using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Domain.Models
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        
        public UserInfo UserInfo { get; set; }
        public int UserInfoId { get; set; }
    }
}