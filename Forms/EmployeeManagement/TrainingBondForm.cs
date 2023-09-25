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
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;
using eMAS.Forms.EmployeeManagement;
using HRDataAccessLayer.System_Setup_Data_Control;
using System.IO;
using System.Drawing.Imaging;
using eMAS.Forms.Reports;
using Microsoft.VisualBasic;

namespace eMAS.Forms
{
    public partial class TrainingBondForm : Form
    {
       private TrainingBondDataMapper trainingBondDataMapper;
        public TrainingBond trainingBond;

        private Company company;
        private IDAL dal;
        private int ctr;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private bool editMode = false;
        private int staffCode;
        private Employee selectedEmployee;
        private DALHelper dalHelper;

        private EmployeeDataMapper empDataMapper;

        private IList<Qualification> lstQualifications;
        private IList<Country> lstCountries;
        private IList<AttendedSchool> lstSchools;

        private IList<TrainingAttendanceMode> lstAttendanceModes;
        private IList<SponsoredCertProgramme> lstProgrammeCategories;

        public IList<SponsorshipGuaranter> lstGuaranters;

        private QualificationDataMapper qualificationsMapper;
        private CountryDataMapper countryMapper;
        private AttendedSchoolDataMapper schoolDataMapper;

        private TrainingAttendanceModeMapper trainingModeMapper;
        private SponsoredCertProgrammeDataMapper sponsorCertMapper;

        private SponsorshipGuarantersDataMapper sponsorGuaranterMapper;

        private MemoryStream stream;

        public Permissions permissions;
        
