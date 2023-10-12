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

        public async Task<CategoryModel> Atualizar(CategoryDataModel categoryDataModel, int id)
        {
            return await categoryRepository.Atualizar(categoryDataModel, id);
        }

        public async Task<CategoryModel> BuscarPorId(int id)
        {
            return await categoryRepository.BuscarPorId(id);
        }

        public async Task<CategoryModel> BuscarPorName(string name)
        {
            return await categoryRepository.BuscarPorName(name);
        }

        public async Task<List<CategoryModel>> BuscarPorStatus(CategoryStatusEnum status)
        {
            return await categoryRepository.BuscarPorStatus(status);
        }

        public async Task<List<CategoryModel>> BuscarTodos()
        {
            return await categoryRepository.BuscarTodos();
        }

        public async Task<bool> Deletar(int id)
        {
            return await categoryRepository.Deletar(id);
        }
    }
}
