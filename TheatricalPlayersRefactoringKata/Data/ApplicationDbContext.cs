// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace TheatricalPlayersRefactoringKata.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<Performance> Performances { get; set; }
    }
}