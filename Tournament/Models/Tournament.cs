using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace Tournament.Models

{
    class Tournament 
    {
        MatchList matchHistory;
        RefereeList refereeList;
        GameType gameType;
        /// <summary>
        /// Initializes a new Instance of Tournament
        /// </summary>
        public Tournament(TeamList teamList, RefereeList refereeList, GameType gameType) 
        { 
            League league = new League(teamList,refereeList,gameType,MatchRank.GroupStage);

            matchHistory.GetMatchList.AddRange(league.SymulateLeague());
        }

        /// <summary>
        /// Symulate a Final or Semifinal results of match.
        /// Returns winner Team value or null if it was draw
        /// </summary>
        public Team FinalOrSemi(Team teamA, Team teamB,MatchRank matchRank)
        {
            Match match = new Match(teamA.PlayersList,teamB.PlayersList,refereeList.RefereesList,
                matchRank,
                teamA.IdTeam,teamB.IdTeam,
                gameType, matchHistory.GetMatchList);

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
