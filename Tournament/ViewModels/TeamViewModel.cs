using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class TeamViewModel
    {
        public TeamList Teams { get; set; }
        public TeamViewModel()
        {
            Teams = new TeamList();
            Teams.TeamsList.Add(new Team("Jacusie",Teams.TeamsList));
            Teams.TeamsList.Add(new Team("Paliki", Teams.TeamsList));
            Teams.TeamsList.Add(new Team("Ciosy",  Teams.TeamsList));
            Teams.TeamsList.Add(new Team("Janusze",Teams.TeamsList));

        }
        

    }
}
