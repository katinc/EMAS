using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using eMAS.All_UIs.Staff_Information_FORMS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Validation;
using System.Drawing.Drawing2D;

namespace eMAS.Forms.Employment
{
    public partial class InternshipNewForm : Form
    {
        private IDAL dal;
        private bool editMode;
        private Internship internship;
        private InternshipType internshipType;
        private MaritalStatusGroups maritalStatusGroup;
        private GenderGroups genderGroup;
        private Department department;
        private Unit unit;
        private IList<Zone> zones;
        private IList<Department> departments;
        private IList<Internship> internships;
        private IList<InternshipType> internshipTypes;
        private IList<PhoneNumberType> phoneNumberTypeList;
        private IList<Unit> units;
        private IList<Company> companyInfo;
        private IList<Employee> employeeList;
        private Company company;
        private int ctr;
        private int internshipID;
        private int staffCode;
        private MyStuff mineObj;

        private IList<StaffFingerprintTemplates> staffFingerprintTemplates;

        List<Control> controls;
        List<controlObject> OldValues;

        public Permissions getPermissions;


        public InternshipNewForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.internship = new Internship();
                this.internshipType = new InternshipType();
                this.department = new Department();
                this.unit = new Unit();
                this.maritalStatusGroup = MaritalStatusGroups.None;
                this.genderGroup = GenderGroups.None;
                this.zones = new List<Zone>();
                this.internships = new List<Internship>();
                this.internshipTypes = new List<InternshipType>();
                this.phoneNumberTypeList = new List<PhoneNumberType>();
                this.departments= new List<Department>();
                this.units = new List<Unit>();
                this.companyInfo = new List<Company>();
                this.employeeList = new List<Employee>();
                this.company = new Company();
                this.editMode = false;
                this.internshipID = 0;
                this.staffCode = 0;
                this.ctr = 0;
                this.mineObj = new MyStuff();
                staffFingerprintTemplates = new List<StaffFingerprintTemplates>();

                fillFingerTypes();

