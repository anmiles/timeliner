#region References

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Timeliner.Configuration;
using Timeliner.Helpers;
using Timeliner.Types;

#endregion

namespace Timeliner
{
    public partial class Form1 : Form
    {
        private static TimelinerConfig config = ConfigHelper.ReadConfig();
        private Step oldStep = new Step();
        private Step step = new Step();

        public Form1()
        {
            this.SetStyle(ControlStyles.Opaque, true);
            this.InitializeComponent();
            this.Width = this.Height = 0;
            this.SetAppearance();
            this.CheckPhases();
            this.CheckInitialized();
        }

        private void CheckPhases()
        {
            foreach (PhaseElement phase in config.Phases)
            {
                try
                {
                    phase.GetColor();
                    phase.GetIcon();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Die();
                }
            }
        }

        private void CheckInitialized()
        {
            if (config.Initialized)
            {
                return;
            }

            CreateScheduledTask();

            config.Initialized = true;
            ConfigHelper.WriteConfig(config);
            this.ShowSettings();
        }

        private void CreateScheduledTask()
        {
            string xmlTask = string.Format(Resources.ScheduledTask, DateTime.Now.ToString("o"), Assembly.GetExecutingAssembly().Location);
            string tmpFile = Path.GetTempFileName();

            using (FileStream file = new FileStream(tmpFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                file.Write(TextHelper.Windows1251().GetBytes(xmlTask), 0, xmlTask.Length);
                file.Close();

                string args = string.Format("/create /xml {0} /f /tn {1}", tmpFile, Application.ProductName);
                ConsoleHelper.RunProcess("schtasks", args, null, ProcessWindowStyle.Hidden, true);
            }

            File.Delete(tmpFile);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.UpdateStep();
            this.LaunchUpdater();
            this.BuildNotifyIcon();
        }

        private void BuildNotifyIcon()
        {
            this.panel1.ContextMenuStrip = this.notifyIcon1.ContextMenuStrip = this.BuildContextMenuStrip();
            EventHandler showMenuFromIcon = (s1, e1) => typeof (NotifyIcon)
                                                            .GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic)
                                                            .Invoke(s1, null);
            EventHandler showMenuFromPanel = (s1, e1) => notifyIcon1.ContextMenuStrip.Show(MousePosition);
            
            this.notifyIcon1.Click += showMenuFromIcon;
            this.panel1.Click += showMenuFromPanel;
        }

        private void LaunchUpdater()
        {
            this.timer1.Interval = 100;
            this.timer1.Tick += (s1, e1) => this.UpdateStep();
            this.timer1.Start();
        }

