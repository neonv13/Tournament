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
    /// Interaction logic for AddTeam.xaml
    /// </summary>
    public partial class AddTeam : Page
    {
        public ViewTeams ViewTeams { get; set; }
        public TeamViewModel TeamViewModel { get; set; }

        public AddTeam(TeamViewModel teamViewModel, ViewTeams teamsViewTeamsView)
        {
            ViewTeams = teamsViewTeamsView;
            TeamViewModel = teamViewModel;
            InitializeComponent();
            TeamGameType.ItemsSource = new List<GameTypes> { GameTypes.DodgeBall, GameTypes.TugOfWar, GameTypes.Volleyball };
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = TeamName.Text;
            bool IsNameValid;
            bool IsTypeValid;
            GameTypes type = 0;
            if (TeamGameType.SelectedItem is GameTypes type1)
            {
                type = type1;
            }
            if (name != string.Empty)
            {
                IsNameValid = true;
            }
            else 
            {
                ErrorWindow errorTypeWindow = new ErrorWindow();
                errorTypeWindow.ErrorContent.Text = "Please enter Team name";
                errorTypeWindow.Show();
                return;
            }
            if (type != 0)
            {
                IsTypeValid = true;
            }
            else
            {
                ErrorWindow errorTypeWindow = new ErrorWindow();
                errorTypeWindow.ErrorContent.Text = "Please choose Game Type";
                errorTypeWindow.Show();
                return;
            }
            if (IsNameValid && IsTypeValid)
            {
                TeamViewModel.Teams.Add(new Team() {Name =  name, ID = -1, GameTypes =  type });
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.ErrorContent.Text = "Succesfully added Team";
                errorWindow.Show();
                ViewTeams.MyListBox.Items.Refresh();
                NavigationService.Navigate(ViewTeams);
            }
            

        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e) 
        {
            ViewTeams.MyListBox.Items.Refresh();
            NavigationService.Navigate(ViewTeams);
        }
    }

}
