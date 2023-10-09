using EstudosApi.Domain.Interfaces;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositorio productRepositorio;

        public ProductService (IProductRepositorio _productRepositorio)
        {
            productRepositorio = _productRepositorio;
        }

        public async Task<List<ProductModel>> BuscarTodos(ProductDataModel productDataModel)
        {
            return await productRepositorio.BuscarTodos(productDataModel);
        }

        public async Task<ProductModel> Adicionar(ProductDataModel productDataModel)
        {
            return await productRepositorio.Adicionar(productDataModel);
        }
    }
}
