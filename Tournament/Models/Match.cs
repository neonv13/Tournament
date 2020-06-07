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
        public int MatchID { get; set; }

        public List<Referee> Referees { get; set; }

        public Team TeamA { get; set; }
        public Team TeamB { get; set; }

        public MatchRank MatchRank { get; set; }

        public GameType GameType { get; set; }

        public int TeamAScore { get; set; }

        public int TeamBScore { get; set; }

        public int TeamA_ID { get; set; }

        public int TeamB_ID { get; set; }


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
            Referees = match.Referees;
            TeamA = match.TeamA;
            TeamB = match.TeamB;
            TeamAScore = match.TeamAScore;
            TeamBScore = match.TeamBScore;
            TeamA_ID = match.TeamA_ID;
            TeamB_ID = match.TeamB_ID;
            GameType = match.GameType;
            MatchID = match.MatchID;
            MatchRank = match.MatchRank;
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
        /// Saves a MatchList to specified file
        /// </summary>
        public void SaveMatchList(string path)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                    file.WriteLine("StartMatchData");
                    file.WriteLine("MatchID: " + MatchID);
                    file.WriteLine("MatchRank: " + MatchRank);
                    file.WriteLine("GameType: " + GameType);
                    file.WriteLine("TeamA_ID: " + TeamA_ID);
                    file.WriteLine("TeamB_ID: " + TeamB_ID);
                    file.WriteLine("TeamAScore: " + TeamAScore);
                    file.WriteLine("TeamBScore: " + TeamBScore);
                    foreach (var player in TeamA.PlayersList.PlayersList)
                    {
                        file.WriteLine("TeamAPlayerID: " + player.ID);
                        file.WriteLine();
                    }
                    foreach (var player in TeamB.PlayersList.PlayersList)
                    {
                        file.WriteLine("TeamBPlayerID: " + player.ID);
                    }
                    foreach (var referee in Referees)
                    {
                        file.WriteLine("RefereeID: " + referee.ID);
                    }
                    file.WriteLine("EndMatchData");
                file.Close();
            };
        }

    }



}
