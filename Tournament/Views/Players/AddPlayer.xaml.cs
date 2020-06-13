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
        public PlayersViewModel PlayersViewModel { get; set; }
        public ViewPlayers ViewPlayers { get; set; }
        public AddPlayer(ViewPlayers viewPlayers, PlayersViewModel playersViewModel)
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
        private void Button_Click_AddPlayer(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            bool IsNameValid;
            bool IsSurameValid;
            
            if (name != string.Empty)
                IsNameValid = true;
            else
            {
                Error("Please enter the Name");
                return;
            }
            if (surname != string.Empty)
                IsSurameValid = true;
            else
            {
                Error("Please enter the Surname");
                return;
            }

            if (IsNameValid && IsSurameValid)
            {
                PlayersViewModel.Players.Add(new Player() { Name = name, Surname = surname, ID = -1 });
                ViewPlayers.Refresh();
                Error("Succesfully added Player");
                NavigationService.Navigate(ViewPlayers);
            }  
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ViewPlayers.Refresh();
            NavigationService.Navigate(ViewPlayers);
        }
    }
}
