using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Domain.Models
{
    public class UserInfo : Entity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        
        public string Email { get; set; }
        public string PassportSerialNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
    }
}