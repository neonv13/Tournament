using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Tournament.Views.Teams
{
    /// <summary>
    /// Interaction logic for AddPlayerToTeamWindow.xaml
    /// </summary>
    public partial class AddPlayerToTeamWindow : Window
    {
        private int teamID;
        private TeamViewModel teamViewModel;

        public TeamViewModel TeamViewModel { get => teamViewModel; set => teamViewModel = value; }
        public int TeamID{ get => teamID; set => teamID = value; }

        public AddPlayerToTeamWindow(int id, TeamViewModel teamViewModel)
        {
            TeamID = id;
            TeamViewModel = teamViewModel;
            InitializeComponent();
        }

        public TeamViewModel TeamList
        {
            get => TeamViewModel;
            set => TeamViewModel = value;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            PlayersViewModel playersViewModel = new PlayersViewModel();
            
            int id = int.Parse(IDText.Text);
            string name = NameText.Text;
            string surname = SurnameText.Text;
            Player player = playersViewModel.Players.FindPlayerByID(id);
            if (player != null
                && player.Name == name
                && player.Surname == surname)
            {
                TeamViewModel.Teams.FindTeamByID(TeamID).AddPlayer(player);
                this.Close();
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Show();
            }
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            PlayersViewModel playersViewModel = new PlayersViewModel();

            int id = int.Parse(IDText.Text);
            string name = NameText.Text;
            string surname = SurnameText.Text;
            Player player = playersViewModel.Players.FindPlayerByID(id);
            if (player != null
                && player.Name == name
                && player.Surname == surname)
            {
                TeamViewModel.Teams.FindTeamByID(TeamID).RemovePlayer(player.ID);
                this.Close();
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Show();
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
