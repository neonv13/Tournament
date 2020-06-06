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
        public TeamList Teams { get; set; }
        
        public TeamViewModel()
        {
            Teams = new TeamList();
            Teams.LoadTeamsList("C:\\Users\\kamil\\OneDrive\\Pulpit\\ZadaniaPO\\Tournament\\Tournament\\bin\\Debug\\netcoreapp3.1\\teamsList.txt");
        }
        public void SaveTeamViewModel() 
        {
            Teams.SaveTeamsList("teamsList.txt");
        }
        public Team Team { get; set; }
       
        #region

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
