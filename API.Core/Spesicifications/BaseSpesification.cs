using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Spesicifications
{
    public class BaseSpesification<TEntity> : ISpesification<TEntity>
    {
        public BaseSpesification()
        {

        }
        public BaseSpesification(Expression<Func<TEntity,bool>> criteria)
        {
            Creteria = criteria;
        }
        public Expression<Func<TEntity, bool>> Creteria { get; }
         
        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        protected void AddInlcude(Expression<Func<TEntity,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
