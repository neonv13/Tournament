namespace Tournament.Models
{
    public class Player : Person
    {
        private int _IndiwidualPionts;
        public Player(string name, string surname, int ID) : base(name, surname, ID)
        {
        }

        public int IndiwidualPionts {
            get => _IndiwidualPionts;
            set { 
                _IndiwidualPionts = value;
                OnPropertyChanged("IndiwidualPionts");
            }
        }
    }
}
