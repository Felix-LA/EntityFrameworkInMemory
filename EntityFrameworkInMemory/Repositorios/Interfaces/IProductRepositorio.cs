using EntityFrameworkInMemory.DataModel;
using EntityFrameworkInMemory.Models;

namespace EntityFrameworkInMemory.Repositorios.Interfaces
{
    public interface IProductRepositorio
    {
        Task<List<ProductModel>> BuscarTodosUsuarios();
        Task<ProductModel> BuscarPorNome(string name);
        Task<ProductModel> BuscarPorCategoria(string category);
        Task<ProductModel> BuscarPorCodigo(int codigo);
        Task<bool> Apagar(int codigo);
    }
}
