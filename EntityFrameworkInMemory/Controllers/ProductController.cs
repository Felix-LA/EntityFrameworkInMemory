using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using EstudosApi;
using EstudosApi.Domain.Interfaces;

//verbosidade de API -- fullrest api
//get byproductname -- usando where com context api net core


namespace EntityFrameworkInMemory.Controllers
{
    
    [ApiController]

    public class ProductController : ControllerBase
    {
        public readonly IProductService productService;


        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        //Buscando todos os produtos
        [HttpPost]
        [Route("Product/BuscarTodos")]
        public async Task<IActionResult> BuscarTodos(ProductDataModel productDataModel)
        {
<<<<<<< HEAD
            List<ProductModel> products = await productService.BuscarTodos(productDataModel);
=======
            List<ProductModel> products;
>>>>>>> a0627c8b442ba3c8d0a1fc442433fbefd96ca3be

            if (productDataModel.Name != null)
            {
                products = await _productRepository.BuscarTodos(productDataModel);
            }
            if (productDataModel.Codigo != null)
            {
                products = await _productRepository.BuscarTodos(productDataModel);
            }
            else
            {
               products = await _productRepository.BuscarTodos(productDataModel);
            }
             
            return Ok(products);
        }
        
        //Adiconando Produto
        [HttpPost]
        [Route("Product/Adicionar")]
        public async Task<IActionResult> Adicionar(ProductDataModel productDataModel)
        {
            ProductModel product = await productService.Adicionar(productDataModel);
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
