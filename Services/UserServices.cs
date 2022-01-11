using server.Models;


namespace server.Services {
    public class UserServices {

        BankContext context;
        public UserServices() {
            context = new BankContext();
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
            user.Balance = 0;

            return user;
        }

        public void RegisterUser(UserDto userDto) {
            
            User user = MapUserToDto(userDto);
            context.Add(user);
            context.SaveChanges();
            
        }

        public bool Login(LoginUser loginUser) {
            
            User user = context.Users
                            .Where(u => u.Email.Equals(loginUser.Email))
                            .FirstOrDefault();

            bool userIsValid = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.EncryptedPassword);

            Console.WriteLine(userIsValid);
            return userIsValid;

        }
    }
}