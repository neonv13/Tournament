using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class TeamViewModel
    {
        public List<Team> Teams { get; private set; }
        public TeamViewModel()
        {
            Teams = new List<Team>();
            Teams.Add(new Team("Jacusie",Teams));
            Teams.Add(new Team("Paliki", Teams));
            Teams.Add(new Team("Ciosy",  Teams));
            Teams.Add(new Team("Janusze",Teams));

        }
        

    }
}
