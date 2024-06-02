using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebAPI_Reactjs.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        [StringLength(50)]
        public string Author { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign key for Post
        public int PostId { get; set; }

        // Navigation property for the related post
        public Post? Post { get; set; }

        
    }
}
