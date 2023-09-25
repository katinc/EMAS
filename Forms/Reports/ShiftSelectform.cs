using eMAS.Forms.Reports.NewReportingDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.Reports
{
    public partial class ShiftSelectform : Form
    {
        private DataTable _shift;

        public ShiftSelectform(DataTable ShiftView, string type, string staffname, string rpttype)
        {
            InitializeComponent();
            try
            {
                this._shift = ShiftView;

                //DataSet ds = new DataSet();
                //List<DataTable> tab = new List<DataTable>();

                var dtComp = new DataTable("CompanyInfo");
                CompanyInfoTableAdapter compAdapat = new CompanyInfoTableAdapter();
                dtComp = compAdapat.GetData();

                //tab.Add(dtComp);
                //tab.Add(ShiftView);
                //DataTable Sname = new DataTable("StaffName");
                //Sname.Columns.Add("StaffUName", typeof(string));
                //Sname.Rows.Add(staffname);

                if(type == "INTERNS")
                {
                    if(rpttype != "ABSENT")
                    {
                        InternShiftReport report = new InternShiftReport();
                        report.Database.Tables[0].SetDataSource(dtComp);


                        //report.Database.Tables[1].SetDataSource(Sname);
                        if (ShiftView.AsDataView().Count != 0)
                        {
                            report.Database.Tables[1].SetDataSource(ShiftView);
                        }
                        crystalReportViewer1.ReportSource = report;
                    }
                    else
                    {
                        InternShiftReport___Absentee report = new InternShiftReport___Absentee();
                        report.Database.Tables[0].SetDataSource(dtComp);


                        //report.Database.Tables[1].SetDataSource(Sname);
                        if (ShiftView.AsDataView().Count != 0)
                        {
                            report.Database.Tables[1].SetDataSource(ShiftView);
                        }
                        crystalReportViewer1.ReportSource = report;
                    }
                   
                }
                else
                {
                    if (rpttype != "ABSENT")
                    {
                        ShiftReport report = new ShiftReport();
                        report.Database.Tables[0].SetDataSource(dtComp);

                        //if(Sname.AsDataView().Count != 0)
                        //{
                        //    report.Database.Tables[1].SetDataSource(Sname);
                        //}
                        if (ShiftView.AsDataView().Count != 0)
                        {
                            report.Database.Tables[1].SetDataSource(ShiftView);
                        }
                        crystalReportViewer1.ReportSource = report;
                    }
                    else
                    {
                        ShiftReport___Absentee report = new ShiftReport___Absentee();
                        report.Database.Tables[0].SetDataSource(dtComp);

                        //if(Sname.AsDataView().Count != 0)
                        //{
                        //    report.Database.Tables[1].SetDataSource(Sname);
                        //}
                        if (ShiftView.AsDataView().Count != 0)
                        {
                            report.Database.Tables[1].SetDataSource(ShiftView);
                        }
                        crystalReportViewer1.ReportSource = report;
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
