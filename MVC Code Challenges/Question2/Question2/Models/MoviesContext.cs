using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Question2.Models;


namespace Question2.Models
{

    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("name=MoviesDbConnection") { }

        public DbSet<Movies> Movies { get; set; }
    }

}