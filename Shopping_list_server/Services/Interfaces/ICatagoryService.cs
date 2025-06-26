using Services.DTOs;

namespace Services.Interfaces
{
    public interface ICatagoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<IEnumerable<CategoryDTO>> GetCategoriesWithProductsAsync();
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task AddAsync(CategoryDTO product);
        Task UpdateAsync(CategoryDTO product);
        Task DeleteAsync(int id);
    }
}