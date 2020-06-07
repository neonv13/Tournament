using System.Collections.Generic;

namespace Tournament.Models
{
    public class PlayerList : BaseList<Player>
    {
        /// <summary>
        /// Initializes a new instance of PlayerList.
        /// </summary>
        public PlayerList()
        {
            List = new List<Player>();
            Count = 0;
        }
    }
}
