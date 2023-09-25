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
    public partial class ApplicantsReportForm : Form
    {
        private IDAL dal;
        ParameterFields paramFields;
        ParameterField paramField;
        ParameterDiscreteValue paramDiscreteValue;

        public ApplicantsReportForm(string startDate,string endDate)
        {
            InitializeComponent();
            this.dal = new DAL();
            paramFields = new ParameterFields();

            paramField = new ParameterField();
            paramField.Name = "Heading";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = "APPLICANTS REPORT FOR THE PERIOD " + startDate + " TO " + endDate;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            ConnectionInfo connInfo = new ConnectionInfo();
            TableLogOnInfo tablesInfo = new TableLogOnInfo();
            Database mydatabase = applicantsReport1.Database;
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

        public ApplicantsReportForm()
        {
            InitializeComponent();
            this.dal = new DAL();
        }

        private void ApplicantsReportForm_Load(object sender, EventArgs e)
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