                this.controls = new List<Control>();
                this.OldValues = new List<controlObject>();

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditInternship(Internship internship)
        {
            try
            {
                Clear();
                editMode = true;
                label13.Text = "Edit Internship / Attachment";
                this.internship = internship;
                cboGender_DropDown(this, EventArgs.Empty);
                cboGender.Text = internship.Gender.ToString();
                cboDepartment_DropDown(this, EventArgs.Empty);
                cboDepartment.Text = internship.Department.Description;
                cboDepartment_SelectionChangeCommitted(this, EventArgs.Empty);
                cboUnit.Text = internship.Unit.Description;
                cboInternshipType_DropDown(this, EventArgs.Empty);
                cboInternshipType.Text = internship.InternshipType.Description;
                cboMaritalStatus_DropDown(this, EventArgs.Empty);
                cboZone_DropDown(this, EventArgs.Empty);
                cboZone.Text = internship.Zone.Description;
                
                txtIDNumber.Text = internship.IDNumber;
                txtStaffID.Text = internship.StaffID;
                txtAreaOfStudy.Text = internship.AreaOfStudy;
                txtSurname.Text = internship.Surname;
                txtOtherName.Text = internship.OtherName;
                dateDOB.Value = internship.DOB.Value.Date;
                txtInstitutionAttended.Text = internship.Institution;
                dateStartDate.Value = internship.StartDate.Value.Date;
                dateEndDate.Value = internship.EndDate.Value.Date;
                dateReportingDate.Value = internship.ReportingDate.Value.Date;
                cboMaritalStatus.Text = internship.MaritalStatus.ToString();
                txtMobileNumber.Text = internship.MobileNo;
                txtAddress.Text = internship.Address;
                txtOverseer.Text = internship.Overseer;
                staffIDtxt.Text = internship.SupervisorStaffID;
                nametxt.Text = internship.SupervisorName;
                staffCode = internship.SupervisorCode;
                numericYear.Value = internship.YearStudied;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != internship.User.ID)
                {
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            OldValues = GlobalData.CloneControls(controls, this);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    UpdateInternshipEntity();
                    if (editMode)
                    {
                        //dal.Update(internship);
                        GlobalData.ProcessEdit(OldValues, controls, this, internshipID, staffIDtxt.Text);
                        Clear();
                    }
                    else
                    {
                        dal.Save(internship);
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Saved Successfully");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                InternshipSearch form = new InternshipSearch(dal,this);
                form.btnRemove.Enabled = getPermissions.CanDelete;
                form.MdiParent = this.MdiParent;
                form.Show();
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

        private void UpdateInternshipEntity()
        {
            try
            {
                internship.InternshipType = internshipTypes[cboInternshipType.SelectedIndex];
                internship.IDNumber = txtIDNumber.Text.Trim();
                internship.StaffID = txtStaffID.Text.Trim();
                internship.Surname = txtSurname.Text.Trim();
                internship.OtherName = txtOtherName.Text.Trim();
                internship.DOB = DateTime.Parse(dateDOB.Value.ToString());
                internship.Institution = txtInstitutionAttended.Text;
                internship.AreaOfStudy = txtAreaOfStudy.Text;
                if (cboGender.Text.Trim() != string.Empty && cboGender.Text.Trim() != null)
                {
                    internship.Gender = (GenderGroups)Enum.Parse(typeof(GenderGroups), cboGender.Text.Trim());
                }
                else
                {
                    internship.Gender = GenderGroups.None;
                }

                if (cboMaritalStatus.Text.Trim() != string.Empty && cboMaritalStatus.Text.Trim() != null)
                {
                    internship.MaritalStatus = (MaritalStatusGroups)Enum.Parse(typeof(MaritalStatusGroups), cboMaritalStatus.Text.Trim());
                }
                else
                {
                    internship.MaritalStatus = MaritalStatusGroups.None;
                }
                if (pictureBox.Image == null)
                {
                    internship.Photo = pictureBox.InitialImage;
                }
                else
                {
                    internship.Photo = pictureBox.Image;
                }
                internship.Department = departments[cboDepartment.SelectedIndex];
                internship.Department.ID=departments[cboDepartment.SelectedIndex].ID;
                internship.Unit = units[cboUnit.SelectedIndex];
                internship.Unit.ID = units[cboUnit.SelectedIndex].ID;
                internship.Zone = zones[cboZone.SelectedIndex];
                internship.Zone.ID = zones[cboZone.SelectedIndex].ID == 0 ? 1 : zones[cboZone.SelectedIndex].ID;
                internship.User.ID = GlobalData.User.ID;
                internship.StartDate = dateStartDate.Value.Date;
                internship.EndDate = dateEndDate.Value.Date;
                internship.ReportingDate = dateReportingDate.Value.Date;
                internship.MobileNo = txtMobileNumber.Text.Trim();
                internship.Address = txtAddress.Text.Trim();
                internship.Overseer = txtOverseer.Text.Trim();
                internship.SupervisorStaffID = staffIDtxt.Text.Trim();
                internship.SupervisorName = nametxt.Text.Trim();
                internship.SupervisorCode = staffCode;
                internship.YearStudied = numericYear.Value;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            try
            {
                age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age = age - 1;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            return age;
        }


        private bool ValidateFields()
        {
            bool result = true;
            int MaxAge = 0;
            int MinAge = 0;
            try
            {
                errorProvider.Clear();
                companyInfo = dal.GetAll<Company>();
                foreach (Company company in companyInfo)
                {
                    MaxAge = company.MaximumEmployeeAge;
                    MinAge = company.MinimumEmployeeAge;
                }
                if (internship.ID == 0)
                {
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.IDNumber",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtIDNumber.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                    if (dal.GetByCriteria<Internship>(query).Count > 0)
                    {
                        result = false;
                        errorProvider.SetError(txtIDNumber, "The ID Number you have entered already exists please change it");
                        txtIDNumber.Focus();
                    }
                }
                else
                {
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.IDNumber",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtIDNumber.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "InternshipView.ID",
                        CriterionOperator = CriterionOperator.NotEqualTo,
                        Value = internship.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    if (dal.GetByCriteria<Internship>(query).Count > 0)
                    {
                        result = false;
                        errorProvider.SetError(txtIDNumber, "The ID Number you have entered already exists please change it");
                        txtIDNumber.Focus();
                    }
                }
                if (cboInternshipType.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboInternshipType, "Please enter employee's surname");
                    cboInternshipType.Focus();
                }
                else if (dateDOB.Checked && !Validator.DateRangeValidator(dateDOB.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    errorProvider.SetError(dateDOB, "The employee's date of birth cannot be greater than today");
                    dateDOB.Focus();
                }
                else if (dateDOB.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(dateDOB, "Please select the employee's date of birth");
                    dateDOB.Focus();
                }
                else if (CalculateAge(dateDOB.Value) > MaxAge)
                {
                    result = false;
                    errorProvider.SetError(dateDOB, "Please the age cannot be greater than the max age");
                    dateDOB.Focus();
                }
                else if (CalculateAge(dateDOB.Value) < MinAge)
                {
                    result = false;
                    errorProvider.SetError(dateDOB, "Please the age cannot be less than the min age");
                    dateDOB.Focus();
                }
                else if (txtIDNumber.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtIDNumber, "Please enter employee's ID Numnber");
                    txtIDNumber.Focus();
                }
                else if (txtSurname.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtSurname, "Please enter employee's surname");
                    txtSurname.Focus();
                }
                else if (txtOtherName.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtOtherName, "Please enter employee's Other name");
                    txtOtherName.Focus();
                }

                else if (dateDOB.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(dateDOB, "Please select the Date of Birth");
                    dateDOB.Focus();
                }
                else if (txtInstitutionAttended.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtInstitutionAttended, "Please enter Institution Attended");
                    txtInstitutionAttended.Focus();
                }
                else if (cboGender.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboGender, "Please select the Gender");
                    cboGender.Focus();
                }
                else if (cboDepartment.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboDepartment, "Please select the Department");
                    cboDepartment.Focus();
                }
                else if (cboDepartment.Text.Trim() != string.Empty && cboUnit.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboUnit, "Please select the Unit");
                    cboUnit.Focus();
                }
                else if (cboZone.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboZone, "Please select the Zone");
                    cboZone.Focus();
                }
                else if (dateStartDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(dateStartDate, "Please select the Start Date");
                    dateStartDate.Focus();
                }
                else if (dateEndDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(dateEndDate, "Please select the End Date");
                    dateEndDate.Focus();
                }
                else if (dateReportingDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(dateReportingDate, "Please select the Reporting Date");
                    dateReportingDate.Focus();
                }
                else if (cboMaritalStatus.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboMaritalStatus, "Please select the Marital Status");
                    cboMaritalStatus.Focus();
                }
                else if (txtAreaOfStudy.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtAreaOfStudy, "Please Enter the Area of Study");
                    txtAreaOfStudy.Focus();
                }
                else if (getPhoneFormat(txtMobileNumber.Text.Trim()) == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtMobileNumber, "Please Enter Correct Format For the Mobile Number");
                    txtMobileNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private string getPhoneFormat(string PhoneNo)
        {
            string CorrectPhoneNumber = string.Empty;
            try
            {
                if (PhoneNo.Trim() != string.Empty && PhoneNo.Length == 13 && PhoneNo != null)
                {
                    string[] PhoneParts = PhoneNo.Split('-');
                    string FirstPart = PhoneParts[0].ToString().Trim();

                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PhoneNumberTypes.Code".Trim(),
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = FirstPart,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    phoneNumberTypeList = dal.GetByCriteria<PhoneNumberType>(query);
                    if (phoneNumberTypeList.Count > 0)
                    {
                        CorrectPhoneNumber = "Yes";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return CorrectPhoneNumber;
        }

        private void Clear()
        {
            try
            {
                internship = new Internship();
                pictureBox.Image = pictureBox.InitialImage;
                cboInternshipType.Items.Clear();
                cboInternshipType.Text = string.Empty;
                txtIDNumber.Clear();
                txtStaffID.Clear();
                txtSurname.Clear();
                txtOtherName.Clear();
                dateDOB.ResetText();
                txtAreaOfStudy.Clear();
                txtInstitutionAttended.Clear();
                cboGender.Items.Clear();
                cboGender.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                cboZone.Items.Clear();
                dateStartDate.ResetText();
                dateEndDate.ResetText();
                dateReportingDate.ResetText();
                cboMaritalStatus.Items.Clear();
                cboMaritalStatus.Text = string.Empty;
                editMode = false;
                label13.Text = "New Internship / Attachment";
                txtMobileNumber.Clear();
                txtAddress.Clear();
                staffIDtxt.Clear();
                nametxt.Clear();
                numericYear.Value = 0;
                getStaffFingerPrints();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void InternshipNewForm_Load(object sender, EventArgs e)
        {
            try
            {
                getPermissions = GlobalData.CheckPermissions(2);
                btnSave.Enabled = getPermissions.CanAdd;
                btnView.Enabled = getPermissions.CanView;

                //GlobalData.assignControls(this);
                this.Text = GlobalData.Caption;
                this.company = dal.GetAll<Company>()[0];
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGender_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGender.Items.Clear();
                foreach (GenderGroups item in Enum.GetValues(typeof(GenderGroups)))
                {
                    if (item != GenderGroups.All && item != GenderGroups.None)
                    {
                        cboGender.Items.Add(item);
                    }                     
                }
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboMaritalStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboMaritalStatus.Items.Clear();
                foreach (MaritalStatusGroups item in Enum.GetValues(typeof(MaritalStatusGroups)))
                {
                    if (item != MaritalStatusGroups.None)
                    {
                        cboMaritalStatus.Items.Add(item);
                    }                   
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboInternshipType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboInternshipType.Items.Clear();
                internshipTypes = dal.GetAll<InternshipType>();
                foreach (InternshipType internshipType in internshipTypes)
                {
                    cboInternshipType.Items.Add(internshipType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
                departments = dal.GetAll<Department>();
                foreach (Department department in departments)
                {
                    cboDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.Items.Clear();
                zones = dal.GetAll<Zone>();
                foreach (Zone zone in zones)
                {
                    cboZone.Items.Add(zone.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboDepartment.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    cboUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }  
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog pictureDialog = new OpenFileDialog();
                pictureDialog.Multiselect = false;
                pictureDialog.RestoreDirectory = true;
                pictureDialog.Title = "Select A Picture";
                pictureDialog.AutoUpgradeEnabled = true;
                pictureDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                pictureDialog.Filter = "Image Files(*.JPE;*.JPEG;*.JFIF;*.JPG;*.EXIF;*.TIFF;*.TIF;*.PAW;*.PNG;*.GIF;*.BMP;*.PPM;*.PGM;*.PBM;*.PNM;*.CGM;*.SVG)|*.JPE;*.JPEG;*.JFIF;*.JPG;*.EXIF;*.TIFF;*.TIF;*.PAW;*.PNG;*.GIF;*.BMP;*.PPM;*.PGM;*.PBM;*.PNM;*.CGM;*.SVG|All Files(*.*)|*.*";
                pictureDialog.CheckFileExists = true;
                if (pictureDialog.ShowDialog(this) == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(pictureDialog.FileName);
                    pictureBox.Image = resizeImage(pictureBox.Image, new Size(100, 100));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            try
            {
                //Get the image current width
                int sourceWidth = imgToResize.Width;
                //Get the image current height
                int sourceHeight = imgToResize.Height;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;
                //Calulate  width with new desired size
                nPercentW = ((float)size.Width / (float)sourceWidth);
                //Calculate height with new desired size
                nPercentH = ((float)size.Height / (float)sourceHeight);

                if (nPercentH < nPercentW)
                    nPercent = nPercentH;
                else
                    nPercent = nPercentW;
                //New Width
                int destWidth = (int)(sourceWidth * nPercent);
                //New Height
                int destHeight = (int)(sourceHeight * nPercent);
                Bitmap b = new Bitmap(destWidth, destHeight);
                try
                {
                    Graphics g = Graphics.FromImage((System.Drawing.Image)b);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    // Draw image with new width and height
                    g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
                    g.Dispose();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    throw ex;
                }
                return (System.Drawing.Image)b;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    staffIDtxt.Text = searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString();
                    nametxt.Text = searchGrid.CurrentRow.Cells["gridName"].Value.ToString();
                    searchGrid.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (nametxt.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        int ctr = 0;
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
                        employeeList = dal.LazyLoadCriteria<Employee>(query);
                        foreach (Employee employee in employeeList)
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                            {
                                found = true;
                                searchGrid.Rows.Add(1);
                                searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                staffCode = employee.ID;
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
                            searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 21);
                            searchGrid.BringToFront();
                            searchGrid.Visible = true;
                        }
                        else
                        {
                            searchGrid.Visible = false;
                        }
                    }
                }
                else
                {
                    ClearStaff();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Search by Staff Name cannot be completed");
            }
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
                        staffErrorProvider.Clear();
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
                        employeeList = dal.LazyLoadCriteria<Employee>(query);
                        if (employeeList.Count > 0)
                        {
                            foreach (Employee employee in employeeList)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    staffCode = employee.ID;
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
                    ClearStaff();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }


        private void ClearStaff()
        {
            try
            {
                nametxt.Clear();
                staffIDtxt.Clear();
                staffIDtxt.Select();
                searchGrid.Visible = false;
                staffCode = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDNumber.Text.Trim() != string.Empty)
                {
                    internship.IDNumber = txtIDNumber.Text.Trim();
                    internship = dal.ShowImageByStaffID<Internship>(internship);
                    if (internship.ID != 0)
                    {
                        if (internship.Photo != null)
                        {
                            pictureBox.Image = internship.Photo;
                        }
                        else
                        {
                            MessageBox.Show("Image is not uploaded for the Intern");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ID Number Not Found");
                    }
                }
                else
                {
                    MessageBox.Show("ID Number is Empty,Please Enter the ID Number");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            frmCameraCapture c = new frmCameraCapture();
            c.ShowDialog(this);
            if (c.ImageToUse != null)
            {
                pictureBox.Image = c.ImageToUse;
            }
            c.Close();
        }

        private void btnRefreshFingers_Click(object sender, EventArgs e)
        {
            getStaffFingerPrints(); 

        }

        private void btnDeleteFinger_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridFingerprints.CurrentRow != null && !gridFingerprints.CurrentRow.IsNewRow)
                {
                    if (MessageBox.Show("Do you want to permanently delete the Selected Fingerprint Template?\n", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int ID = int.Parse(gridFingerprints.CurrentRow.Cells["ID"].Value.ToString());

                        mineObj.DeleteFingerPrintTemplate(ID);
                        gridFingerprints.Rows.RemoveAt(gridFingerprints.Rows.IndexOf(gridFingerprints.CurrentRow));
                        gridFingerprints.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Remove The Record,Please See the System Administrator");
            }
        }

        private void btnEnrollNewFinger_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(internship.StaffID) || string.IsNullOrEmpty(internship.Surname))
            {
                MessageBox.Show("Sorry! You can only enroll already existing employees.\nPlease save details first");
            }
            else
            {
                EnrollFingerTemplate tmp = new EnrollFingerTemplate(internship.ID,internship.StaffID, "INTERN" ,string.Format("{0} {1}", internship.Surname, internship.OtherName), getAlreadyEnrolledFingers());
                DialogResult response = tmp.ShowDialog();
                if (response == DialogResult.OK)
                {
                    ctr = gridFingerprints.Rows.Count;
                    if (tmp.template.TmpLength > 0)
                    {
                        gridFingerprints.Rows.Add(1);

                        gridFingerprints.Rows[ctr].Cells["ID"].Value = tmp.template.ID;
                        gridFingerprints.Rows[ctr].Cells["fingerType"].Value = tmp.template.FingerTypeText;
                        gridFingerprints.Rows[ctr].Cells["templateLength"].Value = tmp.template.TmpLength;
                        gridFingerprints.Rows[ctr].Cells["dateCreated"].Value = DateTime.UtcNow;

                    }

                }
            }

        }

        private string[] getAlreadyEnrolledFingers()
        {
            List<string> itms = new List<string>();
            foreach (DataGridViewRow row in gridFingerprints.Rows)
            {
                if (null != row.Cells["fingerType"].Value)
                {
                    itms.Add(row.Cells["fingerType"].Value.ToString());
                }
            }

            return itms.ToArray();
        }

        public void getStaffFingerPrints()
        {
            gridFingerprints.Rows.Clear();

            staffFingerprintTemplates = mineObj.getStaffFingerprints(internship.StaffID);

            ctr = 0;
            foreach (StaffFingerprintTemplates temp in staffFingerprintTemplates)
            {
                gridFingerprints.Rows.Add(1);

                gridFingerprints.Rows[ctr].Cells["ID"].Value = temp.ID;
                gridFingerprints.Rows[ctr].Cells["fingerType"].Value = temp.FingertypeText;
                gridFingerprints.Rows[ctr].Cells["templateLength"].Value = temp.TempLen;
                gridFingerprints.Rows[ctr].Cells["dateCreated"].Value = temp.CreatedDate;

                ctr++;
            }
        }

        private void fillFingerTypes()
        {
            //gridFingerprints.Columns["fingerType"].
            fingerType.Items.Clear();

            DataTable tbl = mineObj.getFingerTypes(-1);

            foreach (DataRow r in tbl.Rows)
            {
                fingerType.Items.Add(r["FingerType"].ToString());
            }
            //fingerType.DataPropertyName = "ZktecMask";
            //fingerType.DisplayMember = "FingerType";
            //fingerType.ValueMember = "ZktecMask";
            //fingerType.DataSource = tbl;          

        }

        private void InternshipNewForm_Shown(object sender, EventArgs e)
        {
            getStaffFingerPrints();
        }

    }
}
