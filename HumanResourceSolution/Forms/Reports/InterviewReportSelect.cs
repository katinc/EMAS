using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using eMAS.Forms.PayRollProcessing;

namespace eMAS.Forms.Reports
{
    public partial class InterviewReportSelect : Form
    {
        private IDAL dal;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Vacancy> vacancies;
        private IList<AppointmentType> appointmentTypes;
        private Form reportForm;
        private Company company;
        private int ctr;

        public InterviewReportSelect()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.departments = new List<Department>();
                this.vacancies = new List<Vacancy>();
                this.appointmentTypes = new List<AppointmentType>();
                this.company = new Company();
                this.ctr = 0;
                this.reportForm = new Form();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboAppointmentType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAppointmentType.Items.Clear();
                cboAppointmentType.Text = string.Empty;
                cboAppointmentType.Items.Add("All");
                appointmentTypes = dal.GetAll<AppointmentType>();
                foreach (AppointmentType zone in appointmentTypes)
                {
                    cboAppointmentType.Items.Add(zone.Description);
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
                cboDepartment.Text = string.Empty;
                cboDepartment.Items.Add("All");
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

        void cboInterviewStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboInterviewStatus.Items.Clear();
                cboInterviewStatus.Items.Add("Employed");
                cboInterviewStatus.Items.Add("Rejected");
                cboInterviewStatus.Items.Add("Review");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboGrade_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGrade.Items.Clear();
                vacancies = dal.GetAll<Vacancy>();
                foreach (Vacancy vacancy in vacancies)
                {
                    cboGrade.Items.Add(vacancy.Grade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void cboApplicationStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboApplicationStatus.Items.Clear();
                cboApplicationStatus.Items.Add("Open");
                cboApplicationStatus.Items.Add("Close");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Options could not be loaded");
            }
        }

        private void Clear()
        {
            try
            {
                ClearStaff();
                cboInterviewStatus.Items.Clear();
                cboDepartment.Items.Clear();
                cboApplicationStatus.Items.Clear();
                cboGrade.Items.Clear();
                cboApplicationStatus.Items.Clear();
                staffErrorProvider.Clear();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ClearStaff()
        {
            try
            {
                staffErrorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                MessageBox.Show("Error:The form cannot close");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
    
            try
            {
                if (reportForm != null && !reportForm.IsDisposed)
                {
                    reportForm.Close();
                }

                reportForm = new InterviewReportForm(nametxt.Text.Trim(), cboAppointmentType.Text.Trim(), datePickerFrom.Checked, datePickerTo.Checked, datePickerFrom.Value, datePickerTo.Value, cboDepartment.Text.Trim(), cboGrade.Text.Trim(), cboApplicationStatus.Text.Trim(), cboInterviewStatus.Text.Trim());
                reportForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void InterviewReportSelect_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                datePickerFrom.Value = DateTime.Today.Date;
                datePickerFrom.Checked = false;
                datePickerTo.Value = DateTime.Today.Date;
                datePickerTo.Checked = false;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
    }
}
