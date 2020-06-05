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
using Tournament.Views.Teams;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for TeamsView.xaml
    /// </summary>
    public partial class TeamsView : Page
    {
        private TeamViewModel teamsViewModel;
        private TeamsViewTeamsView teamsViewTeamsView;
            
        public TeamViewModel TeamsViewModel { get => teamsViewModel; set => teamsViewModel = value; }
        public TeamsViewTeamsView TeamsViewTeamsView { get => teamsViewTeamsView; set => teamsViewTeamsView = value; }

        public TeamsView()
        {
            TeamsViewModel = new TeamViewModel();
             
            TeamsViewTeamsView = new TeamsViewTeamsView(teamsViewModel);
            InitializeComponent();
        }


        private void Button_Click_AddTeam(object sender, RoutedEventArgs e)
        {
            Teams.Content = new TeamsAddTeamView(teamsViewModel, teamsViewTeamsView);
            TeamsViewTeamsView.Refresh();
        }
        private void Button_Click_RemoveTeam(object sender, RoutedEventArgs e)
        {
            Teams.Content = new TeamsRemoveTeamView(teamsViewModel, teamsViewTeamsView);
            TeamsViewTeamsView.Refresh();
        }
        private void Button_Click_ViewTeams(object sender, RoutedEventArgs e)
        {
            Teams.Content = TeamsViewTeamsView;
            TeamsViewTeamsView.Refresh();
        }
    }
}
