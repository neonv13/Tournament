using System.Windows.Controls;
using System.Windows.Input;
using Tournament.Models;
using Tournament.ViewModels;
using Tournament.Views.Tournament.TourWindow;

namespace Tournament.Views.Tournament
{
    /// <summary>
    /// Interaction logic for ViewTournaments.xaml
    /// </summary>
    public partial class ViewTournaments : Page
    {
        public PlayersViewModel PlayersViewModel { get; set; }
        public TeamViewModel TeamViewModel { get; set; }
        public RefereesViewModel RefereesViewModel { get; set; }
        public TournamentViewModel TournamentViewModel { get; set; }
        public ViewTournaments(TournamentViewModel tournamentViewModel)
        {
            TournamentViewModel = tournamentViewModel;
            InitializeComponent();
            TourListBox.ItemsSource = TournamentViewModel.Tournaments.List;
        }

        private void TourListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TourListBox.SelectedItem is Tournaments tour)
            {
                TournamentWindow tournamentWindow = new TournamentWindow(PlayersViewModel, TeamViewModel,TournamentViewModel, tour);
                tournamentWindow.Show();
            }
        }
    }
}
