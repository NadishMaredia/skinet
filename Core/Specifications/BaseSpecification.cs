using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<System.Func<T, bool>> Criteria {get;}

        public List<System.Linq.Expressions.Expression<System.Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();
    
    
    }
}