using System;
using System.Windows;
using Tournament.Views.Referees;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click_Tournament(object sender, RoutedEventArgs e)
        {
            Main.Content = new TournamentView();
        }
        private void Button_Click_Teams(object sender, RoutedEventArgs e)
        {
            Main.Content = new TeamsView();
        }
        private void Button_Click_Matches(object sender, RoutedEventArgs e)
        {
            Main.Content = new MatchesView();
        }
        private void Button_Click_Players(object sender, RoutedEventArgs e)
        {
            Main.Content = new PlayersView();
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Button_Click_Authors(object sender, RoutedEventArgs e)
        {
            Main.Content = new Authors();
        }
        private void Button_Click_Referees(object sender, RoutedEventArgs e)
        {
            Main.Content = new RefereeView();
        }
    }
}
