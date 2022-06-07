using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.Trucking.Application.Inputs.Order
{
    public class ApproveOrderInput
    {
        public List<int> Orders { get; set; }
        public ApproveOrderInput(List<int> orders)
        {
            Orders = orders;
        }
    }
}
