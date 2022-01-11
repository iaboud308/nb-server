using Microsoft.AspNetCore.Mvc;


namespace server.Controllers {


    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase {

        public IActionResult Home() {
            return Ok("Welcome...");
        }

    }
}