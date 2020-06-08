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
using Tournament.Views.Referees;
using Tournament.Views.Teams;

namespace Tournament.Views.Tournament.TourWindow
{
    /// <summary>
    /// Interaction logic for TournamentWindow.xaml
    /// </summary>
    public partial class TournamentWindow : Window
    {
        public PlayersViewModel PlayersViewModel { get; set; }
        public TeamViewModel TeamViewModel { get; set; } 
        public TournamentViewModel TournamentViewModel { get; set; }
        public Tournaments Tournaments { get; set; }
        public TourInfo TourInfo { get; set; }
        public TournamentWindow(PlayersViewModel playersViewModel, TeamViewModel teamViewModel, TournamentViewModel tournamentViewModel,Tournaments tournaments)
        {
            PlayersViewModel =playersViewModel;
            TeamViewModel = teamViewModel;
            Tournaments = tournaments;
            TournamentViewModel = tournamentViewModel;
            InitializeComponent();
            TitleTour.Text = tournaments.Name;
            TourInfo = new TourInfo(Tournaments);
            Main.Content = TourInfo;
        }

        private void Button_Click_Teams(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewTeams(TeamViewModel,PlayersViewModel);
        }

        private void Button_Click_Referees(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewReferees(null,Tournaments.RefereeList);
        }

        private void Button_Click_Matches(object sender, RoutedEventArgs e)
        {
            Main.Content = new Matches(Tournaments.MatchPlanned,Tournaments.MatchHistory);
        }
        public void Button_Click_TourInfo(object sender, RoutedEventArgs e)
        {
            Main.Content = TourInfo;
        }

    }
}
