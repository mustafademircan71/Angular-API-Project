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

        public Expression<Func<TEntity, object>> OrderBy
        {
            get; 

            private set;
        }
        
        public Expression<Func<TEntity, object>> OrderByDescending
        {
            get;

            private set;
        }

        public int Take
        {
            get;

            private set;
        }

        public int Skip
        {
            get;

            private set;
        }

        public bool IsPagingEnabled
        {
            get;

            private set;
        }

        protected void AddInlcude(Expression<Func<TEntity,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<TEntity,object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
        protected void ApplyPaging(int skip,int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
