using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CB8_TeamYBD_GroupProject_MVC.Models;
using CB8_TeamYBD_GroupProject_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CB8_TeamYBD_GroupProject_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;
        public UsersController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Users.ToList();
            return View(model);
        }
        public IActionResult Details(string id)
        {
            var user = _context.Users.Find(id);
            string userid;
            try
            {
                userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                user = _context.Users.Find(userid);
            }
            catch
            {
                userid = "";
            }
            List<Article> articles = _context.Articles.Where(x => x.Author == user).ToList();
            List<SubscriptionListing> listings = _context.SubscriptionListings.Where(x => x.User == user).ToList();
            List<Follow> follows = _context.Follows.Include(x => x.Follower).Where(x => x.User == user).ToList();
            UserViewModel vm = new UserViewModel() {UserId=userid, User = user, Articles = articles, Listings = listings, Follows=follows };
            return View(vm);

        }

    }
}