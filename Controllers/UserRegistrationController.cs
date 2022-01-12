using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;


namespace server.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class UserRegistrationController : ControllerBase {


        UserServices userServices;

        public UserRegistrationController() {
            userServices = new UserServices();
        }
         



        [HttpPost]
        public IActionResult RegisterUser(UserDto userDto) {

            Console.WriteLine('1');
            userServices.RegisterUser(userDto);
            return Ok();
        }


    }
}