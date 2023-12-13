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
                return dBContext.Category.Where(x => x.CategoryName.Contains(categoryDataModel.Name)).ToList();
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

        public bool Deletar(int id)
        {
            var deletarCategoria = new CategoryModel { CategoryId = id };

            if (deletarCategoria.CategoryId < 0)
            {
                throw new Exception("Categoria nao Encontrada");
            }

            dBContext.Category.Attach(deletarCategoria);
            dBContext.Category.Remove(deletarCategoria);
            dBContext.SaveChanges();

            return true;
        }

        public CategoryModel Atualizar(CategoryDataModel categoryDataModel, int id)
        {
            var atualizarCategoria = dBContext.Category.FirstOrDefault(category => category.CategoryId == id);

            if (atualizarCategoria == null)
            {
                throw new Exception("Categoria nao Encontrada");
            }

            atualizarCategoria.CategoryName = categoryDataModel.Name;
            atualizarCategoria.CategoryStatus = categoryDataModel.Status;

            dBContext.Category.Update(atualizarCategoria);
            dBContext.SaveChanges();

            return atualizarCategoria;
        }
    }
}
