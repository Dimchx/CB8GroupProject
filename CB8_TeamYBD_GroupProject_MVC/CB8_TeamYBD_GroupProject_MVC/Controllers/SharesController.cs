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
    public class SharesController : ControllerBase
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public SharesController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: api/Shares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Share>>> GetShare()
        {
            return await _context.Shares.ToListAsync();
        }

        // GET: api/Shares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Share>> GetShare(int id)
        {
            var share = await _context.Shares.FindAsync(id);

            if (share == null)
            {
                return NotFound();
            }

            return share;
        }

        // PUT: api/Shares/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShare(int id, Share share)
        {
            if (id != share.Id)
            {
                return BadRequest();
            }

            _context.Entry(share).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShareExists(id))
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

        // POST: api/Shares
        [HttpPost]
        public async Task<ActionResult<Share>> PostShare(Share share)
        {
            _context.Shares.Add(share);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShare", new { id = share.Id }, share);
        }

        // DELETE: api/Shares/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Share>> DeleteShare(int id)
        {
            var share = await _context.Shares.FindAsync(id);
            if (share == null)
            {
                return NotFound();
            }

            _context.Shares.Remove(share);
            await _context.SaveChangesAsync();

            return share;
        }

        private bool ShareExists(int id)
        {
            return _context.Shares.Any(e => e.Id == id);
        }
    }
}
