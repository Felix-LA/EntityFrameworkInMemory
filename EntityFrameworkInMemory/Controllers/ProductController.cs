using EstudosApi.Repository.DataBaseContext;
using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;
using EstudosApi.Repository.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using EstudosApi;

//verbosidade de API -- fullrest api
//get byproductname -- usando where com context api net core


namespace EntityFrameworkInMemory.Controllers
{
    
    [ApiController]

    public class ProductController : ControllerBase
    {
        public readonly IProductRepositorio _productRepository;

        private readonly DBContext _dbContext;

        public ProductController(DBContext dBContext, IProductRepositorio productRepositorio)
        {
            _dbContext = dBContext;
            _productRepository = productRepositorio;
        }

        //Buscando todos os produtos
        [HttpPost]
        [Route("Product/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos([FromBody] ProductDataModel productDataModel)
        {
            List<ProductModel> products = await _productRepository.BuscarTodos(productDataModel);

            return Ok(products);
        }
        
        //Adiconando Produto
        [HttpPost]
        [Route("Product/Adicionar")]
        public async Task<IActionResult> Adicionar(ProductDataModel productDataModel)
        {
            ProductModel product = await _productRepository.Adicionar(productDataModel);
            return Ok(productDataModel);
        }

        ////Atualizando Produto
        //[HttpPut]
        //[Route("Product/Atualizar")]
        //public async Task<IActionResult> Atualizar(ProductDataModel productDataModel, int codigo)
        //{
        //    productDataModel.Codigo = codigo;
        //    ProductModel product = await _productRepository.Atualizar(productDataModel, codigo);
        //    return Ok(product);
        //}

        ////Fazendo uma busca de produtos por nome
        //[HttpGet]
        //[Route("Product/GetName")]
        //public async Task<IActionResult> GetProductListForName(string name)
        //{
        //    ProductModel products = await _productRepository.BuscarPorNome(name);
        //    return Ok(products);
        //}

        ////Deletando produto
        //[HttpDelete]
        //[Route("Product/Delete")]
        //public async Task<IActionResult> Delete(int codigo)
        //{
        //    bool apagado = await _productRepository.Apagar(codigo);
        //    return Ok(apagado);
        //}
    }
}
