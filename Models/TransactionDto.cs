

namespace server.Models {

    public enum TransactionState {
        Deposit,
        Withdraw

    }

    public class TransactionDto {

        public TransactionDto(int Id, float Amount, string Description, DateTime Date, float NewBalance, TransactionState TransactionState) {
            this.Id = Id;
            this.NewBalance = NewBalance;
            this.State = TransactionState;
            this.Amount = Amount;
            this.Description = Description;
            this.Date = Date;

        }


        public int Id { get; set; }
        public UserNoPassword User { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public TransactionState State { get; set; }
        public float NewBalance { get; set; }
    }
}