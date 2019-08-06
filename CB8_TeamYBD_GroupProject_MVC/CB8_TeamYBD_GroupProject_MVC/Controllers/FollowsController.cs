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
    public class FollowsController : ControllerBase
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public FollowsController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: api/Follows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follow>>> GetFollow()
        {
            return await _context.Follows.ToListAsync();
        }

        // GET: api/Follows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follow>> GetFollow(int id)
        {
            var follow = await _context.Follows.FindAsync(id);

            if (follow == null)
            {
                return NotFound();
            }

            return follow;
        }

        // PUT: api/Follows/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollow(int id, Follow follow)
        {
            if (id != follow.Id)
            {
                return BadRequest();
            }

            _context.Entry(follow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowExists(id))
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

        // POST: api/Follows
        [HttpPost]
        public async Task<ActionResult<Follow>> PostFollow(FollowViewModel vm)
        {
            Follow follow = new Follow();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.Find(userId);
            follow.Follower = user;
            follow.User = _context.Users.Find(vm.UserId);
            follow.DateTime = DateTime.Now;
            if (_context.Follows.Where(x => x.Follower == user && x.User == follow.User).Count() == 0)
            {

                _context.Follows.Add(follow);
            }
            else
            {
                _context.Follows.RemoveRange(_context.Follows.Where(x => x.Follower == user && x.User == follow.User).ToList());
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollow", new { id = follow.Id }, follow);
        }

        // DELETE: api/Follows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Follow>> DeleteFollow(int id)
        {
            var follow = await _context.Follows.FindAsync(id);
            if (follow == null)
            {
                return NotFound();
            }

            _context.Follows.Remove(follow);
            await _context.SaveChangesAsync();

            return follow;
        }

        private bool FollowExists(int id)
        {
            return _context.Follows.Any(e => e.Id == id);
        }
    }
}
