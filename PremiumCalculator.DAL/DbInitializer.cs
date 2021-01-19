using Microsoft.EntityFrameworkCore;
using PremiumCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.DAL
{
    public class DbInitializer
    {
        public static void Initialize(PremiumDbContext context)
        {
            context.Database.Migrate();

            // Look for any ratings.
            if (context.Ratings.Any())
            {
                return;   // DB has been seeded
            }

            var ratings = new List<Rating>()
            {
                new Rating{RatingID=1, Name="Professional ",Factor=1.00},
                new Rating{RatingID=2, Name="White Collar ",Factor=1.25},
                new Rating{RatingID=3, Name="Light Manual ",Factor=1.50},
                new Rating{RatingID=4, Name="Heavy Manual ",Factor=1.75}
            };
            foreach (Rating rating in ratings)
            {
                context.Ratings.Add(rating);
            }

            var occupations = new Occupation[]
            {
                new Occupation{OccupationID=1,Name="Cleaner", Rating = ratings.FirstOrDefault(x=>x.RatingID==3)},
                new Occupation{OccupationID=2,Name="Doctor", Rating = ratings.FirstOrDefault(x=>x.RatingID==1) },
                new Occupation{OccupationID=3,Name="Author", Rating = ratings.FirstOrDefault(x=>x.RatingID==2) },
                new Occupation{OccupationID=4,Name="Farmer", Rating = ratings.FirstOrDefault(x=>x.RatingID==4) },
                new Occupation{OccupationID=5,Name="Mechanic", Rating = ratings.FirstOrDefault(x=>x.RatingID==4) },
                new Occupation{OccupationID=6,Name="Florist", Rating = ratings.FirstOrDefault(x=>x.RatingID==3) }
            };
            foreach (Occupation occupation in occupations)
            {
                context.Occupations.Add(occupation);
            }
            context.SaveChanges();

        }

    }
}
