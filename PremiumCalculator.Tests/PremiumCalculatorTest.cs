using Microsoft.VisualStudio.TestTools.UnitTesting;
using PremiumCalculator.BLL;
using PremiumCalculator.Models;

namespace PremiumCalculator.Tests
{
    [TestClass]
    public class PremiumCalculatorTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void EnsureThatDeathPremiumIsComputedAsPerFormula()
        {
            BizDeathPremium bizDeathPremium = new BizDeathPremium();
            Rating rating = new Rating() { Factor = 1.5, Name = "Light Manual", RatingID = 3 };
            Occupation occupation = new Occupation() { Name = "Cleaner", OccupationID = 1, Rating = rating };

            double monthlyPremium = bizDeathPremium.Calculate(1_00_000, 25, occupation);

            Assert.AreEqual<double>(monthlyPremium, 45_000);
        }
    }
}
