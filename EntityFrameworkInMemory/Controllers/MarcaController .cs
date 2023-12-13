using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstudosApi.Domain.Interfaces;

namespace EntityFrameworkInMemory.Controllers
{
    [ApiController]
    public class MarcaController : ControllerBase
    {
        public readonly IMarcaService marcaService;
        public MarcaController(IMarcaService _marcaService) 
        {

            marcaService = _marcaService;
        }

        [HttpPost]
        [Route("Marca/Adicionar")]
        public IActionResult Adicionar(MarcaDataModel adicionarMarca)
        {
            MarcaModel marca = marcaService.Adicionar(adicionarMarca);
            return Ok(marca);
        }

        [HttpPost]
        [Route("Marca/BuscarTodos")]
        public IActionResult BuscarMarca(MarcaDataModel marcaDataModel)
        {
            List<MarcaModel> marcaModel = marcaService.BuscarMarca(marcaDataModel);
            return Ok(marcaModel);
        }

        [HttpGet]
        [Route("Marca/BuscarPorCodigo")]
        public IActionResult BuscarPorId(int id)
        {
            MarcaModel marcaModel = marcaService.BuscarPorId(id);
            return Ok(marcaModel);
        }

        [HttpGet]
        [Route("Marca/BuscarPorNome")]
        public IActionResult BuscarPorNome(string name)
        {
            List<MarcaModel> marcaModel = marcaService.BuscarPorName(name);
            return Ok(marcaModel);
        }

        [HttpPut]
        [Route("Marca/Atualizar")]
        public IActionResult Atualizar(MarcaDataModel marcaDataModel, int id)
        {
            marcaDataModel.Id = id;
            MarcaModel marcaModel = marcaService.Atualizar(marcaDataModel, id);

            return Ok(marcaModel);
        }

        [HttpDelete]
        [Route("Marca/Delete")]
        public IActionResult Delete(int id)
        {
            bool Apagar = marcaService.Deletar(id);
            return Ok(Apagar);
        }
    }
}
