using System.ComponentModel.DataAnnotations.Schema;

namespace PremiumCalculator.Models
{
    public class Occupation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OccupationID { get; set; }
        public string Name { get; set; }

        public Rating Rating { get; set; }
    }
}