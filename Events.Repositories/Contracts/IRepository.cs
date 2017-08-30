using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> FetchAll(params Expression<Func<TEntity, object>>[] paths);
        IEnumerable<TEntity> FetchAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageSize, int pageNumber, params Expression<Func<TEntity, object>>[] paths);
        IEnumerable<TEntity> FetchMany(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);
        IEnumerable<TEntity> FetchMany(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageSize, int pageNumber, params Expression<Func<TEntity, object>>[] paths);
        IEnumerable<K> FetchAllOfType<K>(params Expression<Func<K, Object>>[] paths);
        IEnumerable<K> FetchAllOfType<K>(Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, int pageSize, int pageNumber, params Expression<Func<K, object>>[] paths);
        IEnumerable<K> FetchManyOfType<K>(Expression<Func<K, bool>> predicate, params Expression<Func<K, object>>[] paths);
        IEnumerable<K> FetchManyOfType<K>(Expression<Func<K, bool>> predicate, Func<IQueryable<K>, IOrderedQueryable<K>> orderBy, int pageSize, int pageNumber, params Expression<Func<K, object>>[] paths);
        K FetchOfType<K>(Expression<Func<K, bool>> predicate, params Expression<Func<K, object>>[] paths);
        
        TEntity Fetch(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);
        TEntity Fetch(params object[] keys);
        IEnumerable<TEntity> SqlQuery(string esqlText, object[] parameters);
        void Add(TEntity entity);
        void Update(TEntity entity, Func<TEntity, bool> entitySelector = null);
        void Delete(TEntity entity, Func<TEntity, bool> entitySelector = null);


    }
}
