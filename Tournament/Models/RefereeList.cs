using System.Windows.Documents;

namespace Tournament.Models
{
    using System.Collections.Generic;
    public class RefereeList
    {

        private List<Referee> referees;

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

    }



}
