using ASPNetCoreWebAPI_Reactjs.Data;
using ASPNetCoreWebAPI_Reactjs.Dtos.Category;
using ASPNetCoreWebAPI_Reactjs.Dtos.Comment;
using ASPNetCoreWebAPI_Reactjs.Dtos.Post;
using ASPNetCoreWebAPI_Reactjs.Interfaces;
using ASPNetCoreWebAPI_Reactjs.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace ASPNetCoreWebAPI_Reactjs.Repository
{
    public class CommentRepository : IComment
    {
        private readonly ApplicationDBContext _dbContext;

        public CommentRepository(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        public async Task<Comment> CreateAsync(Comment model)
        {
            await _dbContext.Comments.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var model = await _dbContext.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
            if (model == null)
            {
                return null;
            }
            _dbContext.Comments.Remove(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(i => i.CommentId == id);
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto dto)
        {
            var model = await _dbContext.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
            if (model == null)
            {
                return null;
            }
            model.Content = dto.Content;
            await _dbContext.SaveChangesAsync();
            return model;
        }

    }
}
