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
    public partial class SummaryReportFormGradeCategory : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;
        public SummaryReportFormGradeCategory(bool pieChart, bool barChart, bool doughnut, int gradeCategoryCount, int totalStaff)
        {

            try
            {
                InitializeComponent();
                this.dal = new DAL();
                paramFields = new ParameterFields();

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "PieChart";
                paramDiscreteValue.Value = !pieChart;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "BarChart";
                paramDiscreteValue.Value = !barChart;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "Doughnut";
                paramDiscreteValue.Value = !doughnut;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "TotalStaff";
                paramDiscreteValue.Value = totalStaff;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "GradeCategoryCount";
                paramDiscreteValue.Value = gradeCategoryCount;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                crystalReportViewer1.ParameterFieldInfo = paramFields;

                ConnectionInfo connInfo = new ConnectionInfo();
                TableLogOnInfo tablesInfo = new TableLogOnInfo();
                Database mydatabase = summaryReportGradeCategory.Database;
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
                AppUtils.ErrorMessageBox();
            }
        }
    }
}
