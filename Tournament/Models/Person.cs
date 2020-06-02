
namespace Tournament.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        private string name;
        private string surname;
        private int id;

        /// <summary>
        /// /Initalizes a new instance of Person.
        /// </summary>
        public Person(string name, string surname, int id) 
        { 
            this.name = name;
            this.surname = surname;
            this.id = id;
        }

        /// <summary>
        /// Gets or sets Person's Name
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets Person's Surname
        /// </summary>
        public string Surname 
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets Person's ID
        /// </summary>
        public int ID
        {
            get => id; 
            set => id = value; 
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region
        public string this[string propertyName]
        {
            get 
            {
                if (propertyName == "Name")
                {
                    if (String.IsNullOrWhiteSpace(Name))
                    {
                        Error = "Name cannot be null empty";
                    }
                    else
                    {
                        Error = null;
                    }
                }
                else if (propertyName == "Surname")
                {
                    if (String.IsNullOrWhiteSpace(Surname))
                    {
                        Error = "Surname cannot be null";
                    }
                    else
                    {
                        Error = null;
                    }
                }
                return Error;
            }

        } 
        public string Error { get; private set; }
        #endregion

    }

}
