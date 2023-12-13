using EstudosApi.Repository.DataBaseContext;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;
using EstudosApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EntityFrameworkInMemory.Repositorios
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        public readonly DBContext dBContext;

        public MarcaRepositorio(DBContext _dbContext)
        {
            dBContext = _dbContext;
        }

        public MarcaModel Adicionar(MarcaDataModel marcaDataModel)
        {
            MarcaModel marcaModel = new MarcaModel();

            marcaModel.MarcaName = marcaDataModel.Name;
            marcaModel.MarcaStatus = marcaDataModel.Status;

            dBContext.Marca.Add(marcaModel);
            dBContext.SaveChanges();

            return marcaModel;
        }

        public List<MarcaModel> BuscarMarca(MarcaDataModel marcaDataModel)
        {
            if (marcaDataModel.Id > 0)
            {
                return dBContext.Marca.Where(x => x.MarcaId.Equals(marcaDataModel)).ToList();
            }
            else if (marcaDataModel.Name != null)
            {
                return dBContext.Marca.Where(x => x.MarcaName.Contains(marcaDataModel.Name)).ToList();
            }
            else
            {
                return dBContext.Marca.ToList();
            }
            
        }

        public bool Deletar(int id)
        {
            var deletarMarca = new MarcaModel { MarcaId = id };

            if (deletarMarca.MarcaId < 0)
            {
                throw new Exception("Marca nao Encontrada");
            }

            dBContext.Marca.Attach(deletarMarca);
            dBContext.Marca.Remove(deletarMarca);
            dBContext.SaveChanges();

            return true;
        }

        public MarcaModel Atualizar(MarcaDataModel marcaDataModel, int id)
        {
            var atualizarMarca = dBContext.Marca.FirstOrDefault(marca => marca.MarcaId == id);

            if (atualizarMarca == null)
            {
                throw new Exception("Marca nao Encontrada");
            }

            atualizarMarca.MarcaName = marcaDataModel.Name;
            atualizarMarca.MarcaStatus = marcaDataModel.Status;

            dBContext.Marca.Update(atualizarMarca);
            dBContext.SaveChanges();

            return atualizarMarca;
        }
    }
}
