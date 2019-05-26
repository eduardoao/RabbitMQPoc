using Data.Repostitory;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class AplicationService<T> : BaseService<T> where T : AplicationDomain
    {
        public Repository<T> _repository = new Repository<T>();

        public override IList<T> Get(int id)
        {
            var dta = DateTime.UtcNow.AddMinutes(-id);
            var resultado = _repository.Query(a => a.DateTimeUtc >= dta);
            return resultado;
        }


        public override T Post<V>(T obj)
        {
            //Todo Refatorar ...
            Validate(obj, Activator.CreateInstance<V>());
            //Verificar se existem registros para a máquina.
            var returnvalue = _repository.Query(m => m.MachiName == obj.MachiName);
            var itemservice = returnvalue.Find(s => s.ServiceName == obj.ServiceName);
            if (itemservice != null)
            {
                //Update data from obj//
                itemservice.DateTimeUtc = obj.DateTimeUtc;
                itemservice.ServiceType = obj.ServiceType;
                itemservice.Status = obj.Status;
                _repository.Update(itemservice);
            }
            else
                _repository.Insert(obj);

            return obj;
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("None register!");

            validator.ValidateAndThrow(obj);
        }

    }
}
