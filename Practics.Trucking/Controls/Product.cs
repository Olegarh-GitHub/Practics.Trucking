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
    public partial class Product : FlowLayoutPanel
    {
        private readonly Control _parent;
        private readonly Domain.Models.Product _product;
        private readonly Specifications _specifications;

        private CheckBox _checkBox;

        public Product(Control parent, Domain.Models.Product product, bool checkBoxNeeded = true)
        {
            _parent = parent;
            _product = product;

            _specifications = new Specifications(_product.Specifications);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MinimumSize = new System.Drawing.Size(_parent.Width - 10, 75);
            Dock = DockStyle.Fill;
            FlowDirection = FlowDirection.TopDown;
            BorderStyle = BorderStyle.Fixed3D;

            var name = new Label()
            {
                Text = _product.Name,
                AutoSize = true,
            };

            var description = new Label()
            {
                Text = _product.Description,
                AutoSize = true,
            };

            var price = new Label()
            {
                Text = $"{_product.Price} руб.",
                AutoSize = true,
            };

            var detailButton = new Button()
            {
                Text = "Подробно",
                AutoSize = true,
            };

            Label checkBoxLabel = new Label();
            if (checkBoxNeeded)
            {
                checkBoxLabel = new Label()
                {
                    Text = "Нажмите, чтобы добавить товар к заказу",
                    AutoSize = true
                };

                _checkBox = new CheckBox()
                {
                    Checked = false
                };
            }

            detailButton.Click += DetailButton_Click;

            Controls.Add(name);
            Controls.Add(description);
            Controls.Add(price);
            Controls.Add(detailButton);

            if (checkBoxNeeded)
            {
                Controls.Add(checkBoxLabel);
                Controls.Add(_checkBox);
            }

            InitializeComponent();          
        }

        public Domain.Models.Product ProductValue => _product;

        public bool IsChoosed()
        {
            if (_checkBox is null)
                return false;

            return _checkBox.Checked;
        }

        private void DetailButton_Click(object sender, EventArgs e)
        {
            var message =
$@"
Наименование: {_product.Name}
Описание: {_product.Description}
Цена: {_product.Price} руб.
Производитель: {_product.Producer.Title}
Хар-ки:
" +
$"{string.Join("\n", _product.Specifications.Select((x, index) => $"{index + 1}) {x.Name}: {x.Value}"))}";

            MessageBox.Show(message, "Подробнее о товаре", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
