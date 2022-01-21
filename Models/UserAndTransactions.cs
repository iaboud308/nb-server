using System.Collections.Generic;



namespace server.Models {
    public class UserAndTransactions {

        public User User { get; set; }
        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}