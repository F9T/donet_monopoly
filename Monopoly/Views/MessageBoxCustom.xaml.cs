using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Monopoly
{
    /// <summary>
    /// Interaction logic for MsgBoxYesNo.xaml
    /// </summary>
    public partial class MsgBoxYesNo : Window
    {
        public MsgBoxYesNo(string message)
        {
            InitializeComponent();

            txtMessage.Text = message;
        }

        /// <summary>
        /// Action when user click on yes button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Action when user click on No button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void No_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }


    }
}
