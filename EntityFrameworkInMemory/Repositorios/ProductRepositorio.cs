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
        public async Task<List<ProductDataModel>> BuscarTodosUsuarios()
        {
            return await _dBContext.Products.ToListAsync();
        }

        public async Task<ProductDataModel> BuscarPorNome(string name)
        {
            return await _dBContext.Products.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public async Task<ProductDataModel> BuscarPorCategoria(string category)
        {
            return await _dBContext.Products.FirstOrDefaultAsync(x => x.Category.Equals(category));
        }

        public async Task<ProductDataModel> BuscarPorCodigo(int codigo)
        {
            return await _dBContext.Products.FirstOrDefaultAsync(x => x.Codigo.Equals(codigo));
        }

        public async Task<bool> Apagar(int codigo)
        {
            ProductDataModel usuarioPorCodigo = await BuscarPorCodigo(codigo);

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
