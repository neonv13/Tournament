using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Tournament.Commands;
using Tournament.Models;
using Tournament.ViewModels;

namespace Tournament.Views
{
    internal class PlayerViewModel
    {
        private Player player;
        private PlayerInfoViewModel childViewModel;
        /// <summary>
        /// Initializes a new instane of CustomerViewModel class.
        /// </summary>
        public PlayerViewModel() 
        {
            player = new Player("Kamil", "Kośko", null);
            childViewModel = new PlayerInfoViewModel();
            UpdateCommand = new PlayerUpdateCommand(this);
        }
        

        /// <summary>
        /// Gets the person instance
        /// </summary>
        public Player Player 
        {
           get => player;
        }

        /// <summary>
        /// Gets the UpdateCommand for the viewmodel.
        /// </summary>
        public ICommand UpdateCommand
        { 
            get;
            private set;
        }

        /// <summary>
        /// Saves changed made to the Player instance.
        /// </summary>
        public void SaveChanges() 
        {
            PlayerInfoView view = new PlayerInfoView();
            view.DataContext = childViewModel;

            childViewModel.Info = Player.Name + " was updated in the database.";

            view.ShowDialog();
        }
    }
}
