using System.Windows.Documents;

namespace Tournament.Models
{
    using System.Collections.Generic;
    using System.Threading;

    public class RefereeList
    {

        private List<Referee> referees;
        private int count;

        /// <summary>
        /// Initializes a new istance of RefereesList
        /// </summary>
        public List<Referee> RefereesList { get => referees;  }

        /// <summary>
        /// Adds Referee to RefereesList
        /// </summary>
        
        public void AddReferee(Referee referee)
        {
            RefereesList.Add(referee);
        }

        /// <summary>
        /// Initializes a Count
        /// </summary>
        private int Count { get => count; set => count = value; }

        /// <summary>
        /// Retruns a instance of Player that has given ID
        /// </summary>
        public Referee FindRefeereByID(int id)
        {
            foreach (var referee in referees)
            {
                if (referee.ID == id)
                    return referee;
            }
            return null;
        }

        /// <summary>
        /// Removes Referee from RefereesList by ID
        /// </summary>
        public void RemoveReferee(int id)
        {
            foreach (var referee in referees)
            {
                if (referee.ID == id)
                {
                    RefereesList.Remove(referee);
                }
            }
        }

        /// <summary>
        /// Removes Referee from RefereesList by Surname and Name
        /// </summary>
        public void RemoveReferee(string surName, string name)
        {
            foreach (var referee in referees)
            {
                if (referee.Surname == surName && referee.Name == name)
                {
                    RefereesList.Remove(referee);
                }
            }
        }


    }



}
