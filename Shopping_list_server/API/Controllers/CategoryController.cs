using API.Models;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICatagoryService _categoryService;
        public CategoryController(ICatagoryService catagoryService)
        {
            _categoryService = catagoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public Task<IEnumerable<CategoryDTO>> Get()
        {
            return _categoryService.GetAllAsync();
        }

        // GET: api/<CategoryController>
        [HttpGet("GetAllCategorisWithProducts")]
        public Task<IEnumerable<CategoryDTO>> GetAllWithProducts()
        {
            return _categoryService.GetCategoriesWithProductsAsync();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<CategoryDTO?> Get(int id)
        {
            return await _categoryService.GetByIdAsync(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task Post([FromBody] CategoryModel value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Category cannot be null");
            }
            var categoryDto = new CategoryDTO
            {
                Name = value.Name,
                //Description = value.Description,
                //CreatedAt = value.CreatedAt,
                //UpdatedAt = value.UpdatedAt
            };
            await _categoryService.AddAsync(categoryDto);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CategoryModel value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Category cannot be null");
            }
            var categoryDto = new CategoryDTO
            {
                Id = id,
                Name = value.Name,
                //Description = value.Description,
                //CreatedAt = value.CreatedAt,
                //UpdatedAt = value.UpdatedAt
            };
            await _categoryService.UpdateAsync(categoryDto);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
        }
    }
}
