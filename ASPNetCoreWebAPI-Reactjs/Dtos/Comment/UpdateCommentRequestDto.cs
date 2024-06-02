using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebAPI_Reactjs.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Content must be min 5 characters")]
        [MaxLength(500, ErrorMessage = "Content cannot be over 500 characters")]
        public string Content { get; set; } = string.Empty;
    }
}
