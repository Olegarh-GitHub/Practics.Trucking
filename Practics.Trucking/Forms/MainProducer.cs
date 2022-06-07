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
    public partial class MainProducer : Form
    {
        private Form _parent;

        private readonly Domain.Models.User _currentUser;
        private readonly SessionService _sessionService;
        private readonly ProductService _productService;
        private readonly ProducerService _producerService;
        private readonly OrderService _orderService;

        private List<Controls.Product> _productControls = new();
        private List<Controls.Order> _orderControls = new();

        public MainProducer(Form parent, SessionService sessionService, ProductService productService, ProducerService producerService, OrderService orderService)
        {
            _parent = parent;
            _sessionService = sessionService;
            _productService = productService;
            _producerService = producerService;
            _orderService = orderService;

            _currentUser = _sessionService.GetCurrentUser();

            InitializeComponent();
            InitProducts();
            InitOrders();

            _usernameLabel.Text = $"{_currentUser.UserInfo.Surname} {_currentUser.UserInfo.Name}";
            StartPosition = FormStartPosition.CenterScreen;

            FormClosed += FormClosedEventHandler;
        }

        private void FormClosedEventHandler(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void InitProducts()
        {
            _allProductsPanel.Controls.Clear();
            _productControls.Clear();

            var products = _productService.Read().ToList();

            foreach (var product in products)
            {
                var productControl = new Controls.Product(_allProductsPanel, product, false);

                _productControls.Add(productControl);
                _allProductsPanel.Controls.Add(productControl);
            }
        }

        public void InitOrders()
        {
            _myOrdersPanel.Controls.Clear();
            _orderControls.Clear();

            var orders = _orderService.Read().ToList();

            foreach (var order in orders)
            {
                var orderControl = new Controls.Order(_allProductsPanel, order, true);

                _orderControls.Add(orderControl);
                _myOrdersPanel.Controls.Add(orderControl);
            }
        }

        private async void _exitLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dispose();

            await _sessionService.DropCurrentSession();

            _parent.Show();
        }

        private void _userAboutButton_Click(object sender, EventArgs e)
        {
            var info =
                $@"
ФИО: {_currentUser.UserInfo.Surname} {_currentUser.UserInfo.Name} {_currentUser.UserInfo.Initials}
Паспорт: {_currentUser.UserInfo.PassportSerialNumber} {_currentUser.UserInfo.PassportNumber}
Адрес: {_currentUser.UserInfo.Address}
                ";

            MessageBox.Show(info, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _addProduct_Click(object sender, EventArgs e)
        {
            var product = new Product(this, _productService, _producerService);

            product.Show();
            Enabled = false;
        }

        private async void _exitLink_LinkClicked_1Async(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dispose();

            await _sessionService.DropCurrentSession();

            _parent.Show();
        }

        private void _approveOrders_Click(object sender, EventArgs e)
        {
            var checkedOrders = _orderControls
                .Where(x => x.IsChoosed())
                .Select(x => x.OrderValue)
                .ToList();

            if (!checkedOrders.Any())
            {
                MessageBox.Show("Вы не выбрали ни одного заказа для завершения!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var input = new ApproveOrderInput(checkedOrders.Select(x => x.Id).ToList());

            _orderService.ApproveOrder(input);

            InitProducts();
            InitOrders();
        }
    }
}
