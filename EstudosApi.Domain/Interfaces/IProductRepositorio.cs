using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;

namespace EstudosApi.Domain.Interfaces
{
    public interface IProductRepositorio
    {
        List<ProductModel> BuscarProdutos(ProductDataModel productDataModel);
        ProductModel Adicionar(ProductDataModel produto);
        //Task<ProductModel> Atualizar(ProductDataModel atualizarProduto, int codigo);
        //Task<bool> Apagar(int codigo);
    }
}
