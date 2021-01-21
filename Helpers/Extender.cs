#region References

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Timeliner.Configuration;
using Timeliner.Types;

#endregion

namespace Timeliner.Helpers
{
    static class Extender
    {
        public static StartElement SetDate(this StartElement start, DateTime dateTime)
        {
            start.Hour = dateTime.Hour;
            start.Minute = dateTime.Minute;
            start.Second = dateTime.Second;
            return start;
        }

        public static DateTime GetDate(this StartElement start)
        {
            return DateTime.Today.AddHours(start.Hour).AddMinutes(start.Minute).AddSeconds(start.Second);
        }

        public static float GetStep(this StartElement start)
        {
            return start.Hour * 60 + start.Minute + (float)start.Second / 60;
        }

        public static string GetStamp(this AppearanceElement appearance)
        {
            return typeof(AppearanceElement).GetProperties()
                .Where(property => property.GetCustomAttributes(typeof(XmlElementAttribute), true).Any())
                .Aggregate("", (current, property) => current + string.Format("[{0}:{1}]", property.Name, property.GetValue(appearance, null)));
        }

        public static Position GetPosition(this AppearanceElement appearance)
        {
            Position value;

            if (Enum.TryParse(appearance.Position, out value))
            {
                return value;
            }

            throw new InvalidEnumArgumentException(string.Format("Invalid Position value: '{0}'", appearance.Position));
        }

        public static PhaseElement Default(this PhaseElement phase)
        {
            phase.Begin = 0;
            phase.Color = Color.Green.ToArgb();
            return phase;
        }

        public static int? GetNaturalBegin(this PhaseElement phase)
        {
            if (phase.Begin < 0 || phase.Begin > 100)
            {
                return null;
            }

            return phase.Begin;
        }

        public static ToolTipIcon GetIcon(this PhaseElement phase)
        {
            if (phase.Message == null)
            {
                return ToolTipIcon.None;
            }

            ToolTipIcon icon;
            if (Enum.TryParse(phase.Message.Icon, true, out icon))
            {
                return icon;
            }

            throw new InvalidEnumArgumentException(string.Format("ToolTipIcon '{0}' is invalid!", phase.Message.Icon));
        }

        public static void SetIcon(this PhaseElement phase, ToolTipIcon icon)
        {
            if (phase.Message == null)
            {
                if (icon == ToolTipIcon.None)
                {
                    return;
                }

                phase.Message = new MessageElement
                {
                    Text = string.Empty
                };
            }

            phase.Message.Icon = Enum.GetName(typeof(ToolTipIcon), icon);
        }

        public static Color GetColor(this PhaseElement phase)
        {
            if (phase.Color == 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("Color '{0}' is invalid!", phase.Color));
            }

            return Color.FromArgb(phase.Color);
        }

        public static void SetColor(this PhaseElement phase, Color color)
        {
            phase.Color = color.ToArgb();
        }

        public static string GetMessage(this PhaseElement phase)
        {
            if (phase.Message == null)
            {
                return string.Empty;
            }

            return phase.Message.Text;
        }

        public static void SetMessage(this PhaseElement phase, string text)
        {
            if (phase.Message == null)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }

                phase.Message = new MessageElement
                {
                    Icon = Enum.GetName(typeof(ToolTipIcon), ToolTipIcon.None)
                };
            }

            phase.Message.Text = text;
        }
    }
}