using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRDataAccessLayer;

namespace eMAS.Forms.Reports
{
    public partial class DutyRoasterReportOptions : Form
    {
        DataTable roasterTable;
        DALHelper dalHelper;
        private IDAL dal;

        public DutyRoasterReportOptions()
        {
            InitializeComponent();
            dalHelper = new DALHelper();
            this.dal = new DAL();
        }

        private void DutyRoasterReportOptions_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dal.BeginTransaction();

                int days = dateTimePicker2.Value.Subtract(dateTimePicker1.Value).Days;
                dalHelper.ExecuteNonQuery("Delete From DutyRoasterSummary");

                DataTable dutyRoaster = dalHelper.ExecuteReader("Select DutyRoster.*,WorkShifts.ID As ShiftID,WorkShifts.CheckInTime,WorkShifts.CheckOutTime,RosterGroups.Name as RosterGroup,StaffPersonalInfo.StaffID,StaffPersonalInfo.Firstname +' '+ StaffPersonalInfo.OtherName +' '+ StaffPersonalInfo.Surname as StaffName From DutyRoster Inner Join RosterGroups on RosterGroups.ID = DutyRoster.RosterGroupID Inner Join WorkShifts On WorkShifts.ID= RosterGroups.ShiftID Inner Join StaffPersonalInfo on StaffPersonalInfo.ID = DutyRoster.EmpID  Where RosterGroups.Archived ='False' And DutyRoster.StartDate >='" + dateTimePicker1.Text + " 00:00:00' And DutyRoster.EndDate >= '" + dateTimePicker2.Text + " 00:00:00'");
                DateTime date = dateTimePicker1.Value;
                bool save = false;
                foreach (DataRow row in dutyRoaster.Rows)
                {
                    DataTable roasterGroupDays = dalHelper.ExecuteReader("Select * From RoasterGroupDays Where RosterGroupID = " + row["RosterGroupID"].ToString());
                    date = dateTimePicker1.Value;
                    for (int i = 1; i <= days + 1; i++)
                    {
                        save = false;
                        foreach (DataRow day in roasterGroupDays.Rows)
                        {
                            if ((DayOfWeek) int.Parse(day["Day"].ToString()) == date.DayOfWeek)
                            {
                                save = true;
                            }
                        }
                        if (save)
                        {
                            dalHelper.ClearParameters();
                            dalHelper.CreateParameter("@StartDate", dateTimePicker1.Value, DbType.DateTime);
                            dalHelper.CreateParameter("@EndDate", dateTimePicker2.Value, DbType.DateTime);
                            dalHelper.CreateParameter("@RosterGroup", row["RosterGroup"], DbType.String);
                            dalHelper.CreateParameter("@StaffID", row["StaffID"], DbType.String);
                            dalHelper.CreateParameter("@StaffName", row["StaffName"], DbType.String);
                            dalHelper.CreateParameter("@Shift", row["ShiftID"], DbType.Int32);
                            dalHelper.CreateParameter("@StartTime", row["CheckInTime"], DbType.DateTime);
                            dalHelper.CreateParameter("@EndTime", row["CheckOutTime"], DbType.DateTime);
                            dalHelper.CreateParameter("@Day", date.DayOfWeek, DbType.Int32);
                            dalHelper.CreateParameter("@Date", date, DbType.DateTime);
                            dalHelper.ExecuteNonQuery("Insert Into DutyRoasterSummary(StartDate,EndDate,RosterGroup,StaffID,StaffName,Shift,StartTime,EndTime,Day,Date) Values(@StartDate,@EndDate,@RosterGroup,@StaffID,@StaffName,@Shift,@StartTime,@EndTime,@Day,@Date)");
                        }
                        date = date.AddDays(1);

                    }
                }
                dal.CommitTransaction();
                DutyRoasterReportForm reportForm = new DutyRoasterReportForm(dateTimePicker1.Text, dateTimePicker2.Text);
                reportForm.Show();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dal.RollBackTransaction();
            }
        }
    }
}
