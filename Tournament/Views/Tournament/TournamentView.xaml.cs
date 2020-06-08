﻿using DocumentFormat.OpenXml.Wordprocessing;
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
        public TournamentViewModel TournamentViewModel { get; set; }
        public PlayersViewModel PlayersViewModel { get; set; }
        public TeamViewModel TeamViewModel { get; set; }
        public RefereesViewModel RefereesViewModel { get; set; }

        public ViewTournaments ViewTournaments { get; set; }


        public TournamentView(TournamentViewModel tournamentViewModel, PlayersViewModel playersViewModel,
                              TeamViewModel teamViewModel, RefereesViewModel refereesViewModel)
        {
            TournamentViewModel = tournamentViewModel;
            PlayersViewModel = playersViewModel;
            TeamViewModel = teamViewModel;
            RefereesViewModel = refereesViewModel;
            ViewTournaments = new ViewTournaments(TournamentViewModel);
            InitializeComponent();
            TourView.Content = ViewTournaments;
        }
        private void Button_Click_NewTournament(object sender, RoutedEventArgs e)
        {
            TourView.Content = new CreateTournament(TournamentViewModel, TeamViewModel , RefereesViewModel, ViewTournaments);
        }
        private void Button_Click_DeleteTournament(object sender, RoutedEventArgs e)
        {
            TourView.Content = new DeleteTournament(TournamentViewModel, ViewTournaments);
        }
        private void Button_Click_ViewTournaments(object sender, RoutedEventArgs e)
        {
            TourView.Content = ViewTournaments;
        }
        public void Refresh() 
        {
            ViewTournaments.TourListBox.ItemsSource = null;
            ViewTournaments.TourListBox.ItemsSource = TournamentViewModel.Tournaments.List;
        }
    }
}
