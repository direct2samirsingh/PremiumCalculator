﻿using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Services.Core;
using PremiumCalculator.ViewModels.Home;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiumCalculator.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private IPremiumService _premiumService;

        public PremiumController(IPremiumService premiumService)
        {
            _premiumService = premiumService;
        }

        // POST api/<PremiumController>
        [HttpPost]
        public HomePageResponseViewModel Post([FromBody] HomePageRequestViewModel viewModel)
        {
            return new HomePageResponseViewModel() { 
                MonthlyPremium = _premiumService.CalculateDeathPremium(viewModel.SumInsured, 
                                                    viewModel.Age, 
                                                    viewModel.OccupationId) };
        }
    }
}
