using System;
using System.Collections.Generic;
//using System.Windows.Documents;

namespace Tournament.Models

{
    public class Tournaments
    {
 
        public int MatchesPlayed { get; set; }

        public int TeamCount { get; set; }

        public string Name { get; set; }

        public GameType GameType { get; set; }

        public RefereeList RefereeList { get; set; }

        public MatchList MatchHistory { get; set; }

        public TeamList TeamList { get; set; }

        public MatchList Semi { get; set; }

        public Match Final { get; set; }

        public Team Winner { get; set; }
        public Tournaments(TeamList teamList, RefereeList refereeList, GameType gameType, string name)
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
        /// <summary>
        /// Simulates whole Tournament
        /// </summary>
        public void StartSimulateTournament()
        {
            League league = new League(TeamList, RefereeList, GameType, MatchRank.GroupStage);
            MatchHistory.GetMatchList.AddRange(league.SymulateLeague());
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
                            if (comp.IdTeam == points.IdTeam)
                                break;
                            else
                                team = comp;
                        }
                    }
                }
                semi.Add(team);
            }
            Semi = new MatchList();
            Match semi1 = new Match(semi[0], semi[1], RefereeList, MatchRank.Semifinal, semi[0].IdTeam, semi[1].IdTeam, GameType, MatchHistory.GetMatchList);
            Semi.AddMatch(semi1);
            Match semi2 = new Match(semi[2], semi[3], RefereeList, MatchRank.Semifinal, semi[2].IdTeam, semi[3].IdTeam, GameType, MatchHistory.GetMatchList);
            Semi.AddMatch(semi2);
            foreach (Match match in Semi.GetMatchList)
            {
                do
                {
                    match.SymulateGame();
                }
                while (match.TeamAScore != 3 || match.TeamBScore != 3);
            } List<Team> final = new List<Team>();
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
            Final = new Match(final[0], final[1], RefereeList, MatchRank.Final, final[0].IdTeam, final[1].IdTeam, GameType, MatchHistory.GetMatchList);
            do
            {
                Final.SymulateGame();
            }
            while (Final.TeamAScore != 3 || Final.TeamBScore != 3);
            if(Final.TeamAScore > Final.TeamBScore)
            {
                Winner = new Team (Final.TeamA);
            }
            else
            {
                Winner = new Team (Final.TeamB);
            }
        }

        /// <summary>
        /// Symulate a Final or Semifinal results of match.
        /// Returns winner Team value or null if it was draw
        /// </summary>
        public Team FinalOrSemi(Team teamA, Team teamB, MatchRank matchRank)
        {

            Match match = new Match(teamA, teamB, RefereeList,
                matchRank,
                teamA.IdTeam, teamB.IdTeam,
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
