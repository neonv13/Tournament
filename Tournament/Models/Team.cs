using System;
using System.Collections.Generic;
//using System.Windows.Documents;


namespace Tournament.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int PointEarned { get; set; }
        public PlayerList PlayersList { get; set; }
        public int Count { get; set; }
        public GameType GameType { get; set; }

        /// <summary>
        /// Creates a new Team Instance
        /// </summary>
        public Team(string team_name, List<Team> teamLists, GameType gameType) 
        {
            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                if (teamLists != null)
                {
                    foreach (var team in teamLists)
                        {
                            if (randID == team.IdTeam)
                            FreeID = false;
                        }
                }
                else
                {
                    IdTeam = randID;
                    break;
                }
            } while (FreeID == false);
            PlayersList = new PlayerList();
            IdTeam = randID;
            PointEarned = 0;
            TeamName = team_name;
            Count = 0;
            GameType = gameType;
        }
        /// <summary>
        /// Create a new team with setted value of sets
        /// </summary>
        public Team(string tName, int id, PlayerList players, int point, GameType gameType)
        {
            TeamName = tName;
            IdTeam = id;
            PlayersList = players;
            PointEarned = point;
            GameType = gameType;
        }
        /// <summary>
        /// Adds Player to PlayersList
        /// </summary>
        public void AddPlayer(Player player)
        {
            if (!IsInTeam(player.ID))
            {
                PlayersList.PlayersList.Add(player);
                Count++;
            }
        }
   
        /// <summary>
        /// Remove Player from PlatersList
        /// </summary>
        public void RemovePlayer(int id)
        {
                if(IsInTeam(id))
                {
                    PlayersList.PlayersList.Remove(FindPlayerByID(id));
                    Count--;
                }
        }

        public bool IsInTeam(int id)
        {
            foreach (Player player in PlayersList.PlayersList)
            {
                if(player.ID == id)
                    return true;
            }
            return false;
        }

        public Player FindPlayerByID(int id)
        {
            foreach (Player player in PlayersList.PlayersList)
            {
                if (player.ID == id)
                    return player;
            }
            return null;
        
        }
    }
}
