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
    public class ArticlePurchasesController : ControllerBase
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public ArticlePurchasesController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: api/ArticlePurchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticlePurchase>>> GetArticlePurchase()
        {
            return await _context.ArticlePurchases.ToListAsync();
        }

        // GET: api/ArticlePurchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticlePurchase>> GetArticlePurchase(int id)
        {
            var articlePurchase = await _context.ArticlePurchases.FindAsync(id);

            if (articlePurchase == null)
            {
                return NotFound();
            }

            return articlePurchase;
        }

        // PUT: api/ArticlePurchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticlePurchase(int id, ArticlePurchase articlePurchase)
        {
            if (id != articlePurchase.Id)
            {
                return BadRequest();
            }

            _context.Entry(articlePurchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticlePurchaseExists(id))
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

        // POST: api/ArticlePurchases
        [HttpPost]
        public async Task<ActionResult<ArticlePurchase>> PostArticlePurchase(ArticlePurchase articlePurchase)
        {
            _context.ArticlePurchases.Add(articlePurchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticlePurchase", new { id = articlePurchase.Id }, articlePurchase);
        }

        // DELETE: api/ArticlePurchases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArticlePurchase>> DeleteArticlePurchase(int id)
        {
            var articlePurchase = await _context.ArticlePurchases.FindAsync(id);
            if (articlePurchase == null)
            {
                return NotFound();
            }

            _context.ArticlePurchases.Remove(articlePurchase);
            await _context.SaveChangesAsync();

            return articlePurchase;
        }

        private bool ArticlePurchaseExists(int id)
        {
            return _context.ArticlePurchases.Any(e => e.Id == id);
        }
    }
}
