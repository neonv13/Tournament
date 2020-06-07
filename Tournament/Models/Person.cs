
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
        public void WriteXML(Person person)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Person));

            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }
    }

}
