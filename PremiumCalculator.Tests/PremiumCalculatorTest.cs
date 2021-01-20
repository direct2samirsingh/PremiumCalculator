using Microsoft.VisualStudio.TestTools.UnitTesting;
using PremiumCalculator.BLL;
using PremiumCalculator.Models;
using PremiumCalculator.ViewModels.Home;
using System;

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

            Assert.AreEqual<double>(monthlyPremium, 312.50);
        }

        [TestMethod]
        public void EnsureThatNameIsProvidedInHomeRequestViewModel()
        {
            HomePageRequestViewModel model = new HomePageRequestViewModel() { Name = "", 
                DateOfBirth = DateTime.Now.ToShortDateString(),
                Age = 35,
                OccupationId = 5,
                SumInsured = 100_000
            };

            var errors = model.Validate();

            Assert.IsTrue(errors.Count == 1);
        }

        [TestMethod]
        public void EnsureThatDateOfBirthIsWithinRangeInHomeRequestViewModel()
        {
            HomePageRequestViewModel model = new HomePageRequestViewModel()
            {
                Name = "Sam",
                DateOfBirth = new DateTime(1850, 10, 01).ToShortDateString(),
                Age = 35,
                OccupationId = 5,
                SumInsured = 100_000
            };

            var errors = model.Validate();

            Assert.IsTrue(errors.Count == 1);
        }

        [TestMethod]
        public void EnsureThatSumInsuredIsGreaterThanZeroInHomeRequestViewModel()
        {
            HomePageRequestViewModel model = new HomePageRequestViewModel()
            {
                Name = "Sam",
                DateOfBirth = DateTime.Now.ToShortDateString(),
                Age = 35,
                OccupationId = 5,
                SumInsured = 0
            };

            var errors = model.Validate();

            Assert.IsTrue(errors.Count == 1);
        }

        [TestMethod]
        public void EnsureThatAgeIsWithinRangeInHomeRequestViewModel()
        {
            HomePageRequestViewModel model = new HomePageRequestViewModel()
            {
                Name = "Sam",
                DateOfBirth = DateTime.Now.ToShortDateString(),
                Age = 135,
                OccupationId = 5,
                SumInsured = 100_000
            };

            var errors = model.Validate();

            Assert.IsTrue(errors.Count == 1);
        }
    }
}
