using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers {
    [ApiController]
    [Route("[Controller]")]
    public class WithdrawController : ControllerBase {

        FinanceService financeService;
        public WithdrawController() {
            financeService = new FinanceService();
        }


        [HttpPost]
        public IActionResult Withdraw(Withdraw withdraw) {

            bool process = financeService.Withdraw(withdraw);

            if(process == false) {
                return BadRequest();
            }

            return Ok();
        }
    }
}