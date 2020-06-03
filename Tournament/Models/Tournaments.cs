using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace Tournament.Models

{
    class Tournaments
    {
        /// <summary>
        /// Gets or sets a int matchesPlayed value
        /// </summary>
        public int MatchesPlayed { get; set; }
        /// <summary>
        /// Gets or sets a int teamsCount value
        /// </summary>
        public int TeamCount { get; set; }
        /// <summary>
        /// Gets or sets a string name value
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a GameType game type
        /// </summary>
        public GameType GameType { get; set; }
        /// <summary>
        /// Gets or sets a instance of RefereeList
        /// </summary>
        public RefereeList RefereeList { get; set; }
        /// <summary>
        /// Gets or sets a instance of MatchList
        /// </summary>
        public MatchList MatchHistory { get; set; }
        /// <summary>
        /// Gets or sets a instance of TeamList 
        /// </summary>
        public TeamList TeamList { get; set; }
        /// <summary>
        /// Get/set SemiFinals results
        /// </summary>
        public MatchList Semi { get; set; }
        /// <summary>
        /// Get/set Finals results
        /// </summary>
        public Match Final { get; set; }
        /// <summary>
        /// Initializes a new instance of Tournament
        /// </summary>
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
            Match semi1 = new Match(semi[0], semi[1], RefereeList.RefereesList, MatchRank.Semifinal, semi[0].IdTeam, semi[1].IdTeam, GameType, MatchHistory.GetMatchList);
            Semi.AddMatch(semi1);
            Match semi2 = new Match(semi[2], semi[3], RefereeList.RefereesList, MatchRank.Semifinal, semi[2].IdTeam, semi[3].IdTeam, GameType, MatchHistory.GetMatchList);
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
            Match match = new Match(teamA, teamB, RefereeList.RefereesList,
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
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                file.WriteLine("StartTournamentData");
                file.WriteLine("MatchesPlayed: " + MatchesPlayed);
                file.WriteLine("TeamCount: " + TeamCount);
                file.WriteLine("Name: " + Name);
                file.WriteLine("GameType: " + GameType);

                file.WriteLine("RefereeData: ");
                RefereeList.SaveRefereeList(path);
                file.WriteLine("MatchData: ");
                MatchHistory.SaveMatchList(path);
                file.WriteLine("Teamsdata: ");
                TeamList.SaveTeamsList(path);
                file.WriteLine("SemiData: ");
                Semi.SaveMatchList(path);


                file.WriteLine("StartMatchData");
                file.WriteLine("MatchID: " + Final.MatchID);
                file.WriteLine("MatchRank: " + Final.MatchRank);
                file.WriteLine("GameType: " + Final.GameType);
                file.WriteLine("TeamA_ID: " + Final.TeamA_ID);
                file.WriteLine("TeamB_ID: " + Final.TeamB_ID);
                file.WriteLine("TeamAScore: " + Final.TeamAScore);
                file.WriteLine("TeamBScore: " + Final.TeamBScore);
                if (Final.PlayersTeamA.Count > 0)
                {
                    file.WriteLine("TeamA");
                    foreach (var player in Final.PlayersTeamA)
                    {
                        file.WriteLine("PlayerID: " + player.ID);
                        file.WriteLine("PlayerName: " + player.Name);
                        file.WriteLine("PlayerSurname: " + player.Surname);
                        file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                        file.WriteLine("EndPlayer");
                    }
                    file.WriteLine("EndTeamA");
                }
                if (Final.PlayersTeamB.Count > 0)
                {
                    file.WriteLine("TeamB");
                    foreach (var player in Final.PlayersTeamB)
                    {
                        file.WriteLine("PlayerID: " + player.ID);
                        file.WriteLine("PlayerName: " + player.Name);
                        file.WriteLine("PlayerSurname: " + player.Surname);
                        file.WriteLine("PlayerPoints: " + player.IndividualPoints);
                        file.WriteLine("EndPlayer");
                    }
                    file.WriteLine("EndTeamB");
                }
                if (Final.Referees.Count > 0)
                {
                    file.WriteLine("Referee:");
                    foreach (var referee in Final.Referees)
                    {
                        file.WriteLine("RefereeID: " + referee.ID);
                        file.WriteLine("RefereeName: " + referee.Name);
                        file.WriteLine("RefereeSurname: " + referee.Surname);
                        file.WriteLine("EndReferee");
                    }
                    file.WriteLine("EndReferees");
                }
                file.WriteLine("EndTournamentData");


            }

        }


        public void LoadTournament(string path)
        {
            if (path != null && path != string.Empty)
            {

                int machPlayed;
                int teamCount;
                string name;
                GameType gameType;
                RefereeList refereeList = new RefereeList();
                MatchList matchList = new MatchList();
                TeamList teamList = new TeamList();
                MatchList Semi = new MatchList();
                Match Final = null;


                using (System.IO.StreamReader file = new System.IO.StreamReader(path))
                {
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
                                    var tournament = new Tournaments();


                                    break;
                                }
                        }
                        file.Close();
                    }

                }
            }
        }
    }
}
