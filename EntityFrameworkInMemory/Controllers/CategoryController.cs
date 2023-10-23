using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Enums;
using EstudosApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EstudosApi.Domain.Interfaces;

namespace EntityFrameworkInMemory.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService) 
        {
            
            categoryService = _categoryService;
        }

        [HttpPost]
        [Route("Category/Adicionar")]
        public IActionResult Adicionar(CategoryDataModel adicionarCategory)
        {
            CategoryModel category = categoryService.Adicionar(adicionarCategory);
            return Ok(category);
        }

        [HttpPost]
        [Route("Category/BuscarTodos")]
        public IActionResult BuscarCategoria(CategoryDataModel categoryDataModel)
        {
            List<CategoryModel> categoryModel = categoryService.BuscarCategoria(categoryDataModel);
            return Ok(categoryModel);
        }

        [HttpGet]
        [Route("Category/BuscarPorCodigo")]
        public IActionResult BuscarPorId(int id)
        {
            CategoryModel categoryModel = categoryService.BuscarPorId(id);
            return Ok(categoryModel);
        }

        [HttpGet]
        [Route("Category/BuscarPorNome")]
        public IActionResult BuscarPorNome(string name)
        {
            List<CategoryModel> categoryModel = categoryService.BuscarPorName(name);
            return Ok(categoryModel);
        }

        ////[HttpGet]
        //[Route("Category/BuscarPorStatus")]
        //public async Task<IActionResult> BuscarPorStatus (CategoryStatusEnum status)
        //{
        //    List<CategoryModel> categoryModel = await categoryService.BuscarPorStatus(status);
        //    return Ok(categoryModel);
        //}

        [HttpPut]
        [Route("Category/Atualizar")]
        public IActionResult Atualizar(CategoryDataModel categoryDataModel, int id)
        {
            categoryDataModel.Id = id;
            CategoryModel categoryModel = categoryService.Atualizar(categoryDataModel, id);

            return Ok(categoryModel);
        }

        [HttpDelete]
        [Route("Category/Delete")]
        public IActionResult Delete(int id)
        {
            bool Apagar = categoryService.Deletar(id);
            return Ok(Apagar);
        }
    }
}
