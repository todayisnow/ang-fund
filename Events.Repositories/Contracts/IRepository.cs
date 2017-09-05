using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Events.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> FetchAll(params Expression<Func<TEntity, object>>[] paths);
        IEnumerable<TEntity> FetchAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageSize, int pageNumber, params Expression<Func<TEntity, object>>[] paths);
        IEnumerable<TEntity> FetchMany(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);
        IEnumerable<TEntity> FetchMany(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int pageSize, int pageNumber, params Expression<Func<TEntity, object>>[] paths);
        IEnumerable<TK> FetchAllOfType<TK>(params Expression<Func<TK, Object>>[] paths);
        IEnumerable<TK> FetchAllOfType<TK>(Func<IQueryable<TK>, IOrderedQueryable<TK>> orderBy, int pageSize, int pageNumber, params Expression<Func<TK, object>>[] paths);
        IEnumerable<TK> FetchManyOfType<TK>(Expression<Func<TK, bool>> predicate, params Expression<Func<TK, object>>[] paths);
        IEnumerable<TK> FetchManyOfType<TK>(Expression<Func<TK, bool>> predicate, Func<IQueryable<TK>, IOrderedQueryable<TK>> orderBy, int pageSize, int pageNumber, params Expression<Func<TK, object>>[] paths);
        TK FetchOfType<TK>(Expression<Func<TK, bool>> predicate, params Expression<Func<TK, object>>[] paths);

        TEntity Fetch(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] paths);
        TEntity Fetch(params object[] keys);
        IEnumerable<TEntity> SqlQuery(string esqlText, object[] parameters);
        void Add(TEntity entity);
        void Update(TEntity entity, Func<TEntity, bool> entitySelector = null);
        void Delete(TEntity entity, Func<TEntity, bool> entitySelector = null);


    }
}
