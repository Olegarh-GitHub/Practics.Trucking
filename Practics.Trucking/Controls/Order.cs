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
    public partial class Order : FlowLayoutPanel
    {
        private readonly Control _parent;
        private readonly Domain.Models.Order _order;

        private CheckBox _checkBox;

        public Order(Control parent, Domain.Models.Order order, bool checkBoxNeeded = true)
        {
            _parent = parent;
            _order = order;

            if (_order.Status == Domain.Enums.DeliveryStatus.Delivered)
                checkBoxNeeded = false;

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MinimumSize = new System.Drawing.Size(_parent.Width - 10, 75);
            Dock = DockStyle.Fill;
            FlowDirection = FlowDirection.TopDown;
            BorderStyle = BorderStyle.Fixed3D;

            var date = new Label()
            {
                Text = $"Заказ от {_order.OrderTime:dd.MM.yyyy hh:mm}",
                AutoSize = true,
            };

            var price = new Label()
            {
                Text = $"на сумму {_order.TotalPrice} руб.",
                AutoSize = true,
            };

            var count = new Label()
            {
                Text = $"Количество товаров в заказе: {_order.TotalCount}",
                AutoSize = true,
            };

            var status = new Label()
            {
                Text = $"Статус заказа: {(_order.Status == Domain.Enums.DeliveryStatus.InProcess ? "В процессе" : "Доставлено")}",
                AutoSize= true
            };

            var detailButton = new Button()
            {
                Text = "Подробно",
                AutoSize = true,
            };

            var detailProductButton = new Button()
            {
                Text = "Подробно о товарах",
                AutoSize = true,
            };

            Label checkBoxLabel = new Label();
            if (checkBoxNeeded)
            {
                checkBoxLabel = new Label()
                {
                    Text = "Нажмите, чтобы перевести заказ в статус \"Доставлено\"",
                    AutoSize = true
                };

                _checkBox = new CheckBox()
                {
                    Checked = false
                };
            }

            detailButton.Click += DetailButton_Click;
            detailProductButton.Click += DetailProductButton_Click;

            Controls.Add(date);
            Controls.Add(price);
            Controls.Add(count);
            Controls.Add(status);
            Controls.Add(detailButton);
            Controls.Add(detailProductButton);

            if (checkBoxNeeded)
            {
                Controls.Add(checkBoxLabel);
                Controls.Add(_checkBox);
            }

            InitializeComponent();
        }

        private void DetailProductButton_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            int index = 1;
            foreach (var product in _order.Products.ToList())
            {
                message +=
$@"
Товар #{index}
   Наименование: {product.Name}
   Описание: {product.Description}
   Цена: {product.Price} руб.
   Характеристики:

";
                var messageSpecs =
                product.Specifications is not null ||
                product.Specifications.Any() 
                    ? $"{string.Join("\n", product.Specifications.Select((x, index) => $"{index + 1}) {x.Name}: {x.Value}"))}" 
                    : "- Нет";

                message += messageSpecs;

                index++;              
            }

            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Domain.Models.Order OrderValue => _order;

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
Дата заказа: {_order.OrderTime:dd.MM.yyyy hh:mm}
Количество товара: {_order.TotalCount} шт.
Цена: {_order.TotalPrice} руб.";

            MessageBox.Show(message, "Подробнее о заказе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
