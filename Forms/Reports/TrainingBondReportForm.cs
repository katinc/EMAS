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

    public partial class TrainingBondReportForm : Form
    {
        private reportCompanyInfoTableAdapter companyAdapta;
        private viewSponsorshipGuarantersTableAdapter sponsorshipGuarantorsAdapta;

        public TrainingBondReportForm(DataTable reportExcuseDutyRequestsDataTable, eMAS.Forms.OtherDataSets.HR2Dataset.reportFilterDataTable reportFilterDataTable)
        {
            InitializeComponent();
            this.sponsorshipGuarantorsAdapta = new viewSponsorshipGuarantersTableAdapter();

            try
            {
               
                this.companyAdapta = new reportCompanyInfoTableAdapter();

                DataSet ds = new DataSet();

                DataTable dt = new DataTable("reportCompanyInfo");
                dt = companyAdapta.GetData();
                ds.Tables.Add(dt);

                ds.Tables.Add(reportFilterDataTable);

                dt = reportExcuseDutyRequestsDataTable;
                dt.TableName = "reportTrainingBonds";

                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);

                    dt = new DataTable("SponsorshipGuaranters");
                    dt=sponsorshipGuarantorsAdapta.GetData();
                    ds.Tables.Add(dt);
                }

                TrainingBondReport report = new TrainingBondReport();
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
