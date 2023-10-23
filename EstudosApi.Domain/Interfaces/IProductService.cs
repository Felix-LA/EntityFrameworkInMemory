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
        List<ProductModel> BuscarProdutos (ProductDataModel productDataModel);
        ProductModel BuscarProdutosPorId(int id);
        List<ProductModel> BuscarProdutosPorNome(string name);
        ProductModel Adicionar(ProductDataModel produto);
        bool Apagar(int id);
    }
}
