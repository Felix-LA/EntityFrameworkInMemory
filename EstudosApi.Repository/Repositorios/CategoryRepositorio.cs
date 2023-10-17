using EstudosApi.Repository.DataBaseContext;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;
using EstudosApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EntityFrameworkInMemory.Repositorios
{
    public class CategoryRepositorio : ICategoryRepositorio
    {
        public readonly DBContext dBContext;

        public CategoryRepositorio(DBContext _dbContext)
        {
            dBContext = _dbContext;
        }

        public CategoryModel Adicionar(CategoryDataModel categoryDataModel)
        {
            CategoryModel categoryModel = new CategoryModel();

            categoryModel.CategoryName = categoryDataModel.Name;
            categoryModel.CategoryStatus = categoryDataModel.Status;

            dBContext.Category.Add(categoryModel);
            dBContext.SaveChanges();

            return categoryModel;
        }

        public List<CategoryModel> BuscarCategoria(CategoryDataModel categoryDataModel)
        {
            if (categoryDataModel.Id > 0)
            {
                return dBContext.Category.Where(x => x.CategoryId.Equals(categoryDataModel)).ToList();
            }
            else if (categoryDataModel.Name != null)
            {
                return dBContext.Category.Where(x => x.CategoryName.Equals(categoryDataModel.Name)).ToList();
            }
            else
            {
                return dBContext.Category.ToList();
            }
            
        }

        //public async Task<List<CategoryModel>> BuscarPorStatus(CategoryStatusEnum status)
        //{
        //    return await dBContext.Category.Where(x => x.CategoryStatus.Equals(status)).ToListAsync();
        //}

        //public async Task<bool> Deletar(int id)
        //{
        //    CategoryModel buscarCategoryPorCodigo = await BuscarPorId(id);

        //    if (BuscarPorId == null)
        //    {
        //        throw new Exception("Categoria nao Encontrada");
        //    }

        //    dBContext.Category.Remove(buscarCategoryPorCodigo);
        //    await dBContext.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<CategoryModel> Atualizar(CategoryDataModel categoryDataModel, int id)
        //{
        //    CategoryModel buscarCategoryPorCodigo = await BuscarPorId(id);

        //    if (BuscarPorId == null)
        //    {
        //        throw new Exception("Categoria nao Encontrada");
        //    }

        //    buscarCategoryPorCodigo.CategoryName = categoryDataModel.Name;
        //    buscarCategoryPorCodigo.CategoryStatus = categoryDataModel.Status;

        //    dBContext.Category.Update(buscarCategoryPorCodigo);
        //    await dBContext.SaveChangesAsync();

        //    return buscarCategoryPorCodigo;
        //}
    }
}
