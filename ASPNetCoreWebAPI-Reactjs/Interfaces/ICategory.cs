using ASPNetCoreWebAPI_Reactjs.Dtos.Category;
using ASPNetCoreWebAPI_Reactjs.Models;

namespace ASPNetCoreWebAPI_Reactjs.Interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);

        Task<Category> CreateAsync(Category model);

        Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto dto);

        Task<Category?> DeleteAsync(int id);

        Task<bool> ModelExists(int id);
    }
}
