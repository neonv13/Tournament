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
            int id;
            string name = NameTextBox.Text;
            
            bool IsNameValid;
            bool IsTeamValid;
            bool IsIDValid;

            if (name != string.Empty)
                IsNameValid = true;
            else
            {
                Error("Please enter the Name");
                return;
            }

            if (IDTextBox.Text != string.Empty)
            {
                id = int.Parse(IDTextBox.Text);

                if (id >= 0)
                {
                    IsIDValid = true;
                }
                else
                {
                    Error("Please enter corect ID");
                    return;
                }

            }
            else
            {
                Error("Please enter ID");
                return;
            }

            Team team = TeamViewModel.Teams.FindByID(id);

            if (team != null)
            {
                IsTeamValid = true;
            }
            else
            {
                Error("There is no such Team in the database");
                return;
            }
            
            if (IsTeamValid && IsIDValid && IsNameValid && team.Name == name)
            {
                TeamViewModel.Teams.Remove(id);
                NavigationService.Navigate(ViewTeams);
                Error( "Succesfully removed Team");
            }
            else
            {
                Error("There is no such Team in the database");
                return;
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            ViewTeams.MyListBox.Items.Refresh();
            NavigationService.Navigate(ViewTeams);
        }
        private void Error(string text)
        {
            ErrorWindow errorSurnameWindow = new ErrorWindow() { Width = 400 };
            errorSurnameWindow.ErrorContent.Text = text;
            errorSurnameWindow.Show();
        }
    }

}
