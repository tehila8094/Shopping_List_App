using API.Models;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            return await _productService.GetAllAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ProductDTO?> Get(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task Post([FromBody] ProductModel product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            var productDto = new ProductDTO
            {
                Name = product.Name,
                //Description = product.Description,
                //Price = product.Price,
                Quantity = product.Quantity,
                //Unit = product.Unit,
                //IsCompleted = product.IsCompleted,
                //CreatedAt = product.CreatedAt,
                //UpdatedAt = product.UpdatedAt,
                CategoryId = product.CategoryId
            };
           await _productService.AddAsync(productDto);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductModel product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }
            var productDto = new ProductDTO
            {
                Id = id,
                Name = product.Name,
                //Description = product.Description,
                //Price = product.Price,
                Quantity = product.Quantity,
                //Unit = product.Unit,
                //IsCompleted = product.IsCompleted,
                //CreatedAt = product.CreatedAt,
                //UpdatedAt = product.UpdatedAt,
                CategoryId = product.CategoryId
            };
        }
        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _productService.DeleteAsync(id);
        }
    }
}
