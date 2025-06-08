using FinExChange.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinExChange.Infrastructure.DataAccess
{
    public class FinExChangeDBContext : DbContext
    {
        public FinExChangeDBContext(DbContextOptions<FinExChangeDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity mappings here if needed
        }
    }
}
