using Practics.Trucking.Controls;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.Trucking.Extensions
{
    internal static class EditorExtensions
    {
        public static ComboBoxItem ToComboBoxItem<TEntity>(this TEntity entity)
            where TEntity : Entity, IHaveTitle
        {
            var entityName = entity.Title;
            var entityId = entity.Id;

            return new ComboBoxItem(entityId, entityName);
        }
    }
}
