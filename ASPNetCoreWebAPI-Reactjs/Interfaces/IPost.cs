using ASPNetCoreWebAPI_Reactjs.Dtos.Post;
using ASPNetCoreWebAPI_Reactjs.Helpers;
using ASPNetCoreWebAPI_Reactjs.Models;

namespace ASPNetCoreWebAPI_Reactjs.Interfaces
{
    public interface IPost
    {

        Task<List<Post>> GetAllAsync(PostQueryObject postQueryObject);
        Task<Post?> GetByIdAsync(int id);

        Task<Post> CreateAsync(Post model);

        Task<Post?> UpdateAsync(int id, UpdatePostRequestDto dto);

        Task<Post?> DeleteAsync(int id);

        Task<bool> ModelExists(int id);

        Task<bool> SlugExists(string slug);
    }
}
