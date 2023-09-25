using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;


namespace eMAS.Forms.Reports
{
    public partial class StaffProfileReportSelect : Form
    {
        private IList<Zone> zones;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IDAL dal;
        private Form reportForm;

        public StaffProfileReportSelect()
        {
            try
            {
                InitializeComponent();
                this.zones = new List<Zone>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.dal = new DAL();
                this.reportForm = new Form();
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void StaffProfileReportSelect_Load(object sender, EventArgs e)
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

        void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
                cboDepartment.Items.Add("All");
                departments=dal.GetAll<Department>();
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

        void cboGender_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGender.Items.Clear();
                cboGender.Items.Add("All");
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

        private void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.Items.Clear();
                cboZone.Text = string.Empty;
                cboZone.Items.Add("All");
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

        void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategories)
                {
                    cboGradeCategory.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cboGrade.Items.Add(employeeGrade.Grade);
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
                cboUnit.Items.Add("All");
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

        private void Clear()
        {
            try
            {
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboGrade.Items.Clear();
                cboZone.Items.Clear();
                cboZone.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGender.Items.Clear();
                cboGender.Text = string.Empty;
                cboProbation.Items.Clear();
                cboProbation.Text = string.Empty;
                datePickerFrom.Value = DateTime.Today.Date;
                datePickerFrom.Checked = false;
                datePickerTo.Value = DateTime.Today.Date;
                datePickerTo.Checked = false;
                datePickerFromAssumption.Value = DateTime.Now.Date;
                datePickerFromAssumption.Checked = false;
                datePickerFromDOFA.Value = DateTime.Now.Date;
                datePickerFromDOFA.Checked = false;
                datePickerToAssumption.Value = DateTime.Now.Date;
                datePickerToAssumption.Checked = false;
                datePickerToDOFA.Value = DateTime.Now.Date;
                datePickerToDOFA.Checked = false;
                if (reportForm != null && !reportForm.IsDisposed)
                {
                    reportForm.Close();
                }
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboFormat.Text.ToLower().Trim() == "format-1")
                {
                    if (reportForm != null && !reportForm.IsDisposed)
                    {
                        reportForm.Close();
                    }
                    reportForm = new StaffProfileReportForm(datePickerFromDOFA.Checked, datePickerToDOFA.Checked, datePickerFromDOFA.Value, datePickerToDOFA.Value, datePickerFromAssumption.Checked, datePickerToAssumption.Checked, datePickerFromAssumption.Value, datePickerToAssumption.Value, datePickerFrom.Checked, datePickerTo.Checked, datePickerFrom.Value, datePickerTo.Value, cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboZone.Text.Trim(), cboMechanised.Text.Trim(), cboLeave.Text.Trim(), cboGender.Text.Trim(), cboProbation.Text.Trim(), datePickerAsAtDate.Value.Date, datePickerAsAtDate.Checked, cboConfirmed.Text.Trim());
                    reportForm.Show();
                }
                else if (cboFormat.Text.ToLower().Trim() == "master list")
                {
                    if (reportForm != null && !reportForm.IsDisposed)
                    {
                        reportForm.Close();
                    }
                    reportForm = new StaffProfileMasterListReportForm(datePickerFromDOFA.Checked, 
                        datePickerToDOFA.Checked, 
                        datePickerFromDOFA.Value, 
                        datePickerToDOFA.Value, 
                        datePickerFromAssumption.Checked, 
                        datePickerToAssumption.Checked, 
                        datePickerFromAssumption.Value, 
                        datePickerToAssumption.Value, 
                        datePickerFrom.Checked, 
                        datePickerTo.Checked, 
                        datePickerFrom.Value, 
                        datePickerTo.Value, 
                        cboDepartment.Text.Trim(), 
                        cboUnit.Text.Trim(), 
                        cboGradeCategory.Text.Trim(),
                        cboGrade.SelectedIndex == -1 ? "" : cboGrade.Text.Trim(), 
                        cboZone.Text.Trim(), 
                        cboMechanised.Text.Trim(), 
                        cboLeave.Text.Trim(), 
                        cboGender.Text.Trim(), 
                        cboProbation.Text.Trim(), 
                        datePickerAsAtDate.Value.Date, 
                        datePickerAsAtDate.Checked, 
                        cboConfirmed.Text.Trim(), 
                        dateTimePicker.Value, 
                        dateTimePickerFrom.Value);
                    reportForm.Show();
                }
                else if (cboFormat.Text.ToLower().Trim() == "default")
                {
                    if (reportForm != null && !reportForm.IsDisposed)
                    {
                        reportForm.Close();
                    }
                     reportForm = new StaffProfileReportFormat1Form(datePickerFromDOFA.Checked, datePickerToDOFA.Checked, datePickerFromDOFA.Value, datePickerToDOFA.Value, datePickerFromAssumption.Checked, datePickerToAssumption.Checked, datePickerFromAssumption.Value, datePickerToAssumption.Value, datePickerFrom.Checked, datePickerTo.Checked, datePickerFrom.Value, datePickerTo.Value, cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboZone.Text.Trim(), cboMechanised.Text.Trim(), cboLeave.Text.Trim(), cboGender.Text.Trim(), cboProbation.Text.Trim(), datePickerAsAtDate.Value.Date, datePickerAsAtDate.Checked, cboConfirmed.Text.Trim(), dateTimePicker.Value.Date);
                    reportForm.Show();
                }else
                {
                    GlobalData.ShowMessage("Kindly select a format");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboProbation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboProbation.Text.ToLower().Trim() == "yes")
                {
                    datePickerAsAtDate.Visible = true;
                    datePickerAsAtDate.Checked = true;
                    lblDatePickerAsAtDate.Visible = true;
                }
                else
                {
                    datePickerAsAtDate.Visible = false;
                    lblDatePickerAsAtDate.Visible = false;
                    datePickerAsAtDate.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboProbation_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboProbation.Items.Clear();
                cboProbation.Items.Add("All");
                cboProbation.Items.Add("Yes");
                cboProbation.Items.Add("No");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboFormat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboFormat.Text.ToLower().Trim() == "master list")
                {
                    label19.Visible = true;
                    label20.Visible = true;
                    dateTimePickerFrom.Visible = true;
                    dateTimePicker.Visible = true;
                }
                else if (cboFormat.Text.ToLower().Trim() != "master list" || cboFormat.Text == string.Empty)
	            {
		            label19.Visible = false;
                    label20.Visible = false;
                    dateTimePickerFrom.Visible = false;
                    dateTimePicker.Visible = false;
	            }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
