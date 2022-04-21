using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace core.Specificatoins
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            
        }
        
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }
        = new List<Expression<Func<T, object>>>();

        public void AddInclued(Expression<Func<T, object>> expression)
        {
            this.Includes.Add(expression);
        }

    }
}