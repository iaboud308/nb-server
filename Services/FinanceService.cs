
using server.Models;

namespace server.Services {

    public class FinanceService {

        BankContext context;
        public FinanceService() {
            context = new BankContext();
        }


        public void Transfer(Transfer transfer) {
            User From = context.Users.Where(u => u.Id == transfer.From).FirstOrDefault();
            User To = context.Users.Where(u => u.Id == transfer.To).FirstOrDefault();


            if (From == null || To == null || transfer.Amount > From.Balance ) {
                Console.WriteLine("Insufficient Funds for this transfer, or one of the users does not exist");
                return;
            }

            From.Balance = From.Balance - transfer.Amount;
            To.Balance = To.Balance + transfer.Amount;
            
            context.Update(From);
            context.Update(To);
            context.SaveChanges();

        }



    }

}