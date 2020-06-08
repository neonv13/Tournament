using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    public class PlayersViewModel 
    {
        public PlayerList Players { get; set; }
       
        public PlayersViewModel()
        {
            Players = new PlayerList();
           
        }
        public void SavePlayersViewModel()
        {
            Players.WriteXML("playersList.xml");
        }

        public void LoadPlayersViewModel()
        {
            Players.ReadXML("playersList.xml");
        }



    }
}
