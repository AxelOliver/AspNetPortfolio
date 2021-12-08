using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;

namespace MyPortfolio.Models
{
    public class StubbiesController : Controller
    {
        private readonly MyPortfolioContext _context;

        public StubbiesController(MyPortfolioContext context)
        {
            _context = context;
        }

        // GET: Stubbies
        public IActionResult Index()
        {
            var userId = "1";
            var user = _context.ApplicationUser.Where(u => u.Id == userId).Include(s => s.Stubbies).FirstOrDefault();
            return View(user);
        }

        // GET: Stubbies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stubby = await _context.Stubby
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stubby == null)
            {
                return NotFound();
            }

            return View(stubby);
        }

        // GET: Stubbies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stubbies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdentityUserId,OriginalLink,ShortenedLink")] Stubby stubby)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stubby);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stubby);
        }

        // GET: Stubbies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stubby = await _context.Stubby.FindAsync(id);
            if (stubby == null)
            {
                return NotFound();
            }
            return View(stubby);
        }

        // POST: Stubbies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentityUserId,OriginalLink,ShortenedLink")] Stubby stubby)
        {
            if (id != stubby.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stubby);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StubbyExists(stubby.Id))
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
            return View(stubby);
        }

        // GET: Stubbies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stubby = await _context.Stubby
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stubby == null)
            {
                return NotFound();
            }

            return View(stubby);
        }

        // POST: Stubbies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stubby = await _context.Stubby.FindAsync(id);
            _context.Stubby.Remove(stubby);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StubbyExists(int id)
        {
            return _context.Stubby.Any(e => e.Id == id);
        }
    }
}
