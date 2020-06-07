
namespace Tournament.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class Person : BaseObject
    {
        public string Surname { get; set; }
        public Person() 
        {
            Name = string.Empty;
            Surname = string.Empty;
            ID = -1; 
        }
    }

}
