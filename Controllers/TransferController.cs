using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Models;

namespace server.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class TransferController : ControllerBase {

        FinanceService financeService;
        UserServices userServices;

        public TransferController() {
            userServices = new UserServices();
            financeService = new FinanceService(new BankContext(), userServices);
        }

        [HttpPost]
        public IActionResult Transfer(Transfer transfer) {
            
            TransferState transferState = financeService.Transfer(transfer);

            if(transferState == TransferState.InsufficientFunds) {
                return BadRequest("Insufficient Funds");
            }

            if(transferState == TransferState.InvalidUser) {
                return BadRequest("Invalid User");
            }

            User user = userServices.GetUserById(transfer.From);
            IEnumerable<TransactionDto> transactions = financeService.GetTransactionsByUserId(user.Id);

            UserAndTransactions FullUser = new UserAndTransactions();
            FullUser.User = user;
            FullUser.Transactions = transactions;

            return Ok(FullUser);
        }


    }
}