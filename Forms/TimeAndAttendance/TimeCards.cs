using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.TimeAndAttendance;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.TimeAndAttendance
{
    public partial class TimeCards : Form
    {
        IList<Employee> employees;
        DAL dal;
        DALHelper dalHelper;
        Employee employee;
        IList<TimeUnit> timeUnits;
        DataTable ShiftInfo;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;



        public TimeCards()
        {
            InitializeComponent();
            searchGrid.Click += new EventHandler(searchGrid_Click);
            dal = new DAL();
            dalHelper = new DALHelper();
            employees = new List<Employee>();
            timeUnits = new List<TimeUnit>();
            grid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(grid_RowPostPaint);
            grid.RowsAdded += new DataGridViewRowsAddedEventHandler(grid_RowsAdded);
        }

        void grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow)
                {
                    row.Cells["gridCheckInType"].Value = "From HRIS";
                    row.Cells["gridCheckOutType"].Value = "From HRIS";
                }
            }
        }

        void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        void searchGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null && searchGrid.CurrentRow.Cells["gridStaffNo"] != null)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            if (dalHelper.ExecuteReader("Select ID From DutyRoster Where empID =" + employee.ID).Rows.Count > 0)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                nametxt.Text = name;
                                staffIDtxt.Text = employee.StaffID;
                                gendertxt.Text = employee.Gender;
                                if (employee.Photo != null)
                                {
                                    pictureBox.Image = employee.Photo;
                                }
                                else
                                {
                                    pictureBox.Image = pictureBox.InitialImage;
                                }
                                agetxt.Text = employee.Age;
                                textBox1.Text = employee.Department.Description;
                                searchGrid.Visible = false;
                                groupBox2.Enabled = true;
                                this.employee = employee;
                                try
                                {
                                    ShiftInfo = dalHelper.ExecuteReader("Select DutyRoster.StartDate,DutyRoster.EndDate,WorkShifts.* from WorkShifts Inner Join RosterGroups on WorkShifts.ID = RosterGroups.ShiftID inner join DutyRoster On RosterGroups.ID = DutyRoster.RosterGroupID Where DutyRoster.EmpID ='" + employee.ID + "'");
                                }
                                catch (Exception ex)
                                {
                                    string err = ex.Message;
                                }
                            }
                            else
                            {
                                GlobalData.ShowMessage(employee.FirstName + " " + employee.Surname + "'s must be added to the duty roaster\n before his attendance can be viewed");
                                searchGrid.Rows.Clear();
                                searchGrid.Visible = false;
                                Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void GetTimeSheets()
        {
            try
            {
                dal.OpenConnection();
                IList<TimeCard> timeCards = new List<TimeCard>();
                DateTime tempDate = DateTime.Parse(startDatePicker.Text);
                DataTable timeSheetsTable = dalHelper.ExecuteReader("Select StaffAttendanceLog.UserID,CheckTime,CheckType,EmpID,Firstname,OtherName, Surname,Reason  From StaffAttendanceLog inner join StaffPersonalInfo on StaffpersonalInfo.ID = StaffAttendanceLog.EmpID Where EmpID="+ employee.ID +" Order By CHECKTIME Asc");

                int dateDiff = DateTime.Parse(endDatePicker.Text).Subtract(DateTime.Parse(startDatePicker.Text)).Days  ;
                for (int i = 0; i <= dateDiff; i++)
                {
                    timeUnits = new List<TimeUnit>();
                    bool timeUnitFound = false;
                    decimal duration = 0;
                    
                    foreach (DataRow row in timeSheetsTable.Rows)
                    {
                        if (DateTime.Parse(row["CheckTime"].ToString()).Date.Year == tempDate.Date.Year && DateTime.Parse(row["CheckTime"].ToString()).Date.Month == tempDate.Date.Month && DateTime.Parse(row["CheckTime"].ToString()).Date.DayOfYear == tempDate.Date.DayOfYear)
                        {
                            timeUnits.Add(new TimeUnit() { UserID = int.Parse(row["UserID"].ToString()), EmpID = int.Parse(row["EmpID"].ToString()), CheckTime = DateTime.Parse(row["CheckTime"].ToString()), CheckType = row["CheckType"].ToString(),Reason = row["Reason"].ToString() });
                            timeUnitFound = true;
                        }
                        
                    }

                    if (timeUnitFound)
                    {

                        int cntr = 0;

                        foreach (TimeUnit timeUnit in timeUnits)
                        {
                            if (Math.IEEERemainder(timeUnits.Count - cntr, 2) == 0)
                            {
                                string temp = timeUnits[cntr + 1].CheckTime.Value.Subtract(timeUnit.CheckTime.Value).Hours + "." + timeUnits[cntr + 1].CheckTime.Value.Subtract(timeUnit.CheckTime.Value).Minutes;
                                duration += decimal.Parse(temp);
                            }
                            cntr++;
                        }
                        if (timeUnits.Count > 1)
                        {
                            timeCards.Add(new TimeCard() { UserID = timeUnits[0].UserID, EmpID = timeUnits[0].EmpID, CheckIn = timeUnits[0].CheckTime, CheckInType = timeUnits[0].CheckType, CheckInReason = timeUnits[0].Reason, CheckOut = timeUnits[timeUnits.Count - 1].CheckTime, CheckOutType = timeUnits[timeUnits.Count - 1].CheckType, CheckOutReason = timeUnits[timeUnits.Count - 1].Reason, Duration = duration, OverTimeHours = 0, WorkHours = 0 });
                        }
                        else
                        {
                            timeCards.Add(new TimeCard() { UserID = timeUnits[0].UserID, EmpID = timeUnits[0].EmpID, CheckIn = timeUnits[0].CheckTime, CheckInType = timeUnits[0].CheckType,CheckInReason ="N/A", CheckOut = null, CheckOutType = "N/A", CheckOutReason = "N/A", Duration = 0, OverTimeHours = 0, WorkHours = 0 });
                        }
                    }
                    tempDate = tempDate.AddDays(1);
                }

                int ctr = 0;
                grid.Rows.Clear();


                foreach (TimeCard timeCard in timeCards)
                {
                    if ((timeCard.CheckIn.Value >= DateTime.Parse(ShiftInfo.Rows[0]["StartDate"].ToString()) && timeCard.CheckIn.Value <= DateTime.Parse(ShiftInfo.Rows[0]["EndDate"].ToString())))
                    {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = timeCard.EmpID;
                    grid.Rows[ctr].Cells["gridUserID"].Value = timeCard.UserID;
                    grid.Rows[ctr].Cells["gridDate"].Value = timeCard.CheckIn.Value.Date;
                    grid.Rows[ctr].Cells["gridCheckInTime"].Value = timeCard.CheckIn.Value.TimeOfDay;
                    grid.Rows[ctr].Cells["gridCheckInType"].Value = timeCard.CheckInType;
                    grid.Rows[ctr].Cells["gridCheckInReason"].Value = timeCard.CheckInReason;
                    grid.Rows[ctr].Cells["gridCheckOutReason"].Value = timeCard.CheckOutReason;
                    if (timeCard.CheckOut != null)
                    {
                        grid.Rows[ctr].Cells["gridCheckOutTime"].Value = timeCard.CheckOut.Value.TimeOfDay;
                        grid.Rows[ctr].Cells["gridCheckOutType"].Value = timeCard.CheckOutType;
                        timeCard.Duration = decimal.Parse(timeCard.CheckOut.Value.Subtract(timeCard.CheckIn.Value).Hours +"."+ timeCard.CheckOut.Value.Subtract(timeCard.CheckIn.Value).Minutes);
                        grid.Rows[ctr].Cells["gridDuration"].Value = timeCard.Duration;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridCheckOutTime"].Value = "--:--:--";
                        grid.Rows[ctr].Cells["gridCheckOutType"].Value = "N/A";
                        grid.Rows[ctr].Cells["gridDuration"].Value = 0;
                    }

                    timeCard.WorkHours = decimal.Parse(ShiftInfo.Rows[0]["Duration"].ToString());
                   
                    if (timeCard.Duration > timeCard.WorkHours)
                    {
                        timeCard.OverTimeHours = timeCard.Duration - timeCard.WorkHours;
                    }
                    else
                    {
                        timeCard.OverTimeHours = 0;
                    }
                    grid.Rows[ctr].Cells["gridWorkingHours"].Value = timeCard.WorkHours;
                    grid.Rows[ctr].Cells["gridOverTimeHours"].Value = timeCard.OverTimeHours;
                    ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void TimeCards_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            
            try
            {
                dal.OpenConnection();
                employees = dal.LazyLoad<Employee>();
                nametxt.Select();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            grid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(grid_EditingControlShowing);


            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                savebtn.Enabled = getPermissions.CanAdd;
                viewbutton.Enabled = getPermissions.CanView;
                btnDelete.Enabled = getPermissions.CanDelete;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }

        }

        void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            grid.CurrentCellDirtyStateChanged += new EventHandler(grid_CurrentCellDirtyStateChanged);
        }

        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grid.CurrentCell.ColumnIndex == 4)
            {
                if ((grid.CurrentCell.Value != null && grid.CurrentCell.Value.ToString().ToLower() != "--select time--") && (grid.CurrentRow.Cells["gridCheckOutTime"].Value != null && grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString().ToLower() != "--select time--"))
                {
                    DateTime startTime = DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString());
                    DateTime endTime = DateTime.Parse(grid.CurrentCell.Value.ToString());

                    grid.CurrentRow.Cells["gridDuration"].Value = startTime.Subtract(endTime).Hours + "." + startTime.Subtract(endTime).Minutes;
                    foreach (DataRow row in ShiftInfo.Rows)
                    {
                        if ((DateTime.Parse(row["StartDate"].ToString()).Year <= DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()).Year && DateTime.Parse(row["StartDate"].ToString()).Month <= DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()).Month && DateTime.Parse(row["StartDate"].ToString()).Day <= DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()).Day) && (DateTime.Parse(row["EndDate"].ToString()).Year >= DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()).Year && DateTime.Parse(row["EndDate"].ToString()).Month >= DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()).Month && DateTime.Parse(row["EndDate"].ToString()).Day >= DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()).Day))
                        {
                            grid.CurrentRow.Cells["gridWorkingHours"].Value = decimal.Parse(DateTime.Parse(row["CheckOutTime"].ToString()).Subtract(DateTime.Parse(row["CheckInTime"].ToString())).Hours + "." + DateTime.Parse(row["CheckOutTime"].ToString()).Subtract(DateTime.Parse(row["CheckInTime"].ToString())).Minutes);

                            if (decimal.Parse(grid.CurrentRow.Cells["gridDuration"].Value.ToString()) > decimal.Parse(grid.CurrentRow.Cells["gridWorkingHours"].Value.ToString()))
                            {
                                grid.CurrentRow.Cells["gridOverTimeHours"].Value = decimal.Parse(DateTime.Parse(row["CheckOutTime"].ToString()).TimeOfDay.Subtract(DateTime.Parse(grid.CurrentRow.Cells["gridCheckInTime"].Value.ToString()).TimeOfDay).Hours + "." + DateTime.Parse(row["CheckOutTime"].ToString()).TimeOfDay.Subtract(DateTime.Parse(grid.CurrentRow.Cells["gridCheckInTime"].Value.ToString()).TimeOfDay).Minutes);
                            }
                            else
                            {
                                grid.CurrentRow.Cells["gridOverTimeHours"].Value = 0;
                            }
                        }
                    }
                }

            }

            if (grid.CurrentCell.ColumnIndex == 7)
            {
                if ((grid.CurrentCell.Value != null && grid.CurrentCell.Value.ToString().ToLower() != "--select time--") && (grid.CurrentRow.Cells["gridCheckOutTime"].Value != null && grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString().ToLower() != "--select time--"))
                {
                    DateTime startTime = DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString());
                    DateTime endTime = DateTime.Parse(grid.CurrentCell.Value.ToString());

                    grid.CurrentRow.Cells["gridDuration"].Value = endTime.Subtract(startTime).Hours + "." + endTime.Subtract(startTime).Minutes;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            if (nametxt.Text.Trim() != string.Empty)
            {
                errorProvider.Clear();
                searchGrid.Rows.Clear();
                searchGrid.BringToFront();
                int ctr = 0;
                bool found = false;
                foreach (Employee employee in employees)
                {
                    string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                    if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                    {
                        found = true;
                        searchGrid.Rows.Add(1);
                        searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                        searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                        ctr++;
                    }
                }
                if (found)
                {
                    if (searchGrid.RowCount == 2)
                    {
                        searchGrid.Height = searchGrid.RowCount * 24;
                    }
                    else
                    {
                        searchGrid.Height = searchGrid.RowCount * 23;
                    }
                    searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 21);
                    searchGrid.BringToFront();
                    searchGrid.Visible = true;
                }
                else
                {
                    searchGrid.Visible = false;
                }
            }
            else
            {
                Clear();
            }
        }

        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            if (staffIDtxt.Text.Trim() != string.Empty)
            {
                errorProvider.Clear();
                searchGrid.Rows.Clear();
                searchGrid.BringToFront();
                int ctr = 0;
                bool found = false;
                foreach (Employee employee in employees)
                {
                    string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                    if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                    {
                        found = true;
                        searchGrid.Rows.Add(1);
                        searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                        searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                        ctr++;
                    }
                }
                if (found)
                {
                    if (searchGrid.RowCount == 2)
                    {
                        searchGrid.Height = searchGrid.RowCount * 24;
                    }
                    else
                    {
                        searchGrid.Height = searchGrid.RowCount * 23;
                    }
                    searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 21);
                    searchGrid.BringToFront();
                    searchGrid.Visible = true;
                }
                else
                {
                    searchGrid.Visible = false;
                }

            }
            else
            {
                Clear();
            }
        }

        private void ClearStaffInfo()
        {
            staffIDtxt.Clear();
            nametxt.Clear();
            agetxt.Clear();
            gendertxt.Clear();
            pictureBox.Image = pictureBox.InitialImage;
            groupBox2.Enabled = false;
        }

        private void Clear()
        {
            ClearStaffInfo();
            grid.Rows.Clear();
            startDatePicker.ResetText();
            endDatePicker.ResetText();
            grid.Rows.Clear();
        }

        private void viewbutton_Click(object sender, EventArgs e)
        {
            GetTimeSheets();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                dalHelper.OpenConnection();
                dalHelper.BeginTransaction();
                int userID = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridCheckInReason"].Value == null)
                        {
                            row.Cells["gridCheckInReason"].Value = string.Empty;
                        }
                        if (row.Cells["gridCheckOutReason"].Value == null)
                        {
                            row.Cells["gridCheckOutReason"].Value = string.Empty;
                        }
                        if (row.Cells["gridID"].Value != null)
                        {

                            DateTime checkInTime = new DateTime(DateTime.Parse(row.Cells["gridDate"].Value.ToString()).Year, DateTime.Parse(row.Cells["gridDate"].Value.ToString()).Month, DateTime.Parse(row.Cells["gridDate"].Value.ToString()).Day, DateTime.Parse(row.Cells["gridCheckInTime"].Value.ToString()).Hour, DateTime.Parse(row.Cells["gridCheckInTime"].Value.ToString()).Minute, DateTime.Parse(row.Cells["gridCheckInTime"].Value.ToString()).Second);
                            userID = int.Parse(dalHelper.ExecuteScalar("select USERID from StaffAttendanceLog where EmpID = " + employee.ID + " and CHECKTIME = '" + checkInTime + "'").ToString());

                            
                            dalHelper.ClearParameters();
                            dalHelper.CreateParameter("@USERID", userID, DbType.Int32);
                            dalHelper.CreateParameter("@CHECKTIME", row.Cells["gridCheckInTime"].Value.ToString(), DbType.DateTime);
                            if (row.Cells["gridCheckInReason"].Value.ToString() != string.Empty)
                            {
                                dalHelper.CreateParameter("@CHECKTYPE", "E", DbType.String);
                            }
                            else
                            {
                                dalHelper.CreateParameter("@CHECKTYPE", "I", DbType.String);
                            }
                            dalHelper.CreateParameter("@EmpID", employee.ID, DbType.Int32);
                            dalHelper.CreateParameter("@Reason", row.Cells["gridCheckInReason"].Value.ToString(), DbType.String);
                            dalHelper.ExecuteNonQuery("Update StaffAttendanceLog Set CHECKTIME=@CHECKTIME,CHECKTYPE=@CHECKTYPE,EmpID=@EmpID,Reason=@Reason Where USERID=@USERID And CheckTime='"+ checkInTime +"'");


                            DateTime checkOutTime = new DateTime(DateTime.Parse(row.Cells["gridDate"].Value.ToString()).Year, DateTime.Parse(row.Cells["gridDate"].Value.ToString()).Month, DateTime.Parse(row.Cells["gridDate"].Value.ToString()).Day, DateTime.Parse(row.Cells["gridCheckOutTime"].Value.ToString()).Hour, DateTime.Parse(row.Cells["gridCheckOutTime"].Value.ToString()).Minute, DateTime.Parse(row.Cells["gridCheckOutTime"].Value.ToString()).Second);
                            userID = int.Parse(dalHelper.ExecuteScalar("select USERID from StaffAttendanceLog where EmpID = " + employee.ID + " and CHECKTIME = '" + checkOutTime + "'").ToString());
                            
                            dalHelper.ClearParameters();
                            dalHelper.CreateParameter("@USERID", row.Cells["gridUserID"].Value, DbType.Int32);
                            dalHelper.CreateParameter("@CHECKTIME", row.Cells["gridCheckOutTime"].Value.ToString(), DbType.DateTime);
                            if (row.Cells["gridCheckOutReason"].Value.ToString() != string.Empty)
                            {
                                dalHelper.CreateParameter("@CHECKTYPE", "E", DbType.String);
                            }
                            else
                            {
                                dalHelper.CreateParameter("@CHECKTYPE", "I", DbType.String);
                            }
                            dalHelper.CreateParameter("@EmpID", employee.ID, DbType.Int32);
                            dalHelper.CreateParameter("@Reason", row.Cells["gridCheckOutReason"].Value.ToString(), DbType.String);
                            dalHelper.ExecuteNonQuery("Update StaffAttendanceLog Set CHECKTIME=@CHECKTIME,CHECKTYPE=@CHECKTYPE,EmpID=@EmpID,Reason=@Reason Where USERID=@USERID And CheckTime='" + checkOutTime + "'");
                        }
                        else
                        {
                            dalHelper.OpenConnection();

                            userID = int.Parse(dalHelper.ExecuteScalar("select USERINFO.USERID From USERINFO inner join StaffPersonalInfo on StaffPersonalInfo.FingerPrintID = USERINFO.BADGENUMBER where StaffPersonalInfo.StaffID ='" + staffIDtxt.Text + "'").ToString());
                            dalHelper.ClearParameters();
                            dalHelper.CreateParameter("@UserID", userID, DbType.Int32);
                            dalHelper.CreateParameter("@CHECKTIME", row.Cells["gridCheckInTime"].Value.ToString(), DbType.DateTime);
                            dalHelper.CreateParameter("@CHECKTYPE", "E", DbType.String);
                            dalHelper.CreateParameter("@EmpID", employee.ID, DbType.Int32);
                            dalHelper.CreateParameter("@Reason", row.Cells["gridCheckInReason"].Value.ToString(), DbType.String);
                            dalHelper.ExecuteNonQuery("Insert Into StaffAttendanceLog(UserID,CHECKTIME,CHECKTYPE,EmpID,Reason) Values(@UserID,@CHECKTIME,@CHECKTYPE,@EmpID,@Reason)");

                            dalHelper.ClearParameters();
                            dalHelper.CreateParameter("@UserID", userID, DbType.Int32);
                            dalHelper.CreateParameter("@CHECKTIME", row.Cells["gridCheckOutTime"].Value.ToString(), DbType.DateTime);
                            dalHelper.CreateParameter("@CHECKTYPE", "E", DbType.String);
                            dalHelper.CreateParameter("@EmpID", employee.ID, DbType.Int32);
                            dalHelper.CreateParameter("@Reason", row.Cells["gridCheckOutReason"].Value.ToString(), DbType.String);
                            dalHelper.ExecuteNonQuery("Insert Into StaffAttendanceLog(UserID,CHECKTIME,CHECKTYPE,EmpID,Reason) Values(@UserID,@CHECKTIME,@CHECKTYPE,@EmpID,@Reason)");

                        }

                    }
                }
                dal.CommitTransaction();
                Clear();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dalHelper.RollBackTransaction();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null && !grid.CurrentRow.IsNewRow)
            {
            try
            {
                dal.OpenConnection();
                dalHelper.BeginTransaction();
                DateTime checkInTime = new DateTime(DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString()).Year, DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString()).Month, DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString()).Day, DateTime.Parse(grid.CurrentRow.Cells["gridCheckInTime"].Value.ToString()).Hour, DateTime.Parse(grid.CurrentRow.Cells["gridCheckInTime"].Value.ToString()).Minute, DateTime.Parse(grid.CurrentRow.Cells["gridCheckInTime"].Value.ToString()).Second);
                
                int userID = int.Parse(dalHelper.ExecuteScalar("select USERID from StaffAttendanceLog where EmpID = " + employee.ID + " and CHECKTIME = '" + checkInTime + "'").ToString());
                dalHelper.ExecuteNonQuery("Delete From StaffAttendanceLog Where UserID=" + userID + " And CheckTime = '" + checkInTime + "'");

                DateTime checkOutTime = new DateTime(DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString()).Year, DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString()).Month, DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString()).Day, DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()).Hour, DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()).Minute, DateTime.Parse(grid.CurrentRow.Cells["gridCheckOutTime"].Value.ToString()).Second);
                userID = int.Parse(dalHelper.ExecuteScalar("select USERID from StaffAttendanceLog where EmpID = " + employee.ID + " and CHECKTIME = '" + checkOutTime + "'").ToString());
                dalHelper.ExecuteNonQuery("Delete From StaffAttendanceLog Where UserID=" + userID + " And CheckTime = '" + checkOutTime+ "'");
                dalHelper.CommitTransaction();
                grid.Rows.RemoveAt(grid.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dalHelper.RollBackTransaction();
            }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex);
                throw;
            }
            
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
