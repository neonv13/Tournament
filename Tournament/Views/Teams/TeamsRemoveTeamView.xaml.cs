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

namespace Tournament.Views.Teams
{
    /// <summary>
    /// Interaction logic for TeamsRemoveTeamView.xaml
    /// </summary>
    public partial class TeamsRemoveTeamView : Page
    {
        public TeamsRemoveTeamView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TeamViewModel teamsViewModel = new TeamViewModel();
            int id = int.Parse(IDTextBox.Text);
            string name = NameTextBox.Text;
            if (teamsViewModel.Teams.FindTeamByID(id) != null && teamsViewModel.Teams.FindTeamByID(id).TeamName == name)
            {   
                teamsViewModel.Teams.RemoveTeam(id);
                teamsViewModel.Teams.SaveTeamsList("teamsList.txt");
            }
            NavigationService.Navigate(new TeamsViewTeamsView());
        }
    }
}
