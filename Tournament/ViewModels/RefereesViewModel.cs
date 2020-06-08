using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Tournament.Models;

namespace Tournament.ViewModels
{
    public class RefereesViewModel
    { 
        public RefereeList Referees { get; set; }
        public RefereesViewModel()
        {
            Referees = new RefereeList();
        }

        public void SaveRefereesViewModel()
        {
            Referees.WriteXML("refereesList.xml");
        }
        public void LoadRefereesViewModel()
        {
            Referees.ReadXML("refereesList.xml");
        }
        

       
    }
}
