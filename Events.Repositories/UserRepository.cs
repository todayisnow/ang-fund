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
	public partial class UserRepository : Repository<User>
	{
	
		public UserRepository(DbContext ctx, bool noTracking = true) : base(ctx, noTracking)
		{
		}
			
			
		public IEnumerable<User> FetchAllUsers(params Expression<Func<User, object>>[] paths)
		{
			return _iRepository.FetchAll(paths);
		}
	
		public IEnumerable<User> FetchAllUsers(Func<IQueryable<User>, IOrderedQueryable<User>> orderBy, int pageSize, int pageNumber, params Expression<Func<User, object>>[] paths)
		{
	        return _iRepository.FetchAll(orderBy, pageSize, pageNumber, paths);
		}
	
		public IEnumerable<User> FetchManyUsers(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] paths)
		{
			return _iRepository.FetchMany(predicate, paths);
		}
	
	    public IEnumerable<User> FetchManyUsers(Expression<Func<User, bool>> predicate, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy, int pageSize, int pageNumber, params Expression<Func<User, object>>[] paths)
	    {
	        return _iRepository.FetchMany(predicate, orderBy, pageSize, pageNumber, paths);
	    }
	
		public User FetchUser(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] paths)
		{
			return _iRepository.Fetch(predicate, paths);
		}
	
		
	
		public User FetchUser(params object[] keys)
		{
			return _iRepository.Fetch(keys);
		}
	
		
	
		public IEnumerable<User> SqlQuery(string esqlText, object[] Parameters)
		{
			return _iRepository.SqlQuery(esqlText, Parameters);
		}
	
		public void AddUser(User entity)
		{
			 _iRepository.Add(entity);
		}
	
		
	
		public void UpdateUser(User entity)
		{
			 _iRepository.Update(entity, e => e.Id == entity.Id);
		}
	
		
	
		public void DeleteUser(User entity)
		{
			 _iRepository.Delete(entity, e => e.Id == entity.Id);
		}
	
		
	
	}
	
}
