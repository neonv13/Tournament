
namespace Tournament.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    /// <summary>
    /// Abstract class Person - all types of classes to store people data inherits
    /// </summary>
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
