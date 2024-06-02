using ASPNetCoreWebAPI_Reactjs.Dtos.Category;
using ASPNetCoreWebAPI_Reactjs.Models;

namespace ASPNetCoreWebAPI_Reactjs.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category model)
        {
            return new CategoryDto
            {
                Id = model.CategoryId,
                Title = model.Name,
            };
        }

        public static Category ToCategoryFromCreateDto(this CreateCategoryRequestDto dto)
        {
            return new Category
            {
                Name = dto.Name,
                
            };
        }
    }
}
