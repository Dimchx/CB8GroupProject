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
    public class UserSubcriptionsController : ControllerBase
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public UserSubcriptionsController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: api/UserSubcriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSubcription>>> GetUserSubcription()
        {
            return await _context.UserSubcriptions.ToListAsync();
        }

        // GET: api/UserSubcriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSubcription>> GetUserSubcription(int id)
        {
            var userSubcription = await _context.UserSubcriptions.FindAsync(id);

            if (userSubcription == null)
            {
                return NotFound();
            }

            return userSubcription;
        }

        // PUT: api/UserSubcriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSubcription(int id, UserSubcription userSubcription)
        {
            if (id != userSubcription.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSubcription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSubcriptionExists(id))
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

        // POST: api/UserSubcriptions
        [HttpPost]
        public async Task<ActionResult<UserSubcription>> PostUserSubcription(UserSubcription userSubcription)
        {
            _context.UserSubcriptions.Add(userSubcription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSubcription", new { id = userSubcription.Id }, userSubcription);
        }

        // DELETE: api/UserSubcriptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserSubcription>> DeleteUserSubcription(int id)
        {
            var userSubcription = await _context.UserSubcriptions.FindAsync(id);
            if (userSubcription == null)
            {
                return NotFound();
            }

            _context.UserSubcriptions.Remove(userSubcription);
            await _context.SaveChangesAsync();

            return userSubcription;
        }

        private bool UserSubcriptionExists(int id)
        {
            return _context.UserSubcriptions.Any(e => e.Id == id);
        }
    }
}
