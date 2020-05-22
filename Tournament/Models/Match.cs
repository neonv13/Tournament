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
    class Match
    {
        private readonly List<Referee> referees;
        private readonly List<Player> playersTeamA;
        private readonly List<Player> playersTeamB;
        private int teamAScore;
        private int teamBScore;
        private readonly int teamA_ID;
        private readonly int teamB_ID;
        private readonly GameType typeOfGame;
        private readonly int matchID;
        private readonly MatchRank matchRank;
        /// <summary>
        /// Initializes a new instance of Match 
        /// </summary>
        public Match(List<Player> playersTeamA,
                    List<Player>playersTeamB,
                    List<Referee> referees,
                    MatchRank matchRank, int teamA_ID,
                    int teamB_ID, GameType gameType)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Simulates results of match and 
        /// returns results(teamAscore,teamBscore) 
        /// </summary>
        public void SymulateGame()
        {
            throw new System.NotImplementedException();

        }
        /// <summary>
        /// Gets a matchRank value
        /// </summary>
        public MatchRank MatchRank
        {
            get => matchRank;
        }
        /// <summary>
        /// Gets a GameType value of match
        /// </summary>
        public GameType GameType
        {
            get => GameType;
        }
        /// <summary>
        /// Gets TeamAScore value
        /// </summary>
        public int TeamAScore
        {
            get => teamAScore;
        }
        /// <summary>
        /// Gets TeamBScore value
        /// </summary>
        public int TeamBScore
        {
            get => teamBScore;
        }
        /// <summary>
        /// Gets TeamA ID value
        /// </summary>
        public int TeamA_ID
        {
            get => teamA_ID;
        }
        /// <summary>
        /// Gets TeamB ID value
        /// </summary>
        public int TeamB_ID
        {
            get => teamB_ID;
        }
        /// <summary>
        /// Gets a List<Players> of TeamA  
        /// </summary>
        public List<Player> PlayersTeamA
        {
            get => playersTeamA;
        }
        /// <summary>
        /// Gets a List<Players> of TeamB
        /// </summary>
        public List<Player> PlayersTeamB
        {
            get => playersTeamB;
        }
        //commitgitr 

    }



}
