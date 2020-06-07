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
    public class TeamViewModel 
    {
        public TeamList Teams { get; set; }
        
        public TeamViewModel()
        {
            Teams = new TeamList();
            
        }
        public void SaveTeamViewModel() 
        {
            Teams.WriteXML("teamsList.xml");
        }
        public void LoadTeamViewModel()
        {
            Teams.ReadXML("teamsList.xml");
        }

    }
}
