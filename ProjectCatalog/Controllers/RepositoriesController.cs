using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCatalog.Data;
using ProjectCatalog.Models;

namespace ProjectCatalog.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly ProjectCatalogContext _context;

        public RepositoriesController(ProjectCatalogContext context)
        {
            _context = context;
        }

        // GET: Repositories
        public async Task<IActionResult> Index()
        {
              return View(await _context.Repository.ToListAsync());
        }

        // GET: Repositories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Repository == null)
            {
                return NotFound();
            }

            var repository = await _context.Repository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repository == null)
            {
                return NotFound();
            }

            return View(repository);
        }

        // GET: Repositories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repositories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Language,LastUpdatedAt,Owner")] Repository repository)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repository);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repository);
        }

        // GET: Repositories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Repository == null)
            {
                return NotFound();
            }

            var repository = await _context.Repository.FindAsync(id);
            if (repository == null)
            {
                return NotFound();
            }
            return View(repository);
        }

        // POST: Repositories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Language,LastUpdatedAt,Owner")] Repository repository)
        {
            if (id != repository.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repository);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepositoryExists(repository.Id))
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
            return View(repository);
        }

        // GET: Repositories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Repository == null)
            {
                return NotFound();
            }

            var repository = await _context.Repository
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repository == null)
            {
                return NotFound();
            }

            return View(repository);
        }

        // POST: Repositories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Repository == null)
            {
                return Problem("Entity set 'ProjectCatalogContext.Repository'  is null.");
            }
            var repository = await _context.Repository.FindAsync(id);
            if (repository != null)
            {
                _context.Repository.Remove(repository);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepositoryExists(int id)
        {
          return _context.Repository.Any(e => e.Id == id);
        }
    }
}
