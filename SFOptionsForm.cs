using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for SFOptionsForm.
	/// </summary>
	public class SFOptionsForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDefaultJobs;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOutFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.CheckBox cbStripLanguage;

        public SFOptions m_options;

		public SFOptionsForm()
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
            this.tbDefaultJobs = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOutFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.cbStripLanguage = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default VirtualDub .jobs file:";
            // 
            // tbDefaultJobs
            // 
            this.helpProvider1.SetHelpString(this.tbDefaultJobs, "This is the file that is used for the \"Process default .jobs file\" command on the" +
                " Action menu.");
            this.tbDefaultJobs.Location = new System.Drawing.Point(152, 8);
            this.tbDefaultJobs.Name = "tbDefaultJobs";
            this.helpProvider1.SetShowHelp(this.tbDefaultJobs, true);
            this.tbDefaultJobs.Size = new System.Drawing.Size(296, 20);
            this.tbDefaultJobs.TabIndex = 1;
            this.tbDefaultJobs.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(458, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(378, 88);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBrowse
            // 
            this.helpProvider1.SetHelpString(this.btnBrowse, "Press \"Browse\" to search for the VirtualDub .jobs file");
            this.btnBrowse.Location = new System.Drawing.Point(456, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.helpProvider1.SetShowHelp(this.btnBrowse, true);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Subtitle output filename:";
            // 
            // tbOutFormat
            // 
            this.helpProvider1.SetHelpString(this.tbOutFormat, "This is the filename pattern that is used during job processing.  One example mig" +
                "ht be \"%N-English_Subtitles.srt\"");
            this.tbOutFormat.Location = new System.Drawing.Point(152, 40);
            this.tbOutFormat.Name = "tbOutFormat";
            this.helpProvider1.SetShowHelp(this.tbOutFormat, true);
            this.tbOutFormat.Size = new System.Drawing.Size(296, 20);
            this.tbOutFormat.TabIndex = 1;
            this.tbOutFormat.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "%N = original base filename";
            // 
            // cbStripLanguage
            // 
            this.cbStripLanguage.Checked = true;
            this.cbStripLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStripLanguage.Location = new System.Drawing.Point(152, 64);
            this.cbStripLanguage.Name = "cbStripLanguage";
            this.cbStripLanguage.Size = new System.Drawing.Size(296, 24);
            this.cbStripLanguage.TabIndex = 6;
            this.cbStripLanguage.Text = "Strip \"-English\" and such from titles before saving.";
            // 
            // SFOptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(538, 119);
            this.Controls.Add(this.cbStripLanguage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbDefaultJobs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbOutFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SubFutzer Options";
            this.Load += new System.EventHandler(this.SFOptionsForm_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            m_options.sVDJobsFile = tbDefaultJobs.Text;
            m_options.sSubOutFormat = tbOutFormat.Text;
            m_options.bStripLanguage = cbStripLanguage.Checked;
            m_options.WriteToRegistry();
            Close();
        }

        private void SFOptionsForm_Load(object sender, System.EventArgs e)
        {
            tbDefaultJobs.Text = m_options.sVDJobsFile;
            tbOutFormat.Text = m_options.sSubOutFormat;
            cbStripLanguage.Checked = m_options.bStripLanguage;
        }

        private void btnBrowse_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.DefaultExt = "jobs";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select the .jobs file to use as the default";
            openFileDialog1.Filter = "VirtualDub job files (*.jobs)|*.jobs|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbDefaultJobs.Text = openFileDialog1.FileName;
            }
        }
	}
}
