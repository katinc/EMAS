using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;
using HRBussinessLayer.Validation;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class TrainingNewForm : Form
    {
        private StaffTraining staffTraining;
        private IList<Employee> employees;
        private IList<LocationType> locationTypes;
        private IList<InServiceTraining> istTypes;
        private IList<TrainingType> trainingTypes;
        private IList<Sponsor> sponsors;
        private IDAL dal;
        private bool editMode;
        private int staffTrainingID;

        public TrainingNewForm()
        {
            try
            {
                InitializeComponent();
                this.staffTraining = new StaffTraining();
                this.employees = new List<Employee>();
                this.istTypes = new List<InServiceTraining>();
                this.locationTypes = new List<LocationType>();
                this.trainingTypes = new List<TrainingType>();
                this.sponsors=new List<Sponsor>();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.employees = dal.LazyLoad<Employee>();
                this.editMode = false;
                searchGrid.CellClick += new DataGridViewCellEventHandler(searchGrid_CellClick);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public TrainingNewForm(string staffID)
        {
            InitializeComponent();
            this.staffTraining = new StaffTraining();
            this.employees = new List<Employee>();
            this.istTypes = new List<InServiceTraining>();
            this.locationTypes = new List<LocationType>();
            this.trainingTypes = new List<TrainingType>();
            this.sponsors = new List<Sponsor>();
            this.dal = new DAL();
            this.dal.OpenConnection();
            this.employees = dal.LazyLoad<Employee>();
            this.editMode = true;
            searchGrid.CellClick += new DataGridViewCellEventHandler(searchGrid_CellClick);
            
            foreach (Employee employee in employees)
            {
                if (employee.StaffID.Trim() == staffID.Trim())
                {
                    string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                    nametxt.Text = name;
                    staffIDtxt.Text = employee.StaffID;
                    gendertxt.Text = employee.Gender;
                    pictureBox.Image = employee.Photo;
                    agetxt.Text = employee.Age;
                    searchGrid.Visible = false;
                    moreButton.Enabled = true;
                    groupBox2.Enabled = true;
                    bool found = false;
                    foreach (StaffTraining staffTraining in dal.GetAll<StaffTraining>())
                    {
                        if (staffTraining.Employee.StaffID.Trim() == staffID.Trim())
                        {
                            StaffTraining = staffTraining;
                            found = true;
                            groupBox1 .Enabled  = true;
                            groupBox2.Enabled = true;
                        }
                    }
                    if (!found)
                    {
                        staffTraining = new StaffTraining();
                    }
                }
            }
        }


        public StaffTraining StaffTraining
        {
            set
            {
                try
                {
                    this.staffTrainingID = value.ID;
                    staffIDtxt.Text = value.Employee.StaffID.ToString();
                    nametxt.Text = value.Employee.Surname.ToString() + " " + value.Employee.FirstName + "" + value.Employee.OtherName;
                    gendertxt.Text = value.Employee.Gender.ToString();
                    agetxt.Text = value.Employee.Age.ToString();
                    cboTrainingType.Text = value.TrainingType.Description.ToString();
                    dateTrainingDate.Value = value.TrainingDate;
                    dateStartDate.Value = value.StartDate;
                    dateEndDate.Value = value.EndDate;
                    txtCertificateAwarded.Text = value.CertificateAwarded.ToString();
                    cboIST.Text = value.InServiceTraining.Description;
                    txtVenue.Text = value.Venue.ToString();
                    txtOrganisers.Text = value.Organisers.ToString();
                    cboSponsor.Text = value.Sponsor.Description;
                    cboLocationType.Text = value.LocationType.Description;
                    searchGrid.Visible = false;
                    moreButton.Enabled = true;
                    groupBox2.Enabled = true;
                    editMode = true;
                    label9.Text = "Edit Staff Training";
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID == value.Employee.StaffID)
                        {
                            if (employee.Photo != null)
                            {
                                pictureBox.Image = employee.Photo;
                                gendertxt.Text = employee.Gender;
                                agetxt.Text = employee.Gender;
                            }
                            else
                            {
                                pictureBox.Image = pictureBox.InitialImage;
                            }
                        }
                    }
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != value.User.ID)
                    {
                        btnSave.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    throw ex;
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                TrainingViewForm viewForm = new TrainingViewForm(dal, this);
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            gendertxt.Text = employee.Gender;
                            pictureBox.Image = employee.Photo;
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            moreButton.Enabled = true;
                            groupBox2.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Staff Operations
        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
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
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
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
                            searchGrid.Height = searchGrid.RowCount * 23;
                        }
                        searchGrid.Location = new Point(178, 39);
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
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
                    string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
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
                    searchGrid.Location = new Point(178, 59);
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

        #region ASSINGNMENTS
        private void UpdateStaffTrainingEntity()
        {
            try
            {
                Validator.Errors.Clear();
                staffTraining.ID = 0;
                staffTraining.Employee.StaffID = staffIDtxt.Text;
                staffTraining.Employee.StaffID = nametxt.Text;
                staffTraining.TrainingType.Description = cboTrainingType.Text;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            try
            {
                staffTrainingID = 0;
                staffIDtxt.Clear();
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                cboTrainingType.Items.Clear();
                cboIST.Items.Clear();
                dateTrainingDate.ResetText();
                cboCourse.Items.Clear();
                dateStartDate.ResetText();
                txtCertificateAwarded.Clear();
                txtVenue.Clear();
                txtOrganisers.Clear();
                dateEndDate.ResetText();
                cboSponsor.Items.Clear();
                cboLocationType.Items.Clear();
                txtCostFee.Clear();
                txtAccomodationFee.Clear();
                txtTransportationFee.Clear();

                //Staff Details
                pictureBox.Image = pictureBox.InitialImage;
                moreButton.Enabled = false;
                searchGrid.Visible = false;
                editMode = false;
                label9.Text = "New Training Form";
                pictureBox.Image = pictureBox.InitialImage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                this.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboTrainingType_DropDown(object sender, EventArgs e)
        {
            try
            {
                trainingTypes = dal.GetAll<TrainingType>();
                cboTrainingType.Items.Clear();
                cboTrainingType.Text = string.Empty;
                foreach (TrainingType trainingType in trainingTypes)
                {
                    cboTrainingType.Items.Add(trainingType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboIST_DropDown(object sender, EventArgs e)
        {
            try
            {
                istTypes = dal.GetAll<InServiceTraining>();
                cboIST.Items.Clear();
                cboIST.Text = string.Empty;
                foreach (InServiceTraining istType in istTypes)
                {
                    cboIST.Items.Add(istType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboSponsor_DropDown(object sender, EventArgs e)
        {
            try
            {
                sponsors = dal.GetAll<Sponsor>();
                cboSponsor.Items.Clear();
                cboSponsor.Text = string.Empty;
                foreach (Sponsor sponsor in sponsors)
                {
                    cboSponsor.Items.Add(sponsor.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboLocationType_DropDown(object sender, EventArgs e)
        {
            try
            {
                locationTypes = dal.GetAll<LocationType>();
                cboLocationType.Items.Clear();
                cboLocationType.Text = string.Empty;
                foreach (LocationType location in locationTypes)
                {
                    cboLocationType.Items.Add(location.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void TrainingNewForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

    }
}
