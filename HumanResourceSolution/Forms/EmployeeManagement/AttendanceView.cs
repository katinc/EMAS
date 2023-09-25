using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.ClaimsLeaveHirePurchase
{
    public partial class AttendanceView : Form
    {
        IDAL dal;
        AttendanceNew attendanceNew;

        public AttendanceView(IDAL dal,AttendanceNew attendanceNew)
        {
            InitializeComponent();
            this.dal = dal;
            this.attendanceNew = attendanceNew;
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                Attendance attendance = new Attendance();
                attendance.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                attendance.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                attendance.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                attendance.AttendanceDate = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                attendance.AttendanceTime = grid.CurrentRow.Cells["gridTime"].Value.ToString();
                attendanceNew.EditAttendance(attendance);
                this.Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s attendance record?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        Attendance attendance = new Attendance() { ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString()) };
                        dal.Delete(attendance);
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                    }
                }
            }
        }

        private void AttendanceView_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            grid.Rows.Clear();
            int ctr = 0;
            foreach (Attendance attendance in dal.GetAll<Attendance>())
            {
                grid.Rows.Add(1);
                grid.Rows[ctr].Cells["gridID"].Value = attendance.ID;
                grid.Rows[ctr].Cells["gridStaffID"].Value = attendance.StaffID;
                grid.Rows[ctr].Cells["gridStaffName"].Value = attendance.StaffName;
                grid.Rows[ctr].Cells["gridDate"].Value = attendance.AttendanceDate;
                grid.Rows[ctr].Cells["gridTime"].Value = attendance.AttendanceTime;
                ctr++;
            }
        }

    }
}
