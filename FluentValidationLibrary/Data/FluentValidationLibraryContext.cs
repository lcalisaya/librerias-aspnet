using FluentValidationLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationLibrary.Data
{
    public class FluentValidationLibraryContext : DbContext
    {
        public FluentValidationLibraryContext (DbContextOptions<FluentValidationLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
