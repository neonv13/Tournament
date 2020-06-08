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
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            NumberOfPlannedMatches.Text = Tournaments.MatchPlanned.Count.ToString();
            NumberOfPlayedMatches.Text = Tournaments.MatchHistory.Count.ToString();
            TourID.Text = Tournaments.ID.ToString();

            PointsFinalA.Text= Tournaments.FinalAResoult.ToString;
            PointsFinalB.Text= Tournaments.FinalBResoult.ToString;
            TeamFinalA.Text= Tournaments.FinalA.Name;
            TeamFinalB.Text= Tournaments.FinalB.Name;

            PointsSemiA.Text= Tournaments.SemiAResoult.ToString;
            PointsSemiB.Text= Tournaments.SemiBResoult.ToString;
            PointsSemiC.Text= Tournaments.SemiCResoult.ToString;
            PointsSemiD.Text= Tournaments.SemiDResoult.ToString;
            TeamSemiA.Text= Tournaments.SemiA.Name;
            TeamSemiB.Text= Tournaments.SemiB.Name;
            TeamSemiC.Text= Tournaments.Semic.Name;
            TeamSemiD.Text= Tournaments.SemiD.Name;
                
        }
        
    }
}
