using Practics.Trucking.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practics.Trucking.Controls
{
    public partial class Specifications : FlowLayoutPanel
    {
        private readonly List<Specification> _specifications = new();

        public Specifications(List<Specification> specifications)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Dock = DockStyle.Fill;

            Init();

            InitializeComponent();
            _specifications = specifications;
        }

        private void Init()
        {
            foreach (var specification in _specifications)
            {
                var panel = new FlowLayoutPanel()
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Dock = DockStyle.Fill
                };

                var label = new Label()
                {
                    AutoSize = true,
                    Text = $"{specification.Name}: {specification.Value}"
                };

                panel.Controls.Add(label);
                Controls.Add(panel);
            }   
        }
    }
}
