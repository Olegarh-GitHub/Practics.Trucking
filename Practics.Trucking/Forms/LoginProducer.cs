using Practics.Trucking.Application.Inputs.Producer;
using Practics.Trucking.Application.Inputs.User;
using Practics.Trucking.Application.Services;
using Practics.Trucking.Controls;
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
    public partial class LoginProducer : Form
    {
        private Input _loginInput;
        private Input _passwordInput;
        private Button _loginButton;
        private FlowLayoutPanel _mainPanel;
        private TableLayoutPanel _tableMainPanel;
        private LinkLabel _registerProducerLabel;
        private LinkLabel _loginAsUserLabel;

        private readonly UserService _userService;
        private readonly ProducerService _producerService;
        private readonly ProductService _productService;
        private readonly SessionService _sessionService;
        private readonly OrderService _orderService;

        private Form _parent;

        public LoginProducer(Form parent, UserService userService, ProducerService producerService, SessionService sessionService, ProductService productService, OrderService orderService)
        {
            _parent = parent;

            _userService = userService;
            _producerService = producerService;
            _sessionService = sessionService;
            _productService = productService;
            _orderService = orderService;

            _loginInput = new Input("Введите логин");
            _passwordInput = new Input("Введите пароль");

            _registerProducerLabel = new LinkLabel()
            {
                Text = "Еще нет аккаунта предпринимателя?",
                AutoSize = true,
                Dock = DockStyle.Fill
            };

            _loginAsUserLabel = new LinkLabel()
            {
                Text = "Войти как клиент",
                AutoSize = true,
                Dock = DockStyle.Fill
            };

            _mainPanel = new FlowLayoutPanel()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom
            };

            _tableMainPanel = new TableLayoutPanel()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 1
            };

            _loginButton = new Button()
            {
                Text = "Войти",
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            _loginButton.Click += LoginButtonClickEventHandler;
            _registerProducerLabel.LinkClicked += GoToRegisterFormClickEventHandler;
            _loginAsUserLabel.LinkClicked += GoToUserLoginFormClickEventHandler;

            _mainPanel.Controls.Add(_loginInput);
            _mainPanel.Controls.Add(_passwordInput);
            _mainPanel.Controls.Add(_registerProducerLabel);
            _mainPanel.Controls.Add(_loginAsUserLabel);
            _mainPanel.Controls.Add(_loginButton);
            _tableMainPanel.Controls.Add(_mainPanel);

            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            Controls.Add(_tableMainPanel);

            FormClosed += FormClosedEventHandler;
        }

        private void FormClosedEventHandler(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private (string login, string password) GetInputValues()
        {
            return (_loginInput.Value, _passwordInput.Value);
        }

        private async void LoginButtonClickEventHandler(object sender, EventArgs e)
        {
            var (login, password) = GetInputValues();

            var input = new ProducerTryLoginInput(login, password);

            bool result = _producerService.TryLogin(input);

            if (result)
            {
                Domain.Models.User current = _userService.GetUserByLogin(login);

                await _sessionService.SaveLocalSession(current.Id);

                Hide();

                var main = new MainProducer(this, _sessionService, _productService, _producerService, _orderService);

                main.Show();
            }
            else
                MessageBox.Show("Неудача!");
        }

        private void GoToRegisterFormClickEventHandler(object sender, EventArgs e)
        {
            var userForm = new Producer(this, _producerService);

            Enabled = false;
            userForm.Show();
        }

        private void GoToUserLoginFormClickEventHandler(object sender, EventArgs e)
        {
            _parent.Show();
            Dispose();
        }
    }
}
