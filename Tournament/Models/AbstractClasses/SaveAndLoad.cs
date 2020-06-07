using System;
using System.Collections.Generic;
using System.Text;

namespace Tournament.Models
{
    public abstract class SaveAndLoad
    {
        /// <summary>
        /// Writes object to xml file
        /// </summary>
        public void WriteXML(string path)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(this.GetType());

            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, this);
            file.Close();
        }
    }
}
