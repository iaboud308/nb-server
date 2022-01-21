using server.Models;


namespace server.Services {
    public class UserServices {

        BankContext context;
        FinanceService financeService;

        public UserServices() {
            context = new BankContext();
            financeService = new FinanceService();
        }

        public string EncryptPassword(string Password) {

            return Password;
        }


        public User MapUserToDto(UserDto userDto) {

            User user = new User();
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.EncryptedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            user.Balance = 5000;

            return user;
        }

        public void RegisterUser(UserDto userDto) {

            
            User user = MapUserToDto(userDto);
            context.Add(user);
            context.SaveChanges();
            
            financeService.SetInitialBalance(user.Id);
        }

        public bool Login(LoginUser loginUser) {
            
            try {
                User user = context.Users
                                .Where(u => u.Email.Equals(loginUser.Email))
                                .FirstOrDefault();

                Console.WriteLine(user.FirstName);

                bool userIsValid = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.EncryptedPassword);

                Console.WriteLine(userIsValid);
                return userIsValid;

            } catch (Exception e) {

                Console.WriteLine(e);
                return false;

            }

        }


        public User GetUser(LoginUser loginUser) {
            
            User user = context.Users
                            .Where(u => u.Email.Equals(loginUser.Email))
                            .FirstOrDefault();

            return user;

        }

        public IEnumerable<User> GetUsers() {

            IEnumerable<User> users = context.Users.ToList<User>();

            return users;
        }

        public User GetUserById(int Id) {
            User user = context.Users
                            .Where(u => u.Id == Id)
                            .FirstOrDefault();
            
            return user;
        }
    }
}