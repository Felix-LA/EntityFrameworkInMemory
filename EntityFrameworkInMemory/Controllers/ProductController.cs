using EstudosApi.Domain.DataModel;
using EstudosApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using EstudosApi.Domain.Interfaces;


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
        public IActionResult BuscarTodos(ProductDataModel productDataModel)
        {
            List<ProductModel> productModel = productService.BuscarProdutos(productDataModel);
             
            return Ok(productModel);
        }

        [HttpPost]
        [Route("Product/BuscarPorId")]
        public IActionResult BuscarPorId(int id)
        {
            ProductModel productModel = productService.BuscarProdutosPorId(id);
            return Ok(productModel);
        }

        [HttpPost]
        [Route("Product/BuscarPorNome")]
        public IActionResult BuscarPorNome(string name)
        {
            List<ProductModel> productModel = productService.BuscarProdutosPorNome(name);
            return Ok(productModel);
        }

        //Adiconando Produto
        [HttpPost]
        [Route("Product/Adicionar")]
        public IActionResult Adicionar(ProductDataModel productDataModel)
        {
            ProductModel productModel = productService.Adicionar(productDataModel);
            return Ok(productModel);
        }

        //Atualizando Produto
        [HttpPut]
        [Route("Product/Atualizar")]
        public IActionResult Atualizar(ProductDataModel productDataModel, int id)
        {
            productDataModel.Id = id;
            ProductModel product = productService.Atualizar(productDataModel, id);
            return Ok(product);
        }

        ////Fazendo uma busca de produtos por nome
        //[HttpGet]
        //[Route("Product/GetName")]
        //public async Task<IActionResult> GetProductListForName(string name)
        //{
        //    ProductModel products = await _productRepository.BuscarPorNome(name);
        //    return Ok(products);
        //}

        //Deletando produto
        [HttpDelete]
        [Route("Product/Delete")]
        public IActionResult Delete(int id)
        {
            bool apagado =  productService.Apagar(id);
            return Ok(apagado);
        }

        [HttpPost]
        [Route("Product/Mensagem")]
        public IActionResult Mensagem()
        {
            string msg = "Mensagem";
            return Ok(msg);
        }
    }
}
