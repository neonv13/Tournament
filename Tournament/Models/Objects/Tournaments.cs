using System.Collections.Generic;
using System.Linq;

namespace Tournament.Models

{
    public class Tournaments : BaseObject
    {
        #region Properties
        public GameTypes GameTypes { get; set; }
        public RefereeList RefereeList { get; set; }
        public MatchList MatchHistory { get; set; }
        public MatchList MatchPlanned { get; set; }
        public TeamList TeamList { get; set; }
        public Team SemiA { get; set; }
        public Team SemiB { get; set; }
        public Team SemiC { get; set; }
        public Team SemiD { get; set; }
        public Team FinalA { get; set; }
        public Team FinalB { get; set; }
        public int SemiAResult { get; set; }
        public int SemiBResult { get; set; }
        public int SemiCResult { get; set; }
        public int SemiDResult { get; set; }
        public int FinalAResult { get; set; }
        public int FinalBResult { get; set; }
        public Team Winner { get; set; }
        public List<Team> RankingTeam { get; set; }
        #endregion

        public Tournaments()
        {
            RefereeList = new RefereeList();
            MatchHistory = new MatchList();
            MatchPlanned = new MatchList();
            TeamList = new TeamList();
            SemiA = null;
            SemiB = null;
            SemiC = null;
            SemiD = null;
            FinalA = null;
            FinalB = null;
            Winner = null;
            RankingTeam = new List<Team>();
            SemiAResult = 0;
            SemiBResult = 0;
            SemiCResult = 0;
            SemiDResult = 0;
            FinalAResult = 0;
            FinalBResult = 0;
        }

        public void CreateMatchesPlanned()
        {
            if (TeamList.Count >= 2)
            {
                int i = 0;
                int j;
                Match match;
                foreach (var teamA in TeamList.List)
                {
                    j = 0;
                    foreach (var teamB in TeamList.List)
                    {
                        if (j > i)
                        {
                            match = new Match()
                            {
                                TeamA = teamA,
                                TeamB = teamB,
                                RefereeList = RefereeList,
                                GameTypes = GameTypes,
                                MatchRanks = MatchRanks.GroupStage
                            };

                            MatchPlanned.Add(match);
                        }
                        j++;
                    }
                    i++;
                }
            }
        }

        public bool CreateSemi()
        {
            SortTeamsPoints();
            if (RankingTeam.Count >= 4)
            {
                SemiA = RankingTeam[0];
                SemiB = RankingTeam[1];
                SemiC = RankingTeam[2];
                SemiD = RankingTeam[3];
                return true;
            }
            else
            {
                SemiA = null;
                SemiB = null;
                SemiC = null;
                SemiD = null;
                return false;
            }
        }
        public bool CreateFinal()
        {
            SortTeamsPoints();
            if (RankingTeam.Count >= 2)
            {
                FinalA = RankingTeam[0];
                FinalB = RankingTeam[1];

                return true;
            }
            return false;
        }
        public void SortTeamsPoints()
        {
            RankingTeam = TeamList.List.OrderByDescending(Team => Team.PointEarned).ToList();
        }
        public void SymulateGroupStage()
        {
            CreateMatchesPlanned();
            foreach (var match in MatchPlanned.List)
            {
                match.SymulateGame();
                MatchHistory.Add(match);
                MatchHistory.Count++;
                MatchPlanned.Count--;
            }
            MatchPlanned.List = new List<Match>();
        }
    }
}

