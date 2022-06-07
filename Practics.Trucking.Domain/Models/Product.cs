using System.Collections.Generic;
using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        public List<Specification> Specifications { get; set; }

        public int? OrderId { get; set; }
        
        public int? ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}