using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using Microsoft.VisualBasic;
using HRDataAccessLayer.Staff_Info_Data_Control;
using eMAS.Forms.Reports;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ExternalTrainingForm : Form
    {
       private QualificationDataMapper qualificationMapper;
      private  IList<Qualification> lstQualifications;

       private CountryDataMapper countryMapper;
       private IList<Country> lstCountries;
       private AttendedSchoolDataMapper attenSchoolMapper;
       private IList<AttendedSchool> lstAttendedSchool;
       private IList<TrainingOrganizer> lstTrainingOrganizers;
       private IList<TrainingSponsor> lstTrainingSponsors;
       private TrainingOrganizersDataMapper trainingOrganizerDataMapper;
       private TrainingSponsorDataMapper trainingSponsorDataMapper;
       private CompanyDataMapper companyDataMapper;
       private Company company;
       private IDAL dal;
       private IList<Employee> employees;

       private DALHelper dalHelper;
       private ExternalTraining externalTraining;
       private bool editMode;

       private WorkshopDataMapper workshopDataMapper;
       private IList<Workshop> lstWorkshops;

       private bool CanEdit;
       private bool CanAdd;
       private bool CanDelete;
       private bool CanPrint;
       private bool CanView;

        
        public ExternalTrainingForm()
        {
            InitializeComponent();
            qualificationMapper = new QualificationDataMapper();
            lstQualifications = new List<Qualification>();
            countryMapper = new CountryDataMapper();
            lstCountries = new List<Country>();
            attenSchoolMapper = new AttendedSchoolDataMapper();
            lstAttendedSchool = new List<AttendedSchool>();
            lstTrainingOrganizers = new List<TrainingOrganizer>();
            lstTrainingSponsors = new List<TrainingSponsor>();
            trainingOrganizerDataMapper = new TrainingOrganizersDataMapper();
            trainingSponsorDataMapper = new TrainingSponsorDataMapper();
            dal = new DAL();
            employees = new List<Employee>();
            dalHelper = new DALHelper();
            this.externalTraining = new ExternalTraining();
            this.editMode = false;
            this.workshopDataMapper = new WorkshopDataMapper();
            this.lstWorkshops = new List<Workshop>();
        }

        private void cmbQualification_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstQualifications = qualificationMapper.GetAllASRaw();
                cmbQualification.Items.Clear();
                foreach (var Row in lstQualifications)
                {
                    cmbQualification.Items.Add(Row.CertificateObtained);
                }
            }
            catch (Exception e1) { }
         
        }

        private void cmbCountry_DropDown(object sender, EventArgs e,IList<Country> NewLstCountries)
        {
            try
            {
                if (NewLstCountries == null)
                lstCountries = countryMapper.GetAll();
                else
                lstCountries = NewLstCountries;
                cmbCountry.Items.Clear();
                foreach (var Row in lstCountries)
                {
                    
                    cmbCountry.Items.Add(Row.Description);
                }
            }
            catch (Exception e1) { }
        }

        private void cmbCountry_DropDown(object sender, EventArgs e)
        {
            if (radInCountry.Checked == true)
                LocationType_Changed(sender, e);
            else
            {
                try
                {

                    lstCountries = countryMapper.GetAll().Where(r=>r.Description.ToUpper()!="GHANA").ToList();

                    cmbCountry.Items.Clear();
                    foreach (var Row in lstCountries)
                    {
                       
                        cmbCountry.Items.Add(Row.Description);
                    }
                }
                catch (Exception e1) { }
            }
           
        }

        private void cmbSchool_SelectedIndexChangedCommited(object sender, EventArgs e)
        {
            AttendedSchool school=null;
            try
            {
                if (lstAttendedSchool.Count==1)
                    school = attenSchoolMapper.getById(lstAttendedSchool[0].Id);
                else
                school = attenSchoolMapper.getById(lstAttendedSchool[cmbSchool.SelectedIndex].Id);
               
            }
            catch (Exception e1) { }

            if (school != null)
                txtVenue.Text = school.Location;
            else
                txtVenue.Clear();
        }

        private void cmbSchool_DropDown(object sender, EventArgs e)
        {   cmbSchool.Items.Clear();
            try
            {
                lstAttendedSchool.Clear();
             
                lstAttendedSchool = attenSchoolMapper.getByCountryId(lstCountries[cmbCountry.SelectedIndex].ID);
                foreach (var school in lstAttendedSchool)
                {
                    cmbSchool.Items.Add(school.Description);
                }
            }
            catch (Exception e1) { }
        }
        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string StaffID = employee.StaffID;
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
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
                        searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 22);
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

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {

                    Clear();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;

                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;

                          

                          

                            selectedEmployee = dal.ShowImageByStaffID<Employee>(employee);
                            pictureBox.Image = selectedEmployee.Photo;
                            fillWorkshops();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
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
                    employees = dal.LazyLoad<Employee>();
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
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 22);
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

       
        private void cmbOrganizers_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbOrganizers.Items.Clear();
                lstTrainingOrganizers = trainingOrganizerDataMapper.getAll(true);
                foreach (var item in lstTrainingOrganizers)
                {
                    cmbOrganizers.Items.Add(item.Description);
                }
            }
            catch (Exception e1) { }
          
        }

        private void cmbSponsor_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbSponsor.Items.Clear();
                lstTrainingSponsors = trainingSponsorDataMapper.getAll(true);
                foreach (var item in lstTrainingSponsors)
                {
                    cmbSponsor.Items.Add(item.Description);
                }
            }
            catch (Exception e1) { }
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            staffIDtxt.Clear();
            nametxt.Clear();
            dateTrainingDate.ResetText();
            cmbQualification.SelectedIndex = -1;
            cmbQualification.Text = string.Empty;
            dateStartDate.ResetText();
            dateEndDate.ResetText();
            txtCostFee.Clear();
            txtAccomodationFee.Clear();
            txtTransportationFee.Clear();
            cmbOrganizers.SelectedIndex = -1;
            cmbOrganizers.Text = string.Empty;
            cmbSponsor.SelectedIndex = -1;
            cmbSponsor.Text = string.Empty;
            cmbCountry.SelectedIndex = -1;
            cmbCountry.Text = string.Empty;
            cmbSchool.SelectedIndex = -1;
            cmbSchool.Text = string.Empty;
            txtVenue.Clear();
            editMode = false;
            LocationType_Changed(this, EventArgs.Empty);
            gridWorkshops.Rows.Clear();
            pictureBox.Image = null;
            gendertxt.Clear();
            agetxt.Clear();
        }
        bool inCountry = true;
        private int ctr;
        private int staffCode;
        public Employee selectedEmployee;
        private void LocationType_Changed(object sender, EventArgs e)
        {
            if (radInCountry.Checked == true){
                inCountry = true;
                //cmbCountry.Enabled = false;
                lstCountries.Clear();
                lstCountries.Add(countryMapper.GetByName("Ghana"));
            }
            
            else{
                inCountry = false;
            }
            cmbCountry_DropDown(sender, e,lstCountries);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string error = string.Empty;
                if (staffIDtxt.Text == string.Empty)
                {
                    error = "Staff ID Is Required!";
                    staffErrorProvider.SetError(staffIDtxt, error);
                }
                else if (dateEndDate.Value < dateStartDate.Value)
                {
                    error = "Training End Date Cannot Be Less Than The Start Date";
                    staffErrorProvider.SetError(dateStartDate, error);
                }
                else if (!Information.IsNumeric(txtCostFee.Text))
                {
                    error = "Cost Should Be Numeric";
                    staffErrorProvider.SetError(txtCostFee, error);
                }
                else if (!Information.IsNumeric(txtAccomodationFee.Text))
                {
                    error = "Accomodation Fee Should Be Numeric";
                    staffErrorProvider.SetError(txtAccomodationFee, error);
                }
                else if (!Information.IsNumeric(txtTransportationFee.Text))
                {
                    error = "Transportation Fee Should Be Numeric";
                    staffErrorProvider.SetError(txtTransportationFee, error);
                }
                else if (!Information.IsNumeric(txtCost.Text))
                {
                    error = "Totals Cost Should Be Numeric";
                    staffErrorProvider.SetError(txtCost, error);
                }
                else if (cmbOrganizers.SelectedItem == null)
                {
                    error = "Organizer Is Required!";
                    staffErrorProvider.SetError(cmbOrganizers, error);
                }
                else if (cmbSponsor.SelectedItem == null)
                {
                    error = "Sponsor Is Required!";
                    staffErrorProvider.SetError(cmbSponsor, error);
                }

                else if (cmbCountry.SelectedItem == null)
                {
                    error = "Country Is Required!";
                    staffErrorProvider.SetError(cmbCountry, error);
                }
                else if (cmbSchool.SelectedItem == null )
                {
                    error = "School Is Required!";
                    staffErrorProvider.SetError(cmbSchool, error);
                }
                else if (txtVenue.Text == string.Empty)
                {
                    error = "Venue Is Required!";
                    staffErrorProvider.SetError(txtVenue, error);
                }
                
                else
                {
                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();
                    string sql = string.Empty;
                    if (externalTraining == null || externalTraining.ID == 0)
                    {

                       
                        sql = "INSERT INTO ExternalTraining(StaffID,SchoolId,CountryId,StartDate,EndDate,OrganiserId,QualificationId,Venue,CostFee,AccomodationFee,TransportationFee,TotalCost,InCountryTraining,SponsorID,UserID,DateEntered,Archived,Active)VALUES(@StaffID,@SchoolId,@CountryId,@StartDate,@EndDate,@OrganiserId,@QualificationId,@Venue,@CostFee,@AccomodationFee,@TransportationFee,@TotalCost,@InCountryTraining,@SponsorID,@UserID,@DateEntered,@Archived,@Active)";
                    }
                    else
                    {
                        dalHelper.CreateParameter("@Id", externalTraining.ID, DbType.Int32);
                        sql = "UPDATE ExternalTraining SET StaffID=@StaffID,SchoolId = @SchoolId,CountryId = @CountryId,StartDate = @StartDate,EndDate = @EndDate,OrganiserId = @OrganiserId,QualificationId = @QualificationId,Venue = @Venue,CostFee = @CostFee,AccomodationFee = @AccomodationFee,TransportationFee = @TransportationFee,TotalCost = @TotalCost,InCountryTraining = @InCountryTraining,SponsorID = @SponsorID,UserID = @UserID,DateEntered = @DateEntered,Active = @Active WHERE id=@Id";
                    }

                    try
                    {
                        if (cmbSchool.SelectedIndex >= lstAttendedSchool.Count)
                        {
                            lstAttendedSchool = attenSchoolMapper.getByCountryId(lstCountries[cmbCountry.SelectedIndex].ID);
                        }   
                    }
                    catch (Exception x2) { }

                    dalHelper.CreateParameter("@StaffID", selectedEmployee.ID, DbType.Int32);
                    dalHelper.CreateParameter("@SchoolId",lstAttendedSchool[cmbSchool.SelectedIndex].Id, DbType.Int32);
                    dalHelper.CreateParameter("@CountryId", lstCountries[cmbCountry.SelectedIndex].ID, DbType.Int32);
                    dalHelper.CreateParameter("@OrganiserId", lstTrainingOrganizers[cmbOrganizers.SelectedIndex].Id, DbType.Int32);
                    dalHelper.CreateParameter("@SponsorId", lstTrainingSponsors[cmbSponsor.SelectedIndex].Id, DbType.Int32);
                    dalHelper.CreateParameter("@QualificationId", lstQualifications[cmbQualification.SelectedIndex].ID, DbType.Int32);

                    dalHelper.CreateParameter("@StartDate", dateStartDate.Value.Date, DbType.Date);
                    dalHelper.CreateParameter("@EndDate", dateEndDate.Value.Date, DbType.Date);
                    dalHelper.CreateParameter("@Venue", txtVenue.Text, DbType.String);
                    dalHelper.CreateParameter("@CostFee", Convert.ToDecimal(txtCostFee.Text), DbType.Decimal);
                    dalHelper.CreateParameter("@TotalCost", (Convert.ToDecimal(txtCostFee.Text) + Convert.ToDecimal(txtAccomodationFee.Text) + Convert.ToDecimal(txtTransportationFee.Text)), DbType.Decimal);
                    dalHelper.CreateParameter("@AccomodationFee", Convert.ToDecimal(txtAccomodationFee.Text), DbType.Decimal);
                    dalHelper.CreateParameter("@TransportationFee", Convert.ToDecimal(txtTransportationFee.Text), DbType.Decimal);
                    dalHelper.CreateParameter("@InCountryTraining", radInCountry.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                    dalHelper.CreateParameter("@DateEntered", DateTime.Now, DbType.Date);
                    dalHelper.CreateParameter("@Active", chkActive.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@Archived", false, DbType.Boolean);

                    dalHelper.ExecuteNonQuery(sql);
                    MessageBox.Show("Record Saved Successfully!");
                    if (editMode == false)
                        Clear();
                }

                if (error != string.Empty)
                    MessageBox.Show(error);
            }
            catch (Exception e1) {
                Logger.LogError(e1);
                MessageBox.Show("Unable To Save Record!\n Retry Later.");
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ExternalTrainingView externalTrainingView = new ExternalTrainingView(this);
            externalTrainingView.removeButton.Visible = CanDelete;
            externalTrainingView.Show(this);
        }

        public void FillEntries(ExternalTraining externalTraining)
        {
            try
            {
                this.externalTraining = externalTraining;
                staffIDtxt.Text = externalTraining.Staff.StaffID;
                searchGrid.Rows[0].Selected = true;
                searchGrid_CellClick(this, new DataGridViewCellEventArgs(0, 0));

                cmbQualification_DropDown(this, EventArgs.Empty);
                cmbQualification.SelectedItem = externalTraining.AspiredQualification.CertificateObtained;

                dateStartDate.Value = externalTraining.StartDate;
                dateEndDate.Value = externalTraining.EndDate;
                txtCostFee.Text = externalTraining.Cost.ToString();
                txtCost.Text = externalTraining.TotalCost.ToString();

                txtAccomodationFee.Text = externalTraining.AccomodationFee.ToString();
                txtTransportationFee.Text = externalTraining.TransportationFee.ToString();
                cmbOrganizers_DropDown(this, EventArgs.Empty);
                cmbOrganizers.SelectedItem = externalTraining.Organizer.Description;

                cmbSponsor_DropDown(this, EventArgs.Empty);
                cmbSponsor.SelectedItem = externalTraining.Sponsor.Description;
                if (externalTraining.InCountryTraining == true)
                    radInCountry.Checked = true;
                else
                    radOutsideGhana.Checked = true;

                cmbCountry_DropDown(this, EventArgs.Empty);
                cmbCountry.SelectedItem = externalTraining.TrainingCoutry.Description;

                cmbSchool_DropDown(this, EventArgs.Empty);
                cmbSchool.SelectedItem = externalTraining.School.Description;

                txtVenue.Text = externalTraining.Venue;

                dateTrainingDate.Value = externalTraining.EnteredDate;
            }
            catch (Exception e1) { }
            
        }
        public void  fillWorkshops(){
            try
            {
                lstWorkshops.Clear();
                lstWorkshops = workshopDataMapper.getDataStaffId(selectedEmployee.ID);
                gridWorkshops.Rows.Clear();
                int ctr = 0;
                foreach (Workshop workshop in lstWorkshops)
                {
                    gridWorkshops.Rows.Add(1);
                    gridWorkshops.Rows[ctr].Cells["gridID"].Value = workshop.Id;
                    gridWorkshops.Rows[ctr].Cells["gridCourseTitle"].Value = workshop.Course.CertificateObtained;
                    gridWorkshops.Rows[ctr].Cells["gridCountry"].Value = workshop.Country.Description;
                    gridWorkshops.Rows[ctr].Cells["gridSchool"].Value = workshop.School.Description;
                    gridWorkshops.Rows[ctr].Cells["gridPlace"].Value = workshop.Venue;
                    gridWorkshops.Rows[ctr].Cells["gridStartDate"].Value = workshop.StartDate.ToShortDateString();
                    gridWorkshops.Rows[ctr].Cells["gridEndDate"].Value = workshop.EndDate.ToShortDateString();
                    gridWorkshops.Rows[ctr].Cells["gridActive"].Value = workshop.Active;
                    ctr++;
                }
            }
            catch (Exception xi) {
                Logger.LogError(xi);
            }
            gridWorkshops.ClearSelection();
        }

        public void updateWorkshopRow(DataGridViewRow dataRow,Workshop workshop)
        {
            dataRow.Cells["gridID"].Value = workshop.Id;
            dataRow.Cells["gridCourseTitle"].Value = workshop.Course.CertificateObtained;
            dataRow.Cells["gridCountry"].Value = workshop.Country.Description;
            dataRow.Cells["gridSchool"].Value = workshop.School.Description;
            dataRow.Cells["gridPlace"].Value = workshop.Venue;
            dataRow.Cells["gridStartDate"].Value = workshop.StartDate.ToShortDateString();
            dataRow.Cells["gridEndDate"].Value = workshop.EndDate.ToShortDateString();
            dataRow.Cells["gridActive"].Value = workshop.Active;
        }
        private void ExternalTrainingForm_Load(object sender, EventArgs e)
        {
            Clear();
            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnAdd.Visible = getPermissions.CanAdd;
                btnView.Visible = getPermissions.CanView;
                btnPreviewForm.Visible = getPermissions.CanView;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridWorkshops.SelectedRows.Count > 0)
            {
                Workshop workshop = workshopDataMapper.getById(Convert.ToInt32(gridWorkshops.CurrentRow.Cells["gridID"].Value));

                WorkshopEntryForm entryForm = new WorkshopEntryForm(this, workshop);
                entryForm.ShowDialog(this);
            }
            else
                MessageBox.Show("Oops No Record Is Selected!");
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (gridWorkshops.SelectedRows.Count > 0 )
            {
                if (MessageBox.Show(this, "Do you really want to delete record?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Workshop workshop = workshopDataMapper.getById(Convert.ToInt32(gridWorkshops.CurrentRow.Cells["gridID"].Value));
                    dalHelper.ClearParameters();

                    dalHelper.CreateParameter("@Id", workshop.Id, DbType.Int32);
                    dalHelper.ExecuteNonQuery("delete workshops where id=@Id");
                    gridWorkshops.Rows.Remove(gridWorkshops.CurrentRow);
                    // fillWorkshops()
                    MessageBox.Show("Record Deleted Successfully!");
                }
               
            }
            else
                MessageBox.Show("Oops No Record Is Selected!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            WorkshopEntryForm entryForm = new WorkshopEntryForm(this, new Workshop());
            entryForm.ShowDialog(this);
        }

        private void btnPreviewForm_Click(object sender, EventArgs e)
        {
            PreviewExternalTrainingReport reportForm;
            if(staffIDtxt.Text==string.Empty)
                reportForm=new PreviewExternalTrainingReport(new ExternalTraining());
            else
               reportForm=new PreviewExternalTrainingReport(externalTraining);
            reportForm.ShowDialog(this);
        }

        private void txtEachCostChange(object sender, EventArgs e)
        {
            try
            {
              txtCost.Text= (decimal.Parse(txtCostFee.Text) + decimal.Parse(txtTransportationFee.Text) + decimal.Parse(txtAccomodationFee.Text)).ToString();
            }
            catch (Exception xi)
            {
                txtCost.Text = string.Empty;
            }
        }

        private void radOutsideGhana_CheckedChanged(object sender, EventArgs e)
        {
            cmbCountry.Text = string.Empty;
            cmbSchool.Text = string.Empty;
            txtVenue.Clear();
        }

        private void radInCountry_CheckedChanged(object sender, EventArgs e)
        {
            cmbCountry.Text = string.Empty;
            cmbSchool.Text = string.Empty;
            txtVenue.Clear();
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSchool.Text = string.Empty;
            txtVenue.Text = string.Empty;
        }
    }
}
