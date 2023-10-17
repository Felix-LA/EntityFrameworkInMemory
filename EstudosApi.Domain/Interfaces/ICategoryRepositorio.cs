using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;

namespace EstudosApi.Domain.Interfaces
{
    public interface ICategoryRepositorio
    {
        Task<List<CategoryModel>> BuscarCategoria(CategoryDataModel categoryDataModel);
        Task<CategoryModel> Adicionar(CategoryDataModel categoryDataModel);
        //Task<CategoryModel> Atualizar(CategoryDataModel categoryDataModel,int id);
        //Task<bool> Deletar(int id);
    }
}
