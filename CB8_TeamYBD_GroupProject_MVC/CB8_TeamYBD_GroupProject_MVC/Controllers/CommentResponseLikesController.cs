using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CB8_TeamYBD_GroupProject_MVC.Models;
using System.Security.Claims;
using CB8_TeamYBD_GroupProject_MVC.ViewModels;

namespace CB8_TeamYBD_GroupProject_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentResponseLikesController : ControllerBase
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public CommentResponseLikesController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: api/CommentResponseLikes
        [HttpGet]
        public async Task<ActionResult<bool>> GetCommentResponseLike(int Id)
        {
            var commentResponse = _context.CommentResponses.Find(Id);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.Find(userId);
            var like = await _context.CommentResponseLikes.Where(x => x.User == user).ToListAsync();
            return like.Count() > 0;
        }

        // GET: api/CommentResponseLikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentResponseLike>> GetCommentResponseLike(int id, CommentResponseLike responseLike)
        {
            var commentResponseLike = await _context.CommentResponseLikes.FindAsync(id);

            if (commentResponseLike == null)
            {
                return NotFound();
            }

            return commentResponseLike;
        }

        // PUT: api/CommentResponseLikes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentResponseLike(int id, CommentResponseLike commentResponseLike)
        {
            if (id != commentResponseLike.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentResponseLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentResponseLikeExists(id))
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

        // POST: api/CommentResponseLikes
        [HttpPost]
        public async Task<ActionResult<CommentResponseLike>> PostCommentResponseLike(CommentResponseLikeViewModel vm)
        {
            CommentResponseLike like = new CommentResponseLike();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.Find(userId);
            like.User = user;
            like.Response = _context.CommentResponses.Find(vm.CommentResponseId);
            like.LikeDateTime = DateTime.Now;

            if (_context.CommentResponseLikes.Where(x => x.User == user && x.Response == like.Response).Count() == 0)
            {

                _context.CommentResponseLikes.Add(like);
            }
            else
            {
                _context.CommentResponseLikes.RemoveRange(_context.CommentResponseLikes.Where(x => x.User == user && x.Response == like.Response).ToList());
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentResponseLike", new { id = like.Id }, like);
        }

        // DELETE: api/CommentResponseLikes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentResponseLike>> DeleteCommentResponseLike(int id)
        {
            var commentResponseLike = await _context.CommentResponseLikes.FindAsync(id);
            if (commentResponseLike == null)
            {
                return NotFound();
            }

            _context.CommentResponseLikes.Remove(commentResponseLike);
            await _context.SaveChangesAsync();

            return commentResponseLike;
        }

        private bool CommentResponseLikeExists(int id)
        {
            return _context.CommentResponseLikes.Any(e => e.Id == id);
        }
    }
}
