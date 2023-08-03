namespace SubFutzer
{
    partial class RangeExtractForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbTimes = new System.Windows.Forms.TextBox();
            this.tbPrefix = new System.Windows.Forms.TextBox();
            this.panelSingleRange = new System.Windows.Forms.Panel();
            this.cbKeep = new System.Windows.Forms.ComboBox();
            this.ttbBegin = new SubFutzer.TimeTextBox();
            this.ttbEnd = new SubFutzer.TimeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.llPasteTwo = new System.Windows.Forms.LinkLabel();
            this.rbSaveMultiple = new System.Windows.Forms.RadioButton();
            this.rbExtractSingle = new System.Windows.Forms.RadioButton();
            this.cbShiftBack = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panelSingleRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(404, 209);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(485, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbTimes);
            this.groupBox1.Location = new System.Drawing.Point(32, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 118);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Times to extract";
            // 
            // tbTimes
            // 
            this.tbTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTimes.Enabled = false;
            this.tbTimes.Location = new System.Drawing.Point(3, 16);
            this.tbTimes.Multiline = true;
            this.tbTimes.Name = "tbTimes";
            this.tbTimes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTimes.Size = new System.Drawing.Size(519, 99);
            this.tbTimes.TabIndex = 0;
            // 
            // tbPrefix
            // 
            this.tbPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPrefix.Enabled = false;
            this.tbPrefix.Location = new System.Drawing.Point(238, 59);
            this.tbPrefix.Name = "tbPrefix";
            this.tbPrefix.Size = new System.Drawing.Size(319, 20);
            this.tbPrefix.TabIndex = 3;
            this.tbPrefix.Text = "Extract";
            // 
            // panelSingleRange
            // 
            this.panelSingleRange.Controls.Add(this.cbKeep);
            this.panelSingleRange.Controls.Add(this.ttbBegin);
            this.panelSingleRange.Controls.Add(this.ttbEnd);
            this.panelSingleRange.Controls.Add(this.label1);
            this.panelSingleRange.Controls.Add(this.label2);
            this.panelSingleRange.Controls.Add(this.llPasteTwo);
            this.panelSingleRange.Location = new System.Drawing.Point(32, 26);
            this.panelSingleRange.Name = "panelSingleRange";
            this.panelSingleRange.Size = new System.Drawing.Size(549, 24);
            this.panelSingleRange.TabIndex = 12;
            // 
            // cbKeep
            // 
            this.cbKeep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeep.FormattingEnabled = true;
            this.cbKeep.Items.AddRange(new object[] {
            "Keep only",
            "Remove"});
            this.cbKeep.Location = new System.Drawing.Point(0, 0);
            this.cbKeep.Name = "cbKeep";
            this.cbKeep.Size = new System.Drawing.Size(87, 21);
            this.cbKeep.TabIndex = 0;
            // 
            // ttbBegin
            // 
            this.ttbBegin.Location = new System.Drawing.Point(206, 0);
            this.ttbBegin.Name = "ttbBegin";
            this.ttbBegin.Size = new System.Drawing.Size(72, 24);
            this.ttbBegin.TabIndex = 2;
            // 
            // ttbEnd
            // 
            this.ttbEnd.Location = new System.Drawing.Point(315, 0);
            this.ttbEnd.Name = "ttbEnd";
            this.ttbEnd.Size = new System.Drawing.Size(72, 24);
            this.ttbEnd.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "the subtitles between";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "and";
            // 
            // llPasteTwo
            // 
            this.llPasteTwo.AutoSize = true;
            this.llPasteTwo.Location = new System.Drawing.Point(415, 3);
            this.llPasteTwo.Name = "llPasteTwo";
            this.llPasteTwo.Size = new System.Drawing.Size(110, 13);
            this.llPasteTwo.TabIndex = 5;
            this.llPasteTwo.TabStop = true;
            this.llPasteTwo.Text = "&Paste two time values";
            this.llPasteTwo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llPasteTwo_LinkClicked);
            // 
            // rbSaveMultiple
            // 
            this.rbSaveMultiple.AutoSize = true;
            this.rbSaveMultiple.Location = new System.Drawing.Point(14, 60);
            this.rbSaveMultiple.Name = "rbSaveMultiple";
            this.rbSaveMultiple.Size = new System.Drawing.Size(224, 17);
            this.rbSaveMultiple.TabIndex = 1;
            this.rbSaveMultiple.Text = "&Save multiple ranges using filename prefix:";
            this.rbSaveMultiple.UseVisualStyleBackColor = true;
            this.rbSaveMultiple.CheckedChanged += new System.EventHandler(this.rbSaveMultiple_CheckedChanged);
            // 
            // rbExtractSingle
            // 
            this.rbExtractSingle.AutoSize = true;
            this.rbExtractSingle.Checked = true;
            this.rbExtractSingle.Location = new System.Drawing.Point(14, 6);
            this.rbExtractSingle.Name = "rbExtractSingle";
            this.rbExtractSingle.Size = new System.Drawing.Size(127, 17);
            this.rbExtractSingle.TabIndex = 0;
            this.rbExtractSingle.TabStop = true;
            this.rbExtractSingle.Text = "&Extract a single range";
            this.rbExtractSingle.UseVisualStyleBackColor = true;
            this.rbExtractSingle.CheckedChanged += new System.EventHandler(this.rbExtractSingle_CheckedChanged);
            // 
            // cbShiftBack
            // 
            this.cbShiftBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbShiftBack.AutoSize = true;
            this.cbShiftBack.Checked = true;
            this.cbShiftBack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShiftBack.Location = new System.Drawing.Point(12, 213);
            this.cbShiftBack.Name = "cbShiftBack";
            this.cbShiftBack.Size = new System.Drawing.Size(348, 17);
            this.cbShiftBack.TabIndex = 5;
            this.cbShiftBack.Text = "S&hift subtitle times back according to the beginning of the time range";
            this.cbShiftBack.UseVisualStyleBackColor = true;
            // 
            // RangeExtractForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(569, 242);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbPrefix);
            this.Controls.Add(this.panelSingleRange);
            this.Controls.Add(this.rbSaveMultiple);
            this.Controls.Add(this.rbExtractSingle);
            this.Controls.Add(this.cbShiftBack);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(577, 269);
            this.Name = "RangeExtractForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Extract Subtitle Range";
            this.Load += new System.EventHandler(this.RangeExtractForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RangeExtractForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelSingleRange.ResumeLayout(false);
            this.panelSingleRange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TimeTextBox ttbBegin;
        private TimeTextBox ttbEnd;
        private System.Windows.Forms.ComboBox cbKeep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel llPasteTwo;
        private System.Windows.Forms.CheckBox cbShiftBack;
        private System.Windows.Forms.RadioButton rbExtractSingle;
        private System.Windows.Forms.RadioButton rbSaveMultiple;
        private System.Windows.Forms.TextBox tbTimes;
        private System.Windows.Forms.Panel panelSingleRange;
        private System.Windows.Forms.TextBox tbPrefix;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}