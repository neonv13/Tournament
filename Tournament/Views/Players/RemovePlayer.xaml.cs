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
        public PlayersViewModel PlayersViewModel { get; set; }
        public ViewPlayers ViewPlayers { get; set; }
        public RemovePlayer(ViewPlayers viewPlayers, PlayersViewModel playersViewModel)
        {
            ViewPlayers = viewPlayers;
            PlayersViewModel = playersViewModel;
            InitializeComponent();
        }
        private void Error(string text)
        {
            ErrorWindow errorNameWindow = new ErrorWindow();
            errorNameWindow.ErrorContent.Text = text;
            errorNameWindow.Show();
        }
        private void Button_Click_RemovePlayer(object sender, RoutedEventArgs e)
        {
            int id;
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            Player player = null;
            bool IsNameValid;
            bool IsSurnameValid;
            bool IsPlayerValid = false;
            bool IsIDValid;


            try 
            {
                id = int.Parse(IDTextBox.Text);
                if (id >= 0)
                {
                    IsIDValid = true;
                }
                else
                {
                    Error("Bad ID");
                    return;
                }
            }
            catch 
            {
                Error("ID is null!");
                return;
            }

            if (IsIDValid)
                player = PlayersViewModel.Players.FindByID(id);
            if(player == null)
            {
                Error("No player with following ID");
                return;
            }

            if (name != string.Empty)
            {
                IsNameValid = true;
            }
            else
            {
                Error("Please enter the Name");
                return;
            }

            if (surname != string.Empty)
            {
                IsSurnameValid = true;
            }
            else
            {
                Error("Please enter the Surname");
                return;

            }

            if (IsPlayerValid && IsNameValid && IsSurnameValid && IsIDValid && player.Name == name && player.Surname == surname)
            {
                PlayersViewModel.Players.Remove(id);
                ViewPlayers.Refresh();
                NavigationService.Navigate(ViewPlayers);
                Error("Succesfully removed Player");
                
            }
            else
            {
                Error("Wrong data");
                return;
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ViewPlayers.Refresh();
            NavigationService.Navigate(ViewPlayers);
        }
    }
}
