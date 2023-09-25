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
using System.Configuration;
using System.Data.SqlClient;

namespace eMAS.Forms.Reports
{
    public partial class AGALeaveLetterForm : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;

        private string connectionString;

        public AGALeaveLetterForm(string staffID, string leaveType, DateTime dateFrom, DateTime dateTo, decimal days, string refNo)
        {
            try
            {
                InitializeComponent();
                connectionString = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
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
                paramField.Name = "RefNo";
                paramDiscreteValue.Value = refNo;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Days";
                paramDiscreteValue.Value = days;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "StartDate";
                paramDiscreteValue.Value = dateFrom;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "EndDate";
                paramDiscreteValue.Value = dateTo;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "LeaveType";
                paramDiscreteValue.Value = leaveType;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                //AGALeaveLetterReport1.SetParameterValue("RefNo", refNo);
                //AGALeaveLetterReport1.SetParameterValue("StaffID", staffID);
                //AGALeaveLetterReport1.SetParameterValue("Days", days);
                //AGALeaveLetterReport1.SetParameterValue("StartDate", dateFrom);
                //AGALeaveLetterReport1.SetParameterValue("EndDate", dateTo);

                crystalReportViewer1.ParameterFieldInfo = paramFields;
                

                ConnectionInfo connInfo = new ConnectionInfo();
                TableLogOnInfo tablesInfo = new TableLogOnInfo();
                Database mydatabase = AGALeaveLetterReport1.Database;
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

        public AGALeaveLetterForm()
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



        private void AGALeaveLetterForm_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                //crystalReportViewer1.ShowPrintButton = btnPrintReport.Visible;
                //crystalReportViewer1.ShowExportButton = btnExportReport.Visible;
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
