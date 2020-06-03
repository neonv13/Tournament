using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class RefereesViewModel : INotifyPropertyChanged
    {
        private RefereeList referees;
        public RefereeList Referees
        {
            get => referees;
            private set
            { 
                referees = value;
                OnPropertyChanged();
            }
        }
        public RefereesViewModel()
        {
            Referees = new RefereeList();
            Referees.LoadRefereeList("C:\\Users\\kamil\\OneDrive\\Pulpit\\ZadaniaPO\\Tournament\\Tournament\\bin\\Debug\\netcoreapp3.1\\refereesList.txt");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
