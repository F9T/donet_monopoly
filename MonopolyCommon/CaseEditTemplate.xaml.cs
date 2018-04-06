using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using MonopolyCommon.Cases.Categories;

namespace MonopolyCommon
{
    public partial class CaseEditTemplate
    {
        private void BrowseImage_OnClick(object _sender, RoutedEventArgs _e)
        {
            if (_sender is Button button)
            {
                var fileDialog = new OpenFileDialog{ Filter = "PNG files (.png)| *.png", Multiselect = false};
                bool? result = fileDialog.ShowDialog(Application.Current.MainWindow);
                if (result == true)
                {
                    var file = new FileInfo(fileDialog.FileName);
                    if (file.Exists)
                    {
                        if (button.Tag is PriceTextImageCase mcase)
                        {
                            mcase.ImagePath = file.FullName;
                        }
                        else if (button.Tag is TextImageCase mcase2)
                        {
                            mcase2.ImagePath = file.FullName;
                        }
                    }
                }
            }
        }
    }
}
