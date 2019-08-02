using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CB8_TeamYBD_GroupProject_MVC.Models;
using CB8_TeamYBD_GroupProject_MVC.ViewModels;
using System.Security.Claims;

namespace CB8_TeamYBD_GroupProject_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentResponsesController : ControllerBase
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public CommentResponsesController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: api/CommentResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentResponse>>> GetCommentResponse()
        {
            return await _context.CommentResponse.ToListAsync();
        }

        // GET: api/CommentResponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentResponse>> GetCommentResponse(int id)
        {
            var commentResponse = await _context.CommentResponse.FindAsync(id);

            if (commentResponse == null)
            {
                return NotFound();
            }

            return commentResponse;
        }

        // PUT: api/CommentResponses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentResponse(int id, CommentResponse commentResponse)
        {
            if (id != commentResponse.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentResponseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CommentResponses
        [HttpPost]
        public async Task<ActionResult<CommentResponse>> PostCommentResponse(CommentResponseViewModel vm)
        {
            CommentResponse response = new CommentResponse();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.Find(userId);
            response.User = user;
            response.Comment = _context.Comments.Find(vm.CommentId);
            response.ResponseDateTime = DateTime.Now;
            response.Content = vm.Content;
            _context.CommentResponse.Add(response);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentResponse", new { id = response.Id }, response);
        }

        // DELETE: api/CommentResponses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentResponse>> DeleteCommentResponse(int id)
        {
            var commentResponse = await _context.CommentResponse.FindAsync(id);
            if (commentResponse == null)
            {
                return NotFound();
            }

            _context.CommentResponse.Remove(commentResponse);
            await _context.SaveChangesAsync();

            return commentResponse;
        }

        private bool CommentResponseExists(int id)
        {
            return _context.CommentResponse.Any(e => e.Id == id);
        }
    }
}
