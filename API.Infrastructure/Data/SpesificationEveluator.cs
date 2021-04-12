using API.Core.DbModels;
using API.Core.Spesicifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Infrastructure.Data
{
    public class SpesificationEveluator<TEntiy> 
        where TEntiy:BaseEntity
    {
        public static IQueryable<TEntiy> GetQuery(IQueryable<TEntiy> inputQuery,ISpesification<TEntiy> spec)
        {
            var query = inputQuery;

            if (spec.Creteria !=null)
            {
                query = query.Where(spec.Creteria);
            }
            if (spec.OrderBy!=null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending!=null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
