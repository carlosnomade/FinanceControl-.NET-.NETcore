using Finance.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Config
{
    public class BasicContext : IdentityDbContext<ApplicationUser>
    {
        public BasicContext( DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<FinanceSystem> FinanceSystem { set; get; }
        public DbSet<UserFinanceSystem> UserFinanceSystem { set; get; }
        public DbSet<Categories> Categories { set; get; }
        public DbSet<Expenses> Expenses { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObtainStringConnection());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(testc => testc.Id);

            base.OnModelCreating(builder);
        }

        public string ObtainStringConnection()
        {
            return "Data Source=DESKTOP-NPJN69B\\SQLEXPRESS;Initial Catalog=MyFinance;Integrated Security=true; TrustServerCertificate=true";
        }


    }
}
