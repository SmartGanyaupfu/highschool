﻿using System;
using System.Linq.Expressions;

namespace HighSchool.Contracts
{
    public interface IGenericRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
            bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

