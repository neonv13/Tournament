using System;

namespace Tournament.Models
{
    public class Referee : Person
    {
        /// <summary>
        /// Initializes a new instance of Referee
        /// </summary>
        public Referee(string name, string surname, RefereeList refereeList) : base(name, surname, 0)
        {
            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                foreach (var referee in refereeList.RefereesList)
                    if (randID == referee.ID)
                        FreeID = false;
            } while (FreeID == false);
            if (FreeID)
                ID = randID;
        }
    }
}
