using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Xml.Serialization;
using Monopoly.Models.Cases;

namespace Monopoly.Models
{
    [Serializable]
    public class Platter
    {

        public Platter()
        {
            Cases = new ObservableCollection<AbstractCase>();
         /*   for (int i = 0; i < 40; i++)
            {
                if (i == 3 || i == 5 || i == 23 || i == 13)
                {
                    Cases.Add(new PropertyCase
                    {
                        Color = new SolidColorBrush(Colors.Blue),
                        PropertyName = "Super",
                        Price = 100,
                    });
                }
                else if (i == 2)
                {
                    Cases.Add(new ChanceCase());
                }
                else if (i == 6)
                {
                    Cases.Add(new JailCase());
                }
                else
                {
                    Cases.Add(new StartCase());
                }
            }*/
        }

        [XmlArray(ElementName = "Cases")]
        [XmlArrayItem("Case", Type = typeof(AbstractCase))]
        public ObservableCollection<AbstractCase> Cases { get; set; }
    }
}
