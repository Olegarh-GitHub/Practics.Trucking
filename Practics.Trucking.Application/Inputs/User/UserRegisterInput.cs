namespace Practics.Trucking.Application.Inputs.User
{
    public class UserRegisterInput
    {
        public string Login { get; set; }
        public string Password { get; set; }
        
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        
        public string Email { get; set; }
        public string PassportSerialNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }

        public UserRegisterInput() { }

        public UserRegisterInput
        (
            string login,
            string password,
            string surname = null,
            string name = null,
            string initials = null,
            string email = null,
            string passportSerialNumber = null,
            string passportNumber = null,
            string address = null
        )
        {
            Login = login;
            Password = password;
            Surname = surname;
            Name = name;
            Initials = initials;
            Email = email;
            PassportSerialNumber = passportSerialNumber;
            PassportNumber = passportNumber;
            Address = address;
        }
    }
}