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
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.Reports
{
    public partial class StaffProfileReportFormat1Form : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;

        public StaffProfileReportFormat1Form(bool isDateFromDOFAChecked, bool isDateToDOFAChecked, DateTime dateFromDOFA, DateTime dateToDOFA, bool isDateFromAssumptionChecked, bool isDateToAssumptionChecked, DateTime dateFromAssumption, DateTime dateToAssumption, bool isDateFromChecked, bool isDateToChecked, DateTime dateFrom, DateTime dateTo, string department, string unit, string gradeCategory, string employeeGrade, string zone, string mechanised, string leave, string gender, string probation, DateTime asAtDate, bool asAtDateChecked, string confirmed, DateTime date)
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                paramFields = new ParameterFields();
                //Add this parameters to the crystal report and apply to the selection report
                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "IsDateFromDOFAChecked";
                paramDiscreteValue.Value = isDateFromDOFAChecked;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "DateFromDOFA";
                paramDiscreteValue.Value = dateFromDOFA;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "IsDateToDOFAChecked";
                paramDiscreteValue.Value = isDateToDOFAChecked;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "DateToDOFA";
                paramDiscreteValue.Value = dateToDOFA;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);



                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "IsDateFromAssumptionChecked";
                paramDiscreteValue.Value = isDateFromAssumptionChecked;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "DateFromAssumption";
                paramDiscreteValue.Value = dateFromAssumption;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "IsDateToAssumptionChecked";
                paramDiscreteValue.Value = isDateToAssumptionChecked;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "DateToAssumption";
                paramDiscreteValue.Value = dateToAssumption;
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
                paramField.Name = "EmployeeGrade";
                paramDiscreteValue.Value = employeeGrade;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Zone";
                paramDiscreteValue.Value = zone;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Leave";
                paramDiscreteValue.Value = leave;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Mechanised";
                paramDiscreteValue.Value = mechanised;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Gender";
                paramDiscreteValue.Value = gender;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Probation";
                paramDiscreteValue.Value = probation;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "AsAtDate";
                paramDiscreteValue.Value = asAtDate;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "AsAtDateChecked";
                paramDiscreteValue.Value = asAtDateChecked;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Confirmed";
                paramDiscreteValue.Value = confirmed;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Date";
                paramDiscreteValue.Value = date;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;

                ConnectionInfo connInfo = new ConnectionInfo();
                TableLogOnInfo tablesInfo = new TableLogOnInfo();

                Database mydatabase = StaffProfileFormat11.Database;
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
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public StaffProfileReportFormat1Form()
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

        private void StaffProfileReportFormat1Form_Load(object sender, EventArgs e)
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
