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

namespace Tournament.Views.Players
{
    /// <summary>
    /// Interaction logic for ViewPlayers.xaml
    /// </summary>
    public partial class ViewPlayers : Page
    {
        public PlayersViewModel PlayersViewModel { get; set; }

        public ViewPlayers(PlayersViewModel playersViewModel)
        {
            PlayersViewModel = playersViewModel;
            InitializeComponent();
            PlayesListBox.ItemsSource = PlayersViewModel.Players.List;
        }
        public void Refresh()
        {
            PlayesListBox.ItemsSource = null;
            PlayesListBox.ItemsSource = PlayersViewModel.Players.List; 


        }

    }
}
