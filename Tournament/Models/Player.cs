//using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;

namespace Tournament.Models
{
    public class Player : Person
    {
        public int IndividualPoints { get; set; }
        /// <summary>
        /// Creates new Instance of Player 
        /// </summary>
        public Player(string name, string surname, List<Player> playerList) : base(name, surname, 0)
        {
            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                
                if (playerList != null)
                    {
                        foreach (var player in playerList)
                            if (randID == player.ID)
                                FreeID = false;
                    }
                else
                {
                    ID = randID;
                    break;
                }
            } while (FreeID == false);
            if (FreeID)
                ID = randID;
        }
       
      
            
        
    }
}
