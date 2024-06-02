using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebAPI_Reactjs.Dtos.Category
{
    public class UpdateCategoryRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be min 2 characters")]
        [MaxLength(256, ErrorMessage = "Name cannot be over 256 characters")]
        public string Name { get; set; } = string.Empty;

    }
}
