


namespace server.Models {
    public class UserNoPassword {

        public UserNoPassword(int Id, string FirstName, string LastName, string Email) {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}