using System.Linq;
using core.Specificatoins;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Criteria!=null)
            {
                query=query.Where(spec.Criteria);
            }
            query=spec.Includes.Aggregate(query,(current,include)=>current.Include(include));
            return query;
        }
    }
}