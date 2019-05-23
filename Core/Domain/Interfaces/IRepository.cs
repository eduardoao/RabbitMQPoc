using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T: Base
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);

        T Select(int id);

        IList<T> SelectAll();

    }
}
