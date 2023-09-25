using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using Session_Framework;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class WorkshopEntryForm : Form
    {
        private ExternalTrainingForm parentForm;
        private Workshop workshop;
        private IList<Qualification> lstCourses;
        private IList<Country> lstCountries;
        private IList<AttendedSchool> lstSchools;
        private DALHelper dalHelper;

        private QualificationDataMapper courseDataMapper;
        private CountryDataMapper countryDataMapper;
        private AttendedSchoolDataMapper schoolDataMapper;
        private WorkshopDataMapper workshopMapper;
        public WorkshopEntryForm()
        {
            InitializeComponent();
            this.parentForm =new ExternalTrainingForm();
            this.workshop=new Workshop();
            lstCountries = new List<Country>();
            lstCourses = new List<Qualification>();
            lstSchools = new List<AttendedSchool>();
            dalHelper = new DALHelper();
            courseDataMapper = new QualificationDataMapper();
            countryDataMapper = new CountryDataMapper();
            schoolDataMapper = new AttendedSchoolDataMapper();
            workshopMapper = new WorkshopDataMapper();
        }
        public WorkshopEntryForm(ExternalTrainingForm parentForm,Workshop workshop)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.workshop = workshop;
            lstCountries = new List<Country>();
            lstCourses = new List<Qualification>();
            lstSchools = new List<AttendedSchool>();
            dalHelper = new DALHelper();
            courseDataMapper = new QualificationDataMapper();
            countryDataMapper = new CountryDataMapper();
            schoolDataMapper = new AttendedSchoolDataMapper();
            workshopMapper = new WorkshopDataMapper();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbCourses.SelectedIndex = -1;
            cmbCourses.Text = string.Empty;

            cmbCountries.SelectedIndex = -1;
            cmbCountries.Text = string.Empty;

            cmbSchool.SelectedIndex = -1;
            cmbSchool.Text = string.Empty;

            txtVenue.Clear();
            dtpEndDate.ResetText();
            dtpStartDate.ResetText();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            string error;
            if (cmbCourses.Text == string.Empty)
            {
                error = "Course Is Required!";
                errorProvider1.SetError(cmbCourses, error);
            }
            else if (cmbCountries.Text == string.Empty)
            {
                error = "Country Is Required!";
                errorProvider1.SetError(cmbCountries, error);
            }
            else if (cmbSchool.Text == string.Empty)
            {
                error = "School Is Required!";
                errorProvider1.SetError(cmbSchool, error);
            }
            else if (txtVenue.Text == string.Empty)
            {
                error = "Venue Is Required!";
                errorProvider1.SetError(txtVenue, error);
            }
            else if (dtpStartDate.Value>dtpEndDate.Value)
            {
                error = "Start Date Cannot Be Greater Than The End Date!";
                errorProvider1.SetError(dtpStartDate, error);
            }
            else if(cmbCourses.SelectedItem==null)
            {
                error = "Select A Valid Course!";
                errorProvider1.SetError(cmbCourses, error);
            }
            else if (cmbCountries.SelectedItem == null)
            {
                error = "Select A Valid Country!";
                errorProvider1.SetError(cmbCountries, error);
            }
            else if (cmbSchool.SelectedItem == null)
            {
                error = "Select A Valid School!";
                errorProvider1.SetError(cmbSchool, error);
            }
            else 
            {
                try
                {
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@staffId", parentForm.selectedEmployee.ID, DbType.Int32);
                dalHelper.CreateParameter("@courseId", lstCourses[cmbCourses.SelectedIndex].ID, DbType.Int32);
                dalHelper.CreateParameter("@schoolId", lstSchools[cmbSchool.SelectedIndex].Id, DbType.Int32);
                dalHelper.CreateParameter("@countryId", lstCountries[cmbCountries.SelectedIndex].ID, DbType.Int32);
                dalHelper.CreateParameter("@venue", txtVenue.Text, DbType.String);
                dalHelper.CreateParameter("@startDate", dtpStartDate.Value.Date, DbType.Date);
                dalHelper.CreateParameter("@endDate", dtpEndDate.Value.Date, DbType.Date);
                dalHelper.CreateParameter("@active", chkActive.Checked, DbType.Boolean);
                

                if(workshop==null || workshop.Id==0){
                    dalHelper.CreateParameter("@entryDate", DateTime.Now.Date, DbType.Date);
                    dalHelper.CreateParameter("@archived", false, DbType.Boolean);
                    dalHelper.ExecuteNonQuery("insert into workshops (staffId,courseId,schoolId,countryId,venue,entryDate,startDate,endDate,active,archived) values(@staffId,@courseId,@schoolId,@countryId,@venue,@entryDate,@startDate,@endDate,@active,@archived)");
                    
                }
                else
                {
                    dalHelper.CreateParameter("@Id", workshop.Id, DbType.Int32);
                    dalHelper.ExecuteNonQuery("update workshops set staffId=@staffId,courseId=@courseId,schoolId=@schoolId,countryId=@countryId,venue=@venue,startDate=@startDate,active=@active where id=@Id");

                }


                    if (workshop == null || workshop.Id == 0)
                    {
                        parentForm.fillWorkshops();
                        btnClear_Click(sender, e);
                    }
                    else
                    {
                      workshop=  workshopMapper.getById(workshop.Id);
                      parentForm.updateWorkshopRow(parentForm.gridWorkshops.SelectedRows[0],workshop);
                       
                    }
                    
                }
                catch (Exception xi) { Logger.LogError(xi); }
            }
        }

        private void cmbCourses_DropDown(object sender, EventArgs e)
        {
            cmbCourses.Items.Clear();
            try
            {
                lstCourses = courseDataMapper.GetAllASRaw();
                cmbCourses.Items.Clear();
                foreach (Qualification qualification in lstCourses)
                {
                    cmbCourses.Items.Add(qualification.CertificateObtained);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
          
        }

        private void cmbCountries_DropDown(object sender, EventArgs e)
        {
            cmbCountries.Items.Clear();
          
            try
            {
                lstCountries = countryDataMapper.GetAll();
                foreach (Country country in lstCountries)
                {
                    cmbCountries.Items.Add(country.Description);
                }
            }
            catch (Exception xi) { }
          
        }

      

        private void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVenue.Clear();
            if (workshop == null || workshop.Id == 0)
            {
                if (cmbSchool.SelectedItem != null)
                {
                    txtVenue.Text = lstSchools[cmbSchool.SelectedIndex].Location;
                }
            }
            
        }

        private void WorkshopEntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (workshop != null || workshop.Id > 0)
                {
                    cmbCourses_DropDown(this, EventArgs.Empty);
                    cmbCourses.SelectedItem = workshop.Course.CertificateObtained;

                    cmbCountries_DropDown(this, EventArgs.Empty);
                    cmbCountries.SelectedItem = workshop.Country.Description;

                   cmbSchool_DropDown(this, EventArgs.Empty);
                    cmbSchool.SelectedItem = workshop.School.Description;

                    txtVenue.Text = workshop.Venue;
                    dtpStartDate.Value = workshop.StartDate;
                    dtpEndDate.Value = workshop.EndDate;
                }
            }
            catch (Exception xi) { }
           
        }

        private void cmbCountries_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbSchool_DropDown(object sender, EventArgs e)
        {
            cmbSchool.Items.Clear();
            try
            {
                lstSchools.Clear();

                lstSchools = schoolDataMapper.getByCountryId(lstCountries[cmbCountries.SelectedIndex].ID);
                foreach (var school in lstSchools)
                {
                    cmbSchool.Items.Add(school.Description);
                }
            }
            catch (Exception e1) { }
        }

       
    }
}
