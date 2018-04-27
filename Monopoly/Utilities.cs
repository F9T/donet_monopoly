using System.Linq;
using System.Windows;

namespace Monopoly
{
    public class Utilities
    {
        public static Window GetOwnedWindow()
        {
            if (Application.Current.MainWindow == null) return null;
            var ownedWindows = Application.Current.MainWindow.OwnedWindows;
            return ownedWindows.OfType<ConfigurationGameWindow>().FirstOrDefault();
        }
    }
}
