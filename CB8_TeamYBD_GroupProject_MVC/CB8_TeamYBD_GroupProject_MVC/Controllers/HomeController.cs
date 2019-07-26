using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CB8_TeamYBD_GroupProject_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using CB8_TeamYBD_GroupProject_MVC.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace CB8_TeamYBD_GroupProject_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult SeeArticle(int Id)
        {
            bool purchased = false;
            var article = _context.Article.Find(Id);
               IdentityUser user = new IdentityUser();
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    user = _context.Users.Find(userId);
                    foreach (var i in article.PurchasedBy)
                    {
                        if (user == i)
                            purchased = true;
                    }
                }

                if (article.Paid == false || user == article.Author || purchased == true)
                    return View(article);
                else
                    return RedirectToAction("Index");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
