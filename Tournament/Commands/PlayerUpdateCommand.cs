using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tournament.Views;

namespace Tournament.Commands
{
    internal class PlayerUpdateCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of PlayerUpdateCommand class.
        /// </summary>
     
        public PlayerUpdateCommand(PlayerViewModel viewModel){
            _ViewModel = viewModel;
        }

        private PlayerViewModel _ViewModel;
        private ICommand command;

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add {CommandManager.RequerySuggested+= value; }
            remove { CommandManager.RequerySuggested -= value; ; }
        }
        public bool CanExecute(object parameter) {
            return _ViewModel.CanUpdate;
        }
        public void Execute(object parameter) { 
            throw new NotImplementedException(); 
        }

        #endregion
    }
}
