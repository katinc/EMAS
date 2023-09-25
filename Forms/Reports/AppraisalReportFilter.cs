using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;
using eMAS.Forms.OtherDataSets.HR2DatasetTableAdapters;
using HRDataAccessLayer.System_Setup_Data_Control;

namespace eMAS.Forms.Reports
{
    public partial class AppraisalReportFilter : Form
    {
       		private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Zone> zones;

        private IList<ExcuseDutyRequestType> requestTypes;
        private ExcuseDutyRequestTypeDataMapper requestTypesDataMapper;

        private IDAL dal;
        private Form reportForm;
        private Company company;
        private int ctr;

        private string connectionString;
        private DALHelper dalHelper;

        private Employee selectedEmployee;

        public AppraisalReportFilter()
        {
            try
            {
                InitializeComponent();
                this.periodDataMapper = new AppraisalPeriodDataMapper();
                this.dal = new DAL();
                this.dalHelper = new DALHelper();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.selectedEmployee = new Employee();

                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.zones = new List<Zone>();
                this.requestTypes = new List<ExcuseDutyRequestType>();
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.ctr = 0;
                this.company = new Company();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbOption.Text == "All Employees")
                {
                    staffNoLabel.Visible = false;
                    nameLabel.Visible = false;
                    txtStaffName.Visible = false;
                    txtStaffNo.Visible = false;
                    searchGrid.Visible = false;
                    lblDepartment.Visible = true;
                    cboDepartment.Visible = true;
                    lblUnit.Visible = true;
                    cboUnit.Visible = true;
                    lblGradeCategory.Visible = true;
                    cboGradeCategory.Visible = true;
                    lblGrade.Visible = true;
                    cboGrade.Visible = true;
                    lblZone.Visible = true;
                    cboZone.Visible = true;
                    lblLeaveType.Visible = true;
                    cboAppraisalPeriod.Visible = true;

                    txtStaffNo.ResetText();
                    txtStaffName.ResetText();
                   
                }
                else
                {
                    staffNoLabel.Visible = true;
                    nameLabel.Visible = true;
                    txtStaffName.Visible = true;
                    txtStaffNo.Visible = true;
                    searchGrid.Visible = false;
                    lblDepartment.Visible = false;
                    cboDepartment.Visible = false;
                    lblUnit.Visible = false;
                    cboUnit.Visible = false;
                    lblGradeCategory.Visible = false;
                    cboGradeCategory.Visible = false;
                    lblGrade.Visible = false;
                    cboGrade.Visible = false;
                    lblZone.Visible = false;
                    cboZone.Visible = false;
                    lblLeaveType.Visible = true;
                    cboAppraisalPeriod.Visible = true;

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                staffErrorProvider.Clear();
                if (cboReportType.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboReportType, "Please select a report type");
                }

                if (cboAppraisalPeriod.Text.Trim() == string.Empty && string.IsNullOrWhiteSpace(txtStaffNo.Text))
                {
                    result = false;
                    staffErrorProvider.SetError(cboAppraisalPeriod, "Please select an Appraisal Period");
                }

                if (cmbOption.Text.Trim().ToLower() == "individual" && txtStaffNo.Text == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtStaffNo, "Please enter a Staff ID");
                }

