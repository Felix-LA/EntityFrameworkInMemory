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
        public async Task<IActionResult> Adicionar(CategoryDataModel adicionarCategory)
        {
            CategoryModel category = await categoryService.Adicionar(adicionarCategory);
            return Ok(category);
        }

        [HttpPost]
        [Route("Category/BuscarTodos")]
        public async Task<IActionResult> BuscarCategoria(CategoryDataModel categoryDataModel)
        {
            List<CategoryModel> categoryModel = await categoryService.BuscarCategoria(categoryDataModel);
            return Ok(categoryModel);
        }

        //[HttpGet]
        //[Route("Category/BuscarPorCodigo")]
        //public async Task<IActionResult> BuscarPorId(CategoryDataModel categoryDataModel)
        //{
        //    CategoryModel categoryModel = await categoryService.BuscarCategoria(categoryDataModel);
        //    return Ok(categoryModel);
        //}

        [HttpGet]
        [Route("Category/BuscarPorNome")]
        public async Task<IActionResult> BuscarPorNome(CategoryDataModel categoryDataModel)
        {
                List<CategoryModel> categoryModel = await categoryService.BuscarCategoria(categoryDataModel);
                return Ok(categoryModel);
        }

        //[HttpGet]
        //[Route("Category/BuscarPorStatus")]
        //public async Task<IActionResult> BuscarPorStatus (CategoryStatusEnum status)
        //{
        //    List<CategoryModel> categoryModel = await categoryService.BuscarPorStatus(status);
        //    return Ok(categoryModel);
        //}

        //[HttpPut]
        //[Route("Category/Atualizar")]
        //public async Task<IActionResult> Atualizar (CategoryDataModel categoryDataModel, int id)
        //{
        //    categoryDataModel.Id = id;
        //    CategoryModel categoryModel = await categoryService.Atualizar(categoryDataModel, id);

        //    return Ok(categoryModel);
        //}

        //[HttpDelete]
        //[Route("Category/Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    bool Apagar = await categoryService.Deletar(id);
        //    return Ok(Apagar);
        //}
    }
}
