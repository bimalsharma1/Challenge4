using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesReviewAPI.DataStores;
using GamesReviewAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesReviewAPI.Controllers
{
   // [Produces("application/json")]
    [Route("api/Games")]
    public class GamesController : Controller
    {
        // GET: api/Games
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Classes.GamesReviews.GetGamesAndReviews());
        }

        //  [HttpGet("{id}", Name = "Get")]

        //[HttpGet(Name = "Get")]

        //// GET: api/Games/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Games
        [HttpPost("{code}/{rating}")]
        public IActionResult Post(int code, int rating)//(Review reviewItem)//[FromBody]
        {
            Review reviewItem = new Review
            {
                Code = code,
                Rating = rating
            };
            ReviewsDataStore.Current.Reviews.Add(reviewItem);
            return Ok(ReviewsDataStore.Current.Reviews);
        }

        //// PUT: api/Games/5
        [HttpPut("{code}/{description}")]
        public IActionResult Put(int code, string description)
        {
            if(string.IsNullOrWhiteSpace(description))
            {
                return BadRequest("no data exists");
            }
                GamesDataStore.Current.Games
                                .Where(g => g.Code == code).ToList()
                                .ForEach(c => c.Description = description);
                return Ok(description);
        } 
    }
}
