using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubFutzer
{
    public partial class SubFutzerForm : SelectAllForm
    {
        private SFFindText dlgFindText = new SFFindText();
        public SFOptions m_options = new SFOptions();
        private CommandProcessor m_cmdProc = null;
        private bool m_bDirty = false;
        private string m_sFileName;
        private List<Subtitle> m_undoData = new List<Subtitle>();
        private List<Subtitle> m_redoData = new List<Subtitle>();
        private Dictionary<ToolStripMenuItem, string> m_dictMenuHelp;

        public SubFutzerForm()
        {
            InitializeComponent();

            cbWhichItems.SelectedIndex = 0;
            cbWhatAction.SelectedIndex = 0;
            checkLockTimes.Checked = true;
            tbMaxLength.Text = m_options.iLineLength.ToString();
            dlgFindText.ShowInTaskbar = false;
            dlgFindText.SetMainForm(this);
            dlgFindText.Visible = false;
            dlgFindText.CreateControl();
            dlgFindText.DesktopLocation = new Point(0, 0);
            CreateMRUList();

            m_cmdProc = new CommandProcessor(this);

            ProcessArgs();

            InitHelpDictionary();

            m_cmdProc.Run();
        }

        private void InitHelpDictionary()
        {
            m_dictMenuHelp = new Dictionary<ToolStripMenuItem, string>();
            m_dictMenuHelp.Add(miFileNew, "Clears the current subtitle list.");
            m_dictMenuHelp.Add(miFileOpen, "Loads an existing subtitle file.");
            m_dictMenuHelp.Add(miFileMerge, "Merges an existing subtitle file with the current one.");
            m_dictMenuHelp.Add(miFileClose, "Closes the current file.");
            m_dictMenuHelp.Add(miFileSave, "Saves the current subtitle file.");
            m_dictMenuHelp.Add(miFileSaveAs, "Saves the current subtitle file with a new name.");
            m_dictMenuHelp.Add(miFileExit, "Exit SubFutzer.");
            m_dictMenuHelp.Add(miEditUndo, "Undo/Redo the previous action.");
            m_dictMenuHelp.Add(miEditOptions, "View or change the SubFutzer options.");
            m_dictMenuHelp.Add(miActionRenumber, "Re-indexes the current file from 1-N.");
            m_dictMenuHelp.Add(miActionProcessJobs, "Selects a VirtualDub job file to process.");
            m_dictMenuHelp.Add(miActionProcessDefaultJobs, "Process the VirtualDub job file (set via the Options page).");
            m_dictMenuHelp.Add(miHelpAbout, "Display the \"About\" box.");
            m_dictMenuHelp.Add(miEditFind, "Find a subtitle containing specific text.");
            m_dictMenuHelp.Add(miEditFindNext, "Find the next subtitle matching the search string.");
            m_dictMenuHelp.Add(miEditGotoLine, "Go to a specific subtitle index.");
            m_dictMenuHelp.Add(miEditSelectAll, "Select all text or subtitles.");
            m_dictMenuHelp.Add(miEditMoveNext, "Select the next subtitle.");
            m_dictMenuHelp.Add(miEditMovePrevious, "Select the previous subtitle.");
            m_dictMenuHelp.Add(miActionCollapseSequential, "Combine adjacent subtitles into a single one.");
            m_dictMenuHelp.Add(miActionExtractRange, "Remove or keep only subtitles withing a certain time range.");
            m_dictMenuHelp.Add(miActionMoveDown, "Move the selected subtitles down one index.");
            m_dictMenuHelp.Add(miActionMoveUp, "Move the selected subtitle up one index.");
            m_dictMenuHelp.Add(miActionRemoveDuplicate, "Remove duplicated lines within subtitles.");
            m_dictMenuHelp.Add(miActionRemoveShort, "Remove subtitles with durations less than a particular length.");
            m_dictMenuHelp.Add(miContextDeleteAllExcept, "Delete all of the subtitles except for those that are selected.");
            m_dictMenuHelp.Add(miContextDeleteSelected, "Delete all of the selected subtitles.");
            m_dictMenuHelp.Add(miContextInsert, "Insert a new subtitle before the currently selected one.");
            m_dictMenuHelp.Add(miContextMerge, "Merge all selected subtitles into one subtitle.");

            SetMenuSelectEvents(menuStrip1.Items);
            SetMenuSelectEvents(cmSubtitles.Items);
        }

        enum NextArg { None, CommandFile };

        private void ProcessArgs()
        {
            NextArg nextArg = NextArg.None;

            foreach (string sArg in Environment.GetCommandLineArgs())
            {
                switch (nextArg)
                {
                    case NextArg.None:
                        if (sArg[0] == '-')
                        {
                            foreach (char c in sArg.Substring(1))
                            {
                                switch (c)
                                {
                                    case 'f':
                                    case 'F':
                                        nextArg = NextArg.CommandFile;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // Unknown argument, or our own executable name (arg 0)
                        }
                        break;
                    case NextArg.CommandFile:
                        m_cmdProc.SetFile(sArg);
                        nextArg = NextArg.None;
                        break;
                }
            }
        }

        private bool CanClearCurrentFile()
        {
            if ((lvSubtitles.Items.Count > 0) && (m_bDirty))
            {
                if (MessageBox.Show(this, "This will clear all of the current subtitles.  Continue?", "Clear all subtitles?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false;
            }
            return true;
        }

        public void ClearCurrentFile()
        {
            lvSubtitles.Items.Clear();
            m_bDirty = false;
            SetFileName("");
        }

        private int GetNextNumber(string sNumbers, ref int iIndex)
        {
            int iStart = iIndex;

            while (true)
            {
                iIndex++;
                if (iIndex >= sNumbers.Length)
                    break;
                if (!Char.IsDigit(sNumbers, iIndex))
                    break;
            }

            return SafeConvertInt32(sNumbers.Substring(iStart, iIndex - iStart));
        }

        private Subtitle ReadSubtitle(StreamReader reader)
        {
            Subtitle sub = new Subtitle();
            string sLine = "";
            bool bContinue = true;

            // Read the index number
            int iBegin = 0;
            while (bContinue)
            {
                sLine = reader.ReadLine();
                if (reader.Peek() == -1)
                    return sub;
                if (sLine.Length < 1)
                    continue;
                while (sLine[iBegin] == (char)0xFEFF || sLine[iBegin] == (char)0xFFFE)
                    iBegin++;

                if (Char.IsDigit(sLine, iBegin))
                    break;
            }

            sub.Index = SafeConvertInt32(sLine.Substring(iBegin), 10);

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

            int[] iNumbers = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int iIndex = 0;

            for (int i = 0; i < 8; i++)
            {
                iNumbers[i] = GetNextNumber(sLine, ref iIndex);
                if (i == 7)
                    break;
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

            try
            {
                sub.StartTime = new DateTime(1, 1, 1, iNumbers[0], iNumbers[1], iNumbers[2], iNumbers[3]);
                sub.StopTime = new DateTime(1, 1, 1, iNumbers[4], iNumbers[5], iNumbers[6], iNumbers[7]);
            }
            catch (Exception)
            {
                statusBar1.Text = String.Format("Date/Time error on sub {0}", sub.Index);
            }

            // Read any variables that are listed after the subtitle times
            int iVarStart = -1;
            int iVarEnd = -1;
            int iValueStart = -1;
            int iValueEnd = -1;
            string sVariable = "";
            string sValue = "";
            while (iIndex <= sLine.Length)
            {
                if ((iIndex < sLine.Length) && (!Char.IsWhiteSpace(sLine, iIndex)))
                {
                    if (sLine[iIndex] == ':')
                    {
                        iVarEnd = iIndex;
                        iValueStart = iIndex + 1;
                    }
                    else if (iVarStart < 0)
                        iVarStart = iIndex;
                    else if (iValueStart < 0)
                        iVarEnd = iIndex;
                    else
                        iValueEnd = iIndex;
                }
                else
                {
                    // Whitespace terminates any active variable
                    iValueEnd = iIndex;
                    if ((iValueStart >= 0) && (iVarStart >= 0))
                    {
                        sVariable = sLine.Substring(iVarStart, iVarEnd - iVarStart);
                        sValue = sLine.Substring(iValueStart, iValueEnd - iValueStart);

                        // Check for variables we understand
                        if (string.Compare(sVariable, "X1", true) == 0)
                            sub.rcBound.X = SafeConvertInt32(sValue);
                        else if (string.Compare(sVariable, "X2", true) == 0)
                            sub.rcBound.Width = SafeConvertInt32(sValue) - sub.rcBound.X;
                        else if (string.Compare(sVariable, "Y1", true) == 0)
                            sub.rcBound.Y = SafeConvertInt32(sValue);
                        else if (string.Compare(sVariable, "Y2", true) == 0)
                            sub.rcBound.Height = SafeConvertInt32(sValue) - sub.rcBound.Y;
                    }
                    iVarStart = -1;
                    iVarEnd = -1;
                    iValueStart = -1;
                    iValueEnd = -1;
                    sVariable = "";
                    sValue = "";
                }
                iIndex++;
            }

            // Read the subtitles
            sub.Text = "";
            do
            {
                if (reader.Peek() == -1)
                    break;

                sLine = reader.ReadLine();
                if ((sub.Text.Length > 0) && (sLine != ""))
                    sub.Text += "\r\n";

                sub.Text += sLine;
                sub.Valid = true;
            } while (sLine != "" || !IsSubStart(reader.Peek()));

            return sub;
        }

        private bool IsSubStart(int iChar)
        {
            if (iChar == 255 || iChar == 254 || iChar == -1 || iChar == -2 || iChar == 0xFEFF || iChar == 0xFFFE || Char.IsDigit((char)iChar))
                return true;
            return false;
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
            UpdateLVItem(lvItem, (Subtitle)lvItem.Tag);
        }

        private void UpdateProgress(long iCurrent, long iMaximum)
        {
            statusBar1.Text = "Processing: " + (iCurrent * 100 / (double)iMaximum).ToString("0.0") + "%";
        }

        public bool ReadSubtitleFile(string sFileName)
        {
            SetReadyStatus();
            bool bSequence = true;
            int iFirstMisaligned = -1;
            int iMisalignedCorrected = -1;
            lvSubtitles.BeginUpdate();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(sFileName, Encoding.Default);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open file: " + sFileName + "\r\nException: " + ex.Message, "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Subtitle sub;
            int iPrevIndex = 0;

            while (reader.Peek() != -1)
            {
                sub = ReadSubtitle(reader);
                if (sub.Valid)
                    InsertSubtitleIntoList(sub);
                if (sub.Index != iPrevIndex + 1)
                {
                    bSequence = false;
                    if (iFirstMisaligned == -1)
                    {
                        iFirstMisaligned = sub.Index;
                        iMisalignedCorrected = iPrevIndex + 1;
                    }
                }
                UpdateProgress(reader.BaseStream.Position, reader.BaseStream.Length);
                iPrevIndex++;
            }
            reader.Close();
            foreach (ColumnHeader ch in lvSubtitles.Columns)
            {
                ch.Width = -2;
            }

            lvSubtitles.EndUpdate();
            m_bDirty = false;
            SetFileName(sFileName);
            AddFileToMRU(sFileName);
            if (bSequence)
                SetReadyStatus();
            else
                statusBar1.Text = "Warning: Indices non-consecutive (" + iFirstMisaligned.ToString() + " should be " + iMisalignedCorrected.ToString() + ").  Use the Action->Renumber command to resequence.";

            return true;
        }

        public void SetReadyStatus()
        {
            statusBar1.Text = "Ready.";
        }

        private void SubFutzerForm_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            GenericDragDrop(sender, e);
        }

        private void GenericDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] saFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (saFiles.Length > 0)
            {
                if (File.Exists(saFiles[0]))
                {
                    if (CanClearCurrentFile())
                    {
                        SaveUndoData();
                        ClearCurrentFile();
                        ReadSubtitleFile(saFiles[0]);
                    }
                }
            }
        }

        private void lvSubtitles_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            GenericDragDrop(sender, e);
        }

        private void SubFutzerForm_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Generic_DragEnter(sender, e);
        }

        private void Generic_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void lvSubtitles_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Generic_DragEnter(sender, e);
        }

        private void SaveFileAs(bool bSelectedOnly)
        {
            saveFileDialog1.DefaultExt = "srt";
            saveFileDialog1.Title = "Save the current subtitle file as";
            saveFileDialog1.Filter = "SubRip files (*.srt)|*.srt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile(saveFileDialog1.FileName, bSelectedOnly);
            }
        }

        private void WriteSubtitle(StreamWriter writer, ListViewItem lvItem)
        {
            WriteSubtitle(writer, (Subtitle)lvItem.Tag);
        }

        private void WriteSubtitle(StreamWriter writer, Subtitle sub)
        {
            writer.WriteLine(sub.Index);
            string sExtended = "";
            if (!sub.rcBound.IsEmpty)
            {
                sExtended = string.Format("  X1:{0:000} X2:{1:000} Y1:{2:000} Y2:{3:000}",
                    sub.rcBound.Left,
                    sub.rcBound.Right,
                    sub.rcBound.Top,
                    sub.rcBound.Bottom);
            }
            writer.WriteLine("{0:00}:{1:00}:{2:00},{3:000} --> {4:00}:{5:00}:{6:00},{7:000}{8}",
                sub.StartTime.Hour,
                sub.StartTime.Minute,
                sub.StartTime.Second,
                sub.StartTime.Millisecond,
                sub.StopTime.Hour,
                sub.StopTime.Minute,
                sub.StopTime.Second,
                sub.StopTime.Millisecond,
                sExtended);

            writer.WriteLine(sub.Text + "\r\n");
        }

        public bool SaveFileAs(string strFile, bool bSelectedOnly)
        {
            int iIndex = 0;
            try
            {
                StreamWriter writer = new StreamWriter(strFile, false, Encoding.Default);
                while (iIndex < lvSubtitles.Items.Count)
                {
                    UpdateProgress(iIndex, lvSubtitles.Items.Count);
                    if (!bSelectedOnly || lvSubtitles.Items[iIndex].Selected)
                        WriteSubtitle(writer, lvSubtitles.Items[iIndex]);
                    iIndex++;
                }
                writer.Close();
                m_bDirty = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Could not write to file \"" + strFile + "\" (Error: " + e.Message + ")");
                return false;
            }
            return true;
        }

        public void SaveFile(bool bSelectedOnly)
        {
            SaveFileAs(m_sFileName, bSelectedOnly);
            SetReadyStatus();
        }

        public void SaveFile(string sFileName, bool bSelectedOnly)
        {
            if (!bSelectedOnly)
            {
                SetFileName(sFileName);
                SaveFile(bSelectedOnly);
            }
            else
            {
                SaveFileAs(sFileName, bSelectedOnly);
                SetReadyStatus();
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

        private void lvSubtitles_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lvSubtitles.SelectedItems.Count == 1)
            {
                tbSubtitle.Enabled = true;
                Subtitle sub = (Subtitle)lvSubtitles.SelectedItems[0].Tag;
                tbSubtitle.Text = sub.Text;
                ttbStart.SetTime(sub.StartTime);
                ttbStop.SetTime(sub.StopTime);
                LockTimes();
            }
            else
                tbSubtitle.Enabled = false;
        }

        private void OffsetSubtitle(ListViewItem lvItem, TimeSpan tsFirst, double fRatio)
        {
            Subtitle sub = (Subtitle)lvItem.Tag;
            TimeSpan tsDuration = sub.StopTime - sub.StartTime;
            TimeSpan tsStart = TimeToolbox.DateTimeToTimeSpan(sub.StartTime);
            TimeSpan tsOffset = tsStart - tsFirst;
            sub.StartTime = TimeToolbox.TimeSpanToDateTime(new TimeSpan(0, 0, 0, 0, (int)((tsOffset.TotalMilliseconds * fRatio) + tsFirst.TotalMilliseconds)));
            sub.StopTime = sub.StartTime.Add(tsDuration);
            UpdateLVItem(lvItem);
        }

        private void OffsetSubtitle(ListViewItem lvItem, TimeSpan ts)
        {
            Subtitle sub = (Subtitle)lvItem.Tag;
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

        private bool ProcessAllItems
        {
            get
            {
                if (cbWhichItems.SelectedIndex == 0)
                    return true;
                return false;
            }
        }

        public void OffsetSubtitles(TimeSpan ts)
        {
            if (ProcessAllItems)
            {
                foreach (ListViewItem lvItem in lvSubtitles.Items)
                {
                    OffsetSubtitle(lvItem, ts);
                }
            }
            else
            {
                foreach (ListViewItem lvItem in lvSubtitles.SelectedItems)
                {
                    OffsetSubtitle(lvItem, ts);
                }
            }
        }

        public void SetFirstItem(TimeSpan ts)
        {
            Subtitle sub;
            if (ProcessAllItems)
            {
                if (lvSubtitles.Items.Count < 1)
                    return;
                sub = (Subtitle)lvSubtitles.Items[0].Tag;
            }
            else
            {
                if (lvSubtitles.SelectedItems.Count < 1)
                    return;
                sub = (Subtitle)lvSubtitles.SelectedItems[0].Tag;
            }
            TimeSpan tsSet = ts - TimeToolbox.DateTimeToTimeSpan(sub.StartTime);
            OffsetSubtitles(tsSet);
        }

        private bool VerifyDuration(ListViewItem lviFirst, ListViewItem lviNext)
        {
            Subtitle subFirst = (Subtitle)lviFirst.Tag;
            Subtitle subNext = (Subtitle)lviNext.Tag;

            if (subFirst.StopTime <= subNext.StartTime)
                return true;

            subFirst.StopTime = subNext.StartTime;
            UpdateLVItem(lviFirst, subFirst);

            return false;
        }

        public void ExpandLastItem(TimeSpan ts)
        {
            ExpandLastItem(ts, false);
        }

        public void ExpandLastItem(TimeSpan ts, bool bRelative)
        {
            if (lvSubtitles.Items.Count < 2)
                return;

            int iIndexFirst, iIndexLast;
            if (ProcessAllItems || (lvSubtitles.SelectedItems.Count < 1))
            {
                iIndexFirst = 0;
                iIndexLast = lvSubtitles.Items.Count - 1;
            }
            else
            {
                if (lvSubtitles.SelectedItems.Count < 2)
                    return;
                iIndexFirst = lvSubtitles.SelectedIndices[0];
                iIndexLast = lvSubtitles.SelectedIndices[lvSubtitles.SelectedIndices.Count - 1];
            }
            Subtitle subFirst = (Subtitle)lvSubtitles.Items[iIndexFirst].Tag;
            Subtitle subLast = (Subtitle)lvSubtitles.Items[iIndexLast].Tag;
            TimeSpan tsOld = subLast.StartTime - subFirst.StartTime;
            TimeSpan tsNew;

            if (bRelative)
            {
                tsNew = (TimeToolbox.DateTimeToTimeSpan(subLast.StartTime) + ts) - TimeToolbox.DateTimeToTimeSpan(subFirst.StartTime);
            }
            else
            {
                tsNew = ts - TimeToolbox.DateTimeToTimeSpan(subFirst.StartTime);
            }

            double fRatio = tsNew.TotalMilliseconds / tsOld.TotalMilliseconds;

            int iCurrent = iIndexFirst;
            while (iCurrent <= iIndexLast)
            {
                OffsetSubtitle(lvSubtitles.Items[iCurrent], TimeToolbox.DateTimeToTimeSpan(subFirst.StartTime), fRatio);
                if (iCurrent > iIndexFirst)
                    VerifyDuration(lvSubtitles.Items[iCurrent - 1], lvSubtitles.Items[iCurrent]);
                iCurrent++;
            }
        }

        public void ExpandSubtitles(TimeSpan tsExpand)
        {
            ExpandLastItem(tsExpand, true);
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            UpdateSubtitle();
        }

        private void UpdateSubtitle()
        {
            SaveUndoData();
            if (lvSubtitles.SelectedItems.Count < 1)
                return;

            ListViewItem lvItem = lvSubtitles.SelectedItems[0];
            Subtitle sub = (Subtitle)lvItem.Tag;
            DateTime dtStart = TimeToolbox.TimeSpanToDateTime(ttbStart.GetTime());
            DateTime dtStop = TimeToolbox.TimeSpanToDateTime(ttbStop.GetTime());
            if (sub.Text == tbSubtitle.Text && sub.StartTime == dtStart && sub.StopTime == dtStop)
                return;

            sub.Text = tbSubtitle.Text;
            sub.StartTime = dtStart;
            sub.StopTime = dtStop;
            UpdateLVItem(lvItem);

            m_bDirty = true;
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

        public void ProcessJobs()
        {
            openFileDialog2.DefaultExt = "jobs";
            openFileDialog2.Multiselect = false;
            openFileDialog2.Title = "Select VirtualDub-format job file for processing";
            openFileDialog2.Filter = "VirtualDub job files (*.jobs)|*.jobs|All files (*.*)|*.*";
            if (openFileDialog2.ShowDialog(this) == DialogResult.OK)
                ProcessJobs(openFileDialog2.FileName);
        }

        private string GetRegexMatch(string sRegex, string sSearch)
        {
            Regex regex = new Regex(sRegex);
            CaptureCollection cc;

            Match match = regex.Match(sSearch);
            if (match.Groups.Count > 0)
            {
                cc = match.Groups[0].Captures;
                if (cc.Count > 0)
                {
                    return match.Result("${1}");
                }
            }
            return "";
        }

        enum PJState
        {
            FindAVISource,
            FindRange,
            FindAVIDest,
            Finish
        }

        public void ProcessJobs(string sFileName)
        {
            StreamReader reader;
            string sLine;
            string sAVISource = "";
            string sRange = "";
            string sAVIDest = "";
            int iFind;
            long lStart = 0;
            long lEnd = 0;
            PJState state = PJState.FindAVISource;

            try
            {
                reader = new StreamReader(sFileName, Encoding.Default);
            }
            catch
            {
                MessageBox.Show(this, "Could not open file \"" + sFileName + "\" for reading.");
                return;
            }

            while (reader.Peek() != -1)
            {
                sLine = reader.ReadLine();

                switch (state)
                {
                    case PJState.FindAVISource:
                        sAVISource = GetRegexMatch("VirtualDub.Open\\(\"(?<1>.*)\"", sLine);
                        if (sAVISource != "")
                        {
                            state++;
                            sAVISource = sAVISource.Replace("\\\\", "\\");
                        }
                        break;
                    case PJState.FindRange:
                        sRange = GetRegexMatch("VirtualDub.video.SetRange\\((?<1>.*)\\)", sLine);
                        if (sRange != "")
                        {
                            state++;
                            iFind = sRange.IndexOf(',');
                            lStart = Convert.ToInt64(sRange.Substring(0, iFind));
                            lEnd = Convert.ToInt64(sRange.Substring(iFind + 1));
                        }
                        break;
                    case PJState.FindAVIDest:
                        sAVIDest = GetRegexMatch("VirtualDub.SaveAVI\\(\"(?<1>.*)\"", sLine);
                        if (sAVIDest != "")
                        {
                            state++;
                            sAVIDest = sAVIDest.Replace("\\\\", "\\");
                            if (m_options.bStripLanguage)
                                sAVIDest = RemoveLanguageString(sAVIDest);
                        }
                        break;
                    case PJState.Finish:
                        FitSubtitlesToJob(sAVISource, lStart, lEnd, sAVIDest);
                        state = PJState.FindAVISource;
                        break;
                    default:
                        break;
                }

            }
            reader.Close();
        }

        private string RemoveLanguageString(string sAVI)
        {
            string sTemp = sAVI.ToLower();
            int iIndex = -1;

            string[] saLanguages = { "english", "japanese", "chinese", "spanish", "french" };

            // Assume there is at most only a single language string
            foreach (string sLanguage in saLanguages)
            {
                iIndex = sTemp.IndexOf("-" + sLanguage + ".avi");
                if (iIndex > -1)
                    return sAVI.Substring(0, iIndex) + ".avi";
            }

            return sAVI;
        }

        private void WriteSubtitleSection(long lStartMS, long lStopMS, string sFileName)
        {
            int iCurrent = 0;
            int iSubIndex = 1;
            Subtitle sub, newSub;
            long lSubMS;
            StreamWriter writer;

            try
            {
                writer = new StreamWriter(sFileName, false, Encoding.Default);
            }
            catch
            {
                MessageBox.Show(this, "Unable to open file \"" + sFileName + "\" for writing.");
                return;
            }

            while (iCurrent < lvSubtitles.Items.Count)
            {
                sub = (Subtitle)lvSubtitles.Items[iCurrent].Tag;
                lSubMS = TimeToolbox.DateTimeToMilliseconds(sub.StartTime);
                if ((lSubMS > lStartMS) && (lSubMS < lStopMS))
                {
                    newSub = sub.SubtractMS(lStartMS);
                    newSub.Index = iSubIndex;
                    WriteSubtitle(writer, newSub);
                    iSubIndex++;
                }

                iCurrent++;

                if (lSubMS > lStopMS)
                    break;  // No sense processing any further if we're past the end of the segment
            }

            writer.Close();
        }

        private long DWordAt(byte[] buffer, int iOffset)
        {
            return Convert.ToInt64(buffer[iOffset] | (buffer[iOffset + 1] << 8) | (buffer[iOffset + 2] << 16) | (buffer[iOffset + 3] << 24));
        }

        private void FitSubtitlesToJob(string sAVISource, long lStartMS, long lEndMS, string sAVIDest)
        {
            SetReadyStatus();

            // VirtualDub gives us the ending in ms from the END of the file...
            FileStream fs;
            try
            {
                fs = File.OpenRead(sAVISource);

                BinaryReader reader = new BinaryReader(fs);
                byte[] buffer = new byte[512];
                reader.Read(buffer, 0, 512);
                double fSecPerFrame = DWordAt(buffer, 0x80) / (double)DWordAt(buffer, 0x84);
                long lTotalFrames = DWordAt(buffer, 0x8c);
                reader.Close();

                if (fSecPerFrame < 0.0001)
                {
                    // Invalid frame rate
                    lEndMS = 99999999;
                }
                else
                {
                    lEndMS = (long)((lTotalFrames * fSecPerFrame) * 1000) - lEndMS;
                }
            }
            catch (Exception e)
            {
                lEndMS = 99999999;
                SetStatus("Warning:  Could not determine length of file " + sAVISource + " [" + e.Message + "]");
            }

            string sFileName = Path.GetDirectoryName(sAVIDest)
                + "\\"
                + m_options.sSubOutFormat.Replace("%N", Path.GetFileNameWithoutExtension(sAVIDest));
            WriteSubtitleSection(lStartMS, lEndMS, sFileName);

            /* useless
                        FilgraphManager graphManager =
                            new FilgraphManager();

                        // QueryInterface for the IMediaControl interface:
                        IMediaControl mc = 
                            (IMediaControl)graphManager;

                        IMediaSeeking ms =
                            (IMediaSeeking)graphManager;

                        // Call some methods on a COM interface.
                        // Pass in file to RenderFile method on COM object.
                        mc.RenderFile(sAVISource);
        
                        long lDuration, lPosition;
                        double dRate;
            //            ms.IsUsingTimeFormat(TimeFormat.MediaTime);
                        ms.GetDuration(out lDuration);
                        ms.GetCurrentPosition(out lPosition);
                        ms.GetRate(out dRate);
            */
        }

        private void WarnNoSubtitles()
        {
            MessageBox.Show(this, "There are no subtitles loaded.\n\nBefore processing a .jobs file, load in a set of subtitles with the File->Open command.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void MergeLines(ListViewItem lvItem)
        {
            Subtitle sub = (Subtitle)lvItem.Tag;
            int iLine = 0;
            int iFind;
            char[] caNewLine = new char[2] { '\r', '\n' };
            string sBefore, sAfter;
            while (iLine != -1)
            {
                iLine = sub.Text.IndexOfAny(caNewLine);
                if (iLine > 0)
                    sBefore = sub.Text.Substring(0, iLine);
                else
                    sBefore = "";

                sAfter = "";
                iFind = iLine + 1;
                while (iFind < sub.Text.Length)
                {
                    if (Char.IsWhiteSpace(sub.Text[iFind]))
                    {
                        iFind++;
                    }
                    else
                    {
                        sAfter = sub.Text.Substring(iFind);
                        break;
                    }
                }

                if ((sBefore != "") && (sAfter != ""))
                {
                    switch (sub.Text[iLine - 1])
                    {
                        case '!':
                        case '?':
                        case '.':
                            sub.Text = sBefore + "  " + sAfter;
                            break;
                        default:
                            sub.Text = sBefore + " " + sAfter;
                            break;
                    }
                }
                else
                {
                    sub.Text = sBefore + sAfter;
                }

            }

            if (checkNLBeforeBracket.Checked)
            {
                sub.Text = sub.Text.Replace(" [", "[").Replace("[", "\r\n[");
            }

            UpdateLVItem(lvItem, sub);
        }

        private void btnMergeAll_Click(object sender, System.EventArgs e)
        {
            SaveUndoData();
            if (ProcessAllItems)
            {
                foreach (ListViewItem lvItem in lvSubtitles.Items)
                    MergeLines(lvItem);
            }
            else
            {
                foreach (ListViewItem lvItem in lvSubtitles.SelectedItems)
                    MergeLines(lvItem);
            }
            m_bDirty = true;
        }

        private bool IsCRLF(char c)
        {
            if (c == '\r' || c == '\n')
                return true;
            return false;
        }

        private bool IsOneOf(char cTest, char[] arrayChars)
        {
            foreach (char c in arrayChars)
                if (cTest == c)
                    return true;
            return false;
        }

        private void SetMaxLineLength(ListViewItem lvItem, int iMaxLen)
        {
            Subtitle sub = (Subtitle)lvItem.Tag;
            if (sub.Text.Length <= iMaxLen)
                return;

            int iFind = 0;
            int iCurLen = 0;
            int iSpace = 0;
            bool bCRBeforeBracket = false;
            if (checkNLBeforeBracket.Checked)
                bCRBeforeBracket = true;

            while (iFind < sub.Text.Length)
            {
                if (IsCRLF(sub.Text[iFind]))
                {
                    iCurLen = 0;
                    while ((iFind < sub.Text.Length) && (IsCRLF(sub.Text[iFind])))
                        iFind++;
                }

                if (iFind >= sub.Text.Length)
                    break;

                if (sub.Text[iFind] == ' ')
                    iSpace = iFind;

                if (bCRBeforeBracket)
                {
                    if (sub.Text[iFind] == '[')
                    {
                        if (iFind > 0)
                        {
                            if (!IsCRLF(sub.Text[iFind - 1]))
                            {
                                sub.Text = sub.Text.Substring(0, iFind) + "\r\n" + sub.Text.Substring(iFind);
                                iFind += 2;
                            }
                        }
                    }
                }

                if (iCurLen > iMaxLen)
                {
                    if ((iSpace > 0) && (iSpace < sub.Text.Length - 1))
                    {
                        sub.Text = sub.Text.Substring(0, iSpace) + "\r\n" + sub.Text.Substring(iSpace + 1);
                        iFind = iSpace + 2;
                        iCurLen = 0;
                        iSpace = 0;
                    }
                    // If there's no spaces, don't split anything.
                }
                iFind++;
                iCurLen++;
            }
            UpdateLVItem(lvItem, sub);
        }

        private void btnSetMaxLength_Click(object sender, System.EventArgs e)
        {
            SaveUndoData();
            int iLength = 60;

            try { iLength = SafeConvertInt32(tbMaxLength.Text); }
            catch { iLength = 60; }

            if (ProcessAllItems)
            {
                foreach (ListViewItem lvItem in lvSubtitles.Items)
                    SetMaxLineLength(lvItem, iLength);
            }
            else
            {
                foreach (ListViewItem lvItem in lvSubtitles.SelectedItems)
                    SetMaxLineLength(lvItem, iLength);
            }
            m_bDirty = true;
        }

        private void RenumberAllSubtitles()
        {
            int iCurrent = 0;
            while (iCurrent < lvSubtitles.Items.Count)
            {
                ((Subtitle)lvSubtitles.Items[iCurrent].Tag).Index = iCurrent + 1;
                UpdateLVItem(lvSubtitles.Items[iCurrent]);
                iCurrent++;
            }
            SetReadyStatus();
            m_bDirty = true;
        }

        private void DeleteSelectedItems()
        {
            lvSubtitles.BeginUpdate();
            foreach (ListViewItem lvItem in lvSubtitles.SelectedItems)
                lvItem.Remove();
            RenumberAllSubtitles();  // also sets m_bDirty
            lvSubtitles.EndUpdate();
        }

        private void LoadUndoData()
        {
            lvSubtitles.BeginUpdate();

            lvSubtitles.Items.Clear();
            foreach (Subtitle sub in m_undoData)
                InsertSubtitleIntoList(sub);

            lvSubtitles.EndUpdate();
        }

        private void SaveUndoData()
        {
            m_undoData.Clear();
            m_undoData.Capacity = lvSubtitles.Items.Count;
            foreach (ListViewItem lvItem in lvSubtitles.Items)
            {
                m_undoData.Add(new Subtitle((Subtitle)lvItem.Tag));
            }
        }

        private void SaveRedoData()
        {
            m_redoData.Clear();
            m_redoData.Capacity = lvSubtitles.Items.Count;
            foreach (ListViewItem lvItem in lvSubtitles.Items)
            {
                m_redoData.Add(new Subtitle((Subtitle)lvItem.Tag));
            }
        }

        private void CopyRedoToUndo()
        {
            m_undoData.Clear();
            foreach (Subtitle sub in m_redoData)
                m_undoData.Add(new Subtitle(sub));
        }

        private List<Subtitle> CloneSubtitlesToList()
        {
            List<Subtitle> listNew = new List<Subtitle>(lvSubtitles.Items.Count);
            foreach (ListViewItem lvi in lvSubtitles.Items)
                listNew.Add(new Subtitle(lvi.Tag as Subtitle));
            return listNew;
        }

        private void CloneListToSubtitles(List<Subtitle> list, bool bBeginUpdate = false)
        {
            if (bBeginUpdate)
                lvSubtitles.BeginUpdate();

            lvSubtitles.Items.Clear();
            foreach (Subtitle sub in list)
                InsertSubtitleIntoList(sub);

            if (bBeginUpdate)
                lvSubtitles.EndUpdate();
        }

        private int MergeSubtitleIntoList(Subtitle sub)
        {
            int iFind = 0;
            Subtitle curSub;
            while (iFind < lvSubtitles.Items.Count)
            {
                curSub = (Subtitle)lvSubtitles.Items[iFind].Tag;
                if (curSub.StartTime >= sub.StopTime)
                {
                    // No overlap; just insert it into the list before this item
                    ListViewItem lvItem = new ListViewItem();
                    UpdateLVItem(lvItem, sub);
                    lvSubtitles.Items.Insert(iFind, lvItem);
                    return iFind;
                }
                if (curSub.StopTime > sub.StartTime)
                {
                    // This subtitle overlaps the previous one, so combine them and
                    // set the duration to the full overlap period.
                    curSub.Text = curSub.Text + "\r\n[ " + sub.Text + " ]";
                    if (curSub.StartTime > sub.StartTime)
                        curSub.StartTime = sub.StartTime;
                    if (sub.StopTime > curSub.StopTime)
                        curSub.StopTime = sub.StopTime;
                    UpdateLVItem(lvSubtitles.Items[iFind], curSub);
                    return iFind;
                }
                // Otherwise we haven't found the right spot yet
                iFind++;
            }
            // If we get here, the subtitle belongs at the end of the list
            return InsertSubtitleIntoList(sub);
        }

        public void MergeSubtitleFile(string sFileName)
        {
            SetReadyStatus();
            lvSubtitles.BeginUpdate();
            StreamReader reader = new StreamReader(sFileName, Encoding.Default);
            Subtitle sub;

            while (reader.Peek() != -1)
            {
                sub = ReadSubtitle(reader);
                if (sub.Valid)
                    MergeSubtitleIntoList(sub);
                UpdateProgress(reader.BaseStream.Position, reader.BaseStream.Length);
            }
            reader.Close();
            foreach (ColumnHeader ch in lvSubtitles.Columns)
            {
                ch.Width = -2;
            }

            lvSubtitles.EndUpdate();
            RenumberAllSubtitles();
            m_bDirty = false;
            AddFileToMRU(sFileName);
            SetReadyStatus();
        }

        private void tbMaxLength_TextChanged(object sender, System.EventArgs e)
        {
            try { m_options.iLineLength = SafeConvertInt32(tbMaxLength.Text); }
            catch { m_options.iLineLength = 50; }

        }

        public void SetStatus(string sStatus)
        {
            statusBar1.Text = sStatus;
        }

        private void SetMenuSelectEvents(ToolStripItemCollection items)
        {
            foreach (ToolStripItem tsi in items)
            {
                if (tsi is ToolStripMenuItem)
                {
                    ToolStripMenuItem tsmi = tsi as ToolStripMenuItem;
                    if (tsmi.HasDropDownItems)
                        SetMenuSelectEvents(tsmi.DropDownItems);
                    tsmi.DropDownOpening += MenuItem_SetStatusHelp;
                    tsmi.MouseEnter += MenuItem_SetStatusHelp;
                }
                else if (tsi is ToolStripDropDownItem)
                {
                    ToolStripDropDownItem tsddi = tsi as ToolStripDropDownItem;
                    if (tsddi.HasDropDownItems)
                        SetMenuSelectEvents(tsddi.DropDownItems);
                    tsddi.DropDownOpening += MenuItem_SetStatusHelp;
                    tsddi.MouseEnter += MenuItem_SetStatusHelp;
                }
            }
        }

        private void MenuItem_SetStatusHelp(object sender, EventArgs e)
        {
            SetMenuStatusHelp(sender, e);
        }

        private void SetMenuStatusHelp(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null || !m_dictMenuHelp.ContainsKey(item))
                SetReadyStatus();
            else
                SetStatus(m_dictMenuHelp[item]);
        }

        private void DoFindDialog()
        {
            if (dlgFindText.IsDisposed)
            {
                dlgFindText = new SFFindText();
                dlgFindText.SetMainForm(this);
                dlgFindText.CreateControl();
            }
            if ((dlgFindText.DesktopLocation.Y == 0) && (dlgFindText.DesktopLocation.X == 0))
            {
                Point pt = DesktopLocation;
                pt.Offset((Width / 2) - (dlgFindText.Width / 2), (Height / 2) - (dlgFindText.Height / 2));
                dlgFindText.DesktopLocation = pt;
            }
            if (lvSubtitles.SelectedItems.Count < 1)
                dlgFindText.iSearchIndex = 0;
            else
                dlgFindText.iSearchIndex = lvSubtitles.SelectedItems[0].Index;

            dlgFindText.Visible = true;
            dlgFindText.Activate();
        }

        private void mi_MRUFile_Click(object sender, System.EventArgs e)
        {
            SetReadyStatus();

            string sFile = ((ToolStripMenuItem)sender).Tag as string;
            if (File.Exists(sFile))
            {
                if (!CanClearCurrentFile())
                    return;

                SaveUndoData();
                ClearCurrentFile();
                ReadSubtitleFile(sFile);
            }
            else
            {
                SetStatus("Warning: File does not exist - " + sFile);
            }
        }

        private void CreateMRUList()
        {
            if (m_options.m_listMRU.Count > 0)
            {
                miFileRecent.DropDownItems.Clear();

                int iIndex = 1;
                foreach(string strFile in m_options.m_listMRU)
                {
                    string strItem = String.Format("&{0} {1}", iIndex++, strFile);
                    ToolStripMenuItem item = new ToolStripMenuItem(strItem);
                    item.Click += new EventHandler(mi_MRUFile_Click);
                    item.Tag = strFile;
                    miFileRecent.DropDownItems.Add(item);
                }
            }
        }

        private void AddFileToMRU(string sFile)
        {
            if (m_options.m_listMRU.Contains(sFile))
                return;

            if (m_options.m_listMRU.Count == 0)
            {
                m_options.m_listMRU.Add(sFile);
                CreateMRUList();
                return;
            }

            if ((m_options.m_listMRU.Count < 9) && (m_options.m_listMRU.Count > 0))
                m_options.m_listMRU.Add(m_options.m_listMRU[m_options.m_listMRU.Count - 1]);

            for (int iIndex = m_options.m_listMRU.Count - 1; iIndex > 0; iIndex--)
            {
                if (iIndex > 8)
                    continue;

                m_options.m_listMRU[iIndex] = m_options.m_listMRU[iIndex - 1];
            }
            m_options.m_listMRU[0] = sFile;
            CreateMRUList();
        }

        private bool MergeDuplicates(int iStartIndex, bool bRenumberWhenFinished)
        {
            if (iStartIndex > lvSubtitles.Items.Count - 2)
                return false;

            bool bRenumber = false;

            do
            {
                Subtitle sub1 = (Subtitle)lvSubtitles.Items[iStartIndex].Tag;
                Subtitle sub2 = (Subtitle)lvSubtitles.Items[iStartIndex + 1].Tag;

                // Never merge if subtitles are too far apart
                if (sub1.StopTime + new TimeSpan(0, 0, 0, 0, 100) < sub2.StartTime)
                    break;

                if (sub1.Text != sub2.Text)
                    break;

                sub1.StopTime = sub2.StopTime;
                lvSubtitles.Items[iStartIndex + 1].Remove();
                bRenumber = true;
            }
            while (iStartIndex < lvSubtitles.Items.Count - 1);

            if (bRenumber && bRenumberWhenFinished)
                RenumberAllSubtitles();  // also sets m_bDirty

            return bRenumber;
        }

        private void MoveNext()
        {
            UpdateSubtitle();
            Control ctrlFocus = Global.GetActiveControl(this);

            if (lvSubtitles.SelectedItems.Count < 1)
            {
                if (lvSubtitles.Items.Count > 0)
                {
                    lvSubtitles.Items[0].Selected = true;
                }
            }

            ListViewItem lviSel = lvSubtitles.SelectedItems[lvSubtitles.SelectedItems.Count - 1];
            int iNext = lviSel.Index + 1;
            if (iNext < lvSubtitles.Items.Count)
            {
                lvSubtitles.SelectedItems.Clear();
                lvSubtitles.Items[iNext].Selected = true;
                lvSubtitles.Items[iNext].Focused = true;

                lvSubtitles.EnsureVisible(iNext);
            }

            ctrlFocus.Focus();
        }

        private void MovePrevious()
        {
            UpdateSubtitle();
            Control ctrlFocus = Global.GetActiveControl(this);

            if (lvSubtitles.SelectedItems.Count < 1)
            {
                if (lvSubtitles.Items.Count > 0)
                {
                    lvSubtitles.Items[0].Selected = true;
                }
            }

            ListViewItem lviSel = lvSubtitles.SelectedItems[0];
            int iPrev = lviSel.Index - 1;
            if (iPrev >= 0)
            {
                lvSubtitles.SelectedItems.Clear();
                lvSubtitles.Items[iPrev].Selected = true;
                lvSubtitles.Items[iPrev].Focused = true;

                lvSubtitles.EnsureVisible(iPrev);
            }

            ctrlFocus.Focus();
        }

        private void MergeSelectedItemsToSingle()
        {
            if (lvSubtitles.SelectedItems.Count < 2)
                return;

            // Set the start time of all selected items to the start time of the first item,
            // and the end time of the first item to the end time of the last item.
            Subtitle subFirst = (Subtitle)lvSubtitles.SelectedItems[0].Tag;
            Subtitle subLast = (Subtitle)lvSubtitles.SelectedItems[lvSubtitles.SelectedItems.Count - 1].Tag;

            subFirst.StopTime = subLast.StopTime;
            UpdateLVItem(lvSubtitles.SelectedItems[0], subFirst);

            while (lvSubtitles.SelectedItems.Count > 1)
            {
                Subtitle sub = (Subtitle)lvSubtitles.SelectedItems[1].Tag;
                if (sub.Text != subFirst.Text)
                    MergeSubtitleIntoList(sub);
                lvSubtitles.SelectedItems[1].Remove();
            }

            RenumberAllSubtitles();
        }

        private int SafeConvertInt32(string sValue)
        {
            int iOut = 0;
            Int32.TryParse(sValue, out iOut);
            return iOut;
        }

        private void RealignSubs(int iOffset)
        {
            LVICollection items = new LVICollection(lvSubtitles.Items);
            if (!ProcessAllItems)
            {
                items = new LVICollection(lvSubtitles.SelectedItems);
            }

            int iMax = Math.Abs(iOffset);
            int iStart = 0;
            int iEnd = items.Count - iMax;
            int iSign = Math.Sign(iOffset);

            if (iMax == iOffset) // i.e. if it's positive
            {
                iStart = items.Count - 1;
                iEnd = iMax - 1;
            }

            for (int i = iStart; i != iEnd; i -= iSign)
            {
                Subtitle sub1 = (Subtitle)items[i].Tag;
                Subtitle sub2 = (Subtitle)items[i - iOffset].Tag;

                sub1.Text = sub2.Text;

                UpdateLVItem(items[i], sub1);
                UpdateLVItem(items[i - iOffset], sub2);
            }

            m_bDirty = true;
        }

        private int SafeConvertInt32(string sValue, int iBase)
        {
            try
            {
                return Convert.ToInt32(sValue, iBase);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void tbSubtitle_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (e.Modifiers.HasFlag(Keys.Control))
                    {
                        UpdateSubtitle();
                        e.Handled = true;
                    }
                    break;
                case Keys.Z:
                    if (e.Modifiers.HasFlag(Keys.Control))
                    {
                        tbSubtitle.Undo();
                        e.Handled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void miFileNew_Click(object sender, EventArgs e)
        {
            if (CanClearCurrentFile())
            {
                SaveUndoData();
                ClearCurrentFile();
            }
        }

        private void miFileOpen_Click(object sender, EventArgs e)
        {
            if (!CanClearCurrentFile())
                return;

            openFileDialog1.DefaultExt = "srt";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select subtitle file to open";
            openFileDialog1.Filter = "SubRip files (*.srt)|*.srt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                SaveUndoData();
                ClearCurrentFile();
                ReadSubtitleFile(openFileDialog1.FileName);
            }
        }

        private void miFileMerge_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "srt";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select subtitle file to merge";
            openFileDialog1.Filter = "SubRip files (*.srt)|*.srt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
                return;

            SaveUndoData();
            MergeSubtitleFile(openFileDialog1.FileName);
        }

        private void miFileClose_Click(object sender, EventArgs e)
        {
            if (CanClearCurrentFile())
                ClearCurrentFile();
        }

        private void miFileSave_Click(object sender, EventArgs e)
        {
            if (m_sFileName == "")
                SaveFileAs(false);
            else
                SaveFile(m_sFileName, false);
        }

        private void miFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileAs(false);
        }

        private void miFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miEditUndo_Click(object sender, EventArgs e)
        {
            Control ctrl = Global.GetActiveControl(this);
            if (ctrl is TextBox)
                (ctrl as TextBox).Undo();
            else
            {
                SaveRedoData();
                LoadUndoData();
                CopyRedoToUndo();
            }
        }

        private void miEditFind_Click(object sender, EventArgs e)
        {
            DoFindDialog();
        }

        private void miEditFindNext_Click(object sender, EventArgs e)
        {
            if (dlgFindText.IsDisposed)
            {
                DoFindDialog();
                return;
            }

            if (dlgFindText.GetSearchText() == "")
            {
                DoFindDialog();
                return;
            }

            dlgFindText.FindNext();
        }

        private void miEditGotoLine_Click(object sender, EventArgs e)
        {
            GoToLineForm form = new GoToLineForm();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != DialogResult.Cancel)
            {
                int iIndex = form.Index;
                if ((iIndex < lvSubtitles.Items.Count) && (iIndex >= 0))
                    lvSubtitles.EnsureVisible(iIndex);
            }
        }

        private void miEditOptions_Click(object sender, EventArgs e)
        {
            SFOptionsForm optionsForm = new SFOptionsForm();
            optionsForm.m_options = m_options;
            optionsForm.ShowDialog();
            m_options = optionsForm.m_options;
        }

        private void miEditMoveNext_Click(object sender, EventArgs e)
        {
            MoveNext();
        }

        private void miEditMovePrevious_Click(object sender, EventArgs e)
        {
            MovePrevious();
        }

        private void miActionRenumber_Click(object sender, EventArgs e)
        {
            SaveUndoData();
            RenumberAllSubtitles();
        }

        private void miActionCollapseSequential_Click(object sender, EventArgs e)
        {
            SaveUndoData();

            int iIndex = 0;
            bool bRenumber = false;
            while (iIndex < lvSubtitles.Items.Count - 1)
            {
                UpdateProgress(iIndex, lvSubtitles.Items.Count);
                if (!MergeDuplicates(iIndex, false))
                    iIndex++;
                else
                    bRenumber = true;
            }

            if (bRenumber)
                RenumberAllSubtitles();  // also sets m_bDirty

            SetReadyStatus();
        }

        private void miActionRemoveShort_Click(object sender, EventArgs e)
        {
            RemoveShortForm form = new RemoveShortForm();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != DialogResult.Cancel)
            {
                lvSubtitles.BeginUpdate();
                int iDuration = form.Duration;
                int iIndex = 0;
                bool bRenumber = false;
                while (iIndex < lvSubtitles.Items.Count)
                {
                    UpdateProgress(iIndex, lvSubtitles.Items.Count);

                    if (((Subtitle)lvSubtitles.Items[iIndex].Tag).Duration.TotalMilliseconds < iDuration)
                    {
                        lvSubtitles.Items[iIndex].Remove();
                        bRenumber = true;
                    }
                    else
                        iIndex++;
                }

                if (bRenumber)
                    RenumberAllSubtitles();
                lvSubtitles.EndUpdate();
            }
        }

        private void miActionRemoveDuplicate_Click(object sender, EventArgs e)
        {
            char[] charBeginning = { '[', ' ', '\r', '\n' };
            char[] charEnding = { ']', ' ', '\r', '\n' };

            SaveUndoData();

            for (int iIndex = 0; iIndex < lvSubtitles.Items.Count; iIndex++)
            {
                UpdateProgress(iIndex, lvSubtitles.Items.Count);
                Subtitle sub = (Subtitle)lvSubtitles.Items[iIndex].Tag;

                // Check to see if any lines in this subtitle are identical, ignoring
                // any surrounding brackets.
                List<string> arrayLines = new List<string>();
                int iOldFind = 0;
                int iFind = 0;
                while (iFind >= 0)
                {
                    iFind = sub.Text.IndexOfAny(new char[] { '\r', '\n' }, iFind + 1);
                    if (iFind < 0)
                        break;
                    if (iFind + 1 >= sub.Text.Length)
                        break;
                    if (IsCRLF(sub.Text[iFind + 1]))
                        continue;
                    arrayLines.Add(sub.Text.Substring(iOldFind, iFind - iOldFind).Trim());
                    iOldFind = iFind;
                }
                arrayLines.Add(sub.Text.Substring(iOldFind));

                for (int iLine = 0; iLine < arrayLines.Count - 1; iLine++)
                {
                    for (int iCompare = iLine + 1; iCompare < arrayLines.Count; iCompare++)
                    {
                        string sLine = (string)arrayLines[iLine];
                        string sCompare = (string)arrayLines[iCompare];
                        int iBegin = 0;
                        while (IsOneOf(sLine[iBegin], charBeginning))
                            iBegin++;
                        int iEnd = sLine.Length;
                        while (IsOneOf(sLine[iEnd - 1], charEnding))
                        {
                            iEnd--;
                            if (iEnd <= iBegin + 1)
                                break;
                        }
                        sLine = sLine.Substring(iBegin, iEnd - iBegin);

                        iBegin = 0;
                        while (IsOneOf(sCompare[iBegin], charBeginning))
                            iBegin++;
                        iEnd = sCompare.Length;
                        while (IsOneOf(sCompare[iEnd - 1], charEnding))
                        {
                            iEnd--;
                            if (iEnd <= iBegin + 1)
                                break;
                        }
                        sCompare = sCompare.Substring(iBegin, iEnd - iBegin);

                        if (sLine == sCompare)
                            arrayLines.RemoveAt(iCompare);
                    }
                }

                sub.Text = "";
                for (int iLine = 0; iLine < arrayLines.Count; iLine++)
                {
                    sub.Text += ((string)arrayLines[iLine]).Trim();
                    if (iLine < arrayLines.Count - 1)
                        sub.Text += "\r\n";
                }

                UpdateLVItem(lvSubtitles.Items[iIndex], sub);

            }
        }

        private void miActionMoveDown_Click(object sender, EventArgs e)
        {
            RealignSubs(1);
        }

        private void miActionMoveUp_Click(object sender, EventArgs e)
        {
            RealignSubs(-1);
        }

        private void miActionProcessJobs_Click(object sender, EventArgs e)
        {
            if (lvSubtitles.Items.Count < 1)
            {
                WarnNoSubtitles();
                return;
            }

            ProcessJobs();
        }

        private void miActionProcessDefaultJobs_Click(object sender, EventArgs e)
        {
            if (lvSubtitles.Items.Count < 1)
            {
                WarnNoSubtitles();
                return;
            }

            if (File.Exists(m_options.sVDJobsFile))
                ProcessJobs(m_options.sVDJobsFile);
            else
                ProcessJobs();
        }

        private string[] RemoveEmptyLines(string[] lines)
        {
            List<string> list = new List<string>(lines.Length);
            foreach (string s in lines)
                if (!String.IsNullOrWhiteSpace(s))
                    list.Add(s);
            return list.ToArray();
        }

        private void miActionExtractRange_Click(object sender, EventArgs e)
        {
            RangeExtractForm range = new RangeExtractForm();
            range.FileName = m_sFileName;
            if (lvSubtitles.SelectedItems.Count > 0)
            {
                range.SetStartTime(((Subtitle)lvSubtitles.SelectedItems[0].Tag).StartTime);
                range.SetStopTime(((Subtitle)lvSubtitles.SelectedItems[lvSubtitles.SelectedItems.Count-1].Tag).StopTime);
            }
            if (range.ShowDialog() == DialogResult.OK)
            {
                switch (range.Action)
                {
                    case RangeExtractForm.Extract.ExtractMultiple:
                        ExtractMultiple(range.Prefix, RemoveEmptyLines(range.Times), range.ShiftBack);
                        break;
                    default:
                        SaveUndoData();
                        DeleteRange(range.StartTime, range.StopTime, range.RemoveOutside);
                        if (range.ShiftBack)
                            OffsetSubtitles(-range.StartTime);
                        break;
                }
            }
        }

        public void DeleteRange(TimeSpan tsStart, TimeSpan tsStop, bool bRemoveOutside)
        {
            DateTime dtStart = TimeToolbox.TimeSpanToDateTime(tsStart);
            DateTime dtEnd = TimeToolbox.TimeSpanToDateTime(tsStop);

            lvSubtitles.BeginUpdate();
            foreach (ListViewItem lvi in lvSubtitles.Items)
            {
                Subtitle sub = lvi.Tag as Subtitle;

                if (bRemoveOutside)
                {
                    if (sub.StopTime < dtStart || sub.StartTime > dtEnd)
                        lvi.Remove();
                }
                else
                {
                    if (sub.StartTime >= dtStart || sub.StopTime <= dtEnd)
                        lvi.Remove();
                }
            }
            RenumberAllSubtitles();
            lvSubtitles.EndUpdate();
            m_bDirty = true;
        }

        public TimeSpan LastItemEndTime
        {
            get
            {
                if (lvSubtitles.Items.Count < 1)
                    return Global.TimeSpanFromString("0");
                return TimeToolbox.DateTimeToTimeSpan((lvSubtitles.Items[lvSubtitles.Items.Count - 1].Tag as Subtitle).StopTime);
            }
        }

        public TimeSpan FirstItemStartTime
        {
            get
            {
                if (lvSubtitles.Items.Count < 1)
                    return Global.TimeSpanFromString("0");
                return TimeToolbox.DateTimeToTimeSpan((lvSubtitles.Items[0].Tag as Subtitle).StopTime);
            }
        }

        public void ExtractMultiple(string strPrefix, string[] times, bool bOffsetStart = true)
        {
            for (int i = 0; i < times.Length; i++)
            {
                string strFileName = String.Format("{0}{1:D3}{2}", strPrefix, i, Path.GetExtension(m_sFileName));
                string strDir = Path.GetDirectoryName(strFileName);
                if (String.IsNullOrWhiteSpace(strDir))
                    strFileName = Path.Combine(Path.GetDirectoryName(m_sFileName), strFileName);

                StreamWriter writer = null;

                if (String.IsNullOrWhiteSpace(times[i]))
                    continue;

                TimeSpan tsStart = Global.TimeSpanFromString(times[i]);
                TimeSpan tsEnd = (i < times.Length - 1 ? Global.TimeSpanFromString(times[i + 1]) : LastItemEndTime);

                if (tsEnd <= tsStart)
                    continue;

                DateTime dtStart = TimeToolbox.TimeSpanToDateTime(tsStart);
                DateTime dtEnd = TimeToolbox.TimeSpanToDateTime(tsEnd);

                try
                {
                    writer = new StreamWriter(strFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Unable to open file \"{0}\" for writing\r\n\r\nException: {1}", strFileName, ex.Message),
                        "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                int iSubIndex = 0;
                foreach (ListViewItem lvi in lvSubtitles.Items)
                {
                    Subtitle sub = lvi.Tag as Subtitle;
                    if (sub.StartTime >= dtStart && sub.StopTime <= dtEnd)
                    {
                        Subtitle subNew = new Subtitle(sub);
                        subNew.Index = iSubIndex++;
                        if (bOffsetStart)
                            subNew.Offset(-tsStart.TotalMilliseconds);
                        WriteSubtitle(writer, subNew);
                    }
                }

                writer.Close();
            }
        }

        public void ExtractByFile(string strFile)
        {
            // The file is expected to be simply a list of times
            string[] times = RemoveEmptyLines(File.ReadAllLines(strFile));

            ExtractMultiple(Path.GetFileNameWithoutExtension(m_sFileName) + "-Extract", times);
        }

        private void miHelpAbout_Click(object sender, EventArgs e)
        {
            SFAboutBox aboutBox = new SFAboutBox();
            aboutBox.StartPosition = FormStartPosition.CenterParent;
            aboutBox.ShowDialog(this);
        }

        private void SubFutzerForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.Replace("[version]", Global.GetVersion());
        }

        public void ChangeDuration(TimeSpan tsChange)
        {
            IList lvic = lvSubtitles.Items;
            if (!ProcessAllItems)
                lvic = lvSubtitles.SelectedItems;

            lvSubtitles.BeginUpdate();

            foreach (ListViewItem lvi in lvic)
            {
                Subtitle sub = (Subtitle)lvi.Tag;
                sub.StopTime = sub.StopTime.Add(tsChange);
                if (lvi.Index < lvSubtitles.Items.Count - 1)
                    VerifyDuration(lvSubtitles.Items[lvi.Index], lvSubtitles.Items[lvi.Index + 1]);
                UpdateLVItem(lvi);
            }

            lvSubtitles.EndUpdate();
        }

        private void miEditSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void SubFutzerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bDirty)
            {
                DialogResult result = MessageBox.Show(this, "Do you wish to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Cancel)
                    e.Cancel = true;
                else if (result == DialogResult.Yes)
                    SaveFile(m_sFileName, false);
            }

            m_options.WriteToRegistry();
        }

        private void miContextDeleteSelected_Click(object sender, EventArgs e)
        {
            SaveUndoData();
            DeleteSelectedItems();
        }

        private void miContextDeleteAllExcept_Click(object sender, EventArgs e)
        {
            SaveUndoData();
            lvSubtitles.BeginUpdate();
            foreach (ListViewItem lvItem in lvSubtitles.Items)
            {
                if (!lvItem.Selected)
                    lvItem.Remove();
            }
            RenumberAllSubtitles();  // also sets m_bDirty
            lvSubtitles.EndUpdate();
        }

        private void miContextMerge_Click(object sender, EventArgs e)
        {
            SaveUndoData();
            MergeSelectedItemsToSingle();
        }

        private void miContextInsert_Click(object sender, EventArgs e)
        {
            int iIndex = 0;
            if (lvSubtitles.SelectedItems.Count < 1)
                iIndex = lvSubtitles.Items.Count;
            else
                iIndex = lvSubtitles.SelectedItems[0].Index;

            Subtitle sub = new Subtitle();

            if (iIndex > 0)
            {
                Subtitle subCopy = (Subtitle)lvSubtitles.Items[iIndex - 1].Tag;
                sub.StartTime = subCopy.StopTime;
            }

            sub.StopTime = sub.StartTime.AddSeconds(2);

            ListViewItem lvItem = new ListViewItem();
            UpdateLVItem(lvItem, sub);

            lvSubtitles.Items.Insert(iIndex, lvItem);

            RenumberAllSubtitles();

            lvItem.Selected = true;
            tbSubtitle.Focus();

            m_bDirty = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            SaveUndoData();
            switch (cbWhatAction.SelectedIndex)
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
                    SetFirstItem(ttbOffset.GetTime());
                    m_bDirty = true;
                    break;
                case 3: // Expand last item
                    ExpandLastItem(ttbOffset.GetTime());
                    m_bDirty = true;
                    break;
                case 4: // Expand by
                    ExpandSubtitles(ttbOffset.GetTime());
                    m_bDirty = true;
                    break;
                case 5: // Contract by
                    ExpandSubtitles(-ttbOffset.GetTime());
                    m_bDirty = true;
                    break;
                case 6: // Lengthen duration by
                    ChangeDuration(ttbOffset.GetTime());
                    m_bDirty = true;
                    break;
                case 7: // Shorten duration b y
                    ChangeDuration(-ttbOffset.GetTime());
                    m_bDirty = true;
                    break;
                default:
                    break;
            }
        }

        private void SubFutzerForm_KeyDown(object sender, KeyEventArgs e)
        {
            Control ctrl = null;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (e.Modifiers.HasFlag(Keys.Control) && Global.GetActiveControl(this) == tbSubtitle)
                    {
                        UpdateSubtitle();
                        lvSubtitles.Focus();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;
                case Keys.V:
                    if (e.Modifiers.HasFlag(Keys.Control))
                    {
                        ctrl = Global.GetActiveControl(this);
                        if (ctrl.Parent != null && ctrl.Parent is TimeTextBox)
                            ctrl = ctrl.Parent;
                        if (ctrl == ttbStart || ctrl == ttbStop)
                        {
                            if (PasteTwo())
                            {
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                            }
                        }
                    }
                    break;
                case Keys.Insert:
                    if (e.Modifiers.HasFlag(Keys.Shift))
                    {
                        ctrl = Global.GetActiveControl(this);
                        if (ctrl.Parent != null && ctrl.Parent is TimeTextBox)
                            ctrl = ctrl.Parent;
                        if (ctrl == ttbStart || ctrl == ttbStop)
                        {
                            if (PasteTwo())
                            {
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private bool PasteTwo()
        {
            if (!Clipboard.ContainsText())
                return false;

            string strTimes = Clipboard.GetText();
            string[] times = strTimes.Split(new char[] { ' ', '\r', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (times.Length < 2)
                return false;

            ttbStart.SetText(times[0]);
            ttbStop.SetText(times[1]);
            return true;
        }

        private void cmSubtitles_Opening(object sender, CancelEventArgs e)
        {
            bool bAnySelected = lvSubtitles.SelectedItems.Count > 0;
            miContextDeleteAllExcept.Enabled = bAnySelected;
            miContextDeleteSelected.Enabled = bAnySelected;
            miContextMerge.Enabled = bAnySelected;
        }

        private void lvSubtitles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    tbSubtitle.Focus();
                    break;
                default:
                    break;
            }
        }

        private void miFileSaveSelected_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = "srt";
            saveFileDialog1.Title = "Save the currently selected subtitles as";
            saveFileDialog1.Filter = "SubRip files (*.srt)|*.srt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile(saveFileDialog1.FileName, true);
            }
        }
    }
}
