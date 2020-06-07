namespace Tournament.Models
{
    using System.Collections.Generic;
    using System.IO;

    public class RefereeList : BaseList<Referee>
    {
        /// <summary>
        /// Initializes a new istance of RefereeList
        /// </summary>
        public RefereeList()
        {
           List = new List<Referee>();
           Count = 0;
        }
       
    }
}
