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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tournament.ViewModels;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for PlayersView.xaml
    /// </summary>
    public partial class PlayersView : Page
    {
        public PlayersView()
        {
            InitializeComponent();
            DataContext = new PlayersViewModel();
        }

        private void Button_Click_AddPlayer(object sender, RoutedEventArgs e)
        {
            AddPlayerWindow addPlayerWindow = new AddPlayerWindow();
            addPlayerWindow.Show();
        }
        private void Button_Click_RemovePlayer(object sender, RoutedEventArgs e)
        {
            RemovePlayerWindow removePlayerWindow = new RemovePlayerWindow();
            removePlayerWindow.Show();
        }
    }
}
