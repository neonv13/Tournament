using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class TeamViewModel
    {
        private List<Team> teams;
        public TeamViewModel()
        {
            teams = new List<Team>();
            teams.Add(new Team("Jacusie",teams));
            teams.Add(new Team("Paliki", teams));
            teams.Add(new Team("Ciosy",  teams));
            teams.Add(new Team("Janusze",teams));

        }
        public List<Team> Teams
        {
            get => teams;

        }

    }
}
