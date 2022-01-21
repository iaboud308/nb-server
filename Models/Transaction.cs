


namespace server.Models {

    public class Transaction {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public float FromNewBalance { get; set; }
        public float ToNewBalance { get; set; }
    }
}