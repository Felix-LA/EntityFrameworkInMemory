using EntityFrameworkInMemory.DataBaseContext;
using EntityFrameworkInMemory.DataModel;
using EntityFrameworkInMemory.Models;
using EntityFrameworkInMemory.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        [Route("Product/GetProduct")]
        public async Task<IActionResult> GetProductList()
        {
            List<ProductModel> products = await _productRepository.BuscarTodos();
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

        //Atualizando Produto
        [HttpPut]
        [Route("Product/Atualizar")]
        public async Task<IActionResult> Atualizar(ProductDataModel productDataModel, int codigo)
        {
            productDataModel.Codigo = codigo;
            ProductModel product = await _productRepository.Atualizar(productDataModel, codigo);
            return Ok(product);
        }

        //Fazendo uma busca de produtos por nome
        [HttpGet]
        [Route("Product/GetName")]
        public async Task<IActionResult> GetProductListForName(string name)
        {
            ProductModel products = await _productRepository.BuscarPorNome(name);
            return Ok(products);
        }

        //Fazendo uma busca de produtos por categoria
        [HttpGet]
        [Route("Product/GetCategory")]
        public async Task<IActionResult> GetProductListForCategory(CategoryDataModel category)
        {
            List<ProductModel> products = await _productRepository.BuscarPorCategoria(category);
            return Ok(products);
        }

        //Deletando produto
        [HttpDelete]
        [Route("Product/Delete")]
        public async Task<IActionResult> Delete(int codigo)
        {
            bool apagado = await _productRepository.Apagar(codigo);
            return Ok(apagado);
        }
    }
}
