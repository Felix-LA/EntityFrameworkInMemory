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
    public class MarcaService : IMarcaService
    {
        public readonly IMarcaRepositorio iMarcaRepository;
        public MarcaService(IMarcaRepositorio _iMarcaRepository)
        {
            iMarcaRepository = _iMarcaRepository;
        }

        public MarcaModel Adicionar(MarcaDataModel marcaDataModel)
        {
            return iMarcaRepository.Adicionar(marcaDataModel);
        }

        public List<MarcaModel> BuscarMarca(MarcaDataModel marcaDataModel)
        {
            return iMarcaRepository.BuscarMarca(marcaDataModel);
        }

        public MarcaModel BuscarPorId(int id)
        {
            MarcaDataModel marcaDataModel = new MarcaDataModel { Id = id };
            var list = iMarcaRepository.BuscarMarca(marcaDataModel);
            return list.FirstOrDefault();
        }

        public List<MarcaModel> BuscarPorName(string name)
        {
            MarcaDataModel marcaDataModel = new MarcaDataModel { Name = name };
            var list = iMarcaRepository.BuscarMarca(marcaDataModel);
            return list.ToList();
        }

        public MarcaModel Atualizar(MarcaDataModel marcaDataModel, int id)
        {
            return iMarcaRepository.Atualizar(marcaDataModel, id);
        }

        public bool Deletar(int id)
        {
            return iMarcaRepository.Deletar(id);
        }
    }
}
