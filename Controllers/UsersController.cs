using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models;


namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase {
        private readonly UserServices _userServices;


        public UsersController(UserServices userServices) {
            _userServices = userServices;
        }



        [HttpGet]
        public IActionResult GetAllUsers() {
            IEnumerable<User> AllUsers = _userServices.GetUsers();
            return Ok(AllUsers);
        }

    }

}