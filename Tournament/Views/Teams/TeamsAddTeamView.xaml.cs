using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
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
        public TeamsViewTeamsView TeamsViewTeamsView { get; set; }
        public TeamViewModel TeamViewModel { get; set; }

        public TeamsAddTeamView(TeamViewModel teamViewModel, TeamsViewTeamsView teamsViewTeamsView)
        {
            TeamsViewTeamsView = teamsViewTeamsView;
            TeamViewModel = teamViewModel;
            InitializeComponent();
            TeamGameType.ItemsSource = new List<GameTypes> { GameTypes.DodgeBall, GameTypes.TugOfWar, GameTypes.Volleyball };
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = TeamName.Text;

            if (TeamGameType.SelectedItem is GameTypes type)
            {
                TeamViewModel.Teams.AddTeam(new Team(name, TeamViewModel.Teams.TeamsList,type));
                TeamViewModel.SaveTeamViewModel();
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Succesfully added team";
                errorWindow.Show();
                TeamsViewTeamsView.MyListBox.Items.Refresh();
                NavigationService.GoBack();
            }
            else
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Choose Game Type";
            }

        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e) 
        {
            TeamsViewTeamsView.MyListBox.Items.Refresh();
            NavigationService.Navigate(TeamsViewTeamsView);
        }
    }

}
