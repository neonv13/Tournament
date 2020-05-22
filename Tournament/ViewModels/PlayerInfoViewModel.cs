using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tournament.ViewModels
{
    internal class PlayerInfoViewModel : INotifyPropertyChanged
    {
        private string info;
        /// <summary>
        /// Gets or sets some information
        /// </summary>
        public String Info {
            get 
            {
                return info;           
            }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }
        
        
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion
    }
}
