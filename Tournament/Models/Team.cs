using System;
using System.Collections.Generic;
using System.Windows.Documents;


namespace Tournament.Models
{
    class Team
    {
        private int count;
        private string teamName;
        private int idTeam;
        private PlayerList players;
        private int pointEarned;

        /// <summary>
        /// Create a new team
        /// </summary>
        public Team(string team_name, List<Team> teamLists) 
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
            IdTeam = randID;
            PointEarned = 0;
            TeamName = team_name;
            count = 0;
        }
        /// <summary>
        /// Create a new team with setted value of sets
        /// </summary>
        public Team(string tName, int id, PlayerList players, int point)
        {
            this.teamName = tName;
            this.idTeam = id;
            this.players = players;
            this.pointEarned = point;
        }

        /// <summary>
        /// Initializes a TeamName
        /// </summary>
        public string TeamName { get => teamName; set => teamName = value; }


        /// <summary>
        /// Initializes a new istance of Players
        /// </summary>
        public PlayerList PlayersList { get => players; set => players = value; }


        /// <summary>
        /// Initializes a PointEarned
        /// </summary>
        public int PointEarned { get => pointEarned; set => pointEarned = value; }


        /// <summary>
        /// Initializes a IdTeam
        /// </summary>
        public int IdTeam { get => idTeam; set => idTeam = value; }

        /// <summary>
        /// Adds Player to PlayersList
        /// </summary>
        public void AddPlayer(Player player)
        {
            PlayersList.PlayersList.Add(player);
        }
   
        /// <summary>
        /// Remove Player from PlatersList
        /// </summary>
        public void RemovePlayer(int id)
        {
            foreach(var player in PlayersList.PlayersList)
            {
                if(player.ID == id)
                {
                    PlayersList.PlayersList.Remove(player);
                    Count--;
                }
            }
        }

        /// <summary>
        /// Checking if Teams have enough players
        /// !!!!!!!!!!!!!!!!!!
        /// For now 5 players ?? How it many it should be?
        /// </summary>

        public bool DoTheyCanPlay(PlayerList playerList)
        {
            if (playerList.Count == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Count 
        {
            get => count;
            private set => count = value;
        }

    }



}
