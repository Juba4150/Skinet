using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace core.Specificatoins
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get;  }
        List<Expression<Func<T,Object>>> Includes{get;}
    }
}