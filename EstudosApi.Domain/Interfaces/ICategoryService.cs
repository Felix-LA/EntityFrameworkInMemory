using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudosApi.Domain.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryModel> BuscarCategoria(CategoryDataModel categoryDataModel);
        CategoryModel Adicionar(CategoryDataModel categoryDataModel);
        CategoryModel BuscarPorId(int id);
        List<CategoryModel> BuscarPorName(string Name);
        //Task<CategoryModel> Atualizar(CategoryDataModel categoryDataModel, int id);
        //Task<bool> Deletar(int id);
    }
}
