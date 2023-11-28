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
    public interface IMarcaService
    {
        List<MarcaModel> BuscarMarca(MarcaDataModel marcaDataModel);
        MarcaModel Adicionar(MarcaDataModel marcaDataModel);
        MarcaModel BuscarPorId(int id);
        List<MarcaModel> BuscarPorName(string Name);
        MarcaModel Atualizar(MarcaDataModel marcaDataModel, int id);
        bool Deletar(int id);
    }
}
