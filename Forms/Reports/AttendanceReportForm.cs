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
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using eMAS.Forms.Reports.NewReportingDataSetTableAdapters;

namespace eMAS.Forms.Reports
{
    public partial class AttendanceReportForm : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;

        private DataTable Attendance;
        private DALHelper dalHelper;

        public AttendanceReportForm(string staffID, string type, bool isDateFromChecked, bool isDateToChecked, DateTime dateFrom, DateTime dateTo, string department, string unit, string gradeCategory, string grade, string zone)
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                paramFields = new ParameterFields();

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "StaffID";
                paramDiscreteValue.Value = staffID;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);


                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "IsDateFromChecked";
                paramDiscreteValue.Value = isDateFromChecked;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "DateFrom";
                paramDiscreteValue.Value = dateFrom;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "IsDateToChecked";
                paramDiscreteValue.Value = isDateToChecked;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "DateTo";
                paramDiscreteValue.Value = dateTo;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Department";
                paramDiscreteValue.Value = department;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Unit";
                paramDiscreteValue.Value = unit;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "GradeCategory";
                paramDiscreteValue.Value = gradeCategory;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Grade";
                paramDiscreteValue.Value = grade;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Zone";
                paramDiscreteValue.Value = zone;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;

                ConnectionInfo connInfo = new ConnectionInfo();
                TableLogOnInfo tablesInfo = new TableLogOnInfo();
                Database mydatabase = staffAttReport1.Database;
                Tables myTables = mydatabase.Tables;

                connInfo.DatabaseName = GlobalData.DatabaseName;
                connInfo.Password = GlobalData.Password;
                connInfo.ServerName = GlobalData.ServerName;
                connInfo.UserID = GlobalData.UserID;

                foreach (Table myTable in mydatabase.Tables)
                {
                    tablesInfo = myTable.LogOnInfo;
                    tablesInfo.ConnectionInfo = connInfo;
                    myTable.ApplyLogOnInfo(tablesInfo);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public AttendanceReportForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public AttendanceReportForm(DataTable AttendanceView)
        {
            InitializeComponent();
            try
            {
                this.Attendance = AttendanceView;


                DataSet ds = new DataSet();

                var dtComp = new DataTable("CompanyInfo");
                CompanyInfoTableAdapter compAdapat = new CompanyInfoTableAdapter();
                dtComp = compAdapat.GetData();

                //AttendanceViewTableAdapter attendee = new AttendanceViewTableAdapter();
                //AttendanceView = attendee.GetData();

                //ds.Tables.Add(dtComp);
                //ds.Tables.Add(Attendance);

                attendanceReportView_AGA report = new attendanceReportView_AGA();

                //report.SetDataSource(ds);
                if (AttendanceView.AsEnumerable().Count() > 0)
                {
                    report.Database.Tables[0].SetDataSource(AttendanceView);
                    report.Database.Tables[1].SetDataSource(dtComp);
                }
                else
                {
                    report.Database.Tables[0].SetDataSource(new DataTable("AttendanceView"));
                    report.Database.Tables[1].SetDataSource(dtComp);
                }


                crystalReportViewer1.ReportSource = report;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public AttendanceReportForm(DataTable AttendanceView, string reporttype)
        {
            InitializeComponent();
            try
            {
                this.Attendance = AttendanceView;


                DataSet ds = new DataSet();

                var dtComp = new DataTable("CompanyInfo");
                CompanyInfoTableAdapter compAdapat = new CompanyInfoTableAdapter();
                dtComp = compAdapat.GetData();

                //AttendanceViewTableAdapter attendee = new AttendanceViewTableAdapter();
                //AttendanceView = attendee.GetData();

                //ds.Tables.Add(dtComp);
                //ds.Tables.Add(Attendance);
                if (reporttype == "LATENESS")
                {
                    attendanceReportView_AGA_Lateness report = new attendanceReportView_AGA_Lateness();
                    //report.SetDataSource(ds);
                    if (AttendanceView.AsEnumerable().Count() > 0)
                    {
                        report.Database.Tables[0].SetDataSource(AttendanceView);
                        report.Database.Tables[1].SetDataSource(dtComp);
                    }
                    else
                    {
                        report.Database.Tables[0].SetDataSource(new DataTable("AttendanceView"));
                        report.Database.Tables[1].SetDataSource(dtComp);
                    }


                    crystalReportViewer1.ReportSource = report;
                }

              

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        public AttendanceReportForm(string sql)
        {
            InitializeComponent();
            try
            {
                DataSet ds = new DataSet();

                var dtComp = new DataTable("CompanyInfo");
                CompanyInfoTableAdapter compAdapat = new CompanyInfoTableAdapter();
                dtComp = compAdapat.GetData();

                var attendance = new DataTable("AttendanceView");
                attendance = dalHelper.ExecuteReader(sql);

                ds.Tables.Add(attendance);
                ds.Tables.Add(dtComp);



                attendanceReportView_AGA report = new attendanceReportView_AGA();

                report.SetDataSource(ds);
                crystalReportViewer1.ReportSource = report;
            }
            catch (Exception ex)
            {

            }
        }

        private void AttendanceReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                crystalReportViewer1.ShowPrintButton = btnPrintReport.Visible;
                crystalReportViewer1.ShowExportButton = btnExportReport.Visible;
                btnPrintReport.Visible = false;
                btnExportReport.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