        public TrainingBondForm()
        {
            InitializeComponent();
            trainingBondDataMapper = new TrainingBondDataMapper();

            this.company = new Company();
            this.dal = new DAL();
            this.employees = new List<Employee>();
            this.employeeList = new List<Employee>();
            this.empDataMapper = new EmployeeDataMapper();


            this.dalHelper = new DALHelper();
            this.lstAttendanceModes = new List<TrainingAttendanceMode>();
            this.lstProgrammeCategories = new List<SponsoredCertProgramme>();

            this.trainingModeMapper = new TrainingAttendanceModeMapper();
            this.sponsorCertMapper = new SponsoredCertProgrammeDataMapper();

            this.lstCountries = new List<Country>();
            this.lstQualifications = new List<Qualification>();
            this.lstSchools = new List<AttendedSchool>();

            this.qualificationsMapper = new QualificationDataMapper();
            this.countryMapper = new CountryDataMapper();
            this.schoolDataMapper = new AttendedSchoolDataMapper();

            this.sponsorGuaranterMapper = new SponsorshipGuarantersDataMapper();

            this.stream = new MemoryStream();
        }
       
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        byte[] ScannedBytes = null;
        string fileName = string.Empty;
        private void btnSave_Click(object sender, EventArgs e)
        {
            //int TrainingBondId=0;
            try
            {
            string error=string.Empty;
            if (staffIDtxt.Text == string.Empty){
                error="Staff ID Is Required!";
                errorProvider1.SetError(staffIDtxt,error);
                tabAdditionalInfo.Select();
            }
            else if (nametxt.Text == string.Empty){
               error="Name is required!";
                 errorProvider1.SetError(nametxt,error);
                 tabAdditionalInfo.Select();
            }
            else if(chkForAdditionalQualification.Checked==true && cmbQualifications.Text==string.Empty)
            {
                error = "Qualification is required!";
                errorProvider1.SetError(cmbQualifications, error);
                tabCourse.Select();
            }
            else if (chkForAdditionalQualification.Checked == true &&  cmbCountry.Text == string.Empty)
            {
                error = "Country is required!";
                errorProvider1.SetError(cmbCountry, error);
                tabCourse.Select();
            }
            else if (chkForAdditionalQualification.Checked == true && cmbSchoolId.Text == string.Empty)
            {
                error = "School is required!";
                errorProvider1.SetError(cmbSchoolId, error);
                tabCourse.Select();
            }
            else if (chkForAdditionalQualification.Checked == true && cmbAttendanceMode.Text == string.Empty)
            {
                error = "Attendance Mode is required!";
                errorProvider1.SetError(cmbAttendanceMode, error);
                tabCourse.Select();
            }
            else if (cmbProgrammeCategory.Text == string.Empty)
            {
                error = "Programme category is required!";
                errorProvider1.SetError(cmbProgrammeCategory, error);
                tabCourse.Select();
            }

            else if (txtProgrammeDuration.Text == string.Empty)
            {
                error = "Programme duration is required!";
                errorProvider1.SetError(txtProgrammeDuration, error);
                tabCourse.Select();
            }

            else if (txtBondDuration.Text == string.Empty)
            {
                error = "Bond duration is required!";
                errorProvider1.SetError(txtBondDuration, error);
                tabCourse.Select();
            }
            else if (gridGuaranters.Rows.Count == 0)
            {
                error = "You need to supply guaranters!";
                errorProvider1.SetError(gridGuaranters, error);
                tabGuaranters.Select();
            }
            else if (txtWitness.Text == string.Empty)
            {
                error = "Witnessed Name   required!";
                errorProvider1.SetError(txtWitness, error);
                tabWitness.Select();
            }
            else if (chkForAdditionalQualification.Checked == true && fileName==string.Empty)
            {
                error = "Approval letter is required!";
                errorProvider1.SetError(btnBrowseFile, error);
                tabWitness.Select();
            }
            else if (cmbBondStatus.Text == string.Empty)
            {
                error = "Bond status is required!";
                errorProvider1.SetError(cmbBondStatus, error);
                tabWitness.Select();
            }
            else if (chkForAdditionalQualification.Checked == true && dtpStartDate.Value > dtpEndDate.Value)
            {
                error = "Course Start Date Cannot Be Greater Than End Date!";
                errorProvider1.SetError(dtpStartDate, error);
                tabCourse.Select();
            }
            else 
            {
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();
                string sql=string.Empty;

              // dalHelper.BeginTransaction();

                if (trainingBond!=null && trainingBond.Id > 0 && ScannedBytes != null)
                {
                 ScannedBytes=   trainingBond.WitnessStamp;
                }
              

                if (editMode == true && trainingBond.Id>0)
                {
                    dalHelper.CreateParameter("@id", trainingBond.Id, DbType.Int32);
                    if(chkForAdditionalQualification.Checked==true)
                        sql = "update TrainingBonds set staffID=@staffID,qualificationId=@qualificationId,forAdditionalQualification=@forAdditionalQualification,schoolId=@schoolId,courseStartDate=@courseStartDate,courseEndDate=@courseEndDate,AttendanceModeId=@AttendanceModeId,sponsoredProgrammeGroupId=@sponsoredProgrammeGroupId,declarationDate=@declarationDate,entrydate=@entrydate,witnessByName=@witnessByName,witnessStamp=@witnessStamp,letterName=@letterName,witnessDate=@witnessDate,active=@active,archived=@archived,status=@status where id=@id";
                    else
                        sql = "update TrainingBonds set staffID=@staffID,sponsoredProgrammeGroupId=@sponsoredProgrammeGroupId,forAdditionalQualification=@forAdditionalQualification,declarationDate=@declarationDate,entrydate=@entrydate,witnessByName=@witnessByName,witnessDate=@witnessDate,active=@active,archived=@archived,status=@status where id=@id";

                }
                else if (editMode == false || trainingBond.Id==0)
                {
                    if(chkForAdditionalQualification.Checked==true)
                        sql = "insert into TrainingBonds (staffID,qualificationId,schoolId,courseStartDate,courseEndDate,AttendanceModeId,forAdditionalQualification,sponsoredProgrammeGroupId,declarationDate,entrydate,witnessByName,witnessStamp,letterName,witnessDate,active,archived,status) values (@staffID,@qualificationId,@schoolId,@courseStartDate,@courseEndDate,@AttendanceModeId,@forAdditionalQualification,@sponsoredProgrammeGroupId,@declarationDate,@entrydate,@witnessByName,@witnessStamp,@letterName,@witnessDate,@active,@archived,@status)";
                    else
                        sql = "insert into TrainingBonds (staffID,sponsoredProgrammeGroupId,courseStartDate,courseEndDate,forAdditionalQualification,declarationDate,entrydate,witnessByName,witnessDate,active,archived,status) values (@staffID,@sponsoredProgrammeGroupId,@courseStartDate,@courseEndDate,@forAdditionalQualification,@declarationDate,@entrydate,@witnessByName,@witnessDate,@active,@archived,@status)";

                }
                sql = sql + "; SELECT SCOPE_IDENTITY()";

                dalHelper.CreateParameter("@staffID", selectedEmployee.ID, DbType.Int32);


                dalHelper.CreateParameter("@courseStartDate", dtpStartDate.Value.Date, DbType.Date);
                dalHelper.CreateParameter("@courseEndDate", dtpEndDate.Value.Date, DbType.Date);

                if (chkForAdditionalQualification.Checked == true)
                {
                    dalHelper.CreateParameter("@qualificationId", lstQualifications[cmbQualifications.SelectedIndex].ID, DbType.Int32);
                    dalHelper.CreateParameter("@schoolId", lstSchools[cmbSchoolId.SelectedIndex].Id, DbType.Int32);
                  

                    dalHelper.CreateParameter("@AttendanceModeId", lstAttendanceModes[cmbAttendanceMode.SelectedIndex].Id, DbType.Int32);
                }
                
                dalHelper.CreateParameter("@sponsoredProgrammeGroupId", lstProgrammeCategories[cmbProgrammeCategory.SelectedIndex].Id, DbType.Int32);


                dalHelper.CreateParameter("@declarationDate", dtpDeclarationDate.Value.Date, DbType.Date);
                dalHelper.CreateParameter("@entrydate", DateTime.Now.Date, DbType.Date);
                dalHelper.CreateParameter("@witnessByName",txtWitness.Text,DbType.String);


                dalHelper.CreateParameter("@forAdditionalQualification", chkForAdditionalQualification.Checked, DbType.Boolean);
                if (chkForAdditionalQualification.Checked == true)
                {
                    dalHelper.CreateParameter("@witnessStamp", ScannedBytes, DbType.Binary);
                    dalHelper.CreateParameter("@letterName", fileName, DbType.String);
                }
                    
                dalHelper.CreateParameter("@witnessDate", datePickerWitnessDate.Value.Date,DbType.Date);
                dalHelper.CreateParameter("@active",true, DbType.Boolean);
                dalHelper.CreateParameter("@archived", false, DbType.Boolean);

                dalHelper.CreateParameter("@status", cmbBondStatus.Text, DbType.String);

                var result = dalHelper.ExecuteScalar(sql);
                if (Information.IsNumeric(result))
                    trainingBondId = Convert.ToInt32(result);
                else
                    trainingBondId = trainingBond.Id;

               foreach (SponsorshipGuaranter guaranter in lstGuaranters)
               {

                   InsertUpdateGuaranter(guaranter, trainingBondId, dalHelper);
               }
               MessageBox.Show("Training Bond Saved Successfully!");
              }
           //dalHelper.CommitTransaction();
             trainingBond=trainingBondDataMapper.getById(trainingBondId);
            if (error != string.Empty)
                MessageBox.Show(error);
             else if(editMode==false){
                Clear();
             }
            }
           
            catch (Exception e1) {
                //dalHelper.RollBackTransaction();
                MessageBox.Show("Unable To Save Training Bond\n Try Again Later!");
            }
            
        }

