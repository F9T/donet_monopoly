using System.Windows;
using Monopoly.Interfaces;

namespace Monopoly.Models.Cases
{
    public abstract class AbstractCase : IModel
    {
        protected AbstractCase()
        {
            //Default orientation
            Orientation = EnumCaseOrientation.Vertical;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Name { get; set; }

        public Point Position { get; set; }

        public EnumCaseOrientation Orientation { get; set; }

        public abstract void Action();

        public abstract bool IsLegal();

        public void Initialize()
        {
        }

        public void Dispose()
        {
        }
    }
}