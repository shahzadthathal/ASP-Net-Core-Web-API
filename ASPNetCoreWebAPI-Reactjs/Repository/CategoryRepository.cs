using ASPNetCoreWebAPI_Reactjs.Data;
using ASPNetCoreWebAPI_Reactjs.Dtos.Category;
using ASPNetCoreWebAPI_Reactjs.Interfaces;
using ASPNetCoreWebAPI_Reactjs.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebAPI_Reactjs.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryRepository(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        public async Task<Category> CreateAsync(Category model)
        {
            await _dbContext.Categories.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var model = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (model == null)
            {
                return null;
            }
            _dbContext.Categories.Remove(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(i => i.CategoryId == id);
        }

        public async Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto dto)
        {
            var model = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (model == null)
            {
                return null;
            }
            model.Name = dto.Name;
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ModelExists(int id)
        {
            return await _dbContext.Categories.AnyAsync(s => s.CategoryId == id);
        }

    }
}
