using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using System.Speech.Synthesis;
using eMAS.All_UIs.Staff_Information_FORMS;

namespace eMAS.Forms.ClaimsLeaveHirePurchase
{
    public partial class AttendanceNew : CaptureForm
    {

        IDAL dal;
        Attendance attendance;
        int attendanceId;
        IList<Employee> employees;
        SpeechSynthesizer speaker;

        private DPFP.Template template;
        private DPFP.Verification.Verification verificator;

        public AttendanceNew()
        {
            InitializeComponent();
            attendance = new Attendance();
            employees = new List<Employee>();
            speaker = new SpeechSynthesizer();
            template = new DPFP.Template();
            dal = new DAL();
            attendanceId = 0;
            dal.OpenConnection();
            searchGrid.CellClick +=new DataGridViewCellEventHandler(searchGrid_CellClick);
            nametxt.TextChanged +=new EventHandler(nametxt_TextChanged);
            staffIDtxt.TextChanged +=new EventHandler(staffIDtxt_TextChanged);
        }

        public override void CaptureForm_Load(object sender, EventArgs e)
        {
            												
        }

        public void EditAttendance(Attendance attendance)
        {
            foreach (Employee employee in employees)
            {
                if (employee.StaffID == attendance.StaffID)
                {
                    attendanceId = attendance.ID;
                    pictureBox.Image = employee.Photo;
                    staffIDtxt.Text = attendance.StaffID;
                    nametxt.Text = attendance.StaffName;
                    //gendertxt.Text = employee.Gender;
                    agetxt.Text = employee.Age;
                }
            }
            groupBox1.Enabled = true;
            searchGrid.Visible = false;
            label3.Text = "Edit Attendance";
        }

        public void Verify(DPFP.Template template)
        {
            this.template = template;
            ShowDialog();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Fingerprint Verification";
            verificator = new DPFP.Verification.Verification();		// Create a fingerprint template verificator
            UpdateStatus(0);
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            // Check quality of the sample and start verification if it's good
            // TODO: move to a separate task
            if (features != null)
            {
                // Compare the feature set with our template
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                verificator.Verify(features, template, ref result);
                UpdateStatus(result.FARAchieved);
                if (result.Verified)
                {
                   
                    try
                    {
                        Assign();
                        dal.Save(attendance);
                        pictureBox1.Image = PictureImage;
                        //MakeReport("The fingerprint was VERIFIED.");
                        speaker.Speak("congratulations, Your finger print has been verified....");
                        speaker.Speak("Your attendance date is " + dateTimePicker1.Text + " and the time is " + dateTimePicker2.Text);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                    }
                    
                }
                else
                {
                    //MakeReport("The fingerprint was NOT VERIFIED.");
                    speaker.SpeakAsync("sorry, Your finger print was not verified. Please try again....");
                    //verifiedPictureBox.Visible = false;
                    //notVerifiedPictureBox.Visible = true;
                }
            }
        }

        private void UpdateStatus(int FAR)
        {
            // Show "False accept rate" value
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #region Clear
        private void Clear()
        {
            groupBox1.Enabled = false;
            staffIDtxt.Clear();
            nametxt.Clear();
            gendertxt.Clear();
            agetxt.Clear();
            pictureBox.Image = pictureBox.InitialImage;
            label3.Text = "New Attendance";
            pictureBox1.Image = pictureBox1.InitialImage;
        }
        #endregion

        #region Assign
        private void Assign()
        {
            attendance.ID = 0;
            attendance.StaffID = staffIDtxt.Text;
            attendance.StaffName = nametxt.Text;
            attendance.AttendanceDate = DateTime.Parse(dateTimePicker1.Text);
            attendance.AttendanceTime = dateTimePicker2.Text;
        }
        #endregion

        #region Staff Operations
        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (searchGrid.CurrentRow != null)
            {
                foreach (Employee employee in employees)
                {
                    if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                    {
                        string name = employee.FirstName + (employee.MiddleName == string.Empty ? string.Empty : " " + employee.MiddleName) + " " + employee.Surname;
                        nametxt.Text = name;
                        staffIDtxt.Text = employee.StaffID;
                        gendertxt.Text = employee.Gender.ToString();
                        pictureBox.Image = employee.Photo;
                        agetxt.Text = employee.Age;
                        template.DeSerialize(new MemoryStream(employee.FingerPrint));
                        Init();
                        Start();
                        searchGrid.Visible = false;
                        speaker.SpeakAsync("Please Place your index finger on the finger print reader below");
                    }
                }
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            if (nametxt.Text.Trim() != string.Empty)
            {
                staffErrorProvider.Clear();
                searchGrid.Rows.Clear();
                searchGrid.BringToFront();
                int ctr = 0;
                bool found = false;
                foreach (Employee employee in employees)
                {
                    string name = employee.FirstName + (employee.MiddleName == string.Empty ? string.Empty : " " + employee.MiddleName) + " " + employee.Surname;
                    if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                    {
                        found = true;
                        searchGrid.Rows.Add(1);
                        searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                        searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                        ctr++;
                    }
                }
                if (found)
                {
                    if (searchGrid.RowCount == 2)
                    {
                        searchGrid.Height = searchGrid.RowCount * 24;
                    }
                    else
                    {
                        searchGrid.Height = searchGrid.RowCount * 22;
                    }
                    searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 21);
                    searchGrid.BringToFront();
                    searchGrid.Visible = true;
                }
                else
                {
                    searchGrid.Visible = false;
                }
            }
            else
            {
                Clear();
            }
        }

        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            if (staffIDtxt.Text.Trim() != string.Empty)
            {
                staffErrorProvider.Clear();
                searchGrid.Rows.Clear();
                searchGrid.BringToFront();
                int ctr = 0;
                bool found = false;
                foreach (Employee employee in employees)
                {
                    string name = employee.FirstName + (employee.MiddleName == string.Empty ? string.Empty : " " + employee.MiddleName) + " " + employee.Surname;
                    if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                    {
                        found = true;
                        searchGrid.Rows.Add(1);
                        searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                        searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                        ctr++;
                    }
                }
                if (found)
                {
                    if (searchGrid.RowCount == 2)
                    {
                        searchGrid.Height = searchGrid.RowCount * 24;
                    }
                    else
                    {
                        searchGrid.Height = searchGrid.RowCount * 23;
                    }
                    searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 21);
                    searchGrid.BringToFront();
                    searchGrid.Visible = true;
                }
                else
                {
                    searchGrid.Visible = false;
                }

            }
            else
            {
                Clear();
            }
        }
        #endregion

        private void Attendance_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            try
            {
                employees = dal.LazyLoad<Employee>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            PictureVisible = false;
            PromptVisible = false;
            StatusLineVisible = false;
            StatusTextVisible = false;
            CloseButtonVisible = false;
            groupBox1.Enabled = false;
            nametxt.Select();
        }

    }
}
