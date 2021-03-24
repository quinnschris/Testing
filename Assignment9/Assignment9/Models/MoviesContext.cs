using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment9.Models
{
    // DbContext class that grabs from the Database so we have something to "Query" outta

    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
