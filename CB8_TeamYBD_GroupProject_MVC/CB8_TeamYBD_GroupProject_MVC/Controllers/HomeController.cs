﻿using System;
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
            CB8_TeamYBD_GroupProject_MVCUser user = new CB8_TeamYBD_GroupProject_MVCUser();
            try
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                user = _context.Users.Find(userId);
            }
            catch
            {
                userId = "";
            }
            Article article = _context.Articles.Include("Author").First(x => x.Id == Id);
            CB8_TeamYBD_GroupProject_MVCUser author = article.Author;
            bool paywall = article.Paid;
            DateTime dateTime = article.PostDateTime;
            List<ArticleLike> likes = _context.ArticleLikes.Include("User").Where(x => x.Article == article).ToList();
            List<Comment> comments = _context.Comments.Include("User").Where(x => x.Article == article).OrderBy(x=>x.CommentDateTime).ToList();
            List<CommentLike> commentLikes = _context.CommentLikes.Include("User").Include("Comment").Where(x => x.Comment.Article == article).ToList();
            List<CommentResponse> commentResponses = _context.CommentResponses.Include("User").Include("Comment").Where(x => x.Comment.Article == article).OrderBy(x => x.ResponseDateTime).ToList();
            List<CommentResponseLike> commentResponseLikes = _context.CommentResponseLikes.Include("User").Include(x=>x.Response.Comment).Where(x => x.Response.Comment.Article == article).ToList();
            if (paywall == false
                    ||
                (
                    paywall == true 
                        && 
                    (
                        user == author 
                            || 
                        user.Premium == true 
                            || 
                        (_context.ArticlePurchases.Where(x => x.Article == article && x.User == user).Count() > 0) 
                            || 
                        (_context.UserSubcriptions.Where(x => x.Subscriber == user && x.Subscription.User == author && x.EndDate.CompareTo(DateTime.Now) > 0).Count() > 0)
                    )
                 )
               )
            {
                ReadViewModel vm = new ReadViewModel() { UserId = userId, Article = article, Author = author, Likes = likes, Comments = comments, ArticlePostDateTime = dateTime, CommentLikes = commentLikes, CommentResponses = commentResponses, CommentResponseLikes=commentResponseLikes };
                return View(vm);
            }
            else
            {
                article.Content = "<h5 style='color: white;'>This article is paid. Please login/register and purchase either this article, a subscription to the author, or a premium ReedMie account.</h5>";
                ReadViewModel vm = new ReadViewModel() { UserId = userId, Article = article, Author = author, Likes = likes, Comments = comments, ArticlePostDateTime = dateTime, CommentLikes = commentLikes, CommentResponses = commentResponses, CommentResponseLikes=commentResponseLikes };
                return View(vm);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
