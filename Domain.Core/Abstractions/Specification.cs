﻿using System;
using System.Linq.Expressions;

namespace Domain.Core.Abstractions
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}