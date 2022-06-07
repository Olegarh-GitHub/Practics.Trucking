using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Domain.Models
{
    public class ProducerInfo : Entity
    {
        public string INN { get; set; }
        public string EGRIP { get; set; }
    }
}