using ASPNetCoreWebAPI_Reactjs.Data;
using ASPNetCoreWebAPI_Reactjs.Dtos.Post;
using ASPNetCoreWebAPI_Reactjs.Helpers;
using ASPNetCoreWebAPI_Reactjs.Interfaces;
using ASPNetCoreWebAPI_Reactjs.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebAPI_Reactjs.Repository
{
    public class PostRepository : IPost
    {
        private readonly ApplicationDBContext _dbContext;

        public PostRepository(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        public async Task<Post> CreateAsync(Post model)
        {
            await _dbContext.Posts.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Post?> DeleteAsync(int id)
        {
            var model = await _dbContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            if (model == null)
            {
                return null;
            }
            _dbContext.Posts.Remove(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<Post>> GetAllAsync(PostQueryObject postQueryObject)
        {
            var models = _dbContext.Posts.Include(c => c.Category).Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(postQueryObject.Title))
            {
                models = models.Where(s => s.Title.Contains(postQueryObject.Title));
            }
            if (!string.IsNullOrWhiteSpace(postQueryObject.SortBy))
            {
                if (postQueryObject.SortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    models = postQueryObject.IsDecsending ? models.OrderByDescending(s => s.PostId) : models.OrderBy(s => s.PostId);
                }
            }

            var skipNumber = (postQueryObject.PageNumber - 1) * postQueryObject.PageSize;

            return await models.Skip(skipNumber).Take(postQueryObject.PageSize).ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _dbContext.Posts.Include(c => c.Category).Include(c => c.Comments).FirstOrDefaultAsync(i => i.PostId == id);
        }

        public async Task<Post?> UpdateAsync(int id, UpdatePostRequestDto dto)
        {
            var model = await _dbContext.Posts.Include(c => c.Category).FirstOrDefaultAsync(x => x.PostId == id);
            if (model == null)
            {
                return null;
            }
            model.Title = dto.Title;
            model.Content = dto.Content;
            model.Author = dto.Author;
            model.ImagePath = dto.Image;
            model.CategoryId = (int)dto.CategoryId;

            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> ModelExists(int id)
        {
            return await _dbContext.Posts.AnyAsync(s => s.PostId == id);
        }

        public async Task<bool> SlugExists(string  slug)
        {
            return await _dbContext.Posts.AnyAsync(s => s.Slug == slug);
        }
    }
}
