using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;


namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class DepositController : ControllerBase {

        FinanceService financeService;

        public DepositController() {
            financeService = new FinanceService();
        }

        public IActionResult Deposit(Deposit deposit) {

            bool depositProcess = financeService.Deposit(deposit);

            if(depositProcess == false) {
                return BadRequest();
            }

            return Ok();
        }


    }
}