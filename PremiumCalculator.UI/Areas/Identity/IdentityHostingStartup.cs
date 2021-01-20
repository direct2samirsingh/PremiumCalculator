using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PremiumCalculator.UI.Data;
using PremiumCalculator.UI.Models;

[assembly: HostingStartup(typeof(PremiumCalculator.UI.Areas.Identity.IdentityHostingStartup))]
namespace PremiumCalculator.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}