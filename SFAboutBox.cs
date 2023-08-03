using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for SFAboutBox.
	/// </summary>
	public class SFAboutBox : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label labelVersion;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SFAboutBox()
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "SubFutzer is copyright © 2002-2015 by Eric VanHeest";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please feel free to copy distribute, or modify this program as you see fit, as lo" +
    "ng as this notice remains.";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(328, 96);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(8, 8);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(376, 23);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "SubFutzer [version]";
            // 
            // SFAboutBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(408, 127);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SFAboutBox";
            this.Text = "About SubFutzer";
            this.Load += new System.EventHandler(this.SFAboutBox_Load);
            this.ResumeLayout(false);

		}
		#endregion

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        protected override bool ProcessDialogKey(Keys key)
        {
            switch(key) 
            {
                case Keys.Escape:
                    Close();
                    return true;
                default:
                    return base.ProcessDialogKey(key);
            }
        }

		private void SFAboutBox_Load(object sender, System.EventArgs e)
		{
			labelVersion.Text = labelVersion.Text.Replace("[version]", Global.GetVersion());
		}
	}
}
