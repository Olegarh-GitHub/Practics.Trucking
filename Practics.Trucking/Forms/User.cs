using Practics.Trucking.Application.Inputs.User;
using Practics.Trucking.Application.Services;
using Practics.Trucking.Controls;
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
    public partial class User : Form
    {
        private Input _surnameInput = new ("Введите фамилию");
        private Input _nameInput = new ("Введите имя");
        private Input _initialsInput = new ("Введите отчество");
        private Input _emailInput = new ("Введите эл.почту");
        private Input _loginInput = new ("Введите логин");
        private Input _passwordInput = new ("Введите пароль");
        private Input _passportSerialInput = new("Введите серию паспорта");
        private Input _passportNumberInput = new("Введите номер паспорта");
        private Input _addressInput = new("Введите адрес проживания");
        private FlowLayoutPanel _mainPanel;
        private TableLayoutPanel _tableMainPanel;
        private Button _submitButton;

        private UserService _userService;
        private Form _parent;

        public User(Form parent, UserService userService)
        {
            _parent = parent;
            _userService = userService;

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
                AutoScroll = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 1
            };

            _submitButton = new Button()
            {
                Text = "Регистрация",
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            _submitButton.Click += RegisterUserButtonClickEventHandler;

            _mainPanel.Controls.Add(_surnameInput);
            _mainPanel.Controls.Add(_nameInput);
            _mainPanel.Controls.Add(_initialsInput);
            _mainPanel.Controls.Add(_loginInput);
            _mainPanel.Controls.Add(_passwordInput);
            _mainPanel.Controls.Add(_emailInput);
            _mainPanel.Controls.Add(_passportSerialInput);
            _mainPanel.Controls.Add(_passportNumberInput);
            _mainPanel.Controls.Add(_addressInput);
            _mainPanel.Controls.Add(_submitButton);
            _tableMainPanel.Controls.Add(_mainPanel);

            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            Controls.Add(_tableMainPanel);

            FormClosed += FormCloseEventHandler;
        }

        private void FormCloseEventHandler(object sender, FormClosedEventArgs e)
        {
            _parent.Enabled = true;
        }

        private 
            (
                string surname, 
                string name,
                string initials,
                string login, 
                string password,
                string email,
                string passportSerial,
                string passportNumber,
                string address
            ) GetInputValues()
        {
            return
                (
                    _surnameInput.Value,
                    _nameInput.Value,
                    _initialsInput.Value,
                    _loginInput.Value,
                    _passwordInput.Value,
                    _emailInput.Value,
                    _passportSerialInput.Value,
                    _passportNumberInput.Value,
                    _addressInput.Value
                );
        }


        private async void RegisterUserButtonClickEventHandler(object sender, EventArgs e)
        {
            var (surname, name, initials, login, password, email, serial, number, address) = GetInputValues();

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Вы не ввели логин!");

                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Вы не ввели пароль!");

                return;
            }

            var input = new UserRegisterInput(login, password, surname, name, initials, email, serial, number, address);

            Domain.Models.User user = await _userService.RegisterUser(input);

            if (user is null)
                MessageBox.Show("Логин занят, попробуйте выбрать другой");
            else
            {
                MessageBox.Show($"Зареган {user.Login}");

                _parent.Enabled = true;
                Close();
            }
        }
    }
}
