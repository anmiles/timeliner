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

		[XmlElement("Play")]
		public int Play { get; set; }

		[XmlElement("Pause")]
		public int Pause { get; set; }

		[XmlElement("Periods")]
		public int Periods { get; set; }

	}
}
