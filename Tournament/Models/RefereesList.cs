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

        /// <summary>
        /// Adds Referee to RefereesList
        /// </summary>
        public void AddReferee(Referee referee)
        {
            referees.Add(referee);
        }
    
    }



}
