using System;
using System.Collections.Generic;

namespace Tournament.Models
{
    class MatchList
    {
        private List<Match> matchList;
        private int count;

        /// <summary>
        /// Initalizes a new instance of MatchList
        /// </summary>
        public MatchList()
        {
            matchList = new List<Match>();
        }
        /// <summary>
        /// Gets a MatchList value (List<Match>)  
        /// </summary>
        public int Count
        {
            get => count;
            private set => count = value;
        }
        public List<Match> GetMatchList 
        {
            get => matchList;
            private set => matchList = value;
        }
        /// <summary>
        /// Adds a Match instance to MatchList instance
        /// </summary>
        public void AddMatch(Match match) 
        {
            if (!GetMatchList.Contains(match))
                matchList.Add(match);
        }
        /// <summary>
        /// Removes a Match instance form MatchList instance
        /// </summary>
        public void RemoveMatch(Match match)
        {
            if (Count > 0 && GetMatchList.Contains(match))
                matchList.Remove(match);        
        }




        /// <summary>
        /// Saves a MatchList to specified file
        /// </summary>
        public void SaveMatchList(string path) 
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach(var match in GetMatchList)
                {
                    file.WriteLine("StartMatchData");
                    file.WriteLine("MatchID: " + match.MatchID);
                    file.WriteLine("MatchRank: " + match.MatchRank);
                    file.WriteLine("GameType: " + match.GameType);
                    file.WriteLine("TeamA_ID: " + match.TeamA_ID);
                    file.WriteLine("TeamB_ID: " + match.TeamB_ID);
                    file.WriteLine("TeamAScore: " + match.TeamAScore);
                    file.WriteLine("TeamBScore: " + match.TeamBScore);
                    if (match.PlayersTeamA.Count > 0)
                    {
                        file.WriteLine("TeamA:");
                        foreach (var player in match.PlayersTeamA)
                        {
                            file.WriteLine("PlayerID: " + player.ID);
                            file.WriteLine("PlayerName: " + player.Name);
                            file.WriteLine("PlayerSurname: " + player.Surname);
                            file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                            file.WriteLine("EndPlayer");
                        }
                        file.WriteLine("EndTeam");
                    }
                    if (match.PlayersTeamB.Count > 0)
                    {
                        file.WriteLine("TeamB:");
                        foreach (var player in match.PlayersTeamA)
                        {
                            file.WriteLine("PlayerID: " + player.ID);
                            file.WriteLine("PlayerName: " + player.Name);
                            file.WriteLine("PlayerSurname: " + player.Surname);
                            file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                            file.WriteLine("EndPlayer");
                        }
                        file.WriteLine("EndTeam");
                    }
                    if (match.Referees.Count > 0)
                    {
                        file.WriteLine("Referees");
                        foreach (var referee in match.Referees)
                        {
                            file.WriteLine("RefereeID: " + referee.ID);
                            file.WriteLine("RefereeName: " + referee.Name);
                            file.WriteLine("RefereeSurname: " + referee.Surname);
                            file.WriteLine("EndReferee");
                        }
                        file.WriteLine("EndReferees");
                    }
                    file.WriteLine("EndMatchData");
                }
                file.Close();
            };
        }

        public List<Match> LoadMatchList(string path)
        {
            var playersA = new PlayerList();
            var playersB = new PlayerList();
            var referees = new RefereeList();
            MatchRank matchRank = 0;
            int teamA_ID = 0;
            int teamB_ID = 0;
            GameType typeOfGame =0;
            int matchID = 0;
            int teamAScore = 0;
            int teamBScore = 0;

            using (System.IO.StreamReader file = new System.IO.StreamReader(path)) 
            {
                string line;
                while ((line = file.ReadLine() ) != null)
                {
                    string[] words = line.Split(" ");
                        switch (words[0])
                        {
                            case "MatchID:":
                                {
                                    matchID = int.Parse(words[1]);
                                    break;
                                }
                            case "MatchRank:":
                                {
                                    matchRank = (MatchRank)Enum.Parse(typeof(MatchRank),words[1]);
                                    break;
                                }
                            case "GameType:":
                                {
                                    typeOfGame = (GameType)Enum.Parse(typeof(GameType), words[1]);
                                    break;
                                }
                            case "TeamA_ID:":
                                {
                                    teamA_ID = int.Parse(words[1]);
                                    break;
                                }
                            case "TeamB_ID:":
                                {
                                    teamB_ID = int.Parse(words[1]);
                                    break;
                                }
                            case "TeamAScore:":
                                {
                                    teamAScore = int.Parse(words[1]);
                                    break;
                                }
                            case "TeamBScore:":
                                {
                                    teamBScore = int.Parse(words[1]);
                                    break;
                                }
                            case "TeamA:":
                                {
                                    playersA.LoadPlayersList(path);
                                    break;
                                }
                            case "TeamB:":
                                {
                                    playersB.LoadPlayersList(path);
                                    break;
                                }
                            case "Referee:":
                                {
                                    referees.LoadRefereeList(path);
                                    break;
                                }

                            case "EndMatchData":
                                {

                                    var match = new Match(playersA.PlayersList,playersB.PlayersList,referees.RefereesList,matchRank,teamA_ID,teamB_ID,typeOfGame, GetMatchList);
                                    match.ReadMatch(teamAScore,teamBScore,matchID);
                                    matchList.Add(match);
                                    break;
                                }
                        }
                }
                file.Close();
            };
            return matchList;
        }
    
    }



}
