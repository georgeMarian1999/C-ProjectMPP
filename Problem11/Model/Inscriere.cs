using System;
using System.Xml.Serialization;

namespace Problem11.Model
{
    public class Inscriere : Entity<int>
    {
        public Inscriere(int id1, int id2, int id3)
        {
            Id = id1;
            IdPart = id2;
            IdCursa = id3;
        }
        [XmlAttribute]
        public int Id { get; set; }
        public int IdPart { get; set; }
        public int IdCursa { get; set; }


    }
}
