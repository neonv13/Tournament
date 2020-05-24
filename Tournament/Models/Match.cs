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
        private List<Referee> referees;
        private List<Player> playersTeamA;
        private List<Player> playersTeamB;
        private int teamAScore;
        private int teamBScore;
        private int teamA_ID;
        private int teamB_ID;
        private GameType typeOfGame;
        private int matchID;
        private MatchRank matchRank;
        /// <summary>
        /// Initializes a new instance of Match 
        /// </summary> 
        public Match(List<Player> playersTeamA,
                    List<Player> playersTeamB,
                    List<Referee> referees,
                    MatchRank matchRank, int teamA_ID,
                    int teamB_ID, GameType gameType)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Gets a Referees List  of Match
        /// </summary>
        public List<Referee> Referees
        {
            get => referees;
            private set => referees = value;
        }
        /// <summary>
        /// Adds TeamAScore, TeamBScore and MatchID to Match. 
        /// Use when Match was read from file
        /// and you want to add missing fields 
        /// </summary>
        public void ReadMatch(int teamAScore,int teamBScore, int matchID)
        {
            TeamAScore = teamAScore;
            TeamBScore = teamBScore;
            MatchID = matchID;
        }

        /// <summary>
        /// Gets  a matchID value
        /// </summary>
        public int MatchID
        {
            get => matchID;
            private set => matchID = value;
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
            get => typeOfGame;
        }
        /// <summary>
        /// Gets TeamAScore value
        /// </summary>
        public int TeamAScore
        {
            get => teamAScore;
            private set=> teamAScore = value;
        }
        /// <summary>
        /// Gets TeamBScore value
        /// </summary>
        public int TeamBScore
        {
            get => teamBScore;
            private set => teamBScore = value;
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

    }



}
