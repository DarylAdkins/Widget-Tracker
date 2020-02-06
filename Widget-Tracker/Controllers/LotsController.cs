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
        public async Task<IActionResult> Index(string searchQuery)
        {
               
                ApplicationUser loggedInUser = await GetCurrentUserAsync();

            List<Lot> lotsList = await _context.Lots.Where(p => p.User == loggedInUser)                
                .Include(lot => lot.User)                
                .Include(lot => lot.AssociatedLine).ToListAsync();

            //List<Lot> lots = await _context.Lots.Where(p => p.User == loggedInUser).ToListAsync();
            if (searchQuery != null)
            {
                lotsList = lotsList.Where(lots => lots.ProductName.ToString().Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }




            return View(lotsList);
        }

        // GET: Lots/Details/5
        [Authorize]
        public async Task<IActionResult> Details([FromRoute] int? id, LotProcess lotProcess)
        {
            

            if (id == null)
            {
                return NotFound();
            }
            ApplicationUser loggedInUser = await GetCurrentUserAsync(); var applicationDbContext = _context.Lots;
            var lot = await _context.Lots
                .Include(lot => lot.User).Where(lot => lot.User == loggedInUser)
                .Include(lot => lot.AssociatedLine)
                .Include(lot => lot.LotProcesses) 
                .ThenInclude(lot => lot.Process)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            //for running lots, need to add conditionals to look for LotProcess accounts with LotId that have time 
            //in value and time out =null. if none are null???
            //update time in on LotProcesses with edit type function??
            //ViewModel??? because of needing to read lotprocess and lot detail info??
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
        public async Task<IActionResult> Create(CreateLotViewModel vm, List<Line> processes)
        {
           
            ModelState.Remove("Lot.UserId");
            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                vm.Lot.UserId = currentUser.Id;
                List<Process> listOfProcesses = await _context.Processes.Where(p => p.LineId == vm.Lot.LineId).ToListAsync();
                _context.Lots.Add(vm.Lot);
                await _context.SaveChangesAsync();
                foreach (Process singleProcess in listOfProcesses)
                {
                    LotProcess newlp = new LotProcess()
                    {
                        LotId = vm.Lot.Id,
                        ProcessId = singleProcess.Id
                    };
                    _context.LotProcesses.Add(newlp);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = vm.Lot.Id });
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
        public async Task<IActionResult> Edit(int? id, int LotId)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser loggedInUser = await GetCurrentUserAsync(); var applicationDbContext = _context.Lots
               .Include(lot => lot.User).Where(lot => lot.User == loggedInUser)
               .Include(lot => lot.AssociatedLine);

            var lot = await _context.Lots.FindAsync(id);
            if (lot == null)
            {
                return NotFound();
            }
            //ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", lot.UserId);
         return View (lot);
        }

        // POST: Lots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,LineId,UserId,DateCreated")] Lot lot, LotProcess lotProcess)
        {
           
            if (id != lot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lotProcess);
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
            //ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", lot.UserId);
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

        //Update LotProcess table to show advancement of lot through line
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> NextStep(int Id, LotProcess lotprocess)
        {
            ApplicationUser loggedInUser = await GetCurrentUserAsync();

            var listOfProcesses = await _context.LotProcesses.Where(lp => lp.LotId == Id).OrderBy(p => p.Process.TimeStamp)
               .Include(lp => lp.Lot)
               .Include(lp => lp.Process)
               .Where(lot => lot.Lot.User == loggedInUser).ToListAsync();

            LotProcess currentstep = listOfProcesses.Where(lop => lop.TimeIn == null).FirstOrDefault();

            if (currentstep == null)
                {
                    return RedirectToAction("Details", new { id = Id });
                }
           
            
            currentstep.TimeIn = DateTime.Now;
            
            _context.Update(currentstep);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = currentstep.LotId });
        }
            
        
        private bool LotExists(int id)
        {
            return _context.Lots.Any(e => e.Id == id);
        }
    }
}
