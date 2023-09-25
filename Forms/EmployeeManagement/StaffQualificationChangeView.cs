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
    public partial class StaffQualificationChangeView : Form
    {
        private int ctr;
        public StaffQualificationChangeView()
        {
            InitializeComponent();
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
                throw;
            }
        }

        private void GetData()
        {
            try
            {
                grid.Rows.Clear();
                this.ctr = 0;
                var qualifications = GlobalData._context.StaffQualificationChangeViews.Where(u =>
                    (u.Department.Contains(cboDepartment.Text) || u.Department == null) &&
                    (u.Unit.Contains(cboUnit.Text) || u.Unit == null) &&
                    (u.Grade.Contains(cboGrade.Text) || u.Grade == null) &&
                    (u.GradeCategory.Contains(cboGradeCategory.Text) || u.GradeCategory == null) &&
                    ((u.Date.ToString() == dateEntry.Value.ToString() && dateEntry.Checked) || u.Date == null || !dateEntry.Checked) &&
                    (u.StaffID.Contains(staffIDtxt.Text) || u.StaffID == null) &&
                    (u.Archived == false || u.Archived == null) &&
                    (u.QualificationFrom.Contains(cboOldQualification.Text) || u.QualificationFrom == null) && 
                    (u.QualificationTo.Contains(cboNewQualification.Text) || u.QualificationTo == null)
                    ).ToList();

                foreach (var qualification in qualifications)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = qualification.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = qualification.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = qualification.Firstname + " " + qualification.OtherName + " " + qualification.Surname;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = qualification.Department;
                    grid.Rows[ctr].Cells["gridUnit"].Value = qualification.Unit;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = qualification.GradeCategory;
                    grid.Rows[ctr].Cells["gridGrade"].Value = qualification.Grade;
                    grid.Rows[ctr].Cells["gridGender"].Value = qualification.Gender;
                    grid.Rows[ctr].Cells["gridAge"].Value = qualification.Age;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = qualification.Specialty;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = qualification.EmploymentDate;
                    grid.Rows[ctr].Cells["gridApproved"].Value = qualification.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = qualification.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = qualification.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = qualification.ApprovedTime;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = qualification.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridOldqualification"].Value = qualification.QualificationFrom;
                    grid.Rows[ctr].Cells["gridNewqualification"].Value = qualification.QualificationTo;
                    grid.Rows[ctr].Cells["gridDate"].Value = qualification.Date;
                    grid.Rows[ctr].Cells["gridStatus"].Value = qualification.Status;
                    grid.Rows[ctr].Cells["gridReason"].Value = qualification.Reason;


                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
    }
}
