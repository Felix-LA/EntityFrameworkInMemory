using EntityFrameworkInMemory.DataBaseContext;
using EntityFrameworkInMemory.DataModel;
using EntityFrameworkInMemory.Enums;
using EntityFrameworkInMemory.Models;
using EntityFrameworkInMemory.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkInMemory.Repositorios
{
    public class CategoryRepositorio : ICategoryRepositorio
    {
        public readonly DBContext _dBContext;

        public CategoryRepositorio(DBContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<CategoryModel> Adicionar(CategoryDataModel categoryDataModel)
        {
            CategoryModel categoryModel = new CategoryModel();

            categoryModel.CategoryName = categoryDataModel.Name;
            categoryModel.CategoryStatus = categoryDataModel.Status;
            categoryModel.CategoryCodigo = categoryDataModel.Codigo;

            await _dBContext.Category.AddAsync(categoryModel);
            await _dBContext.SaveChangesAsync();

            return categoryModel;
        }

        public async Task<List<CategoryModel>> BuscarTodos()
        {
            return await _dBContext.Category.ToListAsync();
        }

        public async Task<CategoryModel> BuscarPorCodigo(int codigo)
        {
            return await _dBContext.Category.FirstOrDefaultAsync(x => x.CategoryCodigo.Equals(codigo));
        }

        public async Task<CategoryModel> BuscarPorName(string name)
        {
            return await _dBContext.Category.FirstOrDefaultAsync(x => x.CategoryName.Equals(name));
        }

        public async Task<List<CategoryModel>> BuscarPorStatus(CategoryStatusEnum status)
        {
            return await _dBContext.Category.Where(x => x.CategoryStatus.Equals(status)).ToListAsync();
        }

        public async Task<bool> Deletar(int codigo)
        {
            CategoryModel buscarCategoryPorCodigo = await BuscarPorCodigo(codigo);

            if (BuscarPorCodigo == null)
            {
                throw new Exception("Categoria nao Encontrada");
            }

            _dBContext.Category.Remove(buscarCategoryPorCodigo);
            await _dBContext.SaveChangesAsync();

            return true;
        }

        public async Task<CategoryModel> Atualizar(CategoryDataModel categoryDataModel, int codigo)
        {
            CategoryModel buscarCategoryPorCodigo = await BuscarPorCodigo(codigo);

            if (BuscarPorCodigo == null)
            {
                throw new Exception("Categoria nao Encontrada");
            }

            buscarCategoryPorCodigo.CategoryName = categoryDataModel.Name;
            buscarCategoryPorCodigo.CategoryStatus = categoryDataModel.Status;

            _dBContext.Category.Update(buscarCategoryPorCodigo);
            await _dBContext.SaveChangesAsync();

            return buscarCategoryPorCodigo;
        }
    }
}
