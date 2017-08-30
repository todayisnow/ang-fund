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
	public partial class CountryRepository : Repository<Country>
	{
	
		public CountryRepository(DbContext ctx, bool noTracking = true) : base(ctx, noTracking)
		{
		}
			
			
		public IEnumerable<Country> FetchAllCountries(params Expression<Func<Country, object>>[] paths)
		{
			return _iRepository.FetchAll(paths);
		}
	
		public IEnumerable<Country> FetchAllCountries(Func<IQueryable<Country>, IOrderedQueryable<Country>> orderBy, int pageSize, int pageNumber, params Expression<Func<Country, object>>[] paths)
		{
	        return _iRepository.FetchAll(orderBy, pageSize, pageNumber, paths);
		}
	
		public IEnumerable<Country> FetchManyCountries(Expression<Func<Country, bool>> predicate, params Expression<Func<Country, object>>[] paths)
		{
			return _iRepository.FetchMany(predicate, paths);
		}
	
	    public IEnumerable<Country> FetchManyCountries(Expression<Func<Country, bool>> predicate, Func<IQueryable<Country>, IOrderedQueryable<Country>> orderBy, int pageSize, int pageNumber, params Expression<Func<Country, object>>[] paths)
	    {
	        return _iRepository.FetchMany(predicate, orderBy, pageSize, pageNumber, paths);
	    }
	
		public Country FetchCountry(Expression<Func<Country, bool>> predicate, params Expression<Func<Country, object>>[] paths)
		{
			return _iRepository.Fetch(predicate, paths);
		}
	
		
	
		public Country FetchCountry(params object[] keys)
		{
			return _iRepository.Fetch(keys);
		}
	
		
	
		public IEnumerable<Country> SqlQuery(string esqlText, object[] Parameters)
		{
			return _iRepository.SqlQuery(esqlText, Parameters);
		}
	
		public void AddCountry(Country entity)
		{
			 _iRepository.Add(entity);
		}
	
		
	
		public void UpdateCountry(Country entity)
		{
			 _iRepository.Update(entity, e => e.Id == entity.Id);
		}
	
		
	
		public void DeleteCountry(Country entity)
		{
			 _iRepository.Delete(entity, e => e.Id == entity.Id);
		}
	
		
	
	}
	
}