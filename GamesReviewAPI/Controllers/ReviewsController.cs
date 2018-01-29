using GamesReviewAPI.DataStores;
using Microsoft.AspNetCore.Mvc;

namespace GamesReviewAPI.Controllers
{
   // [Produces("application/json")]
    [Route("api/Reviews")]
    public class ReviewsController : Controller
    {
        // GET: api/Reviews
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(ReviewsDataStore.Current.Reviews);
        }

    }
}
