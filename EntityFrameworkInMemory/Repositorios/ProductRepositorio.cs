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
    }
}
