namespace Practics.Trucking.Application.Inputs.User
{
    public class UserTryLoginInput
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public UserTryLoginInput(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public UserTryLoginInput() { }
    }
}