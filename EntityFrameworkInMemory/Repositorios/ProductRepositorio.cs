using EntityFrameworkInMemory.DataBaseContext;
using EntityFrameworkInMemory.DataModel;
using EntityFrameworkInMemory.Models;
using EntityFrameworkInMemory.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkInMemory.Repositorios
{
    public class ProductRepositorio : IProductRepositorio
    {
        public readonly DBContext _dBContext;

        public ProductRepositorio(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<ProductModel>> BuscarTodos()
        {
            return await _dBContext.Products.ToListAsync();
        }

        public async Task<ProductModel> BuscarPorNome(string name)
        {
            return await _dBContext.Products.FirstOrDefaultAsync(x => x.ProductName.Equals(name));
        }

        public async Task<List<ProductModel>> BuscarPorCategoria(CategoryDataModel category)
        {
            return await _dBContext.Products.Where(x => x.ProductCategory.Equals(category)).ToListAsync();
        }

        public async Task<ProductModel> BuscarPorCodigo(int codigo)
        {
            return await _dBContext.Products.FirstOrDefaultAsync(x => x.ProductCodigo.Equals(codigo));
        }

        public async Task<bool> Apagar(int codigo)
        {
            ProductModel usuarioPorCodigo = await BuscarPorCodigo(codigo);

            if (usuarioPorCodigo == null)
            {
                throw new Exception($"Produto com o codigo {codigo} nao foi encontrado");
            }

            _dBContext.Products.Remove(usuarioPorCodigo);
            await _dBContext.SaveChangesAsync();

            return true;
        }

        public async Task<ProductModel> Adicionar(ProductDataModel productDataModel)
        {
            ProductModel product =  new ProductModel();
            
            product.ProductId = Guid.NewGuid();
            product.ProductName = productDataModel.Name;
            product.ProductCategory = productDataModel.Category;
            product.ProductPrice = productDataModel.Price;
            product.ProductCodigo = productDataModel.Codigo;

            await _dBContext.Products.AddAsync(product);
            await _dBContext.SaveChangesAsync();
            
            return product;
        }

        public async Task<ProductModel> Atualizar(ProductDataModel atualizarProduto, int codigo)
        {
            ProductModel buscaProdutoPorCodigo = await BuscarPorCodigo(codigo);

            if (BuscarPorCodigo == null)
            {
                throw new Exception("Produto nao localizado");
            }

            buscaProdutoPorCodigo.ProductName = atualizarProduto.Name;
            buscaProdutoPorCodigo.ProductCategory = atualizarProduto.Category;
            buscaProdutoPorCodigo.ProductPrice = atualizarProduto.Price;

            _dBContext.Products.Update(buscaProdutoPorCodigo);
            await _dBContext.SaveChangesAsync();

            return buscaProdutoPorCodigo;
        }
    }
}
