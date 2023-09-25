using DGVPrinterHelper;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class PromotionStaffDueForm : Form
    {
        private int ctr;
        public Permissions permissions;

        public PromotionStaffDueForm()
        {
            InitializeComponent();
            this.ctr = 0;
        }

        private void PromotionStaffDueForm_Load(object sender, EventArgs e)
        {
            permissions = GlobalData.CheckPermissions(3);
            btnSearch.Enabled = permissions.CanView;

        }

        private void cboApproved_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboQuarter.Items.Clear();
                cboQuarter.Items.Add("First");
                cboQuarter.Items.Add("Second");
                cboQuarter.Items.Add("Third");
                cboQuarter.Items.Add("Fourth");
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void cboYear_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboYear.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    cboYear.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    int firstGradePromotionYears = 3;
                    int otherGradePromotionYears = 5;
                    int nextPromotionYear = 0;

                    var quarter = cboQuarter.Text;
                    int year = 0;
                    List<DataReference.StaffPersonalInfoView> promotionList = new List<DataReference.StaffPersonalInfoView>();
                    var employeeList = GlobalData._context.StaffPersonalInfoViews.Where(u=> !u.Archived && !u.TransferredOut && !u.Terminated && u.OccupationGroupID == 1).ToList();
                    foreach (var employee in employeeList)
                    {
                        if (employee.Grade != null && employee.GradeCategory != null && employee.DOCA != null)
                        {
                            if (employee.GradeCategory.ToString() == employee.Grade.ToString())
                            {
                                year = Convert.ToInt32(cboYear.Text) - firstGradePromotionYears;
                                nextPromotionYear = employee.DOCA.Value.Year + firstGradePromotionYears;
                            }
                            else
                            {
                                year = Convert.ToInt32(cboYear.Text) - otherGradePromotionYears;
                                nextPromotionYear = employee.DOCA.Value.Year + otherGradePromotionYears;
                            }

                            int quarterBegin = getQuarterStartDate(quarter, year);
                            int quarterEnd = getQuarterEndDate(quarter, year);
                            int selectedYear = Convert.ToInt32(cboYear.Text);

                            if (employee.DOCA != null && selectedYear == nextPromotionYear && employee.DOCA.Value.Month >= quarterBegin && employee.DOCA.Value.Month <= quarterEnd )
                            {
                                promotionList.Add(employee);
                            }
                        }
                        
                    }

                    PopulateView(promotionList);
                }
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw;
            }
        }

        private bool Validate()
        {
            try
            {
                if (cboQuarter.Text == null || cboQuarter.Text == string.Empty)
                {
                    errorProvider1.SetError(cboQuarter, "select a quarter");
                    return false;
                }
                else
                {
                    errorProvider1.Clear();
                }

                if (cboYear.Text == null || cboYear.Text == string.Empty)
                {
                    errorProvider1.SetError(cboYear, "select a year");
                    return false;
                }
                else
                {
                    errorProvider1.Clear();
                }
                
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        private int getQuarterStartDate(string quarter, int year)
        {
            int startDate = 0;
            if (quarter == "First")
            {
                startDate = 1;
            }
            else if (quarter == "Second")
            {
                startDate = 4;
            }
            else if (quarter == "Third")
            {
                startDate = 7;
            }
            else if (quarter == "Fourth")
            {
                startDate = 9;
            }

            return startDate;
        }

        private int getQuarterEndDate(string quarter, int year)
        {
            int startDate = 0;
            if (quarter == "First")
            {
                startDate = 3;
            }
            else if (quarter == "Second")
            {
                startDate = 6;
            }
            else if (quarter == "Third")
            {
                startDate = 8;
            }
            else if (quarter == "Fourth")
            {
                startDate = 12;
            }

            return startDate;
        }

        private void PopulateView(List<DataReference.StaffPersonalInfoView> employees)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (var staff in employees)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staff.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staff.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = staff.Title + " " + staff.Surname + " " + staff.Firstname + " " + staff.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = staff.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = staff.GradeCategory;
                    //grid.Rows[ctr].Cells["gridZone"].Value = staff.Zone;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = staff.Department;
                    grid.Rows[ctr].Cells["gridUnit"].Value = staff.Unit;
                    grid.Rows[ctr].Cells["gridDOCA"].Value = Convert.ToDateTime(staff.DOCA).ToShortDateString();
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = Convert.ToDateTime(staff.EmploymentDate).ToShortDateString();
                    grid.Rows[ctr].Cells["gridDOFA"].Value = Convert.ToDateTime(staff.DOFA).ToShortDateString();

                    ctr++;
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            try
            {
                cboQuarter.Items.Clear();
                cboYear.Items.Clear();
                grid.DataSource = null;
                grid.Rows.Clear();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //get the data to be deleted
            //    var data = GlobalData._context.StaffDueForPromotionReports.ToList();

            //    if (data.Count > 0)
            //    {
            //        //clear the table
            //        GlobalData._context.StaffDueForPromotionReports.DeleteAllOnSubmit(data);
            //        GlobalData._context.SubmitChanges();
            //    }

            //    //save the values
            //    foreach (DataGridViewRow row in grid.Rows)
            //    {
            //        if (!row.IsNewRow)
            //        {
            //            var newPromotion = new DataReference.StaffDueForPromotionReport
            //            {
            //                Id = (decimal)row.Cells["ID"].Value,
            //                StaffName = row.Cells["gridStaffName"].Value.ToString(),
            //                StaffId = row.Cells["gridStaffID"].Value.ToString(),
            //                Department = row.Cells["gridDepartment"].Value.ToString(),
            //                Unit = row.Cells["gridUnit"].Value.ToString(),
            //                GradeCategory = row.Cells["ID"].Value.ToString(),
            //                Grade = row.Cells["ID"].Value.ToString(),
            //                EmploymentDate = (DateTime)row.Cells["ID"].Value,
            //                DOCA = (DateTime)row.Cells["ID"].Value,
            //                DOFA = (DateTime)row.Cells["ID"].Value,
            //            };
            //            GlobalData._context.StaffDueForPromotionReports.InsertOnSubmit(newPromotion);
            //        }
            //    }
            //    GlobalData._context.SubmitChanges();
                
            //    //show crystal report
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Staff Due for Promotion";
            printer.TitleFont = new Font("Cambria", 18, FontStyle.Bold, GraphicsUnit.Point);
            printer.SubTitle = "Quarter : " + cboQuarter.Text + "      Year : " + cboYear.Text;
            printer.SubTitleFont = new Font("Cambria", 12, FontStyle.Regular, GraphicsUnit.Point);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = GlobalData.Caption;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(grid);
        }
    }
}
