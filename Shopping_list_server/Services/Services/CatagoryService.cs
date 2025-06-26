using AutoMapper;
using Entities.Interfaces;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CatagoryService : ICatagoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CatagoryService(ICategoryRepository categoryRepository , IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryDTO product)
        {
            await _categoryRepository.AddAsync(_mapper.Map<Category>(product));
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _categoryRepository.Delete(id);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories =await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO?>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesWithProductsAsync()
        {
            return _mapper.Map<IEnumerable<CategoryDTO>>( await _categoryRepository.GetCategoriesWithProductsAsync());
        }

        public async Task UpdateAsync(CategoryDTO product)
        {
            _categoryRepository.Update(_mapper.Map<Category>(product));
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
