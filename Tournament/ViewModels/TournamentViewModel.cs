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
            //Tournaments.LoadTournament("tournamentsList.txt");
        }
        public void SaveViewModel()
        {
            Tournaments.SaveTournaments("tournamentsList.txt");
        }
    }
}
