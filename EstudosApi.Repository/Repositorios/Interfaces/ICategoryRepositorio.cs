using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;

namespace EntityFrameworkInMemory.Repositorios.Interfaces
{
    public interface ICategoryRepositorio
    {
        Task<List<CategoryModel>> BuscarTodos();
        Task<CategoryModel> Adicionar(CategoryDataModel categoryDataModel);
        Task<CategoryModel> BuscarPorCodigo(int codigo);
        Task<CategoryModel> BuscarPorName(string name);
        Task<List<CategoryModel>> BuscarPorStatus(CategoryStatusEnum status);
        Task<CategoryModel> Atualizar(CategoryDataModel categoryDataModel,int codigo);
        Task<bool> Deletar(int codigo);
    }
}
