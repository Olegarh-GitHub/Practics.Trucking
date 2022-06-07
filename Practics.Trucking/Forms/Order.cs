using Practics.Trucking.Application.Inputs.Order;
using Practics.Trucking.Application.Services;
using Practics.Trucking.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practics.Trucking.Forms
{
    public partial class Order : Form
    {
        private Main _parent;
        private List<Domain.Models.Product> _products = new ();
        private readonly OrderService _orderService;
        private readonly SessionService _sessionService;

        public Order(Main parent, List<Domain.Models.Product> products, OrderService orderService, SessionService sessionService)
        {
            _products = products;
            _parent = parent;
            _orderService = orderService;
            _sessionService = sessionService;

            InitializeComponent();
            InitProducts();

            _productsCountLabel.Text = $"Количество товаров к перевозке: {_products.Count}";
            _totalSumLabel.Text = $"Итоговая сумма заказа: {_products.Sum(x => x.Price)}";
            _addressLabel.Text = $"Адрес доставки: {_sessionService.GetCurrentUser().UserInfo.Address}";

            FormClosed += Order_FormClosed;
        }

        private void Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Enabled = true;
        }

        private void InitProducts()
        {
            _allProductsPanel.Controls.Clear();

            foreach (var product in _products)
            {
                _allProductsPanel.Controls.Add(new Controls.Product(_allProductsPanel, product, false));
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var productIds = _products.Select(x => x.Id).ToList();
            var userId = _sessionService.GetCurrentUser().Id;

            var input = new OfferOrderInput(userId, productIds);

            var order = await _orderService.OfferOrder(input);

            if (order is null)
            {
                MessageBox.Show("Извините, из-за технической ошибки оформить заказ не удалось", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Успешно был оформлен товар на сумму {_products.Sum(x => x.Price)} руб.", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _parent.InitProducts();
            _parent.InitOrders();
            Close();
        }
    }
}
