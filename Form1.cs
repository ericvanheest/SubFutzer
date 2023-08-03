using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace SubFutzer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.ColumnHeader chIndex;
        private System.Windows.Forms.ColumnHeader chStartTime;
        private System.Windows.Forms.ColumnHeader chStopTime;
        private System.Windows.Forms.ColumnHeader chDuration;
        private System.Windows.Forms.ColumnHeader chText;
        private System.Windows.Forms.MenuItem mi_File_New;
        private System.Windows.Forms.MenuItem mi_File_Open;
        private System.Windows.Forms.MenuItem mi_File_Close;
        private System.Windows.Forms.MenuItem mi_File_Save;
        private System.Windows.Forms.MenuItem mi_File_SaveAs;
        private System.Windows.Forms.MenuItem mi_File_Exit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListView lvSubtitles;
        private System.Windows.Forms.MenuItem menuItem2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private bool m_bDirty = false;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.MenuItem mi_File;
        private System.Windows.Forms.MenuItem mi_Edit;
        private System.Windows.Forms.MenuItem mi_Edit_Offset;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private SubFutzer.TimeTextBox ttbStart;
        private SubFutzer.TimeTextBox ttbStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSubtitle;
        private string m_sFileName;
        private System.Windows.Forms.Panel panelControls;
        private SubFutzer.TimeTextBox ttbOffset;
        private System.Windows.Forms.ComboBox cbWhatAction;
        private System.Windows.Forms.ComboBox cbWhichItems;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox checkLockTimes;

        bool m_bInitialized;

        public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            lvSubtitles.FullRowSelect = true;
            cbWhichItems.SelectedIndex = 0;
            cbWhatAction.SelectedIndex = 0;
            m_bInitialized = true;
            checkLockTimes.Checked = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.lvSubtitles = new System.Windows.Forms.ListView();
            this.chIndex = new System.Windows.Forms.ColumnHeader();
            this.chStartTime = new System.Windows.Forms.ColumnHeader();
            this.chStopTime = new System.Windows.Forms.ColumnHeader();
            this.chDuration = new System.Windows.Forms.ColumnHeader();
            this.chText = new System.Windows.Forms.ColumnHeader();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mi_File = new System.Windows.Forms.MenuItem();
            this.mi_File_New = new System.Windows.Forms.MenuItem();
            this.mi_File_Open = new System.Windows.Forms.MenuItem();
            this.mi_File_Close = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.mi_File_Save = new System.Windows.Forms.MenuItem();
            this.mi_File_SaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mi_File_Exit = new System.Windows.Forms.MenuItem();
            this.mi_Edit = new System.Windows.Forms.MenuItem();
            this.mi_Edit_Offset = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbWhichItems = new System.Windows.Forms.ComboBox();
            this.cbWhatAction = new System.Windows.Forms.ComboBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.ttbOffset = new SubFutzer.TimeTextBox();
            this.tbSubtitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ttbStart = new SubFutzer.TimeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ttbStop = new SubFutzer.TimeTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkLockTimes = new System.Windows.Forms.CheckBox();
            this.panelControls.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSubtitles
            // 
            this.lvSubtitles.AllowDrop = true;
            this.lvSubtitles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                          this.chIndex,
                                                                                          this.chStartTime,
                                                                                          this.chStopTime,
                                                                                          this.chDuration,
                                                                                          this.chText});
            this.lvSubtitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubtitles.HideSelection = false;
            this.lvSubtitles.Name = "lvSubtitles";
            this.lvSubtitles.Size = new System.Drawing.Size(648, 235);
            this.lvSubtitles.TabIndex = 0;
            this.lvSubtitles.View = System.Windows.Forms.View.Details;
            this.lvSubtitles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvSubtitles_DragDrop);
            this.lvSubtitles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvSubtitles_DragEnter);
            this.lvSubtitles.SelectedIndexChanged += new System.EventHandler(this.lvSubtitles_SelectedIndexChanged);
            // 
            // chIndex
            // 
            this.chIndex.Text = "Index";
            this.chIndex.Width = 50;
            // 
            // chStartTime
            // 
            this.chStartTime.Text = "Start";
            // 
            // chStopTime
            // 
            this.chStopTime.Text = "Stop";
            // 
            // chDuration
            // 
            this.chDuration.Text = "Duration";
            // 
            // chText
            // 
            this.chText.Text = "Subtitle Text";
            this.chText.Width = 400;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.mi_File,
                                                                                      this.mi_Edit});
            // 
            // mi_File
            // 
            this.mi_File.Index = 0;
            this.mi_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                    this.mi_File_New,
                                                                                    this.mi_File_Open,
                                                                                    this.mi_File_Close,
                                                                                    this.menuItem10,
                                                                                    this.mi_File_Save,
                                                                                    this.mi_File_SaveAs,
                                                                                    this.menuItem2,
                                                                                    this.mi_File_Exit});
            this.mi_File.Text = "&File";
            // 
            // mi_File_New
            // 
            this.mi_File_New.Index = 0;
            this.mi_File_New.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.mi_File_New.Text = "&New";
            this.mi_File_New.Click += new System.EventHandler(this.mi_File_New_Click);
            // 
            // mi_File_Open
            // 
            this.mi_File_Open.Index = 1;
            this.mi_File_Open.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.mi_File_Open.Text = "&Open...";
            this.mi_File_Open.Click += new System.EventHandler(this.mi_File_Open_Click);
            // 
            // mi_File_Close
            // 
            this.mi_File_Close.Index = 2;
            this.mi_File_Close.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            this.mi_File_Close.Text = "&Close";
            this.mi_File_Close.Click += new System.EventHandler(this.mi_File_Close_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 3;
            this.menuItem10.Text = "-";
            // 
            // mi_File_Save
            // 
            this.mi_File_Save.Index = 4;
            this.mi_File_Save.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.mi_File_Save.Text = "&Save";
            this.mi_File_Save.Click += new System.EventHandler(this.mi_File_Save_Click);
            // 
            // mi_File_SaveAs
            // 
            this.mi_File_SaveAs.Index = 5;
            this.mi_File_SaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.mi_File_SaveAs.Text = "Save &as...";
            this.mi_File_SaveAs.Click += new System.EventHandler(this.mi_File_SaveAs_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 6;
            this.menuItem2.Text = "-";
            // 
            // mi_File_Exit
            // 
            this.mi_File_Exit.Index = 7;
            this.mi_File_Exit.Text = "E&xit";
            // 
            // mi_Edit
            // 
            this.mi_Edit.Index = 1;
            this.mi_Edit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                    this.mi_Edit_Offset});
            this.mi_Edit.Text = "&Edit";
            // 
            // mi_Edit_Offset
            // 
            this.mi_Edit_Offset.Index = 0;
            this.mi_Edit_Offset.Text = "&Offset";
            this.mi_Edit_Offset.Click += new System.EventHandler(this.mi_Edit_Offset_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "doc1";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 361);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(648, 24);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "Ready.";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 358);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(648, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // panelControls
            // 
            this.panelControls.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                        this.checkLockTimes,
                                                                                        this.btnUpdate,
                                                                                        this.cbWhichItems,
                                                                                        this.cbWhatAction,
                                                                                        this.btnChange,
                                                                                        this.ttbOffset,
                                                                                        this.tbSubtitle,
                                                                                        this.label3,
                                                                                        this.ttbStart,
                                                                                        this.label1,
                                                                                        this.ttbStop,
                                                                                        this.label2});
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 238);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(648, 120);
            this.panelControls.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(568, 72);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbWhichItems
            // 
            this.cbWhichItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWhichItems.Items.AddRange(new object[] {
                                                              "All items",
                                                              "Selected items"});
            this.cbWhichItems.Location = new System.Drawing.Point(8, 8);
            this.cbWhichItems.Name = "cbWhichItems";
            this.cbWhichItems.Size = new System.Drawing.Size(96, 21);
            this.cbWhichItems.TabIndex = 0;
            // 
            // cbWhatAction
            // 
            this.cbWhatAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWhatAction.Items.AddRange(new object[] {
                                                              "Shift backwards by",
                                                              "Shift forwards by",
                                                              "Set first item to"});
            this.cbWhatAction.Location = new System.Drawing.Point(104, 8);
            this.cbWhatAction.Name = "cbWhatAction";
            this.cbWhatAction.Size = new System.Drawing.Size(120, 21);
            this.cbWhatAction.TabIndex = 1;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(208, 32);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(88, 23);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "&Change times";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // ttbOffset
            // 
            this.ttbOffset.Location = new System.Drawing.Point(224, 8);
            this.ttbOffset.Name = "ttbOffset";
            this.ttbOffset.Size = new System.Drawing.Size(72, 24);
            this.ttbOffset.TabIndex = 2;
            // 
            // tbSubtitle
            // 
            this.tbSubtitle.Location = new System.Drawing.Point(368, 8);
            this.tbSubtitle.Multiline = true;
            this.tbSubtitle.Name = "tbSubtitle";
            this.tbSubtitle.Size = new System.Drawing.Size(280, 56);
            this.tbSubtitle.TabIndex = 5;
            this.tbSubtitle.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(328, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Text:";
            // 
            // ttbStart
            // 
            this.ttbStart.Location = new System.Drawing.Point(368, 72);
            this.ttbStart.Name = "ttbStart";
            this.ttbStart.Size = new System.Drawing.Size(72, 24);
            this.ttbStart.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(328, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "&Start:";
            // 
            // ttbStop
            // 
            this.ttbStop.Location = new System.Drawing.Point(488, 72);
            this.ttbStop.Name = "ttbStop";
            this.ttbStop.Size = new System.Drawing.Size(72, 24);
            this.ttbStop.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(448, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sto&p:";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 235);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(648, 3);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            this.splitter2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                 this.lvSubtitles});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 235);
            this.panel1.TabIndex = 7;
            // 
            // checkLockTimes
            // 
            this.checkLockTimes.Location = new System.Drawing.Point(368, 96);
            this.checkLockTimes.Name = "checkLockTimes";
            this.checkLockTimes.Size = new System.Drawing.Size(272, 16);
            this.checkLockTimes.TabIndex = 11;
            this.checkLockTimes.Text = "C&hange stop time if start time is changed.";
            this.checkLockTimes.CheckedChanged += new System.EventHandler(this.checkLockTimes_CheckedChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(648, 385);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.panel1,
                                                                          this.splitter2,
                                                                          this.panelControls,
                                                                          this.splitter1,
                                                                          this.statusBar1});
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "SubFutzer";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.panelControls.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

        private bool ClearCurrentFile()
        {
            if ((lvSubtitles.Items.Count > 0) && (m_bDirty))
            {
                if (MessageBox.Show("This will clear all of the current subtitles.  Continue?", "Clear all subtitles?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false;
            }

            lvSubtitles.Items.Clear();
            m_bDirty = false;
            SetFileName("");

            return true;
        }

        private void mi_File_Open_Click(object sender, System.EventArgs e)
        {
            if (!ClearCurrentFile())
                return;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReadSubtitleFile(openFileDialog1.FileName);
            }
        }

        private int GetNextNumber(string sNumbers, ref int iIndex)
        {
            int iStart = iIndex;

            while (true)
            {
                iIndex++;
                if (iIndex >= sNumbers.Length)
                    break;
                if (!Char.IsDigit(sNumbers,iIndex))
                    break;
            }

            return Convert.ToInt32(sNumbers.Substring(iStart, iIndex - iStart));
        }

        private Subtitle ReadSubtitle(StreamReader reader)
        {
            Subtitle sub = new Subtitle();
            string sLine = "";
            bool bContinue = true;

            // Read the index number
            while (bContinue)
            {
                sLine = reader.ReadLine();
                if (reader.Peek() == -1)
                    return sub;
                if (sLine.Length < 1)
                    continue;
                if (Char.IsDigit(sLine, 0))
                    break;
            }

            sub.Index = Convert.ToInt32(sLine, 10);

            // Read the start/stop times
            sLine = "";
            while (bContinue)
            {
                sLine = reader.ReadLine();
                if (reader.Peek() == -1)
                    return sub;
                if (sLine.Length < 1)
                    continue;
                if (Char.IsDigit(sLine, 0))
                    break;
            }

            int[] iNumbers = new int[8] {0,0,0,0,0,0,0,0};
            int iIndex = 0;

            for (int i = 0; i < 8; i++)
            {
                iNumbers[i] = GetNextNumber(sLine, ref iIndex);
                while (bContinue)
                {
                    iIndex++;
                    if (iIndex >= sLine.Length)
                        break;
                    if (Char.IsDigit(sLine, iIndex))
                        break;
                }
                if (iIndex >= sLine.Length)
                    break;
            }

            sub.StartTime = new DateTime(1, 1, 1, iNumbers[0], iNumbers[1], iNumbers[2], iNumbers[3]);
            sub.StopTime = new DateTime(1, 1, 1, iNumbers[4], iNumbers[5], iNumbers[6], iNumbers[7]);

            // Read the subtitles
            sub.Text = "";
            do
            {
                if (reader.Peek() == -1)
                    return sub;

                sLine = reader.ReadLine();
                if ((sub.Text.Length > 0) && (sLine != ""))
                    sub.Text += "\r\n";

                sub.Text += sLine;
            } while (sLine != "");
            
            sub.Valid = true;
            return sub;
        }

        private int InsertSubtitleIntoList(Subtitle sub)
        {
            ListViewItem lvItem = new ListViewItem();
            UpdateLVItem(lvItem, sub);
            return lvSubtitles.Items.Add(lvItem).Index;
        }

        private void UpdateLVItem(ListViewItem lvItem, Subtitle sub)
        {
            lvItem.Tag = sub;
            lvItem.SubItems.Clear();
            lvItem.Text = sub.Index.ToString();
            lvItem.SubItems.Add(sub.StartTime.ToString("HH:mm:ss.fff"));
            lvItem.SubItems.Add(sub.StopTime.ToString("HH:mm:ss.fff"));
            lvItem.SubItems.Add((sub.StopTime - sub.StartTime).TotalMilliseconds.ToString());
            lvItem.SubItems.Add(sub.Text);
        }

        private void UpdateLVItem(ListViewItem lvItem)
        {
            UpdateLVItem(lvItem, (Subtitle) lvItem.Tag);
        }

        private void UpdateProgress(long iCurrent, long iMaximum)
        {
            statusBar1.Text = "Parsing: " + (iCurrent * 100 / (double) iMaximum).ToString("0.0") + "%";
        }

        private void ReadSubtitleFile(string sFileName)
        {
            lvSubtitles.SuspendLayout();
            StreamReader reader = new StreamReader(sFileName);
            Subtitle sub;
            while (reader.Peek() != -1)
            {
                sub = ReadSubtitle(reader);
                if (sub.Valid)
                    InsertSubtitleIntoList(sub);
                UpdateProgress(reader.BaseStream.Position, reader.BaseStream.Length);
            }
            reader.Close();
            foreach(ColumnHeader ch in lvSubtitles.Columns)
            {
                ch.Width = -2;
            }

            lvSubtitles.ResumeLayout();
            m_bDirty = false;
            SetFileName(sFileName);
            SetReadyStatus();
        }

        private void SetReadyStatus()
        {
            statusBar1.Text = "Ready.";
        }

        private void Form1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            GenericDragDrop(sender, e);
        }

        private void GenericDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] saFiles = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (saFiles.Length > 0)
            {
                if (File.Exists(saFiles[0]))
                {
                    if (ClearCurrentFile())
                        ReadSubtitleFile(saFiles[0]);
                }
            }
        }

        private void lvSubtitles_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            GenericDragDrop(sender, e);
        }

        private void Form1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Generic_DragEnter(sender, e);
        }

        private void Generic_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void lvSubtitles_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Generic_DragEnter(sender, e);
        }

        private void mi_File_Close_Click(object sender, System.EventArgs e)
        {
            ClearCurrentFile();
        }

        private void mi_File_New_Click(object sender, System.EventArgs e)
        {
            ClearCurrentFile();
        }

        private void SaveFileAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile(saveFileDialog1.FileName);
            }
        }

        private void WriteSubtitle(StreamWriter writer, ListViewItem lvItem)
        {
            Subtitle sub = (Subtitle) lvItem.Tag;

            writer.WriteLine(sub.Index);
            writer.WriteLine("{0:00}:{1:00}:{2:00},{3:000} --> {4:00}:{5:00}:{6:00},{7:000}",
                sub.StartTime.Hour,
                sub.StartTime.Minute,
                sub.StartTime.Second,
                sub.StartTime.Millisecond,
                sub.StopTime.Hour,
                sub.StopTime.Minute,
                sub.StopTime.Second,
                sub.StopTime.Millisecond);

            writer.WriteLine(sub.Text + "\r\n");
        }

        private void SaveFile(string sFileName)
        {
            SetFileName(sFileName);

            int iIndex = 0;
            try
            {
                StreamWriter writer = new StreamWriter(sFileName);
                while (iIndex < lvSubtitles.Items.Count)
                {
                    WriteSubtitle(writer, lvSubtitles.Items[iIndex]);
                    iIndex++;
                }
                writer.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Could not write to file \"" + sFileName + "\" (Error: " + e.Message + ")");
            }
        }

        private void SetFileName(string sFileName)
        {
            m_sFileName = sFileName;
            if (sFileName != "")
                this.Text = "SubFutzer - " + sFileName;
            else
                this.Text = "SubFutzer";
        }

        private void mi_File_Save_Click(object sender, System.EventArgs e)
        {
            if (m_sFileName == "")
                SaveFileAs();
            else
                SaveFile(m_sFileName);
        }

        private void mi_File_SaveAs_Click(object sender, System.EventArgs e)
        {
            SaveFileAs();
        }

        private void mi_Edit_Offset_Click(object sender, System.EventArgs e)
        {
        
        }

        private void lvSubtitles_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvSubtitles.SelectedItems.Count < 1)
                return;

            Subtitle sub = (Subtitle) lvSubtitles.SelectedItems[0].Tag;
            tbSubtitle.Text = sub.Text;
            ttbStart.SetTime(sub.StartTime);
            ttbStop.SetTime(sub.StopTime);
            LockTimes();
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (!m_bInitialized)
                return;

            int iWidth = panelControls.Width - tbSubtitle.Left;
            if (iWidth > 30)
                tbSubtitle.Width = iWidth;
        }

        private void OffsetSubtitle(ListViewItem lvItem, TimeSpan ts)
        {
            Subtitle sub = (Subtitle) lvItem.Tag;
            try
            {
                sub.StartTime += ts;
            }
            catch
            {
                sub.StartTime = new DateTime(1, 1, 1, 0, 0, 0, 0);
            }
            try
            {
                sub.StopTime += ts;
            }
            catch
            {
                sub.StopTime = new DateTime(1, 1, 1, 0, 0, 0, 0);
            }
            UpdateLVItem(lvItem);
        }

        private void OffsetSubtitles(TimeSpan ts)
        {
            if (cbWhichItems.SelectedIndex == 0)
            {
                foreach(ListViewItem lvItem in lvSubtitles.Items)
                {
                    OffsetSubtitle(lvItem, ts);
                }
            } 
            else
            {
                foreach(ListViewItem lvItem in lvSubtitles.SelectedItems)
                {
                    OffsetSubtitle(lvItem, ts);
                }
            }
        }

        private void SetFirstItem()
        {
            Subtitle sub;
            if (cbWhichItems.SelectedIndex == 0)
            {
                if (lvSubtitles.Items.Count < 1)
                    return;
                sub = (Subtitle) lvSubtitles.Items[0].Tag;
            } 
            else
            {
                if (lvSubtitles.SelectedItems.Count < 1)
                    return;
                sub = (Subtitle) lvSubtitles.SelectedItems[0].Tag;
            }
            TimeSpan ts = ttbOffset.GetTime() - TimeTextBox.DateTimeToTimeSpan(sub.StartTime);
            OffsetSubtitles(ts);
        }

        private void btnChange_Click(object sender, System.EventArgs e)
        {
            switch(cbWhatAction.SelectedIndex)
            {
                case 0: // Backwards
                    OffsetSubtitles(-ttbOffset.GetTime());
                    m_bDirty = true;
                    break;
                case 1: // Forwards
                    OffsetSubtitles(ttbOffset.GetTime());
                    m_bDirty = true;
                    break;
                case 2: // Set first item
                    SetFirstItem();
                    m_bDirty = true;
                    break;
                default:
                    break;
            }
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (lvSubtitles.SelectedItems.Count < 1)
                return;

            ListViewItem lvItem = lvSubtitles.SelectedItems[0];
            Subtitle sub = (Subtitle) lvItem.Tag;
            sub.Text = tbSubtitle.Text;
            sub.StartTime = TimeTextBox.TimeSpanToDateTime(ttbStart.GetTime());
            sub.StopTime = TimeTextBox.TimeSpanToDateTime(ttbStop.GetTime());
            UpdateLVItem(lvItem);
        }

        private void LockTimes()
        {
            if (checkLockTimes.Checked)
            {
                ttbStart.SetLock(ttbStop);
            } 
            else
            {
                ttbStart.SetLock(null);
            }
        }

        private void checkLockTimes_CheckedChanged(object sender, System.EventArgs e)
        {
            LockTimes();
        }
	}
}
