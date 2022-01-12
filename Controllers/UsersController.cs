using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models;


namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase {

        UserServices userServices;
        public UsersController() {
            userServices = new UserServices();
        }


        public IActionResult GetAllUsers() {
            IEnumerable<User> AllUsers = userServices.GetUsers();

            return Ok(AllUsers);
        }

    }

}