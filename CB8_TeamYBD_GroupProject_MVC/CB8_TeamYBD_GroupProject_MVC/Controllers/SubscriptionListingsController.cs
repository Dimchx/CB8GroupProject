using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CB8_TeamYBD_GroupProject_MVC.Models;
using System.Security.Claims;
using CB8_TeamYBD_GroupProject_MVC.ViewModels;

namespace CB8_TeamYBD_GroupProject_MVC.Controllers
{
    public class SubscriptionListingsController : Controller
    {
        private readonly CB8_TeamYBD_GroupProject_MVCContext _context;

        public SubscriptionListingsController(CB8_TeamYBD_GroupProject_MVCContext context)
        {
            _context = context;
        }

        // GET: SubscriptionListings
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubscriptionListings.ToListAsync());
        }

        // GET: SubscriptionListings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionListing = await _context.SubscriptionListings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriptionListing == null)
            {
                return NotFound();
            }

            return View(subscriptionListing);
        }

        // GET: SubscriptionListings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionListings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,DayDuration,MonthDuration")] SubscriptionListingViewModel vm)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.Find(userId);
            vm.User = user;
            SubscriptionListing listing = (SubscriptionListing)vm;
            if (ModelState.IsValid)
            {

                _context.Add(listing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: SubscriptionListings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionListing = await _context.SubscriptionListings.FindAsync(id);
            if (subscriptionListing == null)
            {
                return NotFound();
            }
            return View(subscriptionListing);
        }

        // POST: SubscriptionListings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,DayDuration,MonthDuration")] SubscriptionListing subscriptionListing)
        {
            if (id != subscriptionListing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriptionListing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionListingExists(subscriptionListing.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subscriptionListing);
        }

        // GET: SubscriptionListings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionListing = await _context.SubscriptionListings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriptionListing == null)
            {
                return NotFound();
            }

            return View(subscriptionListing);
        }

        // POST: SubscriptionListings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriptionListing = await _context.SubscriptionListings.FindAsync(id);
            _context.SubscriptionListings.Remove(subscriptionListing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionListingExists(int id)
        {
            return _context.SubscriptionListings.Any(e => e.Id == id);
        }
    }
}
