using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for TimeTextBox.
	/// </summary>
	public class TimeTextBox : System.Windows.Forms.UserControl
	{
        private System.Windows.Forms.TextBox tbTime;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        TimeTextBox ttbLocked = null;
        TimeSpan tsLockSpan;

        enum TimeSegment 
        {
            Hours,
            Minutes,
            Seconds,
            Milliseconds
        }

		public TimeTextBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tbTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbTime
            // 
            this.tbTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTime.Location = new System.Drawing.Point(0, 0);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(72, 20);
            this.tbTime.TabIndex = 0;
            this.tbTime.Text = "00:00:00.000";
            this.tbTime.TextChanged += new System.EventHandler(this.tbTime_TextChanged);
            this.tbTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTime_KeyDown);
            // 
            // TimeTextBox
            // 
            this.Controls.Add(this.tbTime);
            this.Name = "TimeTextBox";
            this.Size = new System.Drawing.Size(72, 24);
            this.Leave += new System.EventHandler(this.TimeTextBox_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        public void SetLock(TimeTextBox ttb)
        {
            ttbLocked = ttb;
            if (ttb == null)
                return;

            if (ttb.GetLock() == this)
                ttb.SetLock(null);      // Prevent trivial recursive loops
            tsLockSpan = ttb.GetTime() - GetTime();
        }

        public TimeTextBox GetLock()
        {
            return ttbLocked;
        }

        private void GetSegment(int iSel, out int iStart, out int iEnd, out TimeSegment segment)
        {
            GetSegmentStart(iSel, out iStart, out segment);
            iEnd = iStart;
            while (iEnd < tbTime.Text.Length)
            {
                if (!Char.IsDigit(tbTime.Text,iEnd))
                    break;
                iEnd++;
            }
        }

        private void GetSegmentStart(int iSel, out int iStart, out TimeSegment segment)
        {
            iStart = 0;
            int iIndex = 0;
            segment = TimeSegment.Hours;
            while (tbTime.Text[iIndex] != ':')
            {
                iIndex++;
                if (iIndex >= iSel)
                    return;
            }
            segment = TimeSegment.Minutes;
            iIndex++;
            iStart = iIndex;
            while (tbTime.Text[iIndex] != ':')
            {
                iIndex++;
                if (iIndex >= iSel)
                    return;
            }
            segment = TimeSegment.Seconds;
            iIndex++;
            iStart = iIndex;
            while (tbTime.Text[iIndex] != '.')
            {
                iIndex++;
                if (iIndex >= iSel)
                    return;
            }
            segment = TimeSegment.Milliseconds;
            iIndex++;
            iStart = iIndex;
            return;
        }

        private void CheckTime(TimeSegment segment, ref int iTime)
        {

            switch(segment)
            {
                case TimeSegment.Hours:
                    if (iTime > 99)
                    {
                        iTime = 0;
                    }
                    if (iTime < 0)
                    {
                        iTime = 99;
                    }
                    break;
                case TimeSegment.Minutes:
                case TimeSegment.Seconds:
                    if (iTime > 59)
                    {
                        iTime = 0;
                    }
                    if (iTime < 0)
                    {
                        iTime = 59;
                    }
                    break;
                case TimeSegment.Milliseconds:
                    if (iTime > 999)
                    {
                        iTime = 0;
                    }
                    if (iTime < 0)
                    {
                        iTime = 999;
                    }
                    break;
                default:
                    break;
            }

        }

        public void ChangeTime(int iChange)
        {
            int iSel = tbTime.SelectionStart;
            int iStart, iEnd;
            TimeSegment segment;

            GetSegment(iSel, out iStart, out iEnd, out segment);

            int iTime = 0;
            if (iEnd > iStart)
            {
                iTime = Convert.ToInt32(tbTime.Text.Substring(iStart,iEnd-iStart));
            } 

            iTime += iChange;

            CheckTime(segment, ref iTime);

            tbTime.SelectionStart = iStart;
            tbTime.SelectionLength = iEnd - iStart;
            if (segment == TimeSegment.Milliseconds)
                tbTime.SelectedText = iTime.ToString("000");
            else
                tbTime.SelectedText = iTime.ToString("00");
            tbTime.SelectionStart = iStart;
            tbTime.SelectionLength = iEnd - iStart;

            if (ttbLocked != null)
                ttbLocked.SetTime(GetTime() + tsLockSpan);
        }

        private void tbTime_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Up:
                    ChangeTime(1);
                    e.Handled = true;
                    break;
                case Keys.Down:
                    ChangeTime(-1);
                    e.Handled = true;
                    break;
                case Keys.Back:
                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }

        public void SetText(string str)
        {
            tbTime.Text = str;
            ValidateTime();
        }
        
        private void ValidateTime()
        {
            tbTime.Text = Global.NormalizeTimeString(tbTime.Text);

            if (ttbLocked != null)
                ttbLocked.SetTime(GetTime() + tsLockSpan);
        }

        private int FixMilliseconds(int iMilliseconds)
        {
/*
            if (iMilliseconds < 10)
                return iMilliseconds * 100;
            if (iMilliseconds < 100)
                return iMilliseconds * 10;
*/                
            if (iMilliseconds >= 1000)
                return Convert.ToInt32(iMilliseconds.ToString().Substring(0,3));
            return iMilliseconds;
        }

        private void tbTime_TextChanged(object sender, System.EventArgs e)
        {
        }

        private void TimeTextBox_Leave(object sender, System.EventArgs e)
        {
            ValidateTime();
        }

        public void SetTime(DateTime dt)
        {
            tbTime.Text = dt.ToString("HH:mm:ss.fff");
        }

        public void SetTime(TimeSpan ts)
        {
            SetTime(TimeToolbox.TimeSpanToDateTime(ts));
        }

        public TimeSpan GetTime()
        {
            return Global.TimeSpanFromString(tbTime.Text);
        }

        public void SelectAll()
        {
            tbTime.SelectionStart = 0;
            tbTime.SelectionLength = tbTime.Text.Length;
        }
	}
}
