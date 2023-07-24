using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoXamarinAPI.Models;

namespace DemoXamarinAPI.Data
{
    public class DemoXamarinDbContext : DbContext
    {
        public DemoXamarinDbContext (DbContextOptions<DemoXamarinDbContext> options)
            : base(options)
        {
        }

        public DbSet<DemoXamarinAPI.Models.Client> Clients { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            //modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            //modelBuilder.Entity<User>().ToTable(nameof(User));

            base.OnModelCreating(modelBuilder);
        }

    }
}
