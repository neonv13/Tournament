using System.Windows;
using Match = Tournament.Models.Match;

namespace Tournament.Views.Tournament.TourWindow
{
    /// <summary>
    /// Interaction logic for MatchProgression.xaml
    /// </summary>
    public partial class MatchProgression : Window
    {
        Match Match { get; set; }
        public MatchProgression(Match match)
        {
            InitializeComponent();
            Match = match;

            MatchRank.Text = Match.MatchRanks.ToString();
            TeamA.Text = Match.TeamA.Name.ToString();
            TeamB.Text = Match.TeamB.Name.ToString();

        }
    }
}
