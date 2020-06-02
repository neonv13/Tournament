using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for RemovePlayerWindow.xaml
    /// </summary>
    public partial class RemovePlayerWindow : Window
    {
        public RemovePlayerWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
    }
}
