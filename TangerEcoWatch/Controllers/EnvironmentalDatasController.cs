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
    public class EnvironmentalDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnvironmentalDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EnvironmentalDatas
        public async Task<IActionResult> Index()
        {
              return _context.EnvironmentalData != null ? 
                          View(await _context.EnvironmentalData.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EnvironmentalData'  is null.");
        }

        // GET: EnvironmentalDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EnvironmentalData == null)
            {
                return NotFound();
            }

            var environmentalData = await _context.EnvironmentalData
                .FirstOrDefaultAsync(m => m.DataId == id);
            if (environmentalData == null)
            {
                return NotFound();
            }

            return View(environmentalData);
        }

        // GET: EnvironmentalDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnvironmentalDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataId,Type,Value,TimeStamp,Location")] EnvironmentalData environmentalData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(environmentalData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(environmentalData);
        }

        // GET: EnvironmentalDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EnvironmentalData == null)
            {
                return NotFound();
            }

            var environmentalData = await _context.EnvironmentalData.FindAsync(id);
            if (environmentalData == null)
            {
                return NotFound();
            }
            return View(environmentalData);
        }

        // POST: EnvironmentalDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataId,Type,Value,TimeStamp,Location")] EnvironmentalData environmentalData)
        {
            if (id != environmentalData.DataId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(environmentalData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnvironmentalDataExists(environmentalData.DataId))
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
            return View(environmentalData);
        }

        // GET: EnvironmentalDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EnvironmentalData == null)
            {
                return NotFound();
            }

            var environmentalData = await _context.EnvironmentalData
                .FirstOrDefaultAsync(m => m.DataId == id);
            if (environmentalData == null)
            {
                return NotFound();
            }

            return View(environmentalData);
        }

        // POST: EnvironmentalDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EnvironmentalData == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EnvironmentalData'  is null.");
            }
            var environmentalData = await _context.EnvironmentalData.FindAsync(id);
            if (environmentalData != null)
            {
                _context.EnvironmentalData.Remove(environmentalData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnvironmentalDataExists(int id)
        {
          return (_context.EnvironmentalData?.Any(e => e.DataId == id)).GetValueOrDefault();
        }
    }
}
