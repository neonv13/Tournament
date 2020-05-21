
namespace Tournament.Models
{
    using System;
    using System.ComponentModel;
    public abstract class Person : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private int _ID;
        /// <summary>
        /// /Initalizes a new instance of Person.
        /// </summary>
        public Person(string name, string surname, int ID) { 
            _name = name;
            _surname = surname;
            _ID = ID; }
        /// <summary>
        /// Gets or sets Person's Name
        /// </summary>
        public string Name {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        /// <summary>
        /// Gets or sets Person's Surname
        /// </summary>
        public string Surname {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }
        /// <summary>
        /// Gets or sets Person's ID
        /// !!!!
        /// Have to discuss method of giving ID to Person.
        /// !!!!
        /// </summary>
        public int ID { 
            get => _ID; 
            set => _ID = value; 
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        
        #endregion
    }

}
