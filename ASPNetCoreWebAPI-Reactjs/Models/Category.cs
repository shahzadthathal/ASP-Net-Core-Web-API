using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebAPI_Reactjs.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation property for Posts
        public List<Post> Posts { get; set; } = new List<Post>();
    }

}
