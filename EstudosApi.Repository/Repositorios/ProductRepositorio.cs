using EstudosApi.Repository.DataBaseContext;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;
using EstudosApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EntityFrameworkInMemory.Repositorios
{
    public class ProductRepositorio : IProductRepositorio
    {
        public readonly DBContext dBContext;

        public ProductRepositorio(DBContext _dBContext)
        {
            this.dBContext = _dBContext;
        }

        public async Task<List<ProductModel>> BuscarTodos(ProductDataModel productDataModel)
        {
            if (productDataModel.Name != null)
            {
                return await dBContext.Products.Where(x => x.ProductName.Equals(productDataModel.Name)).ToListAsync();
            }
            if (productDataModel.Codigo != null) {
                return await dBContext.Products.Where(x => x.ProductCodigo.Equals(productDataModel.Codigo)).ToListAsync();
            }
            else {

                return await dBContext.Products.ToListAsync();
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

        public async Task<ProductModel> Adicionar(ProductDataModel productDataModel)
        {
            ProductModel product = new ProductModel();
            
            product.ProductId = productDataModel.IdCategory;
            product.ProductName = productDataModel.Name;
            product.ProductPrice = productDataModel.Price;
            product.ProductCodigo = productDataModel.Codigo;

            await dBContext.Products.AddAsync(product);
            await dBContext.SaveChangesAsync();
            
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
