using EstudosApi.Repository.DataBaseContext;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;
using EstudosApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Data.Entity;

namespace EntityFrameworkInMemory.Repositorios
{
    public class ProductRepositorio : IProductRepositorio
    {
        public readonly DBContext dBContext;

        public ProductRepositorio(DBContext _dBContext)
        {
            this.dBContext = _dBContext;
        }

        public List<ProductModel> BuscarProdutos(ProductDataModel productDataModel)
        {
            if (!string.IsNullOrEmpty(productDataModel.Name))
            {
                return dBContext.Products.Where(x => x.ProductName.Equals(productDataModel.Name)).ToList();
            }
            else if (productDataModel.Id > 0) {
                return dBContext.Products.Where(x => x.ProductId.Equals(productDataModel.Id)).ToList();
            }
            else {
                return dBContext.Products.ToList();
                }
            }

        //public async Task<bool> Apagar(int codigo)
        //{
        //    ProductDataModel productDataModel = new ProductDataModel {Codigo= codigo };
        //    var  buscaApagar = await BuscarTodos(productDataModel);


        //    if (!buscaApagar.Any())
        //    {
        //        throw new Exception($"Produto com o codigo {codigo} nao foi encontrado");
        //    }

        //    _dBContext.Products.Remove(productDataModel);
        //    await _dBContext.SaveChangesAsync();

        //    return true;
        //}

        public ProductModel Adicionar(ProductDataModel productDataModel)
        {
            ProductModel product = new ProductModel();
            
            product.CategoryId = productDataModel.IdCategory;
            product.ProductName = productDataModel.Name;
            product.ProductPrice = productDataModel.Price;

            dBContext.Products.Add(product);
            dBContext.SaveChanges();
            
            return product;
        }

        //public async Task<ProductModel> Atualizar(ProductDataModel atualizarProduto, int codigo)
        //{
        //    ProductModel buscaProdutoPorCodigo = await BuscarTodos(codigo);

        //    if (BuscarPorCodigo == null)
        //    {
        //        throw new Exception("Produto nao localizado");
        //    }

        //    buscaProdutoPorCodigo.ProductName = atualizarProduto.Name;
        //    buscaProdutoPorCodigo.ProductPrice = atualizarProduto.Price;

        //    _dBContext.Products.Update(buscaProdutoPorCodigo);
        //    await _dBContext.SaveChangesAsync();

        //    return buscaProdutoPorCodigo;
        //}
    }
}
