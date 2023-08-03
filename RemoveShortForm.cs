using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for RemoveShortForm.
	/// </summary>
	public class RemoveShortForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbDuration;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RemoveShortForm()
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
			this.btnGo = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbDuration = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnGo
			// 
			this.btnGo.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnGo.Location = new System.Drawing.Point(184, 40);
			this.btnGo.Name = "btnGo";
			this.btnGo.TabIndex = 2;
			this.btnGo.Text = "&Go";
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(264, 40);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(232, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Remove all subtitles with a duration less than ";
			// 
			// tbDuration
			// 
			this.tbDuration.Location = new System.Drawing.Point(240, 5);
			this.tbDuration.Name = "tbDuration";
			this.tbDuration.Size = new System.Drawing.Size(64, 20);
			this.tbDuration.TabIndex = 4;
			this.tbDuration.Text = "1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(312, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "ms.";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// RemoveShortForm
			// 
			this.AcceptButton = this.btnGo;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(346, 71);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbDuration,
																		  this.label1,
																		  this.btnGo,
																		  this.btnCancel,
																		  this.label2});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "RemoveShortForm";
			this.Text = "Remove short subtitles";
			this.Load += new System.EventHandler(this.RemoveShortForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void RemoveShortForm_Load(object sender, System.EventArgs e)
		{
			tbDuration.Focus();
			tbDuration.Select();
		}

		private void btnGo_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
		
		}

		public int Duration
		{
			get
			{
				try
				{
					return Convert.ToInt32(tbDuration.Text);
				}
				catch(Exception)
				{
					return 0;
				}
			}
			set
			{
				tbDuration.Text = value.ToString();
			}
		}

	}
}
