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
        /// <summary>
        /// Gets or Sets List<Match> value
        /// </summary>
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
                foreach (var match in GetMatchList)
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
                        file.WriteLine("TeamA");
                        foreach (var player in match.PlayersTeamA)
                        {
                            file.WriteLine("PlayerID: " + player.ID);
                            file.WriteLine("PlayerName: " + player.Name);
                            file.WriteLine("PlayerSurname: " + player.Surname);
                            file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                            file.WriteLine("EndPlayer");
                        }
                        file.WriteLine("EndTeamA");
                    }
                    if (match.PlayersTeamB.Count > 0)
                    {
                        file.WriteLine("TeamB");
                        foreach (var player in match.PlayersTeamB)
                        {
                            file.WriteLine("PlayerID: " + player.ID);
                            file.WriteLine("PlayerName: " + player.Name);
                            file.WriteLine("PlayerSurname: " + player.Surname);
                            file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                            file.WriteLine("EndPlayer");
                        }
                        file.WriteLine("EndTeamB");
                    }
                    if (match.Referees.Count > 0)
                    {
                        file.WriteLine("Referee:");
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
        private void LoadPlayer(System.IO.StreamReader file, string endstring, PlayerList players ) 
        {
            int id = 0;
            string name = string.Empty;
            string surname = string.Empty;
            int points = 0;
            string text1;
            while ((text1 = file.ReadLine()) != null && text1 != endstring)
            {
                string[] word = text1.Split(" ");
                switch (word[0])
                {
                    case "PlayerID:":
                        {
                            id = int.Parse(word[1]);
                            break;
                        }
                    case "PlayerName:":
                        {
                            name = word[1];
                            break;
                        }
                    case "PlayerSurname:":
                        {
                            surname = word[1];
                            break;
                        }
                    case "PlayerPoints:":
                        {
                            points = int.Parse(word[1]);
                            break;
                        }

                    case "EndPlayer":
                        {
                            if (id != 0 && name != string.Empty && surname != string.Empty)
                            {
                                Player player = new Player(name, surname, null);
                                player.ID = id;
                                player.IndividualPoints = points;
                                players.AddPlayer(player);
                            }
                            break;
                        }
                }
            }
        }
        public void LoadMatchList(string path)
        {
            var TeamA = new Team(string.Empty,null);
            var TeamB = new Team(string.Empty, null);
            var referees = new RefereeList();
            MatchRank matchRank = 0;
            int teamA_ID = 0;
            int teamB_ID = 0;
            GameType typeOfGame = 0;
            int matchID = 0;
            int teamAScore = 0;
            int teamBScore = 0;

            using (System.IO.StreamReader file = new System.IO.StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
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
                                matchRank = (MatchRank)Enum.Parse(typeof(MatchRank), words[1]);
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
                        case "TeamA":
                            {
                                string endstring = "End" + words[0];
                                LoadPlayer(file, endstring, TeamA.PlayersList);
                                break;
                            }
                        case "TeamB":
                            {
                                string endstring = "End" + words[0];
                                LoadPlayer(file, endstring, TeamB.PlayersList);
                                break;
                            }
                        case "Referee:":
                            {
                                referees.LoadRefereeList(path);
                                break;
                            }

                        case "EndMatchData":
                            {

                                var match = new Match(TeamA, TeamB, referees.RefereesList, matchRank, teamA_ID, teamB_ID, typeOfGame, GetMatchList);
                                match.ReadMatch(teamAScore, teamBScore, matchID);
                                matchList.Add(match);
                                break;
                            }
                    }
                }
                file.Close();
            };
            GetMatchList = matchList;
        }

    }



}
