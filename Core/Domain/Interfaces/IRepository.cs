using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T: Base
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);

        T Select(int id);

        IList<T> SelectAll();

        List<T> Query(Expression<Func<T, bool>> predicate);

    }
}
