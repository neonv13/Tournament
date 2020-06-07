using System;
using System.Collections.Generic;
using System.Text;

namespace Tournament.Models
{
    public abstract class BaseObject : SaveAndLoad
    {
        public string Name { get; set; }
        public int ID { get; set; }

    }
}
