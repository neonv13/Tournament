
namespace Tournament.Models
{
    using System.Collections.Generic;
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

        public override void SetObj(object obj)
        {
            TournamentList list = (TournamentList)obj;
            List = list.List;
            Count = list.Count;
        }
    }
}


