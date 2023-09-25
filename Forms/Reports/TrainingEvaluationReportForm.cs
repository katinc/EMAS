using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using HRDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.Reports
{
    public partial class TrainingEvaluationReportForm : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;

        private string connectionString;
        private readonly DataTable dtReportData;

        public TrainingEvaluationReportForm(string training)
        {
            try
            {
                InitializeComponent();
                //this.dal = new DAL();
                //paramFields = new ParameterFields();

                //paramField = new ParameterField();
                //paramDiscreteValue = new ParameterDiscreteValue();
                //paramField.Name = "Training";
                //paramDiscreteValue.Value = training;
                //paramField.CurrentValues.Add(paramDiscreteValue);
                //paramFields.Add(paramField);

                //crystalReportViewer1.ParameterFieldInfo = paramFields;

                //ConnectionInfo connInfo = new ConnectionInfo();
                //TableLogOnInfo tablesInfo = new TableLogOnInfo();
                //Database mydatabase = StudyLeaveReport1.Database;
                //Tables myTables = mydatabase.Tables;

                //connInfo.DatabaseName = GlobalData.DatabaseName;
                //connInfo.Password = GlobalData.Password;
                //connInfo.ServerName = GlobalData.ServerName;
                //connInfo.UserID = GlobalData.UserID;

                //foreach (Table myTable in mydatabase.Tables)
                //{
                //    tablesInfo = myTable.LogOnInfo;
                //    tablesInfo.ConnectionInfo = connInfo;
                //    myTable.ApplyLogOnInfo(tablesInfo);
                //}
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
