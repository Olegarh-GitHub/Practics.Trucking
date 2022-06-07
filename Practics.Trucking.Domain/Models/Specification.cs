using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Domain.Models
{
    public class Specification : Entity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}