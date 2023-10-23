using EntityFrameworkInMemory.Repositorios;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Interfaces;
using EstudosApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosApi.Service
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepositorio icategoryRepository;
        public CategoryService(ICategoryRepositorio _icategoryRepository)
        {
            icategoryRepository = _icategoryRepository;
        }

        public CategoryModel Adicionar(CategoryDataModel categoryDataModel)
        {
            return icategoryRepository.Adicionar(categoryDataModel);
        }

        public List<CategoryModel> BuscarCategoria(CategoryDataModel categoryDataModel)
        {
            return  icategoryRepository.BuscarCategoria(categoryDataModel);
        }

        public CategoryModel BuscarPorId(int id)
        {
            CategoryDataModel categoryDataModel = new CategoryDataModel { Id = id };
            var list =  icategoryRepository.BuscarCategoria(categoryDataModel);
            return list.FirstOrDefault();
        }

        public List<CategoryModel> BuscarPorName(string name)
        {
            CategoryDataModel categoryDataModel = new CategoryDataModel { Name = name };
            var list = icategoryRepository.BuscarCategoria(categoryDataModel);
            return list.ToList();
        }

        public CategoryModel Atualizar(CategoryDataModel categoryDataModel, int id)
        {
            return  icategoryRepository.Atualizar(categoryDataModel, id);
        }

        //public async Task<List<CategoryModel>> BuscarPorStatus(CategoryStatusEnum status)
        //{
        //    return await categoryRepository.BuscarPorStatus(status);
        //}

        public bool Deletar(int id)
        {
            return  icategoryRepository.Deletar(id);
        }
    }
}
