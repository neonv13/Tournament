using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class PlayersViewModel
    {
        public string Name { get;  set; }
        public string Surname { get;  set; }
        public  PlayerList Players { get; private set; }
        public bool CanUpdate { get; internal set; }

        public PlayersViewModel()
        {
            Players = new PlayerList();
            Players.LoadPlayersList("plik.txt","null");
            UpdateCommand = new 
        }
        public void AddPlayerToList() 
        {
            Players.AddPlayer(new Player(Name,Surname,Players.PlayersList));
            Players.SavePlayersList("plik.txt");
        }

    }
}
