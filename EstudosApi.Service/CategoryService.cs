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
        public readonly ICategoryService categoryService;
        public CategoryService(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public async Task<CategoryModel> Adicionar(CategoryDataModel categoryDataModel)
        {
            return await categoryService.Adicionar(categoryDataModel);
        }

        public async Task<CategoryModel> Atualizar(CategoryDataModel categoryDataModel, int codigo)
        {
            return await categoryService.Atualizar(categoryDataModel, codigo);
        }

        public async Task<CategoryModel> BuscarPorCodigo(int codigo)
        {
            return await categoryService.BuscarPorCodigo(codigo);
        }

        public async Task<CategoryModel> BuscarPorName(string name)
        {
            return await categoryService.BuscarPorName(name);
        }

        public async Task<List<CategoryModel>> BuscarPorStatus(CategoryStatusEnum status)
        {
            return await categoryService.BuscarPorStatus(status);
        }

        public async Task<List<CategoryModel>> BuscarTodos()
        {
            return await categoryService.BuscarTodos();
        }

        public async Task<bool> Deletar(int codigo)
        {
            return await categoryService.Deletar(codigo);
        }
    }
}
