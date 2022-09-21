using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab2
{
    [Serializable]
    [XmlRoot("dogs")]
    public class Dogs
    {
        [XmlElement("dog")]
        public List<DOG>? dog { get; set; }
    }

    [Serializable]
    public class DOG
    {
        [XmlElement("dogName")]
        public string? dogName { get; set; }

        [XmlElement("dogWeight")]
        public string? dogWeight { get; set; }

        [XmlElement("dogColor")]
        public string? dogColor { get; set; }
    }

    public class Serializable
    {
        public Dogs deserialize(string path)
        {
            Dogs dogs;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dogs), new XmlRootAttribute("dogs"));
            using (StreamReader reader = new StreamReader(path))
            {
                dogs = (Dogs)xmlSerializer.Deserialize(reader);
            }
            return dogs;
        }
    }
}
