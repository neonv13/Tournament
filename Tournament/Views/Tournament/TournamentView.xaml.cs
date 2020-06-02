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
using Tournament.Views.Tournament;


namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for TournamentView.xaml   
    /// </summary>
    public partial class TournamentView : Page
    {
        public TournamentView()
        {
            InitializeComponent();
            DataContext = new TournamentViewModel();
        }
        private void Button_Click_NewTournament(object sender, RoutedEventArgs e)
        {
            CreateTournament createTournament = new CreateTournament();
            createTournament.Show();
        }
        private void Button_Click_DeleteTournament(object sender, RoutedEventArgs e)
        {
            DeleteTournament createTournament = new DeleteTournament();
            createTournament.Show();
        }
        private void Button_Click_ViewTournaments(object sender, RoutedEventArgs e)
        {
            TourView.Content = new ViewTournaments();
        }
    }
}
