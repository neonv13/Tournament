using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System;
using System.Collections.Generic;
using System.IO;
using Tournament.Models.Enums;
using Tournament.Views;

namespace Tournament.Models
{
    public class Match : BaseObject
    {
        #region Properties
        public RefereeList RefereeList { get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public PlayerList PlayersPlayingInTeamA { get; set; }
        public PlayerList PlayersPlayingInTeamB { get; set; }
        public MatchRanks MatchRanks { get; set; }
        public GameTypes GameTypes { get; set; }
        public Past_Future Past_Future { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        
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

    }



}
