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
    public partial class StaffListByZoneSelect : Form
    {
        private IList<Zone> zones;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IDAL dal;
        private Form reportForm;

        public StaffListByZoneSelect()
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

        private void StaffListByZoneSelect_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                cboZone.Items.Clear();
                cboZone.Text = string.Empty;
                cboGender.Items.Clear();
                cboGender.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                asAtDatePicker.ResetText();
                staffNoRadioButton.Checked = true;
                if (reportForm != null && !reportForm.IsDisposed)
                {
                    reportForm.Close();
                }
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
                reportForm = new StaffListByZoneForm(asAtDatePicker.Checked, asAtDatePicker.Value, cboGender.Text, cboDepartment.Text, cboUnit.Text.Trim(), cboZone.Text.Trim(), cboGradeCategory.Text, cboGrade.Text, staffNoRadioButton.Checked, nameRadioButton.Checked, departmentRadioButton.Checked);
                reportForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
