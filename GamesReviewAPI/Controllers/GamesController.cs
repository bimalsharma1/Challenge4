using System.Linq;
using GamesReviewAPI.DataStores;
using GamesReviewAPI.Interfaces;
using GamesReviewAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesReviewAPI.Controllers
{
   // [Produces("application/json")]
    [Route("api/Games")]
    public class GamesController : Controller
    {
        private readonly IGameReviews _gamesReviews;

        public GamesController(IGameReviews gamesReviews)
        {
            _gamesReviews = gamesReviews;
        }

        // GET: api/Games
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gamesReviews.GetGamesAndReviews());//Classes.GamesReviews.GetGamesAndReviews()
        }

        //// POST: api/Games
        [HttpPost("{code}/{rating}")]
        public IActionResult Post(int code, int rating)// --from body is the alternative method  :  (Review reviewItem)//[FromBody]
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
