using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.Trucking.Controls
{
    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string DisplayValue { get; set; }

        public ComboBoxItem(int id, string displayValue)
        {
            Id = id;
            DisplayValue = displayValue;
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}
