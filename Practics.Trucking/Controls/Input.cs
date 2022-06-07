using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practics.Trucking.Controls
{
    public partial class Input : TableLayoutPanel
    {
        private Label _label;
        private TextBox _textBox;
        private FlowLayoutPanel _panel;

        private string _name;
        private bool _isRequired;

        public Input(string name, bool isRequired = false)
        {
            _name = name;
            _isRequired = isRequired;

            _label = new Label()
            {
                AutoSize = true,
                MinimumSize = new Size(150, 10),             
                Text = _name,
                Dock = DockStyle.Fill,
            };

            _textBox = new TextBox()
            {
                AutoSize = true,
                MinimumSize = new Size(150, 25),
                MaxLength = 16,
                Dock = DockStyle.Fill,
            };

            _panel = new FlowLayoutPanel()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(150, 50),
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
                BackColor = Color.Azure
            };

            RowCount = 1;
            ColumnCount = 1;
            Dock = DockStyle.Fill;
            MinimumSize = new Size(150, 50);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            _panel.Controls.Add(_label);
            _panel.Controls.Add(_textBox);

            Controls.Add(_panel);

            InitializeComponent();
        }

        public bool IsRequired => _isRequired;

        public new void Refresh()
        {
            _panel.Refresh();
            _label.Refresh();
            _textBox.Refresh();
            base.Refresh();
        }

        public string Label
        {
            get => _name;
            set 
            { 
                _name = value;
                _label.Text = _name;

                Refresh();
            }
        }

        public string Value
        {
            get => string.IsNullOrEmpty(_textBox.Text) ? null : _textBox.Text;
            set => _textBox.Text = value;
        }
    }
}
