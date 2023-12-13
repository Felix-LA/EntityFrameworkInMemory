using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;

namespace EstudosApi.Domain.Interfaces
{
    public interface IMarcaRepositorio
    {
        List<MarcaModel> BuscarMarca(MarcaDataModel marcaDataModel);
        MarcaModel Adicionar(MarcaDataModel marcaDataModel);
        MarcaModel Atualizar(MarcaDataModel marcaDataModel, int id);
        bool Deletar(int id);
    }
}
