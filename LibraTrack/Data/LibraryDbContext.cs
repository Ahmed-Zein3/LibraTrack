
using LibraTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraTrack.Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<LoanRecord> Loans { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=LibraTrackDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(LibraryDbContext).Assembly);
        }
    }

}
