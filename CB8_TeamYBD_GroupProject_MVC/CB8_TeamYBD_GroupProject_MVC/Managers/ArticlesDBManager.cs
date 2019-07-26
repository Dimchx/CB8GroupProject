using CB8_TeamYBD_GroupProject_MVC.Data;
using CB8_TeamYBD_GroupProject_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB8_TeamYBD_GroupProject_MVC.Managers
{
    public class ArticlesDBManager
    {
        private readonly ApplicationDbContext _context;

        public List<Article> MyArticles(string authorId)
        {
            IdentityUser author = _context.Users.Find(authorId);
            switch (_context.Article.Where(x => x.Author == author).ToList())
            {
                case null:
                    return new List<Article> { };
                default:
                    return _context.Article.Where(x => x.Author == author).ToList();
            }
        }
    }
}
