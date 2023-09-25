using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.Reports
{
    public partial class LeaveEncashmentReport : Form
    {
        private Form encashmentForm;

        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Zone> zones;
        private IList<LeaveType> leaveTypes;
        private IDAL dal;
        private Form reportForm;
        private Company company;
        private int ctr;

        private string connectionString;

        public LeaveEncashmentReport()
        {
            InitializeComponent();

            this.encashmentForm = new Form();
            this.dal = new DAL();
            this.employees = new List<Employee>();
            this.employeeList = new List<Employee>();
            this.departments = new List<Department>();
            this.units = new List<Unit>();
            this.gradeCategories = new List<GradeCategory>();
            this.employeeGrades = new List<EmployeeGrade>();
            this.zones = new List<Zone>();
            this.leaveTypes = new List<LeaveType>();
            this.dal.OpenConnection();
            this.reportForm = new Form();
            this.ctr = 0;
            this.company = new Company();
        }

        private void cmbOption_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbOption.Items.Clear();
                cmbOption.Items.Add("All Employees");
                cmbOption.Items.Add("Individual");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Options could not be loaded");
            }
        }

        private void cmbOption_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //ClearStaff();
                if (cmbOption.Text.ToLower() == "individual")
                {
                    nametxt.Visible = true;
                    staffIDtxt.Visible = true;
                    nameLabel.Visible = true;
                    staffNoLabel.Visible = true;

                    lblDepartment.Visible = false;
                    cboDepartment.Visible = false;
                    cboUnit.Visible = false;
                    lblUnit.Visible = false;
                    cboZone.Visible = false ;
                    cboGrade.Visible = false;
                    cboGradeCategory.Visible = false;
                    lblZone.Visible = false;
                    lblGrade.Visible = false;
                    lblGradeCategory.Visible = false;
                }
                else if (cmbOption.Text.ToLower() == "all employees")
                {
                    nametxt.Visible = false;
                    staffIDtxt.Visible = false;
                    nameLabel.Visible = false;
                    staffNoLabel.Visible = false;

                    lblDepartment.Visible = true;
                    cboDepartment.Visible = true;
                    cboUnit.Visible = true;
                    lblUnit.Visible = true;
                    cboZone.Visible = true;
                    cboGrade.Visible = true;
                    cboGradeCategory.Visible = true;
                    lblZone.Visible = true;
                    lblGrade.Visible = true;
                    lblGradeCategory.Visible = true;
                }

                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Options could not be changed");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                staffIDtxt.Clear();
                nametxt.Clear();
                cmbOption.Items.Clear();
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                cboGradeCategory.Items.Clear();
                cboGrade.Items.Clear();
                cboZone.Items.Clear();
                //cboInType.Items.Clear();
                searchGrid.Visible = false;
                //staffErrorProvider.Clear();
                //dalHelper.CloseConnection();
                //dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                if (cmbOption.Text.Trim() == "Individual Employee")
                {
                    if (nametxt.Text.Trim() == string.Empty)
                    {
                        result = false;
                        staffErrorProvider.SetError(nametxt, "Please enter Name of Staff");
                        nametxt.Focus();
                    }
                    if (staffIDtxt.Text.Trim() == string.Empty)
                    {
                        result = false;
                        staffErrorProvider.SetError(staffIDtxt, "Please enter a staffID");
                        staffIDtxt.Focus();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    //Application.DoEvents();
                    //eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                    //frm.Show(this);
                    //Application.DoEvents();

                    //var 
                    encashmentForm = new LeaveEncashReportForm(staffIDtxt.Text.Trim(), datePickerFrom.Checked, datePickerTo.Checked, datePickerFrom.Value, datePickerTo.Value, cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboZone.Text.Trim());
                    encashmentForm.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //sthrow;
            }
        }

        private void LeaveEncashmentReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                connectionString = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                    {
                        //staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
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
                                if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
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
                                searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 21);
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text.Trim() + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    staffIDtxt.Clear();
                    nametxt.Clear();
                }
                }
            
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw ex;
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
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
                        if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
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
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 21);
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
                    staffIDtxt.Clear();
                    nametxt.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        //private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (searchGrid.CurrentRow != null)
        //        {
        //            staffIDtxt.Clear();
        //            nametxt.Clear();
        //            foreach (Employee employee in employees)
        //            {
        //                if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
        //                {
        //                    string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
        //                    nametxt.Text = name;
        //                    staffIDtxt.Text = employee.StaffID;
        //                    searchGrid.Visible = false;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}

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
                cboDepartment.Text = string.Empty;
                cboDepartment.Items.Add("All");
                departments = dal.GetAll<Department>();

                foreach (Department department in departments)
                {
                    cboDepartment.Items.Add(department.Description);
                }
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
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategories)
                {
                    cboGradeCategory.Items.Add(category.Description);
                }
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
                /* Query query = new Query();
                 cboGrade.Items.Clear();
                 cboGrade.Text = string.Empty;
                 query.Criteria.Add(new Criterion()
                 {
                     Property = "EmployeeGradeView.GradeCategory",
                     CriterionOperator = CriterionOperator.EqualTo,
                     Value = cboGradeCategory.SelectedItem,
                     CriteriaOperator = CriteriaOperator.And
                 });*/
                //Pulling Employee Grade
                //System.Data.SqlClient.SqlDataAdapter adapta = new System.Data.SqlClient.SqlDataAdapter("Select * from EmployeeGradeView where EmployeeGradeView.Archived='False' and GradeCategory=@GradeCategory Order By EmployeeGradeView.Description,EmployeeGradeView.GradeCategory ASC", new System.Data.SqlClient.SqlConnection(connectionString));
                //adapta.SelectCommand.Parameters.AddWithValue("@GradeCategory", cboGradeCategory.SelectedItem);

                //var dtEmpGrade = new DataTable();

                //adapta.Fill(dtEmpGrade);

                string GradeCategoryID = gradeCategories[cboGradeCategory.SelectedIndex].ID.ToString();

                var grades = GlobalData._context.EmployeeGradeViews.Where(u => u.CategoryID.ToString() == GradeCategoryID);

                foreach (var dRow in grades)
                {

                    cboGrade.Items.Add(dRow.Description);
                }
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
                Query query = new Query();
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboDepartment.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                cboUnit.Items.Add("All");
                units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    cboUnit.Items.Add(unit.Description);
                }
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
                staffIDtxt.Clear();
                nametxt.Clear();
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

        private void searchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    staffIDtxt.Clear();
                    nametxt.Clear();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
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

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbOption.Text == string.Empty)
                {
                    nametxt.Visible = false;
                    staffIDtxt.Visible = false;
                    nameLabel.Visible = false;
                    staffNoLabel.Visible = false;

                    lblDepartment.Visible = false;
                    cboDepartment.Visible = false;
                    cboUnit.Visible = false;
                    lblUnit.Visible = false;
                    cboZone.Visible = false;
                    cboGrade.Visible = false;
                    cboGradeCategory.Visible = false;
                    lblZone.Visible = false;
                    lblGrade.Visible = false;
                    lblGradeCategory.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw;
            }
        }

    }
}
