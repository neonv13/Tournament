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
    /// Interaction logic for RemoveTeam.xaml
    /// </summary>
    public partial class RemoveTeam : Page
    {
        public TeamViewModel TeamViewModel { get; set; }
        public ViewTeams ViewTeams { get; set; }

        public RemoveTeam(TeamViewModel teamViewModel, ViewTeams teamsViewTeamsView)
        {
            TeamViewModel = teamViewModel;
            ViewTeams = teamsViewTeamsView;
            InitializeComponent();
        }


        private void Button_Click_RemoveTeam(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(IDTextBox.Text);
            string name = NameTextBox.Text;
            Team team = TeamViewModel.Teams.FindByID(id);
            bool IsNameValid;
            bool IsTeamValid;
            bool IsIDValid;

            if (name != string.Empty)
                IsNameValid = true;
            else
            {
                ErrorWindow errorNameWindow = new ErrorWindow();
                errorNameWindow.ErrorContent.Text = "Please enter the Name";
                errorNameWindow.Show();
                return;
            }

            if (id >= 0)
            {
                IsIDValid = true;
            }
            else
            {
                ErrorWindow errorSurnameWindow = new ErrorWindow();
                errorSurnameWindow.ErrorContent.Text = "Please enter the ID";
                errorSurnameWindow.Show();
                return;
            }

            if (team != null)
            {
                IsTeamValid = true;
            }
            else
            {
                ErrorWindow errorSurnameWindow = new ErrorWindow() { Width=400};
                errorSurnameWindow.ErrorContent.Text = "There is no such Team in the database";
                errorSurnameWindow.Show();
                return;
            }
            
            if (IsTeamValid && IsIDValid && IsNameValid)
            {
                TeamViewModel.Teams.Remove(id);
                NavigationService.Navigate(ViewTeams);
                ErrorWindow errorSurnameWindow = new ErrorWindow();
                errorSurnameWindow.ErrorContent.Text = "Succesfully removed Team";
                errorSurnameWindow.Show();
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ViewTeams.MyListBox.Items.Refresh();
            NavigationService.Navigate(ViewTeams);
        }
    }

}
