using System;

namespace Tournament.Models
{
    public class Player : Person
    {
        private int individualPoints;

        public Player(string name, string surname, PlayerList playerList) : base(name, surname, 0)
        {
            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                if (playerList.PlayersList != null)
                {
                    foreach (var player in playerList.PlayersList)
                        if (randID == player.ID)
                            FreeID = false;
                }
                else
                {
                    ID = randID;
                    FreeID = false;
                    break;
                }
            } while (FreeID == false);
            if (FreeID)
                ID = randID;
        }
        /// <summary>
        /// Gets or sets IndividualPoints 
        /// </summary>
        public int IndividualPoints {
            get => individualPoints;
            set { 
                individualPoints = value;
                //OnPropertyChanged("IndividualPoints");
            }
        }
    }
}
