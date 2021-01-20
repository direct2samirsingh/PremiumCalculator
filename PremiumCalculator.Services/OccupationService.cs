using Microsoft.EntityFrameworkCore;
using PremiumCalculator.DAL;
using PremiumCalculator.Models;
using PremiumCalculator.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.Services
{
    public class OccupationService : IOccupationService
    {
        PremiumDbContext _premiumDbContext;

        public OccupationService(PremiumDbContext premiumDbContext)
        {
            _premiumDbContext = premiumDbContext;
        }

        public List<Occupation> GetAll()
        {
            return _premiumDbContext.Occupations.ToList();
        }

        public Occupation GetById(int id)
        {
            return _premiumDbContext.Occupations.Include(occupation => occupation.Rating).FirstOrDefault(x => x.OccupationID == id);
        }
    }
}
