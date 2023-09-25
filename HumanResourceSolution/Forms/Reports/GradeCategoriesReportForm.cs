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
    public partial class GradeCategoriesReportForm : Form
    {
        private IDAL dal;
        public GradeCategoriesReportForm()
        {
            InitializeComponent();
            this.dal = new DAL();
            ConnectionInfo connInfo = new ConnectionInfo();
            TableLogOnInfo tablesInfo = new TableLogOnInfo();

            Database mydatabase = GradeCategories1.Database;
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

        private void GradeCategoriesReportForm_Load(object sender, EventArgs e)
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
