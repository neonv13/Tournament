using System;
using System.Collections.Generic;

namespace Tournament.Models
{
    public enum MatchRank
    {
        GroupStage, Semifinal, Final
    }
    public enum GameType
    {
        Volleyball, TugOfWar, DodgeBall
    }
    public class Match
    {
        private List<Referee> referees;
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        private int teamAScore;
        private int teamBScore;
        private int teamA_ID;
        private int teamB_ID;
        private GameType gameType;
        private int matchID;
        private MatchRank matchRank;

        /// <summary>
        /// Initializes a new instance of Match 
        /// </summary> 
        public Match(Team A,
                    Team B,
                    RefereeList referees,
                    MatchRank matchRank, int teamA_ID,
                    int teamB_ID, GameType gameType, List<Match> matchList)
        {

            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                if (matchList != null)
                {
                    foreach (var match in matchList)
                        if (randID == match.MatchID)
                            FreeID = false;
                }
                else
                {
                    MatchID = randID;
                    FreeID = false;
                    break;
                }
            } while (FreeID == false);
            if (FreeID)
                MatchID = randID;

            TeamA = A;
            TeamB = B;
            Referees = referees.RefereesList;
            TeamA_ID = teamA_ID;
            TeamB_ID = teamB_ID;
            GameType = gameType;
            MatchRank = matchRank;
        }

        public Match(Match match)
        {
            referees = match.Referees;
            TeamA = match.TeamA;
            TeamB = match.TeamB;
            teamAScore = match.TeamAScore;
            teamBScore = match.TeamBScore;
            teamA_ID = match.teamA_ID;
            teamB_ID = match.TeamB_ID;
            gameType = match.GameType;
            matchID = match.MatchID;
            matchRank = match.MatchRank;
        }
        /// <summary>
        /// Gets a Referees List  of Match
        /// </summary>
        public List<Referee> Referees
        {
            get => referees;
            private set => referees = value;
        }
        /// <summary>
        /// Adds TeamAScore, TeamBScore and MatchID to Match. 
        /// Use when Match was read from file
        /// and you want to add missing fields 
        /// </summary>
        public void ReadMatch(int teamAScore, int teamBScore, int matchID)
        {
            TeamAScore = teamAScore;
            TeamBScore = teamBScore;
            MatchID = matchID;
        }

        /// <summary>
        /// Gets  a matchID value
        /// </summary>
        public int MatchID
        {
            get => matchID;
            private set => matchID = value;
        }
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
        /// <summary>
        /// Gets a matchRank value
        /// </summary>
        public MatchRank MatchRank
        {
            get => matchRank;
            private set => matchRank = value;
        }
        /// <summary>
        /// Gets a GameType value of match
        /// </summary>
        public GameType GameType
        {
            get => gameType;
            private set => gameType = value;
        }
        /// <summary>
        /// Gets TeamAScore value
        /// </summary>
        public int TeamAScore
        {
            get => teamAScore;
            private set => teamAScore = value;
        }
        /// <summary>
        /// Gets TeamBScore value
        /// </summary>
        public int TeamBScore
        {
            get => teamBScore;
            private set => teamBScore = value;
        }
        /// <summary>
        /// Gets TeamA ID value
        /// </summary>
        public int TeamA_ID
        {
            get => teamA_ID;
            private set => teamA_ID = value;

        }
        /// <summary>
        /// Gets TeamB ID value
        /// </summary>
        public int TeamB_ID
        {
            get => teamB_ID;
            private set => teamB_ID = value;

        }
        
    }



}
