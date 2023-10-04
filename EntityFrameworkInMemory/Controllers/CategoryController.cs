using EstudosApi.Repository.DataBaseContext;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;
using EstudosApi.Repository.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkInMemory.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly DBContext dbContext;
        public readonly ICategoryRepositorio categoryRepositorio;
        public CategoryController(DBContext _dbContext, ICategoryRepositorio _categoryRepositorio) 
        {
            dbContext = _dbContext;
            categoryRepositorio = _categoryRepositorio;
        }

        [HttpPost]
        [Route("Category/Adicionar")]
        public async Task<IActionResult> Adicionar(CategoryDataModel adicionarCategory)
        {
            CategoryModel category = await categoryRepositorio.Adicionar(adicionarCategory);
            return Ok(category);
        }

        [HttpGet]
        [Route("Category/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            List<CategoryModel> categoryModel = await categoryRepositorio.BuscarTodos();
            return Ok(categoryModel);
        }

        [HttpGet]
        [Route("Category/BuscarPorCodigo")]
        public async Task<IActionResult> BuscarPorCodigo(int codigo)
        {
            CategoryModel categoryModel = await categoryRepositorio.BuscarPorCodigo(codigo);
            return Ok(categoryModel);
        }

        [HttpGet]
        [Route("Category/BuscarPorNome")]
        public async Task<IActionResult> BuscarPorNome(string name)
        {
            CategoryModel categoryModel = await categoryRepositorio.BuscarPorName(name);
            return Ok(categoryModel);
        }

        [HttpGet]
        [Route("Category/BuscarPorStatus")]
        public async Task<IActionResult> BuscarPorStatus (CategoryStatusEnum status)
        {
            List<CategoryModel> categoryModel = await categoryRepositorio.BuscarPorStatus(status);
            return Ok(categoryModel);
        }

        [HttpPut]
        [Route("Category/Atualizar")]
        public async Task<IActionResult> Atualizar (CategoryDataModel categoryDataModel, int codigo)
        {
            categoryDataModel.Codigo = codigo;
            CategoryModel categoryModel = await categoryRepositorio.Atualizar(categoryDataModel, codigo);

            return Ok(categoryModel);
        }

        [HttpDelete]
        [Route("Category/Delete")]
        public async Task<IActionResult> Delete(int codigo)
        {
            bool Apagar = await categoryRepositorio.Deletar(codigo);
            return Ok(Apagar);
        }
    }
}
