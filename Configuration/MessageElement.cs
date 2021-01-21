#region References

using System;
using System.Xml.Serialization;

#endregion

namespace Timeliner.Configuration
{
    [Serializable]
    public class MessageElement
    {
        [XmlAttribute("Text")]
        public string Text { get; set; }

        [XmlAttribute("Icon")]
        public string Icon { get; set; }

    }
}
