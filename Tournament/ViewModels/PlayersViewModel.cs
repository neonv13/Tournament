using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    public class PlayersViewModel : INotifyPropertyChanged
    {
        public PlayerList Players { get; set; }
       
        public PlayersViewModel()
        {
            Players = new PlayerList();
            Players.LoadPlayersList("playersList.txt", "null");
        }
        public void SavePlayersViewModel()
        {
            StreamWriter streamWriter = new StreamWriter("playersList.txt");
            Players.SavePlayersList(streamWriter);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        

    }
}
