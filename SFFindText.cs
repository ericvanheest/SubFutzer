using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for SFFindText.
	/// </summary>
	public class SFFindText : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFindText;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnClose;

        private SubFutzerForm m_mainForm;
        public int iSearchIndex;
        private System.Windows.Forms.CheckBox checkReverse;
        private System.Windows.Forms.CheckBox checkWrap;
        private System.Windows.Forms.CheckBox checkMatchCase;
        private System.Windows.Forms.StatusBar statusBar1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SFFindText()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.tbFindText = new System.Windows.Forms.TextBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.checkReverse = new System.Windows.Forms.CheckBox();
            this.checkWrap = new System.Windows.Forms.CheckBox();
            this.checkMatchCase = new System.Windows.Forms.CheckBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Find what:";
            // 
            // tbFindText
            // 
            this.tbFindText.Location = new System.Drawing.Point(64, 8);
            this.tbFindText.Name = "tbFindText";
            this.tbFindText.Size = new System.Drawing.Size(240, 20);
            this.tbFindText.TabIndex = 1;
            // 
            // btnFindNext
            // 
            this.btnFindNext.Location = new System.Drawing.Point(312, 8);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(75, 23);
            this.btnFindNext.TabIndex = 2;
            this.btnFindNext.Text = "Find &next";
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(312, 80);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // checkReverse
            // 
            this.checkReverse.Location = new System.Drawing.Point(8, 40);
            this.checkReverse.Name = "checkReverse";
            this.checkReverse.Size = new System.Drawing.Size(104, 16);
            this.checkReverse.TabIndex = 3;
            this.checkReverse.Text = "&Reverse search";
            // 
            // checkWrap
            // 
            this.checkWrap.Checked = true;
            this.checkWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkWrap.Location = new System.Drawing.Point(8, 64);
            this.checkWrap.Name = "checkWrap";
            this.checkWrap.Size = new System.Drawing.Size(208, 16);
            this.checkWrap.TabIndex = 4;
            this.checkWrap.Text = "&Wrap around after finding last item.";
            // 
            // checkMatchCase
            // 
            this.checkMatchCase.Location = new System.Drawing.Point(8, 88);
            this.checkMatchCase.Name = "checkMatchCase";
            this.checkMatchCase.Size = new System.Drawing.Size(208, 16);
            this.checkMatchCase.TabIndex = 5;
            this.checkMatchCase.Text = "&Match case";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 113);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(392, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 7;
            this.statusBar1.Text = "Ready.";
            // 
            // SFFindText
            // 
            this.AcceptButton = this.btnFindNext;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(392, 135);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.checkReverse);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.tbFindText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkWrap);
            this.Controls.Add(this.checkMatchCase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SFFindText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Find Text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        public void SetMainForm(SubFutzerForm form)
        {
            m_mainForm = form;
            if (form.lvSubtitles.SelectedItems.Count > 0)
                iSearchIndex = form.lvSubtitles.SelectedItems[0].Index;
            else
                iSearchIndex = 0;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Hide();
        }

        private bool SearchInBounds()
        {
            if (iSearchIndex < 0)
                return false;
            else if (iSearchIndex >= m_mainForm.lvSubtitles.Items.Count)
                return false;
            return true;
        }

        private void FixSearchBounds()
        {
            int iMax = m_mainForm.lvSubtitles.Items.Count - 1;
            if (checkWrap.Checked)
            {
                if (iSearchIndex < 0)
                    iSearchIndex = iMax;
                else if (iSearchIndex > iMax)
                    iSearchIndex = 0;
            } 
            else
            {
                if (iSearchIndex < 0)
                    iSearchIndex = 0;
                else if (iSearchIndex > iMax)
                    iSearchIndex = iMax;
            }
        }

        public void SetStatus(string sText)
        {
            statusBar1.Text = sText;
            m_mainForm.SetStatus(sText);
        }

        public void SetReadyStatus()
        {
            SetStatus("Ready.");
        }

        private void btnFindNext_Click(object sender, System.EventArgs e)
        {
            FindNext();
        }

        public void FindNext()
        {
            SetReadyStatus();

            if (m_mainForm.lvSubtitles.Items.Count < 2)
            {
                return;
            }

            int iLastSearch = iSearchIndex;
            int iDirection = 1;
            if (checkReverse.Checked)
                iDirection = -1;
            bool bSearch = true;
            int iFail = 0;
            string sSearch, sText;

            if (checkMatchCase.Checked)
            {
                sSearch = tbFindText.Text;
            } 
            else
            {
                sSearch = tbFindText.Text.ToLower();
            }

            iSearchIndex += iDirection; // Skip the one we're currently on.

            if (!checkWrap.Checked && !SearchInBounds())
            {
                SetStatus("Search reached end of text.");
                iSearchIndex = iLastSearch;
                return;
            }

            while (bSearch)
            {
                FixSearchBounds();
                if (checkMatchCase.Checked)
                {
                    sText = ((Subtitle) m_mainForm.lvSubtitles.Items[iSearchIndex].Tag).Text;
                } 
                else
                {
                    sText = ((Subtitle) m_mainForm.lvSubtitles.Items[iSearchIndex].Tag).Text.ToLower();
                }
                if (sText.IndexOf(sSearch) != -1)
                {
                    // Found one
                    m_mainForm.lvSubtitles.SelectedItems.Clear();
                    m_mainForm.lvSubtitles.Items[iSearchIndex].Selected = true;
                    m_mainForm.lvSubtitles.EnsureVisible(iSearchIndex);
                    bSearch = false;
                    SetStatus("Found search text \"" + tbFindText.Text + "\" on line " + iSearchIndex.ToString());
                    return;
                }
                iSearchIndex += iDirection;
                if (!SearchInBounds())
                {
                    if (!checkWrap.Checked)
                    {
                        SetStatus("Search reached end of text.");
                        iSearchIndex = iLastSearch;
                        break;
                    }
                }
                iFail++;
                if (iFail > m_mainForm.lvSubtitles.Items.Count)
                    break;
            }

            SetStatus("Could not find text \"" + tbFindText.Text + "\"");
        }

        public string GetSearchText()
        {
            return tbFindText.Text;
        }

        protected override bool ProcessDialogKey(Keys key)
        {
            switch(key) 
            {
                case Keys.Escape:
                    Hide();
                    return true;
                default:
                    return base.ProcessDialogKey(key);
            }
        }
    }
}
