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
    public partial class StaffAttendanceReportForm : Form
    {
        private IDAL dal;
        ParameterFields paramFields;
        ParameterField paramField;
        ParameterDiscreteValue paramDiscreteValue;

        public StaffAttendanceReportForm(string starDate,string endDate)
        {
            InitializeComponent();
            this.dal = new DAL();
            paramFields = new ParameterFields();

            //paramField = new ParameterField();
            //paramField.Name = "StartDate";
            //paramDiscreteValue = new ParameterDiscreteValue();
            //paramDiscreteValue.Value = starDate;
            //paramField.CurrentValues.Add(paramDiscreteValue);
            //paramFields.Add(paramField);

            paramField = new ParameterField();
            paramField.Name = "HEADING";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = "Staff AttendanceReport For The Period " + starDate + " To " + endDate;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crystalReportViewer1.ParameterFieldInfo = paramFields;
            //crystalReportViewer1.SelectionFormula = "{StaffAttendance.AttendanceDate} >= CDateTime (" + starDate + ") And {StaffAttendance.AttendanceDate} <= CDateTime (" + endDate +")";

            ConnectionInfo connInfo = new ConnectionInfo();
            TableLogOnInfo tablesInfo = new TableLogOnInfo();
            ParameterField startDate = new ParameterField();
            Database mydatabase = staffAttendanceReport1.Database;
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

        public StaffAttendanceReportForm()
        {
            InitializeComponent();
            this.dal = new DAL();
        }

        private void StaffAttendanceReportForm_Load(object sender, EventArgs e)
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
