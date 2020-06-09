using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        public TournamentViewModel TournamentViewModel { get; set; }
        public RefereesToChoose RefereesToChoose { get; set; }
        public TeamsToChoose TeamsToChoose { get; set; }

        public CreateTournament(TournamentViewModel tournamentViewModel, TeamViewModel teamViewModel,
                                RefereesViewModel refereesViewModel, ViewTournaments viewTournaments)
        {
            ViewTournaments = viewTournaments;
            RefereesViewModel = refereesViewModel;
            TeamViewModel = teamViewModel;
            TournamentViewModel = tournamentViewModel;
            InitializeComponent();
            GameTypeComboBox.ItemsSource = new List<GameTypes> { GameTypes.DodgeBall, GameTypes.TugOfWar, GameTypes.Volleyball };
            RefereesToChoose = new RefereesToChoose(RefereesViewModel);
            TeamsToChoose = new TeamsToChoose(TeamViewModel);
        }

        private void Button_Click_RefereesList(object sender, RoutedEventArgs e)
        {
            ListsPlace.Content = RefereesToChoose;
        }
        private void Button_Click_TeamsList(object sender, RoutedEventArgs e)
        {
            ListsPlace.Content = TeamsToChoose;
        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewTournaments);
        }

        private void Button_Click_AddTournament(object sender, RoutedEventArgs e)
        {
            string name = TourName.Text;

            RefereeList refereeList = new RefereeList();
            bool AreTeamsValid;
            bool AreRefereesValid;
            bool IsTypeValid;
            TeamList teamList = new TeamList();
            GameTypes type;

            foreach (var item in RefereesToChoose.RefereesListBox.SelectedItems)
            {
                if (item is Referee referee)
                    refereeList.Add(referee);
            }

            foreach (var item in TeamsToChoose.TeamsListBox.SelectedItems)
            {
                if (item is Team team)
                    teamList.Add(team);
            }
            if (GameTypeComboBox.SelectedItem is GameTypes types)
            {
                type = types;
                IsTypeValid = true;
            }
            else 
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Choose Game Type";
                errorWindow.Show();
                return;
            }
           
            if (refereeList.Count > 0)
            {
                AreRefereesValid = true;
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Choose at least one Referee";
                errorWindow.Show();
                return;
            }
            if (teamList.Count >= 2)
            {
                AreTeamsValid = true;
            }
            else 
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Choose at least two Teams";
                errorWindow.Show();
                return;
            }
            

            if (IsTypeValid && AreTeamsValid && AreRefereesValid)
            {
                Tournaments tournament = new Tournaments() { TeamList = teamList, RefereeList = refereeList, GameTypes = type, Name = name, ID = -1 };
                TournamentViewModel.Tournaments.Add(tournament);

                ErrorWindow errorWindow = new ErrorWindow() { Width = 350 };
                errorWindow.ErrorContent.Text = "Succesfully added Tourament";
                errorWindow.Show();
                ViewTournaments.TourListBox.Items.Refresh();
                NavigationService.Navigate(ViewTournaments);
            }
        }

        
    }
}

