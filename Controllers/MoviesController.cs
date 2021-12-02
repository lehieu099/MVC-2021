using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.MoviesNew_.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesNew_ = await _context.MoviesNew_
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesNew_ == null)
            {
                return NotFound();
            }

            return View(moviesNew_);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] MoviesNew_ moviesNew_)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesNew_);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moviesNew_);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesNew_ = await _context.MoviesNew_.FindAsync(id);
            if (moviesNew_ == null)
            {
                return NotFound();
            }
            return View(moviesNew_);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] MoviesNew_ moviesNew_)
        {
            if (id != moviesNew_.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviesNew_);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviesNew_Exists(moviesNew_.Id))
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
            return View(moviesNew_);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviesNew_ = await _context.MoviesNew_
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviesNew_ == null)
            {
                return NotFound();
            }

            return View(moviesNew_);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviesNew_ = await _context.MoviesNew_.FindAsync(id);
            _context.MoviesNew_.Remove(moviesNew_);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviesNew_Exists(int id)
        {
            return _context.MoviesNew_.Any(e => e.Id == id);
        }
    }
}
