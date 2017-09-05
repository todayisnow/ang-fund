using Events.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Events.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Constructors and Factories

        public Repository(DbContext ctx, bool noTracking = true)
        {
            _ctx = ctx as EventsEntities;
            IRepository = this;
            NoTracking = noTracking;
        }
        #endregion

        #region Fields

        private readonly EventsEntities _ctx;
        private DbSet<TEntity> _dbSet;
        protected readonly IRepository<TEntity> IRepository;
        private bool NoTracking { get; set; }

        #endregion

        #region Properties

        private DbSet<TEntity> EntitySet => _dbSet ?? (_dbSet = _ctx.Set<TEntity>());

        protected DbQuery<TEntity> EntityQuery => NoTracking ? EntitySet.AsNoTracking() : EntitySet;

        #endregion

        #region Operations

        IEnumerable<TEntity> IRepository<TEntity>.FetchAll(params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            if (paths != null)
                query = paths.Aggregate(query, (current, path) => current.Include(path));
            return query.ToList();
        }
        IEnumerable<TEntity> IRepository<TEntity>.FetchAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageSize, int pageNumber, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            if (paths != null)
                query = paths.Aggregate(query, (current, path) => current.Include(path));
            return orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        IEnumerable<TEntity> IRepository<TEntity>.FetchMany(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            if (paths != null)
                query = paths.Aggregate(query, (current, path) => current.Include(path));
            return query.Where(predicate).ToList();
        }
        IEnumerable<TEntity> IRepository<TEntity>.FetchMany(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageSize, int pageNumber, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            if (paths != null)
                query = paths.Aggregate(query, (current, path) => current.Include(path));
            query = query.Where(predicate);
            return orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        TEntity IRepository<TEntity>.Fetch(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths)
        {
            var query = EntityQuery.AsQueryable();
            if (paths != null)
                query = paths.Aggregate(query, (current, path) => current.Include(path));
            return query.SingleOrDefault(predicate);
        }
        TEntity IRepository<TEntity>.Fetch(params object[] keys)
        {
            return EntitySet.Find(keys);
        }

        #region Inheritance
        IEnumerable<TK> IRepository<TEntity>.FetchAllOfType<TK>(params Expression<Func<TK, object>>[] paths)
        {
            var query = EntityQuery.OfType<TK>().AsQueryable();
            if (paths != null) query = paths.Aggregate(query, (current, path) => current.Include(path));
            return query.ToList();
        }
        IEnumerable<TK> IRepository<TEntity>.FetchAllOfType<TK>(Func<IQueryable<TK>, IOrderedQueryable<TK>> orderBy, int pageSize, int pageNumber, params Expression<Func<TK, object>>[] paths)
        {
            var query = EntityQuery.OfType<TK>().AsQueryable();
            if (paths != null) query = paths.Aggregate(query, (current, path) => current.Include(path));
            return orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        IEnumerable<TK> IRepository<TEntity>.FetchManyOfType<TK>(Expression<Func<TK, bool>> predicate, params Expression<Func<TK, object>>[] paths)
        {
            var query = EntityQuery.OfType<TK>().AsQueryable();
            if (paths != null) query = paths.Aggregate(query, (current, path) => current.Include(path));
            return query.Where(predicate).ToList();
        }
        IEnumerable<TK> IRepository<TEntity>.FetchManyOfType<TK>(Expression<Func<TK, bool>> predicate, Func<IQueryable<TK>, IOrderedQueryable<TK>> orderBy, int pageSize, int pageNumber, params Expression<Func<TK, object>>[] paths)
        {
            var query = EntityQuery.OfType<TK>().AsQueryable();
            if (paths != null) query = paths.Aggregate(query, (current, path) => current.Include(path));
            query = query.Where(predicate);
            return orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        TK IRepository<TEntity>.FetchOfType<TK>(Expression<Func<TK, bool>> predicate, params Expression<Func<TK, object>>[] paths)
        {
            var query = EntityQuery.OfType<TK>().AsQueryable();

            if (paths != null) query = paths.Aggregate(query, (current, path) => current.Include(path));
            return query.SingleOrDefault(predicate);
        }

        #endregion

        IEnumerable<TEntity> IRepository<TEntity>.SqlQuery(string esqlText, object[] parameters)
        {
            return EntitySet.SqlQuery(esqlText, parameters);
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
        private bool _disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _ctx?.Dispose();
                }
                _disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #endregion

    }
}
