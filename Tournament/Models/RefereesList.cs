using System.Windows.Documents;

namespace Tournament.Models
{
    using System.Collections.Generic;
    class RefereesList
    {

        private List<Referee> referees;

        /// <summary>
        /// Initializes a new istance of RefereesList
        /// </summary>
        public List<Referee> Referees { get => referees; }
        public IEnumerable<object> RefereeList { get; private set; }

        /// <summary>
        /// Adds Referee to RefereesList
        /// </summary>
        public void AddReferee(Referee referee)
        {
            referees.Add(referee);
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
