using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;


namespace server.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class UserRegistrationController : ControllerBase {

        private readonly UserServices _userServices;
        private readonly FinanceService _financeServices;


        public UserRegistrationController(UserServices userServices, FinanceService financeService) {
            _userServices = userServices;
            _financeServices = financeService;
        }
         



        [HttpPost]
        public IActionResult RegisterUser(UserDto userDto) {

            _userServices.RegisterUser(userDto);
            return Ok(userDto);
        }


    }
}