#region References

using System;
using System.Xml.Serialization;

#endregion

namespace Timeliner.Configuration
{
    [Serializable]
    public class TimelineElement
    {
        [XmlElement("Start")]
        public StartElement Start { get; set; }

        [XmlElement("Period")]
        public int Period { get; set; }

        [XmlElement("Pause")]
        public int Pause { get; set; }
    }
}
