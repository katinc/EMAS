namespace EMASDeviceConsole
{
    partial class EMASDeviceConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EMASDeviceConsole));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ServiceMNU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRefreshMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShowMe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.lstView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceMenus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuConnectToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPing = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSyncDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFingerprintsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.importAttendanceLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.clearDeviceLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.setDeviceTieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imglist32 = new System.Windows.Forms.ImageList(this.components);
            this.imgList16 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picPleaseWait = new System.Windows.Forms.PictureBox();
            this.nupMaxListCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblLastSyncedDate = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstMessages = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.ServiceMNU.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.deviceMenus.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPleaseWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxListCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Manages all attandance devices";
            this.notifyIcon1.BalloonTipTitle = "EMAS Device Console";
            this.notifyIcon1.ContextMenuStrip = this.ServiceMNU;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "EMAS Device Console";
            this.notifyIcon1.Visible = true;
            // 
            // ServiceMNU
            // 
            this.ServiceMNU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRefreshMnu,
            this.toolStripSeparator14,
            this.mnuShowMe,
            this.toolStripSeparator9,
            this.restartToolStripMenuItem});
            this.ServiceMNU.Name = "ServiceMNU";
            this.ServiceMNU.Size = new System.Drawing.Size(114, 82);
            // 
            // mnuRefreshMnu
            // 
            this.mnuRefreshMnu.Name = "mnuRefreshMnu";
            this.mnuRefreshMnu.Size = new System.Drawing.Size(113, 22);
            this.mnuRefreshMnu.Text = "Refresh";
            this.mnuRefreshMnu.Visible = false;
            this.mnuRefreshMnu.Click += new System.EventHandler(this.mnuRefreshMnu_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(110, 6);
            // 
            // mnuShowMe
            // 
            this.mnuShowMe.Name = "mnuShowMe";
            this.mnuShowMe.Size = new System.Drawing.Size(113, 22);
            this.mnuShowMe.Text = "Hide";
            this.mnuShowMe.Click += new System.EventHandler(this.mnuShowMe_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(110, 6);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restartToolStripMenuItem.Text = "Exit";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(967, 45);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(967, 417);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lstView);
            this.splitContainer2.Size = new System.Drawing.Size(208, 413);
            this.splitContainer2.SplitterDistance = 38;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONFIGUERED DEVICES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstView
            // 
            this.lstView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader1});
            this.lstView.ContextMenuStrip = this.deviceMenus;
            this.lstView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstView.FullRowSelect = true;
            this.lstView.GridLines = true;
            this.lstView.HideSelection = false;
            this.lstView.LargeImageList = this.imglist32;
            this.lstView.Location = new System.Drawing.Point(0, 0);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(206, 372);
            this.lstView.SmallImageList = this.imgList16;
            this.lstView.TabIndex = 0;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Tile;
            this.lstView.SelectedIndexChanged += new System.EventHandler(this.lstView_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Location";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IP Address";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Last Synced";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Device ID";
            this.columnHeader1.Width = 1;
            // 
            // deviceMenus
            // 
            this.deviceMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditDevice,
            this.toolStripSeparator1,
            this.mnuConnectToggle,
            this.toolStripSeparator2,
            this.mnuPing,
            this.toolStripSeparator3,
            this.mnuSyncDevice,
            this.toolStripSeparator4,
            this.setDeviceTieToolStripMenuItem,
            this.toolStripSeparator6,
            this.mnuDeleteDevice,
            this.toolStripSeparator5,
            this.refreshToolStripMenuItem});
            this.deviceMenus.Name = "deviceMenus";
            this.deviceMenus.Size = new System.Drawing.Size(160, 194);
            // 
            // mnuEditDevice
            // 
            this.mnuEditDevice.Name = "mnuEditDevice";
            this.mnuEditDevice.Size = new System.Drawing.Size(159, 22);
            this.mnuEditDevice.Text = "Edit";
            this.mnuEditDevice.Click += new System.EventHandler(this.mnuEditDevice_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuConnectToggle
            // 
            this.mnuConnectToggle.Name = "mnuConnectToggle";
            this.mnuConnectToggle.Size = new System.Drawing.Size(159, 22);
            this.mnuConnectToggle.Text = "Connect";
            this.mnuConnectToggle.Click += new System.EventHandler(this.mnuConnectToggle_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuPing
            // 
            this.mnuPing.Name = "mnuPing";
            this.mnuPing.Size = new System.Drawing.Size(159, 22);
            this.mnuPing.Text = "Ping";
            this.mnuPing.Click += new System.EventHandler(this.mnuPing_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuSyncDevice
            // 
            this.mnuSyncDevice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadFingerprintsToolStripMenuItem,
            this.toolStripSeparator7,
            this.importAttendanceLogToolStripMenuItem,
            this.toolStripSeparator8,
            this.clearDeviceLogsToolStripMenuItem});
            this.mnuSyncDevice.Name = "mnuSyncDevice";
            this.mnuSyncDevice.Size = new System.Drawing.Size(159, 22);
            this.mnuSyncDevice.Text = "Synchronization";
            this.mnuSyncDevice.Click += new System.EventHandler(this.mnuSyncDevice_Click);
            // 
            // uploadFingerprintsToolStripMenuItem
            // 
            this.uploadFingerprintsToolStripMenuItem.Name = "uploadFingerprintsToolStripMenuItem";
            this.uploadFingerprintsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.uploadFingerprintsToolStripMenuItem.Text = "Upload Fingerprints to Device";
            this.uploadFingerprintsToolStripMenuItem.Click += new System.EventHandler(this.uploadFingerprintsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(242, 6);
            // 
            // importAttendanceLogToolStripMenuItem
            // 
            this.importAttendanceLogToolStripMenuItem.Name = "importAttendanceLogToolStripMenuItem";
            this.importAttendanceLogToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.importAttendanceLogToolStripMenuItem.Text = "Import Attendance Log to EMAS";
            this.importAttendanceLogToolStripMenuItem.Click += new System.EventHandler(this.importAttendanceLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(242, 6);
            // 
            // clearDeviceLogsToolStripMenuItem
            // 
            this.clearDeviceLogsToolStripMenuItem.Name = "clearDeviceLogsToolStripMenuItem";
            this.clearDeviceLogsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.clearDeviceLogsToolStripMenuItem.Text = "Clear Device Logs";
            this.clearDeviceLogsToolStripMenuItem.Click += new System.EventHandler(this.clearDeviceLogsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(156, 6);
            // 
            // setDeviceTieToolStripMenuItem
            // 
            this.setDeviceTieToolStripMenuItem.Name = "setDeviceTieToolStripMenuItem";
            this.setDeviceTieToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.setDeviceTieToolStripMenuItem.Text = "Sync Time";
            this.setDeviceTieToolStripMenuItem.Click += new System.EventHandler(this.setDeviceTieToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuDeleteDevice
            // 
            this.mnuDeleteDevice.Name = "mnuDeleteDevice";
            this.mnuDeleteDevice.Size = new System.Drawing.Size(159, 22);
            this.mnuDeleteDevice.Text = "Delete";
            this.mnuDeleteDevice.Click += new System.EventHandler(this.mnuDeleteDevice_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(156, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // imglist32
            // 
            this.imglist32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist32.ImageStream")));
            this.imglist32.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist32.Images.SetKeyName(0, "connected-256 (1).png");
            this.imglist32.Images.SetKeyName(1, "connected-256.png");
            this.imglist32.Images.SetKeyName(2, "ok.png");
            this.imglist32.Images.SetKeyName(3, "ok1.jpg");
            this.imglist32.Images.SetKeyName(4, "ok2.png");
            this.imglist32.Images.SetKeyName(5, "ok3.png");
            this.imglist32.Images.SetKeyName(6, "questionmark.png");
            this.imglist32.Images.SetKeyName(7, "questionmark2.png");
            // 
            // imgList16
            // 
            this.imgList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList16.ImageStream")));
            this.imgList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList16.Images.SetKeyName(0, "connected-256 (1).png");
            this.imgList16.Images.SetKeyName(1, "connected-256.png");
            this.imgList16.Images.SetKeyName(2, "ok.png");
            this.imgList16.Images.SetKeyName(3, "ok1.jpg");
            this.imgList16.Images.SetKeyName(4, "ok2.png");
            this.imgList16.Images.SetKeyName(5, "ok3.png");
            this.imgList16.Images.SetKeyName(6, "questionmark.png");
            this.imgList16.Images.SetKeyName(7, "questionmark2.png");
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer3.Size = new System.Drawing.Size(749, 413);
            this.splitContainer3.SplitterDistance = 199;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picPleaseWait);
            this.groupBox2.Controls.Add(this.nupMaxListCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.chkIsActive);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLocation);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtIPAddress);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSerialNo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 199);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device Details";
            // 
            // picPleaseWait
            // 
            this.picPleaseWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPleaseWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPleaseWait.Image = global::EMASDeviceConsole.Properties.Resources.loader;
            this.picPleaseWait.Location = new System.Drawing.Point(373, 82);
            this.picPleaseWait.Name = "picPleaseWait";
            this.picPleaseWait.Size = new System.Drawing.Size(151, 111);
            this.picPleaseWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPleaseWait.TabIndex = 10;
            this.picPleaseWait.TabStop = false;
            this.picPleaseWait.Visible = false;
            // 
            // nupMaxListCount
            // 
            this.nupMaxListCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nupMaxListCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupMaxListCount.Location = new System.Drawing.Point(655, 172);
            this.nupMaxListCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupMaxListCount.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nupMaxListCount.Name = "nupMaxListCount";
            this.nupMaxListCount.Size = new System.Drawing.Size(84, 21);
            this.nupMaxListCount.TabIndex = 9;
            this.nupMaxListCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(530, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Max Messaages Count:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(267, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 34);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(140, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(13, 153);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(107, 34);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Add New";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblLastSyncedDate);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 64);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Last Synced Date";
            // 
            // lblLastSyncedDate
            // 
            this.lblLastSyncedDate.Location = new System.Drawing.Point(21, 22);
            this.lblLastSyncedDate.Name = "lblLastSyncedDate";
            this.lblLastSyncedDate.Size = new System.Drawing.Size(251, 29);
            this.lblLastSyncedDate.TabIndex = 0;
            this.lblLastSyncedDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(449, 56);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(15, 14);
            this.chkIsActive.TabIndex = 4;
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(363, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Is Active:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(449, 20);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(217, 21);
            this.txtLocation.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(366, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Location:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(87, 55);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(217, 21);
            this.txtIPAddress.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP Address:";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(88, 23);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(217, 21);
            this.txtSerialNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Serial No:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstMessages);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Console Messages";
            // 
            // lstMessages
            // 
            this.lstMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lstMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMessages.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMessages.FullRowSelect = true;
            this.lstMessages.HideSelection = false;
            this.lstMessages.Location = new System.Drawing.Point(3, 19);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(743, 188);
            this.lstMessages.TabIndex = 0;
            this.lstMessages.UseCompatibleStateImageBehavior = false;
            this.lstMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Date & Time";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Type";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Details";
            this.columnHeader8.Width = 700;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // EMASDeviceConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 462);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EMASDeviceConsole";
            this.Text = "EMAS Device Console";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EMASDeviceConsole_FormClosing);
            this.Load += new System.EventHandler(this.EMASDeviceConsole_Load);
            this.ServiceMNU.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.deviceMenus.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPleaseWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxListCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.ImageList imgList16;
        private System.Windows.Forms.ImageList imglist32;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstMessages;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblLastSyncedDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ContextMenuStrip deviceMenus;
        private System.Windows.Forms.ToolStripMenuItem mnuEditDevice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuConnectToggle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuPing;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuSyncDevice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteDevice;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.NumericUpDown nupMaxListCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.PictureBox picPleaseWait;
        private System.Windows.Forms.ContextMenuStrip ServiceMNU;
        private System.Windows.Forms.ToolStripMenuItem mnuRefreshMnu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem mnuShowMe;
        private System.Windows.Forms.ToolStripMenuItem setDeviceTieToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem uploadFingerprintsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem importAttendanceLogToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem clearDeviceLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}

