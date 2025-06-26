using AutoMapper;
using Entities.Entities;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository , IMapper mapper)
        {
                _mapper = mapper;
                _productRepository = productRepository;
        }
        public async Task AddAsync(ProductDTO product)
        {
            await _productRepository.AddAsync(_mapper.Map<Product>(product));
            await _productRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _productRepository.Delete(id);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return  _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return  _mapper.Map<ProductDTO?>(product); 
        }

        public async Task UpdateAsync(ProductDTO product)
        {
            _productRepository.Update(_mapper.Map<Product>(product));
            await _productRepository.SaveChangesAsync();
        }
    }
}
