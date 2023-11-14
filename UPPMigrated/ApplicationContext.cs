using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPPMigrated.Entities;

namespace UPPMigrated
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Share> Shares => Set<Share>();
        public DbSet<Cost> Costs => Set<Cost>();
        public DbSet<Buy> Buys => Set<Buy>();
        public DbSet<Sell> Sells => Set<Sell>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=UPPapp.db");
        }
    }
}
