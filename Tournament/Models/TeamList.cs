//using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
//using System.Windows.Documents;

namespace Tournament.Models
{
    public class TeamList
    {
        public int Count { get; set; }
        public List<Team> TeamsList { get; set; }

        public TeamList()
        {
            TeamsList = new List<Team>();
        }

        public TeamList(List<Team> listteam)
        {
            TeamsList = new List<Team>();
            TeamsList = listteam;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        /// <summary>
        /// Adds Team to TeamsList
        /// </summary>
        public void AddTeam(Team team)
        {
            TeamsList.Add(team);
            Count++;
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
                    file.WriteLine("TeamID: " + team.IdTeam);
                    file.WriteLine("TeamName: " + team.TeamName);
                    file.WriteLine("TeamGameType: " + team.GameType);
                    file.WriteLine("TeamsPointEarned: " + team.PointEarned);
                    if (team != null && team.PlayersList != null && team.PlayersList.PlayersList.Count > 0)
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
            GameType teamGameType = 0;
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
                    case "TeamsGameType:":
                        {
                            teamGameType = (GameType)Enum.Parse(typeof(GameType), words[1]);
                            break;
                        }
                    case "Players":
                        {
                            string endstring = "End" + words[0];
                            LoadPlayer(file, endstring, players);
                            break;
                        }
                    case "EndTeamsData":
                        {

                            var team = new Team(teamName, teamID, players, teamPoint, teamGameType) { Count = players.Count };
                            teamsList.Add(team);
                            players = new PlayerList();
                            break;
                        }
                }

            }
            file.Close();
            TeamsList = teamsList;
            Count = teamsList.Count;
        }

        private void LoadPlayer(StreamReader file, string endstring, PlayerList players)
        {
            int id = 0;
            string name = string.Empty;
            string surname = string.Empty;
            int points = 0;
            string text;
            while ((text = file.ReadLine()) != null && text != endstring)
            {
                string[] words = text.Split(" ");
                switch (words[0])
                {
                    case "PlayerID:":
                        {
                            id = int.Parse(words[1]);
                            break;
                        }
                    case "PlayerName:":
                        {
                            name = words[1];
                            break;
                        }
                    case "PlayerSurname:":
                        {
                            surname = words[1];
                            break;
                        }
                    case "EndPlayer":
                        {
                            if (id != 0 && name != string.Empty && surname != string.Empty)
                            {
                                Player player = new Player(name, surname, null)
                                {
                                    ID = id,
                                    IndividualPoints = points
                                };
                                players.AddPlayer(player);
                            }
                            break;
                        }
                    case "EndTeam":
                        {
                            return;
                        }
                }
            }
        }
    }

}
