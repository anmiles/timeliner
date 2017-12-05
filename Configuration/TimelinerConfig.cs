#region References

using System;
using System.Xml.Serialization;
using System.Collections.Generic;

#endregion

namespace Timeliner.Configuration
{
	[Serializable]
	public class TimelinerConfig
	{
		[XmlElement("Initialized")]
		public bool Initialized { get; set; }

		[XmlElement("Timeline")]
		public TimelineElement Timeline { get; set; }

		[XmlElement("Settings")]
		public SettingsElement Settings { get; set; }

		[XmlElement("Appearance")]
		public AppearanceElement Appearance { get; set; }

		[XmlArray("Phases")]
		[XmlArrayItem("Phase", typeof(PhaseElement))]
		public List<PhaseElement> Phases { get; set; }

	}
}
