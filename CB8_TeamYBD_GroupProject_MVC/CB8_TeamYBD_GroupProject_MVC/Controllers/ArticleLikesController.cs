﻿using System;
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
    public class ArticleLikesController : ControllerBase
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public ArticleLikesController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleLike>>> GetArticleLike()
        {
            return await _context.ArticleLikes.ToListAsync();
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleLike>> GetArticleLike(int id)
        {
            var ArticleLike = await _context.ArticleLikes.FindAsync(id);

            if (ArticleLike == null)
            {
                return NotFound();
            }

            return ArticleLike;
        }

        // PUT: api/Likes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticleLike(int id, ArticleLike ArticleLike)
        {
            if (id != ArticleLike.Id)
            {
                return BadRequest();
            }

            _context.Entry(ArticleLike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleLikeExists(id))
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

        // POST: api/Likes
        [HttpPost]
        public async Task<ActionResult<ArticleLike>> PostArticleLike(ArticleLike ArticleLike)
        {
            _context.ArticleLikes.Add(ArticleLike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticleLike", new { id = ArticleLike.Id }, ArticleLike);
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArticleLike>> DeleteLike(int id)
        {
            var ArticleLike = await _context.ArticleLikes.FindAsync(id);
            if (ArticleLike == null)
            {
                return NotFound();
            }

            _context.ArticleLikes.Remove(ArticleLike);
            await _context.SaveChangesAsync();

            return ArticleLike;
        }

        private bool ArticleLikeExists(int id)
        {
            return _context.ArticleLikes.Any(e => e.Id == id);
        }
    }
}