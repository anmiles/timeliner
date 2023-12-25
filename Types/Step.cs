#region References

using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timeliner.Configuration;
using Timeliner.Helpers;

#endregion

namespace Timeliner.Types
{
    public class Step
    {
        public double Percent { get; set; }
        public Color Color { get; set; }
        public ToolTipIcon NotificationIcon { get; set; }
        public string NotificationText { get; set; }
        public string AppearanceStamp { get; set; }

        private PhaseElement phase;

        public Step()
        {
            this.Color = Color.Transparent;
            this.Percent = Int32.MinValue;
        }

        public Step(TimelinerConfig config, DateTime dateTime)
            : this()
        {
            float beginTime = config.Timeline.Start.GetStep();
            float time = new StartElement().SetDate(dateTime).GetStep();

            int period = GetPeriod(config, time, beginTime);
            this.Percent = GetPercent(config, period, time, beginTime);
            this.phase = config.Phases.Last(p => this.Percent >= 0 ? (p.Begin <= this.Percent * 100) : p.Begin < 0);

            this.Color = this.phase.GetColor();
            this.NotificationIcon = this.phase.GetIcon();

            string periodTitle = period >= 0 && period < config.Periods.Count 
                ? config.Periods[period].Title
                : "All";

            this.NotificationText = String.Format(this.phase.GetMessage(), periodTitle);

            this.AppearanceStamp = config.Appearance.GetStamp();
        }

        private static int GetPeriod(TimelinerConfig config, float time, float beginTime)
        {
            return (int)Math.Floor((time - beginTime) / (config.Timeline.Period + config.Timeline.Pause));
        }

        private static float GetPercent(TimelinerConfig config, int period, float time, float beginTime)
        {
            if (time < beginTime)
            {
                return -1;
            }

            if (period >= config.Periods.Count)
            {
                return 1;
            }

            float rest = (time - beginTime) % (config.Timeline.Period + config.Timeline.Pause);
            if (rest > config.Timeline.Period)
            {
                return 1;
            }

            return rest / config.Timeline.Period;
        }

        public bool Equals(Step step)
        {
            return this.phase == step.phase;
        }
    }
}
