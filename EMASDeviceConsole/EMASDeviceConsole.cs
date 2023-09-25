using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using EMASDeviceConsole.Libs;
using System.IO; 

namespace EMASDeviceConsole
{
    public partial class EMASDeviceConsole : Form
    {
        private int DeviceID = 0;
        private Monitor m = new Monitor();
        //private SqlConnection con = new Libs.DBLib();

        LogManager l = new LogManager();
        private FileSystemWatcher logMonitor;
        private DateTime _changedtime, _logged;
        private long LogLine = 0;
        //private string mode = "ALL";

        delegate void ThreadSafeListView();
        public static List<Device> ImportDeviceQueue = new List<Device>();
        public static List<Device> UploadDeviceQueue = new List<Device>();

        public EMASDeviceConsole()
        {
            InitializeComponent();
            fillDevices();
            monitorLog();
        }

        private void monitorLog()
        {
            try
            {              
                l.RowSize = Convert.ToInt32(nupMaxListCount.Value);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                // this.SetStyle(ControlStyles.UserPaint, true);
                // this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                initWatcher();
                displayLog();
                //lblCount.Text = "List Count: " + lstView.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private DateTime Changedtime
        {
            get { return _changedtime; }
            set { _changedtime = value; }
        }

        private DateTime Logged
        {
            get { return _logged; }
            set { _logged = value; }
        }

               

        private void updateDevicesConnectionStatus()
        {
            if (lstView.InvokeRequired)
            {
                ThreadSafeListView safe = new ThreadSafeListView(updateDevicesConnectionStatus);
                this.Invoke(safe);
                //updateDevicesConnectionStatus();
            }

            foreach (ListViewItem itm in lstView.Items)
            {
                
                if (Convert.ToBoolean(itm.SubItems[2].Text))
                {

                    Device dev = Monitor.Devices.Find(d => d.DeviceID == Int32.Parse(itm.SubItems[3].Text));

                    if (null != dev && dev.DeviceID > 0)
                    {
                        if (dev.Connected)
                        {
                            itm.ImageIndex = 0;
                        }
                        else
                        {
                            itm.ImageIndex = 1;
                        }
                    }
                }
                else
                {
                    itm.ImageIndex = 1;
                }
                
            }
        }
        private void initWatcher()
        {
            try
            {
                logMonitor = new FileSystemWatcher(l.LogFolder, LogManager.getlogName());
                logMonitor.InternalBufferSize = 140000;
                logMonitor.SynchronizingObject = this;
                logMonitor.EnableRaisingEvents = true;
                logMonitor.IncludeSubdirectories = false;
                logMonitor.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Attributes;
                logMonitor.Changed += new FileSystemEventHandler(LogChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                Changedtime = DateTime.Now;
                //logMonitor.
                displayLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void nupMaxListCount_ValueChanged(object sender, EventArgs e)
        {
            l.RowSize = Convert.ToInt32(nupMaxListCount.Value);
        }


        public void Trace()
        {
            if (!l.IsLogging)
                return;

            if (lstMessages.InvokeRequired)
            {
                ThreadSafeListView safe = new ThreadSafeListView(Trace);
                this.Invoke(safe);
            }

            string[] line;
            ListViewItem lst;

            Application.DoEvents();
            if (Logged <= Changedtime)
            {
                //lstMessages.Items.Clear();
                lstMessages.BeginUpdate();
                try
                {
                    using (FileStream log = new FileStream(l.LogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader streamReader = new StreamReader(log))
                        {
                            int currCount = 0;
                            while (!streamReader.EndOfStream)
                            {

                                line = streamReader.ReadLine().Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                currCount++;
                                if (currCount >= LogLine)
                                {
                                    if (line.Length > 0)
                                    {
                                        if (line[0].StartsWith("_"))
                                        {
                                            lst = lstMessages.Items.Add("**********************");
                                            lst.SubItems.Add("*****************");
                                            lst.SubItems.Add("*****************************************************");

                                        }
                                        else
                                        {
                                            if (line.Length > 2)
                                            {
                                                lst = lstMessages.Items.Add(line[0], l.getImageID(line[1]));

                                                lst.SubItems.Add(line[1]);
                                                lst.SubItems.Add(line[2]);
                                                l.setBackColor(lst, line[1]);
                                            }
                                            else
                                            {
                                                lst = lstMessages.Items.Add(line[0], 2);
                                                lst.SubItems.Add(line[0]);
                                            }
                                        }

                                        LogLine++;
                                        if (lstMessages.Items.Count > l.RowSize)
                                        {
                                            lstMessages.Items.RemoveAt(0);
                                        }

                                        lstMessages.Items[lstMessages.Items.Count - 1].EnsureVisible();
                                    }
                                }
                            }

                            //this.textBoxLogs.Text = streamReader.ReadToEnd();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lst = lstMessages.Items.Add(DateTime.Now + " (" + DateTime.Now.Millisecond + ")", l.getImageID("Error"));
                    lst.SubItems.Add("Error"); lst.SubItems.Add(ex.Message);
                    l.setBackColor(lst, "Error");
                }

                Logged = DateTime.Now;
                //lblUpdated.Text = "Last Updated:" + DateTime.Now.ToString();
                lstMessages.EndUpdate();
            }
            Application.DoEvents();
            //lblCount.Text = "List Count: " + lstMessages.Items.Count.ToString();
        }



        private void displayLog()
        {

            Trace();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            AddNew();

        }

        private void AddNew()
        {
            txtIPAddress.Text = "";
            txtSerialNo.Text = "";
            txtLocation.Text = "";
            chkIsActive.Checked = false;
            lblLastSyncedDate.Text = "";
            DeviceID = 0;
        }


        private void fillDevices()
        {

            string sql = "SELECT * FROM AttendanceDevices ";

            using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader rs = command.ExecuteReader();

                    lstView.Items.Clear();
                    ListViewItem lstItm;
                    while (rs.Read())
                    {
                        lstItm = lstView.Items.Add(Convert.ToString(rs.GetValue(2)));
                        lstItm.SubItems.Add(rs.GetString(3));
                        lstItm.SubItems.Add(Convert.ToString(rs.GetBoolean(5)));
                        if (!rs.IsDBNull(8))
                        {
                            lstItm.SubItems.Add(rs.GetString(8));
                        }
                        lstItm.SubItems.Add(rs.GetInt32(0).ToString());
                        lstItm.ToolTipText = rs.GetBoolean(5) ? "Device is Active" : "Device is Disabled";
                        if (Convert.ToBoolean(rs["CurrentStatus"]))
                        {
                            lstItm.ImageIndex = 0;
                        }
                        else
                        {
                            lstItm.ImageIndex = 1;
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DeviceID == 0)
            {
                string sql = "INSERT INTO AttendanceDevices(SerialNo,Location,IPAddress,IsActive,DateCreated,UserID) ";
                sql = sql + " values(@SerialNo,@Location,@IPAddress,@IsActive,@DateCreated,@UserID)";


                using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@SerialNo", txtSerialNo.Text);
                    command.Parameters.AddWithValue("@Location", txtLocation.Text);
                    command.Parameters.AddWithValue("@IPAddress", txtIPAddress.Text);
                    command.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                    command.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                    command.Parameters.AddWithValue("@UserID", Configs.UserID);

                    try
                    {
                        connection.Open();
                        Int32 rowsAffected = command.ExecuteNonQuery();
                        fillDevices();                        
                        MessageBox.Show(string.Format("RowsAffected: {0}", rowsAffected));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                string sql = "UPDATE AttendanceDevices SET SerialNo=@SerialNo,Location=@Location,IPAddress=@IPAddress,IsActive=@IsActive ";
                sql = sql + " WHERE ID="+ DeviceID ;

                using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@SerialNo", txtSerialNo.Text);
                    command.Parameters.AddWithValue("@Location", txtLocation.Text);
                    command.Parameters.AddWithValue("@IPAddress", txtIPAddress.Text);
                    command.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                    

                    try
                    {
                        connection.Open();
                        Int32 rowsAffected = command.ExecuteNonQuery();
                        fillDevices();
                        AddNew();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            updateDevicesConnectionStatus();
        }

        private void mnuEditDevice_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                DeviceID = Convert.ToInt32( lstView.SelectedItems[0].SubItems[3].Text );
                if (DeviceID > 0)
                {
                    fillForm();
                }
            }
        }

        private void fillForm()
        {
            string sql = "SELECT * FROM AttendanceDevices  where ID=" + DeviceID;

            using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader rs = command.ExecuteReader();

                    while (rs.Read())
                    {
                        txtIPAddress.Text = rs["IPAddress"].ToString();
                        txtLocation.Text = rs["Location"].ToString();
                        txtSerialNo.Text = rs["SerialNo"].ToString();
                        chkIsActive.Checked = Convert.ToBoolean(rs["IsActive"].ToString());
                        lblLastSyncedDate.Text = rs["LastSynced"].ToString();


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private Device  GetDevice(int DevID)
        {
            Device d = new Device();
            string sql = "SELECT * FROM AttendanceDevices  where ID=" + DevID;

            using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader rs = command.ExecuteReader();

                    while (rs.Read())
                    {
                        d.DeviceID = Convert.ToInt32(rs["ID"]);
                        d.IPAddress = rs["IPAddress"].ToString();
                        d.Port = Convert.ToInt32(rs["Port"].ToString());
                        d.Location = rs["Location"].ToString();
                        d.SerialNo = rs["SerialNo"].ToString();
                        d.IsActive = Convert.ToBoolean(rs["IsActive"].ToString());

                        if (DBNull.Value != rs["LastSynced"])
                        {
                            d.LastSynced = Convert.ToDateTime(rs["LastSynced"]);
                        }

                        if (DBNull.Value != rs["CurrentStatus"])
                        {
                            d.Status = Convert.ToBoolean(rs["CurrentStatus"].ToString());
                        }

                        if (DBNull.Value != rs["StatusDate"])
                        {
                            d.StatusDate = Convert.ToDateTime(rs["StatusDate"].ToString());
                        } 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return d;
        }

        private void EMASDeviceConsole_Load(object sender, EventArgs e)
        {
            m.work();
            updateDevicesConnectionStatus();

            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }

        }

        private void mnuPing_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                if (new DeviceManager().PingDevice(lstView.SelectedItems[0].SubItems[1].Text))
                {
                    MessageBox.Show("Device is reachable");
                }
                else
                {
                    MessageBox.Show("Device cannot be reached");
                }
                
            }

        }

        private void mnuConnectToggle_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                picPleaseWait.Visible = true;
                Application.DoEvents();
                if (mnuConnectToggle.Text == "Connect")
                {
                    m.AttemptConnection(GetDevice(Int32.Parse(lstView.SelectedItems[0].SubItems[3].Text)));
                }
                else
                {
                    m.AttemptDisConnection(GetDevice(Int32.Parse(lstView.SelectedItems[0].SubItems[3].Text)));
                }

                Application.DoEvents();
                updateDevicesConnectionStatus();
                Cursor = Cursors.Default;
                picPleaseWait.Visible = false;
                Application.DoEvents();
            }
        }

        private void lstView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                if (Convert.ToBoolean(lstView.SelectedItems[0].ImageIndex == 0))
                {
                    mnuConnectToggle.Text = "Disconnect";
                    setDeviceTieToolStripMenuItem.Enabled  = true;
                }
                else
                {
                    mnuConnectToggle.Text = "Connect";
                    setDeviceTieToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void mnuDeleteDevice_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete?","Confirm Action",MessageBoxButtons.YesNo ,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (mnuConnectToggle.Text == "Disconnect")
                    {
                        m.AttemptDisConnection(GetDevice(Int32.Parse(lstView.SelectedItems[0].SubItems[3].Text)));
                    }

                    if (deleteDevice(Int32.Parse(lstView.SelectedItems[0].SubItems[3].Text)))
                    {
                        lstView.SelectedItems[0].Remove();
                    }
                    else
                    {
                        MessageBox.Show("Sorry Could not delete the device from DB");
                    }
                   
                }
                
            }
        }

        private bool  deleteDevice(int DevID)
        {
            bool status = false;
            string sql = " delete FROM AttendanceDevices  where ID=" + DevID;

            using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    int i = command.ExecuteNonQuery ();
                    if (i > 0)
                        status = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return status;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fillDevices();
            updateDevicesConnectionStatus();
        }
               

        private void mnuShowMe_Click(object sender, EventArgs e)
        {
            if (mnuShowMe.Text == "Hide")
            {
                this.Hide();
                mnuShowMe.Text = "Show";
            }
            else
            {
                this.Show();
                mnuShowMe.Text = "Hide";
            }
           
        }

        private void mnuSyncDevice_Click(object sender, EventArgs e)
        {

          
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            DBLib lib = new DBLib();

            LogManager.Log("Background Activity Manager started");
          
            //worker.ReportProgress(1);

            while (true)
            {

                if (worker.CancellationPending == true)
                {
                    LogManager.Log("Background Activity Manager has been stopped");
                    e.Cancel = true;
                    break;
                }
                else
                {
                    foreach (Device div in Monitor.Devices)
                    {
                        LogManager.Log("Background Activity Manager: Checking Connection state of "+div.IPAddress );
                        if (div.Connected)
                        {
                            LogManager.Log("Background Activity Manager: Connected");
                            DataTable tbl = lib.getDeviceTempsToSync(div.DeviceID);
                            LogManager.Log("Background Activity Manager: " + tbl.Rows.Count + " Fingerprints to sync");
                            foreach (DataRow row in tbl.Rows)
                            {
                                if(!string.IsNullOrEmpty(row["StaffMainID"].ToString()))
                                {
                                    FingerprintTemplate temp = new FingerprintTemplate();
                                    temp.ID = Convert.ToInt64(row["ID"]);
                                    temp.FingerType = Convert.ToInt32(row["FingerType"]);
                                    temp.Name = string.Format("{0} {1} {2}", row["Firstname"].ToString(), row["Surname"].ToString(), row["OtherName"].ToString());
                                    temp.StaffID = row["StaffID"].ToString();
                                    temp.Template = row["Template"].ToString();
                                    temp.TempLen = Convert.ToInt32(row["TempLen"]);
                                    temp.Flag = Convert.ToInt32(row["Flag"]);
                                    temp.UserID = Convert.ToInt32(row["UserID"]);
                                    temp.StaffMainID = Convert.ToInt32(row["StaffMainID"].ToString());

                                    temp.UserType = row["UserType"].ToString();

                                    if (div.UploadTemplate(temp))
                                    {
                                        lib.StaffMainID = Convert.ToInt32(row["StaffMainID"].ToString());
                                        lib.UserType = row["UserType"].ToString();
                                        lib.insertSyncData(temp, div.DeviceID);
                                    }
                                }
                             
                            }

                            tbl = lib.getDeviceSyncToUpdate(div.DeviceID);
                            LogManager.Log("Background Activity Manager: " + tbl.Rows.Count + " Fingerprints to Delete");
                            foreach (DataRow row in tbl.Rows)
                            {
                                if (div.DeleteTemplate(row["StaffID"].ToString(), Convert.ToInt32(row["FingerIndex"])))
                                {
                                    LogManager.Log("Background Activity Manager: " + row["StaffID"].ToString() + ":  Fingerprint Deleted on Device");

                                    if (lib.UpdateSyncData(Convert.ToInt32(row["DeviceID"]), Convert.ToInt64(row["TemplateID"])))
                                    {
                                        LogManager.Log("Background Activity Manager: " + row["StaffID"].ToString() + ":  Fingerprint Deletion updated in DB");
                                    }
                                }
                                else
                                {
                                       LogManager.Log("Background Activity Manager: " + row["StaffID"].ToString() + ":  Fingerprint could not be deleted on Device",LogManager.LogType.WARNING);
                                }
                            }

                        }
                        else
                        {
                            LogManager.Log("Background Activity Manager: Not Connected",LogManager.LogType.WARNING);
                        }

                    }

                    System.Threading.Thread.Sleep(10000);
                    // worker.ReportProgress(i * 10);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void setDeviceTieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                if (m.SetDeviceTime(GetDevice(Int32.Parse(lstView.SelectedItems[0].SubItems[3].Text))))
                {
                    MessageBox.Show("Device date and time set successfully");
                }
                else
                {
                    MessageBox.Show("Device cannot be reached");
                }

            }
        }

        private void uploadFingerprintsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                UploadDeviceQueue.Add(GetDevice(Int32.Parse(lstView.SelectedItems[0].SubItems[3].Text)));
                if (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync();
                }
               
            }
        }

        private void importAttendanceLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                ImportDeviceQueue.Add(GetDevice(Int32.Parse(lstView.SelectedItems[0].SubItems[3].Text)));
                if (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync();
                }

            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < UploadDeviceQueue.Count;)
            {
                m.SyncDevice(UploadDeviceQueue[i]);
                UploadDeviceQueue.RemoveAt(i);
            }

            for (int i = 0; i < ImportDeviceQueue.Count; )
            {
                m.ImportLog(ImportDeviceQueue[i]);
                ImportDeviceQueue.RemoveAt(i);
            }
        }

        private void clearDeviceLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to Clear attendance log on the selected device?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    picPleaseWait.Visible = true;
                    Application.DoEvents();

                    if (GetDevice(Int32.Parse(lstView.SelectedItems[0].SubItems[3].Text)).ClearLog())
                    {
                        Application.DoEvents();                    
                        Cursor = Cursors.Default;
                        picPleaseWait.Visible = false;
                        Application.DoEvents();

                        MessageBox.Show("Logs cleared successfully");
                    }
                    else
                    {
                        Application.DoEvents();
                        Cursor = Cursors.Default;
                        picPleaseWait.Visible = false;
                        Application.DoEvents();
                        MessageBox.Show("Error. Could not clear attendance logs");
                    }

                }

            }
        }

        private void mnuRefreshMnu_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void EMASDeviceConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure? We will not be able to moniter EMAS attendance devices again", "EMAS Device Console",
         MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }
    }
}
