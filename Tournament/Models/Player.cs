namespace Tournament.Models
{
    public class Player : Person
    {
        private int indiwidualPionts;
        public Player(string name, string surname, int ID) : base(name, surname, ID)
        {
        }

        public int IndiwidualPionts {
            get => indiwidualPionts;
            set { 
                indiwidualPionts = value;
                OnPropertyChanged("IndiwidualPionts");
            }
        }
    }
}
