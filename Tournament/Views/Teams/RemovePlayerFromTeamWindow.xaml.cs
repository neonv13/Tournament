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

namespace Tournament.Views.Teams
{
    /// <summary>
    /// Interaction logic for RemovePlayerFromTeamWindow.xaml
    /// </summary>
    public partial class RemovePlayerFromTeamWindow : Window
    {
        public TeamViewModel TeamViewModel {get ;set; }
        public Team Team { get; set; }
        public TeamWindow TeamWindow { get; set; }
        public TeamViewModel TeamList { get; set; }


        public RemovePlayerFromTeamWindow(Team team, TeamWindow teamWindow, TeamViewModel teamViewModel)
        {
            TeamViewModel = teamViewModel;
            TeamWindow = teamWindow;
            Team = team;
            InitializeComponent();
        }


        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            PlayersViewModel playersViewModel = new PlayersViewModel();

            int id = int.Parse(IDText.Text);
            string name = NameText.Text;
            string surname = SurnameText.Text;
            Player player = playersViewModel.Players.FindPlayerByID(id);
            if (player != null && player.Name == name && player.Surname == surname)
            {
                if (Team.IsInTeam(id))
                {
                    Team.RemovePlayer(player.ID);
                    TeamWindow.Refresh();
                    TeamViewModel.SaveTeamViewModel();
                    this.Close();
                }
                else
                {
                    ErrorWindow errorWindow = new ErrorWindow();
                    errorWindow.ErrorContent.Text = "This player isn't in this team";
                    errorWindow.Show();
                }
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
