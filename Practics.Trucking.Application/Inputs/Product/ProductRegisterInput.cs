using System.Collections.Generic;
using Practics.Trucking.Application.Inputs.Specification;

namespace Practics.Trucking.Application.Inputs.Product
{
    public class ProductRegisterInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        public int? ProducerId { get; set; }
        public List<SpecificationRegisterInput> Specifications { get; set; }

        public ProductRegisterInput() { }
        public ProductRegisterInput(string name, string description, decimal price, int? producerId, List<SpecificationRegisterInput> spesc) 
        {
            Name = name;
            Description = description;
            Price = price;
            ProducerId = producerId;
            Specifications = spesc;
        }
    }
}