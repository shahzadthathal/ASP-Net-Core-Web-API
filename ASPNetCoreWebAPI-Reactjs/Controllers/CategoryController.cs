using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreWebAPI_Reactjs.Data;
using ASPNetCoreWebAPI_Reactjs.Models;
using ASPNetCoreWebAPI_Reactjs.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ASPNetCoreWebAPI_Reactjs.Mappers;
using System.Collections;
using ASPNetCoreWebAPI_Reactjs.Dtos.Category;

namespace ASPNetCoreWebAPI_Reactjs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategory _categoryRepo;

        public CategoryController(ICategory categoryInterface)
        {
            _categoryRepo = categoryInterface;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var models = await _categoryRepo.GetAllAsync();
            var modelsDto = models.Select(s => s.ToCategoryDto()).ToList();
            return Ok(modelsDto);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            var model = await _categoryRepo.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            } 
            return Ok(model.ToCategoryDto());
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, UpdateCategoryRequestDto category)
        {
            var model = await _categoryRepo.UpdateAsync(id, category);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model.ToCategoryDto());
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCategory(CreateCategoryRequestDto dto)
        {
            var model = dto.ToCategoryFromCreateDto();
            await _categoryRepo.CreateAsync(model);
            return CreatedAtAction("GetCategory", new { id = model.CategoryId }, model.ToCategoryDto());
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _categoryRepo.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
