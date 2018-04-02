using System.Windows.Media;

namespace Monopoly.Models.Cases
{
    public class PropertyCase : AbstractCase
    {
        public SolidColorBrush Color { get; set; }

        public string PropertyName { get; set; }

        public int Price { get; set; }
        public override void Action()
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
