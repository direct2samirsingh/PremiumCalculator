using Microsoft.Extensions.DependencyInjection;
using PremiumCalculator.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPremiumCalculatorServices(this IServiceCollection services)
        {
            services.AddScoped<IPremiumService, PremiumService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IOccupationService, OccupationService>();
            return services;
        }
    }
}
