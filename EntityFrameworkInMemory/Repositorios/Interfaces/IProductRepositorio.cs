using EntityFrameworkInMemory.DataModel;
using EntityFrameworkInMemory.Models;

namespace EntityFrameworkInMemory.Repositorios.Interfaces
{
    public interface IProductRepositorio
    {
        Task<List<ProductModel>> BuscarTodos();
        Task<ProductModel> Adicionar(ProductDataModel produto);
        Task<ProductModel> Atualizar(ProductDataModel atualizarProduto, int codigo);
        Task<ProductModel> BuscarPorNome(string name);
        Task<List<ProductModel>> BuscarPorCategoria(string category);
        Task<ProductModel> BuscarPorCodigo(int codigo);
        Task<bool> Apagar(int codigo);
    }
}
