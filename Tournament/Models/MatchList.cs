using System.Collections.Generic;

namespace Tournament.Models
{
    class MatchesList
    {
        private List<Match> matchList;

        /// <summary>
        /// Initalizes a new instance of MatchList
        /// </summary>
        public MatchesList()
        {
            var matchList = new List<Match>();
        }
        /// <summary>
        /// Gets a MatchList value (List<Match>)  
        /// </summary>
        public List<Match> GetMatchesList 
        {
            get => matchList;
        }
        /// <summary>
        /// Adds Match to MatchList instance
        /// </summary>
        public void AddMatch(Match match) 
        {
            if (!GetMatchesList.Contains(match))
                matchList.Add(match);
        }
        /// <summary>
        /// Saves MatchList to specified file
        /// </summary>
        public void SaveMatchList(string path) 
        {
            throw new System.NotImplementedException();
        }

        public List<Match> LoadMatchesList(string path)
        {
            throw new System.NotImplementedException(); 
           
        }
    
    }



}
