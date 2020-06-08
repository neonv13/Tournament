using System;
using System.Collections.Generic;
using System.IO;

namespace Tournament.Models

{
    public class Tournaments : BaseObject
    {
        public int MatchesPlayed { get; set; }
        public int NumberOfTeams { get; set; }
        public GameTypes GameTypes { get; set; }
        public RefereeList RefereeList { get; set; }
        public MatchList MatchHistory { get; set; }
        public MatchList MatchPlanned { get; set; }
        public TeamList TeamList { get; set; }
        public MatchList Semi { get; set; }
        public Match Final { get; set; }
        public Team Winner { get; set; }


        public Tournaments() 
        {
            MatchesPlayed = 0;
            NumberOfTeams = 0;
            RefereeList = new RefereeList();
            MatchHistory = new MatchList();
            MatchPlanned = new MatchList();
            TeamList= new TeamList();
            Semi = new MatchList();
            Final = new Match();
            Winner = new Team();
        }
        /*
        public void StartSimulateTournament()
        {
            League league = new League(TeamList, RefereeList, GameTypes, MatchRanks.GroupStage);
            MatchHistory.List.AddRange(league.SymulateLeague());
            List<Team> semi = new List<Team>();
            for (int i = 0; i < 4; ++i)
            {
                Team team = TeamList.TeamsList[0];
                foreach (Team comp in TeamList.TeamsList)
                {
                    if (team.PointEarned < comp.PointEarned)
                    {
                        foreach (Team points in semi)
                        {
                            if (comp.IDTeam == points.IDTeam)
                                break;
                            else
                                team = comp;
                        }
                    }
                }
                semi.Add(team);
            }
            Semi = new MatchList();
            Match semi1 = new Match(semi[0], semi[1], RefereeList, MatchRanks.Semifinal, semi[0].IDTeam, semi[1].IDTeam, GameTypes, MatchHistory.GetMatchList);
            Semi.AddMatch(semi1);
            Match semi2 = new Match(semi[2], semi[3], RefereeList, MatchRanks.Semifinal, semi[2].IDTeam, semi[3].IDTeam, GameTypes, MatchHistory.GetMatchList);
            Semi.AddMatch(semi2);
            foreach (Match match in Semi.GetMatchList)
            {
                do
                {
                    match.SymulateGame();
                }
                while (match.TeamAScore != 3 || match.TeamBScore != 3);
            }
            List<Team> final = new List<Team>();
            foreach (Match match in Semi.GetMatchList)
            {
                if (match.TeamAScore > match.TeamBScore)
                {
                    final.Add(match.TeamA);
                }
                else
                {
                    final.Add(match.TeamB);
                }
            }
            Final = new Match(final[0], final[1], RefereeList, MatchRanks.Final, final[0].IDTeam, final[1].IDTeam, GameTypes, MatchHistory.GetMatchList);
            do
            {
                Final.SymulateGame();
            }
            while (Final.TeamAScore != 3 || Final.TeamBScore != 3);
            if (Final.TeamAScore > Final.TeamBScore)
            {
                Winner = new Team(Final.TeamA);
            }
            else
            {
                Winner = new Team(Final.TeamB);
            }
        }

        /// <summary>
        /// Symulate a Final or Semifinal results of match.
        /// Returns winner Team value or null if it was draw
        /// </summary>
        public Team FinalOrSemi(Team teamA, Team teamB, MatchRanks matchRank)
        {

            Match match = new Match(teamA, teamB, RefereeList,
                matchRank,
                teamA.IDTeam, teamB.IDTeam,
                GameTypes, MatchHistory.List);

            match.SymulateGame();

            if (match.TeamAScore > match.TeamBScore)
                return teamA;
            else if (match.TeamAScore < match.TeamBScore)
                return teamB;
            else
                return null;

        }
        
        */


    }
}

