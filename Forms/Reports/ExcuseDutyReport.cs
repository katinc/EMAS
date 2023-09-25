using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using eMAS.Forms.OtherDataSets.HR2DatasetTableAdapters;

namespace eMAS.Forms.Reports
{

    public partial class ExcuseDutyReport : Form
    {
        private reportCompanyInfoTableAdapter companyAdapta;

        public ExcuseDutyReport(DataTable reportExcuseDutyRequestsDataTable, eMAS.Forms.OtherDataSets.HR2Dataset.reportFilterDataTable reportFilterDataTable)
        {
            InitializeComponent();

            try
            {
               
                this.companyAdapta = new reportCompanyInfoTableAdapter();

                DataSet ds = new DataSet();

                DataTable dt = new DataTable("reportCompanyInfo");
                dt = companyAdapta.GetData();
                ds.Tables.Add(dt);

                ds.Tables.Add(reportFilterDataTable);

                dt = reportExcuseDutyRequestsDataTable;
                dt.TableName = "reportExcuseDutyRequests";

                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);
                }

                ExcuseDutyRequestReport report = new ExcuseDutyRequestReport();
                report.SetDataSource(ds);

                crvExcuseDutyReport.ReportSource = report;
            }
            catch (Exception xi)
            {}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExcuseDutyReport_Load(object sender, EventArgs e)
        {

        }
    }
}
