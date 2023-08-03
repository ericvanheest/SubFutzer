namespace SubFutzer
{
    partial class SubFutzerForm
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvSubtitles = new System.Windows.Forms.ListView();
            this.chIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStopTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmSubtitles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miContextDeleteSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.miContextDeleteAllExcept = new System.Windows.Forms.ToolStripMenuItem();
            this.miContextMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.miContextInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditFind = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditGotoLine = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miEditOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miEditMoveNext = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditMovePrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.miAction = new System.Windows.Forms.ToolStripMenuItem();
            this.miActionRenumber = new System.Windows.Forms.ToolStripMenuItem();
            this.miActionCollapseSequential = new System.Windows.Forms.ToolStripMenuItem();
            this.miActionRemoveShort = new System.Windows.Forms.ToolStripMenuItem();
            this.miActionRemoveDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.miActionMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.miActionMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.miActionProcessJobs = new System.Windows.Forms.ToolStripMenuItem();
            this.miActionProcessDefaultJobs = new System.Windows.Forms.ToolStripMenuItem();
            this.miActionExtractRange = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbWhichItems = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbMaxLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSetMaxLength = new System.Windows.Forms.Button();
            this.ttbOffset = new SubFutzer.TimeTextBox();
            this.cbWhatAction = new System.Windows.Forms.ComboBox();
            this.checkNLBeforeBracket = new System.Windows.Forms.CheckBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnMergeAll = new System.Windows.Forms.Button();
            this.ttbStop = new SubFutzer.TimeTextBox();
            this.checkLockTimes = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ttbStart = new SubFutzer.TimeTextBox();
            this.tbSubtitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.miFileSaveSelected = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cmSubtitles.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvSubtitles);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnUpdate);
            this.splitContainer1.Panel2.Controls.Add(this.cbWhichItems);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.ttbStop);
            this.splitContainer1.Panel2.Controls.Add(this.checkLockTimes);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.ttbStart);
            this.splitContainer1.Panel2.Controls.Add(this.tbSubtitle);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(762, 345);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 9;
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
            this.lvSubtitles.ContextMenuStrip = this.cmSubtitles;
            this.lvSubtitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubtitles.FullRowSelect = true;
            this.lvSubtitles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSubtitles.HideSelection = false;
            this.lvSubtitles.Location = new System.Drawing.Point(0, 24);
            this.lvSubtitles.Name = "lvSubtitles";
            this.lvSubtitles.Size = new System.Drawing.Size(762, 189);
            this.lvSubtitles.TabIndex = 0;
            this.lvSubtitles.UseCompatibleStateImageBehavior = false;
            this.lvSubtitles.View = System.Windows.Forms.View.Details;
            this.lvSubtitles.SelectedIndexChanged += new System.EventHandler(this.lvSubtitles_SelectedIndexChanged);
            this.lvSubtitles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvSubtitles_DragDrop);
            this.lvSubtitles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvSubtitles_DragEnter);
            this.lvSubtitles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvSubtitles_KeyDown);
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
            // cmSubtitles
            // 
            this.cmSubtitles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miContextDeleteSelected,
            this.miContextDeleteAllExcept,
            this.miContextMerge,
            this.toolStripSeparator7,
            this.miContextInsert});
            this.cmSubtitles.Name = "cmSubtitles";
            this.cmSubtitles.Size = new System.Drawing.Size(247, 98);
            this.cmSubtitles.Opening += new System.ComponentModel.CancelEventHandler(this.cmSubtitles_Opening);
            // 
            // miContextDeleteSelected
            // 
            this.miContextDeleteSelected.Name = "miContextDeleteSelected";
            this.miContextDeleteSelected.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.miContextDeleteSelected.Size = new System.Drawing.Size(246, 22);
            this.miContextDeleteSelected.Text = "&Delete selected items";
            this.miContextDeleteSelected.Click += new System.EventHandler(this.miContextDeleteSelected_Click);
            // 
            // miContextDeleteAllExcept
            // 
            this.miContextDeleteAllExcept.Name = "miContextDeleteAllExcept";
            this.miContextDeleteAllExcept.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.miContextDeleteAllExcept.Size = new System.Drawing.Size(246, 22);
            this.miContextDeleteAllExcept.Text = "Delete all &except selected";
            this.miContextDeleteAllExcept.Click += new System.EventHandler(this.miContextDeleteAllExcept_Click);
            // 
            // miContextMerge
            // 
            this.miContextMerge.Name = "miContextMerge";
            this.miContextMerge.Size = new System.Drawing.Size(246, 22);
            this.miContextMerge.Text = "&Merge items into single subtitle";
            this.miContextMerge.Click += new System.EventHandler(this.miContextMerge_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(243, 6);
            // 
            // miContextInsert
            // 
            this.miContextInsert.Name = "miContextInsert";
            this.miContextInsert.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miContextInsert.Size = new System.Drawing.Size(246, 22);
            this.miContextInsert.Text = "&Insert Subtitle";
            this.miContextInsert.Click += new System.EventHandler(this.miContextInsert_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.miAction,
            this.miHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(762, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileNew,
            this.miFileOpen,
            this.miFileMerge,
            this.miFileClose,
            this.toolStripSeparator1,
            this.miFileSave,
            this.miFileSaveAs,
            this.miFileSaveSelected,
            this.miFileRecent,
            this.toolStripSeparator2,
            this.miFileExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "&File";
            // 
            // miFileNew
            // 
            this.miFileNew.Name = "miFileNew";
            this.miFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miFileNew.Size = new System.Drawing.Size(207, 22);
            this.miFileNew.Text = "&New";
            this.miFileNew.Click += new System.EventHandler(this.miFileNew_Click);
            // 
            // miFileOpen
            // 
            this.miFileOpen.Name = "miFileOpen";
            this.miFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miFileOpen.Size = new System.Drawing.Size(207, 22);
            this.miFileOpen.Text = "&Open...";
            this.miFileOpen.Click += new System.EventHandler(this.miFileOpen_Click);
            // 
            // miFileMerge
            // 
            this.miFileMerge.Name = "miFileMerge";
            this.miFileMerge.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.miFileMerge.Size = new System.Drawing.Size(207, 22);
            this.miFileMerge.Text = "&Merge...";
            this.miFileMerge.Click += new System.EventHandler(this.miFileMerge_Click);
            // 
            // miFileClose
            // 
            this.miFileClose.Name = "miFileClose";
            this.miFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.miFileClose.Size = new System.Drawing.Size(207, 22);
            this.miFileClose.Text = "&Close";
            this.miFileClose.Click += new System.EventHandler(this.miFileClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // miFileSave
            // 
            this.miFileSave.Name = "miFileSave";
            this.miFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miFileSave.Size = new System.Drawing.Size(207, 22);
            this.miFileSave.Text = "&Save";
            this.miFileSave.Click += new System.EventHandler(this.miFileSave_Click);
            // 
            // miFileSaveAs
            // 
            this.miFileSaveAs.Name = "miFileSaveAs";
            this.miFileSaveAs.Size = new System.Drawing.Size(207, 22);
            this.miFileSaveAs.Text = "Save &as...";
            this.miFileSaveAs.Click += new System.EventHandler(this.miFileSaveAs_Click);
            // 
            // miFileRecent
            // 
            this.miFileRecent.Name = "miFileRecent";
            this.miFileRecent.Size = new System.Drawing.Size(207, 22);
            this.miFileRecent.Text = "Recent Files";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(204, 6);
            // 
            // miFileExit
            // 
            this.miFileExit.Name = "miFileExit";
            this.miFileExit.Size = new System.Drawing.Size(207, 22);
            this.miFileExit.Text = "E&xit";
            this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditUndo,
            this.miEditFind,
            this.miEditFindNext,
            this.miEditGotoLine,
            this.miEditSelectAll,
            this.toolStripSeparator4,
            this.miEditOptions,
            this.toolStripSeparator3,
            this.miEditMoveNext,
            this.miEditMovePrevious});
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(39, 20);
            this.miEdit.Text = "&Edit";
            // 
            // miEditUndo
            // 
            this.miEditUndo.Name = "miEditUndo";
            this.miEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miEditUndo.Size = new System.Drawing.Size(201, 22);
            this.miEditUndo.Text = "&Undo";
            this.miEditUndo.Click += new System.EventHandler(this.miEditUndo_Click);
            // 
            // miEditFind
            // 
            this.miEditFind.Name = "miEditFind";
            this.miEditFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.miEditFind.Size = new System.Drawing.Size(201, 22);
            this.miEditFind.Text = "&Find...";
            this.miEditFind.Click += new System.EventHandler(this.miEditFind_Click);
            // 
            // miEditFindNext
            // 
            this.miEditFindNext.Name = "miEditFindNext";
            this.miEditFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.miEditFindNext.Size = new System.Drawing.Size(201, 22);
            this.miEditFindNext.Text = "Find &next";
            this.miEditFindNext.Click += new System.EventHandler(this.miEditFindNext_Click);
            // 
            // miEditGotoLine
            // 
            this.miEditGotoLine.Name = "miEditGotoLine";
            this.miEditGotoLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.miEditGotoLine.Size = new System.Drawing.Size(201, 22);
            this.miEditGotoLine.Text = "&Go to line...";
            this.miEditGotoLine.Click += new System.EventHandler(this.miEditGotoLine_Click);
            // 
            // miEditSelectAll
            // 
            this.miEditSelectAll.Name = "miEditSelectAll";
            this.miEditSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.miEditSelectAll.Size = new System.Drawing.Size(201, 22);
            this.miEditSelectAll.Text = "Select &all";
            this.miEditSelectAll.Click += new System.EventHandler(this.miEditSelectAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(198, 6);
            // 
            // miEditOptions
            // 
            this.miEditOptions.Name = "miEditOptions";
            this.miEditOptions.Size = new System.Drawing.Size(201, 22);
            this.miEditOptions.Text = "&Options...";
            this.miEditOptions.Click += new System.EventHandler(this.miEditOptions_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
            // 
            // miEditMoveNext
            // 
            this.miEditMoveNext.Name = "miEditMoveNext";
            this.miEditMoveNext.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.miEditMoveNext.Size = new System.Drawing.Size(201, 22);
            this.miEditMoveNext.Text = "Move &Next";
            this.miEditMoveNext.Click += new System.EventHandler(this.miEditMoveNext_Click);
            // 
            // miEditMovePrevious
            // 
            this.miEditMovePrevious.Name = "miEditMovePrevious";
            this.miEditMovePrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.miEditMovePrevious.Size = new System.Drawing.Size(201, 22);
            this.miEditMovePrevious.Text = "Move &Previous";
            this.miEditMovePrevious.Click += new System.EventHandler(this.miEditMovePrevious_Click);
            // 
            // miAction
            // 
            this.miAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miActionRenumber,
            this.miActionCollapseSequential,
            this.miActionRemoveShort,
            this.miActionRemoveDuplicate,
            this.toolStripSeparator5,
            this.miActionMoveDown,
            this.miActionMoveUp,
            this.toolStripSeparator6,
            this.miActionProcessJobs,
            this.miActionProcessDefaultJobs,
            this.miActionExtractRange});
            this.miAction.Name = "miAction";
            this.miAction.Size = new System.Drawing.Size(54, 20);
            this.miAction.Text = "&Action";
            // 
            // miActionRenumber
            // 
            this.miActionRenumber.Name = "miActionRenumber";
            this.miActionRenumber.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.miActionRenumber.Size = new System.Drawing.Size(312, 22);
            this.miActionRenumber.Text = "&Renumber";
            this.miActionRenumber.Click += new System.EventHandler(this.miActionRenumber_Click);
            // 
            // miActionCollapseSequential
            // 
            this.miActionCollapseSequential.Name = "miActionCollapseSequential";
            this.miActionCollapseSequential.Size = new System.Drawing.Size(312, 22);
            this.miActionCollapseSequential.Text = "&Collapse sequential duplicates";
            this.miActionCollapseSequential.Click += new System.EventHandler(this.miActionCollapseSequential_Click);
            // 
            // miActionRemoveShort
            // 
            this.miActionRemoveShort.Name = "miActionRemoveShort";
            this.miActionRemoveShort.Size = new System.Drawing.Size(312, 22);
            this.miActionRemoveShort.Text = "R&emove short duration items...";
            this.miActionRemoveShort.Click += new System.EventHandler(this.miActionRemoveShort_Click);
            // 
            // miActionRemoveDuplicate
            // 
            this.miActionRemoveDuplicate.Name = "miActionRemoveDuplicate";
            this.miActionRemoveDuplicate.Size = new System.Drawing.Size(312, 22);
            this.miActionRemoveDuplicate.Text = "Re&move intra-subtitle duplicate lines";
            this.miActionRemoveDuplicate.Click += new System.EventHandler(this.miActionRemoveDuplicate_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(309, 6);
            // 
            // miActionMoveDown
            // 
            this.miActionMoveDown.Name = "miActionMoveDown";
            this.miActionMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.miActionMoveDown.Size = new System.Drawing.Size(312, 22);
            this.miActionMoveDown.Text = "Move subtitles down one index";
            this.miActionMoveDown.Click += new System.EventHandler(this.miActionMoveDown_Click);
            // 
            // miActionMoveUp
            // 
            this.miActionMoveUp.Name = "miActionMoveUp";
            this.miActionMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.miActionMoveUp.Size = new System.Drawing.Size(312, 22);
            this.miActionMoveUp.Text = "Move subtitles up one index";
            this.miActionMoveUp.Click += new System.EventHandler(this.miActionMoveUp_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(309, 6);
            // 
            // miActionProcessJobs
            // 
            this.miActionProcessJobs.Name = "miActionProcessJobs";
            this.miActionProcessJobs.Size = new System.Drawing.Size(312, 22);
            this.miActionProcessJobs.Text = "&Process .jobs file...";
            this.miActionProcessJobs.Click += new System.EventHandler(this.miActionProcessJobs_Click);
            // 
            // miActionProcessDefaultJobs
            // 
            this.miActionProcessDefaultJobs.Name = "miActionProcessDefaultJobs";
            this.miActionProcessDefaultJobs.Size = new System.Drawing.Size(312, 22);
            this.miActionProcessDefaultJobs.Text = "Process &default .jobs file";
            this.miActionProcessDefaultJobs.Click += new System.EventHandler(this.miActionProcessDefaultJobs_Click);
            // 
            // miActionExtractRange
            // 
            this.miActionExtractRange.Name = "miActionExtractRange";
            this.miActionExtractRange.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.miActionExtractRange.Size = new System.Drawing.Size(312, 22);
            this.miActionExtractRange.Text = "&Extract range";
            this.miActionExtractRange.Click += new System.EventHandler(this.miActionExtractRange_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHelpAbout});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(44, 20);
            this.miHelp.Text = "&Help";
            // 
            // miHelpAbout
            // 
            this.miHelpAbout.Name = "miHelpAbout";
            this.miHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.miHelpAbout.Size = new System.Drawing.Size(190, 22);
            this.miHelpAbout.Text = "&About SubFutzer...";
            this.miHelpAbout.Click += new System.EventHandler(this.miHelpAbout_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(687, 84);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbWhichItems
            // 
            this.cbWhichItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWhichItems.Items.AddRange(new object[] {
            "All items",
            "Selected items only"});
            this.cbWhichItems.Location = new System.Drawing.Point(177, 0);
            this.cbWhichItems.Name = "cbWhichItems";
            this.cbWhichItems.Size = new System.Drawing.Size(120, 21);
            this.cbWhichItems.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "The following commands will affect";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(441, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sto&p:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMaxLength);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSetMaxLength);
            this.groupBox1.Controls.Add(this.ttbOffset);
            this.groupBox1.Controls.Add(this.cbWhatAction);
            this.groupBox1.Controls.Add(this.checkNLBeforeBracket);
            this.groupBox1.Controls.Add(this.btnChange);
            this.groupBox1.Controls.Add(this.btnMergeAll);
            this.groupBox1.Location = new System.Drawing.Point(1, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 104);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // tbMaxLength
            // 
            this.tbMaxLength.Location = new System.Drawing.Point(144, 48);
            this.tbMaxLength.Name = "tbMaxLength";
            this.tbMaxLength.Size = new System.Drawing.Size(72, 20);
            this.tbMaxLength.TabIndex = 4;
            this.tbMaxLength.Text = "50";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Set maximum line length to ";
            // 
            // btnSetMaxLength
            // 
            this.btnSetMaxLength.Location = new System.Drawing.Point(224, 48);
            this.btnSetMaxLength.Name = "btnSetMaxLength";
            this.btnSetMaxLength.Size = new System.Drawing.Size(32, 23);
            this.btnSetMaxLength.TabIndex = 5;
            this.btnSetMaxLength.Text = "G&o";
            this.btnSetMaxLength.Click += new System.EventHandler(this.btnSetMaxLength_Click);
            // 
            // ttbOffset
            // 
            this.ttbOffset.Location = new System.Drawing.Point(144, 16);
            this.ttbOffset.Name = "ttbOffset";
            this.ttbOffset.Size = new System.Drawing.Size(72, 24);
            this.ttbOffset.TabIndex = 1;
            // 
            // cbWhatAction
            // 
            this.cbWhatAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWhatAction.Items.AddRange(new object[] {
            "Shift backwards by",
            "Shift forwards by",
            "Set first item to",
            "Expand last item to",
            "Expand by",
            "Contract by",
            "Lengthen duration by",
            "Shorten duration by"});
            this.cbWhatAction.Location = new System.Drawing.Point(8, 16);
            this.cbWhatAction.Name = "cbWhatAction";
            this.cbWhatAction.Size = new System.Drawing.Size(128, 21);
            this.cbWhatAction.TabIndex = 0;
            // 
            // checkNLBeforeBracket
            // 
            this.checkNLBeforeBracket.Checked = true;
            this.checkNLBeforeBracket.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNLBeforeBracket.Location = new System.Drawing.Point(104, 75);
            this.checkNLBeforeBracket.Name = "checkNLBeforeBracket";
            this.checkNLBeforeBracket.Size = new System.Drawing.Size(192, 24);
            this.checkNLBeforeBracket.TabIndex = 7;
            this.checkNLBeforeBracket.Text = "Keep (add) newlines before a \"[\"";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(224, 16);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(32, 24);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "&Go";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnMergeAll
            // 
            this.btnMergeAll.Location = new System.Drawing.Point(8, 75);
            this.btnMergeAll.Name = "btnMergeAll";
            this.btnMergeAll.Size = new System.Drawing.Size(88, 23);
            this.btnMergeAll.TabIndex = 6;
            this.btnMergeAll.Text = "&Merge all lines";
            this.btnMergeAll.Click += new System.EventHandler(this.btnMergeAll_Click);
            // 
            // ttbStop
            // 
            this.ttbStop.Location = new System.Drawing.Point(481, 88);
            this.ttbStop.Name = "ttbStop";
            this.ttbStop.Size = new System.Drawing.Size(72, 24);
            this.ttbStop.TabIndex = 8;
            // 
            // checkLockTimes
            // 
            this.checkLockTimes.AutoSize = true;
            this.checkLockTimes.Location = new System.Drawing.Point(361, 112);
            this.checkLockTimes.Name = "checkLockTimes";
            this.checkLockTimes.Size = new System.Drawing.Size(219, 17);
            this.checkLockTimes.TabIndex = 10;
            this.checkLockTimes.Text = "C&hange stop time if start time is changed.";
            this.checkLockTimes.CheckedChanged += new System.EventHandler(this.checkLockTimes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(321, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "&Start:";
            // 
            // ttbStart
            // 
            this.ttbStart.Location = new System.Drawing.Point(361, 88);
            this.ttbStart.Name = "ttbStart";
            this.ttbStart.Size = new System.Drawing.Size(72, 24);
            this.ttbStart.TabIndex = 6;
            // 
            // tbSubtitle
            // 
            this.tbSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSubtitle.Enabled = false;
            this.tbSubtitle.Location = new System.Drawing.Point(361, 0);
            this.tbSubtitle.Multiline = true;
            this.tbSubtitle.Name = "tbSubtitle";
            this.tbSubtitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSubtitle.Size = new System.Drawing.Size(401, 80);
            this.tbSubtitle.TabIndex = 4;
            this.tbSubtitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSubtitle_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(321, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Text:";
            // 
            // statusBar1
            // 
            this.statusBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar1.Location = new System.Drawing.Point(1, 351);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(749, 23);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 11;
            this.statusBar1.Text = "Ready.";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "doc1";
            // 
            // miFileSaveSelected
            // 
            this.miFileSaveSelected.Name = "miFileSaveSelected";
            this.miFileSaveSelected.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.miFileSaveSelected.Size = new System.Drawing.Size(239, 22);
            this.miFileSaveSelected.Text = "Save s&elected as...";
            this.miFileSaveSelected.Click += new System.EventHandler(this.miFileSaveSelected_Click);
            // 
            // SubFutzerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 371);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(680, 300);
            this.Name = "SubFutzerForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "SubFutzer [version]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubFutzerForm_FormClosing);
            this.Load += new System.EventHandler(this.SubFutzerForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SubFutzerForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SubFutzerForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SubFutzerForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cmSubtitles.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ListView lvSubtitles;
        private System.Windows.Forms.ColumnHeader chIndex;
        private System.Windows.Forms.ColumnHeader chStartTime;
        private System.Windows.Forms.ColumnHeader chStopTime;
        private System.Windows.Forms.ColumnHeader chDuration;
        private System.Windows.Forms.ColumnHeader chText;
        private System.Windows.Forms.ComboBox cbWhichItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMaxLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSetMaxLength;
        private TimeTextBox ttbOffset;
        private System.Windows.Forms.ComboBox cbWhatAction;
        private System.Windows.Forms.CheckBox checkNLBeforeBracket;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnMergeAll;
        private System.Windows.Forms.CheckBox checkLockTimes;
        private System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.TextBox tbSubtitle;
        private System.Windows.Forms.Label label3;
        private TimeTextBox ttbStart;
        private System.Windows.Forms.Label label1;
        private TimeTextBox ttbStop;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miFileNew;
        private System.Windows.Forms.ToolStripMenuItem miFileOpen;
        private System.Windows.Forms.ToolStripMenuItem miFileMerge;
        private System.Windows.Forms.ToolStripMenuItem miFileClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miFileSave;
        private System.Windows.Forms.ToolStripMenuItem miFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miFileExit;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miEditUndo;
        private System.Windows.Forms.ToolStripMenuItem miEditFind;
        private System.Windows.Forms.ToolStripMenuItem miEditFindNext;
        private System.Windows.Forms.ToolStripMenuItem miEditGotoLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miEditOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miEditMoveNext;
        private System.Windows.Forms.ToolStripMenuItem miEditMovePrevious;
        private System.Windows.Forms.ToolStripMenuItem miAction;
        private System.Windows.Forms.ToolStripMenuItem miActionRenumber;
        private System.Windows.Forms.ToolStripMenuItem miActionCollapseSequential;
        private System.Windows.Forms.ToolStripMenuItem miActionRemoveShort;
        private System.Windows.Forms.ToolStripMenuItem miActionRemoveDuplicate;
        private System.Windows.Forms.ToolStripMenuItem miActionMoveDown;
        private System.Windows.Forms.ToolStripMenuItem miActionMoveUp;
        private System.Windows.Forms.ToolStripMenuItem miActionProcessJobs;
        private System.Windows.Forms.ToolStripMenuItem miActionProcessDefaultJobs;
        private System.Windows.Forms.ToolStripMenuItem miActionExtractRange;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miHelpAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem miFileRecent;
        private System.Windows.Forms.ToolStripMenuItem miEditSelectAll;
        private System.Windows.Forms.ContextMenuStrip cmSubtitles;
        private System.Windows.Forms.ToolStripMenuItem miContextDeleteSelected;
        private System.Windows.Forms.ToolStripMenuItem miContextDeleteAllExcept;
        private System.Windows.Forms.ToolStripMenuItem miContextMerge;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem miContextInsert;
        private System.Windows.Forms.ToolStripMenuItem miFileSaveSelected;
    }
}