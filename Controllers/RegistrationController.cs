using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBaseFirstEFCore.Models;

namespace DataBaseFirstEFCore.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AarohiContext _context;

        public RegistrationController(AarohiContext context)
        {
            _context = context;
        }

        // GET: Registration
        public async Task<IActionResult> Index()
        {
              return _context.Registration1s != null ? 
                          View(await _context.Registration1s.ToListAsync()) :
                          Problem("Entity set 'AarohiContext.Registration1s'  is null.");
        }

        // GET: Registration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registration1s == null)
            {
                return NotFound();
            }

            var registration1 = await _context.Registration1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration1 == null)
            {
                return NotFound();
            }

            return View(registration1);
        }

        // GET: Registration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailId,Password,Dob,Gender,ContactNumber,Dept,Role,Fee,Status,Qualification")] Registration1 registration1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registration1);
        }

        // GET: Registration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registration1s == null)
            {
                return NotFound();
            }

            var registration1 = await _context.Registration1s.FindAsync(id);
            if (registration1 == null)
            {
                return NotFound();
            }
            return View(registration1);
        }

        // POST: Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailId,Password,Dob,Gender,ContactNumber,Dept,Role,Fee,Status,Qualification")] Registration1 registration1)
        {
            if (id != registration1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Registration1Exists(registration1.Id))
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
            return View(registration1);
        }

        // GET: Registration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registration1s == null)
            {
                return NotFound();
            }

            var registration1 = await _context.Registration1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration1 == null)
            {
                return NotFound();
            }

            return View(registration1);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registration1s == null)
            {
                return Problem("Entity set 'AarohiContext.Registration1s'  is null.");
            }
            var registration1 = await _context.Registration1s.FindAsync(id);
            if (registration1 != null)
            {
                _context.Registration1s.Remove(registration1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Registration1Exists(int id)
        {
          return (_context.Registration1s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
