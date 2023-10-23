using EstudosApi.Domain.Interfaces;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;

namespace EstudosApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositorio iproductRepositorio;

        public ProductService (IProductRepositorio _iproductRepositorio)
        {
            iproductRepositorio = _iproductRepositorio;
        }

        public List<ProductModel> BuscarProdutos(ProductDataModel productDataModel)
        {
            return iproductRepositorio.BuscarProdutos(productDataModel);
        }

        public ProductModel BuscarProdutosPorId(int id)
        {
            ProductDataModel productDataModel = new (){Id = id};
            var list = iproductRepositorio.BuscarProdutos(productDataModel);
            return list.FirstOrDefault();
        }

        public List<ProductModel> BuscarProdutosPorNome(string name)
        {
            ProductDataModel productDataModel = new() { Name = name};
            return iproductRepositorio.BuscarProdutos(productDataModel);
        }

        public ProductModel Adicionar(ProductDataModel productDataModel)
        {
            return iproductRepositorio.Adicionar(productDataModel);
        }

        public bool Apagar(int id)
        {
            return iproductRepositorio.Apagar(id);
        }
    }
}
