using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.ViewModels.Home
{
    public class HomePageResponseViewModel
    {
        public double MonthlyPremium { get; set; }
        public Dictionary<string, string> Errors  { get; set; }
    }
}
