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

        public async Task<List<ProductModel>> BuscarProdutos(ProductDataModel productDataModel)
        {
            return await productRepositorio.BuscarProdutos(productDataModel);
        }

        public async Task<ProductModel> BuscarProdutosPorId(ProductDataModel productDataModel)
        {
            var list = await productRepositorio.BuscarProdutos(productDataModel);
            return list.FirstOrDefault();
        }

        public async Task<List<ProductModel>> BuscarProdutosPorNome(ProductDataModel productDataModel)
        {
            return await productRepositorio.BuscarProdutos(productDataModel);
        }

        public async Task<ProductModel> Adicionar(ProductDataModel productDataModel)
        {
            return await productRepositorio.Adicionar(productDataModel);
        }
    }
}
