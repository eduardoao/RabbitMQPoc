using Domain.Entities;
using System;
using System.Linq;

namespace Data.Repostitory
{
    public class AplicationRepositorio: Repository<AplicationDomain>
    {
        private Context.DataAccessContext context;

        public AplicationRepositorio()
        {
            context = Activator.CreateInstance<Context.DataAccessContext>();

        }

        public AplicationRepositorio(Context.DataAccessContext  Contexto): base( Contexto)
        {

        }


        public override AplicationDomain Select(int id)
        {       

            return base.Select(id);
        }

     



    }
}
