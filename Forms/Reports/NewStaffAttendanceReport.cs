using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.Reports
{
    public partial class NewStaffAttendanceReport : Form
    {
       
        public NewStaffAttendanceReport(DataTable attendanceData,DataTable companyInfoData)
        {
            try
            {
                InitializeComponent();
             

                DataSet ds = new DataSet();
                
                ds.Tables.Add(companyInfoData);
                ds.Tables.Add(attendanceData);

                StaffAttendanceReport report = new StaffAttendanceReport();
                report.SetDataSource(ds);
                crvStaffAttendanceReport.ReportSource = report;
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }

       
    }
}
