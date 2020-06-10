
namespace Tournament.Models
{
    using System.Collections.Generic;
    /// <summary>
    /// Stores instances of Match 
    /// </summary>
    public class MatchList : BaseList<Match>
    {
        /// <summary>
        /// Initalizes a new instance of MatchList
        /// </summary>
        public MatchList()
        {
            List = new List<Match>();
            Count = 0;
        }

        public override void SetObj(object obj)
        {
            MatchList list = (MatchList)obj;
            List = list.List;
            Count = list.Count;
        }
    }
}