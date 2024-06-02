using ASPNetCoreWebAPI_Reactjs.Dtos.Category;
using ASPNetCoreWebAPI_Reactjs.Dtos.Comment;
using ASPNetCoreWebAPI_Reactjs.Models;

namespace ASPNetCoreWebAPI_Reactjs.Dtos.Post
{
    public class PostDto
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public CategoryDto? Category { get; set; }

        public List<CommentDto> Comments { get; set; }


    }
}
