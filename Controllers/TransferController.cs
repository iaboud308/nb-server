using Microsoft.AspNetCore.Mvc;
using server.Services;


namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class TransferController : ControllerBase {

        FinanceService financeService;

        public TransferController() {
            financeService = new FinanceService();
        }

        [HttpPost]
        public IActionResult Transfer(Transfer transfer) {
            
            financeService.Transfer(transfer);

            return Ok();
        }


    }
}