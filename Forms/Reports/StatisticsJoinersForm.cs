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
    public partial class StatisticsJoinersForm : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;

        public StatisticsJoinersForm(bool isDateFromChecked, DateTime dateFrom, bool isDateToChecked, DateTime dateTo)
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                paramFields = new ParameterFields();
                //Add this parameters to the crystal report and apply to the selection report

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "DateFrom";
                paramDiscreteValue.Value = dateFrom;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
                crystalReportViewer1.ParameterFieldInfo = paramFields;

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "DateTo";
                paramDiscreteValue.Value = dateTo;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "IsDateFromChecked";
                paramDiscreteValue.Value = isDateFromChecked;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);
                crystalReportViewer1.ParameterFieldInfo = paramFields;

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "IsDateToChecked";
                paramDiscreteValue.Value = isDateToChecked;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;
                ConnectionInfo connInfo = new ConnectionInfo();
                TableLogOnInfo tablesInfo = new TableLogOnInfo();

                Database mydatabase = StatisticsJoiners1.Database;
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

        public StatisticsJoinersForm()
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

        private void StatisticsJoinersForm_Load(object sender, EventArgs e)
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
