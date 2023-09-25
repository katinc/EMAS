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
using HRDataAccessLayerBase;

namespace eMAS.Forms.Reports
{
    public partial class PreviewAppraisalForm : Form
    {
        private AppraisalGeneralReview appraisalGeneralReview;
        private reportCompanyInfoTableAdapter companyAdapta;
        private reportAppraisalGeneralReviewsTableAdapter generalReviewAdapta;

        private ViewAppraisalObjectivesTableAdapter appraisalObjectiveAdapta;
        private reportAppraisalGeneralPerformanceRatingsTableAdapter appraisalPerformanceRatingAdapta;
        private reportStaffEducationHistoryViewTableAdapter staffEducationalAdapta;

        private AppraisalTypesTableAdapter appraisalTypesAdapter;
        private DALHelper dalHelper;
        public bool CanPrint;

        public PreviewAppraisalForm(AppraisalGeneralReview appraisalGeneralReview)
        {
            InitializeComponent();
            this.companyAdapta = new reportCompanyInfoTableAdapter();
            this.appraisalGeneralReview = appraisalGeneralReview;
            this.generalReviewAdapta = new reportAppraisalGeneralReviewsTableAdapter();

            this.appraisalObjectiveAdapta = new ViewAppraisalObjectivesTableAdapter();

            this.appraisalPerformanceRatingAdapta = new reportAppraisalGeneralPerformanceRatingsTableAdapter();
            this.staffEducationalAdapta = new reportStaffEducationHistoryViewTableAdapter();

            this.appraisalTypesAdapter = new AppraisalTypesTableAdapter();

            this.dalHelper=new DALHelper();
            
            try
            {
                DataTable dtAppraisalType=null;
                var dt = new DataTable("reportCompanyInfo");
                dt = companyAdapta.GetData();

                DataSet ds = new DataSet();

                ds.Tables.Add(dt);
                if (appraisalGeneralReview != null && appraisalGeneralReview.Id > 0)
                {
                    dt = new DataTable("reportAppraisalGeneralReviews");
                    dt = generalReviewAdapta.GetDataById(appraisalGeneralReview.Appraisee.ID);
                    ds.Tables.Add(dt);

                    dt = new DataTable("reportStaffEducationHistoryView");
                    dt = staffEducationalAdapta.GetDataById(appraisalGeneralReview.Appraisee.ID);
                    ds.Tables.Add(dt);

                   /* dt = new DataTable("ViewAppraisalObjectives");
                    dt = appraisalObjectiveAdapta.GetDataById(appraisalGeneralReview.Appraisee.ID, appraisalGeneralReview.appraisalPeriod.Id);
                    ds.Tables.Add(dt);*/

                    dt = new DataTable("ViewAppraisalObjectives");
                    dt = appraisalObjectiveAdapta.GetDataById(appraisalGeneralReview.Appraisee.ID, appraisalGeneralReview.appraisalPeriod.Id);
                    ds.Tables.Add(dt);

                    dt = new DataTable("reportAppraisalGeneralPerformanceRatings");
                    dt = appraisalPerformanceRatingAdapta.GetDataById(appraisalGeneralReview.Appraisee.ID, appraisalGeneralReview.appraisalPeriod.Id);

                    ds.Tables.Add(dt);
                }
                else
                {
                    dtAppraisalType = new DataTable("reportAppraisalGeneralPerformanceRatings");
                    dtAppraisalType = dalHelper.ExecuteReader("select id as factorId,Description,'' as staffId,0 as periodId,'' as Rating,0 as value,0 as avgmin,0 as avgmax,0 as RatingId,'' as comment,getdate() as entryDate,0 as enteredBy,0 as overalmax,0 as overalmin,'' as RateDescription,'' as PeriodName,'' as PeriodCode from appraisaltypes");
                    ds.Tables.Add(dtAppraisalType);
                }

                PreviewAppraisalReport report = new PreviewAppraisalReport();
                report.SetDataSource(ds);

                if (dtAppraisalType != null)
                {
                    report.Subreports[1].DataSourceConnections.Clear();
                    report.Subreports[1].SetDataSource(dtAppraisalType);
                }


                crvPreviewAppraisal.ReportSource = report;
            }
            catch (Exception xi) { }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreviewAppraisalForm_Load(object sender, EventArgs e)
        {

        }
    }
}
