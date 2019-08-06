using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CB8_TeamYBD_GroupProject_MVC.Areas.Identity.Data;
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
            var profile = _context.Users.Find(id);
            string userid;
            CB8_TeamYBD_GroupProject_MVCUser user = new CB8_TeamYBD_GroupProject_MVCUser();
            try
            {
                userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                user = _context.Users.Find(userid);
            }
            catch
            {
                userid = "";
            }
            List<Article> articles = _context.Articles.Where(x => x.Author == profile).ToList();
            List<SubscriptionListing> listings = _context.SubscriptionListings.Where(x => x.User == profile).ToList();
            List<Follow> follows = _context.Follows.Include(x => x.Follower).Where(x => x.User == profile).ToList();
            UserViewModel vm = new UserViewModel() {UserId=userid, User = profile, Articles = articles, Listings = listings, Follows=follows };
            return View(vm);

        }
        public IActionResult Favorites()
        {
            List<CB8_TeamYBD_GroupProject_MVCUser> favorites = new List<CB8_TeamYBD_GroupProject_MVCUser>();
            if (User.Identity.IsAuthenticated)
            {
                string userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                CB8_TeamYBD_GroupProject_MVCUser user = _context.Users.Find(userid);
                favorites = _context.Follows.Where(x => x.Follower == user).Select(x => x.User).ToList();
            }
            return View(favorites);
        }
    }
}