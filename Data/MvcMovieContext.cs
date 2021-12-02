using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }


        public DbSet<MvcMovie.Models.Person> Person { get; set; }
        public DbSet<MvcMovie.Models.Student> Students { get; set; }

        public DbSet<MvcMovie.Models.Employee> Employee { get; set; }

        public DbSet<MvcMovie.Models.Category> Category { get; set; }

        public DbSet<MvcMovie.Models.ProductNew> ProductNew { get; set; }

        public DbSet<MvcMovie.Models.MoviesNew_> MoviesNew_ { get; set; }

       }
}