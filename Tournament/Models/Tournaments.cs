using System;
using System.Collections.Generic;
using System.IO;
//using System.Windows.Documents;

namespace Tournament.Models

{
    public class Tournaments
    {
        public int ID { get; set; }
        public int MatchesPlayed { get; set; }

        public int NumberOfTeams { get; set; }

        public string Name { get; set; }

        public GameTypes GameTypes { get; set; }

        public RefereeList RefereeList { get; set; }

        public MatchList MatchHistory { get; set; }

        public TeamList TeamList { get; set; }

        public MatchList Semi { get; set; }

        public Match Final { get; set; }

        public Team Winner { get; set; }
        public Tournaments(TeamList teamList, RefereeList refereeList, GameTypes gameType, string name, TournamentList tournamentList)
        {
            TeamList = teamList;
            RefereeList = refereeList;
            GameTypes = gameType;
            MatchHistory = new MatchList();
            Name = name;
            NumberOfTeams = teamList.Count;
            MatchesPlayed = 0;

            Random random = new Random();
            int randID;
            bool FreeID = true;
            do
            {
                randID = random.Next(0, 1000);
                if (tournamentList.Count > 0)
                {
                    foreach (var tour in tournamentList.TournamentsList)
                        if (randID == tour.ID)
                            FreeID = false;
                }
                else
                {
                    ID = randID;
                    break;
                }
            } while (FreeID == false);
            if (FreeID)
                ID = randID;
        }
        /// <summary>
        /// Simulates whole Tournament
        /// </summary>
        public void StartSimulateTournament()
        {
            League league = new League(TeamList, RefereeList, GameTypes, MatchRanks.GroupStage);
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
                GameTypes, MatchHistory.GetMatchList);

            match.SymulateGame();

            if (match.TeamAScore > match.TeamBScore)
                return teamA;
            else if (match.TeamAScore < match.TeamBScore)
                return teamB;
            else
                return null;

        }
        public void SaveTournament(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("TournamentDataStart");
            streamWriter.WriteLine("Name: " + Name);
            streamWriter.WriteLine("GameTypes: " + GameTypes);
            streamWriter.WriteLine("MatchesPlayed: " + MatchesPlayed);
            streamWriter.WriteLine("NumberOfTeams: " + NumberOfTeams);

            #region Referees
            streamWriter.WriteLine("Referee_Data_Start");
            RefereeList.SaveRefereeList(streamWriter);
            streamWriter.WriteLine("Referee_Data_End");
            #endregion


            #region MatchList
            streamWriter.WriteLine("Matchs_History_Data_Start");
            MatchHistory.SaveMatchList(streamWriter);
            streamWriter.WriteLine("Matchs_History_Data_End");
            #endregion

            streamWriter.WriteLine("Teams_Data_Start: ");
            TeamList.SaveTeamsList(streamWriter);
            streamWriter.WriteLine("Teams_Data_End: ");

            //  Semi_Data_Start
            streamWriter.WriteLine("Semi_Data_Start: ");
            foreach (var match in MatchHistory.GetMatchList)
            {
                streamWriter.WriteLine("StartMatchData");
                streamWriter.WriteLine("MatchID: " + match.MatchID);
                streamWriter.WriteLine("MatchRanks: " + match.MatchRanks);
                streamWriter.WriteLine("GameTypes: " + match.GameTypes);
                streamWriter.WriteLine("TeamA_ID: " + match.TeamA_ID);
                streamWriter.WriteLine("TeamB_ID: " + match.TeamB_ID);
                streamWriter.WriteLine("TeamAScore: " + match.TeamAScore);
                streamWriter.WriteLine("TeamBScore: " + match.TeamBScore);
                foreach (var player in match.TeamA.PlayersList.PlayersList)
                {
                    streamWriter.WriteLine("TeamAPlayerID: " + player.ID);
                }
                foreach (var player in match.TeamB.PlayersList.PlayersList)
                {
                    streamWriter.WriteLine("TeamBPlayerID: " + player.ID);
                }
                foreach (var referee in match.Referees)
                {
                    streamWriter.WriteLine("RefereeID: " + referee.ID);
                }
                streamWriter.WriteLine("EndMatchData");
            }
            streamWriter.WriteLine("Semi_Data_End: ");

            //                                          Missing Player List???

            streamWriter.WriteLine("StartMatchData");
            streamWriter.WriteLine("MatchID: " + Final.MatchID);
            streamWriter.WriteLine("MatchRanks: " + Final.MatchRanks);
            streamWriter.WriteLine("GameTypes: " + Final.GameTypes);
            streamWriter.WriteLine("TeamA_ID: " + Final.TeamA_ID);
            streamWriter.WriteLine("TeamB_ID: " + Final.TeamB_ID);
            streamWriter.WriteLine("TeamAScore: " + Final.TeamAScore);
            streamWriter.WriteLine("TeamBScore: " + Final.TeamBScore);

            // Final_Mach_Data_Start
            streamWriter.WriteLine("Final_Match_Start: ");

            streamWriter.WriteLine("MatchID: " + Final.MatchID);
            streamWriter.WriteLine("MatchRanks: " + Final.MatchRanks);
            streamWriter.WriteLine("GameTypes: " + Final.GameTypes);
            streamWriter.WriteLine("TeamA_ID: " + Final.TeamA_ID);
            streamWriter.WriteLine("TeamB_ID: " + Final.TeamB_ID);
            streamWriter.WriteLine("TeamAScore: " + Final.TeamAScore);
            streamWriter.WriteLine("TeamBScore: " + Final.TeamBScore);
            foreach (var player in Final.TeamA.PlayersList.PlayersList)
            {
                streamWriter.WriteLine("TeamAPlayerID: " + player.ID);
            }
            foreach (var player in Final.TeamB.PlayersList.PlayersList)
            {
                streamWriter.WriteLine("TeamBPlayerID: " + player.ID);
            }
            foreach (var referee in Final.Referees)
            {
                streamWriter.WriteLine("RefereeID: " + referee.ID);
            }
            streamWriter.WriteLine("Final_Mach_End: ");

            streamWriter.WriteLine("Final_Mach_End: ");


            streamWriter.WriteLine("TournamentDataEnd");
        }



    }
}

