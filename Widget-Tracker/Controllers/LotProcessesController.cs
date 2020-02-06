using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Widget_Tracker.Data;
using Widget_Tracker.Models;

namespace Widget_Tracker.Controllers
{
    public class LotProcessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LotProcessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LotProcesses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LotProcesses
                .Include(l => l.Lot)
                .Include(l => l.Process);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LotProcesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotProcess = await _context.LotProcesses
                .Include(l => l.Lot)
                .Include(l => l.Process)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lotProcess == null)
            {
                return NotFound();
            }

            return View(lotProcess);
        }

        // GET: LotProcesses/Create
        public IActionResult Create()
        {
            //ViewData["LotId"] = new SelectList(_context.Lots, "Id", "ProductName");
            //ViewData["ProcessId"] = new SelectList(_context.Processes, "Id", "Description");
            return View();
        }

        // POST: LotProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int lineId, LotProcess lotProcess, List<Process> processes)
        {
            if (processes is null)
            {
                throw new ArgumentNullException(nameof(processes));
            }

            if (ModelState.IsValid)
            {
                {
                    foreach (Process singleProcess in processes)

                        _context.Add(lotProcess);
                }
                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            //ViewData["LotId"] = new SelectList(_context.Lots, "Id", "ProductName", lotProcess.LotId);
            //ViewData["ProcessId"] = new SelectList(_context.Processes, "Id", "Description", lotProcess.ProcessId);
            return View(lotProcess);
        }

        // GET: LotProcesses/Edit/5
        public async Task<IActionResult> Edit(int? id, int LineId)
        {
            if (id == null)
            {
                return NotFound();
            }


            var lotProcess = await _context.LotProcesses.FindAsync(id);
            if (lotProcess == null)
            {
                return NotFound();
            }
            ViewData["LotId"] = new SelectList(_context.Lots, "Id", "ProductName", lotProcess.LotId);
            ViewData["ProcessId"] = new SelectList(_context.Processes, "Id", "Description", lotProcess.ProcessId);
            return RedirectToAction("Edit", new { id = lotProcess.Id }); ;
        }

        // POST: LotProcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int LineId, int id, [Bind("Id,LotId,ProcessId")] LotProcess lotProcess)
        {
            if (id != lotProcess.Id)
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
                    if (!LotProcessExists(lotProcess.Id))
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
            ViewData["LotId"] = new SelectList(_context.Lots, "Id", "ProductName", lotProcess.LotId);
            ViewData["ProcessId"] = new SelectList(_context.Processes, "Id", "Description", lotProcess.ProcessId);
            return View(lotProcess);
        }

        // GET: LotProcesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotProcess = await _context.LotProcesses
                .Include(l => l.Lot)
                .Include(l => l.Process)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lotProcess == null)
            {
                return NotFound();
            }

            return View(lotProcess);
        }

        // POST: LotProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lotProcess = await _context.LotProcesses.FindAsync(id);
            _context.LotProcesses.Remove(lotProcess);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LotProcessExists(int id)
        {
            return _context.LotProcesses.Any(e => e.Id == id);
        }
    }
}
