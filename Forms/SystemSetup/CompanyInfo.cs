using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic;


namespace eMAS.Forms.SystemSetup
{
    public partial class CompanyInfo : Form
    {
        private IDAL dal;
        private DALHelper dalHelper;
        private Company company;
        private IList<HealthFacilityType> facilityTypes;
        private IList<HealthFacilityOwnership> facilityOwnerships;
        private IList<Country> countries;
        private IList<District> districts;
        private IList<HRBussinessLayer.System_Setup_Class.Region> regions;
        private IList<Town> towns;
        private District district;
        private Town town;
        //private DataReference.hrContextDataContext _context = new DataReference.hrContextDataContext();

        public Permissions permissions;

        public CompanyInfo()
        {
            this.InitializeComponent();
            this.dalHelper = new DALHelper();
            this.dal = new DAL();
            this.company = new Company();
            this.facilityTypes = new List<HealthFacilityType>();
            this.facilityOwnerships = new List<HealthFacilityOwnership>();
            this.countries = new List<Country>();
            this.regions = new List<HRBussinessLayer.System_Setup_Class.Region>();
            this.districts = new List<District>();
            this.towns = new List<Town>();
            this.town = new Town();
            this.district = new District();
        }

        void calculatedOnComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                calculatedOnComboBox.Items.Clear();
                calculatedOnComboBox.Items.Add("Basic Salary");
                calculatedOnComboBox.Items.Add("Net Salary");
                calculatedOnComboBox.Items.Add("Take Home");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void typeComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                typeComboBox.Items.Clear();
                typeComboBox.Items.Add("Fixed");
                typeComboBox.Items.Add("Rate");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void salaryPaymentUnitComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                salaryPaymentUnitComboBox.Items.Clear();
                salaryPaymentUnitComboBox.Items.Add("Month");
                salaryPaymentUnitComboBox.Items.Add("2 Weeks");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void frequencyComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                frequencyComboBox.Items.Clear();
                frequencyComboBox.Items.Add("Weekly");
                frequencyComboBox.Items.Add("BiWeekly");
                frequencyComboBox.Items.Add("Monthly");
                frequencyComboBox.Items.Add("Yearly");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void paymentUnitComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                wagePaymentUnitComboBox.Items.Clear();
                wagePaymentUnitComboBox.Items.Add("Hour");
                wagePaymentUnitComboBox.Items.Add("Day");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void CompanyInfo_Load(object sender, EventArgs e)
        {
            try
            {
                //GlobalData.assignControls(this);
                if (GlobalData.User.UserName.Trim().ToLower() == "admin")
                {
                    btnDev.Visible = true;
                }

                //MessageBox.Show(GlobalData.GetLastDayOfMonth("June").ToString());
                this.Text = GlobalData.Caption;
                GetAll();
                btnView_Click(sender, e);


                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                permissions = GlobalData.CheckPermissions(2);
                savebtn.Enabled = permissions.CanAdd;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetAll()
        {
            try
            {
                company = dal.GetAll<Company>()[0];
                //cbAutomaticPromotion.Checked = company.AutomaticPromotionFlag;
                nametextBox.Text = company.Name;
                postalAddressTextBox.Text = company.PostalAddress;
                emailAddressTextBox.Text = company.EmailAddress;
                webSiteTextBox.Text = company.Website;
                contactNoTextBox.Text = company.ContactNos;
                faxNosTextBox.Text = company.FaxNos;
                countryComboBox_DropDown(this, EventArgs.Empty);
                countryComboBox.Text = company.Country.Description;
                regionComboBox_DropDown(this, EventArgs.Empty);
                regionComboBox.Text = company.Region.Description;
                regionComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                districtComboBox.Text = company.District.Description;
                districtComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                townComboBox.Text =company.Town.Description;
                cboFacilityType_DropDown(this, EventArgs.Empty);
                cboFacilityType.Text = company.FacilityType.Description;
                cboOwnershipType_DropDown(this, EventArgs.Empty);
                cboOwnershipType.Text = company.OwnershipType.Description;
                dateEstablishedPicker.Text = company.DateEstabished.Value.ToString();
                checkBoxIsSalaryStructure.Checked = company.IsSalaryStructure;
                numericUpDownMinimumCharacter.Value = company.MinimumCharacter;
                numericUpDownPINMinimumCharacter.Value = company.PINMinimumCharacter;
                mottoTextBox.Text = company.Motto;
                pictureBox.Image = company.Logo;

                if (company.Wage)
                {
                    wageGroupBox.Visible = true;
                    wageCheckBox.Checked = company.Wage;
                    wagePaymentUnitComboBox.Items.Add(company.WagePaymentUnit);
                    wagePaymentUnitComboBox.Text = company.WagePaymentUnit;
                    minimumWageNumbericUpDown.Value = company.MinimumWage;
                }
                else
                {
                    wageGroupBox.Visible = false;
                    wageCheckBox.Checked = false;
                    wagePaymentUnitComboBox.Items.Clear();
                    wagePaymentUnitComboBox.Text = string.Empty;
                    minimumWageNumbericUpDown.ResetText();
                }
                if (company.Salary)
                {
                    salaryGroupBox.Visible = true;
                    salaryCheckBox.Checked = company.Salary;
                    salaryPaymentUnitComboBox.Items.Add(company.SalaryPaymentUnit);
                    salaryPaymentUnitComboBox.Text = company.SalaryPaymentUnit;
                    minimumSalaryNumbericUpDown.Value = company.MinimumSalary;
                    checkBoxIsSalaryStructure.Checked = company.IsSalaryStructure;
                }
                else
                {
                    salaryGroupBox.Visible = false;
                    salaryCheckBox.Checked = false;
                    salaryPaymentUnitComboBox.Items.Clear();
                    salaryPaymentUnitComboBox.Text = string.Empty;
                    minimumSalaryNumbericUpDown.ResetText();
                    checkBoxIsSalaryStructure.Checked = false;
                }

                if (company.OverTime)
                {
                    overTimeGroupBox.Visible = true;
                    overTimeCheckBox.Checked = company.OverTime;
                    if (company.OverTimeType.Trim().ToLower() == "rate")
                    {
                        percentageLabel.Visible = true;
                        calculatedOnComboBox.Visible = true;
                        calculatedOnLabel.Visible = true;
                        calculatedOnComboBox.Items.Add(company.CalulatedOn);
                        calculatedOnComboBox.Text = company.CalulatedOn;
                        amountLabel.Text = "Rate";
                    }
                    else
                    {
                        percentageLabel.Visible = false;
                        calculatedOnComboBox.Visible = false;
                        calculatedOnLabel.Visible = false;
                        calculatedOnComboBox.Items.Clear();
                        calculatedOnComboBox.Text = string.Empty;
                        calculatedOnComboBox.Visible = false;
                        amountLabel.Text = "Amount";
                    }
                    typeComboBox.Items.Add(company.OverTimeType);
                    typeComboBox.Text = company.OverTimeType;
                    amountNumericUpDown.Value = company.OverTimeAmount;
                    minimumOvertimeNumericUpDown.Value = company.MinimumOverTime;
                    
                }
                else
                {
                    overTimeGroupBox.Visible = false;
                    overTimeCheckBox.Checked = false;
                    minimumOvertimeNumericUpDown.ResetText();
                    typeComboBox.Items.Clear();
                    typeComboBox.Text = string.Empty;
                    calculatedOnLabel.Visible = false;
                    calculatedOnComboBox.Visible = false;
                }

                var combo = GlobalData._context.UserAuthenticationSetups.ToList();
                cboAuth.DataSource = combo;
                cboAuth.ValueMember = "Code";
                cboAuth.DisplayMember = "Description";

                var getselected = GlobalData._context.UserAuthenticationSetups.SingleOrDefault(u => u.Code == company.AuthenticationType);
                if (getselected != null)
                {
                    cboAuth.Text = getselected.Description;
                }

                pensionMaleNumericUpDown.Value = company.PensionAgeMale;
                pensionfemaleNumericUpDown.Value = company.PensionAgeFemale;
                minimumAgeNumericUpDown.Value = company.MinimumEmployeeAge;
                maximumAgeNumericUpDown.Value = company.MaximumEmployeeAge;
                frequencyComboBox.Items.Add(company.PaymentFrequency);
                frequencyComboBox.Text = company.PaymentFrequency;
                ssnitRegNoTextBox.Text = company.SSNITRegistrationNo;
                checkBoxIsFileNumber.Checked = company.IsFileNumber;

                cmbPayslipFormat.Text = company.PayslipFormat;

                txtActualDutyAllowanceRate.Text = company.DutyAllowanceRate.ToString();

                

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                postalAddressTextBox.Clear();
                emailAddressTextBox.Clear();
                webSiteTextBox.Clear();
                contactNoTextBox.Clear();
                contactNoTextBox.Clear();
                faxNosTextBox.Clear();
                countryComboBox.Items.Clear();
                countryComboBox.Text = string.Empty;
                regionComboBox.Items.Clear();
                regionComboBox.Text = string.Empty;
                districtComboBox.Items.Clear();
                districtComboBox.Text = string.Empty;
                townComboBox.Items.Clear();
                townComboBox.Text = string.Empty;
                dateEstablishedPicker.ResetText();
                mottoTextBox.Clear();
                pictureBox.Image = null;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }
        private void UpdateCompanyEntity()
        {
            try
            {
                company.Name = nametextBox.Text;
                company.PostalAddress = postalAddressTextBox.Text;
                company.EmailAddress = emailAddressTextBox.Text;
                company.Website = webSiteTextBox.Text;
                company.ContactNos = contactNoTextBox.Text;
                company.FaxNos = faxNosTextBox.Text;
                if(cboAuth.Text.Trim() == string.Empty)
                {
                    company.AuthenticationType = 1;
                }
                else
                {
                    company.AuthenticationType = (int)cboAuth.SelectedValue;
                }
                if (countryComboBox.Text.Trim() == string.Empty)
                {
                    company.Country.ID = 0;
                }
                else
                {
                    company.Country.ID = countries[countryComboBox.SelectedIndex].ID;
                }
                if (regionComboBox.Text.Trim() == string.Empty)
                {
                    company.Region.ID = 0;
                }
                else
                {
                    company.Region.ID = regions[regionComboBox.SelectedIndex].ID;
                }
                if (districtComboBox.Text.Trim() == string.Empty)
                {
                    company.District.ID = 0;
                }
                else
                {
                    company.District.ID = districts[districtComboBox.SelectedIndex].ID;
                }
                if (townComboBox.Text.Trim() == string.Empty)
                {
                    company.Town.ID = 0;
                }
                else
                {
                    company.Town.ID = towns[townComboBox.SelectedIndex].ID;
                }
                
                
                if (cboFacilityType.Text.Trim() == string.Empty)
                {
                    company.FacilityType.ID = 0;
                }
                else
                {
                    company.FacilityType.ID = facilityTypes[cboFacilityType.SelectedIndex].ID;
                }

                if (cboOwnershipType.Text.Trim() == string.Empty)
                {
                    company.OwnershipType.ID = 0;
                }
                else
                {
                    company.OwnershipType.ID = facilityOwnerships[cboOwnershipType.SelectedIndex].ID;
                }
                company.DateEstabished = DateTime.Parse(dateEstablishedPicker.Text);
                company.Motto = mottoTextBox.Text;

                if (pictureBox.Image == null)
                {
                    company.Logo = pictureBox.InitialImage;
                }
                else
                {
                    company.Logo = pictureBox.Image;
                }

                company.DutyAllowanceRate = txtActualDutyAllowanceRate.Text != string.Empty ? Convert.ToDecimal(txtActualDutyAllowanceRate.Text) : 0;

                company.Wage = wageCheckBox.Checked;
                company.WagePaymentUnit = wagePaymentUnitComboBox.Text;
                company.MinimumWage = minimumWageNumbericUpDown.Value;

                company.Salary = salaryCheckBox.Checked;
                company.SalaryPaymentUnit = salaryPaymentUnitComboBox.Text;
                company.MinimumSalary = minimumSalaryNumbericUpDown.Value;
                company.MinimumCharacter = (int)numericUpDownMinimumCharacter.Value;
                company.PINMinimumCharacter = (int)numericUpDownPINMinimumCharacter.Value;
                company.IsSalaryStructure = checkBoxIsSalaryStructure.Checked;

                company.MaximumEmployeeAge = (int)maximumAgeNumericUpDown.Value;
                company.MinimumEmployeeAge = (int)minimumAgeNumericUpDown.Value;
                company.PensionAgeMale = (int)pensionMaleNumericUpDown.Value;
                company.PensionAgeFemale = (int)pensionfemaleNumericUpDown.Value;

                company.PaymentFrequency = frequencyComboBox.Text;

                company.OverTime = overTimeCheckBox.Checked;
                company.OverTimeType = typeComboBox.Text;
                company.OverTimeAmount = amountNumericUpDown.Value;
                company.MinimumOverTime = minimumOvertimeNumericUpDown.Value;
                company.CalulatedOn = calculatedOnComboBox.Text;
                company.SSNITRegistrationNo = ssnitRegNoTextBox.Text;
                company.IsFileNumber = checkBoxIsFileNumber.Checked;

                company.PayslipFormat = cmbPayslipFormat.Text;
                //company.AutomaticPromotionFlag = cbAutomaticPromotion.Checked;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    
                    UpdateCompanyEntity();
                    dal.Update(company);
                    this.Close();
                    
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {               
                errorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }


        private void wageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (wageCheckBox.Checked == true)
                {
                    wageGroupBox.Visible = true;
                }
                else
                {
                    wageGroupBox.Visible = false;
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
                    pictureBox.Image = resizeImage(pictureBox.Image, new Size(80, 80));
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

        private void salaryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (salaryCheckBox.Checked)
                {
                    salaryGroupBox.Visible = true;
                }
                else
                {
                    salaryGroupBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void overTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (overTimeCheckBox.Checked)
                {
                    overTimeGroupBox.Visible = true;
                }
                else
                {
                    overTimeGroupBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                amountNumericUpDown.ResetText();
                if (typeComboBox.Text.Trim() == "Fixed")
                {
                    amountLabel.Text = "Amount";
                    percentageLabel.Visible = false;
                    calculatedOnComboBox.Visible = false;
                    calculatedOnLabel.Visible = false;
                }
                else
                {
                    amountLabel.Text = "Rate";
                    percentageLabel.Visible = true;
                    calculatedOnComboBox.Visible = true;
                    calculatedOnLabel.Visible = true;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cboFacilityType_DropDown(object sender, EventArgs e)
        {
            try
            {
                facilityTypes = dal.GetAll<HealthFacilityType>();
                cboFacilityType.Items.Clear();
                cboFacilityType.Text = string.Empty;
                foreach (HealthFacilityType facilityType in facilityTypes)
                {
                    cboFacilityType.Items.Add(facilityType.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboOwnershipType_DropDown(object sender, EventArgs e)
        {
            try
            {
                facilityOwnerships = dal.GetAll<HealthFacilityOwnership>();
                cboOwnershipType.Items.Clear();
                cboOwnershipType.Text = string.Empty;
                foreach (HealthFacilityOwnership facilityOwnership in facilityOwnerships)
                {
                    cboOwnershipType.Items.Add(facilityOwnership.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void countryComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                countries = dal.GetAll<Country>();
                countryComboBox.Items.Clear();
                countryComboBox.Text = string.Empty;
                foreach (Country country in countries)
                {
                    countryComboBox.Items.Add(country.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void regionComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                regions = dal.GetAll<HRBussinessLayer.System_Setup_Class.Region>();
                regionComboBox.Items.Clear();
                regionComboBox.Text = string.Empty;
                foreach (HRBussinessLayer.System_Setup_Class.Region region in regions)
                {
                    regionComboBox.Items.Add(region.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void regionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {              
                districts = dal.GetByRegion<District>(regionComboBox.SelectedItem.ToString());
                districtComboBox.Items.Clear();
                districtComboBox.Text = string.Empty;
                foreach (District district in districts)
                {
                    districtComboBox.Items.Add(district.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void districtComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "TownView.District",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = districtComboBox.SelectedItem.ToString(),
                    CriteriaOperator = CriteriaOperator.And
                });
                towns = dal.GetByCriteria<Town>(query);
                townComboBox.Items.Clear();
                townComboBox.Text = string.Empty;
                foreach (Town town in towns)
                {
                    townComboBox.Items.Add(town.Description);
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
                company = dal.ShowImage<Company>();
                if (company != null)
                {
                    if (company.Logo != null)
                    {
                        pictureBox.Image = company.Logo;
                    }
                    else
                    {
                        MessageBox.Show("Image is not uploaded for Company");
                    }
                }
                else
                {
                    MessageBox.Show("CompanyInfo Not Found");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void cboAuth_DropDown(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch(Exception ex)
            {

            }
        }

        private void cboAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private string DeveloperPage()
        {

            string input = string.Empty;
            try
            {
                input = Interaction.InputBox("Enter admin password", "Developer", "Default");

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            return input;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = DeveloperPage();


                if (pass == GlobalData.Password)
                {
                    AdminForm form = new AdminForm();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Password, try again");
                }
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                
            }
        }

        private void cbAutomaticPromotion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (cbAutomaticPromotion.Checked == true && nametextBox.Text != string.Empty) // just to stop the error from being thrown when the form is loading
                {
                    //check requirements
                    //check if grades and gradecategories are setup 
                    if (!(GlobalData._context.GradeCategory_Setups.Count() > 0 && GlobalData._context.EmployeeGrades_Setups.Count() > 0))
                    {
                        MessageBox.Show("Please setup Grade Category and Grades for your Facility and try again.","Automatic Promotion Requirement");
                        cbAutomaticPromotion.Checked = false;
                        return;
                    }

                    //check if grade salaries are set up
                    if (!(GlobalData._context.GradeSalaries.Count() > 0))
                    {
                        MessageBox.Show("Please setup Salaries for your Facility and try again.", "Automatic Promotion Requirement");
                        cbAutomaticPromotion.Checked = false;
                        return;
                    }

                    //check if steps are setup
                    if (!(GlobalData._context.Steps.Count() > 0))
                    {
                        MessageBox.Show("Please setup Steps for your Facility and try again.", "Automatic Promotion Requirement");
                        cbAutomaticPromotion.Checked = false;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
            }
        }

        private void btnMapFields_Click(object sender, EventArgs e)
        {
            try
            {
                FieldMapping form = new FieldMapping();
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }
    }
}
