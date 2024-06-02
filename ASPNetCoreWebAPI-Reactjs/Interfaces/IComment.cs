using ASPNetCoreWebAPI_Reactjs.Dtos.Comment;
using ASPNetCoreWebAPI_Reactjs.Dtos.Post;
using ASPNetCoreWebAPI_Reactjs.Helpers;
using ASPNetCoreWebAPI_Reactjs.Models;

namespace ASPNetCoreWebAPI_Reactjs.Interfaces
{
    public interface IComment
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);

        Task<Comment> CreateAsync(Comment model);

        Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto dto);

        Task<Comment?> DeleteAsync(int id);

       
    }
}
