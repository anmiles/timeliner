#region References

using System.Windows.Forms;
using System.Linq;

#endregion

namespace Timeliner.Helpers
{
    public static class FormHelper
    {
        public static void Die(this Form form)
        {
            form.Controls.OfType<NotifyIcon>().ToList().ForEach(icon => icon.Visible = false);
            form.Close();
            ConsoleHelper.Die();
        }

        public static void Die()
        {
            Application.OpenForms.Cast<Form>().ToList().ForEach(form => form.Die());
        }

        public static void AddExit(this ToolStrip toolStrip)
        {
            toolStrip.Items.Add("Exit", Resources.Exit, (sender, e) => Die());
        }
    }
}