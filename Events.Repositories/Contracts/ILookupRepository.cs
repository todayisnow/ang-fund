
using Events.Common;
using Events.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Events.Repositories
{
    public interface ILookupRepository
    {
        IEnumerable<LookupEntity> FetchAsLookup(Language? language = null, int? pageSize = null, int? pageNumber = null);
    }
    public interface ILookupRepository<T> : ILookupRepository where T :class
    {
        IEnumerable<LookupEntity> FetchAsLookup(Expression<Func<T, bool>> predicate, Language? language = null, int? pageSize = null, int? pageNumber = null);
    }
}
