using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;

namespace EntityFrameworkInMemory.Repositorios.Interfaces
{
    public interface IProductRepositorio
    {
        Task<List<ProductModel>> BuscarTodos(ProductDataModel productDataModel);
        Task<ProductModel> Adicionar(ProductDataModel produto);
        //Task<ProductModel> Atualizar(ProductDataModel atualizarProduto, int codigo);
        //Task<bool> Apagar(int codigo);
    }
}
