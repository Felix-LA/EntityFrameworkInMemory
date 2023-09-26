using EntityFrameworkInMemory.DataModel;
using EntityFrameworkInMemory.Models;

namespace EntityFrameworkInMemory.Repositorios.Interfaces
{
    public interface IProductRepositorio
    {
        Task<List<ProductDataModel>> BuscarTodosUsuarios();
        Task<ProductDataModel> BuscarPorNome(string name);
        Task<ProductDataModel> BuscarPorCategoria(string category);
        Task<ProductDataModel> BuscarPorCodigo(int codigo);
        Task<bool> Apagar(int codigo);
    }
}
