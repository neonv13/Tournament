namespace Tournament.Models
{
    public class Team : BaseObject
    {
        public int PointEarned { get; set; }
        public PlayerList PlayersList { get; set; }
        public GameTypes GameTypes { get; set; }
        public int GamesPlayed { get; set; }

        /// <summary>
        /// Creates a new Team Instance
        /// </summary>
        public Team()
        {
            PlayersList = new PlayerList();
            GamesPlayed = 0;
            PointEarned = 0;
        }
    }
}
