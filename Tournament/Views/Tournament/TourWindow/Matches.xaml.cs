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
    /// Interaction logic for Matches.xaml
    /// </summary>
    public partial class Matches : Page
    {
        public Matches(MatchList Planned,MatchList History)
        {
            InitializeComponent();
            PlannedMatches.ItemsSource = Planned.List;
            MatchHistory.ItemsSource = History.List;
        }
    }
}
