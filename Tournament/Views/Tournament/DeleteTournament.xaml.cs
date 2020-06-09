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

namespace Tournament.Views.Tournament
{
    /// <summary>
    /// Interaction logic for DeleteTournament.xaml
    /// </summary>
    public partial class DeleteTournament : Page
    {
        public TournamentViewModel TournamentViewModel {get;set; }
        public ViewTournaments ViewTournaments { get; set; }
        public DeleteTournament(TournamentViewModel tournamentViewModel, ViewTournaments viewTournaments)
        {
            ViewTournaments = viewTournaments;
            TournamentViewModel = tournamentViewModel;
            InitializeComponent();
        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewTournaments);
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IDTextBox.Text);
            string name = NameTextBox.Text;
            Tournaments tour = TournamentViewModel.Tournaments.FindByID(id);
            if (tour != null && tour.Name == name)
            {
                TournamentViewModel.Tournaments.Remove(id);
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Width += 100;
                errorWindow.Show();
            }
            NavigationService.Navigate(ViewTournaments);
        }
    }
}
