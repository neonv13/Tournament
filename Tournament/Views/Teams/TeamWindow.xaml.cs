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
    public partial class TeamWindow : Window, INotifyPropertyChanged
    {
        private int teamID;
        private TeamViewModel teamViewModel;

        public int TeamID 
        { 
            get => teamID;
            set => teamID = value; 
        }

        public TeamViewModel TeamViewModel 
        { 
            get => teamViewModel;
            set 
            { 
                teamViewModel = value;
                OnPropertyChanged();
            } 
        }


        public TeamWindow(int teamID, TeamViewModel teamViewModel)
        {
            TeamID = teamID;
            TeamViewModel = teamViewModel;
            InitializeComponent();
        }

        private void Button_Click_AddPlayerToTeam(object sender, RoutedEventArgs e)
        {
            AddPlayerToTeamWindow addPlayerToTeamWindow = new AddPlayerToTeamWindow(TeamID, TeamViewModel);
            addPlayerToTeamWindow.Show();
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
