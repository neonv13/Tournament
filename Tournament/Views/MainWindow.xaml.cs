﻿using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using System.Windows;
using Tournament.ViewModels;
using Tournament.Views.Referees;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel MainViewModel { get; set; }
        public MainWindow()
        {
            MainViewModel = new MainViewModel();
            InitializeComponent();
        }

        private void Button_Click_Tournament(object sender, RoutedEventArgs e)
        {
            Main.Content = MainViewModel.TournamentView;
        }
        private void Button_Click_Teams(object sender, RoutedEventArgs e)
        {
            Main.Content = MainViewModel.TeamsView;
        }
        private void Button_Click_Players(object sender, RoutedEventArgs e)
        {
            Main.Content = MainViewModel.PlayersView;
        }
        private void Button_Click_Referees(object sender, RoutedEventArgs e)
        {
            Main.Content = MainViewModel.RefereeView;
        }
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            MainViewModel.SaveAll();
            Error("Succesfully saved all data");
        }
        private void Error(string text)
        {
            ErrorWindow errorWindow = new ErrorWindow() { Width = 400 };
            errorWindow.ErrorContent.Text = text;
            errorWindow.Show();
        }
        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                MainViewModel.LoadAll();
                Error("Succesfully loaded data");
            }
            catch(System.Exception ex) 
            {
                Error(ex.Message);
            }
        }
        private void Button_Click_Authors(object sender, RoutedEventArgs e)
        {
            Main.Content = new Authors();
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
