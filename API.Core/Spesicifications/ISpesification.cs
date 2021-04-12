using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Core.Spesicifications
{
    public interface ISpesification<TEntity>
    {
        Expression<Func<TEntity,bool>> Creteria { get; }
        List<Expression<Func<TEntity,object>>> Includes { get; }
        Expression<Func<TEntity,object>> OrderBy { get; }
        Expression<Func<TEntity,object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
