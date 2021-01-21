#region References

using System;
using System.Xml.Serialization;

#endregion

namespace Timeliner.Configuration
{
    [Serializable]
    public class StartElement
    {
        [XmlAttribute("Hour")]
        public int Hour { get; set; }

        [XmlAttribute("Minute")]
        public int Minute { get; set; }

        [XmlAttribute("Second")]
        public int Second { get; set; }

    }
}
