using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using eMAS.Forms.Reports.NewReportingDataSetTableAdapters;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRDataAccessLayerBase;

namespace eMAS.Forms.Reports
{
    public partial class StaffLeaveBalanceReportForm : Form
    {
        private string Department, Unit, Year, Month, StaffID;
        private DALHelper dalHelper;
        StaffLeaveBalances report;
        private LeaveBalanceDataMapper leaveBalanceDataMapper;


        private void GenerateBalances(string staffID, string Department, string Unit, string Mechanised, string Month, string Year, int monthEnd)
        {
            string where = string.Empty;
            string sql = string.Empty;
            leaveBalanceDataMapper = new LeaveBalanceDataMapper();
            try
            {


                this.dalHelper = new DALHelper();
                dalHelper.ClearParameters();

                if (Department.Trim().ToUpper() != "ALL" && Department.Trim() != string.Empty)
                {
                    where += " Department=@Department and ";
                    dalHelper.CreateParameter("@Department", Department, DbType.String);
                }

                if (Unit.Trim().ToUpper() != "ALL" && Unit.Trim() != string.Empty)
                {
                    where += " Unit=@Unit and ";
                    dalHelper.CreateParameter("@Unit", Unit, DbType.String);
                }

                if (Mechanised.Trim().ToUpper() != "ALL" && Mechanised.Trim() != string.Empty)
                {
                    where += " Mechanised=@Mechanised and ";
                    dalHelper.CreateParameter("@Mechanised", Mechanised.Trim().ToUpper() == "YES" ? true : false, DbType.Boolean);
                }

                if (staffID != null && staffID != string.Empty)
                {
                    where += " StaffID=@StaffID and ";
                    dalHelper.CreateParameter("@StaffID", staffID, DbType.String);
                }

                sql = " select ID,StaffID, EmploymentDate from StaffPersonalInfoView  ";
                sql += where != string.Empty ? " where" : string.Empty;
                sql += where.TrimEnd(" and ".ToCharArray());

                var dtResults = dalHelper.ExecuteReader(sql);

                foreach (DataRow DataRow in dtResults.Rows)
                {
                    DateTime? employmentDate = GlobalData._context.StaffPersonalInfos.First(u => u.StaffID == DataRow["StaffID"].ToString()).EmploymentDate;
                    var emp = new Employee() { ID = DataRow["ID"] != DBNull.Value ? Convert.ToInt32(DataRow["ID"]) : 0, StaffID = DataRow["StaffID"] != DBNull.Value ? Convert.ToString(DataRow["StaffID"]) : string.Empty, EmploymentDate = employmentDate };
                    
                    leaveBalanceDataMapper.ComputeLeaveBalances(emp, GlobalData.GetMonth(Month.Trim()), Convert.ToInt32(Year), monthEnd);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }
        public StaffLeaveBalanceReportForm(string staffID, string Department, string Unit, string Mechanised, string Year, string Month, string StaffID, int monthEnd)
        {
            InitializeComponent();

            try
            {

                GenerateBalances(staffID, Department, Unit, Mechanised, Month, Year, monthEnd);
                this.report = new StaffLeaveBalances();

                this.Department = Department;
                this.Unit = Unit;

                this.Year = Year;
                this.Month = Month;
                this.StaffID = StaffID;
                this.dalHelper = new DALHelper();

                var ds = new DataSet();

                CompanyInfoTableAdapter companyAdapta = new CompanyInfoTableAdapter();
                var dt = new DataTable("CompanyInfo");
                dt = companyAdapta.GetData();
                ds.Tables.Add(dt);

                dalHelper.ClearParameters();

                string where = "";

                if (Department.ToUpper() != "ALL" && Department.Trim() != string.Empty)
                {
                    where += " Department=@Department and ";
                    dalHelper.CreateParameter("@Department", Department, DbType.String);
                }
                if (Unit.ToUpper() != "ALL" && Unit.Trim() != string.Empty)
                {
                    where += "Unit=@Unit and ";
                    dalHelper.CreateParameter("@Unit", Unit, DbType.String);
                }
                if (Mechanised.ToUpper() != "ALL" && Mechanised.Trim() != string.Empty)
                {
                    where += "Mechanised=@Mechanised and ";
                    dalHelper.CreateParameter("@Mechanised", Mechanised.ToUpper() == "YES" ? true : false, DbType.Boolean);
                }
                if (Year.ToUpper() != "ALL" && Year.Trim() != string.Empty)
                {
                    where += "AnnualLeaveYear=@Year and ";
                    dalHelper.CreateParameter("@Year", Year, DbType.String);
                }

                if (Month.ToUpper() != "ALL" && Month.Trim() != string.Empty)
                {
                    where += "Month=@Month and ";
                    dalHelper.CreateParameter("@Month", GlobalData.GetMonth(Month), DbType.Int32);
                }

                if (StaffID.Trim() != string.Empty)
                {
                    where += "StaffID=@StaffID and ";
                    dalHelper.CreateParameter("@StaffID", StaffID, DbType.String);
                }

                where += "Terminated=@Terminated and TransferredOut=@TransferredOut and Archived=@Archive and ";
                dalHelper.CreateParameter("@Terminated", false, DbType.Boolean);
                dalHelper.CreateParameter("@TransferredOut", false, DbType.Boolean);
                dalHelper.CreateParameter("@Archive", false, DbType.Boolean);

                where = " where " + where.TrimEnd(" and ".ToCharArray());
                var sql = "select * from StaffLeaveBalancesReportView " + where + " order by staffid asc";
                var dtBalances = new DataTable("StaffLeaveBalancesReportView");

                dtBalances = dalHelper.ExecuteReader(sql);

                ds.Tables.Add(dtBalances);


                report.SetDataSource(ds);
                report.Database.Tables[0].SetDataSource(dt);
                report.Database.Tables[1].SetDataSource(dtBalances);

                crystalReportViewer1.ReportSource = report;
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void StaffLeaveBalanceReportForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
