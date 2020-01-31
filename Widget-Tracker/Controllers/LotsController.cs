using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Widget_Tracker.Data;
using Widget_Tracker.Models;
using Widget_Tracker.Models.ViewModels;

namespace Widget_Tracker.Controllers
{
    public class LotsController : Controller
    {
        // Private field to store user manager
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        // Inject user manager into constructor
        public LotsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Private method to get current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Lots
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lots
                .Include(lot => lot.User)
                .Include(lot => lot.AssociatedLine);
                //.Include(line => line.Id);
               


            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lots/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lot = await _context.Lots
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View(lot);
        }

        // GET: Lots/Create
        [Authorize]
        public IActionResult Create()
        {
            
            CreateLotViewModel vm = new CreateLotViewModel();
            vm.Lines = _context.Lines.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            vm.Lines.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose a manufacturing line"
            });
            return View(vm);
        }

        // POST: Lots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLotViewModel vm)
        {
            ModelState.Remove("Lot.UserId");
            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                vm.Lot.UserId = currentUser.Id;
                _context.Add(vm.Lot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.Lines = _context.Lines.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return View(vm);
        }

        // GET: Lots/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lot = await _context.Lots.FindAsync(id);
            if (lot == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", lot.UserId);
            return View(lot);
        }

        // POST: Lots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,LineId,UserId,DateCreated")] Lot lot)
        {
            if (id != lot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LotExists(lot.Id))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", lot.UserId);
            return View(lot);
        }

        // GET: Lots/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lot = await _context.Lots
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View(lot);
        }

        // POST: Lots/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lot = await _context.Lots.FindAsync(id);
            _context.Lots.Remove(lot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LotExists(int id)
        {
            return _context.Lots.Any(e => e.Id == id);
        }
    }
}
