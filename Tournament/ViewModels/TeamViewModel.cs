using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Models;
using Tournament.Views;

namespace Tournament.ViewModels 
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        private TeamList teamsList;

        public TeamList Teams
        {
            get => teamsList;
            set 
            { 
                teamsList = value;
                OnPropertyChanged(); 
            }
        }
        public TeamViewModel()
        {
            Teams = new TeamList();
            Teams.LoadTeamsList("C:\\Users\\kamil\\OneDrive\\Pulpit\\ZadaniaPO\\Tournament\\Tournament\\bin\\Debug\\netcoreapp3.1\\teamsList.txt");
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
