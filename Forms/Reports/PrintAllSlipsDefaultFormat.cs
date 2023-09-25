using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.VisualBasic;

namespace eMAS.Forms.Reports
{
    public partial class PrintAllSlipsDefaultFormat : Form
    {
        private List<String> StaffIDs;
        private List<Int32> PaymentIDs;
        private ReportDocument reportDoc;
        private List<string> Months;
        private List<string> Years;
        public PrintAllSlipsDefaultFormat(ReportDocument reportDoc, List<String> StaffIDs, List<Int32> PaymentIDs, List<string> Months, List<string> Years)
        {
            InitializeComponent();

            this.StaffIDs = StaffIDs;

            this.PaymentIDs = PaymentIDs;
            this.reportDoc = reportDoc;
            this.Months = Months;
            this.Years = Years;

            foreach( string staffID in StaffIDs)
            {
                lstStaffIDs.Items.Add(staffID);
            }
        }
        public PrintAllSlipsDefaultFormat()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrintAllSlipsDefaultFormat_Load(object sender, EventArgs e)
        {
            if (StaffIDs.Count > 0)
            {
                showReport(0,false);
            }
        }

        private void showReport(int reportIndex,bool print){
            try
            {
                reportDoc.SetParameterValue("StaffID", StaffIDs[reportIndex]);
                reportDoc.SetParameterValue("PaymentID", PaymentIDs[reportIndex]);
                reportDoc.SetParameterValue("Month", Months[reportIndex]);
                reportDoc.SetParameterValue("Year", Years[reportIndex]);
                reportDoc.SetParameterValue("Department", string.Empty);
                reportDoc.SetParameterValue("Unit", string.Empty);
                reportDoc.SetParameterValue("GradeCategory", string.Empty);
                reportDoc.SetParameterValue("Grade", string.Empty);
                reportDoc.SetParameterValue("Zone", string.Empty);
                reportDoc.SetParameterValue("Mechanised", string.Empty);

                ConnectionInfo connInfo = new ConnectionInfo();
                TableLogOnInfo tablesInfo = new TableLogOnInfo();
                Database mydatabase = reportDoc.Database;
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
                this.crystalReportViewer1.ReportSource = reportDoc;
                if (print)
                {
                    Thread.Sleep(1000);
                    reportDoc.PrintToPrinter(1, true, 0, 0);
                }
               
                
            }
            catch (Exception ex) { }
          
        }

        private void lstStaffIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrintAll.Text = "&Print All Slips";
            if (lstStaffIDs.SelectedIndex > -1)
            {
                showReport(lstStaffIDs.SelectedIndex,false);
                if (lstStaffIDs.SelectedItems.Count > 1)
                    btnPrintAll.Text = "&Print Selected Slips";
               
            }
        }

        private void lstStaffIDs_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if (lstStaffIDs.SelectedItems.Count > 1 )
            {
                foreach(string SelectedItem in lstStaffIDs.SelectedItems){
                    for(int i=0 ;i< StaffIDs.Count-1;i++){
                        if(SelectedItem.Trim()==StaffIDs[i].Trim())
                        {
                            showReport(i, true);
                            //Thread.Sleep(1000);
                        }
                    }
                }
               
            }
            else
            {
                for (int i = 0; i < StaffIDs.Count; i++)
                {

                    showReport(i, true);
                    //Thread.Sleep(1000);

                }
            }
        }

        private void chkPrintSelected_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        

       

    }
}
