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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            List<Article> articles = _context.Articles.Include("Author").OrderByDescending(x=>x.PostDateTime).ToList();
            return View(articles);
        }

        
        public async Task<IActionResult> Read(int Id)
        {
            string userId;
            try
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            catch
            {
                userId = "";
            }
            Article article = _context.Articles.Find(Id);
            CB8_TeamYBD_GroupProject_MVCUser author = article.Author;
            bool paywall = article.Paid;
            DateTime dateTime = article.PostDateTime;
            List<ArticleLike> likes = _context.ArticleLikes.Include("User").Where(x => x.Article == article).ToList();
            List<Comment> comments = _context.Comments.Include("User").Where(x => x.Article == article).OrderBy(x=>x.CommentDateTime).ToList();
            List<CommentLike> commentLikes = _context.CommentLikes.Include("User").Include("Comment").Where(x => x.Comment.Article == article).OrderBy(x => x.LikeDateTime).ToList();
            ReadViewModel vm = new ReadViewModel() { UserId=userId, Article=article,Author=author,Likes=likes,Comments=comments,ArticlePostDateTime=dateTime, CommentLikes=commentLikes };
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
