using System.Linq;
using System.Windows.Forms;

namespace Timeliner.Controls
{
    public class ExTableLayoutPanel : TableLayoutPanel
    {
        public ExTableLayoutPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, false);
        }

        public void RemoveRow(int rowNumber)
        {
            this.Controls.Cast<Control>()
                .Where(control => this.GetRow(control) == rowNumber)
                .ToList()
                .ForEach(control => this.Controls.Remove(control));

            this.RowStyles.RemoveAt(rowNumber);

            foreach (Control control in this.Controls)
            {
                int row = this.GetRow(control);
                if (row > rowNumber)
                {
                    this.SetRow(control, row - 1);
                }
            }
        }
    }
}