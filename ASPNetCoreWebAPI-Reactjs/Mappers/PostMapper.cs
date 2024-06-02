using ASPNetCoreWebAPI_Reactjs.Dtos.Post;
using ASPNetCoreWebAPI_Reactjs.Models;

namespace ASPNetCoreWebAPI_Reactjs.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToPostDto(this Post model)
        {
            return new PostDto
            {
                Id = model.PostId,
                Title = model.Title,
                Slug = model.Slug,
                Content = model.Content,
                Author = model.Author,
                Image = model.ImagePath,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                Category = model.Category?.ToCategoryDto(),
                Comments = model.Comments.Select(c => c.ToCommentDto()).ToList(),
            };
        }

        public static Post ToPostFromCreateDto(this CreatePostRequestDto dto)
        {
            return new Post
            {
                Title = dto.Title,
                Slug = dto.Slug,
                Content = dto.Content,
                Author = dto.Author,
                ImagePath = dto.Image,
                CategoryId = (int) dto.CategoryId

            };
        }


    }
}
