#region References

using System;
using System.Xml.Serialization;

#endregion

namespace Timeliner.Configuration
{
    [Serializable]
    public class SettingsElement
    {
        [XmlElement("ResetAfterMidnight")]
        public bool ResetAfterMidnight { get; set; }

        [XmlElement("ShowAfterMidnight")]
        public bool ShowAfterMidnight { get; set; }

    }
}
