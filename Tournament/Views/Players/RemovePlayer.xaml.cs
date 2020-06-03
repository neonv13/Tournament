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
using Tournament.Models;
using Tournament.ViewModels;
using Tournament.Views.Players;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for RemovePlayerWindow.xaml
    /// </summary>
    public partial class RemovePlayer : Page
    {
        public RemovePlayer()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayersViewModel playersViewModel = new PlayersViewModel();
            int id = int.Parse(IDTextBox.Text);
            string name= NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            if (playersViewModel.Players.FindPlayerByID(id).Name == name && playersViewModel.Players.FindPlayerByID(id).Surname == surname)
            {
                playersViewModel.Players.RemovePlayer(id);
                playersViewModel.Players.SavePlayersList("playersList.txt");
            }
            NavigationService.Navigate(new ViewPlayers());
        }
    }
}
