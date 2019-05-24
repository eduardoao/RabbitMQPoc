
using Data.Repostitory;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class BaseService<T> : IService<T> where T : Base
    {

        public Repository<T> repository = new Repository<T>();

        public virtual T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public virtual T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public virtual void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Delete(id);
        }

        public virtual IList<T> Get() => repository.SelectAll();

        public virtual T GetId(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

        public virtual void Remove(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Delete(id);

        }
    }
}
