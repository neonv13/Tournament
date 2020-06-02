using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tournament.ViewModels;

namespace Tournament.Commands
{
    class PlayersSaveCommand : ICommand
    {
        public PlayersSaveCommand(PlayersViewModel viewModel)
        {
            viewModel = ViewModel;
        }
        
        public PlayersViewModel ViewModel { get; private set; }
        
        
        
        
        
        
        
        
        
        
        public event EventHandler CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return ViewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            ViewModel.AddPlayerToList();
        }
    }
}
