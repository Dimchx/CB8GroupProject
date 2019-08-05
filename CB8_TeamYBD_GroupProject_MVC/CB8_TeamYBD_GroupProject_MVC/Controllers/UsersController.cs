using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CB8_TeamYBD_GroupProject_MVC.Models;
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
    }
}