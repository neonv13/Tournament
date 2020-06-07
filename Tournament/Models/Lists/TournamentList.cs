using System.Collections.Generic;

namespace Tournament.Models
{
    public class TournamentList : BaseList<Tournaments>
    {
        /// <summary>
        /// Initializes new Instance of TournamentList
        /// </summary>
        public TournamentList()
        {
           List = new List<Tournaments>();
           Count = 0;
        }

    }
}


