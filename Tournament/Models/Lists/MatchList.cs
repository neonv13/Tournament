using System;
using System.Collections.Generic;
using System.IO;

namespace Tournament.Models
{
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
    }
}