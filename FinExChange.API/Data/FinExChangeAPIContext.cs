using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinExChange.API.Models;

namespace FinExChange.API.Data
{
    public class FinExChangeAPIContext : DbContext
    {
        public FinExChangeAPIContext (DbContextOptions<FinExChangeAPIContext> options)
            : base(options)
        {
        }

        public DbSet<FinExChange.API.Models.TransactionModel> TransactionModel { get; set; } = default!;
    }
}
