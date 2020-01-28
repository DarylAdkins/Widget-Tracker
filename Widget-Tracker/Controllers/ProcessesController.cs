using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Widget_Tracker.Data;
using Widget_Tracker.Models;

namespace Widget_Tracker.Controllers
{
    public class ProcessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Processes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Processes.Include(p => p.Line);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Processes/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Processes/Create
        public IActionResult Create(int id)
        {
            return View();
        }

        
        // POST: Processes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //This method is used to post new process and then redirect to enter another process for the line
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] int id, [Bind("Name,Description")] Process process)        
        {
           // ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                process.LineId = id;
                _context.Add(process);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", new { id });
            }
            //ViewData["LineId"] = new SelectList(_context.Lines, "Id", "Description", process.LineId);
            return View(process);
        }

        // GET: Processes/Edit/5
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
            //ViewData["LineId"] = new SelectList(_context.Lines, "Id", "Description", process.LineId);
            return View(process);
        }

        // POST: Processes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,LineId,TimeStamp")] Process process)
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
            //ViewData["LineId"] = new SelectList(_context.Lines, "Id", "Description", process.LineId);
            return View(process);
        }

        // GET: Processes/Delete/5
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


        //This method is used to post new process and then redirect to enter another process for the line
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExit([FromRoute] int id, [Bind("Name,Description")] Process process, Line line)
        {

            if (ModelState.IsValid)
            {
                process.LineId = id;
                _context.Add(process);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Lines", new { id = line.Id });
            }
            //ViewData["LineId"] = new SelectList(_context.Lines, "Id", "Description", process.LineId);
            return View(process);
        }
    }
}
