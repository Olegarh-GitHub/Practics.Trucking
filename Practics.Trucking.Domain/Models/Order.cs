using System;
using System.Collections.Generic;
using System.Linq;
using Practics.Trucking.Domain.Enums;
using Practics.Trucking.Domain.Models.Base;

namespace Practics.Trucking.Domain.Models
{
    public class Order : Entity
    {
        public decimal TotalPrice => Products.Sum(product => product.Price);
        public int TotalCount => Products.Count;
        public List<Product> Products { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DeliveryStatus Status { get; set; }

        public DateTime OrderTime { get; set; }
    }
}