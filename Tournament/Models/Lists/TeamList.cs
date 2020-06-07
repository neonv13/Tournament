using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Tournament.Models
{
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
