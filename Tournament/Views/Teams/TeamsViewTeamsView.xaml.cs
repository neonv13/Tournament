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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tournament.Models;
using Tournament.ViewModels;

namespace Tournament.Views.Teams
{
    /// <summary>
    /// Interaction logic for TeamsViewTeamsView.xaml
    /// </summary>
    public partial class TeamsViewTeamsView : Page, INotifyPropertyChanged
    {
        public TeamViewModel TeamViewModel { get; set; }
        public TeamsViewTeamsView(TeamViewModel teamViewModel)
        {
            TeamViewModel = teamViewModel;
            InitializeComponent();
        }

        private void Button_Click_ViewTeam(object sender, RoutedEventArgs e)
        {
            if (MyListBox.SelectedItem is Team team)
            {
                TeamWindow teamWindow = new TeamWindow(team, TeamViewModel);
                teamWindow.Show();
            }
        }
        public void Refresh()
        {
            MyListBox.ItemsSource = null;
            MyListBox.ItemsSource = TeamViewModel.Teams.TeamsList;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
