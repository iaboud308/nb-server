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

            string FakeToken = $"ThisIsAFakeToken{loginUser.Email}";
            
            bool userIsValid = userServices.Login(loginUser);

            if (userIsValid) {
                return Ok(new { token = FakeToken });
            } else {
                return Ok(userIsValid);
            }

        }

    }


}