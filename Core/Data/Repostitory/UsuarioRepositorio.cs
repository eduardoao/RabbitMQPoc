using Domain.Entities;

namespace Data.Repostitory
{
    public class UsuarioRepositorio: Repository<Usuario>
    {

        public UsuarioRepositorio()
        {        

        }

        public UsuarioRepositorio(Context.DataAccessContext  Contexto): base( Contexto)
        {

        }

       
    }
}
