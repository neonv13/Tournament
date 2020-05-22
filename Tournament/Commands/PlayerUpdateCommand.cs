using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tournament.Views;

namespace Tournament.Commands
{
    internal class PlayerUpdateCommand : ICommand
    {
        private PlayerViewModel viewModel;
     
        /// <summary>
        /// Initializes a new instance of PlayerUpdateCommand class.
        /// </summary>
        public PlayerUpdateCommand(PlayerViewModel viewModel){
            this.viewModel = viewModel;
        }


        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add {CommandManager.RequerySuggested+= value; }
            remove { CommandManager.RequerySuggested -= value; ; }
        }
        public bool CanExecute(object parameter) {
            return String.IsNullOrWhiteSpace(viewModel.Player.Error);
        }
        public void Execute(object parameter) { 
            viewModel.SaveChanges(); 
        }

        #endregion
    }
}
