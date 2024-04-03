using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TangerEcoWatch.Data;
using TangerEcoWatch.Models;

namespace TangerEcoWatch.Controllers
{
    public class CleanUpEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CleanUpEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CleanUpEvents
        public async Task<IActionResult> Index()
        {
              return _context.CleanUpEvent != null ? 
                          View(await _context.CleanUpEvent.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CleanUpEvent'  is null.");
        }

        // GET: CleanUpEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CleanUpEvent == null)
            {
                return NotFound();
            }

            var cleanUpEvent = await _context.CleanUpEvent
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (cleanUpEvent == null)
            {
                return NotFound();
            }

            return View(cleanUpEvent);
        }

        // GET: CleanUpEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CleanUpEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Name,Location,Date")] CleanUpEvent cleanUpEvent)
        {
            cleanUpEvent.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(cleanUpEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cleanUpEvent);
        }

        // GET: CleanUpEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CleanUpEvent == null)
            {
                return NotFound();
            }

            var cleanUpEvent = await _context.CleanUpEvent.FindAsync(id);
            if (cleanUpEvent == null)
            {
                return NotFound();
            }
            return View(cleanUpEvent);
        }

        // POST: CleanUpEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Name,Location,Date")] CleanUpEvent cleanUpEvent)
        {
            if (id != cleanUpEvent.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cleanUpEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CleanUpEventExists(cleanUpEvent.EventId))
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
            return View(cleanUpEvent);
        }

        // GET: CleanUpEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CleanUpEvent == null)
            {
                return NotFound();
            }

            var cleanUpEvent = await _context.CleanUpEvent
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (cleanUpEvent == null)
            {
                return NotFound();
            }

            return View(cleanUpEvent);
        }

        // POST: CleanUpEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CleanUpEvent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CleanUpEvent'  is null.");
            }
            var cleanUpEvent = await _context.CleanUpEvent.FindAsync(id);
            if (cleanUpEvent != null)
            {
                _context.CleanUpEvent.Remove(cleanUpEvent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CleanUpEventExists(int id)
        {
          return (_context.CleanUpEvent?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
