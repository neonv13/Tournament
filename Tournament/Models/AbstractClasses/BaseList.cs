using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Tournament.Models
{
    public abstract class BaseList<T> where T: BaseObject
    {
        public int Count { get; set; }
        public List<T> List { get; set; }
        /// <summary>
        /// Returns Object T with following ID or null if Object doesn't exists 
        /// </summary>
        public T FindByID(int id)
        {
            foreach (T t in List)
            {
                if (t.ID == id)
                    return t;
            }
            return null;
        }
        /// <summary>
        /// Removes Object T with following ID if Object exists
        /// </summary>
        public void Remove(int id)
        {
            T t = FindByID(id);
            if (t != null)
            {
                List.Remove(t);
                Count--;
            }
        }
        /// <summary>
        /// Adds Object T with following ID if ID is free
        /// </summary>
        public void Add(T t)
        {
            if (FindByID(t.ID) == null)
            {

                List.Add(t);
                Count++;
            }
        }
        public void WriteXML(string path)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(this.GetType());

            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, this);
            file.Close();
        }
        /// <summary>
        /// Reads XML file and makes this Instance with Data
        /// </summary>
        public void ReadXML(string path)
        {
            System.Xml.Serialization.XmlSerializer reader =
               new System.Xml.Serialization.XmlSerializer(this.GetType());
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            var obj = reader.Deserialize(file);
            file.Close();
            SetObj(obj);
        }
        /// <summary>
        /// Refills this Instance with obj Properies
        /// </summary>
        public abstract void SetObj(object obj);
        
    }
}
