using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System;
using System.Collections.Generic;
using System.IO;
using Tournament.Views;

namespace Tournament.Models
{
    public class Match : BaseObject
    {
        #region Properties
        public RefereeList RefereeList { get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public MatchRanks MatchRanks { get; set; }
        public GameTypes GameTypes { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public int TeamA_ID { get; set; }
        public int TeamB_ID { get; set; }
        #endregion

        public Match() 
        {
            RefereeList = new RefereeList();
            TeamA = new Team();
            TeamB = new Team();
            ID = -1;
        }



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
                        TeamAScore = 3;
                        TeamBScore = 0;
                        TeamA.PointEarned += TeamAScore;
                        TeamB.PointEarned += TeamBScore;
                        break;
                    }
                case (2):
                    {
                        TeamAScore = 1;
                        TeamBScore = 1;
                        TeamA.PointEarned += TeamAScore;
                        TeamB.PointEarned += TeamBScore;
                        break;
                    }
                case (3):
                    {
                        TeamAScore = 0;
                        TeamBScore = 3;
                        TeamA.PointEarned += TeamAScore;
                        TeamB.PointEarned += TeamBScore;
                        break;
                    }
            }

        }
        #endregion

    }



}
