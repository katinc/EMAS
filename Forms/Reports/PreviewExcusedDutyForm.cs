using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using eMAS.Forms.OtherDataSets.HR2DatasetTableAdapters;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRBussinessLayer.System_Setup_Class;


namespace eMAS.Forms.Reports
{
    public partial class PreviewExcusedDutyForm : Form
    {
        private ExcuseDutyRequest excuseDutyRequest;
        private reportExcuseDutyTableAdapter reportExcuseDutyTableAdapter;
        private reportCompanyInfoTableAdapter companyAdapta;
        private Company company;
       
        public PreviewExcusedDutyForm(ExcuseDutyRequest excuseDutyRequest)
        {
            InitializeComponent();
            this.excuseDutyRequest = excuseDutyRequest;
            this.reportExcuseDutyTableAdapter = new reportExcuseDutyTableAdapter();
            this.companyAdapta = new reportCompanyInfoTableAdapter();
           
            try
            {
                var dtCompanyInfo = new DataTable();
                dtCompanyInfo = companyAdapta.GetData();

                DataTable dt = new eMAS.Forms.OtherDataSets.HR2Dataset.generalReporHeaderDataTable();

                DataRow dRow = dt.NewRow();
                dRow["CompanyName"] = dtCompanyInfo.Rows[0]["Name"];
                dRow["Motto"] = dtCompanyInfo.Rows[0]["Motto"];
                dRow["Logo"] = dtCompanyInfo.Rows[0]["Logo"];

                dt.Rows.Add(dRow);

                DataSet ds = new DataSet();

                ds.Tables.Add(dt);

                if (excuseDutyRequest != null && excuseDutyRequest.id > 0)
                {
                    dt = new DataTable("reportExcuseDuty");
                    dt = reportExcuseDutyTableAdapter.GetDataById(excuseDutyRequest.id);

                    
                        ds.Tables.Add(dt);
                        PreviewExcusedDutyReport report = new PreviewExcusedDutyReport();
                        report.SetDataSource(ds);
                        crvPreviewExcusedDuty.ReportSource = report;
                }
                else
                {
                    PreviewExcusedDutyReportBlank report = new PreviewExcusedDutyReportBlank();
                    report.SetDataSource(ds);
                    crvPreviewExcusedDuty.ReportSource = report;
                }

               

                /*string fileName="excusedDutyRequest-"+excuseDutyRequest.employee.Surname+"-"+excuseDutyRequest.employee.FirstName+".pdf";
                
                string directory=@Environment.SpecialFolder.MyDocuments + "\\EmasDocs\\";
                String path = directory+fileName;
                bool exists = System.IO.Directory.Exists(directory);
                
                if(!exists)
                    System.IO.Directory.CreateDirectory(directory);*/

                
                //report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,path);
                //System.Diagnostics.Process.Start(path);
                
                //report.Export();
               
            }
            catch (Exception xi) { }
           
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreviewExcusedDutyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
