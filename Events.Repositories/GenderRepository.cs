//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Events.EF;
using Events.Entities;
using Events.Common;

namespace Events.Repositories
{
	public partial class GenderRepository : Repository<Gender>, ILookupRepository<Gender>
	{
	
		public GenderRepository(DbContext ctx, bool noTracking = true) : base(ctx, noTracking)
		{
		}
			
			
		public IEnumerable<Gender> FetchAllGenders(params Expression<Func<Gender, object>>[] paths)
		{
			return _iRepository.FetchAll(paths);
		}
	
		public IEnumerable<Gender> FetchAllGenders(Func<IQueryable<Gender>, IOrderedQueryable<Gender>> orderBy, int pageSize, int pageNumber, params Expression<Func<Gender, object>>[] paths)
		{
	        return _iRepository.FetchAll(orderBy, pageSize, pageNumber, paths);
		}
	
		public IEnumerable<Gender> FetchManyGenders(Expression<Func<Gender, bool>> predicate, params Expression<Func<Gender, object>>[] paths)
		{
			return _iRepository.FetchMany(predicate, paths);
		}
	
	    public IEnumerable<Gender> FetchManyGenders(Expression<Func<Gender, bool>> predicate, Func<IQueryable<Gender>, IOrderedQueryable<Gender>> orderBy, int pageSize, int pageNumber, params Expression<Func<Gender, object>>[] paths)
	    {
	        return _iRepository.FetchMany(predicate, orderBy, pageSize, pageNumber, paths);
	    }
	
		public Gender FetchGender(Expression<Func<Gender, bool>> predicate, params Expression<Func<Gender, object>>[] paths)
		{
			return _iRepository.Fetch(predicate, paths);
		}
	
		
	
		public Gender FetchGender(params object[] keys)
		{
			return _iRepository.Fetch(keys);
		}
	
		
	
		public IEnumerable<Gender> SqlQuery(string esqlText, object[] Parameters)
		{
			return _iRepository.SqlQuery(esqlText, Parameters);
		}
	
		public void AddGender(Gender entity)
		{
			 _iRepository.Add(entity);
		}
	
		
	
		public void UpdateGender(Gender entity)
		{
			 _iRepository.Update(entity, e => e.Id == entity.Id);
		}
	
		
	
		public void DeleteGender(Gender entity)
		{
			 _iRepository.Delete(entity, e => e.Id == entity.Id);
		}
	
		
	
		#region ILookupRepository<T> contract
	    public IEnumerable<LookupEntity> FetchAsLookup(Language? language = null, int? pageSize = null, int? pageNumber = null)
	    {
	        return FetchAsLookup(null, language, pageSize, pageNumber);
	    }
	
	    
	
	    public IEnumerable<LookupEntity> FetchAsLookup(Expression<Func<Gender, bool>> predicate, Language? language,  int? pageSize = null, int? pageNumber = null)
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
