using Microsoft.EntityFrameworkCore;
using PremiumCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PremiumCalculator.DAL
{
    public class PremiumDbContext : DbContext
    {
        public PremiumDbContext(DbContextOptions<PremiumDbContext> options) : base(options)
        {
        }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Occupation> Occupations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<Occupation>().ToTable("Occupation");

        }

    }
}
