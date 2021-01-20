using PremiumCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.BLL
{
    public class BizDeathPremium
    {
        
        public double Calculate(double sumInsured, short age, Occupation occupation)
        {
            //Monthly Death Premium = (Death Cover amount * Occupation Rating Factor * Age) /1000 * 12 
            return (sumInsured * occupation.Rating.Factor * age) / (1000 * 12);
        }
    }
}
