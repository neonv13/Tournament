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
        public TeamsAddTeamView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TeamViewModel teamViewModel = new TeamViewModel();
            string name = TeamName.Text;
            teamViewModel.Teams.AddTeam(new Team(name,teamViewModel.Teams.TeamsList));
            teamViewModel.Teams.SaveTeamsList("plik2.txt");
            NavigationService.Navigate(new TeamsViewTeamsView());
        }
    }
}
