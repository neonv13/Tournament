using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class PlayersViewModel
    {
        private List<Player> player;
        public PlayersViewModel()
        {
            player = new List<Player>();
            player.Add(new Player("Kamil", "Kosko", null));
            player.Add(new Player("4321", "K2413ko", null));
            player.Add(new Player("12354l", "Ko23", null));
            player.Add(new Player("Kam235il", "Ko421o", null));

        }
        public List<Player> Player
        {
            get => player;

        }

    }
}
