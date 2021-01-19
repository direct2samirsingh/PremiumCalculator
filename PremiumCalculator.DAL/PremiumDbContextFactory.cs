using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.DAL
{
    public class PremiumDbContextFactory : IDesignTimeDbContextFactory<PremiumDbContext>
    {
        public PremiumDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", true)
                 .AddEnvironmentVariables()
                 .Build();

            var builder = new DbContextOptionsBuilder<PremiumDbContext>();

            var connectionString = configuration
                        .GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString,
                        x => x.MigrationsAssembly(typeof(PremiumDbContextFactory).Assembly.FullName));


            return new PremiumDbContext(builder.Options);
        }
    }
}
