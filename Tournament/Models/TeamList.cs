using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;

namespace Tournament.Models
{
    class TeamList 
    {
        private List<Team> teamsList;
        private int count;

        /// <summary>
        /// Initializes a Count
        /// </summary>
        public int Count { get => count; set => count = value; }

        /// <summary>
        /// Initializes a GetTeamsList
        /// </summary>
        public List<Team> TeamsList { get => teamsList; set => teamsList = value; }

        /// <summary>
        /// Adds Team to TeamsList
        /// </summary>
        public void AddTeam(Team team)
        {
            TeamsList.Add(team);
        }
        /// <summary>
        /// Finds Team instance with following ID 
        /// </summary>
        public Team FindTeamByID(int id)
        {
            foreach (var team in TeamsList)
            {
                if (team.IdTeam == id)
                    return team;
            }

            return null;
        }
        /// <summary>
        /// Removes Team from TeamsList
        /// </summary>
        public void RemoveTeam(int id)
        {
            
                if (TeamsList.Contains(FindTeamByID(id)))
                {     
                    TeamsList.Remove(FindTeamByID(id));
                    Count--;
                }
        }

        /// <summary>
        /// Saves a  TeamsList
        /// </summary>
        public void SaveTeamsList(string path)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach (var team in TeamsList)
                {
                    file.WriteLine("StartTeamsData");
                    file.WriteLine("TeamName: " + team.TeamName);
                    file.WriteLine("TeamID: " + team.IdTeam);
                    file.WriteLine("TeamsPointEarned: " + team.PointEarned);
                    if (team.PlayersList.Count > 0)
                    {
                        file.WriteLine("Players");
                        foreach (var player in team.PlayersList.PlayersList)
                        {
                            file.WriteLine("PlayerID: " + player.ID);
                            file.WriteLine("PlayerName: " + player.Name);
                            file.WriteLine("PlayerSurname: " + player.Surname);
                            file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                            file.WriteLine("EndPlayer");
                        }
                        file.WriteLine("EndTeam");
                    }
                    file.WriteLine("EndTeamsData");
                }
                file.Close();
            };
        }

        /// <summary>
        /// Load TeamList
        /// </summary>
        public void LoadTeamsList(string path)
        {
            var players = new PlayerList();
            var teamsList = new List<Team>(); 
            int teamID = 0;
            string teamName = "";
            int teamPoint = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(" ");
                    switch (words[0])
                    {
                        case "TeamName:":
                            {
                                teamName = words[1];
                                break;
                            }
                        case "TeamID:":
                            {
                                teamID = int.Parse(words[1]);
                                break;
                            }
                        case "TeamsPointEarned:":
                            {
                                teamPoint = int.Parse(words[1]);
                                break;
                            }
                        case "Players:":
                            {
                                string endstring = "End" + words[0];
                                LoadPlayer(file, endstring, players);
                                //players.LoadPlayersList(path);
                                break;
                            }


                        case "EndTeamsData":
                            {

                                var team = new Team(teamName, teamID, players, teamPoint);
                                teamsList.Add(team);
                                break;
                            }
                    }
                file.Close();
            
            TeamsList = teamsList;
            Count = teamsList.Count;
            }
        }

        private void LoadPlayer(StreamReader file, string endstring, object playersA)
        {
            throw new NotImplementedException();
        }
    }

}
