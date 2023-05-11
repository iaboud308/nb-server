using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class TransactionController : ControllerBase {

        private readonly FinanceService _financeService;



        public TransactionController(FinanceService financeService) {
            _financeService = financeService;
        }


    
        [HttpGet]
        public IActionResult GetAllTransactions(int Id) {

            IEnumerable<TransactionDto> Transactions = _financeService.GetTransactionsByUserId(Id);

            return Ok(Transactions);
        }
    }

}