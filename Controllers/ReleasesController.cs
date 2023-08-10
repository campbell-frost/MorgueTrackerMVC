using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MorgueTrackerMVC.Models;

namespace MorgueTrackerMVC.Controllers
{
    public class ReleasesController : Controller
    {
        private readonly MorgueTrackerContext _context;

        public ReleasesController(MorgueTrackerContext context)
        {
            _context = context;
        }

        // GET: Releases
        public async Task<IActionResult> Index()
        {
            var morgueTrackerContext = _context.Releases.Include(r => r.OutEmployee).Include(r => r.Patient);
            return View(await morgueTrackerContext.ToListAsync());
        }

        // GET: Releases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Releases == null)
            {
                return NotFound();
            }

            var release = await _context.Releases
                .Include(r => r.OutEmployee)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.ReleaseID == id);
            if (release == null)
            {
                return NotFound();
            }

            return View(release);
        }

        // GET: Releases/Create
        public IActionResult Create()
        {
            ViewData["OutEmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID");
            ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "PatientID");
            return View();
        }

        // POST: Releases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReleaseID,PatientID,OutEmployeeID,FuneralHome,FuneralHomeEmployee,PickedUpDate")] Release release)
        {
            if (ModelState.IsValid)
            {
                _context.Add(release);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OutEmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", release.OutEmployeeID);
            ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "PatientID", release.PatientID);
            return View(release);
        }

        // GET: Releases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Releases == null)
            {
                return NotFound();
            }

            var release = await _context.Releases.FindAsync(id);
            if (release == null)
            {
                return NotFound();
            }
            ViewData["OutEmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", release.OutEmployeeID);
            ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "PatientID", release.PatientID);
            return View(release);
        }

        // POST: Releases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReleaseID,PatientID,OutEmployeeID,FuneralHome,FuneralHomeEmployee,PickedUpDate")] Release release)
        {
            if (id != release.ReleaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(release);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReleaseExists(release.ReleaseID))
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
            ViewData["OutEmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", release.OutEmployeeID);
            ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "PatientID", release.PatientID);
            return View(release);
        }

        // GET: Releases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Releases == null)
            {
                return NotFound();
            }

            var release = await _context.Releases
                .Include(r => r.OutEmployee)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.ReleaseID == id);
            if (release == null)
            {
                return NotFound();
            }

            return View(release);
        }

        // POST: Releases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Releases == null)
            {
                return Problem("Entity set 'MorgueTrackerContext.Releases'  is null.");
            }
            var release = await _context.Releases.FindAsync(id);
            if (release != null)
            {
                _context.Releases.Remove(release);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReleaseExists(int id)
        {
          return (_context.Releases?.Any(e => e.ReleaseID == id)).GetValueOrDefault();
        }
    }
}
