using Microsoft.AspNetCore.Mvc;
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
        // GET: api/<OccupationController>
        [HttpGet]
        public IEnumerable<SelectItemViewModel> Get() {
            return new SelectItemViewModel[] { new SelectItemViewModel() { Id = 1, Name = "Value1"} , new SelectItemViewModel() { Id = 2, Name = "Value2" } };
        }

        // GET api/<OccupationController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<OccupationController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<OccupationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<OccupationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
