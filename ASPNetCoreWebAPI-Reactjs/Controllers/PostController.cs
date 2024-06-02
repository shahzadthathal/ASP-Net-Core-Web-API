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
using ASPNetCoreWebAPI_Reactjs.Mappers;
using System.Collections;
using ASPNetCoreWebAPI_Reactjs.Dtos.Post;
using ASPNetCoreWebAPI_Reactjs.Helpers;

namespace ASPNetCoreWebAPI_Reactjs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPost _postRepo;

        private readonly ICategory _categoryRepo;

        public PostController(IPost postInterface, ICategory categoryInterface)
        {
            _postRepo = postInterface;
            _categoryRepo = categoryInterface;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult> GetPosts([FromQuery] PostQueryObject postQueryObject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var models = await _postRepo.GetAllAsync(postQueryObject);
            var modelsDto = models.Select(s => s.ToPostDto()).ToList();
            return Ok(modelsDto);
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPost(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _postRepo.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            } 
            return Ok(model.ToPostDto());
        }

        // PUT: api/Post/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, UpdatePostRequestDto post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _postRepo.UpdateAsync(id, post);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model.ToPostDto());
        }

        // POST: api/Post
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostPost(CreatePostRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _categoryRepo.ModelExists((int)dto.CategoryId))
            {
                 return BadRequest("Category does not exists...");
            }

            // Generate and set a unique slug
            dto.Slug = SlugHelper.GenerateSlug(dto.Title);
            if (await _postRepo.SlugExists(dto.Slug))
            {
                return BadRequest("Post title already exists...");
            }

            var model = dto.ToPostFromCreateDto();
            await _postRepo.CreateAsync(model);
            return CreatedAtAction("GetPost", new { id = model.PostId }, model.ToPostDto());
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _postRepo.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
