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

namespace Tournament.Views.Tournament
{
    /// <summary>
    /// Interaction logic for CreateTournament.xaml
    /// </summary>
    public partial class CreateTournament : Page
    {
        private TournamentViewModel TournamentViewModel { get; set; }
        public CreateTournament(TournamentViewModel tournamentViewModel)
        {
            TournamentViewModel = tournamentViewModel;
            InitializeComponent();
            GameTypeComboBox.ItemsSource = new List<GameType> { GameType.DodgeBall, GameType.TugOfWar, GameType.Volleyball };

        }

        private void Button_Click_RefereesList(object sender, RoutedEventArgs e)
        {
            ListsPlace.Content = new RefereesToChoose();
        }
        private void Button_Click_TeamsList(object sender, RoutedEventArgs e)
        {
            ListsPlace.Content = new TeamsToChoose();
        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            
        }
 /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = TourName.Text;

            if (GameTypeComboBox.SelectedItem is GameType type)
            {
                TournamentViewModel.Teams.AddTeam(new Team(name, TeamViewModel.Teams.TeamsList, type));
                TeamViewModel.SaveTeamViewModel();
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Succesfully added team";
                errorWindow.Show();
                TeamsViewTeamsView.MyListBox.Items.Refresh();
                NavigationService.GoBack();
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Choose Game Type";
            }

        }
        */
    }
}
