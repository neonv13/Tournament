using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using System.Windows;
using Tournament.ViewModels;
using Tournament.Views.Referees;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TeamViewModel teamViewModel;
        private PlayersViewModel playersViewModel;
        private RefereesViewModel refereesViewModel;
        private TournamentViewModel tournamentViewModel;
        private MatchesViewModel matchesViewModel;
        private TournamentView tournamentView;
        private TeamsView teamsView;
        private MatchesView matchesView;
        private PlayersView playersView;
        private RefereeView refereeView;

        public TeamViewModel TeamViewModel { get => teamViewModel; set => teamViewModel = value; }
        public PlayersViewModel PlayersViewModel { get => playersViewModel; set => playersViewModel = value; }
        public RefereesViewModel RefereesViewModel { get => refereesViewModel; set => refereesViewModel = value; }
        public TournamentViewModel TournamentViewModel { get => tournamentViewModel; set => tournamentViewModel = value; }
        public MatchesViewModel MatchesViewModel { get => matchesViewModel; set => matchesViewModel = value;}
        public TournamentView TournamentView { get => tournamentView; set => tournamentView = value; }
        public TeamsView TeamsView { get => teamsView; set => teamsView = value; }
        public MatchesView MatchesView { get => matchesView; set => matchesView = value; }
        public PlayersView PlayersView { get => playersView; set => playersView = value; }
        public RefereeView RefereeView { get => refereeView; set => refereeView = value; }

        public MainWindow()
        {
            TeamViewModel = new TeamViewModel();
            PlayersViewModel = new PlayersViewModel();
            RefereesViewModel = new RefereesViewModel();
            TournamentViewModel = new TournamentViewModel();
            MatchesViewModel = new MatchesViewModel();
            InitializeComponent();
            TournamentView = new TournamentView(TournamentViewModel, PlayersViewModel, TeamViewModel, RefereesViewModel);
            TeamsView = new TeamsView(TeamViewModel,PlayersViewModel);
            MatchesView = new MatchesView(MatchesViewModel);
            PlayersView = new PlayersView(PlayersViewModel);
            RefereeView = new RefereeView(RefereesViewModel);
        }

        private void Button_Click_Tournament(object sender, RoutedEventArgs e)
        {
            Main.Content = TournamentView;
        }
        private void Button_Click_Teams(object sender, RoutedEventArgs e)
        {
            Main.Content = TeamsView;
        }
        private void Button_Click_Matches(object sender, RoutedEventArgs e)
        {
            Main.Content = MatchesView;
        }
        private void Button_Click_Players(object sender, RoutedEventArgs e)
        {
            Main.Content = PlayersView;
        }
        private void Button_Click_Referees(object sender, RoutedEventArgs e)
        {
            Main.Content = RefereeView;
        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_Authors(object sender, RoutedEventArgs e)
        {
            Main.Content = new Authors();
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
