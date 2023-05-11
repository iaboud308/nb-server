using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models;

namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class TransferController : ControllerBase {
       
        private readonly UserServices _userServices;
        private readonly FinanceService _financeService;


        public TransferController(UserServices userServices, FinanceService financeService) {
            _userServices = userServices;
            _financeService = financeService;
        }
        

        [HttpPost]
        public IActionResult Transfer(Transfer transfer) {
            
            TransferState transferState = _financeService.Transfer(transfer);

            if(transferState == TransferState.InsufficientFunds) {
                return BadRequest("Insufficient Funds");
            }

            if(transferState == TransferState.InvalidUser) {
                return BadRequest("Invalid User");
            }

            User user = _userServices.GetUserById(transfer.From);
            IEnumerable<TransactionDto> transactions = _financeService.GetTransactionsByUserId(user.Id);

            UserAndTransactions FullUser = new UserAndTransactions();
            FullUser.User = user;
            FullUser.Transactions = transactions;

            return Ok(FullUser);
        }


    }
}