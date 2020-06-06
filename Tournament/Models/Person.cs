
namespace Tournament.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ID { get; set; }

        /// <summary>
        /// /Initalizes a new instance of Person.
        /// </summary>
        public Person(string name, string surname, int id) 
        { 
            Name = name;
            Surname = surname;
            ID = id;
        }
    }

}
