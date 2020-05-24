using System.Collections.Generic;

namespace Tournament.Models
{
    public class PlayerList
    {
        private List<Player> players;
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
            private set => count = value;
        }
        /// <summary>
        /// Gets a List of Players in PlayersList
        /// </summary>
        public List<Player> PlayersList { 
            get => players;
            private set => players = value;
        }
        /// <summary>
        /// Adds a Player to PlayerList
        /// </summary>
        public void AddPlayer(Player Player)
        {
            if (!PlayersList.Contains(Player))
            {
                players.Add(Player);
                Count++;
            }
        }
        /// <summary>
        /// Removes a Player form PlayersList
        /// </summary>
        public void RemovePlayer(Player Player)
        {
            if(Count > 0 && PlayersList.Contains(Player))
                players.Remove(Player);
        }
        /// <summary>
        /// Removes Player object form PlayersList which have same id as given
        /// </summary>
        public void RemovePlayer(int id)
        {
            if (Count > 0 && PlayersList.Contains(FindPlayerByID(id)))
            {
                PlayersList.Remove(FindPlayerByID(id));
                Count--;
            }
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
