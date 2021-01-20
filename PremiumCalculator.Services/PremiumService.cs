using PremiumCalculator.BLL;
using PremiumCalculator.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Services
{
    public class PremiumService : IPremiumService
    {
        private IOccupationService _occupationService;
        public PremiumService(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        public double CalculateDeathPremium(double sumInsured, short age, int occupationId)
        {
            return new BizDeathPremium().Calculate(sumInsured, age, _occupationService.GetById(occupationId));
        }
    }
}
