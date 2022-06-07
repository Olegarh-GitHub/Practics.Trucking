using Practics.Trucking.Application.Inputs.User;

namespace Practics.Trucking.Application.Inputs.Producer
{
    public class ProducerRegisterInput : UserRegisterInput
    {
        public string INN { get; set; }
        public string EGRIP { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }

        public ProducerRegisterInput() : base() {  }
        public ProducerRegisterInput
        (
            string login,
            string password,
            string title,
            string description,
            string surname = null,
            string name = null,
            string initials = null,
            string email = null,
            string passportSerialNumber = null,
            string passportNumber = null,
            string address = null,
            string inn = null,
            string egrn = null
        ) : base(login, password, surname, name, initials, email, passportSerialNumber, passportNumber, address) 
        {
            Title = title;
            Description = description;
            EGRIP = egrn;
            INN = inn;
        }
    }
}