using PremiumCalculator.DAL;
using PremiumCalculator.Models;
using PremiumCalculator.Services.Core;
using System.Collections.Generic;
using System.Linq;

namespace PremiumCalculator.Services
{
    public class RatingService : IRatingService
    {
        PremiumDbContext _premiumDbContext;

        public RatingService(PremiumDbContext premiumDbContext)
        {
            _premiumDbContext = premiumDbContext;
        }

        public List<Rating> GetAll()
        {
            return _premiumDbContext.Ratings.ToList();
        }

        public Rating GetById(int id)
        {
            return _premiumDbContext.Ratings.FirstOrDefault(x => x.RatingID == id);
        }
    }
}
