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
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;

namespace eMAS.Forms.Reports
{
    public partial class StraightToBankReportForm : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;
        private StraighToBankReport reportDoc;


        public StraightToBankReportForm(string staffID, string month, string year, string zone ,string department,string unit,string gradeCategory,string grade, string bank, string bankBranch, string accountType, string accountNumber,string mechanised,string Type)
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                paramFields = new ParameterFields();
                //Add this parameters to the crystal report and apply to the selection report
                reportDoc = new StraighToBankReport();


                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Month";
                paramDiscreteValue.Value = month;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Year";
                paramDiscreteValue.Value = year;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "StaffID";
                paramDiscreteValue.Value = staffID;
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
                paramField.Name = "Bank";
                paramDiscreteValue.Value = bank;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "BankBranch";
                paramDiscreteValue.Value = bankBranch;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "AccountType";
                paramDiscreteValue.Value = accountType;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "AccountNumber";
                paramDiscreteValue.Value = accountNumber;
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
                paramField.Name = "FType";
                paramDiscreteValue.Value = Type;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;

                reportDoc.SetParameterValue("Year", year);
                reportDoc.SetParameterValue("Month", month);
                reportDoc.SetParameterValue("StaffID", staffID);
                reportDoc.SetParameterValue("Zone", zone);
                reportDoc.SetParameterValue("Department", department);
                reportDoc.SetParameterValue("Unit", unit);
                reportDoc.SetParameterValue("AccountType", accountType);
                reportDoc.SetParameterValue("AccountNumber", accountNumber);

                reportDoc.SetParameterValue("Bank", bank);
                reportDoc.SetParameterValue("BankBranch", bankBranch);
                reportDoc.SetParameterValue("GradeCategory", gradeCategory);
                reportDoc.SetParameterValue("Grade", grade);
                reportDoc.SetParameterValue("FType", Type);

                

                ConnectionInfo connInfo = new ConnectionInfo();
                TableLogOnInfo tablesInfo = new TableLogOnInfo();

                Database mydatabase = reportDoc.Database;
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


               /* string directory=@Environment.SpecialFolder.MyDocuments + "\\EmasDocs\\";
                String path = directory+month+"-"+year+".xls";
                bool exists = System.IO.Directory.Exists(directory);
                
                if(!exists)
                    System.IO.Directory.CreateDirectory(directory);*/

               
               
               crystalReportViewer1.ShowExportButton = true;
              // crystalReportViewer1.AllowedExportFormats = ExportFormatType.Excel.;
                
             
                //reportDoc.ExportToDisk()
               crystalReportViewer1.ReportSource = reportDoc;
                
                //crystalReportViewer1.AllowedExportFormats
                //this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        public StraightToBankReportForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void BankAdviceSlipReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                if (GlobalData.User.UserCategory.Description == "Advance")
                {
                    btnPrintReport.Visible = true;
                    btnExportReport.Visible = true;
                }
               

                crystalReportViewer1.ShowPrintButton = btnPrintReport.Visible;
                crystalReportViewer1.ShowExportButton = btnExportReport.Visible;
                //btnPrintReport.Visible = false;
                //btnExportReport.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            

        }
    }
}
public class StraightToBank
{
    public string Year{get;set;}
    public int Month{get;set;}
    public string StaffID{get;set;}
    public string Zone{get;set;}
    public string Department { get; set; }
    public string Unit { get; set; }
    public string AccountType { get; set; }
    public string AccountNumber { get; set; }
    public string Bank { get; set; }
    public string BankBranch { get; set; }
    public string GradeCategory { get; set; }
    public string Grade { get; set; }
    public string FType { get; set; }
}