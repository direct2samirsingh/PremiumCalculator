using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Services.Core;
using PremiumCalculator.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiumCalculator.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private IOccupationService _occupationService;

        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService;    
        }

        // GET: api/Occupation
        [HttpGet("GetSelectList")]
        public IEnumerable<SelectItemViewModel> GetSelectList() {
            return _occupationService.GetAll().Select(x => new SelectItemViewModel() { Id = x.OccupationID, Name = x.Name });
        }

    }
}
