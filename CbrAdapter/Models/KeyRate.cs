using System.Xml.Serialization;

namespace CbrAdapter.Models
{
    [XmlRoot("KR")]
    public class KeyRate
    {
        [XmlElement("DT")]
        public DateTime Date { get; set; }

        [XmlElement("Rate")]
        public float Rate { get; set; }
    }
}
