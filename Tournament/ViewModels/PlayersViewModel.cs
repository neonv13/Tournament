using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    public class PlayersViewModel : INotifyPropertyChanged
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
            Players.LoadPlayersList("C:\\Users\\kamil\\OneDrive\\Pulpit\\ZadaniaPO\\Tournament\\Tournament\\bin\\Debug\\netcoreapp3.1\\playersList.txt", "null");
        }
        public void SavePlayersViewModel()
        {
            Players.SavePlayersList("playersList.txt");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        

    }
}
