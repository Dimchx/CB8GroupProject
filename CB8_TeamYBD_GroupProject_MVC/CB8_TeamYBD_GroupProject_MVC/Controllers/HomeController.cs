using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CB8_TeamYBD_GroupProject_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CB8_TeamYBD_GroupProject_MVC.ViewModels;
using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;

namespace CB8_TeamYBD_GroupProject_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;
        public HomeController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> Read(int Id)
        {
            Article article = _context.Articles.Find(Id);
            CB8_TeamYBD_GroupProject_MVCUser author = article.Author;
            DateTime dateTime = article.PostDateTime;
            List<ArticleLike> likes = _context.ArticleLikes.Where(x => x.Article == article).ToList();
            List<Comment> comments = _context.Comments.Where(x => x.Article == article).OrderBy(x=>x.CommentDateTime).ToList();
            ReadViewModel vm = new ReadViewModel() { Article=article,Author=author,Likes=likes,Comments=comments,ArticlePostDateTime=dateTime };
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
