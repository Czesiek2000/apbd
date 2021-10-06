using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia10.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia10.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext ( DbContextOptions<MvcMovieContext> options ) : base( options ) {}

        public DbSet<Movie> Movie { get; set; }
    }
}
