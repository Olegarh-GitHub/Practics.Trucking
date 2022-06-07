using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models.Base;
using Practics.Trucking.Extensions;
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
    public partial class ComboBoxControl<TEntity> : ComboBox
        where TEntity : Entity, IHaveTitle
    {
        private readonly List<TEntity> _entities;

        public ComboBoxControl(List<TEntity> entities, int width, int height)
        {
            _entities = entities;

            var dataSource = entities
                .Select(entity => entity.ToComboBoxItem())
                .ToList();

            Width = width;
            Height = height;
            DataSource = dataSource;
            DropDownStyle = ComboBoxStyle.DropDownList;

            InitializeComponent();
        }

        public new int? SelectedValue => SelectedItem is not null
            ? (SelectedItem as ComboBoxItem).Id
            : null;
    }
}
