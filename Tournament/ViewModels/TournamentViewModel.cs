using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    public class TournamentViewModel
    {
        public List<Tournaments> Tournaments { get; private set; }
        public TournamentViewModel()
        {
            Tournaments = new List<Tournaments>();
            Tournaments.Add(new Tournaments(null,null, GameType.Volleyball, "Jacusie"));
            Tournaments.Add(new Tournaments(null,null, GameType.DodgeBall,  "Paliki4"));
            Tournaments.Add(new Tournaments(null,null, GameType.Volleyball, "ios435y"));
            Tournaments.Add(new Tournaments(null,null, GameType.TugOfWar,   "anuze43"));

        }
    }
}
