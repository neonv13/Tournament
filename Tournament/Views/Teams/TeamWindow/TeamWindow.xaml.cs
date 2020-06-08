using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tournament.Models;
using Tournament.ViewModels;

namespace Tournament.Views.Teams
{
    /// <summary>
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        public Team Team { get; set; }
        public TeamViewModel TeamViewModel { get; set; }
        public PlayersViewModel PlayersViewModel { get; set; }
       
        public TeamWindow(Team team, TeamViewModel teamViewModel, PlayersViewModel playersViewModel)
        {
            Team = team;
            PlayersViewModel = playersViewModel;
            TeamViewModel = teamViewModel;
            InitializeComponent();
            XMLData();
        }
        private void XMLData() 
        {
            if (Team.PlayersList != null && Team.PlayersList.List != null)
                PlayersListBox.ItemsSource = Team.PlayersList.List;
            TopTextBlock.Text = Team.Name;
            TeamIDTextBlock.Text = Team.ID.ToString();
            TeamCountTextBlock.Text = Team.PlayersList.Count.ToString();
            TeamPointsTextBlock.Text = Team.PointEarned.ToString();
            TeamGameTypeTextBlock.Text = Team.GameTypes.ToString();
        }
        private void Button_Click_AddPlayerToTeam(object sender, RoutedEventArgs e)
        {
            AddPlayerToTeamWindow addPlayerToTeamWindow = new AddPlayerToTeamWindow(Team, this, TeamViewModel, PlayersViewModel);
            addPlayerToTeamWindow.Show();
            Refresh();
        }
        private void Button_Click_RemovePlayerFromTeam(object sender, RoutedEventArgs e)
        {
            RemovePlayerFromTeamWindow removePlayerFromTeamWindow = new RemovePlayerFromTeamWindow(Team, this, TeamViewModel);
            removePlayerFromTeamWindow.Show();
            Refresh();
        }
        public void Refresh() 
        {
            PlayersListBox.Items.Refresh();
            TeamCountTextBlock.Text = null;
            TeamCountTextBlock.Text = Team.PlayersList.Count.ToString();
            TeamPointsTextBlock.Text = null;
            TeamPointsTextBlock.Text = Team.PointEarned.ToString();
            TeamGameTypeTextBlock.Text = null;
            TeamGameTypeTextBlock.Text = Team.GameTypes.ToString();
        }
        #region

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
