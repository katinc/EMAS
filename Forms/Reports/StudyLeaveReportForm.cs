﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using HRBussinessLayer.ErrorLogging;
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
    public partial class StudyLeaveReportForm : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;

        public StudyLeaveReportForm(string staffID, bool isDateFromChecked, bool isDateToChecked, DateTime dateFrom, DateTime dateTo, string department, string unit, string gradeCategory, string grade, string zone, string recommended, string approved)
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

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "Recommended";
            paramDiscreteValue.Value = recommended;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "Approved";
            paramDiscreteValue.Value = approved;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField();
            paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "Archived";
            paramDiscreteValue.Value = false;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            ConnectionInfo connInfo = new ConnectionInfo();
            TableLogOnInfo tablesInfo = new TableLogOnInfo();
            Database mydatabase = StudyLeaveReport1.Database;
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

        private void StudyLeaveReportForm_Load(object sender, EventArgs e)
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
