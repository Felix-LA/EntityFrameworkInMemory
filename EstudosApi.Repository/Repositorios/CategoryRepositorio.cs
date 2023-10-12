using EstudosApi.Repository.DataBaseContext;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;
using EstudosApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkInMemory.Repositorios
{
    public class CategoryRepositorio : ICategoryRepositorio
    {
        public readonly DBContext dBContext;

        public CategoryRepositorio(DBContext _dbContext)
        {
            dBContext = _dbContext;
        }

        public async Task<CategoryModel> Adicionar(CategoryDataModel categoryDataModel)
        {
            CategoryModel categoryModel = new CategoryModel();

            categoryModel.CategoryName = categoryDataModel.Name;
            categoryModel.CategoryStatus = categoryDataModel.Status;

            await dBContext.Category.AddAsync(categoryModel);
            await dBContext.SaveChangesAsync();

            return categoryModel;
        }

        public async Task<List<CategoryModel>> BuscarTodos()
        {
            return await dBContext.Category.ToListAsync();
        }

        public async Task<CategoryModel> BuscarPorId(int id)
        {
            return await dBContext.Category.FirstOrDefaultAsync(x => x.CategoryId.Equals(id));
        }

        public async Task<CategoryModel> BuscarPorName(string name)
        {
            return await dBContext.Category.FirstOrDefaultAsync(x => x.CategoryName.Equals(name));
        }

        public async Task<List<CategoryModel>> BuscarPorStatus(CategoryStatusEnum status)
        {
            return await dBContext.Category.Where(x => x.CategoryStatus.Equals(status)).ToListAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            CategoryModel buscarCategoryPorCodigo = await BuscarPorId(id);

            if (BuscarPorId == null)
            {
                throw new Exception("Categoria nao Encontrada");
            }

            dBContext.Category.Remove(buscarCategoryPorCodigo);
            await dBContext.SaveChangesAsync();

            return true;
        }

        public async Task<CategoryModel> Atualizar(CategoryDataModel categoryDataModel, int id)
        {
            CategoryModel buscarCategoryPorCodigo = await BuscarPorId(id);

            if (BuscarPorId == null)
            {
                throw new Exception("Categoria nao Encontrada");
            }

            buscarCategoryPorCodigo.CategoryName = categoryDataModel.Name;
            buscarCategoryPorCodigo.CategoryStatus = categoryDataModel.Status;

            dBContext.Category.Update(buscarCategoryPorCodigo);
            await dBContext.SaveChangesAsync();

            return buscarCategoryPorCodigo;
        }
    }
}
