using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    class RefereesViewModel
    {
        public List<Referee> Referees { get; private set; }
        public RefereesViewModel()
        {
            Referees = new List<Referee>();
            Referees.Add(new Referee("x345ie", "adsrf", Referees));
            Referees.Add(new Referee("xdd3i", "dsgfh",  Referees));
            Referees.Add(new Referee("xdd25", "sdf",    Referees));
            Referees.Add(new Referee("x3245e", "fsd",   Referees));
        }
        
    }
}
