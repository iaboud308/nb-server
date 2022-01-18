using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models;

namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class LoginController : ControllerBase {

        UserServices userServices;
        FinanceService financeService;
        public LoginController() {
            userServices = new UserServices();
            financeService = new FinanceService();
        }


        [HttpPost]
        public IActionResult Login(LoginUser loginUser) {

            bool userIsValid = userServices.Login(loginUser);

            if (userIsValid) {
                User user = userServices.GetUser(loginUser);
                IEnumerable<TransactionDto> Transactions = financeService.GetTransactionsByUserId(user.Id);
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