        private ContextMenuStrip BuildContextMenuStrip()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
            {
                new ToolStripMenuItem("Start", Resources.Start, (s, e) => this.Start()),
                new ToolStripMenuItem("Reset", Resources.Reset, (s, e) => this.Reset()),
                new ToolStripSeparator(),
                new ToolStripMenuItem("Show", Resources.Show, (s, e) => this.Show()),
                new ToolStripMenuItem("Hide", Resources.Hide, (s, e) => this.Hide()),
                new ToolStripSeparator(),
                new ToolStripMenuItem("Settings", Resources.Settings, (s, e) => this.ShowSettings()),
                new ToolStripSeparator()
            });
            new Support(this).AddSupport(contextMenuStrip);
            contextMenuStrip.AddExit();
            return contextMenuStrip;
        }

        private void Start()
        {
            config.Timeline.Start = new StartElement().SetDate(DateTime.Now);
            this.UpdateStep();
        }

        internal void Reset()
        {
            config = ConfigHelper.ReadConfig();
            this.SetAppearance();

            List<ConfigForm> configForms = Application.OpenForms.OfType<ConfigForm>().ToList();

            if (configForms.Any())
            {
                configForms.ForEach(configForm => configForm.Close());
                ShowSettings();
            }
        }

        internal void ShowSettings()
        {
            new ConfigForm().BuildForm(config);
        }

        private void DownloadUpdate()
        {

        }

        private void UpdateStep()
        {
            this.step = new Step(config, DateTime.Now);

            if (this.step.AppearanceStamp != this.oldStep.AppearanceStamp)
            {
                this.SetAppearance();
            }

            this.SetPanel1Size(this.step.Percent, config.Appearance.GetPosition());

            if (this.step.Percent.Equals(-1.0) && !this.oldStep.Percent.Equals(-1.0))
            {
                if (config.Settings.ResetAfterMidnight)
                {
                    this.Reset();
                }

                if (config.Settings.ShowAfterMidnight)
                {
                    this.Show();
                }
            }

            if (!string.IsNullOrEmpty(this.step.NotificationText) && !this.step.Equals(this.oldStep) && this.Visible)
            {
                this.notifyIcon1.ShowBalloonTip(1000, this.step.NotificationText, " ", this.step.NotificationIcon);
            }

            this.panel1.BackColor = this.step.Color;
            this.oldStep = this.step;
        }

        private void SetPanel1Size(double factor, Position position)
        {
            if (position == Position.Left || position == Position.Right)
            {
                this.Height = panel1.Height = (int) ((config.Appearance.IgnoreTaskbar
                                                          ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Height
                                                          : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Height) * Math.Abs(factor));
            }
            else
            {
                this.Width = panel1.Width = (int)((config.Appearance.IgnoreTaskbar
                                           ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Width
                                           : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Width) * Math.Abs(factor));
            }
        }

        private void SetAppearance()
        {
            if (config.Appearance.ScreenIndex >= Screen.AllScreens.Length)
            {
                config.Appearance.ScreenIndex = Screen.AllScreens.Length - 1;
                ConfigHelper.WriteConfig(config);
            }

            this.Left = config.Appearance.IgnoreTaskbar
                            ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Left
                            : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Left;

            this.Top = config.Appearance.IgnoreTaskbar
                           ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Top
                           : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Top;

            switch (config.Appearance.GetPosition())
            {
                case Position.Top:
                    this.Left = config.Appearance.IgnoreTaskbar
                                    ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Left
                                    : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Left;
                    this.Top = config.Appearance.IgnoreTaskbar
                                   ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Top
                                   : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Top;
                    this.ClientSize = this.panel1.Size = new Size(
                                                             config.Appearance.IgnoreTaskbar
                                                                 ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Width
                                                                 : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Width,
                                                             config.Appearance.BarWidth);
                    break;

                case Position.Right:
                    this.Left = config.Appearance.IgnoreTaskbar
                                    ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Right - config.Appearance.BarWidth
                                    : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Right - config.Appearance.BarWidth;
                    this.Top = config.Appearance.IgnoreTaskbar
                                   ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Top
                                   : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Top;
                    this.ClientSize = this.panel1.Size = new Size(
                                                             config.Appearance.BarWidth,
                                                             config.Appearance.IgnoreTaskbar
                                                                 ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Height
                                                                 : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Height);
                    break;

                case Position.Bottom:
                    this.Left = config.Appearance.IgnoreTaskbar
                                    ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Left
                                    : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Left;
                    this.Top = config.Appearance.IgnoreTaskbar
                                   ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Bottom - config.Appearance.BarWidth
                                   : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Bottom - config.Appearance.BarWidth;
                    this.ClientSize = this.panel1.Size = new Size(
                                                             config.Appearance.IgnoreTaskbar
                                                                 ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Width
                                                                 : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Width,
                                                             config.Appearance.BarWidth);
                    break;

                case Position.Left:
                    this.Left = config.Appearance.IgnoreTaskbar
                                    ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Left
                                    : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Left;
                    this.Top = config.Appearance.IgnoreTaskbar
                                   ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Top
                                   : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Top;
                    this.ClientSize = this.panel1.Size = new Size(
                                                             config.Appearance.BarWidth,
                                                             config.Appearance.IgnoreTaskbar
                                                                 ? Screen.AllScreens[config.Appearance.ScreenIndex].Bounds.Height
                                                                 : Screen.AllScreens[config.Appearance.ScreenIndex].WorkingArea.Height);
                    break;
            }
        }
    }
}