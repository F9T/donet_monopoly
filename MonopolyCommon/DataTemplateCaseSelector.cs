using System.Windows;
using System.Windows.Controls;
using MonopolyCommon.Cases;

namespace MonopolyCommon
{
    public class DataTemplateCaseSelector : DataTemplateSelector
    {
        public DataTemplate PropertyCaseTemplate { get; set; }
        public DataTemplate JailCaseTemplate { get; set; }
        public DataTemplate StationCaseTemplate { get; set; }
        public DataTemplate TaxCaseTemplate { get; set; }
        public DataTemplate ChestCaseTemplate { get; set; }
        public DataTemplate StartCaseTemplate { get; set; }
        public DataTemplate ChanceCaseTemplate { get; set; }

        public override DataTemplate SelectTemplate(object _item, DependencyObject _container)
        {
            if (_item is PropertyCase)
            {
                return PropertyCaseTemplate;
            }
            if (_item is JailCase)
            {
                return JailCaseTemplate;
            }
            if (_item is StationCase)
            {
                return StationCaseTemplate;
            }
            if (_item is TaxCase)
            {
                return TaxCaseTemplate;
            }
            if (_item is ChestCase)
            {
                return ChestCaseTemplate;
            }
            if (_item is StartCase)
            {
                return StartCaseTemplate;
            }
            if (_item is ChanceCase)
            {
                return ChanceCaseTemplate;
            }
            return base.SelectTemplate(_item, _container);
        }
    }
}
