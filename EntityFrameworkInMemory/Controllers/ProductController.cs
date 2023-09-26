﻿using EntityFrameworkInMemory.DataBaseContext;
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
        [Route("API/GetProduct")]
        public async Task<IActionResult> GetProductList()
        {
            List<ProductDataModel> products = await _productRepository.BuscarTodosUsuarios();
            return Ok(products);
        }
        
        //Adiconando Produto
        [HttpPost]
        [Route("API/PostProduct")]
        public async Task<IActionResult> PostProduct(ProductModel productModel)
        {
            ProductDataModel product = new ProductDataModel();

            product.Id = Guid.NewGuid();
            product.Name = productModel.ProductName;
            product.Category = productModel.ProductCategory;
            product.Price = productModel.ProductPrice;
            product.Codigo = productModel.ProductCodigo;

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return Ok(product);
        }


        //Fazendo uma busca de produtos por nome
        [HttpGet]
        [Route("API/GetName")]
        public async Task<IActionResult> GetProductListForName(string name)
        {
            ProductDataModel products = await _productRepository.BuscarPorNome(name);
            return Ok(products);
        }

        //Fazendo uma busca de produtos por categoria
        [HttpGet]
        [Route("API/GetCategory")]
        public async Task<IActionResult> GetProductListForCategory(string category)
        {
            ProductDataModel products = await _productRepository.BuscarPorCategoria(category);
            return Ok(products);
        }

        //Deletando produto
        [HttpDelete]
        [Route("API/Delete")]
        public async Task<IActionResult> Delete(int codigo)
        {
            bool apagado = await _productRepository.Apagar(codigo);
            return Ok(apagado);
        }
    }
}
