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
    public partial class LeaveEncashmentView : Form
    {
        private int ctr;
        private LeaveEncashment leaveEncashment;



        public LeaveEncashmentView(LeaveEncashment leaveNew)
        {
            InitializeComponent();

            this.leaveEncashment = leaveNew;
            this.ctr = 0;
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
                throw ex;
            }
        }

        private void GetData()
        {
            try
            {
                //chkAll.Checked = false;
                grid.Rows.Clear();
                this.ctr = 0;
                var leaveEncashments = GlobalData._context.LeaveEncashmentViews.Where(u =>
                    (u.Department.Contains(cboDepartment.Text) || u.Department == null) &&
                    (u.Unit.Contains(cboUnit.Text) || u.Unit == null) &&
                    (u.Grade.Contains(cboGrade.Text) || u.Grade == null) &&
                    (u.GradeCategory.Contains(cboGradeCategory.Text) || u.GradeCategory == null) &&
                    (u.Firstname.Contains(txtFirstName.Text) || u.Firstname == null) && 
                    (u.Surname.Contains(txtSurname.Text) || u.Surname == null) && 
                    (u.StaffID.Contains(txtStaffID.Text) || u.StaffID == null) && 
                    (u.Archived == false || u.Archived == null)
                    );

                foreach (var encashment in leaveEncashments)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = encashment.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = encashment.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = encashment.Firstname + " " + encashment.OtherName + " " + encashment.Surname ;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = encashment.Department;
                    grid.Rows[ctr].Cells["gridUnit"].Value = encashment.Unit;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = encashment.GradeCategory;
                    grid.Rows[ctr].Cells["gridGrade"].Value = encashment.Grade;
                    grid.Rows[ctr].Cells["gridEncashmentDays"].Value = encashment.NumberOfDays;
                    grid.Rows[ctr].Cells["gridDate"].Value = encashment.EntryDate.ToShortDateString();
                    grid.Rows[ctr].Cells["gridAmount"].Value = encashment.Amount;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
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

        private void cboGrade_DropDown(object sender, EventArgs e)
        {
            
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.DataSource = null;
                cboDepartment.Text = string.Empty;

                cboUnit.DataSource = null;
                cboUnit.Text = string.Empty;

                cboGrade.DataSource = null;
                cboGrade.Text = string.Empty;

                cboGradeCategory.DataSource = null;
                cboGradeCategory.Text = string.Empty;

                txtFirstName.Text = string.Empty;
                txtSurname.Text = string.Empty;
                txtStaffID.Text = string.Empty;

                grid.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void LeaveEncashmentView_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s leave encashment?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var encashment = GlobalData._context.LeaveEncashments.SingleOrDefault(u => u.ID == Convert.ToDecimal(grid.CurrentRow.Cells["gridID"].Value.ToString()));

                        DateTime entryDate = encashment.EntryDate;

                        if (entryDate.Year != DateTime.Now.Year)
                        {
                            MessageBox.Show("Sorry, cannot edit or delete an inactive encashment");
                            return;
                        }

                        if (encashment == null)
                        {
                            MessageBox.Show("Leave Encashment details could not be found");
                            GetData();
                            return;
                        }

                        var employeeLeaveData = GlobalData._context.StaffPersonalInfos.SingleOrDefault(u => u.StaffID == grid.CurrentRow.Cells["gridStaffID"].Value.ToString());

                        if (employeeLeaveData == null)
                        {
                            MessageBox.Show("Employee could not be found");
                            GetData();
                            return;
                        }

                        encashment.Archived = true;
                        encashment.ArchiveDateTime = DateTime.Now;
                        encashment.ArchiverID = GlobalData.UserID;

                        employeeLeaveData.LeaveTaken -= encashment.NumberOfDays;
                        employeeLeaveData.LeaveBalance += encashment.NumberOfDays;
                        employeeLeaveData.LeaveArrears += encashment.NumberOfDays;

                        GlobalData._context.SubmitChanges();
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!leaveEncashment.CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
                    return;
                }
                leaveEncashment.EditEncashment(grid.CurrentRow.Cells["gridID"].Value.ToString());
                leaveEncashment.Show();
                leaveEncashment.BringToFront();
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw;
            }
        }

    }
}
