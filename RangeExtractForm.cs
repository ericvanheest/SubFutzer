using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubFutzer
{
    public partial class RangeExtractForm : SelectAllForm
    {
        public enum Extract
        {
            ExtractSingle,
            ExtractMultiple
        }

        private string m_sFileName = "Subtitle";

        public Extract Action
        {
            get { return rbExtractSingle.Checked ? Extract.ExtractSingle : Extract.ExtractMultiple; }

            set
            {
                if (value == Extract.ExtractMultiple)
                    rbExtractSingle.Checked = true;
                else
                    rbExtractSingle.Checked = true;
            }
        }

        public RangeExtractForm()
        {
            InitializeComponent();
            cbKeep.SelectedIndex = 0;
            StartTime = TimeSpan.MinValue;
            StopTime = TimeSpan.MinValue;
        }

        public string FileName
        {
            get { return m_sFileName; }
            set { m_sFileName = value; }
        }

        public TimeSpan StartTime
        {
            get { return ttbBegin.GetTime(); }
            set { ttbBegin.SetTime(value); }
        }

        public TimeSpan StopTime
        {
            get { return ttbEnd.GetTime(); }
            set { ttbEnd.SetTime(value); }
        }

        public bool ShiftBack
        {
            get { return cbShiftBack.Checked; }
            set { cbShiftBack.Checked = value; }
        }

        public string[] Times { get { return tbTimes.Lines; } }
        public string Prefix { get { return tbPrefix.Text; } }

        public bool RemoveOutside { get { return cbKeep.SelectedIndex == 0; } }

        public void SetStartTime(DateTime dt)
        {
            StartTime = TimeToolbox.DateTimeToTimeSpan(dt);
        }

        public void SetStopTime(DateTime dt)
        {
            StopTime = TimeToolbox.DateTimeToTimeSpan(dt);
        }

        private void RangeExtractForm_Load(object sender, EventArgs e)
        {
            ttbBegin.SetTime(StartTime);
            ttbEnd.SetTime(StopTime);
            ttbBegin.Focus();
            ttbBegin.Select();
            tbPrefix.Text = Path.GetFileNameWithoutExtension(m_sFileName) + "-Extract";
            rbSaveMultiple.Checked = true;
            PasteTwo(false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void llPasteTwo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasteTwo(true);
        }

        private bool PasteTwo(bool bShowErrors)
        {
            if (!Clipboard.ContainsText())
            {
                if (bShowErrors)
                    MessageBox.Show("There is no text in the clipboard.", "No Text", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string strTimes = Clipboard.GetText();
            string[] times = strTimes.Split(new char[] { ' ', '\r', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (times.Length < 2)
            {
                if (bShowErrors)
                    MessageBox.Show("Could not parse the clipboard into two time values.", "Incompatible Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ttbBegin.SetText(times[0]);
            ttbEnd.SetText(times[1]);
            return true;
        }

        private void HandlePaste(KeyEventArgs e)
        {
            if (rbExtractSingle.Checked)
            {
                if (PasteTwo(false))
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void RangeExtractForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.V:
                    if (e.Modifiers.HasFlag(Keys.Control))
                        HandlePaste(e);
                    break;
                case Keys.Insert:
                    if (e.Modifiers.HasFlag(Keys.Shift))
                        HandlePaste(e);
                    break;
                default:
                    break;
            }
        }

        private void rbExtractSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExtractSingle.Checked)
            {
                rbSaveMultiple.Checked = false;
                tbTimes.Enabled = false;
                tbPrefix.Enabled = false;
                llPasteTwo.Enabled = true;
                cbKeep.Enabled = true;
                ttbBegin.Enabled = true;
                ttbEnd.Enabled = true;
            }
        }

        private void rbSaveMultiple_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSaveMultiple.Checked)
            {
                rbExtractSingle.Checked = false;
                tbTimes.Enabled = true;
                llPasteTwo.Enabled = false;
                tbPrefix.Enabled = true;
                cbKeep.Enabled = false;
                ttbBegin.Enabled = false;
                ttbEnd.Enabled = false;
            }
        }
    }
}
