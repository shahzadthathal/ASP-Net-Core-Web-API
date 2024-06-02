using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebAPI_Reactjs.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [StringLength(50)]
        public string Author { get; set; } = string.Empty;

       
        public bool IsPublished { get; set; } = false;

        [StringLength(255)]
        public string ImagePath { get; set; } = string.Empty;


        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        public List<Comment> Comments { get; set; } = new List<Comment>();

        // Foreign key for Category
        public int CategoryId { get; set; }

        // Navigation property for Category
        public Category? Category { get; set; }



    }
}
