using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PremiumCalculator.Services.Core;
using PremiumCalculator.ViewModels.Home;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiumCalculator.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PremiumController : ControllerBase
    {
        private IPremiumService _premiumService;
        private ILogger _logger;

        public PremiumController(IPremiumService premiumService, ILogger<PremiumController> logger)
        {
            _premiumService = premiumService;
            _logger = logger;
        }

        // POST api/<PremiumController>
        [HttpPost]
        public HomePageResponseViewModel Post([FromBody] HomePageRequestViewModel viewModel)
        {
            Dictionary<string, string> errors;
            HomePageResponseViewModel responseViewModel = new HomePageResponseViewModel();
            try
            {
                errors = viewModel.Validate();

                if (errors.Count > 0)
                {
                    responseViewModel.Errors = errors;
                    responseViewModel.MonthlyPremium = 0;
                }
                else
                {
                    responseViewModel.Errors = errors;
                    responseViewModel.MonthlyPremium = Math.Round(_premiumService.CalculateDeathPremium(viewModel.SumInsured,
                                                                                                        viewModel.Age,
                                                                                                        viewModel.OccupationId)
                                                                , 2);
                }
            }
            catch (Exception exception)
            {
                responseViewModel.Errors.Add("", "An error occured while processing your request");
                responseViewModel.MonthlyPremium = 0;
                _logger.LogError(exception, exception.Message);
            }

            return responseViewModel;
        }
    }
}
