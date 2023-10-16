using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosApi.Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> BuscarProdutos (ProductDataModel productDataModel);
        Task<ProductModel> BuscarProdutosPorId(ProductDataModel productDataModel);
        Task<List<ProductModel>> BuscarProdutosPorNome(ProductDataModel productDataModel);
        Task<ProductModel> Adicionar(ProductDataModel produto);
    }
}
