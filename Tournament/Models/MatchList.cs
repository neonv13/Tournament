using System;
using System.Collections.Generic;
using System.IO;

namespace Tournament.Models
{
    public class MatchList
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
            set => count = value;
        }
        public List<Match> GetMatchList
        {
            get => matchList;
            set => matchList = value;
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
        /// Saves a MatchList to specified streamWriter
        /// </summary>
        public void SaveMatchList(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("StartMatchesList");
            foreach (var match in GetMatchList)
                match.SaveMatch(streamWriter);
            streamWriter.WriteLine("EndMatchesList");
        }

        public List<Match> LoadMatchList(string path)
        {
            var matchList = new List<Match>();
            var TeamA = new Team(string.Empty, null, 0);
            var TeamB = new Team(string.Empty, null, 0);
            var referees = new RefereeList();
            MatchRanks matchRank = 0;
            int teamA_ID = 0;
            int teamB_ID = 0;
            GameTypes typeOfGame = 0;
            int matchID = 0;
            int teamAScore = 0;
            int teamBScore = 0;

            using (System.IO.StreamReader streamWriter = new System.IO.StreamReader(path))
            {
                string line;
                while ((line = streamWriter.ReadLine()) != null)
                {
                    string[] words = line.Split(" ");
                    if (words.Length > 1)
                        switch (words[0])
                        {
                            case "MatchID":
                                {
                                    matchID = int.Parse(words[1]);
                                    break;
                                }
                            case "MatchRanks":
                                {
                                    matchRank = (MatchRanks)Enum.Parse(typeof(MatchRanks), words[1]);
                                    break;
                                }
                            case "GameTypes":
                                {
                                    typeOfGame = (GameTypes)Enum.Parse(typeof(GameTypes), words[1]);
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
                            case "TeamA":
                                {
                                    string endstring = "End" + words[0];
                                    LoadPlayer(streamWriter, endstring, TeamA.PlayersList);
                                    break;
                                }
                            case "TeamB":
                                {
                                    string endstring = "End" + words[0];
                                    LoadPlayer(streamWriter, endstring, TeamB.PlayersList);
                                    break;
                                }
                            case "Referee":
                                {
                                    referees.LoadRefereeList(path);
                                    break;
                                }

                            case "EndMatchData":
                                {

                                    var match = new Match(TeamA, TeamB, referees, matchRank, teamA_ID, teamB_ID, typeOfGame, GetMatchList);
                                    // nsadadfg
                                    matchList.Add(match);
                                    break;
                                }
                        }

                }
                streamWriter.Close();
            };
            return matchList;
        }

        private void LoadPlayer(StreamReader streamWriter, string endstring, PlayerList playersList)
        {
            throw new NotImplementedException();
        }
    }



}
