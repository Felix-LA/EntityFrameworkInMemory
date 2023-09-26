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
        public async Task<List<ProductModel>> BuscarTodosUsuarios()
        {
            return await _dBContext.Products.ToListAsync();
        }

        public async Task<ProductModel> BuscarPorNome(string name)
        {
            return await _dBContext.Products.FirstOrDefaultAsync(x => x.ProductName.Equals(name));
        }

        public async Task<ProductModel> BuscarPorCategoria(string category)
        {
            return await _dBContext.Products.FirstOrDefaultAsync(x => x.ProductCategory.Equals(category));
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
    }
}
