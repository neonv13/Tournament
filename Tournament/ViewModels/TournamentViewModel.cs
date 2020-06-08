using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    public class TournamentViewModel
    {
        public TournamentList Tournaments { get; private set; }
        public TournamentViewModel()
        {
            Tournaments = new TournamentList();
            
        }
        public void SaveViewModel()
        {
            Tournaments.WriteXML("tournamentsList.xml");
        }
        public void LoadViewModel() 
        {
            Tournaments.ReadXML("tournamentsList.xml");
        }
    }
}
