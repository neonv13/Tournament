using System.Collections.Generic;
using System.IO;

namespace Tournament.Models
{
    public class PlayerList
    {
        public int Count { get; set; }
        public List<Player> PlayersList { get; set; }

        /// <summary>
        /// Initializes a new instance of PlayerList.
        /// </summary>
        public PlayerList()
        {
            PlayersList = new List<Player>();
            Count = 0;
        }

        public PlayerList(PlayerList playerlist)
        {
            PlayersList = playerlist.PlayersList;
            Count = playerlist.Count;
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
        /// Adds a Player to PlayerList
        /// </summary>
        public void AddPlayer(Player Player)
        {
            if (!PlayersList.Contains(Player))
            {
                PlayersList.Add(Player);
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
        /// Saves PlayersList to streamWriter form given path
        /// </summary>
        public void SavePlayersList(StreamWriter streamWriter)
        {
            if (PlayersList.Count > 0)
            {
                streamWriter.WriteLine("StartPlayers");
                foreach (var player in PlayersList)
                {
                    player.SavePlayer(streamWriter);
                }
                streamWriter.WriteLine("EndPlayers");
            }
        }
        /// <summary>
        /// Loads a PlayersList from a streamWriter from given path
        /// </summary>
        public void LoadPlayersList(string path, string endstring)
        {
            if (path != null && path != string.Empty)
                using (System.IO.StreamReader streamWriter = new System.IO.StreamReader(path))
                {

                    int id = 0;
                    string name = string.Empty;
                    string surname = string.Empty;
                    int points = 0;
                    string text = string.Empty;
                    while ((text = streamWriter.ReadLine()) != null && text != "EndPlayers")
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
                                        Player player = new Player(name, surname, null)
                                        {
                                            ID = id,
                                            IndividualPoints = points
                                        };
                                        PlayersList.Add(player);
                                        Count++;
                                    }
                                    break;
                                }
                        }
                    }
                    streamWriter.Close();
                }
        }



    }



}
