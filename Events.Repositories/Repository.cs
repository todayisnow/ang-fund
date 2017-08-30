using Events.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Constructors and Factories
        public Repository(DbContext ctx, bool noTracking = true)
        {
            _ctx = ctx as EventsEntities;
            _iRepository = this;
            NoTracking = noTracking;
        }
        #endregion

        #region Fields

        protected readonly EventsEntities _ctx;
        private DbSet<TEntity> _dbSet;
        protected readonly IRepository<TEntity> _iRepository;
        protected bool NoTracking { get; private set; }

        #endregion

        #region Properties

        protected DbSet<TEntity> EntitySet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = _ctx.Set<TEntity>();
                return _dbSet;
            }
        }
        protected DbQuery<TEntity> EntityQuery
        {
            get
            {
                return NoTracking ? EntitySet.AsNoTracking() : EntitySet;
            }
        }
        #endregion

        #region Operations

        IEnumerable<TEntity> IRepository<TEntity>.FetchAll(params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            foreach (var path in paths)
                query = query.Include(path);
            return query.ToList();
        }
        IEnumerable<TEntity> IRepository<TEntity>.FetchAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageSize, int pageNumber, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            if(paths !=null)
            foreach (var path in paths)
                query = query.Include(path);
            return  orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        IEnumerable<TEntity> IRepository<TEntity>.FetchMany(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            foreach (var path in paths)
                query = query.Include(path);
            return query.Where(predicate).ToList();
        }
        IEnumerable<TEntity> IRepository<TEntity>.FetchMany(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageSize, int pageNumber, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            foreach (var path in paths)
                query = query.Include(path);
            query = query.Where(predicate);
            return orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        TEntity IRepository<TEntity>.Fetch(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            foreach (var path in paths)
                query = query.Include(path);
            return query.SingleOrDefault(predicate);
        }
        TEntity IRepository<TEntity>.Fetch(params object[] keys)
        {
            return EntitySet.Find(keys);
        }

        #region Inheritance
        IEnumerable<K> IRepository<TEntity>.FetchAllOfType<K>(params Expression<Func<K, object>>[] paths)
        {
            var query = EntityQuery.OfType<K>().AsQueryable();
            foreach (var path in paths)
                query = query.Include(path);
            return query.ToList();
        }
        IEnumerable<K> IRepository<TEntity>.FetchAllOfType<K>(Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, int pageSize, int pageNumber, params Expression<Func<K, object>>[] paths)
        {
            var query = EntityQuery.OfType<K>().AsQueryable();
            foreach (var path in paths)
                query = query.Include(path);
            return orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        IEnumerable<K> IRepository<TEntity>.FetchManyOfType<K>(Expression<Func<K, bool>> predicate, params Expression<Func<K, object>>[] paths)
        {
            var query = EntityQuery.OfType<K>().AsQueryable();
            foreach (var path in paths)
                query = query.Include(path);
            return query.Where(predicate).ToList();
        }
        IEnumerable<K> IRepository<TEntity>.FetchManyOfType<K>(Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, int pageSize, int pageNumber, params Expression<Func<K, object>>[] paths)
        {
            var query = EntityQuery.OfType<K>().AsQueryable();
            foreach (var path in paths)
                query = query.Include(path);
            query = query.Where(predicate);
            return orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        K IRepository<TEntity>.FetchOfType<K>(Expression<Func<K, bool>> predicate, params Expression<Func<K, object>>[] paths)
        {
            var query = EntityQuery.OfType<K>().AsQueryable();
            foreach (var path in paths)
                query = query.Include(path);
            return query.SingleOrDefault(predicate);
        }
       
        #endregion

        IEnumerable<TEntity> IRepository<TEntity>.SqlQuery(string esqlText, object[] Parameters)
        {
            return EntitySet.SqlQuery(esqlText, Parameters);
        }
        void IRepository<TEntity>.Add(TEntity entity)
        {
            try
            {
                EntitySet.Add(entity);
               
            }
            catch (Exception)
            {
                throw;
            }
        }
        void IRepository<TEntity>.Update(TEntity entity, Func<TEntity, bool> entitySelector = null)
        {
            var dbEntry = _ctx.Entry(entity);
            if (dbEntry.State == EntityState.Detached)
            {
                if (entitySelector != null)
                {
                    var attachedEntity = EntitySet.Local.SingleOrDefault(entitySelector);
                    if (attachedEntity == null)
                        dbEntry.State = EntityState.Modified;
                    else
                    {
                        var attachedEntry = _ctx.Entry(attachedEntity);
                        attachedEntry.CurrentValues.SetValues(entity);
                    }
                }
                else
                {
                    try
                    {
                        dbEntry.State = EntityState.Modified;
                    }
                    catch (InvalidOperationException)
                    {
                        _ctx.Entry(EntitySet.Find(dbEntry.Property("Id").CurrentValue)).CurrentValues.SetValues(entity);
                    }
                }
            }
           
        }
        void IRepository<TEntity>.Delete(TEntity entity, Func<TEntity, bool> entitySelector = null)
        {
            var dbEntry = _ctx.Entry(entity);
            if (dbEntry.State == EntityState.Detached)
            {
                if (entitySelector != null)
                {
                    var attachedEntity = EntitySet.Local.SingleOrDefault(entitySelector);
                    if (attachedEntity == null)
                        dbEntry.State = EntityState.Deleted;
                    else
                        EntitySet.Remove(attachedEntity);
                }
                else
                {
                    try
                    {
                        dbEntry.State = EntityState.Deleted;
                    }
                    catch (InvalidOperationException)
                    {
                        EntitySet.Remove(EntitySet.Find(dbEntry.Property("Id").CurrentValue));
                    }
                }
            }
            else
            {
                EntitySet.Remove(entity);
            }
           
        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && _ctx != null)
                {
                    _ctx.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Repository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
        #endregion

    }
}
