using Microsoft.AspNetCore.Mvc;
using server.Models;
using System.Collections;

namespace server.Services {

    public class FinanceService {

        BankContext context;
        public FinanceService() {
            context = new BankContext();
        }


        public TransferState Transfer(Transfer transfer) {
            User From = context.Users.Where(u => u.Id == transfer.From).FirstOrDefault();
            User To = context.Users.Where(u => u.Email == transfer.To).FirstOrDefault();


            if (transfer.Amount > From.Balance ) {
                Console.WriteLine("Insufficient Funds");
                return TransferState.InsufficientFunds;
            }

            if (From == null || To == null) {
                Console.WriteLine("Invalid User");
                return TransferState.InvalidUser;
            }

            From.Balance = From.Balance - transfer.Amount;
            To.Balance = To.Balance + transfer.Amount;
            
            context.Update(From);
            context.Update(To);
            context.SaveChanges();

            SaveTransactionFromTransfer(From.Id, To.Id, transfer.Amount, To.Balance, From.Balance);

            return TransferState.Success;

        }

        public void SaveTransactionFromTransfer(int From, int To, int Amount, float ToNewBalance, float FromNewBalance) {


            Console.WriteLine(Amount);

            Transaction transaction = new Transaction();

            transaction.FromId = From;
            transaction.ToId = To;
            transaction.ToNewBalance = ToNewBalance;
            transaction.FromNewBalance = FromNewBalance;
            transaction.Amount = Amount;
            transaction.Description = "Transfer";
            transaction.Date = DateTime.Now;

            context.Transactions.Add(transaction);
            context.SaveChanges();

        }



        public IEnumerable<TransactionDto> GetTransactionsByUserId(int UserId) {

            List<Transaction> FromTransactions =  context.Transactions.Where(t => t.FromId == UserId).ToList();
            List<Transaction> ToTransactions = context.Transactions.Where(t => t.ToId == UserId).ToList();
            
            List<TransactionDto> TotalTransactions = new List<TransactionDto>();

            for(int i = 0; i < FromTransactions.Count(); i++) {
                Transaction cT = FromTransactions[i];
                User user = context.Users.Where<User>(u => u.Id == cT.ToId).FirstOrDefault();
                TransactionDto NewTransaction = new TransactionDto(cT.Id, cT.Amount, cT.Description, cT.Date, cT.FromNewBalance, TransactionState.Withdraw);
                NewTransaction.User = new UserNoPassword(user.Id, user.FirstName, user.LastName, user.Email);
                TotalTransactions.Add(NewTransaction);
            }

            for(int i = 0; i < ToTransactions.Count(); i++) {
                Transaction cT = ToTransactions[i];
                TransactionDto NewTransaction = new TransactionDto(cT.Id, cT.Amount, cT.Description, cT.Date, cT.ToNewBalance, TransactionState.Deposit);
                User user = context.Users.Where<User>(u => u.Id == cT.FromId).FirstOrDefault();
                NewTransaction.User = new UserNoPassword(user.Id, user.FirstName, user.LastName, user.Email);
                TotalTransactions.Add(NewTransaction);
            }

            var OrderedTransactions = TotalTransactions.OrderByDescending(TDto => TDto.Date);
            return OrderedTransactions;

        }

        // public IEnumerable TestMethod(int Id) {

        //     var query = from transactions in context.Set<Transaction>()
        //                 join user in context.Set<User>()
        //                     on transactions.ToId equals user.Id
        //                 select new { transactions, user };

            
        //     var something = Enumerable.ToList(query);
        //     return something;

        // }
    

        public void SetInitialBalance(int UserId) {
            Transaction transaction = new Transaction();
            transaction.FromId = 5;
            transaction.ToId = UserId;
            transaction.Amount = 5000;
            transaction.Description = "Initial Deposit";
            transaction.ToNewBalance = 5000;
            transaction.Date = DateTime.Now;

            context.Transactions.Add(transaction);
            context.SaveChanges();

        }


        public bool Withdraw(Withdraw withdraw) {
            User user = context.Users.Where<User>(u => u.Id == withdraw.UserId).FirstOrDefault();
            
            if(withdraw.Amount > user.Balance) {
                Console.WriteLine("Get a job");
                return false;
            }

            user.Balance = user.Balance - withdraw.Amount;
            context.Users.Update(user);
            context.SaveChanges();
            return true;
        }

        public bool Deposit(Deposit deposit) {

            User user = context.Users.Where(u => u.Id == deposit.UserId).FirstOrDefault();
            user.Balance = user.Balance + deposit.Amount;
            context.Users.Update(user);
            context.SaveChanges();

            return true;
        }



    }

}