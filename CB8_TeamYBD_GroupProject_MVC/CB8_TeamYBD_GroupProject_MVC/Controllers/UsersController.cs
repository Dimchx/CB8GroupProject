using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CB8_TeamYBD_GroupProject_MVC.Models;
using CB8_TeamYBD_GroupProject_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Details(string userid)
        {
            var user = _context.Users.Find(userid);
            var articles = _context.Articles.Where(x => x.Author == user).ToList();
            var listings = _context.SubscriptionListings.Where(x => x.User == user).ToList();
            var vm = new UserViewModel() { User = user, Articles = articles, Listings = listings };
            return View(vm);

        }

    }
}