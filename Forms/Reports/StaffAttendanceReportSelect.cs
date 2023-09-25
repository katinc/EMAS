using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.TimeAndAttendance;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using eMAS.Forms.OtherDataSets.HR2DatasetTableAdapters;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.Reports
{
    public partial class StaffAttendanceReportSelect : Form
    {
        private DALHelper dalHelper;
        private IList<TimeUnit> timeUnits;
        private DataTable ShiftInfo;
        private IList<Employee> employees;
        private Employee employee;
        private DAL dal;
        private int employeeID;

        private IList<Department> departments;

        public StaffAttendanceReportSelect()
        {
            InitializeComponent();
            this.employee = new Employee();
            this.employees = new List<Employee>();
            this.dalHelper = new DALHelper();
            this.dal = new DAL();
            this.employees = dal.LazyLoad<Employee>();
            searchGrid.Click += new EventHandler(searchGrid_Click);
            cmbOption.DropDown +=new EventHandler(cmbOption_DropDown);
            cmbOption.SelectedIndexChanged +=new EventHandler(cmbOption_SelectedIndexChanged);
            txtStaffNo.TextChanged +=new EventHandler(txtStaffNo_TextChanged);
            txtStaffName.TextChanged +=new EventHandler(txtStaffName_TextChanged);
            
        }

        void searchGrid_Click(object sender, EventArgs e)
        {
            if (searchGrid.CurrentRow != null)
            {
                foreach (Employee employee in employees)
                {
                    if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                    {
                        if (dalHelper.ExecuteReader("Select ID From DutyRoster Where empID =" + employee.ID).Rows.Count > 0)
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            txtStaffName.Text = name;
                            txtStaffNo.Text = employee.StaffID;
                            searchGrid.Visible = false;
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
                            break;
                        }
                    }
                }
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            if (txtStaffName.Text.Trim() != string.Empty)
            {
                staffErrorProvider.Clear();
                searchGrid.Rows.Clear();
                searchGrid.BringToFront();
                int ctr = 0;
                bool found = false;
                foreach (Employee employee in employees)
                {
                    string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                    if (name.Trim().ToLower().StartsWith(txtStaffName.Text.Trim().ToLower()))
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
                    searchGrid.Location = new Point(txtStaffName.Location.X, txtStaffName.Location.Y + 21);
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

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbOption.Text.ToLower() != "individual attendance")
            //{
            //    txtStaffName.Visible = false;
            //    txtStaffNo.Visible = false;
            //    nameLabel.Visible = false;
            //    staffNoLabel.Visible = false;
            //}
            //else
            //{
            //    txtStaffName.Visible = true;
            //    txtStaffNo.Visible = true;
            //    nameLabel.Visible = true;
            //    staffNoLabel.Visible = true;
            //}
        }

        private void StaffAttendanceReportSelect_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            searchGrid.Hide();
            Clear();
            txtStaffName.Select();
            cmbOption.DropDown += new EventHandler(cmbOption_DropDown);
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            grpIndividual.Enabled = false;
        }

        void cmbOption_DropDown(object sender, EventArgs e)
        {
            //cmbOption.Items.Clear();
            //cmbOption.Items.Add("All Staff");
            //cmbOption.Items.Add("Individual Attendance");
        }

        private void Clear()
        {
            startDatePicker.ResetText();
            endDatePicker.ResetText();
            txtStaffName.Clear();
            txtStaffNo.Clear();
            searchGrid.Visible = false;
            staffErrorProvider.Clear();
            //cmbOption.Items.Clear();
            //cmbOption.Text = string.Empty;
        }

        //private void GetTimeSheets()
        //{

        //    try
        //    {
        //        dalHelper.OpenConnection();
        //        IList<TimeCard> timeCards = new List<TimeCard>();
        //        DateTime tempDate = DateTime.Parse(startDatePicker.Text);
        //        foreach (Employee employee in employees)
        //        {
        //            if (employee.StaffID == txtStaffNo.Text)
        //            {
        //                this.employeeID = employee.ID;
        //            }
        //        }

        //        DataTable timeSheetsTable;

        //        if (this.employee.ID == 0)
        //        {
        //            timeSheetsTable = dalHelper.ExecuteReader("Select StaffAttendanceLog.UserID,CheckTime,CheckType,EmpID,Firstname,OtherName, Surname,Reason  From StaffAttendanceLog inner join StaffPersonalInfo on StaffpersonalInfo.ID = StaffAttendanceLog.EmpID Order By CHECKTIME Asc");
        //        }
        //        else
        //        {
        //            timeSheetsTable = dalHelper.ExecuteReader("Select StaffAttendanceLog.UserID,CheckTime,CheckType,EmpID,Firstname,OtherName, Surname,Reason  From StaffAttendanceLog inner join StaffPersonalInfo on StaffpersonalInfo.ID = StaffAttendanceLog.EmpID Where EmpID=" + this.employee.ID + " Order By CHECKTIME Asc");
        //        }
        //        int dateDiff = DateTime.Parse(endDatePicker.Text).Subtract(DateTime.Parse(startDatePicker.Text)).Days;
        //        for (int i = 0; i <= dateDiff; i++)
        //        {
        //            timeUnits = new List<TimeUnit>();
        //            bool timeUnitFound = false;
        //            decimal duration = 0;

        //            foreach (DataRow row in timeSheetsTable.Rows)
        //            {
        //                if (DateTime.Parse(row["CheckTime"].ToString()).Date.Year == tempDate.Date.Year && DateTime.Parse(row["CheckTime"].ToString()).Date.Month == tempDate.Date.Month && DateTime.Parse(row["CheckTime"].ToString()).Date.DayOfYear == tempDate.Date.DayOfYear)
        //                {
        //                    timeUnits.Add(new TimeUnit() { UserID = int.Parse(row["UserID"].ToString()), EmpID = int.Parse(row["EmpID"].ToString()), CheckTime = DateTime.Parse(row["CheckTime"].ToString()), CheckType = row["CheckType"].ToString(), Reason = row["Reason"].ToString() });
        //                    timeUnitFound = true;
        //                }

        //            }

        //            if (timeUnitFound)
        //            {

        //                int cntr = 0;

        //                foreach (TimeUnit timeUnit in timeUnits)
        //                {
        //                    if (Math.IEEERemainder(timeUnits.Count - cntr, 2) == 0)
        //                    {
        //                        string temp = timeUnits[cntr + 1].CheckTime.Value.Subtract(timeUnit.CheckTime.Value).Hours + "." + timeUnits[cntr + 1].CheckTime.Value.Subtract(timeUnit.CheckTime.Value).Minutes;
        //                        duration += decimal.Parse(temp);
        //                    }
        //                    cntr++;
        //                }
        //                if (timeUnits.Count > 1)
        //                {
        //                    timeCards.Add(new TimeCard() { UserID = timeUnits[0].UserID, EmpID = timeUnits[0].EmpID, CheckIn = timeUnits[0].CheckTime, CheckInType = timeUnits[0].CheckType, CheckInReason = timeUnits[0].Reason, CheckOut = timeUnits[timeUnits.Count - 1].CheckTime, CheckOutType = timeUnits[timeUnits.Count - 1].CheckType, CheckOutReason = timeUnits[timeUnits.Count - 1].Reason, Duration = duration, OverTimeHours = 0, WorkHours = 0 });
        //                }
        //                else
        //                {
        //                    timeCards.Add(new TimeCard() { UserID = timeUnits[0].UserID, EmpID = timeUnits[0].EmpID, CheckIn = timeUnits[0].CheckTime, CheckInType = timeUnits[0].CheckType, CheckInReason = "N/A", CheckOut = null, CheckOutType = "N/A", CheckOutReason = "N/A", Duration = 0, OverTimeHours = 0, WorkHours = 0 });
        //                }
        //            }
        //            tempDate = tempDate.AddDays(1);
        //        }

        //        int ctr = 0;
        //        string staffID = string.Empty;
        //        string name = string.Empty;
        //        foreach (TimeCard timeCard in timeCards)
        //        {
        //            if ((timeCard.CheckIn.Value >= DateTime.Parse(ShiftInfo.Rows[0]["StartDate"].ToString()) && timeCard.CheckIn.Value <= DateTime.Parse(ShiftInfo.Rows[0]["EndDate"].ToString())))
        //            {
        //                foreach (Employee emp in employees)
        //                {
        //                    if (emp.ID == timeCard.EmpID)
        //                    {
        //                        staffID = employee.StaffID;
        //                        name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
        //                    }
        //                }
        //                dalHelper.ClearParameters();
        //                dalHelper.CreateParameter("@EmpID", timeCard.EmpID,DbType.Int32);
        //                dalHelper.CreateParameter("@StaffID", staffID, DbType.String);
        //                dalHelper.CreateParameter("@Name", name, DbType.String);
        //                dalHelper.CreateParameter("@UserID", timeCard.UserID,DbType.Int32);
        //                dalHelper.CreateParameter("@Date", timeCard.CheckIn.Value.Date,DbType.DateTime);
        //                dalHelper.CreateParameter("@CheckInTime", timeCard.CheckIn.Value.TimeOfDay.ToString(), DbType.String);
        //                dalHelper.CreateParameter("@CheckInType", timeCard.CheckInType, DbType.String);
        //                dalHelper.CreateParameter("@CheckInReason", timeCard.CheckInReason, DbType.String);
        //                dalHelper.CreateParameter("@CheckOutReason", timeCard.CheckOutReason, DbType.String);

        //                if (timeCard.CheckOut != null)
        //                {
        //                    dalHelper.CreateParameter("@CheckOutTime", timeCard.CheckOut.Value.TimeOfDay.ToString(),DbType.String);
        //                    dalHelper.CreateParameter("@CheckOutType", timeCard.CheckOutType, DbType.String);
        //                    dalHelper.CreateParameter("@Duration", decimal.Parse(timeCard.CheckOut.Value.Subtract(timeCard.CheckIn.Value).Hours + "." + timeCard.CheckOut.Value.Subtract(timeCard.CheckIn.Value).Minutes), DbType.String);
        //                }
        //                else
        //                {
        //                    dalHelper.CreateParameter("@CheckOutTime","N/A",DbType.String);
        //                    dalHelper.CreateParameter("@CheckOutType",timeCard.CheckOutType,DbType.String);
        //                    dalHelper.CreateParameter("@Duration","N/A",DbType.String);
        //                }

        //                timeCard.WorkHours = decimal.Parse(ShiftInfo.Rows[0]["Duration"].ToString());

        //                if (timeCard.Duration > timeCard.WorkHours)
        //                {
        //                    timeCard.OverTimeHours = timeCard.Duration - timeCard.WorkHours;
        //                }
        //                else
        //                {
        //                    timeCard.OverTimeHours = 0;
        //                }
        //                dalHelper.CreateParameter("@WorkingHours", timeCard.WorkHours, DbType.String);
        //                dalHelper.CreateParameter("@OverTimeHours", timeCard.OverTimeHours, DbType.String);
        //                dalHelper.ExecuteNonQuery("Delete From StaffAttendanceReport");
        //                dalHelper.ExecuteNonQuery("Insert Into StaffAttendanceReport(EmpID,StaffID,Name,UserID,Date,CheckInTime,CheckOutTime,CheckInReason,CheckOutReason,CheckOutType,CheckInType,Duration,WorkingHours,OverTimeHours) Values(@EmpID,@StaffID,@Name,@UserID,@Date,@CheckInTime,@CheckOutTime,@CheckInReason,@CheckOutReason,@CheckOutType,@CheckInType,@Duration,@WorkingHours,@OverTimeHours)");
        //                ctr++;

        //                StaffAttendanceReportForm reportFrom = new StaffAttendanceReportForm(startDatePicker.Text, endDatePicker.Text);
        //                reportFrom.Show();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string err = ex.Message;
        //    }
        //}

        private void txtStaffNo_TextChanged(object sender, EventArgs e)
        {
            if (txtStaffNo.Text.Trim() != string.Empty)
            {
                staffErrorProvider.Clear();
                searchGrid.Rows.Clear();
                searchGrid.BringToFront();
                int ctr = 0;
                bool found = false;
                foreach (Employee employee in employees)
                {
                    string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                    if (employee.StaffID.Trim().ToLower().StartsWith(txtStaffNo.Text.Trim().ToLower()))
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
                    searchGrid.Location = new Point(txtStaffName.Location.X, txtStaffName.Location.Y + 21);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbOption.SelectedItem == null)
            {
                staffErrorProvider.SetError(cmbOption, "Reporting Option is required!");
                return;
            }
            switch (cmbOption.SelectedItem.ToString())
            {
                case "Individual Employee":
                    if (txtStaffNo.Text == string.Empty)
                    {
                        staffErrorProvider.SetError(txtStaffNo, "Staff Number Is Required!");
                        return;
                    }
                    
                    break;
                //case "All Employees":
                //    if (cmbDepartment.Text == string.Empty)
                //    {
                //        staffErrorProvider.SetError(cmbDepartment, "Department Is Required!");
                //        return;
                //    }
                //    break;
                default:
                    break;
            }

            dalHelper.ClearParameters();
            string SQL = "select * from StaffAttendanceView", where = " where CheckInTime between @start and @end ";
            dalHelper.CreateParameter("@start", startDatePicker.Value, DbType.Date);
            dalHelper.CreateParameter("@end", endDatePicker.Value, DbType.Date);

            if (cmbOption.Text == "Individual Employee"){
                where =where+ " and staffID=@staffID";
                dalHelper.CreateParameter("@staffID", txtStaffNo.Text, DbType.String);
            }
            else
            {
                if (cmbDepartment.Text != string.Empty && cmbDepartment.Text != "ALL DEPARTMENTS")
                {
                    where =where+ " and Department=@Department";
                    dalHelper.CreateParameter("@Department", cmbDepartment.Text, DbType.String);
                }
                if (cmbUnit.Text != string.Empty)
                {
                    where += " and Unit=@Unit";
                    dalHelper.CreateParameter("@Unit", cmbUnit.Text, DbType.String);
                }

            }

            SQL = SQL + "" + where + " order by CheckInTime desc,StaffID asc";
            DataTable attendanceReport = dalHelper.ExecuteReader(SQL);
            attendanceReport.TableName = "ViewAttendanceReport";

           reportCompanyInfoTableAdapter companyInfoAdapter = new reportCompanyInfoTableAdapter();
         DataTable companyInfo=  companyInfoAdapter.GetData();
         companyInfo.TableName = "reportCompanyInfo";

         NewStaffAttendanceReport reportForm = new NewStaffAttendanceReport(attendanceReport, companyInfo);
         reportForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbOption_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbOption.SelectedItem == "All Employees"){
                grpDepartment.Enabled = true;
                grpIndividual.Enabled = false;
            }
            else{
                grpDepartment.Enabled = false;
                grpIndividual.Enabled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbOption.SelectedIndex = 1;
            cmbDepartment.SelectedIndex = -1;
            cmbUnit.SelectedIndex = -1;
            grpDepartment.Enabled = true;
            txtStaffName.Clear();
            txtStaffNo.Clear();
            startDatePicker.Value = DateTime.Now;
            endDatePicker.Value = DateTime.Now;


        }

        private void cmbDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                departments= dal.GetAll<Department>();

                cmbUnit.Items.Clear();
                cmbUnit.Text = string.Empty;
                cmbDepartment.Items.Clear();
               foreach (var emp in departments)
               {
                   cmbDepartment.Items.Add(emp.Description);
               }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void cmbUnit_DropDown(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cmbDepartment.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                var units = dal.GetByCriteria<Unit>(query);

                cmbUnit.Items.Clear();
                foreach (Unit unit in units)
                {
                    cmbUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }

     
    }
}
