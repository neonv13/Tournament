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
        private List<Player> players;
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
        public Match(List<Player> player,List<Referee> referees, MatchRank matchRank,int teamA_ID,int teamB_ID, GameType gameType) 
        {
            throw new System.NotImplementedException();
        }
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
    }



}
