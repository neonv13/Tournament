using System.Collections.Generic;
using System.Windows.Documents;

namespace Tournament.Models
{
    class Team
    {

        private string teamName;

        /// <summary>
        /// Initializes a TeamName
        /// </summary>
        public string TeamName { get => teamName; set => teamName = value; }

        private List<Player> players;

        /// <summary>
        /// Initializes a new istance of Players
        /// </summary>
        public List<Player> PlayersList { get => players; }

        private int pointEarned;

        /// <summary>
        /// Initializes a PointEarned
        /// </summary>
        private int PointEarned { get => pointEarned; set => pointEarned = value; }

        private int idTeam;

        /// <summary>
        /// Initializes a IdTeam
        /// </summary>
        public int IdTeam { get => idTeam; set => idTeam = value; }

        /// <summary>
        /// Adds Player to PlayersList
        /// </summary>
        public void AddPlayer(Player player)
        {
            PlayersList.Add(player);
        }
   
        /// <summary>
        /// Remove Player from PlatersList
        /// </summary>
        public void RemovePlayer(int id)
        {
            foreach(var player in PlayersList)
            {
                if(player.ID == id)
                {
                    PlayersList.Remove(player);
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



    }



}
