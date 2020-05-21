using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Tournament.Commands;
using Tournament.Models;

namespace Tournament.Views
{
    internal class PlayerViewModel
    {
        /// <summary>
        /// Initializes a new instane of CustomerViewModel class.
        /// </summary>
        public PlayerViewModel() {
            _Player = new Player("Kamil", "Kośko", 1);
            UpdateCommand = new PlayerUpdateCommand(this);
        }
        /// <summary>
        /// Gets or sets a Bolean value indicating wheter the Player can be updated
        /// </summary>
        public bool CanUpdate {
            get {
                if (Player == null) { 
                    return false;
                }
                return !String.IsNullOrWhiteSpace(Player.Name);
            
            }
            
        }

        private Player _Player;
        /// <summary>
        /// Gets the person instance
        /// </summary>
        public Player Player {
           get => _Player; }

        /// <summary>
        /// Gets the UpdateCommand for the viewmodel.
        /// </summary>
        public ICommand UpdateCommand { 
            get;
            private set;
        }

        /// <summary>
        /// Saves changed made to the Player instance.
        /// </summary>
        public void SaveChanges() {
            Debug.Assert(false, String.Format("{0} was updated.", Player.Name));
        }
    }
}
