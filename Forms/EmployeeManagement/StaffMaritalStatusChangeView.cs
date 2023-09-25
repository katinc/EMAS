using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;


namespace eMAS.Forms.EmployeeManagement
{
    public partial class StaffMaritalStatusChangeView : Form
    {
        private int ctr;
        public StaffMaritalStatusChangeView()
        {
            InitializeComponent();
            this.ctr = 0;
        }

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.DataSource = null;
                var department = GlobalData._context.DDepartments.ToList();

                if (department.Count() > 0)
                {
                    cboDepartment.DataSource = department;
                    cboDepartment.ValueMember = "ID";
                    cboDepartment.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void cboUnit_DropDown(object sender, EventArgs e)
        {

        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboUnit.DataSource = null;
                var units = GlobalData._context.UnitViews.Where(u => u.Department == cboDepartment.Text).ToList();

                if (units.Count() > 0)
                {
                    cboUnit.DataSource = units;
                    cboUnit.ValueMember = "ID";
                    cboUnit.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.DataSource = null;
                var gradeCategory = GlobalData._context.GradeCategory_Setups.ToList();

                if (gradeCategory.Count() > 0)
                {
                    cboGradeCategory.DataSource = gradeCategory;
                    cboGradeCategory.ValueMember = "ID";
                    cboGradeCategory.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboGrade.DataSource = null;
                var grades = GlobalData._context.EmployeeGradeViews.Where(u => u.GradeCategory == cboGradeCategory.Text).ToList();

                if (grades.Count() > 0)
                {
                    cboGrade.DataSource = grades;
                    cboGrade.ValueMember = "ID";
                    cboGrade.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetData()
        {
            try
            {
                grid.Rows.Clear();
                this.ctr = 0;
                var maritalStatuses = GlobalData._context.StaffMaritalStatusChangeViews.Where(u =>
                    (u.Department.Contains(cboDepartment.Text) || u.Department == null) &&
                    (u.Unit.Contains(cboUnit.Text) || u.Unit == null) &&
                    (u.Grade.Contains(cboGrade.Text) || u.Grade == null) &&
                    (u.GradeCategory.Contains(cboGradeCategory.Text) || u.GradeCategory == null) &&
                    ((u.Date.ToString() == dateEntry.Value.ToString() && dateEntry.Checked) || u.Date == null || !dateEntry.Checked) &&
                    (u.StaffID.Contains(staffIDtxt.Text) || u.StaffID == null) &&
                    (u.Archived == false || u.Archived == null)
                    ).ToList();

                foreach (var maritalStatus in maritalStatuses)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = maritalStatus.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = maritalStatus.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = maritalStatus.Firstname + " " + maritalStatus.OtherName + " " + maritalStatus.Surname;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = maritalStatus.Department;
                    grid.Rows[ctr].Cells["gridUnit"].Value = maritalStatus.Unit;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = maritalStatus.GradeCategory;
                    grid.Rows[ctr].Cells["gridGrade"].Value = maritalStatus.Grade;
                    grid.Rows[ctr].Cells["gridGender"].Value = maritalStatus.Gender;
                    grid.Rows[ctr].Cells["gridAge"].Value = maritalStatus.Age;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = maritalStatus.Specialty;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = maritalStatus.EmploymentDate;
                    grid.Rows[ctr].Cells["gridApproved"].Value = maritalStatus.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = maritalStatus.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = maritalStatus.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = maritalStatus.ApprovedTime;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = maritalStatus.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridOldMaritalStatus"].Value = maritalStatus.MaritalStatusFrom;
                    grid.Rows[ctr].Cells["gridNewMaritalStatus"].Value = maritalStatus.MaritalStatusTo;
                    grid.Rows[ctr].Cells["gridDate"].Value = maritalStatus.Date;
                    grid.Rows[ctr].Cells["gridStatus"].Value = maritalStatus.Status;
                    grid.Rows[ctr].Cells["gridReason"].Value = maritalStatus.Reason;


                    ctr++;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
