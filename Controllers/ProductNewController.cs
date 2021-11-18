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
    public class ProductNewController : Controller
    {
        private readonly MvcMovieContext _context;

        public ProductNewController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: ProductNew
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.ProductNew.Include(p => p.Categories_);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: ProductNew/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productNew = await _context.ProductNew
                .Include(p => p.Categories_)
                .FirstOrDefaultAsync(m => m.ProductNewID == id);
            if (productNew == null)
            {
                return NotFound();
            }

            return View(productNew);
        }

        // GET: ProductNew/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName");
            
            return View();
        }

        // POST: ProductNew/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductNewID,ProductNewName,CategoryName")] ProductNew productNew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productNew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryName", "CategoryName", productNew.CategoryID);
            return View(productNew);
        }

        // GET: ProductNew/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productNew = await _context.ProductNew.FindAsync(id);
            if (productNew == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryName", "CategoryName", productNew.CategoryID);
            return View(productNew);
        }

        // POST: ProductNew/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductNewID,ProductNewName,CategoryName")] ProductNew productNew)
        {
            if (id != productNew.ProductNewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productNew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductNewExists(productNew.ProductNewID))
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
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryName", "CategoryName", productNew.CategoryID);
            return View(productNew);
        }

        // GET: ProductNew/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productNew = await _context.ProductNew
                .Include(p => p.Categories_)
                .FirstOrDefaultAsync(m => m.ProductNewID == id);
            if (productNew == null)
            {
                return NotFound();
            }

            return View(productNew);
        }

        // POST: ProductNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productNew = await _context.ProductNew.FindAsync(id);
            _context.ProductNew.Remove(productNew);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductNewExists(int id)
        {
            return _context.ProductNew.Any(e => e.ProductNewID == id);
        }
    }
}
