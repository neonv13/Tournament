using System;
using System.Collections.Generic;

namespace Tournament.Models
{
    class MatchList
    {
        private List<Match> matchList;

        /// <summary>
        /// Initalizes a new instance of MatchList
        /// </summary>
        public MatchList()
        {
            var matchList = new List<Match>();
        }
        /// <summary>
        /// Gets a MatchList value (List<Match>)  
        /// </summary>
        public List<Match> GetMatchList 
        {
            get => matchList;
        }
        /// <summary>
        /// Adds Match to MatchList instance
        /// </summary>
        public void AddMatch(Match match) 
        {
            if (!GetMatchList.Contains(match))
                matchList.Add(match);
        }
        /// <summary>
        /// Saves MatchList to specified file
        /// </summary>
        public void SaveMatchList(string path, MatchList MatchList) 
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach(var match in MatchList.GetMatchList)
                {
                    file.WriteLine("StartMatchData");
                    file.WriteLine("MatchID: " + match.MatchID);
                    file.WriteLine("MatchRank: " + match.MatchRank);
                    file.WriteLine("GameType: " + match.GameType);
                    file.WriteLine("TeamA_ID: " + match.TeamA_ID);
                    file.WriteLine("TeamB_ID: " + match.TeamB_ID);
                    file.WriteLine("TeamAScore: " + match.TeamAScore);
                    file.WriteLine("TeamBScore: " + match.TeamBScore);
                    foreach (var player in match.PlayersTeamA)
                    {
                        file.WriteLine("TeamAPlayerID: " + player.ID);
                    }
                    foreach (var player in match.PlayersTeamB)
                    {
                        file.WriteLine("TeamBPlayerID: " + player.ID);
                    }
                    foreach (var referee in match.Referees)
                    {
                        file.WriteLine("RefereeID: " + referee.ID);
                    }
                    file.WriteLine("EndMatchData");
                }
                file.Close();
            };
        }

        public List<Match> LoadMatchList(string path, PlayerList playersList, RefereesList refereesList)
        {
            var matchList = new List<Match>();
            var playersA = new List<Player>();
            var playersB = new List<Player>();
            var referees = new List<Referee>();
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
                    if(words.Length > 1)
                        switch (words[0])
                        {
                            case "MatchID":
                                {
                                    matchID = int.Parse(words[1]);
                                    break;
                                }
                            case "MatchRank":
                                {
                                    matchRank = (MatchRank)Enum.Parse(typeof(MatchRank),words[1]);
                                    break;
                                }
                            case "GameType":
                                {
                                    typeOfGame = (GameType)Enum.Parse(typeof(GameType), words[1]);
                                    break;
                                }
                            case "TeamA_ID":
                                {
                                    teamA_ID = int.Parse(words[1]);
                                    break;
                                }
                            case "TeamB_ID":
                                {
                                    teamB_ID = int.Parse(words[1]);
                                    break;
                                }
                            case "TeamAScore":
                                {
                                    teamAScore = int.Parse(words[1]);
                                    break;
                                }
                            case "TeamBScore":
                                {
                                    teamBScore = int.Parse(words[1]);
                                    break;
                                }
                            case "TeamAPlayerID":
                                {
                                    playersA.Add(playersList.FindPlayerByID(int.Parse(words[1])));
                                    break;
                                }
                            case "TeamBPlayerID":
                                {
                                    playersB.Add(playersList.FindPlayerByID(int.Parse(words[1])));
                                    break;
                                }
                            case "Referee":
                                {
                                    referees.Add(refereesList.FindRefeereByID(int.Parse(words[1])));
                                    break;
                                }

                            case "EndMatchData":
                                {

                                    var match = new Match(playersA,playersB,referees,matchRank,teamA_ID,teamB_ID,typeOfGame);
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
