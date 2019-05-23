using Data.Repostitory;
using Domain.Entities;

namespace Service.Services
{
    public class ProdutoService<Produto> : BaseService<Produto> where Produto : Base
    {
        private new readonly UsuarioRepositorio repository = new UsuarioRepositorio();     
    }
}
