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
        public TeamViewModel TeamViewModel { get; set; }
        public RefereesViewModel RefereesViewModel { get; set; }
        public ViewTournaments ViewTournaments { get; set; }
        private TournamentViewModel TournamentViewModel { get; set; }
        public CreateTournament(TournamentViewModel tournamentViewModel, TeamViewModel teamViewModel,
                                RefereesViewModel refereesViewModel, ViewTournaments viewTournaments)
        {
            ViewTournaments = viewTournaments;
            RefereesViewModel = refereesViewModel;
            TeamViewModel = teamViewModel;
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
 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = TourName.Text;
            RefereeList refereeList= null;
            TeamList teamList = null;

            if (GameTypeComboBox.SelectedItem is GameType type)
            {
                TournamentViewModel.Tournaments.AddTournament(new Tournaments(teamList,refereeList,type, name));
                TournamentViewModel.SaveViewModel();
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Succesfully added team";
                errorWindow.Show();
                ViewTournaments.TourListBox.Items.Refresh();
                NavigationService.GoBack();
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Choose Game Type";
            }

        }
       
    }
}
