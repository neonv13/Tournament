using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
using Tournament.ViewModels;
using Tournament.Views.Tournament.TourWindow;

namespace Tournament.Views.Teams
{
    /// <summary>
    /// Interaction logic for TeamsViewTeamsView.xaml
    /// </summary>
    public partial class ViewTeams : Page
    {
        public PlayersViewModel PlayersViewModel { get; set; }
        public TeamViewModel TeamViewModel { get; set; }
        public ViewTeams(TeamViewModel teamViewModel, PlayersViewModel playersViewModel)
        {
            TeamViewModel = teamViewModel;
            PlayersViewModel = playersViewModel;
            InitializeComponent();
            MyListBox.ItemsSource = TeamViewModel.Teams.List;
        }

        public void Refresh()
        {
            MyListBox.ItemsSource = null;
            MyListBox.ItemsSource = TeamViewModel.Teams.List;
        }

        private void MyListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MyListBox.SelectedItem is Team team)
            {

                TeamWindow teamWindow = new TeamWindow(team, TeamViewModel, PlayersViewModel);
                teamWindow.Show();
            }
        }
    }
}
