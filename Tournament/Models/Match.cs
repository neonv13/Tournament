using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System;
using System.Collections.Generic;
using System.IO;
using Tournament.Views;

namespace Tournament.Models
{
    
    
    public class Match
    {
        #region Properties
        public int MatchID { get; set; }
        public RefereeList Referees { get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public MatchRanks MatchRanks { get; set; }
        public GameTypes GameTypes { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public int TeamA_ID { get; set; }
        public int TeamB_ID { get; set; }
        #endregion
        #region Creators
        public Match(Team A,Team B,RefereeList referees,MatchRanks matchRank, int teamA_ID,
                     int teamB_ID, GameTypes gameType, List<Match> matchList)
        {
            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                if (matchList.Count > 0)
                {
                    foreach (var match in matchList)
                        if (randID == match.MatchID)
                            FreeID = false;
                }
                else
                {
                    MatchID = randID;
                    break;
                }
            } while (FreeID == false);

            TeamA = A;
            TeamB = B;
            Referees = referees;
            TeamA_ID = teamA_ID;
            TeamB_ID = teamB_ID;
            GameTypes = gameType;
            MatchRanks = matchRank;
        }

        public Match(Match match)
        {
            Referees = match.Referees;
            TeamA = match.TeamA;
            TeamB = match.TeamB;
            TeamAScore = match.TeamAScore;
            TeamBScore = match.TeamBScore;
            TeamA_ID = match.TeamA_ID;
            TeamB_ID = match.TeamB_ID;
            GameTypes = match.GameTypes;
            MatchID = match.MatchID;
            MatchRanks = match.MatchRanks;
        }
        #endregion

        #region Methods
       

        /// <summary>
        /// Simulates results of match and 
        /// returns results(teamAscore,teamBscore) 
        /// </summary>
        public void SymulateGame()
        {
            Random random = new Random();
            switch (random.Next(1, 3))
            {
                case (1):
                    {
                        TeamA.PointEarned = TeamAScore = 3;
                        TeamB.PointEarned = TeamBScore = 0;
                        break;
                    }
                case (2):
                    {
                        TeamA.PointEarned = TeamAScore = 1;
                        TeamB.PointEarned = TeamBScore = 1;
                        break;
                    }
                case (3):
                    {
                        TeamA.PointEarned = TeamAScore = 0;
                        TeamB.PointEarned = TeamBScore = 3;
                        break;
                    }
            }

        }
        #endregion

        #region Save/Load
        /// <summary>
        /// Saves a MatchList to specified streamWriter
        /// </summary>
        public void SaveMatch(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("StartMatchData");
            streamWriter.WriteLine("MatchID: " + MatchID);
            streamWriter.WriteLine("MatchRanks: " + MatchRanks);
            streamWriter.WriteLine("GameTypes: " + GameTypes);
            streamWriter.WriteLine("TeamAScore: " + TeamAScore);
            streamWriter.WriteLine("TeamBScore: " + TeamBScore);
            TeamA.SaveTeam(streamWriter);
            TeamB.SaveTeam(streamWriter);
            Referees.SaveRefereeList(streamWriter);
            streamWriter.WriteLine("EndMatchData");
        }
        #endregion
    }



}
