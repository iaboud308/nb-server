using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models;

namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class LoginController : ControllerBase {

        UserServices userServices;
        public LoginController() {
            userServices = new UserServices();
        }


        [HttpPost]
        public IActionResult Login(LoginUser loginUser) {

            bool userIsValid = userServices.Login(loginUser);

            if (userIsValid) {
                User user = userServices.GetUser(loginUser);
                return Ok(user);
            } else {
                return Ok(userIsValid);
            }

        }

    }


}