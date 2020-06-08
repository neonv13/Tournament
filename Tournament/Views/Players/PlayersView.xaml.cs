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
using Tournament.Views.Players;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for PlayersView.xaml
    /// </summary>
    public partial class PlayersView : Page
    {
        public PlayersViewModel PlayersViewModel { get; set; }
        public ViewPlayers ViewPlayers { get; set; }
        public PlayersView(PlayersViewModel playersViewModel)
        {
            PlayersViewModel = playersViewModel;
            ViewPlayers = new ViewPlayers(PlayersViewModel); 
            InitializeComponent();
            PlayerView.Content = ViewPlayers;
        }

        private void Button_Click_AddPlayer(object sender, RoutedEventArgs e)
        {
            PlayerView.Content = new AddPlayer(ViewPlayers,PlayersViewModel);
        }
        private void Button_Click_RemovePlayer(object sender, RoutedEventArgs e)
        {
            PlayerView.Content = new RemovePlayer(ViewPlayers, PlayersViewModel);
        }
        private void Button_Click_ViewPlayers(object sender, RoutedEventArgs e)
        {
            ViewPlayers.Refresh();
            PlayerView.Content = ViewPlayers;
        }

    }
}
