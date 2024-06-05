using Microsoft.AspNetCore.Mvc;

namespace CommunityServiceAPI.Controllers
{
    [Route("api/c/[controller]")]
    public class PlatformsController : Controller
    {
        public PlatformsController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbout POST # Community Service");

            return Ok("Inbound test from Community Controller");
        }
    }
}
