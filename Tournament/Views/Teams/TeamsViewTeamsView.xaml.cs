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
using Tournament.ViewModels;

namespace Tournament.Views.Teams
{
    /// <summary>
    /// Interaction logic for TeamsViewTeamsView.xaml
    /// </summary>
    public partial class TeamsViewTeamsView : Page
    {
        private TeamViewModel teamViewModel;
        public TeamViewModel TeamViewModel { get => teamViewModel; set => teamViewModel = value; }
        public TeamsViewTeamsView(TeamViewModel teamViewModel)
        {
            TeamViewModel = teamViewModel;
            InitializeComponent();
        }

        private void Button_Click_ViewTeam(object sender, RoutedEventArgs e)
        {
            Team team = MyListBox.SelectedItem as Team;
            if (team != null)
            {
                TeamWindow teamWindow = new TeamWindow(team.IdTeam, TeamViewModel);
                teamWindow.Show();
            }
        }
        public void Refresh()
        {
            MyListBox.ItemsSource = null;
            MyListBox.ItemsSource = TeamViewModel.Teams.TeamsList;

        }
    }
}
