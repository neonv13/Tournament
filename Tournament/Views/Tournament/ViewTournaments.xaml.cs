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
using Tournament.ViewModels;

namespace Tournament.Views.Tournament
{
    /// <summary>
    /// Interaction logic for ViewTournaments.xaml
    /// </summary>
    public partial class ViewTournaments : Page
    {
        public TournamentViewModel TournamentViewModel { get; set; }
        public ViewTournaments(TournamentViewModel tournamentViewModel)
        {
            TournamentViewModel = tournamentViewModel;
            InitializeComponent();
            TourListBox.ItemsSource = TournamentViewModel.Tournaments.List;
        }
        
    }
}
