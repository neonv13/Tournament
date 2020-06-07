﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Tournament.Models
{
    public class TournamentList
    {
        public List<Tournaments> TournamentsList { get; set; }
        public int Count { get; set; }


        public TournamentList()
        {
            TournamentsList = new List<Tournaments>();
        }
        public void AddTournament(Tournaments tour)
        {
            TournamentsList.Add(tour);
            Count++;
        }

        public void RemoveTournament(int id)
        {

        }

        public Tournaments FindTournamentByID(int id)
        {
            foreach (var tour in TournamentsList)
            {
                if (tour.ID == id)
                    return tour;
            }
            return null;
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
                tour.RefereeList.SaveRefereeList(path);
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
                        file.WriteLine("TeamAPlayerName: " + player.Name);
                        file.WriteLine("TeamAPlayerSurname: " + player.Surname);
                        file.WriteLine("TeamAPlayerPoints: " + player.IndividualPoints);
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


      
            }
        }

