using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.AspNetCore.Http;

using MvcMovie.Models.Process;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;
        private ExcelProcess _excelPro = new ExcelProcess();

        public MoviesController(MvcMovieContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public IConfiguration Configuration  {get;}
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
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] MoviesNew_ moviesNew_, IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to server
                    //tao duong dan /Uploads/Excels de luu file upload len server
                    var fileName = "Book1";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName + fileExtension);
                    var fileLocation = new FileInfo(filePath).ToString();
                    

                    if (ModelState.IsValid)
                    {
                        //upload file to server
                        if (file.Length > 0)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //save file to server
                                await file.CopyToAsync(stream);
                                //read data from file and write to database
                                //_excelPro la doi tuong xu ly file excel ExcelProcess
                                var dt = _excelPro.ExcelToDataTable(fileLocation);
                                //ghi du lieu datatable vao database
                                // BUOC 4: LUU DATA TU DATATABLE ->CSDL
                                WriteInformaticResults(dt);
                            }
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
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

        private int WriteInformaticResults(DataTable dt)
        {
            try
            {
                var con = Configuration.GetConnectionString("MvcMovieContext");
                SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
                bulkCopy.DestinationTableName = "MoviesNew_";
                bulkCopy.ColumnMappings.Add(0, "Id");
                bulkCopy.ColumnMappings.Add(1, "Title");
                bulkCopy.ColumnMappings.Add(2, "ReleaseDate");
                bulkCopy.ColumnMappings.Add(3, "Price");
                bulkCopy.ColumnMappings.Add(4, "Genre");
                bulkCopy.ColumnMappings.Add(5, "Rating");
            }
            catch
            {

                return 0;
            }
            return dt.Rows.Count;
        }
    }
}
