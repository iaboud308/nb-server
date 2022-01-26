using Microsoft.AspNetCore.Mvc;


namespace server.Controllers {


    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase {

        [HttpGet]
        public IActionResult Home() {
            return Ok("Welcome...");
        }

    }
}
