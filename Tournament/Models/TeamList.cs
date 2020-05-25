using System.Collections.Generic;
using System.Windows.Documents;

namespace Tournament.Models
{
    class TeamList 
    {
        private List<Team> teamsList;

        /// <summary>
        /// Initializes a TeamsList
        /// </summary>
        private List<Team> TeamsList { get => teamsList; }

        private int count;

        /// <summary>
        /// Initializes a Count
        /// </summary>
        public int Count { get => count; set => count = value; }

        /// <summary>
        /// Adds Team to TeamsList
        /// </summary>
        public void AddTeam(Team team)
        {
            TeamsList.Add(team);
        }

        /// <summary>
        /// Removes Team from TeamsList
        /// </summary>
        public void RemoveTeam(int id)
        {
            foreach(var team in TeamsList)
            {
                if (team.IdTeam == id)
                    TeamsList.Remove(team);
            }
        }




    }

}
