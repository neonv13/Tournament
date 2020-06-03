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

namespace Tournament.Views.Tournament
{
    /// <summary>
    /// Interaction logic for CreateTournament.xaml
    /// </summary>
    public partial class CreateTournament : Page
    {
        public CreateTournament()
        {
            InitializeComponent();
        }

        private void Button_Click_RefereesList(object sender, RoutedEventArgs e)
        {
            ListsPlace.Content = new RefereesToChoose();
        }
        private void Button_Click_TeamsList(object sender, RoutedEventArgs e)
        {
            ListsPlace.Content = new TeamsToChoose();
        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
