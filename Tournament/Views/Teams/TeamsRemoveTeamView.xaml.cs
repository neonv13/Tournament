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
    /// Interaction logic for TeamsRemoveTeamView.xaml
    /// </summary>
    public partial class TeamsRemoveTeamView : Page
    {
        public TeamViewModel TeamViewModel { get; set; }
        public TeamsViewTeamsView TeamsViewTeamsView { get; set; }

        public TeamsRemoveTeamView(TeamViewModel teamViewModel, TeamsViewTeamsView teamsViewTeamsView)
        {
            TeamViewModel = teamViewModel;
            TeamsViewTeamsView = teamsViewTeamsView;
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IDTextBox.Text);
            string name = NameTextBox.Text;
            Team team = TeamViewModel.Teams.FindTeamByID(id);
            if (team != null && team.TeamName == name)
            {
                TeamViewModel.Teams.RemoveTeam(id);
                TeamViewModel.Teams.SaveTeamsList("teamsList.txt");
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Width+=100;
                errorWindow.Show();
            }
            NavigationService.Navigate(TeamsViewTeamsView);
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            TeamsViewTeamsView.MyListBox.Items.Refresh();
            NavigationService.Navigate(TeamsViewTeamsView);
        }
    }

}
