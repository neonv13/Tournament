
namespace Tournament.Models
{
    using System.Collections.Generic;
    /// <summary>
    /// Stores instances of Player 
    /// </summary
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
        public override void SetObj(object obj)
        {
            PlayerList list = (PlayerList)obj;
            List = list.List;
            Count = list.Count;
        }
    }
}
