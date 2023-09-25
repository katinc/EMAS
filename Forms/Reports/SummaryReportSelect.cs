using eMAS.DataReference;
using eMAS.Forms.SystemSetup;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.Reports
{
    public partial class SummaryReportSelect : Form
    {
        private IList<Employee> employees;
        private IList<PayRollAttendance> payRollAttendances;
        private PayRollAttendance payRollAttendance;
        private IDAL dal;
        private Form reportForm;
        private IList<Company> company;
        private List<DataReference.StaffPersonalInfoView> userInfo;


        public SummaryReportSelect()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.employees = new List<Employee>();
            this.payRollAttendances = new List<PayRollAttendance>();
            this.payRollAttendance = new PayRollAttendance();
            this.dal.OpenConnection();
            this.reportForm = new Form();
            this.company = new List<Company>();
            this.userInfo = new List<StaffPersonalInfoView>();
        }



        private void SummaryReportSelect_Load(object sender, EventArgs e)
        {
            try
            {
                cboSummary.Items.Add("No. of Staff By Department");
                cboSummary.Items.Add("No. of Staff By Unit");
                cboSummary.Items.Add("No. of Staff By GradeCategory");
                cboSummary.Items.Add("No. of Staff By Grade");
                cboSummary.Items.Add("No. of Staff By Appointment Type");
                //cboSummary.Items.Add("Region");
                //cboSummary.Items.Add("Country");
                //cboSummary.Items.Add("Leave Entitlement");
                cboSummary.Items.Add("No. of Staff By Mechanised");
                //cboSummary.Items.Add("Bank");

                lblDepartment.Visible = false;
                cboDepartment.Visible = false;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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

                bool pieChart = clb.CheckedItems.Contains("Pie Chart");
                bool barChart = clb.CheckedItems.Contains("Bar Chart");
                bool doughnut = clb.CheckedItems.Contains("Doughnut");

                //load all user details 
                userInfo = GlobalData._context.StaffPersonalInfoViews.Where(u => u.Archived == false && u.Terminated == false && u.TransferredOut == false).ToList();

                if (cboSummary.Text == "No. of Staff By Department")
                {
                    var departmentsInfo = userInfo.Select(a => a.Department).Distinct().Count();
                    reportForm = new SummaryReportForm(cboSummary.Text, pieChart, barChart, doughnut, userInfo.Count, departmentsInfo);
                    reportForm.Show();
                }else if (cboSummary.Text == "No. of Staff By Unit")
                {
                    var unitsInfo = userInfo.Where(u => u.Department == cboDepartment.Text).Select(a => a.Unit).Distinct().Count();
                    reportForm = new SummaryReportFormUnit(cboDepartment.Text, pieChart, barChart, doughnut, userInfo.Where(a=>a.Department == cboDepartment.Text).Count(), unitsInfo);
                    reportForm.Show();
                }
                else if (cboSummary.Text == "No. of Staff By GradeCategory")
                {
                    //var gradeCategoryInfo = userInfo.Where(u => u.GradeCategory == cbosu.Text).Select(a => a.GradeCategory).Distinct().Count();
                    reportForm = new SummaryReportFormGradeCategory(pieChart, barChart, doughnut, userInfo.Select(a=> a.GradeCategory).Distinct().Count(), userInfo.Count);
                    reportForm.Show();
                }
                else if (cboSummary.Text == "No. of Staff By Grade")
                {
                    var gradesinfo = userInfo.Where(u => u.GradeCategory == cboDepartment.Text).Select(a => a.Grade).Distinct().Count();
                    reportForm = new SummaryReportFromGrade(cboDepartment.Text, pieChart, barChart, doughnut, userInfo.Where(a => a.GradeCategory == cboDepartment.Text).Count(), gradesinfo);
                    reportForm.Show();
                }
                else if (cboSummary.Text == "No. of Staff By Appointment Type")
                {
                    var appointmentInfo = userInfo.Select(a => a.AppointmentType).Distinct().Count();
                    reportForm = new SummaryReportFormAppointmentType(pieChart, barChart, doughnut, appointmentInfo, userInfo.Count);
                    reportForm.Show();
                }
                else if (cboSummary.Text == "No. of Staff By Mechanised")
                {
                    var mechanisedInfo = userInfo.Select(a => a.Mechanised).Distinct().Count();
                    reportForm = new SummaryReportFormMechanised(pieChart, barChart, doughnut, mechanisedInfo, userInfo.Count);
                    reportForm.Show();
                }
                //else if (cboSummary.Text == "")
                //{

                //}
                //else if (cboSummary.Text == "")
                //{

                //}
                //else if (cboSummary.Text == "")
                //{

                //}
                //else if (cboSummary.Text == "")
                //{

                //}
                //else if (cboSummary.Text == "")
                //{

                //}

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("There was an error, /n Kindly contact your Administrator", "Error");
            }
        }

        private void cboSummary_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();

                if (cboSummary.Text == "No. of Staff By Unit")
                {
                    //MessageBox.Show("Select a department to Summarise the count.");
                    errorProvider1.SetError(cboDepartment, "Select a department to Summarise the count.");
                    lblDepartment.Visible = true;
                    cboDepartment.Visible = true;
                    lblDepartment.Location = new Point(19, 85);
                    lblDepartment.Text = "Department :";

                    var departments = GlobalData._context.DDepartments.Where(u => u.Archived == false && u.Active == true).ToList();

                    foreach (var item in departments)
                    {
                        cboDepartment.Items.Add(item.Description);
                    }
                }
                else if (cboSummary.Text == "No. of Staff By Grade")
                {
                    //MessageBox.Show("Select a grade category to Summarise the count.");
                    errorProvider1.SetError(cboDepartment,"Select a grade category to Summarise the count.");
                    lblDepartment.Text = "Grade Category :";
                    lblDepartment.Location = new Point(3, 85);
                    lblDepartment.Visible = true;
                    cboDepartment.Visible = true;

                    var departments = GlobalData._context.GradeCategoryViews.Where(u => u.Archived == false && u.Active == true).ToList();

                    foreach (var item in departments)
                    {
                        cboDepartment.Items.Add(item.Description);
                    }
                }
                else
                {
                    lblDepartment.Visible = false;
                    cboDepartment.Visible = false;
                    errorProvider1.Clear();
                }
            }
            catch (Exception x)
            {
                Logger.LogError(x);
                AppUtils.ErrorMessageBox();
            }
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboDepartment.Text != null || cboDepartment.Text != string.Empty)
            {
                errorProvider1.Clear();
            }
        }

        private void btnChartSetup_Click(object sender, EventArgs e)
        {
            try
            {
                ChartSetup form = new ChartSetup();
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
            this.Close();
        }
    }
}
