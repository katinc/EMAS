﻿using System;
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
    public partial class PaySlipReportForm : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;

        private string AutoAction;

        public PaySlipReportForm(string staffID, int paymentID, string month, string year, string department, string unit, string gradeCategory, string grade, string zone, string mechanised, string AutoAction)
        {
            try
            {
                this.AutoAction = AutoAction;
                InitializeComponent();
                this.dal = new DAL();
                paramFields = new ParameterFields();

                //Add this parameters to the crystal report and apply to the selection report
                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "StaffID";
                paramDiscreteValue.Value = staffID;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField();
                paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "PaymentID";
                paramDiscreteValue.Value = paymentID;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

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
                crystalReportViewer1.ParameterFieldInfo = paramFields;
                crystalReportViewer1.Refresh();

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
                paramField.Name = "Mechanised";
                paramDiscreteValue.Value = mechanised;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                ConnectionInfo connInfo = new ConnectionInfo();
                TableLogOnInfo tablesInfo = new TableLogOnInfo();
                Database mydatabase = paySlipReport1.Database;
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
                //paySlipReport1.DataSourceConnections[0].SetConnection(connInfo.ServerName, connInfo.DatabaseName, connInfo.UserID, connInfo.Password);
                //paySlipReport1.Refresh();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public PaySlipReportForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PaySlipReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                crystalReportViewer1.ShowPrintButton = btnPrintReport.Visible;
                crystalReportViewer1.ShowExportButton = btnExportReport.Visible;
                btnPrintReport.Visible = false;
                btnExportReport.Visible = false;

                if (this.AutoAction == "print")
                {
                    this.crystalReportViewer1.PrintReport();
                    this.Close();
                }
                if (this.AutoAction == "export_pdf")
                {
                    this.crystalReportViewer1.ExportReport();
                    this.Close();


                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
