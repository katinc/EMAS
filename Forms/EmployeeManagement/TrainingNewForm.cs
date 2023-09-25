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
using HRDataAccessLayerBase;
using eMAS.Forms.SystemSetup;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class TrainingNewForm : Form
    {
        private StaffTraining staffTraining;
        private IList<Employee> employees;
        private IList<LocationType> locationTypes;
        private IList<Organizers> organizers;
        private IList<InServiceTraining> istTypes;
        private IList<TrainingType> trainingTypes;
        private IList<Sponsor> sponsors;
        private IDAL dal;
        private bool editMode;
        private int staffTrainingID;
        private int trainingID;

        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        private Company company;
        DALHelper dalHelper;
        private int ctr;


        public TrainingNewForm()
        {
            try
            {
                InitializeComponent();
                this.staffTraining = new StaffTraining();
                this.employees = new List<Employee>();
                this.istTypes = new List<InServiceTraining>();
                this.locationTypes = new List<LocationType>();
                this.organizers = new List<Organizers>();
                this.trainingTypes = new List<TrainingType>();
                this.sponsors=new List<Sponsor>();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.employees = dal.LazyLoad<Employee>();
                this.editMode = false;
                searchGrid.CellClick += new DataGridViewCellEventHandler(searchGrid_CellClick);

                this.company = new Company();
                this.dalHelper = new DALHelper();
                this.ctr = 0;

                this.trainingID = 0;
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
            this.organizers = new List<Organizers>();
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
                    cmbOrganizers.Text = value.Organisers.ToString();
                    dateTrainingDate.Value = value.TrainingDate;
                    dateStartDate.Value = value.StartDate;
                    dateEndDate.Value = value.EndDate;
                    //cmbProgramme.SelectedItem = value.CertificateAwarded.ToString();
                    //cmbCountry.Text = value.InServiceTraining.Description;
                    txtVenue.Text = value.Venue.ToString();
                   // txtOrganisers.Text = value.Organisers.ToString();
                    cmbSponsor.Text = value.Sponsor.Description;
                    txtLocationType.Text = value.LocationType;
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

        public void EditStaffTraining(StaffTraining staffTraining)
        {
            try
            {
                Clear();
                editMode = true;
                trainingID = staffTraining.ID;
                staffIDtxt.Text = staffTraining.Employee.StaffID;
                searchGrid_CellClick(this, new DataGridViewCellEventArgs(this.searchGrid.CurrentCell.ColumnIndex, this.searchGrid.CurrentRow.Index));
                cboTrainingType_DropDown(this, EventArgs.Empty);
                cboTrainingType.Text = staffTraining.TrainingType.Description;

                cmbOrganizers_DropDown(this, EventArgs.Empty);
                cmbOrganizers.Text = staffTraining.Organisers.Description.ToString();

                cboSponsor_DropDown(this, EventArgs.Empty);
                cmbSponsor.Text = staffTraining.Sponsor.Description;

                cboLocationType_DropDown(this, EventArgs.Empty);
                txtLocationType.Text = staffTraining.LocationType;

                //cmbIST_DropDown(this, EventArgs.Empty);
                ////cmbIST.Text = staffTraining.InServiceTraining.Description;

                txtCertificate.Text = staffTraining.CertificateAwarded;
                numericUpDownNumberOfDays.Value = staffTraining.Days;
                txtHours.Text = staffTraining.Hours.ToString();
                cmbProgramme.Text = staffTraining.Program;

                txtVenue.Text = staffTraining.Venue;
                dateStartDate.Text = staffTraining.StartDate.ToString();
                dateEndDate.Text = staffTraining.EndDate.ToString();

                label1.Text = "Edit Staff Training";

                var trainingAllowances = GlobalData._context.StaffTrainingAllowances.Where(u => u.TrainingID == trainingID.ToString()).ToList();
                getCostCovers();
                getCurrency();

                ctr = 0;
                gridTrainingCosts.Rows.Clear();
                foreach (var item in trainingAllowances)
                {
                    gridTrainingCosts.Rows.Add(1);
                    gridTrainingCosts.Rows[ctr].Cells["gridID"].Value = item.ID.ToString();
                    gridTrainingCosts.Rows[ctr].Cells["gridTrainingAllowanceType"].Value = item.Training_Allowance;
                    gridTrainingCosts.Rows[ctr].Cells["gridCurrency"].Value = item.Currency;
                    gridTrainingCosts.Rows[ctr].Cells["gridCost"].Value = item.Amount.ToString();
                    ctr++;
                }


            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
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

                            loadImage(employee);
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

        public void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            if (staffIDtxt.Text.Trim() != string.Empty)
            {
                if (company.ID == 0)
                {
                    company = dal.LazyLoad<Company>()[0];
                }
                if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    foreach (Employee employee in employees)
                    {
                        if (employee.Terminated == false && employee.TransferredOut == false && employee.Confirmed == true)
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
                if (editMode == true)
                {
                    staffTraining.ID = trainingID;
                }
                else
                {
                    staffTraining.ID = 0;
                }
                
                staffTraining.Employee.StaffID = staffIDtxt.Text;
                staffTraining.TrainingType.ID = Convert.ToInt32(GlobalData._context.TrainingTypes.FirstOrDefault(u => u.Description == cboTrainingType.Text).ID);
                //staffTraining.InServiceTraining.ID = Convert.ToInt32(GlobalData._context.InServiceTrainings.FirstOrDefault(u => u.Description == cmbIST.Text).ID);
                staffTraining.StartDate = dateStartDate.Value;
                staffTraining.EndDate = dateEndDate.Value;
                staffTraining.Organisers.Description = cmbOrganizers.Text;
                staffTraining.Sponsor.ID = Convert.ToInt32(GlobalData._context.TrainingSponsors.FirstOrDefault(u => u.Description == cmbSponsor.Text).id);
                staffTraining.Venue = txtVenue.Text;
                staffTraining.LocationType = txtLocationType.Text;
                staffTraining.User.ID = GlobalData.User.ID;
                staffTraining.DateEntered = DateTime.Now;
                staffTraining.Archived = false;
                staffTraining.Days = Convert.ToInt32(numericUpDownNumberOfDays.Value);
                staffTraining.CertificateAwarded = txtCertificate.Text;
                staffTraining.Hours = Convert.ToDecimal(txtHours.Text);
                staffTraining.Program = cmbProgramme.Text;

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
                cboTrainingType.DataSource = null;
                //cmbCountry.Items.Clear();
                dateTrainingDate.ResetText();
                cmbProgramme.Clear();
                dateStartDate.ResetText();
                txtCertificate.Clear();
                txtVenue.Clear();
                //txtOrganisers.Clear();
                dateEndDate.ResetText();
                cmbSponsor.DataSource = null;
                //cboLocationType.Items.Clear();
                //txtCostFee.Clear();
                //txtAccomodationFee.Clear();
                //txtTransportationFee.Clear();
                txtLocationType.Clear();

                gridTrainingCosts.Rows.Clear();
                cmbOrganizers.DataSource = null;
                txtHours.Clear();
                //cmbIST.Items.Clear();
                numericUpDownNumberOfDays.Value = 0;

                //Staff Details
                pictureBox.Image = pictureBox.InitialImage;
                //moreButton.Enabled = false;
                //searchGrid.Visible = false;
                //editMode = false;
                //label9.Text = "New Training Form";
                //pictureBox.Image = pictureBox.InitialImage;
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
                cboTrainingType.DataSource = null;
                cboTrainingType.Text = string.Empty;

                cboTrainingType.DataSource = trainingTypes;
                cboTrainingType.DisplayMember = "Description";
                cboTrainingType.ValueMember = "ID";
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
                var trainingSponsors = GlobalData._context.TrainingSponsors.ToList();
                cmbSponsor.DataSource = null;
                cmbSponsor.Text = string.Empty;

                cmbSponsor.DataSource = trainingSponsors;
                cmbSponsor.DisplayMember = "Description";
                cmbSponsor.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboLocationType_DropDown(object sender, EventArgs e)
        {
            //try
            //{
            //    locationTypes = dal.GetAll<LocationType>();
            //    cboLocationType.Items.Clear();
            //    cboLocationType.Text = string.Empty;
            //    foreach (LocationType location in locationTypes)
            //    {
            //        cboLocationType.Items.Add(location.Description);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex);
            //}
        }

        private void TrainingNewForm_Load(object sender, EventArgs e)
        {
            
            
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Enabled = getPermissions.CanAdd;
                    btnView.Enabled = getPermissions.CanView;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void moreButton_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateFields())
                {
                    UpdateStaffTrainingEntity();
                    dal.BeginTransaction();

                    if (editMode == true)
                    {
                        Update(staffTraining);
                        var allowances = GlobalData._context.StaffTrainingAllowances.Where(u => u.TrainingID == trainingID.ToString()).ToList();
                        GlobalData._context.StaffTrainingAllowances.DeleteAllOnSubmit(allowances);
                        saveTrainingAllowance();

                    }
                    else
                    {
                        trainingID = Save(staffTraining);
                        saveTrainingAllowance();
                    }

                    dal.CommitTransaction();
                    Clear();
                    MessageBox.Show("Saved successfully");
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                //throw ex;
            }
        }

        public void saveTrainingAllowance()
        {
            try
            {
                GlobalData._context.StaffTrainingAllowances.DeleteAllOnSubmit(GlobalData._context.StaffTrainingAllowances.Where(u => u.TrainingID == trainingID.ToString()));

                foreach (DataGridViewRow row in gridTrainingCosts.Rows)
                {

                    if (gridTrainingCosts.CurrentRow != null)
                    {
                        if (row.Cells["gridTrainingAllowanceType"].Value == null && row.Cells["gridCost"].Value == null && row.Cells["gridCurrency"].Value == null)
                        {
                            break;
                        }
                        else
                        {


                            var trainingAllowanceFee = new DataReference.StaffTrainingAllowance
                            {
                                StaffID = staffIDtxt.Text,
                                Training_Allowance = row.Cells["gridTrainingAllowanceType"].Value.ToString(),
                                Amount = Convert.ToDecimal(row.Cells["gridCost"].Value.ToString()),
                                Currency = row.Cells["gridCurrency"].Value == null ? "GHS" : row.Cells["gridCurrency"].Value.ToString(),
                                TrainingID = trainingID.ToString(),

                            };
                            GlobalData._context.StaffTrainingAllowances.InsertOnSubmit(trainingAllowanceFee);
                            GlobalData._context.SubmitChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        public int Save(object item)
        {

            int trainingID = 0;

            try
            {
                StaffTraining staffTraining = (StaffTraining)item;
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@StaffID", staffTraining.Employee.StaffID, DbType.String);
                //dalHelper.CreateParameter("@StaffCode", staffTraining.Employee.ID.ToString(), DbType.String);
                dalHelper.CreateParameter("@TrainingTypeID", staffTraining.TrainingType.ID, DbType.String);
                dalHelper.CreateParameter("@ISTID", staffTraining.InServiceTraining.ID, DbType.String);
                dalHelper.CreateParameter("@StartDate", staffTraining.StartDate, DbType.Date);
                dalHelper.CreateParameter("@EndDate", staffTraining.EndDate, DbType.Date);
                dalHelper.CreateParameter("@Organisers", staffTraining.Organisers.Description.ToString(), DbType.String);
                dalHelper.CreateParameter("@CertificateAwarded", staffTraining.CertificateAwarded.ToString(), DbType.String);
                dalHelper.CreateParameter("@Venue", staffTraining.Venue.ToString(), DbType.String);
                //dalHelper.CreateParameter("@CostFee", staffTraining.CostFee.ToString(), DbType.String);
                //dalHelper.CreateParameter("@AccomodationFee", staffTraining.AccomodationFee.ToString(), DbType.String);
                //dalHelper.CreateParameter("@TransportationFee", staffTraining.TransportationFee.ToString(), DbType.String);
                //dalHelper.CreateParameter("@TotalCost", staffTraining.TotalCost.ToString(), DbType.String);
                dalHelper.CreateParameter("@LocationType", staffTraining.LocationType, DbType.String);
                dalHelper.CreateParameter("@SponsorID", staffTraining.Sponsor.ID, DbType.String);
                dalHelper.CreateParameter("@UserID", staffTraining.User.ID.ToString(), DbType.String);
                dalHelper.CreateParameter("@DateEntered", staffTraining.DateEntered, DbType.DateTime);
                dalHelper.CreateParameter("@Hours", staffTraining.Hours, DbType.String);
                dalHelper.CreateParameter("@Duration", staffTraining.Days, DbType.Int32);
                dalHelper.CreateParameter("@Course", staffTraining.Program, DbType.String);

                //dalHelper.ExecuteNonQuery("Insert Into StaffTraining(StaffID,TrainingTypeID,ISTID,StartDate,EndDate,Organisers,Venue,LocationTypeID,SponsorID,UserID,DateEntered) Values(@StaffID,@TrainingTypeID,@ISTID,@StartDate,@EndDate,@Organisers,@Venue,@LocationTypeID,@SponsorID,@UserID,@DateEntered); SELECT SCOPE_IDENTITY();");

                var newRowID = dalHelper.ExecuteScalar("Insert Into StaffTraining(StaffID,TrainingTypeID,ISTID,StartDate,EndDate,Organisers,CertificateAwarded,Venue,LocationType,SponsorID,UserID,DateEntered,Hours, Duration, Course) Values(@StaffID,@TrainingTypeID,@ISTID,@StartDate,@EndDate,@Organisers,@CertificateAwarded, @Venue,@LocationType,@SponsorID,@UserID,@DateEntered, @Hours,@Duration, @Course); SELECT SCOPE_IDENTITY();");

                trainingID = Convert.ToInt32(newRowID);
                //dalHelper.ExecuteNonQuery("Insert Into StaffTraining(StaffID,StaffCode,TrainingTypeID,ISTID,StartDate,EndDate,Organisers,CertificateAwarded,Venue,CostFee,AccomodationFee,TransportationFee,TotalCost,LocationTypeID,SponsorID,UserID,DateEntered) Values(@StaffID,@StaffCode,@TrainingTypeID,@ISTID,@StartDate,@EndDate,@Organisers,@CertificateAwarded,@Venue,@CostFee,@AccomodationFee,@TransportationFee,@TotalCost,@LocationTypeID,@SponsorID,@UserID,@DateEntered)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Training entry was not saved, contact Admin");
                throw ex;
            }
            return trainingID;
        }

        public void Update(object item)
        {
            try
            {
                StaffTraining staffTraining = (StaffTraining)item;
                var updateEntity = GlobalData._context.StaffTrainings.Single(u => u.ID == staffTraining.ID);

                if (updateEntity != null)
                {
                    updateEntity.TrainingTypeID = staffTraining.TrainingType.ID;
                    updateEntity.Organisers = staffTraining.Organisers.Description;
                    updateEntity.SponsorID = staffTraining.Sponsor.ID;
                    updateEntity.LocationType = staffTraining.LocationType;
                    updateEntity.ISTID = staffTraining.InServiceTraining.ID;
                    updateEntity.Venue = staffTraining.Venue;
                    updateEntity.StartDate = staffTraining.StartDate;
                    updateEntity.EndDate = staffTraining.EndDate;
                    updateEntity.Course = staffTraining.Program;
                    updateEntity.DateEntered = staffTraining.DateEntered;

                    GlobalData._context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void cmbOrganizers_DropDown(object sender, EventArgs e)
        {
            try
            {
                var trainingOrganizers = GlobalData._context.TrainingOrganizers.ToList();
                cmbOrganizers.DataSource = null;
                cmbOrganizers.Text = string.Empty;

                cmbOrganizers.DataSource = trainingOrganizers;
                cmbOrganizers.DisplayMember = "Description";
                cmbOrganizers.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        //private void cmbIST_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        istTypes = dal.GetAll<InServiceTraining>();
        //        cmbIST.Items.Clear();
        //        cmbIST.Text = string.Empty;
        //        foreach (InServiceTraining istType in istTypes)
        //        {
        //            cmbOrganizers.Items.Add(istType.Description);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}

        private void getCostCovers() 
        {
            try
            {
                var costCovers = GlobalData._context.TrainingAllowanceTypes.Where(u=>u.Active == true).ToList();

                gridTrainingAllowanceType.DataSource = null;

                gridTrainingAllowanceType.DataSource = costCovers;
                gridTrainingAllowanceType.DisplayMember = "Description";
                gridTrainingAllowanceType.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex; 
            }

        }

        private void getCurrency()
        {
            try
            {
                var currencies = GlobalData._context.Currencies.ToList();

                    gridCurrency.Items.Clear();
                    foreach (var item in currencies)
                    {
                        gridCurrency.Items.Add(item.code);
                    }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (gridTrainingCosts.CurrentCell.ColumnIndex == 1)
                {
                    gridTrainingAllowanceType.Items.Clear();
                    getCostCovers();
                }
                else if (gridTrainingCosts.CurrentCell.ColumnIndex == 2)
                {
                    getCurrency();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw ex;
            }
        }

        private void cmbIST_DropDown(object sender, EventArgs e)
        {
            //try
            //{
            //    var ist = GlobalData._context.InServiceTrainings.ToList();

            //    cmbIST.Items.Clear();

            //    foreach (var item in ist)
            //    {
            //        cmbIST.Items.Add(item.Description);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex);
            //    throw ex;
            //}
        }

        private void cboTrainingType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool ValidateFields()
        {
            bool result = true;

            try
            {
                staffErrorProvider.Clear();

                foreach (DataGridViewRow row in gridTrainingCosts.Rows)
                {
                    if (row.Cells["gridTrainingAllowanceType"].Value == null && row.Cells["gridCost"].Value == null && row.Cells["gridCurrency"].Value == null)
                    {
                        break;
                    }
                    else
                    {
                        if (row.Cells["gridTrainingAllowanceType"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please select Training Allowance Type on row " + (row.Index + 1));
                        }

                        if (row.Cells["gridCost"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter Allowance Amount Type on row " + (row.Index + 1));
                        }

                        //if (row.Cells["gridCurrency"].Value == null)
                        //{
                        //    result = false;
                        //    staffErrorProvider.SetError(groupBox2, "Please select Currency on row " + (row.Index + 1));
                        //}
                    }
                }
                

                if (staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter The StaffID");
                }
                if (cboTrainingType.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboTrainingType, "Please select a training type");
                }
                if (dateStartDate.Value.Date > dateEndDate.Value.Date)
                {
                    result = false;
                    staffErrorProvider.SetError(dateStartDate, "The start date of the training cannot be greater than the end date");
                }
                //if (numericUpDownNumberOfDays.Value <= 0)
                //{
                //    result = false;
                //    staffErrorProvider.SetError(numericUpDownNumberOfDays, "Number Of Days Cannot be Zero");
                //}
                if (numericUpDownNumberOfDays.Value <= 0 )
                {
                    result = false;
                    staffErrorProvider.SetError(numericUpDownNumberOfDays, "Number of days cant not be less than or equal to 0");
                }
                if (cmbSponsor.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cmbSponsor, "Please select a sponsor type");
                }
                //if (cboLocationType.Text.Trim() == string.Empty)
                //{
                //    result = false;
                //    staffErrorProvider.SetError(cboLocationType, "Please select a location");
                //}
                if (cmbOrganizers.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cmbOrganizers, "Please select an organizer");
                }
                if (txtHours.Text == string.Empty || txtHours.Text == null)
                {
                    result = false;
                    staffErrorProvider.SetError(txtHours, "Please enter a valid hours per day");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return result;
        }

        private void cmbProgramme_DropDown(object sender, EventArgs e)
        {
            //try
            //{
            //    var trainingPrograms = GlobalData._context.SponsoredCertProgrammesGroups.ToList();
            //    cmbProgramme.Items.Clear();
            //    cmbProgramme.Text = string.Empty;
            //    foreach (var program in trainingPrograms)
            //    {
            //        cmbProgramme.Items.Add(program.programme);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex);
            //}
        }

        private void btnTrainingAllowanceType_Click(object sender, EventArgs e)
        {
            try
            {
                TrainingAllowanceTypeForm TrainingSponsorsForm = new TrainingAllowanceTypeForm();
                TrainingSponsorsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void loadImage(Employee employee)
        {
            try
            {
                employee = dal.ShowImageByStaffID<Employee>(employee);
                if (employee.Photo != null)
                {
                    pictureBox.Image = employee.Photo;
                }
                else
                {
                    MessageBox.Show("Image is not uploaded for the Staff");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
    }
}
