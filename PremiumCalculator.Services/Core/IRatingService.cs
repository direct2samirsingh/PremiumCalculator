using PremiumCalculator.Models;
using System.Collections.Generic;

namespace PremiumCalculator.Services.Core
{
    public interface IRatingService
    {
        List<Rating> GetAll();
        Rating GetById(int id);
    }
}