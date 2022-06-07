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
    public partial class Login : Form
    {
        private Input _loginInput;
        private Input _passwordInput;
        private Button _loginButton;
        private FlowLayoutPanel _mainPanel;
        private TableLayoutPanel _tableMainPanel;
        private LinkLabel _registerUserLabel;
        private LinkLabel _loginAsProducerLabel;

        private SessionService _sessionService;
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly ProducerService _producerService;
        private readonly OrderService _orderService;

        public Login
        (
            UserService userService, 
            ProducerService producerService, 
            SessionService sessionService, 
            ProductService productService, 
            OrderService orderService
        )
        {
            _userService = userService;
            _producerService = producerService;
            _sessionService = sessionService;
            _orderService = orderService;

            _loginInput = new Input("Введите логин");
            _passwordInput = new Input("Введите пароль");

            _registerUserLabel = new LinkLabel()
            {
                Text = "Еще нет аккаунта?",
                AutoSize = true,
                Dock = DockStyle.Fill
            };

            _loginAsProducerLabel = new LinkLabel()
            {
                Text = "Войти как производитель",
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
            _registerUserLabel.LinkClicked += GoToRegisterFormClickEventHandler;
            _loginAsProducerLabel.LinkClicked += GoToProducerLoginFormClickEventHandler;

            _mainPanel.Controls.Add(_loginInput);
            _mainPanel.Controls.Add(_passwordInput);
            _mainPanel.Controls.Add(_registerUserLabel);
            _mainPanel.Controls.Add(_loginAsProducerLabel);
            _mainPanel.Controls.Add(_loginButton);
            _tableMainPanel.Controls.Add(_mainPanel);

            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            Controls.Add(_tableMainPanel);

            Load += FormLoadedEventHandler;
            _productService = productService;
        }

        private async void FormLoadedEventHandler(object sender, EventArgs e)
        {
            var isUserAlreadyLoggedIn = await _sessionService.IsLocalSessionUserAuthorized();

            if (!isUserAlreadyLoggedIn)
                return;
         
            Hide();

            Form main;

            if (_sessionService.IsCurrentUserAProducer())
            {
                main = new MainProducer(this, _sessionService, _productService, _producerService, _orderService);

                main.Show();
            }
            else
            {
                main = new Main(this, _sessionService, _productService, _orderService);

                main.Show();
            }
        }

        private (string login, string password) GetInputValues()
        {
            return (_loginInput.Value, _passwordInput.Value);
        }

        private async void LoginButtonClickEventHandler(object sender, EventArgs e)
        {
            var (login, password) = GetInputValues();

            var input = new UserTryLoginInput(login, password);

            bool result = _userService.TryLogin(input);

            if (result)
            {
                Domain.Models.User current = _userService.GetUserByLogin(login);

                await _sessionService.SaveLocalSession(current.Id);

                Hide();

                var main = new Main(this, _sessionService, _productService, _orderService);

                main.Show();
            }
            else
                MessageBox.Show("Неудача!");
        }

        private void GoToRegisterFormClickEventHandler(object sender, EventArgs e)
        {
            var userForm = new User(this, _userService);

            Enabled = false;
            userForm.Show();
        }

        private void GoToProducerLoginFormClickEventHandler(object sender, EventArgs e)
        {
            var producerForm = new LoginProducer(this, _userService, _producerService, _sessionService, _productService, _orderService);

            producerForm.Show();
            Hide();
        }
    }
}
