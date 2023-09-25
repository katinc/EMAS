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
    public partial class VehicleReportForm : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;
        public VehicleReportForm(string staffID, string vehicleType, string department, string unit, string gradeCategory, string grade, string zone)
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
                paramField.Name = "VehicleType";
                paramDiscreteValue.Value = vehicleType;
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
                Database mydatabase = VehicleReport1.Database;
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

        private void VehicleReport_Load(object sender, EventArgs e)
        {

        }
    }
}
