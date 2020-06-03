using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels 
{
    class TeamViewModel : INotifyPropertyChanged
    {
        private TeamList teamsList;
        public TeamList Teams { get=> teamsList; set { teamsList = value; OnPropertyChanged(); } }
        public TeamViewModel()
        {
            Teams = new TeamList();
            Teams.LoadTeamsList("teamsList.txt");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
