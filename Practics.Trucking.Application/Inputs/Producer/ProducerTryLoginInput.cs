using Practics.Trucking.Application.Inputs.User;

namespace Practics.Trucking.Application.Inputs.Producer
{
    public class ProducerTryLoginInput : UserTryLoginInput
    {
        public ProducerTryLoginInput(string login, string password): base(login, password)
        {

        }
    }
}