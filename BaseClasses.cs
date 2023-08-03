using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubFutzer
{
    public class SelectAllForm : Form
    {
        protected void SelectAll()
        {
            Control ctrl = Global.GetActiveControl(this);

            if (ctrl is TimeTextBox)
                ((TimeTextBox)ctrl).SelectAll();
            else if (ctrl is TextBox)
            {
                TextBox tb = ctrl as TextBox;
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
            else if (ctrl is ListView)
            {
                foreach (ListViewItem lvi in ((ListView)ctrl).Items)
                    lvi.Selected = true;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (e.Modifiers.HasFlag(Keys.Control))
                    {
                        SelectAll();
                        return;
                    }
                    break;
                default:
                    break;
            }
            base.OnKeyDown(e);
        }

    }
}