        private void TrainingBond_Load(object sender, EventArgs e)
        {
            trainingBond = new TrainingBond();
            lstGuaranters = new List<SponsorshipGuaranter>();
            chkForAdditionalQualification_CheckedChanged(this, EventArgs.Empty);

            permissions = GlobalData.CheckPermissions(3);
            btnSave.Enabled = permissions.CanAdd;
            btnView.Enabled = permissions.CanView;
        }
        public void FillForm(TrainingBond NewtrainingBond)
        {
            try
            {
                

               chkForAdditionalQualification.Checked = NewtrainingBond.ForAdditionalQualification;

                if (chkForAdditionalQualification.Checked == true)
                {
                    cmbQualifications_DropDown(this, EventArgs.Empty);

                    cmbQualifications.SelectedItem = NewtrainingBond.AspiredQualification.CertificateObtained;

                    cmbCountry_DropDown(this, EventArgs.Empty);
                    cmbCountry.SelectedItem = NewtrainingBond.School.SchoolCountry.Description.Trim();

                    cmbCountry_SelectionChangeCommitted(this, EventArgs.Empty);
                    cmbSchoolId.SelectedItem = NewtrainingBond.School.Description.Trim();

                    cmbAttendanceMode_DropDown(this, EventArgs.Empty);
                    cmbAttendanceMode.SelectedItem = NewtrainingBond.CourseAttendanceMode.Description.Trim();

                    dtpEndDate.Value = NewtrainingBond.CourseEndDate;
                    dtpStartDate.Value = NewtrainingBond.CourseStartDate;



                    lblApprovalLetter.Visible = true;
                    btnBrowseFile.Visible = true;
                    btnPreviewScannedCopy.Visible = true;

                    //pboxWitnessedCopy.Image = Image.FromStream(new MemoryStream(NewtrainingBond.WitnessStamp));
                }
                
               

                cmbProgrammeCategory_DropDown(this, EventArgs.Empty);
                cmbProgrammeCategory.SelectedItem = NewtrainingBond.SponsoredProgrammeCategory.Description;

            

                staffIDtxt.Text = NewtrainingBond.Staff.StaffID;

                searchGrid.Rows[0].Selected = true;
                Object sender=new object();
                DataGridViewCellEventArgs eventArgs=new DataGridViewCellEventArgs(0,0);
                searchGrid_CellClick(sender,eventArgs);

                txtWitness.Text = NewtrainingBond.WitnessedBy;

                dtpDeclarationDate.Value = NewtrainingBond.DeclarationDate;


                ScannedBytes = NewtrainingBond.WitnessStamp;

                if (ScannedBytes != null)
                    btnBrowseFile.Text = "-";

                cmbBondStatus.SelectedItem = NewtrainingBond.Status;
                cmbBondStatus.Text = NewtrainingBond.Status;

                txtBondDuration.Text = NewtrainingBond.SponsoredProgrammeCategory.BondedDuration.ToString();
                txtProgrammeDuration.Text = NewtrainingBond.SponsoredProgrammeCategory.ProgrammeDuration.ToString();
                fileName = NewtrainingBond.letterName;

                this.trainingBond = NewtrainingBond;
            }
            catch (Exception e1) { }
            
        }
        private void btnAddGuaranter_Click(object sender, EventArgs e)
        {
            SponsorShipGuarantersForm guaranterForm = new SponsorShipGuarantersForm(this, new SponsorshipGuaranter(),false);
            guaranterForm.ShowDialog(this);

           
        }
        void InsertUpdateGuaranter(SponsorshipGuaranter guaranter,int TrainingBondId,DALHelper myDalHelper)
        {
            try
            {
                 string sql=string.Empty;
          myDalHelper.ClearParameters();
            if (guaranter.Id > 0){
                sql = "update SponsorshipGuaranters set GuaranterName=@GuaranterName,Designation=@Designation,trainingBondId=@trainingBondId,EmpNumber=@EmpNumber,PassPortNo=@PassPortNo,PassPortIssueDate=@PassPortIssueDate,PassPortExpiryDate=@PassPortExpiryDate,Email=@Email,MobileNo=@MobileNo,TelNo=@TelNo,Address=@Address,Organization=@Organization,Photo=@Photo,active=@active,archived=@archived,IdentityTypeId=@IdentityTypeId where Id=@Id";
                myDalHelper.CreateParameter("@Id", guaranter.Id,DbType.Int32);
            }
            else
                sql = "insert into SponsorshipGuaranters (GuaranterName,Designation,trainingBondId,EmpNumber,PassPortNo,PassPortIssueDate,PassPortExpiryDate,Email,MobileNo,TelNo,Address,Organization,Photo,active,archived,IdentityTypeId) values(@GuaranterName,@Designation,@trainingBondId,@EmpNumber,@PassPortNo,@PassPortIssueDate,@PassPortExpiryDate,@Email,@MobileNo,@TelNo,@Address,@Organization,@Photo,@active,@archived,@IdentityTypeId)";
            myDalHelper.CreateParameter("@GuaranterName", guaranter.GuaranterName, DbType.String);
            myDalHelper.CreateParameter("@Designation", guaranter.Designation, DbType.String);
            myDalHelper.CreateParameter("@trainingBondId", TrainingBondId, DbType.Int32);
            myDalHelper.CreateParameter("@EmpNumber", guaranter.EmpNumber, DbType.String);
            myDalHelper.CreateParameter("@PassPortNo", guaranter.PassPortNo, DbType.String);
            myDalHelper.CreateParameter("@PassPortIssueDate", guaranter.PassPortIssueDate, DbType.Date);
            myDalHelper.CreateParameter("@PassPortExpiryDate", guaranter.PassPortExpiryDate, DbType.Date);
            myDalHelper.CreateParameter("@Email", guaranter.Email, DbType.String);
            myDalHelper.CreateParameter("@MobileNo", guaranter.MobileNo, DbType.String);
            myDalHelper.CreateParameter("@TelNo", guaranter.TelNo, DbType.String);
            myDalHelper.CreateParameter("@Address", guaranter.Address, DbType.String);
            myDalHelper.CreateParameter("@Organization", guaranter.Organization, DbType.String);
            myDalHelper.CreateParameter("@Photo", guaranter.Photo, DbType.Binary);
            myDalHelper.CreateParameter("@active", guaranter.Active, DbType.Boolean);
            myDalHelper.CreateParameter("@archived", guaranter.Archived, DbType.Boolean);
            myDalHelper.CreateParameter("@IdentityTypeId", guaranter.IdentificationType.ID, DbType.Int32);

            myDalHelper.ExecuteNonQuery(sql);
            }catch (Exception e1){}
           
        
        }
       public int GuaranterCtr = 0;
      public  void loadGuaranters(int trainingBondId)
        {
            try
            {
                lstGuaranters.Clear();
                if (trainingBondId>0)
                {
                    var guaranters = trainingBondDataMapper.getById(trainingBondId).SponsorshipGuaranters;
                    gridGuaranters.Rows.Clear();
                    GuaranterCtr = 0;
                   
                    foreach (SponsorshipGuaranter guaranter in guaranters)
                        AddToGuarantersGrid(guaranter);
                }
            }
            catch (Exception e1) { }
           
        }
      public void AddToGuarantersGrid(SponsorshipGuaranter guaranter)
      {
          lstGuaranters.Add(guaranter);
          gridGuaranters.Rows.Add(1);
        
          gridGuaranters.Rows[GuaranterCtr].Cells["gridID"].Value = guaranter.Id;

          stream = new MemoryStream(guaranter.Photo);
         ((DataGridViewImageCell) gridGuaranters.Rows[GuaranterCtr].Cells["gridPhoto"]).Value =Bitmap.FromStream(stream);
         //((DataGridViewImageCell) gridGuaranters.Rows[GuaranterCtr].Cells["gridPhoto"]).RowIndex

          if(guaranter.Id>0)
              gridGuaranters.Rows[GuaranterCtr].Cells["gridID"].Value = guaranter.Id;
          gridGuaranters.Rows[GuaranterCtr].Cells["gridGuaranterName"].Value = guaranter.GuaranterName;
          gridGuaranters.Rows[GuaranterCtr].Cells["gridEmpNumber"].Value = guaranter.EmpNumber;
          gridGuaranters.Rows[GuaranterCtr].Cells["gridOrganization"].Value = guaranter.Organization;
          gridGuaranters.Rows[GuaranterCtr].Cells["gridEmailAddress"].Value = guaranter.Email;
          gridGuaranters.Rows[GuaranterCtr].Cells["gridTelNo"].Value = guaranter.TelNo;
          gridGuaranters.Rows[GuaranterCtr].Cells["gridDesignation"].Value = guaranter.Designation;
          gridGuaranters.Rows[GuaranterCtr].Cells["gridPassPort"].Value = guaranter.PassPortNo;

          gridGuaranters.Rows[GuaranterCtr].Cells["gridIDType"].Value = guaranter.IdentificationType.CardName;

          gridGuaranters.Rows[GuaranterCtr].Cells["gridPassportIssueDate"].Value = guaranter.PassPortIssueDate.ToString("dd/MM/yyyy");
          gridGuaranters.Rows[GuaranterCtr].Cells["gridPassportExpiryDate"].Value = guaranter.PassPortExpiryDate.ToString("dd/MM/yyyy");

          gridGuaranters.RowTemplate.Height = 100;
          
          GuaranterCtr = GuaranterCtr + 1;  
      }
      public void EditToGuarantersGrid(SponsorshipGuaranter guaranter,int Index)
      {
          try
          {
              gridGuaranters.Rows[Index].Cells["gridID"].Value = guaranter.Id;

              stream = new MemoryStream(guaranter.Photo);
              ((DataGridViewImageCell)gridGuaranters.Rows[Index].Cells["gridPhoto"]).Value = Bitmap.FromStream(stream);

              if (guaranter.Id > 0)
                  gridGuaranters.Rows[Index].Cells["gridID"].Value = guaranter.Id;
              gridGuaranters.Rows[Index].Cells["gridGuaranterName"].Value = guaranter.GuaranterName;
              gridGuaranters.Rows[Index].Cells["gridEmpNumber"].Value = guaranter.EmpNumber;
              gridGuaranters.Rows[Index].Cells["gridOrganization"].Value = guaranter.Organization;
              gridGuaranters.Rows[Index].Cells["gridEmailAddress"].Value = guaranter.Email;
              gridGuaranters.Rows[Index].Cells["gridTelNo"].Value = guaranter.TelNo;
              gridGuaranters.Rows[Index].Cells["gridDesignation"].Value = guaranter.Designation;

              gridGuaranters.Rows[Index].Cells["gridIDType"].Value = guaranter.IdentificationType.CardName;

              gridGuaranters.Rows[Index].Cells["gridPassPort"].Value = guaranter.PassPortNo;
              gridGuaranters.Rows[Index].Cells["gridPassportIssueDate"].Value = guaranter.PassPortIssueDate.ToString("dd/MM/yyyy");
              gridGuaranters.Rows[Index].Cells["gridPassportExpiryDate"].Value = guaranter.PassPortExpiryDate.ToString("dd/MM/yyyy");
          
          }
          catch (Exception e1) { }
          
      }
        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                    {
                        errorProvider1.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Terminated",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Confirmed",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = true,
                            CriteriaOperator = CriteriaOperator.And
                        });

