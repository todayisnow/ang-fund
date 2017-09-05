//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

	using Events.Common;


using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections.Generic;
using Events.Entities;

namespace Events.Repositories
{
	public partial class LevelRepository : Repository<Level>, ILookupRepository<Level>
	{
	
		public LevelRepository(DbContext ctx, bool noTracking = true) : base(ctx, noTracking)
		{
		}
			
			
		public IEnumerable<Level> FetchAllLevels(params Expression<Func<Level, object>>[] paths)
		{
			return IRepository.FetchAll(paths);
		}
	
		public IEnumerable<Level> FetchAllLevels(Func<IQueryable<Level>, IOrderedQueryable<Level>> orderBy, int pageSize, int pageNumber, params Expression<Func<Level, object>>[] paths)
		{
	        return IRepository.FetchAll(orderBy, pageSize, pageNumber, paths);
		}
	
		public IEnumerable<Level> FetchManyLevels(Expression<Func<Level, bool>> predicate, params Expression<Func<Level, object>>[] paths)
		{
			return IRepository.FetchMany(predicate, paths);
		}
	
	    public IEnumerable<Level> FetchManyLevels(Expression<Func<Level, bool>> predicate, Func<IQueryable<Level>, IOrderedQueryable<Level>> orderBy, int pageSize, int pageNumber, params Expression<Func<Level, object>>[] paths)
	    {
	        return IRepository.FetchMany(predicate, orderBy, pageSize, pageNumber, paths);
	    }
	
		public Level FetchLevel(Expression<Func<Level, bool>> predicate, params Expression<Func<Level, object>>[] paths)
		{
			return IRepository.Fetch(predicate, paths);
		}
	
		
	
		public Level FetchLevel(params object[] keys)
		{
			return IRepository.Fetch(keys);
		}
	
		
	
		public IEnumerable<Level> SqlQuery(string esqlText, object[] Parameters)
		{
			return IRepository.SqlQuery(esqlText, Parameters);
		}
	
		public void AddLevel(Level entity)
		{
			 IRepository.Add(entity);
		}
	
		
	
		public void UpdateLevel(Level entity)
		{
			 IRepository.Update(entity, e => e.Id == entity.Id);
		}
	
		
	
		public void DeleteLevel(Level entity)
		{
			 IRepository.Delete(entity, e => e.Id == entity.Id);
		}
	
		
	
		#region ILookupRepository<T> contract
	    public IEnumerable<LookupEntity> FetchAsLookup(Language? language = null, int? pageSize = null, int? pageNumber = null)
	    {
	        return FetchAsLookup(null, language, pageSize, pageNumber);
	    }
	
	    
	
	    public IEnumerable<LookupEntity> FetchAsLookup(Expression<Func<Level, bool>> predicate, Language? language,  int? pageSize = null, int? pageNumber = null)
		{
	        var query = EntityQuery.AsQueryable();
	            
	        if (predicate != null)
	            query = query.Where(predicate);
	        var lookupQuery = ((language ?? Language.Ar) == Language.Ar) ?
	            query.Select(e => new { Id = e.Id, Name = e.NameAr }) : query.Select(e => new { Id = e.Id, Name = e.NameEn });
	        if (pageSize.HasValue && pageNumber.HasValue)
	            lookupQuery = lookupQuery.OrderBy(e => e.Name).Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
	        var result = lookupQuery.ToList();
	        return result.Select(e => new LookupEntity { Id = Convert.ToInt32(e.Id), Name = Convert.ToString(e.Name) });
	    }
		
		
		#endregion
	}
	
}
