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


    }

}
