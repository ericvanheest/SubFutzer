using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for GoToLineForm.
	/// </summary>
	public class GoToLineForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbIndex;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GoToLineForm()
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
			this.tbIndex = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnGo
			// 
			this.btnGo.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnGo.Location = new System.Drawing.Point(56, 32);
			this.btnGo.Name = "btnGo";
			this.btnGo.TabIndex = 2;
			this.btnGo.Text = "&Go";
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(136, 32);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Go to subtitle index ";
			// 
			// tbIndex
			// 
			this.tbIndex.Location = new System.Drawing.Point(136, 5);
			this.tbIndex.Name = "tbIndex";
			this.tbIndex.Size = new System.Drawing.Size(75, 20);
			this.tbIndex.TabIndex = 4;
			this.tbIndex.Text = "";
			// 
			// GoToLineForm
			// 
			this.AcceptButton = this.btnGo;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(218, 63);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbIndex,
																		  this.label1,
																		  this.btnGo,
																		  this.btnCancel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "GoToLineForm";
			this.Text = "Go to";
			this.Load += new System.EventHandler(this.GoToLineForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void GoToLineForm_Load(object sender, System.EventArgs e)
		{
			tbIndex.Focus();
			tbIndex.Select();
		}

		private void btnGo_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		public int Index
		{
			get
			{
				try
				{
					return Convert.ToInt32(tbIndex.Text);
				}
				catch(Exception)
				{
					return 0;
				}
			}
			set
			{
				tbIndex.Text = value.ToString();
			}
		}

	}
}
