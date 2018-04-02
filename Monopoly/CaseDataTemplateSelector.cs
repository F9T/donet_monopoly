using System.Windows;
using System.Windows.Controls;
using Monopoly.Models.Cases;

namespace Monopoly
{
    public class CaseDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PropertyCaseTemplate { get; set; }
        public DataTemplate StartCaseTemplate { get; set; }

        public override DataTemplate SelectTemplate(object _item, DependencyObject _container)
        {
            if (!(_item is DependencyProperty dp))
            {
                return null;
            }
            if (dp.PropertyType == typeof(PropertyCase))
            {
                return PropertyCaseTemplate;
            }
            if (dp.PropertyType == typeof(StartCase))
            {
                return StartCaseTemplate;
            }
            return base.SelectTemplate(_item, _container);
        }
    }
}
