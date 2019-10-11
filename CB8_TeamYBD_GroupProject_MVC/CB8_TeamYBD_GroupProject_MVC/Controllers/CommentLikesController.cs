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
    public class CommentLikesController : ControllerBase
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public CommentLikesController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: api/CommentLikes
        [HttpGet]
        public async Task<ActionResult<bool>> GetCommentLike(int Id)
        {
            var comment = _context.Comments.Find(Id);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.Find(userId);
            var like = await _context.CommentLikes.Where(x => x.User == user).ToListAsync();
            return like.Count() > 0;
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
        public async Task<ActionResult<CommentLike>> PostCommentLike(CommentLikeViewModel vm)
        {
            CommentLike like = new CommentLike();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.Find(userId);
            like.User = user;
            like.Comment = _context.Comments.Find(vm.CommentId);
            like.LikeDateTime = DateTime.Now;

            if (_context.CommentLikes.Where(x => x.User == user && x.Comment == like.Comment).Count() == 0)
            {

                _context.CommentLikes.Add(like);
            }
            else
            {
                _context.CommentLikes.RemoveRange(_context.CommentLikes.Where(x => x.User == user && x.Comment == like.Comment).ToList());
            }
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentLike", new { id = like.Id }, like);
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
