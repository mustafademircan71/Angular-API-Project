using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Core.Spesicifications
{
    public interface ISpesification<TEntity>
    {
        Expression<Func<TEntity,bool>> Creteria { get; }
        List<Expression<Func<TEntity,object>>> Includes { get; }
    }
}
