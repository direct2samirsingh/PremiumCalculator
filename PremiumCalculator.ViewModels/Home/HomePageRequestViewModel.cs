using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.ViewModels.Home
{
    public class HomePageRequestViewModel
    {
        public short Age { get; set; }
        public string DateOfBirth { get; set; }
        public double SumInsured { get; set; }
        public int OccupationId { get; set; }
    }
}
