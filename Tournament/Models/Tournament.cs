using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace Tournament.Models

{
    class Tournament 
    {
        MatchList matchHistory;
        TeamList teamList;
        RefereeList refereeList;
        GameType gameType;

        public Tournament(TeamList teamList, RefereeList refereeList, GameType gameType) 
        { 
            League league = new League(teamList,refereeList,gameType,MatchRank.GroupStage);

            matchHistory.GetMatchList.AddRange(league.SymulateLeague());
        }

            
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
