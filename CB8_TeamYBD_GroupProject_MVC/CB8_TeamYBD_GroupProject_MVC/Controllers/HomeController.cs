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
            return View(_context.Articles.Find(Id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
