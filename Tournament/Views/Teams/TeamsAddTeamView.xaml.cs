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
using Tournament.Views.Teams;

namespace Tournament.Views
{
    /// <summary>
    /// Interaction logic for TeamsAddTeamView.xaml
    /// </summary>
    public partial class TeamsAddTeamView : Page
    {
        private TeamViewModel teamViewModel;
        private TeamsViewTeamsView teamsViewTeamsView;
        public TeamsViewTeamsView TeamsViewTeamsView { get => teamsViewTeamsView; set => teamsViewTeamsView = value; }

        public TeamsAddTeamView(TeamViewModel teamViewModel, TeamsViewTeamsView teamsViewTeamsView)
        {
            TeamsViewTeamsView = teamsViewTeamsView;
            TeamViewModel = teamViewModel;
            InitializeComponent();
        }

        public TeamViewModel TeamViewModel { get => teamViewModel; set => teamViewModel = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = TeamName.Text;
            teamViewModel.Teams.AddTeam(new Team(name,teamViewModel.Teams.TeamsList));
            
            NavigationService.Navigate(TeamsViewTeamsView);
        }
    }
}
