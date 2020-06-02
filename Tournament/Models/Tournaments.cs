using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace Tournament.Models

{
    class Tournaments 
    {
        /// <summary>
        /// Gets or sets a int matchesPlayed value
        /// </summary>
        public int MatchesPlayed { get; private set; }
        /// <summary>
        /// Gets or sets a int teamsCount value
        /// </summary>
        public int TeamCount { get; private set; }
        /// <summary>
        /// Gets or sets a string name value
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Gets or sets a GameType game type
        /// </summary>
        public GameType GameType { get; private set; }
        /// <summary>
        /// Gets or sets a instance of RefereeList
        /// </summary>
        public RefereeList RefereeList { get ;private set ; }
        /// <summary>
        /// Gets or sets a instance of MatchList
        /// </summary>
        public MatchList MatchHistory { get ; private set; }
        /// <summary>
        /// Gets or sets a instance of TeamList 
        /// </summary>
        public TeamList TeamList { get; private set; }
        /// <summary>
        /// Initializes a new instance of Tournament
        /// </summary>
        public Tournaments(TeamList teamList, RefereeList refereeList, GameType gameType,string name) 
        {
            TeamList = teamList;
            RefereeList = refereeList;
            GameType = gameType;
            MatchHistory = new MatchList();
            Name = name;
            if (teamList != null)
                TeamCount = teamList.Count;
            else
                TeamCount = 0;
            MatchesPlayed = 0;
        }
        public void StartSimulateTournament()
        { 
            League league = new League(TeamList,RefereeList,GameType,MatchRank.GroupStage);
            MatchHistory.GetMatchList.AddRange(league.SymulateLeague());
        
        
        }

        /// <summary>
        /// Symulate a Final or Semifinal results of match.
        /// Returns winner Team value or null if it was draw
        /// </summary>
        public Team FinalOrSemi(Team teamA, Team teamB,MatchRank matchRank)
        {
            Match match = new Match(teamA.PlayersList,teamB.PlayersList,RefereeList.RefereesList,
                matchRank,
                teamA.IdTeam,teamB.IdTeam,
                GameType, MatchHistory.GetMatchList);

            match.SymulateGame();

            if (match.TeamAScore > match.TeamBScore)
                return teamA;
            else if (match.TeamAScore < match.TeamBScore)
                return teamB;
            else
                return null;
                
        }
    
        
    
    }



}
