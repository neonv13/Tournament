using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    public class RefereesViewModel : INotifyPropertyChanged
    {
        public RefereeList Referees { get; set; }
        public RefereesViewModel()
        {
            Referees = new RefereeList();
            Referees.LoadRefereeList("C:\\Users\\kamil\\OneDrive\\Pulpit\\ZadaniaPO\\Tournament\\Tournament\\bin\\Debug\\netcoreapp3.1\\refereesList.txt");
        }

        public void SaveRefereesViewModel()
        {
            Referees.SaveRefereeList("refereesList.txt");
        
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
