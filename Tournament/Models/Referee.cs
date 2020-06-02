using System;
using System.Collections.Generic;

namespace Tournament.Models
{
    public class Referee : Person
    {
        /// <summary>
        /// Initializes a new instance of Referee
        /// </summary>
        public Referee(string name, string surname, List<Referee> refereeList) : base(name, surname, 0)
        {
            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                if (refereeList != null)
                {
                    foreach (var referee in refereeList)
                        if (randID == referee.ID)
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
    }
}
