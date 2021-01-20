using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiumCalculator.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeathPremiumController : ControllerBase
    {
        // GET: api/DeathPremium
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/DeathPremium/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/DeathPremium
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
