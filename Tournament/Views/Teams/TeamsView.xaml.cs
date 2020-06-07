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
    /// Interaction logic for TeamsView.xaml
    /// </summary>
    public partial class TeamsView : Page
    {
            
        public TeamViewModel TeamsViewModel { get; set; }
        public TeamsViewTeamsView TeamsViewTeamsView { get; set; }
        public PlayersViewModel PlayersViewModel { get; set; }

        public TeamsView(TeamViewModel teamViewModel, PlayersViewModel playersViewModel)
        {
            TeamsViewModel = teamViewModel;
            PlayersViewModel = playersViewModel;
            TeamsViewTeamsView = new TeamsViewTeamsView(TeamsViewModel, PlayersViewModel);
            InitializeComponent();
        }

        private void Button_Click_AddTeam(object sender, RoutedEventArgs e)
        {
            Teams.Content = new TeamsAddTeamView(TeamsViewModel, TeamsViewTeamsView);
            TeamsViewTeamsView.Refresh();
            TeamsViewModel.SaveTeamViewModel();
        }
        private void Button_Click_RemoveTeam(object sender, RoutedEventArgs e)
        {
            Teams.Content = new TeamsRemoveTeamView(TeamsViewModel, TeamsViewTeamsView);
            TeamsViewTeamsView.Refresh();
            TeamsViewModel.SaveTeamViewModel();

        }
        private void Button_Click_ViewTeams(object sender, RoutedEventArgs e)
        {
            Teams.Content = TeamsViewTeamsView;
            TeamsViewTeamsView.Refresh();

        }
        
    }
}
