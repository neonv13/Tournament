using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class PlayersViewModel
    {
        public  List<Player> Players { get; private set; }
        public PlayersViewModel()
        {
            Players = new List<Player>();
            Players.Add(new Player("Kamil", "Kosko", Players));
            Players.Add(new Player("4321", "K2413ko", Players));
            Players.Add(new Player("12354l", "Ko23", Players));
            Players.Add(new Player("Kam235il", "Ko421o", Players));

        }
        

    }
}