                        employees = dal.LazyLoadCriteria<Employee>(query);
                        if (employees.Count > 0)
                        {
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
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

        private void Clear()
        {
            txtPob.Clear();
            txtCountryOfBirth.Clear();
            txtHomeTown.Clear();
            txtNationality.Clear();
            txtResidenceCountry.Clear();
            txtResidencePostalAddress.Clear();
            txtResidenceRegion.Clear();
            txtResidenceTown.Clear();
            txtSSNITNo.Clear();
            nametxt.Clear();
            txtMaidenName.Clear();
            txtTitle.Clear();
            gendertxt.Clear();
            txtDob.Clear();
            txtEmail.Clear();
            txtPhoneNo.Clear();

            txtCurrentGrade.Clear();
            txt1stAppointment.Clear();
            txt1stAppointmentGrade.Clear();
            txtSpecialty.Clear();
            txtProfession.Clear();
            txtDepartment.Clear();
            txtUnit.Clear();
            //pboxWitnessedCopy.Image = global::eMAS.Properties.Resources.DOCX;
            dtpDeclarationDate.ResetText();
            editMode = false;
            trainingBond = new TrainingBond();
            staffIDtxt.Clear();

            cmbQualifications.Items.Clear();
            cmbSchoolId.Items.Clear();
            cmbCountry.Items.Clear();
            dtpEndDate.ResetText();
            dtpStartDate.ResetText();
            cmbAttendanceMode.Items.Clear();
            cmbProgrammeCategory.Items.Clear();
            txtWitness.Clear();
            datePickerWitnessDate.ResetText();
            dtpDeclarationDate.ResetText();
            cmbBondStatus.SelectedIndex = -1;
            ScannedBytes = null;
            fileName = string.Empty;
            pictureBox.Image = global::eMAS.Properties.Resources._default;
            txtProgrammeDuration.Clear();
            txtBondDuration.Clear();
            cmbProgrammeCategory.Items.Clear();
            gridGuaranters.Rows.Clear();
            chkForAdditionalQualification.Checked = false;

            cmbQualifications.Text = string.Empty;
            cmbQualifications.Items.Clear();

            cmbCountry.Text = string.Empty;
            cmbCountry.Items.Clear();

            cmbSchoolId.Text = string.Empty;
            cmbSchoolId.Items.Clear();

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;

            cmbAttendanceMode.Text = string.Empty;
            cmbAttendanceMode.Items.Clear();

            cmbProgrammeCategory.Text = string.Empty;
            cmbProgrammeCategory.Items.Clear();

            txtProgrammeDuration.Clear();
            txtBondDuration.Clear();
            trainingBond.SponsorshipGuaranters = null;
            //FillForm(trainingBond);
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

                            selectedEmployee = dal.ShowImageByStaffID<Employee>(employee);
                            pictureBox.Image = selectedEmployee.Photo;

                            selectedEmployee = empDataMapper.GetByID(employee.ID);

                            staffIDtxt.Text = selectedEmployee.StaffID;
                            staffCode = selectedEmployee.ID;
                            gendertxt.Text = selectedEmployee.Gender;
                            txtMaidenName.Text = selectedEmployee.MaidenName;
                            txtTitle.Text = selectedEmployee.Title.Description;
                            txtDob.Text = selectedEmployee.DOB.Value.ToString("dd/MM/yyyy");
                            txtEmail.Text = selectedEmployee.Email;
                            txtPhoneNo.Text = selectedEmployee.TelNo;

                            txtPob.Text = selectedEmployee.POB.Description;
                            txtCountryOfBirth.Text = selectedEmployee.CountryOfBirth.Description;
                            txtHomeTown.Text = selectedEmployee.HomeTown.Description;
                            txtNationality.Text = selectedEmployee.Nationality.Description;
                            txtResidenceCountry.Text = selectedEmployee.ResidentialCountry.Description;
                            txtResidencePostalAddress.Text = selectedEmployee.ResidentialRegion.Description;
                            txtResidenceRegion.Text = selectedEmployee.ResidentialRegion.Description;
                            txtResidenceTown.Text = selectedEmployee.ResidentialTown.Description;
                            txtSpecialty.Text = selectedEmployee.Specialty.Description;
                            txtSSNITNo.Text = selectedEmployee.SSNITNo;
                            txtResidencePostalAddress.Text = selectedEmployee.Address;

                            txtCurrentGrade.Text = selectedEmployee.Grade.Grade;
                            txt1stAppointmentGrade.Text = selectedEmployee.GradeOnFirstAppointment.Grade;
                            txtSpecialty.Text = selectedEmployee.Specialty.Description;

                            txt1stAppointment.Text = selectedEmployee.EmploymentDate.Value.ToShortDateString();
                            txtProfession.Text = selectedEmployee.JobTitle.Description;
                            txtDepartment.Text = selectedEmployee.Department.Description;
                            txtUnit.Text = selectedEmployee.Unit.Description;
                          
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            //selectedEmployee = employee;
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
                    errorProvider1.Clear();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            fileName = string.Empty;

            if (btnBrowseFile.Text == "-")
                ScannedBytes = null;

            try
            {
               
                    opfDialog.Filter = "Approval Letter|*.doc;*.docx;*.xls;*.xlsx;*.png;*.jpg;*.jpeg;*.bmp;*.pdf";
                    if (opfDialog.ShowDialog() == DialogResult.OK)
                    {
                        //pboxWitnessedCopy.Image = Image.FromFile(opfDialog.FileName);
                        //btnBrowseFile.Visible = true;
                        //stream = new MemoryStream();
                        //pboxWitnessedCopy.Image.Save(stream, ImageFormat.Jpeg);
                        ScannedBytes = AppUtils.FileGetBytes(opfDialog.FileName); //stream.GetBuffer();
                         //char[] delimiterChars={'\\'};
                        
                        
                        String[] fileNameSplit =opfDialog.FileName.Split(new char[] { '\\' });
                        fileName = fileNameSplit[fileNameSplit.Length - 1];

                        if (trainingBond != null && trainingBond.Id > 0)
                        {
                            trainingBond.WitnessStamp = ScannedBytes;
                            trainingBond.letterName = fileName;

                            btnBrowseFile.Text = "-";
                        }
                    }
                else
                        btnBrowseFile.Text = "+";
                }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }

        private void cmbQualifications_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstQualifications = qualificationsMapper.GetAllASRaw();

                cmbQualifications.Items.Clear();
                foreach (Qualification qualification in lstQualifications)
                {
                    cmbQualifications.Items.Add(qualification.CertificateObtained);
                }
            }
            catch (Exception e1) { }
           
        }

        private void cmbCountry_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstCountries = countryMapper.GetAll();
                cmbCountry.Items.Clear();
                foreach (Country country in lstCountries)
                {
                    cmbCountry.Items.Add(country.Description);
                }
            }
            catch (Exception e2) { }
           
        }

        private void cmbSchoolId_DropDown(object sender, EventArgs e)
        {
            
          
        }

        private void cmbAttendanceMode_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstAttendanceModes = trainingModeMapper.GetData();
                cmbAttendanceMode.Items.Clear();
                foreach (TrainingAttendanceMode trainingMode in lstAttendanceModes)
                {
                    cmbAttendanceMode.Items.Add(trainingMode.Description);
                }
            }
            catch (Exception e1) { }
            
        }

        private void cmbProgrammeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstProgrammeCategories.Clear();
                lstProgrammeCategories = sponsorCertMapper.getData(true, false);
                cmbProgrammeCategory.Items.Clear();

                foreach (SponsoredCertProgramme program in lstProgrammeCategories)
                {
                    cmbProgrammeCategory.Items.Add(program.Description);
                }
            }
            catch (Exception e1) { }
           
        }

        private void cmbProgrammeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProgrammeDuration.Clear();
            txtBondDuration.Clear();
            try
            {
                var selectedProgrammeGroup = lstProgrammeCategories[cmbProgrammeCategory.SelectedIndex];

                txtProgrammeDuration.Text = selectedProgrammeGroup.ProgrammeDuration.ToString();
                txtBondDuration.Text = selectedProgrammeGroup.BondedDuration.ToString();
            }
            catch (Exception e1) { }
           
        }

        private void btnPreviewScannedCopy_Click(object sender, EventArgs e)
        {
            /*if (pboxWitnessedCopy.Image != null && ScannedBytes!=null)
                AppUtils.downloadFile(ScannedBytes, nametxt.Text + ".jpg");*/
             if(fileName!=string.Empty && ScannedBytes!=null)
                 AppUtils.downloadFile(ScannedBytes, fileName);
            else
                 MessageBox.Show("No File To Download");
        }

        private void btnEditGuaranter_Click(object sender, EventArgs e)
        {
            if(gridGuaranters.SelectedRows.Count>0){
                //SponsorshipGuaranter guaranter=sponsorGuaranterMapper.getById(Convert.ToInt32( gridGuaranters.SelectedRows[0].Cells["gridID"].Value));
                SponsorshipGuaranter guaranter = lstGuaranters[gridGuaranters.CurrentRow.Index];
               
                SponsorShipGuarantersForm guaranterForm = new SponsorShipGuarantersForm(this, guaranter,true);
               guaranterForm.ShowDialog(this);
            }
            
        }
        TrainingBondView fromView;
        private void btnViewRows_Click(object sender, EventArgs e)
        {
            fromView= new TrainingBondView(this);
            fromView.removeButton.Enabled = permissions.CanDelete;
            fromView.gridViewInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gridViewInfo_CellDoubleClick);
            fromView.ShowDialog(this);
        }

        private int trainingBondId;
        private void gridViewInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            trainingBondId = 0;
            if (fromView.gridViewInfo.SelectedRows.Count > 0)
            {
                editMode = true;
                trainingBondId = Convert.ToInt32(fromView.gridViewInfo.SelectedRows[0].Cells["gridID"].Value);
                trainingBond = trainingBondDataMapper.getById(trainingBondId);
                FillForm(trainingBond);
                loadGuaranters(trainingBondId);
            }
           
        }

        private void btnRemoveGuaranter_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridGuaranters.SelectedRows.Count > 0)
                {
                    trainingBond = trainingBondDataMapper.getById(Convert.ToInt32(fromView.gridViewInfo.SelectedRows[0].Cells["gridID"].Value));
                    gridGuaranters.Rows.Remove(gridGuaranters.CurrentRow);
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@Id", trainingBond.Id, DbType.Int32);
                    dalHelper.ExecuteNonQuery("delete trainingBonds where id=@Id");
                    MessageBox.Show("Record Deleted Successfully!");
                    trainingBond = trainingBondDataMapper.getById(trainingBond.Id);
                    loadGuaranters(trainingBond.Id);
                }
            }
            catch (Exception e1) {
                Logger.LogError(e1);
                MessageBox.Show("Unable To Delete Record\n Retry Later!");
            }
         
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewTrainingBondForm trainingBondPreview;
                if(staffIDtxt.Text!=string.Empty){
                    trainingBondId = 1;
                    this.trainingBond=trainingBond!=null && trainingBond.Id>0? trainingBond: trainingBondDataMapper.getById(trainingBondId);
                   trainingBondPreview = new PreviewTrainingBondForm(this.trainingBond);
                }
                    
                else
                    trainingBondPreview=new PreviewTrainingBondForm(new TrainingBond());
            trainingBondPreview.Show(this);
        }

        private void chkForAdditionalQualification_CheckedChanged(object sender, EventArgs e)
        {
            if (chkForAdditionalQualification.Checked == true)
            {
                cmbQualifications.Enabled = true;
                cmbCountry.Enabled = true;
                cmbSchoolId.Enabled = true;
               // dtpStartDate.Enabled = true;
               // dtpEndDate.Enabled = true;

                lblApprovalLetter.Visible = true;
                //pboxWitnessedCopy.Visible = true;
                btnBrowseFile.Visible = true;
                btnPreviewScannedCopy.Visible = true;
                cmbAttendanceMode.Enabled = true;
            }
            else
            {
                cmbQualifications.Enabled = false;
                cmbCountry.Enabled = false;
                cmbSchoolId.Enabled = false;
                //dtpStartDate.Enabled = false;
                //dtpEndDate.Enabled = false;

                lblApprovalLetter.Visible = false;
                //pboxWitnessedCopy.Visible = false;
                btnBrowseFile.Visible = false;
                btnPreviewScannedCopy.Visible = false;
                cmbAttendanceMode.Enabled = false;
            }
        }

        private void cmbCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbSchoolId.Items.Clear();
               
                lstSchools = schoolDataMapper.getByCountryId(lstCountries[cmbCountry.SelectedIndex].ID);

                foreach (AttendedSchool school in lstSchools)
                {
                    if (editMode == false && school.Active == false)
                        continue;
                    cmbSchoolId.Items.Add(school.Description);
                }
                cmbSchoolId.Text = string.Empty;

            }
            catch (Exception e1) { }
        }
    }
}
