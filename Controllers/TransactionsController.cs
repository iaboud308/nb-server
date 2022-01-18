using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class TransactionController : ControllerBase {
        
        FinanceService financeService;

        public TransactionController() {
            financeService = new FinanceService();
        }


    
        [HttpGet]
        public IActionResult GetAllTransactions(int Id) {

            IEnumerable<TransactionDto> Transactions = financeService.GetTransactionsByUserId(Id);

            return Ok(Transactions);
        }
    }

}