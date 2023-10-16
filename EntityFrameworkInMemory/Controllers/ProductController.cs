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
            List<ProductModel> productModel = await productService.BuscarProdutos(productDataModel);
             
            return Ok(productModel);
        }

        //[HttpPost]
        //[Route("Product/BuscarPorId")]
        //public async Task<IActionResult> BuscarPorId(int id)
        //{
        //    ProductModel productModel = await productService.BuscarProdutosPorId(id);
        //    return Ok(productModel);
        //}

        //[HttpPost]
        //[Route("Product/BuscarPorNome")]
        //public async Task<IActionResult> BuscarPorNome(string name)
        //{
        //    List<ProductModel> productModel = await productService.BuscarProdutosPorId(name);
        //    return Ok(productModel);
        //}

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
