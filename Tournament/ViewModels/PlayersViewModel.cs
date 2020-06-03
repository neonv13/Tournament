using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Commands;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class PlayersViewModel : INotifyPropertyChanged
    {
        public string Name { get;  set; }
        public string Surname { get;  set; }
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
        public PlayersSaveCommand UpdateCommand { get; private set; }
        public Player player { get; set; }
        public PlayersViewModel()
        {
            Players = new PlayerList();
            Players.LoadPlayersList("C:\\Users\\kamil\\OneDrive\\Pulpit\\ZadaniaPO\\Tournament\\Tournament\\bin\\Debug\\netcoreapp3.1\\plik2.txt", "null");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public bool CanUpdate 
        {
            get 
            {
                if (player == null)
                    return false;
                return !String.IsNullOrWhiteSpace(player.Name); } 
        }

    }
}
