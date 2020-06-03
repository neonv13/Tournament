using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
using Tournament.Models;
using Tournament.ViewModels;
using Tournament.Views.Players;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for AddPlayerWindow.xaml
    /// </summary>
    public partial class AddPlayer : Page
    {
        public AddPlayer()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayersViewModel playersViewModel = new PlayersViewModel();
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            playersViewModel.Players.AddPlayer(new Player(name,surname,playersViewModel.Players.PlayersList));
            playersViewModel.Players.SavePlayersList("playersList.txt");
            NavigationService.Navigate(new ViewPlayers());
        }
    }
}
