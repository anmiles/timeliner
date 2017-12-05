#region References

using System;
using System.Xml.Serialization;

#endregion

namespace Timeliner.Configuration
{
	[Serializable]
	public class PhaseElement
	{
		[XmlAttribute("Begin")]
		public int Begin { get; set; }

		[XmlAttribute("Color")]
		public int Color { get; set; }

		[XmlElement("Message")]
		public MessageElement Message { get; set; }

	}
}
