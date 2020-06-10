using System.Collections.Generic;
using System.Linq;

namespace Tournament.Models

{
    public class Tournaments : BaseObject
    {
        #region Properties
        public bool WasFinalCreated { get; set; }
        public bool WasSemiCreated { get; set; }
        public bool WasGroupStageSymulated { get; set; }
        public bool WasGroupStageCreated { get; set; }
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
            WasGroupStageSymulated = false;
            WasGroupStageCreated = false;
            WasSemiCreated = false;
            WasFinalCreated = false;
        }

        public void CreateGroupStage()
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
                WasGroupStageCreated = true;
            }
        }

        public void CreateSemi()
        {
            SortTeamsPoints();
            if (RankingTeam.Count >= 4)
            {
                Match match = new Match()
                {
                    TeamA = RankingTeam[0],
                    TeamB = RankingTeam[1],
                    RefereeList = RefereeList,
                    GameTypes = GameTypes,
                    MatchRanks = MatchRanks.Semifinal
                };
                MatchPlanned.Add(match);

                match = new Match()
                {
                    TeamA = RankingTeam[2],
                    TeamB = RankingTeam[3],
                    RefereeList = RefereeList,
                    GameTypes = GameTypes,
                    MatchRanks = MatchRanks.Semifinal
                };
                MatchPlanned.Add(match);
                WasSemiCreated = true;
            }
        }
        public void CreateFinal()
        {
            SortTeamsPoints();
            if (RankingTeam.Count >= 2)
            {
                FinalA = RankingTeam[0];
                FinalB = RankingTeam[1];
                Match match = new Match()
                {
                    TeamA = FinalA,
                    TeamB = FinalB,
                    RefereeList = RefereeList,
                    GameTypes = GameTypes,
                    MatchRanks = MatchRanks.Final
                };
                MatchPlanned.Add(match);
                WasFinalCreated = true;
            }
        }
        public void SortTeamsPoints()
        {
            RankingTeam = TeamList.List.OrderByDescending(Team => Team.PointEarned).ToList();
        }
        public void SymulateGroupStage()
        {
            foreach (var match in MatchPlanned.List)
            {
                match.SymulateGame();
                MatchHistory.Add(match);
                MatchPlanned.Count--;
            }

            MatchPlanned.List = new List<Match>();
            WasGroupStageSymulated = true;
            SortTeamsPoints();
            if (TeamList.Count >= 4)
            {
                SemiA = RankingTeam[0];
                SemiB = RankingTeam[1];
                SemiC = RankingTeam[2];
                SemiD = RankingTeam[3];
            }

            else if (TeamList.Count >= 2)
            {
                FinalA = RankingTeam[0];
                FinalB = RankingTeam[1];
            }
        }
    }
}

