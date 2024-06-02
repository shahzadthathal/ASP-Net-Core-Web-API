using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebAPI_Reactjs.Dtos.Post
{
    public class CreatePostRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Title must be min 2 characters")]
        [MaxLength(256, ErrorMessage = "Title cannot be over 256 characters")]
        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public int? CategoryId { get; set; }


    }
}
