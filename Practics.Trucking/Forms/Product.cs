using Practics.Trucking.Application.Inputs.Product;
using Practics.Trucking.Application.Inputs.Specification;
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
    public partial class Product : Form
    {
        private Input _name = new("Введите имя товара");
        private Input _description = new("Введите описание товара");
        private Input _price = new("Введите цену товара");
        private ComboBoxControl<Domain.Models.Producer> _producers;
        private List<(Input name, Input value)> _specifications = new();
        private Button _submitButton;
        private LinkLabel _linkLabel;

        private FlowLayoutPanel _mainPanel;
        private TableLayoutPanel _tableMainPanel;

        private MainProducer _parent;
        private readonly ProductService _productService;
        private readonly ProducerService _producerService;


        public Product(MainProducer parent, ProductService productService, ProducerService producerService)
        {
            _parent = parent;
            _productService = productService;
            _producerService = producerService;

            _producers = new ComboBoxControl<Domain.Models.Producer>(producerService.Read().ToList(), 150, 25);

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

            _linkLabel = new LinkLabel()
            {
                Text = "Добавить характеристику",
                AutoSize = true
            };

            _submitButton = new Button()
            {
                Text = "Добавить продукт",
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            _submitButton.Click += AddProductButtonClickEventHandler;
            _linkLabel.Click += AddSpecClickEventHandler;

            _mainPanel.Controls.Add(_name);
            _mainPanel.Controls.Add(_description);
            _mainPanel.Controls.Add(_price);
            _mainPanel.Controls.Add(_producers);
            _mainPanel.Controls.Add(_linkLabel);
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
            _parent.InitProducts();
            _parent.InitOrders();
        }

        private void AddSpecClickEventHandler(object sender, EventArgs e)
        {
            var flowpanel = new FlowLayoutPanel()
            {
                AutoSize = true,
                AutoSizeMode= AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(_parent.Width / 3, 100),
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
            };

            var label = new Label()
            {
                AutoSize = true,
                Text = $"Введите характеристику #{_specifications.Count + 1}"
            };

            var table = new TableLayoutPanel()
            {
                AutoScroll = true,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 1
            };

            var inputName = new Input("Имя характеристики");
            var inputValue = new Input("Значение характеристики");

            flowpanel.Controls.Add(label);
            flowpanel.Controls.Add(inputName);
            flowpanel.Controls.Add(inputValue);

            table.Controls.Add(flowpanel);

            _specifications.Add((inputName, inputValue));

            _mainPanel.Controls.Add(table);
            _tableMainPanel.Refresh();
        }

        private List<SpecificationRegisterInput> GetSpecs()
        {
            return _specifications
                .Select(x => new SpecificationRegisterInput() { Name = x.name.Value, Value = x.value.Value })
                .ToList();
        }

        private
        (
            string name,
            string description,
            decimal price,
            int? producerId
        ) GetInputValues()
        {
            return
                (
                    _name.Value,
                    _description.Value,
                    decimal.TryParse(_price.Value, out var result) ? result : 0m,
                    _producers.SelectedValue
                );        
        }

        private async void AddProductButtonClickEventHandler(object sender, EventArgs e)
        {
            var (name, descr, price, producerId) = GetInputValues();
            var specs = GetSpecs();

            var input = new ProductRegisterInput(name, descr, price, producerId, specs);

            var res = await _productService.RegisterProduct(input);

            if (res is null)
                MessageBox.Show("Проверьте вводимые данные");
            else
            {
                MessageBox.Show($"Зареган товар {res.Name}");

                _parent.Enabled = true;
                Close();
            }
        }
    }
}
