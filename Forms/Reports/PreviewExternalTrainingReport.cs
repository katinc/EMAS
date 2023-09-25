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
using System.Reflection;

namespace eMAS.Forms.Reports
{
    public partial class PreviewExternalTrainingReport : Form
    {
        ExternalTraining externalTraining;
        reportExternalTrainingTableAdapter externalTrainingAdapta;
        reportWorkshopsTableAdapter workshopAdapta;
        private reportCompanyInfoTableAdapter companyAdapta;
        //DataReference.hrContextDataContext context = new DataReference.hrContextDataContext();

        private Company company;
        public PreviewExternalTrainingReport(ExternalTraining externalTraining)
        {
            InitializeComponent();
            try
            {
                this.externalTraining = externalTraining;
                externalTrainingAdapta = new reportExternalTrainingTableAdapter();
                this.workshopAdapta = new reportWorkshopsTableAdapter();
                this.companyAdapta = new reportCompanyInfoTableAdapter();

                DataSet ds = new DataSet();

                var dt = new DataTable("reportCompanyInfo");
                dt = companyAdapta.GetData();

                ds.Tables.Add(dt);

                 //dt = new DataTable("reportExternalTraining");
                 var getexTraining = GlobalData._context.ViewExternalTrainings.Where(u => u.ID == externalTraining.ID).ToList();
                //dt = externalTrainingAdapta.GetDataById(externalTraining.ID);
                 dt = ToDataTable<DataReference.ViewExternalTraining>(getexTraining, "reportExternalTraining");
                
                if (dt.Rows.Count > 0)
                {
                    ds.Tables.Add(dt);

                    dt = new DataTable("reportWorkshops");
                    dt = workshopAdapta.GetDataById(externalTraining.Staff.ID);

                    ds.Tables.Add(dt);

                    PreviewExternalTraining report = new PreviewExternalTraining();
                    report.SetDataSource(ds);
                    crvPreviewExternalTraining.ReportSource = report;
                }

                else
                {
                    PreviewExternalTrainingBlank report = new PreviewExternalTrainingBlank();
                    report.SetDataSource(ds);
                    crvPreviewExternalTraining.ReportSource = report;
                }
                
                
              
            }
            catch (Exception xi) { }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreviewExternalTrainingReport_Load(object sender, EventArgs e)
        {

        }

        public static DataTable ToDataTable<T>(List<T> items, string Name)
        {
            DataTable dataTable = new DataTable(Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
