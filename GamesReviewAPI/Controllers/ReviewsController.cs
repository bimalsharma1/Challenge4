using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesReviewAPI.DataStores;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Reviews/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Reviews
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
