#region References

using System;
using System.Xml.Serialization;

#endregion

namespace Timeliner.Configuration
{
	[Serializable]
	public class AppearanceElement
	{
		[XmlElement("BarWidth")]
		public int BarWidth { get; set; }

		[XmlElement("ScreenIndex")]
		public int ScreenIndex { get; set; }

		[XmlElement("Position")]
		public string Position { get; set; }

		[XmlElement("IgnoreTaskbar")]
		public bool IgnoreTaskbar { get; set; }

	}
}
