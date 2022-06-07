using System.Collections.Generic;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Domain.Models
{
    public class Producer : Entity, IHaveTitle
    {
        public int UserId { get; set; }
        public User User { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        
        public ProducerInfo ProducerInfo { get; set; }
        public int ProducerInfoId { get; set; }
        
        public List<Product> Products { get; set; }
    }
}