                if (string.IsNullOrWhiteSpace(txtStaffNo.Text))
                {
                    var periodData = GlobalData._context.ViewAppraisalGeneralReviews.Where(u => u.Period == cboAppraisalPeriod.Text).ToList();
                    if (periodData.Count() < 1)
                    {
                        result = false;
                        staffErrorProvider.SetError(cboAppraisalPeriod, "No data found for selected period");
                    }
                }
                

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private IList<AppraisalPeriod> lstAppraisalPeriods;
        private AppraisalPeriodDataMapper periodDataMapper;
        private void btnOK_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidateFields())
                {
                    if (reportForm != null && !reportForm.IsDisposed)
                    {
                        reportForm.Close();
                    }

                    if (cboReportType.Text == "Individual")
                    {
                        reportForm = new AppraisalReportForm(txtStaffNo.Text.Trim(), cboAppraisalPeriod.Text.Trim(), datePickerFrom.Checked, datePickerTo.Checked, datePickerFrom.Value, datePickerTo.Value, cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboZone.Text.Trim());
                        reportForm.Show();
                    }
                    else
                    {
                        reportForm = new AppraisalSummaryReportForm(txtStaffNo.Text.Trim(), cboAppraisalPeriod.Text.Trim(), datePickerFrom.Checked, datePickerTo.Checked, datePickerFrom.Value, datePickerTo.Value, cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboZone.Text.Trim());
                        reportForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }

        private void txtStaffNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffNo.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (txtStaffNo.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffNo.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Terminated",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Confirmed",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = true,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        employees = dal.LazyLoadCriteria<Employee>(query);
                        if (employees.Count > 0)
                        {
                            foreach (Employee employee in employees)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                if (employee.StaffID.Trim().ToLower().StartsWith(txtStaffNo.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                                    ctr++;
                                }
                            }
                            if (found)
                            {
                                if (searchGrid.RowCount == 2)
                                {
                                    searchGrid.Height = searchGrid.RowCount * 24;
                                }
                                else
                                {
                                    searchGrid.Height = searchGrid.RowCount * 23;
                                }
                                searchGrid.Location = new Point(txtStaffNo.Location.X, txtStaffNo.Location.Y + 21);
                                searchGrid.BringToFront();
                                searchGrid.Visible = true;
                            }
                            else
                            {
                                searchGrid.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + txtStaffNo.Text.Trim() + " is not Found");
                            txtStaffNo.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    ClearStaffInfo();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffName.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(txtStaffName.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                            ctr++;
                        }
                    }
                    if (found)
                    {
                        if (searchGrid.RowCount == 2)
                        {
                            searchGrid.Height = searchGrid.RowCount * 24;
                        }
                        else
                        {
                            searchGrid.Height = searchGrid.RowCount * 23;
                        }
                        searchGrid.Location = new Point(txtStaffName.Location.X, txtStaffName.Location.Y + 21);
                        searchGrid.BringToFront();
                        searchGrid.Visible = true;
                    }
                    else
                    {
                        searchGrid.Visible = false;
                    }
                }
                else
                {
                    ClearStaffInfo();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEmployee = new Employee();
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    ClearStaffInfo();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            txtStaffName.Text = name;
                            txtStaffNo.Text = employee.StaffID;

                            selectedEmployee = employee;
                            searchGrid.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.Items.Clear();
                cboZone.Text = string.Empty;
                cboZone.Items.Add("All");
                zones = dal.GetAll<Zone>();
                foreach (Zone zone in zones)
                {
                    cboZone.Items.Add(zone.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();

                cboDepartment.Items.Add("All");
                var departments = GlobalData._context.DDepartments.Where(u => u.Active).OrderBy(u=>u.Description).ToList();

                foreach (var item in departments)
                {
                    cboDepartment.Items.Add(item.Description);
                }

                //cboDepartment.Text = string.Empty;
                //cboDepartment.Items.Add("All");
                //departments = dal.GetAll<Department>();

                //foreach (Department department in departments)
                //{
                //    cboDepartment.Items.Add(department.Description);
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Items.Add("All");
                var gradeCategories = GlobalData._context.GradeCategory_Setups.Where(u=> u.Active).ToList();

                foreach (var item in gradeCategories)
                {
                    cboGradeCategory.Items.Add(item.Description);
                }

                //gradeCategories = dal.GetAll<GradeCategory>();
                //foreach (GradeCategory category in gradeCategories)
                //{
                //    cboGradeCategory.Items.Add(category.Description);
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboGrade.Items.Clear();
                cboGrade.Items.Add("All");
                var grades = GlobalData._context.EmployeeGradeViews.Where(u => u.GradeCategory == cboGradeCategory.Text).ToList();

                foreach (var item in grades)
                {
                    cboGrade.Items.Add(item.Description);
                }


                //SqlDataAdapter adapta = new SqlDataAdapter("Select * from EmployeeGradeView where EmployeeGradeView.Archived='False' and GradeCategory=@GradeCategory Order By EmployeeGradeView.Description,EmployeeGradeView.GradeCategory ASC", new SqlConnection(connectionString));
                //adapta.SelectCommand.Parameters.AddWithValue("@GradeCategory", cboGradeCategory.SelectedItem);

                //var dtEmpGrade = new DataTable();

                //adapta.Fill(dtEmpGrade);

                //foreach(DataRow dRow in dtEmpGrade.Rows){

                //    var empGrade = new EmployeeGrade()
                //    {
                //        ID=int.Parse(dRow["ID"].ToString()),
                //        Grade=dRow["Description"].ToString(),
                //    };
                //    cboGrade.Items.Add(empGrade.Grade);
                //    employeeGrades.Add(empGrade);
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboUnit.Items.Clear();
                cboUnit.Items.Add("All");
                var units = GlobalData._context.UnitViews.Where(u => u.Department == cboDepartment.Text && u.Active).OrderBy(u => u.Description).ToList();

                foreach (var item in units)
                {
                    cboUnit.Items.Add(item.Description);
                }

                //Query query = new Query();
                //cboUnit.Items.Clear();
                //cboUnit.Text = string.Empty;
                //query.Criteria.Add(new Criterion()
                //{
                //    Property = "UnitView.Department",
                //    CriterionOperator = CriterionOperator.EqualTo,
                //    Value = cboDepartment.SelectedItem,
                //    CriteriaOperator = CriteriaOperator.And
                //});
                //cboUnit.Items.Add("All");
                //units = dal.GetByCriteria<Unit>(query);
                //foreach (Unit unit in units)
                //{
                //    cboUnit.Items.Add(unit.Description);
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Clear()
        {
            try
            {
                ClearStaffInfo();
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                cboZone.Items.Clear();
                datePickerFrom.ResetText();
                datePickerTo.ResetText();
                searchGrid.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        private void ClearStaffInfo()
        {
            try
            {
                txtStaffNo.Clear();
                txtStaffName.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

      
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ExcuseDutyReportFilter_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                connectionString = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;

                cmbOption.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

     
        private void cboAppraisalPeriod_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAppraisalPeriod.Items.Clear();
                lstAppraisalPeriods = periodDataMapper.getData(true, false);
                foreach (var period in lstAppraisalPeriods)
                {
                    cboAppraisalPeriod.Items.Add(period.Description);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }

        private void cboReportType_DropDown(object sender, EventArgs e)
        {
            cboReportType.Items.Clear();

            cboReportType.Items.Add("Individual");
            cboReportType.Items.Add("Summary");
        }

        private void cboReportType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboReportType.Text == "Summary")
            {
                cmbOption.Enabled = false;

                staffNoLabel.Visible = false;
                nameLabel.Visible = false;
                txtStaffName.Visible = false;
                txtStaffNo.Visible = false;
                searchGrid.Visible = false;
                lblDepartment.Visible = false;
                cboDepartment.Visible = false;
                lblUnit.Visible = false;
                cboUnit.Visible = false;
                lblGradeCategory.Visible = false;
                cboGradeCategory.Visible = false;
                lblGrade.Visible = false;
                cboGrade.Visible = false;
                lblZone.Visible = false;
                cboZone.Visible = false;

                txtStaffNo.ResetText();
                txtStaffName.ResetText();
            }
            else
            {
                cmbOption.Enabled = true;
            }
        }
    }
}
