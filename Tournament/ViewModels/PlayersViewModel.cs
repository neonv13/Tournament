using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class PlayersViewModel : INotifyPropertyChanged
    {
        private PlayerList players;
        public  PlayerList Players 
        {
            get => players;
            private set 
            {
                players = value;
                OnPropertyChanged(); 
            } 
        }
        public PlayersViewModel()
        {
            Players = new PlayerList();
            Players.LoadPlayersList("playersList.txt", "null");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        

    }
}
