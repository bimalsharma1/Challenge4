using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace FlipFlop.Controllers
{
    [Route("api/FlipFlop")]
    public class FlipFlopController : Controller
    {

        [HttpGet()]
        public ActionResult Get()
        {
            return Ok(Classes.FlipFlop.DisplayFlipFlop());
        }

       

        
    }
}