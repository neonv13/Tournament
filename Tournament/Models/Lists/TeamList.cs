
namespace Tournament.Models
{
    using System.Collections.Generic;
    public class TeamList : BaseList<Team>
    {
        /// <summary>
        /// Initializes new Instance of TeamList
        /// </summary>
        public TeamList()
        {
            List = new List<Team>();
            Count = 0;

        }

        public override void SetObj(object obj)
        {
            TeamList list = (TeamList)obj;
            List = list.List;
            Count = list.Count;
        }
    }

}
