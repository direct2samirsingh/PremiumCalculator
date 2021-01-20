using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiumCalculator.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        public PremiumController() {

        }


        // GET: api/<PremiumController>
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PremiumController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<PremiumController>
        [HttpPost]
        public HomePageResponseViewModel Post([FromBody] HomePageRequestViewModel viewModel) {
            return new HomePageResponseViewModel() { MonthlyPremium = 100 };
        }

        
        // PUT api/<PremiumController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<PremiumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
