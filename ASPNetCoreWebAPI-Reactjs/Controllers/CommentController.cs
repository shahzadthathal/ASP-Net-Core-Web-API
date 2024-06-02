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
using ASPNetCoreWebAPI_Reactjs.Helpers;
using ASPNetCoreWebAPI_Reactjs.Mappers;
using ASPNetCoreWebAPI_Reactjs.Dtos.Comment;
using Humanizer;

namespace ASPNetCoreWebAPI_Reactjs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComment _commentRepo;
        private readonly IPost _postRepo;

        public CommentController(IComment commentInterface, IPost postInterface)
        {
            _commentRepo = commentInterface;
            _postRepo = postInterface;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<ActionResult> GetComments()
        {
            var models = await _commentRepo.GetAllAsync();
            var modelsDto = models.Select(s => s.ToCommentDto()).ToList();
            return Ok(modelsDto);

        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetComment(int id)
        {
            var model = await _commentRepo.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model.ToCommentDto());
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, UpdateCommentRequestDto comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _commentRepo.UpdateAsync(id, comment);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model.ToCommentDto());
        }

        // POST: api/Comment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostComment(CreateCommentRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _postRepo.ModelExists((int)dto.PostId))
            {
                return BadRequest("Post does not exists...");
            }

            var model = dto.ToCommentFromCreateDto();
            await _commentRepo.CreateAsync(model);
            return CreatedAtAction("GetComment", new { id = model.CommentId}, model.ToCommentDto());

        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _commentRepo.DeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
