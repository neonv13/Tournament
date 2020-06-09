using System.Windows.Controls;
using Tournament.Models;

namespace Tournament.Views.Tournament.TourWindow
{
    /// <summary>
    /// Interaction logic for TourInfo.xaml
    /// </summary>
    public partial class TourInfo : Page
    {
        public Tournaments Tournaments { get; set; }

        public TourInfo(Tournaments tournaments)
        {
            Tournaments = tournaments;
            InitializeComponent();
            Refresh();
            if (Tournaments.WasGroupStageCreated)
                Create.IsEnabled = false;
            if (Tournaments.WasGroupStageSymulated || !Tournaments.WasGroupStageCreated)
                Symulate.IsEnabled = false;
            if (!Tournaments.WasGroupStageSymulated || !Tournaments.WasGroupStageCreated || Tournaments.WasSemiCreated || Tournaments.WasFinalCreated)
                CreateSemi.IsEnabled = false;
            if (!Tournaments.WasGroupStageSymulated || !Tournaments.WasGroupStageCreated || !Tournaments.WasSemiCreated)
                CreateFinal.IsEnabled = false;
        }
        public void Refresh()
        {
            TourID.Text = null;
            TourID.Text = Tournaments.ID.ToString();

            NumberOfPlannedMatches.Text = null;
            NumberOfPlayedMatches.Text = null;
            NumberOfPlannedMatches.Text = Tournaments.MatchPlanned.Count.ToString();
            NumberOfPlayedMatches.Text = Tournaments.MatchHistory.Count.ToString();

            GameType.Text = null;
            GameType.Text = Tournaments.GameTypes.ToString() ;

            Tournaments.SortTeamsPoints();
            ScoreBoard.ItemsSource = null;
            ScoreBoard.ItemsSource = Tournaments.RankingTeam;

        }
        public void Error(string text)
        {
            ErrorWindow errorWindow = new ErrorWindow() { Width = 500 };
            errorWindow.ErrorContent.Text = text;
            errorWindow.Show();
        }
        private void Button_Click_SymulateGroupStage(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!Tournaments.WasGroupStageSymulated && Tournaments.WasGroupStageCreated)
            {
                Tournaments.SymulateGroupStage();
                Symulate.IsEnabled = false;
                Create.IsEnabled = false;
                Tournaments.WasGroupStageSymulated = true;
                Tournaments.WasGroupStageCreated = true;
                if (Tournaments.TeamList.Count >= 4)
                    CreateSemi.IsEnabled = true;
                else if(Tournaments.TeamList.Count >=2 && Tournaments.TeamList.Count < 4)
                {
                    CreateFinal.IsEnabled = true;
                }
                Refresh();
                Error("GroupStage was succesfully symulated!");
            }
        }
        private void Button_Click_CreateGroupStage(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!Tournaments.WasGroupStageCreated)
            {
                Tournaments.CreateGroupStage();
                Create.IsEnabled = false;
                Symulate.IsEnabled = true;
                Tournaments.WasGroupStageCreated = true;
                Refresh();
                Error("GroupStage was succesfully created!");
            }
        }
        private void Button_Click_CreateSemi(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!Tournaments.WasSemiCreated)
            {
                Tournaments.CreateSemi();
                CreateSemi.IsEnabled = false;
                CreateFinal.IsEnabled = true;
                Tournaments.WasSemiCreated = true;
                Tournaments.WasGroupStageSymulated = true;
                Tournaments.WasGroupStageCreated = true;
                Refresh();
                Error("Semifinal was succesfully created!");
            }
        }
        private void Button_Click_CreateFinal(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!Tournaments.WasFinalCreated)
            {
                Tournaments.CreateFinal();
                CreateFinal.IsEnabled = false;
                CreateSemi.IsEnabled = false;
                Tournaments.WasSemiCreated = true;
                Tournaments.WasGroupStageSymulated = true;
                Tournaments.WasGroupStageCreated = true;
                Tournaments.WasFinalCreated = true;
                Refresh();
                Error("Final was succesfully created!");
            }
        }
    }
}
