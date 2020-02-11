using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Widget_Tracker.Data;
using Widget_Tracker.Models;
using Widget_Tracker.Models.ViewModels;

namespace Widget_Tracker.Controllers
{
    public class ProcessesController : Controller
    {
        // Private field to store user manager
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        // Inject user manager into constructor
        public ProcessesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Private method to get current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Processes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Processes.Include(p => p.Line);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Processes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id, string link)
        {
            if (id == null)
            {
                return NotFound();
            }

            var process = await _context.Processes
                .Include(p => p.Line)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (process == null)
            {
                return NotFound();
            }

            if (link == "line")
            {
                return RedirectToAction("Details", "Lines", new { id = process.LineId });
            }
            return View(process);
        }

        // GET: Processes/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            return View();
        }


        // POST: Processes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //This method is used to post new process and then redirect to enter another process for the line
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] int id, string buttonName, [Bind("Name,Description")] Process process)        
        {
            
            //ensure a line Id is associated to the process
            if (id == 0)
            {
                return NotFound();
            }
                                 
            if (ModelState.IsValid)
            {
                process.LineId = id;
                _context.Add(process);
                await _context.SaveChangesAsync();


                //redirects are determined by the button clicked on the processes create view.
                if (buttonName == "saveCreate" || buttonName == null )
                {
                    return RedirectToAction("Create", new { id });
                }
                if (buttonName == "saveExit")
                {
                    return RedirectToAction("Details", "Lines", new { id });
                }
            }
            
            return View(process);
        }

        // GET: Processes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var process = await _context.Processes.FindAsync(id);
            if (process == null)
            {
                return NotFound();
            }
           
            return View(process);
        }

        // POST: Processes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, [Bind("Id,Name,Description,LineId")] Process process)
        {
            if (id != process.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                    _context.Update(process);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessExists(process.Id))
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
            
            return View(process);
        }

        // GET: Processes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var process = await _context.Processes
                .Include(p => p.Line)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (process == null)
            {
                return NotFound();
            }

            return View(process);
        }

        // POST: Processes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var process = await _context.Processes.FindAsync(id);
            _context.Processes.Remove(process);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessExists(int id)
        {
            return _context.Processes.Any(e => e.Id == id);
        }


       
    }
}
