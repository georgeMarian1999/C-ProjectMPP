using System;
using System.Xml.Serialization;

namespace Problem11.Model
{
    public class DTOBJPart
    {
        public DTOBJPart(String nume,int capacitate)
        {
            this.Nume = nume;
            this.Capacitate = capacitate;
        }
        [XmlAttribute]
        public String Nume { get; set; }
        public int Capacitate { get; set; }
    }
}
