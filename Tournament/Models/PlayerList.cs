using System.Collections.Generic;

namespace Tournament.Models
{
    public class PlayerList
    {
        private readonly List<Player> players;
        private int count;
        /// <summary>
        /// Initializes a new instance of PlayerList.
        /// </summary>
        public PlayerList()
        {
            var players = new List<Player>();
            count = 0;

        }
        /// <summary>
        /// Retruns a instance of Player that has given ID
        /// </summary>
        public Player FindPlayerByID(int id)
        {
            foreach (var player in PlayersList)
            {
                if (player.ID == id)
                    return player;
            }
            return null;
        }
        /// <summary>
        /// Gets a value of Players in PlayersList
        /// </summary>
        public int Count
        {
            get => count; 
        }
        /// <summary>
        /// Gets a List of Players in PlayersList
        /// </summary>
        public List<Player> PlayersList { 
            get => players;
        }
        /// <summary>
        /// Adds a Player to PlayerList
        /// </summary>
        public void AddPlayer(Player Player)
        {
            if(!IsThere(Player))
                players.Add(Player);
        }
        /// <summary>
        /// Removes a Player form PlayersList
        /// </summary>
        public void RemovePlayer(Player Player)
        {
            if(IsThere(Player))
                players.Remove(Player);
        }
        /// <summary>
        /// Removes Player object form PlayersList which have same id as given
        /// </summary>
        public void RemovePlayer(int id)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Returns true (if Player already occurs in PlayerList)
        /// or false (Player does not occurs in PlayerList)
        /// </summary>
        public bool IsThere(Player Player) 
        {
            if (players.Contains(Player)) 
                return true;
            else 
                return false;
        }
        /// <summary>
        /// Saves PlayersList to file form given path
        /// </summary>
        public void SavePlayersList(string path)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Loads a PlayersList from a file from given path
        /// </summary>
        public void LoadPlayersList(string path)
        {
            throw new System.NotImplementedException();
        }


    }



}
