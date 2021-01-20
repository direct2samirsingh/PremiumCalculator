using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculator.ViewModels.Home
{
    public class HomePageRequestViewModel
    {
        public string Name { get; set; }
        public short Age { get; set; }
        public string DateOfBirth { get; set; }
        public double SumInsured { get; set; }
        public int OccupationId { get; set; }

        public Dictionary<string, string> Validate() {
            Dictionary<string, string> Errors = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(Name))
            {
                Errors.Add(nameof(Name).ToLower(), "Please enter name");
            }

            DateTime dob = DateTime.MinValue;
            DateTime.TryParse(DateOfBirth, out dob);
            if (dob > DateTime.Now || dob < DateTime.Now.AddYears(-130))
            {
                Errors.Add(nameof(DateOfBirth).ToLower(), "Date of Birth must be within past 130 years");
            }

            if (Age < 1 || Age > 130) {
                Errors.Add(nameof(Age).ToLower(), "Please enter age between 1-130");
            }

            if (SumInsured <= 0)
            {
                Errors.Add(nameof(SumInsured).ToLower(), "Sum Insured must be greater than 0");
            }

            return Errors;
        }
    }
}
