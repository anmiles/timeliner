#region References

using System.Windows.Forms;

#endregion

namespace Timeliner
{
    public partial class UpdateForm : Form
    {
        public UpdateForm(string text)
        {
            this.InitializeComponent();
            this.label1.Text = text;
            this.pictureBox1.Image = Resources.Preloader;
        }
    }
}