#region References

using System;
using System.Xml.Serialization;

#endregion

namespace Timeliner.Configuration
{
    [Serializable]
    public class PeriodElement
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }

    }
}
