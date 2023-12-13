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
            dBContext = _dBContext;
        }

        public List<ProductModel> BuscarProdutos(ProductDataModel productDataModel)
        {
            if (!string.IsNullOrEmpty(productDataModel.Name))
            {
                return dBContext.Products.Where(x => x.ProductName.Contains(productDataModel.Name)).ToList();
            }
            else if (productDataModel.Id > 0) {
                return dBContext.Products.Where(x => x.ProductId.Equals(productDataModel.Id)).ToList();
            }
            else {
                return dBContext.Products.ToList();
                }
            }

        public bool Apagar (int Id)
        {

            var apagarProduto = new ProductModel { ProductId = Id };

            if(apagarProduto.ProductId < 0)
            {
                throw new Exception("Produto Não Encontrado");
            }

            dBContext.Products.Attach(apagarProduto);
            dBContext.Products.Remove(apagarProduto);
            dBContext.SaveChangesAsync();

            return true;
        }

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

        public ProductModel Atualizar(ProductDataModel productDataModel, int id)
        {
            var atualizarProduto = dBContext.Products.FirstOrDefault(product => product.ProductId == id);

            if (atualizarProduto == null)
            {
                throw new Exception("Produto nao localizado");
            }

            atualizarProduto.ProductName = productDataModel.Name;
            atualizarProduto.ProductPrice = productDataModel.Price;

            dBContext.Products.Update(atualizarProduto);
            dBContext.SaveChangesAsync();

            return atualizarProduto;
        }
    }
}
