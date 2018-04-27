using System.Windows;
using System.Windows.Controls;
using MonopolyCommon.Cases;
using MonopolyCommon.Cases.Categories;

namespace MonopolyCommon
{
    public class DataTemplateCaseSelector : DataTemplateSelector
    {
        public DataTemplate TextImageCaseTemplate { get; set; }
        public DataTemplate PriceTextImageCaseTemplate { get; set; }
        public DataTemplate PropertyCaseTemplate { get; set; }
        public DataTemplate EmptyCaseTemplate { get; set; }

        public override DataTemplate SelectTemplate(object _item, DependencyObject _container)
        {
            switch (_item)
            {
                case PriceTextImageCase _:
                    return PriceTextImageCaseTemplate;
                case TextImageCase _:
                    return TextImageCaseTemplate;
                case PropertyCase _:
                    return PropertyCaseTemplate;
                case EmptyCase _:
                    return EmptyCaseTemplate;
            }
            return base.SelectTemplate(_item, _container);
        }
    }
}
