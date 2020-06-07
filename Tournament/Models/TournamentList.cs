using System;
using System.Collections.Generic;
using System.Text;

namespace Tournament.Models
{
    public class TournamentList
    {
        public List<Tournaments> TournamentsList { get; set; }

        public void AddTournament(Tournaments tour)
        {

        }

        public void RemoveTournament(Tournaments tour)
        {

        }
        public void SaveTournaments(string path)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);

            foreach (Tournaments tour in TournamentsList)
            {
                file.WriteLine("StartTournamentData");
                file.WriteLine("MatchesPlayed: " + tour.MatchesPlayed);
                file.WriteLine("TeamCount: " + tour.TeamCount);
                file.WriteLine("Name: " + tour.Name);
                file.WriteLine("GameType: " + tour.GameType);


                // Referee_Data_Start
                file.WriteLine("Referee_Data_Start: ");
                foreach (var referee in tour.RefereeList.RefereesList)
                {
                    file.WriteLine("RefereeID: " + referee.ID);
                    file.WriteLine("RefereeName: " + referee.Name);
                    file.WriteLine("RefereeSurname: " + referee.Surname);
                    file.WriteLine("EndReferee");
                }
                file.WriteLine("Referee_Data_End: ");

                // Matchs_History_Data_Start
                file.WriteLine("Matchs_History_Data_Start: ");
                foreach (var match in tour.MatchHistory.GetMatchList)
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
                foreach (var team in tour.TeamList.TeamsList)
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
                foreach (var match in tour.MatchHistory.GetMatchList)
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
                file.WriteLine("MatchID: " + tour.Final.MatchID);
                file.WriteLine("MatchRank: " + tour.Final.MatchRank);
                file.WriteLine("GameType: " + tour.Final.GameType);
                file.WriteLine("TeamA_ID: " + tour.Final.TeamA_ID);
                file.WriteLine("TeamB_ID: " + tour.Final.TeamB_ID);
                file.WriteLine("TeamAScore: " + tour.Final.TeamAScore);
                file.WriteLine("TeamBScore: " + tour.Final.TeamBScore);

                // Final_Mach_Data_Start
                file.WriteLine("Final_Match_Start: ");

                file.WriteLine("MatchID: " + tour.Final.MatchID);
                file.WriteLine("MatchRank: " + tour.Final.MatchRank);
                file.WriteLine("GameType: " + tour.Final.GameType);
                file.WriteLine("TeamA_ID: " + tour.Final.TeamA_ID);
                file.WriteLine("TeamB_ID: " + tour.Final.TeamB_ID);
                file.WriteLine("TeamAScore: " + tour.Final.TeamAScore);
                file.WriteLine("TeamBScore: " + tour.Final.TeamBScore);
                foreach (var player in tour.Final.TeamA.PlayersList.PlayersList)
                {
                    file.WriteLine("TeamAPlayerID: " + player.ID);
                }
                foreach (var player in tour.Final.TeamB.PlayersList.PlayersList)
                {
                    file.WriteLine("TeamBPlayerID: " + player.ID);
                }
                foreach (var referee in tour.Final.Referees)
                {
                    file.WriteLine("RefereeID: " + referee.ID);
                }
                file.WriteLine("Final_Mach_End: ");

                file.WriteLine("Final_Mach_End: ");


                file.WriteLine("EndTournamentData");
            }

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

