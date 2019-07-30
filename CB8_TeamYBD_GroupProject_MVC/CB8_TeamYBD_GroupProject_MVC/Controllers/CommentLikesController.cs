using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CB8_TeamYBD_GroupProject_MVC.Models;

namespace CB8_TeamYBD_GroupProject_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentLikesController : ControllerBase
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public CommentLikesController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: api/CommentLikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentLike>>> GetCommentLike()
        {
            return await _context.CommentLikes.ToListAsync();
        }

        // GET: api/CommentLikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentLike>> GetCommentLike(int id)
        {
            var commentLike = await _context.CommentLikes.FindAsync(id);

            if (commentLike == null)
            {
                return NotFound();
            }

            return commentLike;
        }

        // PUT: api/CommentLikes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentLike(int id, CommentLike commentLike)
        {
            if (id != commentLike.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentLikeExists(id))
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

        // POST: api/CommentLikes
        [HttpPost]
        public async Task<ActionResult<CommentLike>> PostCommentLike(CommentLike commentLike)
        {
            _context.CommentLikes.Add(commentLike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentLike", new { id = commentLike.Id }, commentLike);
        }

        // DELETE: api/CommentLikes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentLike>> DeleteCommentLike(int id)
        {
            var commentLike = await _context.CommentLikes.FindAsync(id);
            if (commentLike == null)
            {
                return NotFound();
            }

            _context.CommentLikes.Remove(commentLike);
            await _context.SaveChangesAsync();

            return commentLike;
        }

        private bool CommentLikeExists(int id)
        {
            return _context.CommentLikes.Any(e => e.Id == id);
        }
    }
}
