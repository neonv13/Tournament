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
        }
        public void Refresh()
        {
            TourID.Text = null;
            TourID.Text = Tournaments.ID.ToString();

            NumberOfPlannedMatches.Text = null;
            NumberOfPlayedMatches.Text = null;
            NumberOfPlannedMatches.Text = Tournaments.MatchPlanned.Count.ToString();
            NumberOfPlayedMatches.Text = Tournaments.MatchHistory.Count.ToString();

            PointsFinalA.Text = null;
            PointsFinalB.Text = null;
            if (Tournaments.FinalA != null)
            {
                PointsFinalA.Text = Tournaments.FinalAResult.ToString();
                PointsFinalB.Text = Tournaments.FinalBResult.ToString();
            }

            TeamFinalA.Text = null;
            TeamFinalB.Text = null;
            if (Tournaments.FinalA != null)
            {
                TeamFinalA.Text = Tournaments.FinalA.Name;
                TeamFinalB.Text = Tournaments.FinalB.Name;
            }
            PointsSemiA.Text = null;
            PointsSemiB.Text = null;
            PointsSemiC.Text = null;
            PointsSemiD.Text = null;

            TeamSemiA.Text = null;
            TeamSemiB.Text = null;
            TeamSemiC.Text = null;
            TeamSemiD.Text = null;
            if (Tournaments.SemiA != null)
            {
                PointsSemiA.Text = Tournaments.SemiAResult.ToString();
                PointsSemiB.Text = Tournaments.SemiBResult.ToString();
                PointsSemiC.Text = Tournaments.SemiCResult.ToString();
                PointsSemiD.Text = Tournaments.SemiDResult.ToString();

                TeamSemiA.Text = Tournaments.SemiA.Name;
                TeamSemiB.Text = Tournaments.SemiB.Name;
                TeamSemiC.Text = Tournaments.SemiC.Name;
                TeamSemiD.Text = Tournaments.SemiD.Name;
            }
            

            Winner.Text = null;
            if(Tournaments.Winner !=null)
                Winner.Text = Tournaments.Winner.Name.ToString();

            GameType.Text = null;
            GameType.Text = Tournaments.GameTypes.ToString() ;

            Tournaments.SortTeamsPoints();
            ScoreBoard.ItemsSource = null;
            ScoreBoard.ItemsSource = Tournaments.RankingTeam;

        }

        private void Button_Click_SymulateGroupStage(object sender, System.Windows.RoutedEventArgs e)
        {
            Tournaments.SymulateGroupStage();
            Refresh();
            ErrorWindow errorWindow = new ErrorWindow();
            errorWindow.ErrorContent.Text = "GroupStage was symulated";
            errorWindow.Show();

        }
    }
}
