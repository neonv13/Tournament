namespace Tournament.Models
{
    public class Player : Person
    {
        private int individualPoints;
        public Player(string name, string surname, int ID) : base(name, surname, ID)
        {
        }
        /// <summary>
        /// Gets or sets IndividualPoints 
        /// </summary>
        public int IndividualPoints {
            get => individualPoints;
            set { 
                individualPoints = value;
                OnPropertyChanged("IndividualPoints");
            }
        }
    }
}
