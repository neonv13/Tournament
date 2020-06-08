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
        private void Button_Click_RemovePlayer(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IDTextBox.Text);
            string name= NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            Player player = PlayersViewModel.Players.FindByID(id);
            bool IsNameValid;
            bool IsSurnameValid;
            bool IsPlayerValid;
            bool IsIDValid;

            if (id >= 0)
            {
                IsIDValid = true;
            }
            else 
            {
                ErrorWindow errorNameWindow = new ErrorWindow();
                errorNameWindow.ErrorContent.Text = "Please enter the ID";
                errorNameWindow.Show();
                return;
            }

            if (name != string.Empty)
            {
                IsNameValid = true;
            }
            else
            {
                ErrorWindow errorNameWindow = new ErrorWindow();
                errorNameWindow.ErrorContent.Text = "Please enter the Name";
                errorNameWindow.Show();
                return;
            }

            if (surname != string.Empty)
            {
                IsSurnameValid = true;
            }
            else
            {
                ErrorWindow errorSurnameWindow = new ErrorWindow();
                errorSurnameWindow.ErrorContent.Text = "Please enter the Surname";
                errorSurnameWindow.Show();
                return;

            }

            if (player != null)
            {
                IsPlayerValid = true;
            }
            else
            {
                ErrorWindow errorSurnameWindow = new ErrorWindow() { Width = Width + 200 };
                errorSurnameWindow.ErrorContent.Text = "There is no such player in the database";
                errorSurnameWindow.Show();
                return;

            }

            if (IsPlayerValid && IsNameValid && IsSurnameValid && IsIDValid)
            {
                PlayersViewModel.Players.Remove(id);
                ViewPlayers.Refresh();
                NavigationService.Navigate(ViewPlayers);
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Succesfully removed Player";
                errorWindow.Show();
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ViewPlayers.Refresh();
            NavigationService.Navigate(ViewPlayers);
        }
    }
}
