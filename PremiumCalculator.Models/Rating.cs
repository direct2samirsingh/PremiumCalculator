using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PremiumCalculator.Models
{
    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RatingID { get; set; }
        public string Name { get; set; }
        public double Factor { get; set; }

        public ICollection<Occupation> Occupations { get; set; }
    }
}
