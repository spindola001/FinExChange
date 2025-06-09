using FinExChange.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinExChangeDBContext).Assembly);
        }
    }
}
