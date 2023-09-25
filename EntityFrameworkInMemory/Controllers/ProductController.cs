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
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepositorio _productRepository;

        private readonly DBContext _dbContext;

        public ProductController(DBContext dBContext, IProductRepositorio productRepositorio)
        {
            _dbContext = dBContext;
            _productRepository = productRepositorio;
        }


        [HttpGet]
        //[Route("API/GetProduct")]
        public async Task<IActionResult> GetProductList()
        {
            List<ProductDataModel> products = await _productRepository.BuscarTodosUsuarios();
            return Ok(products);
        }
        

        [HttpPost]
        //[Route("API/PostProduct")]
        public async Task<IActionResult> PostProduct(ProductModel productModel)
        {
            ProductDataModel product = new ProductDataModel();

            product.Id = Guid.NewGuid();
            product.Name = productModel.ProductName;
            product.Category = productModel.ProductCategory;
            product.Price = productModel.ProductPrice;

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return Ok(product);
        }



        [HttpGet]
        public async Task<IActionResult> GetProductListForName(string name)
        {
            ProductDataModel products = await _productRepository.BuscarPorNome(name);
            return Ok(products);
        }
    }
}
