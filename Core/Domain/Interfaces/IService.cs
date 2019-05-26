using Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IService<T> where T: Base
    {
        T Post<V>(T entity) where V : AbstractValidator<T>;       

        T Put<V>(T entity) where V : AbstractValidator<T>;

        void Remove(int id);

        IList<T> Get();

        IList<T> Get(int id);

        T GetId(int id);



    }
}
