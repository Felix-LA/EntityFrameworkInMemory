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
        public readonly ICategoryRepositorio categoryRepository;
        public CategoryService(ICategoryRepositorio _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public async Task<CategoryModel> Adicionar(CategoryDataModel categoryDataModel)
        {
            return await categoryRepository.Adicionar(categoryDataModel);
        }

        public async Task<List<CategoryModel>> BuscarCategoria(CategoryDataModel categoryDataModel)
        {
            return await categoryRepository.BuscarCategoria(categoryDataModel);
        }

        public async Task<CategoryModel> BuscarPorId(int id)
        {
            CategoryDataModel categoryDataModel = new CategoryDataModel { Id = id };
            var list = await categoryRepository.BuscarCategoria(categoryDataModel);
            return list.FirstOrDefault();
        }

        public async Task<List<CategoryModel>> BuscarPorName(string name)
        {
            CategoryDataModel categoryDataModel = new CategoryDataModel { Name = name };
            var list = await categoryRepository.BuscarCategoria(categoryDataModel);
            return list.ToList();
        }

        //public async Task<CategoryModel> Atualizar(CategoryDataModel categoryDataModel, int id)
        //{
        //    return await categoryRepository.Atualizar(categoryDataModel, id);
        //}

        //public async Task<List<CategoryModel>> BuscarPorStatus(CategoryStatusEnum status)
        //{
        //    return await categoryRepository.BuscarPorStatus(status);
        //}

        //public async Task<bool> Deletar(int id)
        //{
        //    return await categoryRepository.Deletar(id);
        //}
    }
}
