using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.Trucking.Application.Inputs.Order
{
    public class OfferOrderInput
    {
        public int UserId { get; set; }
        public List<int> Products { get; set; }

        public OfferOrderInput(int userId, List<int> products)
        {
            UserId = userId;
            Products = products;
        }
    }
}
