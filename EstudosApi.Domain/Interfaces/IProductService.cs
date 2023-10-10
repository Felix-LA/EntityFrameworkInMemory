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
        Task<List<ProductModel>> BuscarTodos (ProductDataModel productDataModel);
        Task<ProductModel> Adicionar(ProductDataModel produto);
    }
}
