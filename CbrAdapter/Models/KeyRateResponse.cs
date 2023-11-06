using System.Xml.Serialization;

namespace CbrAdapter.Models
{
    [XmlRoot("root")]
    public class KeyRateResponse
    {
        [XmlElement("KR")]
        public List<KeyRate>? KeyRates { get; set; }
    }
}
