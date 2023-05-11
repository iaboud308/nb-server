using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models;

namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class LoginController : ControllerBase {

        private readonly UserServices _userServices;
        private readonly FinanceService _financeService;


        public LoginController(FinanceService financeService, UserServices userServices) {
            _userServices = userServices;
            _financeService = financeService;
        }


        [HttpPost]
        public IActionResult Login(LoginUser loginUser) {

            bool userIsValid = _userServices.Login(loginUser);

            if (userIsValid) {
                User user = _userServices.GetUser(loginUser);
                IEnumerable<TransactionDto> Transactions = _financeService.GetTransactionsByUserId(user.Id);
                UserAndTransactions FullUser = new UserAndTransactions();
                FullUser.User = user;
                FullUser.Transactions = Transactions;

                return Ok(FullUser);
            } else {
                return Ok(userIsValid);
            }

        }

    }


}