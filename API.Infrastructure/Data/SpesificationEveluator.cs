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

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
