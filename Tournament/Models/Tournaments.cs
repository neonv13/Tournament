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
            }
            foreach (Match match in Semi.GetMatchList)
            {
                if (match.TeamAScore > match.TeamBScore)
                {

                }
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


        public void SaveTournaments(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);


            file.WriteLine("StartTournamentData");

            file.WriteLine("MatchesPlayed: " + MatchesPlayed);
            file.WriteLine("TeamCount: " + TeamCount);
            file.WriteLine("Name: " + Name);
            file.WriteLine("GameType: " + GameType);


            // Referee_Data_Start
            file.WriteLine("Referee_Data_Start: ");
            foreach (var referee in RefereeList.RefereesList)
            {
                file.WriteLine("RefereeID: " + referee.ID);
                file.WriteLine("RefereeName: " + referee.Name);
                file.WriteLine("RefereeSurname: " + referee.Surname);
                file.WriteLine("EndReferee");
            }
            file.WriteLine("Referee_Data_End: ");

            // Matchs_History_Data_Start
            file.WriteLine("Matchs_History_Data_Start: ");
            foreach (var match in MatchHistory.GetMatchList)
            {
                file.WriteLine("StartMatchData");
                file.WriteLine("MatchID: " + match.MatchID);
                file.WriteLine("MatchRank: " + match.MatchRank);
                file.WriteLine("GameType: " + match.GameType);
                file.WriteLine("TeamA_ID: " + match.TeamA_ID);
                file.WriteLine("TeamB_ID: " + match.TeamB_ID);
                file.WriteLine("TeamAScore: " + match.TeamAScore);
                file.WriteLine("TeamBScore: " + match.TeamBScore);
                foreach (var player in match.TeamA.PlayersList.PlayersList)
                {
                    file.WriteLine("TeamAPlayerID: " + player.ID);
                }
                foreach (var player in match.TeamB.PlayersList.PlayersList)
                {
                    file.WriteLine("TeamBPlayerID: " + player.ID);
                }
                foreach (var referee in match.Referees)
                {
                    file.WriteLine("RefereeID: " + referee.ID);
                }
                file.WriteLine("EndMatchData");
            }
            file.WriteLine("Matchs_History_Data_Start: ");

            //  Teams_Data_Start
            file.WriteLine("Teams_Data_Start: ");
            foreach (var team in TeamList.TeamsList)
            {
                file.WriteLine("StartTeamsData");
                file.WriteLine("TeamName: " + team.TeamName);
                file.WriteLine("TeamID: " + team.IdTeam);
                file.WriteLine("TeamsPointEarned: " + team.PointEarned);
                if (team != null && team.PlayersList != null && team.PlayersList.Count > 0)
                {
                    file.WriteLine("Players");
                    foreach (var player in team.PlayersList.PlayersList)
                    {
                        file.WriteLine("PlayerID: " + player.ID);
                        file.WriteLine("PlayerName: " + player.Name);
                        file.WriteLine("PlayerSurname: " + player.Surname);
                        file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                        file.WriteLine("EndPlayer");
                    }
                    file.WriteLine("EndTeam");
                }
                file.WriteLine("EndTeamsData");
            }
            file.WriteLine("Teams_Data_End: ");

            //  Semi_Data_Start
            file.WriteLine("Semi_Data_Start: ");
            foreach (var match in MatchHistory.GetMatchList)
            {
                file.WriteLine("StartMatchData");
                file.WriteLine("MatchID: " + match.MatchID);
                file.WriteLine("MatchRank: " + match.MatchRank);
                file.WriteLine("GameType: " + match.GameType);
                file.WriteLine("TeamA_ID: " + match.TeamA_ID);
                file.WriteLine("TeamB_ID: " + match.TeamB_ID);
                file.WriteLine("TeamAScore: " + match.TeamAScore);
                file.WriteLine("TeamBScore: " + match.TeamBScore);
                foreach (var player in match.TeamA.PlayersList.PlayersList)
                {
                    file.WriteLine("TeamAPlayerID: " + player.ID);
                }
                foreach (var player in match.TeamB.PlayersList.PlayersList)
                {
                    file.WriteLine("TeamBPlayerID: " + player.ID);
                }
                foreach (var referee in match.Referees)
                {
                    file.WriteLine("RefereeID: " + referee.ID);
                }
                file.WriteLine("EndMatchData");
            }
            file.WriteLine("Semi_Data_End: ");

            //                                          Missing Player List???

            file.WriteLine("StartMatchData");
            file.WriteLine("MatchID: " + Final.MatchID);
            file.WriteLine("MatchRank: " + Final.MatchRank);
            file.WriteLine("GameType: " + Final.GameType);
            file.WriteLine("TeamA_ID: " + Final.TeamA_ID);
            file.WriteLine("TeamB_ID: " + Final.TeamB_ID);
            file.WriteLine("TeamAScore: " + Final.TeamAScore);
            file.WriteLine("TeamBScore: " + Final.TeamBScore);

            // Final_Mach_Data_Start
            file.WriteLine("Final_Match_Start: ");

            file.WriteLine("MatchID: " + Final.MatchID);
            file.WriteLine("MatchRank: " + Final.MatchRank);
            file.WriteLine("GameType: " + Final.GameType);
            file.WriteLine("TeamA_ID: " + Final.TeamA_ID);
            file.WriteLine("TeamB_ID: " + Final.TeamB_ID);
            file.WriteLine("TeamAScore: " + Final.TeamAScore);
            file.WriteLine("TeamBScore: " + Final.TeamBScore);
            foreach (var player in Final.TeamA.PlayersList.PlayersList)
            {
                file.WriteLine("TeamAPlayerID: " + player.ID);
            }
            foreach (var player in Final.TeamB.PlayersList.PlayersList)
            {
                file.WriteLine("TeamBPlayerID: " + player.ID);
            }
            foreach (var referee in Final.Referees)
            {
                file.WriteLine("RefereeID: " + referee.ID);
            }
            file.WriteLine("Final_Mach_End: ");

            file.WriteLine("Final_Mach_End: ");


            file.WriteLine("EndTournamentData");

            file.Close();
        }


        public void LoadTournament(string path)
        {
            if (path != null && path != string.Empty)
            {

                int machPlayed;
                int teamCount;
                string name = string.Empty;
                GameType gameType = 0;
                RefereeList refereeList = new RefereeList();
                //MatchList matchList = new MatchList();
                TeamList teamList = new TeamList();
                //MatchList Semi;
                //Match Final;


                System.IO.StreamReader file = new System.IO.StreamReader(path);


                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(" ");
                    switch (words[0])
                    {
                        case "MatchesPlayed: ":
                            {
                                machPlayed = int.Parse(words[1]);
                                break;
                            }
                        case "TeamCount: ":
                            {
                                teamCount = int.Parse(words[1]);
                                break;
                            }
                        case "Name: ":
                            {
                                name = words[1];
                                break;
                            }
                        case "GameType: ":
                            {
                                gameType = (GameType)Enum.Parse(typeof(GameType), words[1]);
                                break;
                            }


                        case "EndTournamentData":
                            {
                                var tournament = new Tournaments(teamList, refereeList, gameType, name);


                                break;
                            }
                    }
                    file.Close();
                }


            }
        }
    }
}
