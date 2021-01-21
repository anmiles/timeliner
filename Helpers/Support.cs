#region References

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using Timer = System.Windows.Forms.Timer;

#endregion

namespace Timeliner.Helpers
{
    public class Support
    {
        private const string CONST_updateURL = "http://files.anmiles.net/distrib/{0}/{1}";
        private const string CONST_latestFileName = "latest.txt";
        private static List<object> expiredForms = new List<object>();
        private static string newExecutable;
        private Form form;
        private ToolStrip toolStrip;

        public Support(Form form)
        {
            this.form = form;
        }

        public void AddSupport(ToolStrip contextMenuStrip)
        {
            this.toolStrip = contextMenuStrip;
            ToolStripMenuItem supportMenu = new ToolStripMenuItem("Support", Resources.Support);
            supportMenu.DropDown.Items.Add("Check for updates", Resources.SupportUpdates, SupportUpdates);
            supportMenu.DropDown.Items.Add("Download source code", Resources.SupportSource, SupportSource);
            supportMenu.DropDown.Items.Add("Download installer", Resources.SupportInstaller, SupportInstaller);
            supportMenu.DropDown.Location = contextMenuStrip.Location - supportMenu.Size;
            contextMenuStrip.Items.Add(supportMenu);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
        }

        private void SupportUpdates(object sender, EventArgs e)
        {
            ShowUpdateForm("Check for updates", sender, tag => this.WrapSupportMethod(() =>
            {
                IEnumerable<string> latestVersion = this.CheckLatestVersion();

                if (latestVersion != null)
                {
                    string exeFile = latestVersion.Skip(0).Take(1).Single();
                    string exePath = string.Format(CONST_updateURL, Application.ProductName, exeFile);
                    string newExePath = Assembly.GetExecutingAssembly().Location.Replace(".exe", ConsoleHelper.CONST_TempExtension + ".exe");
                    new WebClient().DownloadFile(exePath, newExePath);
                    newExecutable = newExePath;
                    expiredForms.Add(tag);
                }
            }));
        }

        private void SupportSource(object sender, EventArgs e)
        {

        }

        private void SupportInstaller(object sender, EventArgs e)
        {

        }

        private IEnumerable<string> CheckLatestVersion()
        {
            return WrapSupportMethod(() => 
            {
                string latestFile = Path.GetTempFileName();
                new WebClient().DownloadFile(string.Format(CONST_updateURL, Application.ProductName, CONST_latestFileName), latestFile);
                IEnumerable<string> latestVersion = File.ReadAllText(latestFile)
                    .Split(Environment.NewLine.ToCharArray())
                    .Where(str => !string.IsNullOrWhiteSpace(str))
                    .Select(str => str.Trim());
                File.Delete(latestFile);
                return latestVersion;
            });
        }

        private void WrapSupportMethod(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Support methods failed. Please contact to program author.\r\nError: {0}", ex.Message));
            }
        }

        private T WrapSupportMethod<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Support methods failed. Please contact to program author.\r\nError: {0}", ex.Message));
                return default(T);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Timer timer = ((Timer) sender);

            if (expiredForms.Contains(timer.Tag))
            {
                expiredForms.Remove(timer.Tag);
                Application.OpenForms.Cast<Form>().Single(f => f.Tag != null && f.Tag.Equals(timer.Tag)).Close();
                timer.Stop();
                timer.Dispose();

                if (!string.IsNullOrEmpty(newExecutable))
                {
                    this.form.Die();
                }
            }
        }

        private void ShowUpdateForm(string labelString, object sender, Action<object> action)
        {
            UpdateForm updateForm = new UpdateForm(labelString);
            updateForm.Show();
            Guid tag = Guid.NewGuid();
            updateForm.Tag = tag;

            Timer timer = new Timer {Enabled = true, Interval = 10, Tag = tag};
            timer.Tick += this.timer_Tick;
            timer.Start();
            
            new Thread(start => action(start)).Start(tag);
        }
    }
}