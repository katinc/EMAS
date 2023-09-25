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
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;


namespace eMAS.Forms.Reports
{
    public partial class PreviewTrainingBondForm : Form
    {
        private TrainingBond trainingBond;
        private reportTrainingBondsTableAdapter trainingBondAdapta;
        private reportSponsoredCertProgrammesGroupTableAdapter sponsoredProgrammesAdapta;
        private viewSponsorshipGuarantersTableAdapter guarantorsAdapata;
       
        //private Company company;
        private CompanyDataMapper companyDataMapper;
        private reportCompanyInfoTableAdapter companyAdapta;
        public PreviewTrainingBondForm(TrainingBond NewtrainingBond)
        {
            InitializeComponent();
            this.trainingBond = NewtrainingBond;
            this.trainingBondAdapta = new reportTrainingBondsTableAdapter();
            this.sponsoredProgrammesAdapta = new reportSponsoredCertProgrammesGroupTableAdapter();
            this.guarantorsAdapata = new viewSponsorshipGuarantersTableAdapter();
            this.companyDataMapper=new CompanyDataMapper();
            this.companyAdapta = new reportCompanyInfoTableAdapter();

           
            try
            {
                var ds = new DataSet();


                var dt = new DataTable("reportCompanyInfo");
                dt = companyAdapta.GetData();

                ds.Tables.Add(dt);

                dt = new DataTable("reportSponsoredCertProgrammesGroup");
                dt = sponsoredProgrammesAdapta.GetData();
                ds.Tables.Add(dt);


                dt = new DataTable("reportTrainingBonds");
                dt = trainingBondAdapta.GetDataById(trainingBond.Id);

               
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);

                    dt = new DataTable("SponsorshipGuaranters");
                    dt = guarantorsAdapata.GetDataById(trainingBond.Id);
                    ds.Tables.Add(dt);

                    PreviewTrainingBond report = new PreviewTrainingBond();
                    report.SetDataSource(ds);
                crvPreviewTrainingBond.ReportSource = report;

                }
                else{
                    PreviewTrainingBondBlank report = new PreviewTrainingBondBlank();
                    report.SetDataSource(ds);
                    crvPreviewTrainingBond.ReportSource = report;
                }
               

             
                
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }

        private void PreviewTrainingBondForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
