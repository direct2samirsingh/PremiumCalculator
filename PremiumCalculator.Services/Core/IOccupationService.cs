using PremiumCalculator.Models;
using System.Collections.Generic;

namespace PremiumCalculator.Services.Core
{
    public interface IOccupationService
    {
        List<Occupation> GetAll();
        Occupation GetById(int id);
    }
}