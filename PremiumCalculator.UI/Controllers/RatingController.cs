using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Models;
using PremiumCalculator.Services.Core;
using System.Collections.Generic;

namespace PremiumCalculator.UI.Controllers
{
    public class RatingController : Controller
    {
        private IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        // GET: api/Rating
        [HttpGet]
        public IEnumerable<Rating> Get()
        {
            return _ratingService.GetAll();
        }

        // GET api/Rating/5
        [HttpGet("{id}")]
        public Rating Get(int ratingId)
        {
            return _ratingService.GetById(ratingId);
        }

        // POST api/Rating
        [HttpPost]
        public void Post([FromBody] Rating rating)
        {
        }
    }
}
