using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tournament.Models
{
    public class PlayerList : INotifyPropertyChanged
    {
        private List<Player> players;
        private int count;

        

        /// <summary>
        /// Initializes a new instance of PlayerList.
        /// </summary>
        public PlayerList()
        {
            players = new List<Player>();
            count = 0;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
            private set
                {
                count = value;
                OnPropertyChanged();
                }
        }
        /// <summary>
        /// Gets a List of Players in PlayersList
        /// </summary>
        public List<Player> PlayersList
        {
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
        /// Removes Player object form PlayersList which have same id as given
        /// </summary>
        public void RemovePlayer(int id)
        {
            if (PlayersList.Contains(FindPlayerByID(id)))
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
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach (var player in PlayersList)
                {
                    file.WriteLine("PlayerID: " + player.ID);
                    file.WriteLine("PlayerName: " + player.Name);
                    file.WriteLine("PlayerSurname: " + player.Surname);
                    file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                    file.WriteLine("EndPlayer");
                }
                file.Close();
            }
        }
        /// <summary>
        /// Loads a PlayersList from a file from given path
        /// </summary>
        public void LoadPlayersList(string path, string endstring)
        {
            PlayerList playerList = new PlayerList();
            if(path != null && path != string.Empty)
            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {

                int id = 0;
                string name = string.Empty;
                string surname = string.Empty;
                int points = 0;
                string text = string.Empty;
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
                        case "PlayerPoints:":
                            {
                                points = int.Parse(words[1]);
                                break;
                            }

                        case "EndPlayer":
                            {
                                if (id != 0 && name != string.Empty && surname != string.Empty)
                                {
                                    Player player = new Player(name, surname, null);
                                    player.ID = id;
                                    player.IndividualPoints = points;
                                    playerList.AddPlayer(player);
                                }
                                break;
                            }
                    }

                }
                file.Close();
            }
            Count = playerList.Count;
           players = playerList.PlayersList;
        }



    }



}
