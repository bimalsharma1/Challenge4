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
            return Ok(DisplayFlipFlop());
        }

        private string DisplayFlipFlop()
        {
            var flipFlopData = "";
            var maxNum = 100;
            for(int i=1; i <= maxNum; i++)
            {
                flipFlopData += Classes.FlipFlop.DisplayValue(i);
                if (i != maxNum)
                {
                    flipFlopData += ", ";
                }
            }

            return flipFlopData;
        }

        
    }
}