using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using eMAS.Forms.PayRollProcessing;
using System.Reflection;
using System.Data.SqlClient;

namespace eMAS.Forms.Reports
{
    public partial class AttendanceReportSelect : Form
    {
        private IDAL dal;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Zone> zones;
        private Form reportForm;
        private DALHelper dalHelper;
        private Company company;
        private int ctr;
        private string type;

        public AttendanceReportSelect()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.zones = new List<Zone>();
                this.dalHelper = new DALHelper();
                this.company = new Company();
                this.ctr = 0;
                this.type = string.Empty;
                this.reportForm = new Form();
                this.cboRptType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    staffIDtxt.Text = searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString();
                    nametxt.Text = searchGrid.CurrentRow.Cells["gridName"].Value.ToString();
                    searchGrid.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                Query query = new Query();
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cboGrade.Items.Add(employeeGrade.Grade);
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

        private void Clear()
        {
            try
            {
                ClearStaff();
                cmbOption.Items.Clear();
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                cboGradeCategory.Items.Clear();
                cboGrade.Items.Clear();
                cboZone.Items.Clear();
                cboInType.Items.Clear();
                searchGrid.Visible = false;
                staffErrorProvider.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ClearStaff()
        {
            try
            {
                nametxt.Clear();
                staffIDtxt.Clear();
                staffIDtxt.Select();
                searchGrid.Visible = false;
                staffErrorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearStaff();
                if (cmbOption.Text.ToLower() != "individual")
                {
                    nametxt.Visible = false;
                    staffIDtxt.Visible = false;
                    nameLabel.Visible = false;
                    staffNoLabel.Visible = false;
                    lblDepartment.Visible = true;
                    cboDepartment.Visible = true;
                    //lblUnit.Visible = true;
                    //cboUnit.Visible = true;
                    //lblGradeCategory.Visible = true;
                    //cboGradeCategory.Visible = true;
                    //lblGrade.Visible = true;
                    //cboGrade.Visible = true;
                    //lblZone.Visible = true;
                    //cboZone.Visible = true;
                }
                else
                {
                    nametxt.Visible = true;
                    staffIDtxt.Visible = true;
                    nameLabel.Visible = true;
                    staffNoLabel.Visible = true;
                    lblDepartment.Visible = false;
                    cboDepartment.Visible = false;
                    //lblUnit.Visible = false;
                    //cboUnit.Visible = false;
                    //lblGradeCategory.Visible = false;
                    //cboGradeCategory.Visible = false;
                    //lblGrade.Visible = false;
                    //cboGrade.Visible = false;
                    //lblZone.Visible = false;
                    //cboZone.Visible = false;
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
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:The form cannot close");
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (nametxt.Text.Length >= company.MinimumCharacter)
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
                }
                else
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Search by Staff Name cannot be completed");
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
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

        //DataReference.hrContextDataContext _context = new DataReference.hrContextDataContext();

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {

                    Application.DoEvents();
                    eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                    frm.Show(this);
                    Application.DoEvents();
                    //    if (reportForm != null && !reportForm.IsDisposed)
                    //    {
                    //        reportForm.Close();
                    //    }

                    //    reportForm = new AttendanceReportForm(staffIDtxt.Text.Trim(), type, datePickerFrom.Checked, datePickerTo.Checked, datePickerFrom.Value, datePickerTo.Value, cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboZone.Text.Trim());
                    //    reportForm.Show();
                    dalHelper.ClearParameters();
                    string where = string.Empty;

                    if (staffIDtxt.Text != string.Empty)
                    {
                        dalHelper.CreateParameter("@StaffID", staffIDtxt.Text, DbType.String);
                        where += " staffID=@StaffID and ";
                    }
                    if (datePickerFrom.Checked)
                    {
                        dalHelper.CreateParameter("@FromDate", datePickerFrom.Value.Date.ToShortDateString(), DbType.Date);
                        where += " Date>=@FromDate and ";
                    }
                    if (datePickerTo.Checked)
                    {
                        dalHelper.CreateParameter("@ToDate", datePickerTo.Value.Date.ToShortDateString(), DbType.Date);
                        where += " Date<=@ToDate and ";

                    }
                    if (cboShiftType.Text != "ALL" && cboShiftType.Text != string.Empty)
                    {
                        dalHelper.CreateParameter("@ShiftType", cboShiftType.Text.Trim(), DbType.String);
                        where += " ShiftType=@ShiftType and ";
                    }
                    if (cboCheckOutType.Text != "All" && cboCheckOutType.Text != string.Empty)
                    {
                        dalHelper.CreateParameter("@CheckOutType", cboCheckOutType.Text.Trim(), DbType.String);
                        where += " CheckOutType=@CheckOutType and ";
                    }
                    if (cboInType.Text.ToUpper() != "ALL" && cboInType.Text.Trim() != string.Empty)
                    {

                        dalHelper.CreateParameter("@InType", cboInType.Text.ToUpper(), DbType.String);
                        where += " InType=@InType and ";

                    }
                    if (cboOutType.Text.ToUpper() != "ALL" && cboOutType.Text.Trim() != string.Empty)
                    {

                        dalHelper.CreateParameter("@OutType", cboOutType.Text.ToUpper(), DbType.String);
                        where += " OutType=@OutType and ";
                    }

                    if (cboDepartment.Text.ToUpper() != "ALL" && !string.IsNullOrEmpty(cboDepartment.Text.Trim()))
                    {
                        dalHelper.CreateParameter("@Department", cboDepartment.Text.Trim().ToUpper(), DbType.String);
                        where += " Department=@Department and ";
                    }

                    if (cboUnit.Text.ToUpper() != "ALL" && !string.IsNullOrEmpty(cboUnit.Text.Trim()))
                    {
                        dalHelper.CreateParameter("@Unit", cboUnit.Text.Trim().ToUpper(), DbType.String);
                        where += " Unit=@Unit and ";
                    }
                    if (comboBoxUsertype.Text == "INTERNS")
                    {
                        if (!string.IsNullOrEmpty(comboInterntype.Text.Trim()))
                        {
                            dalHelper.CreateParameter("@UserType", comboInterntype.Text.ToUpper(), DbType.String);
                            where += " UserType=@UserType and ";
                        }
                        else
                        {
                            MessageBox.Show("Please select intern type");
                            return;
                        }
                    }
                    else if (comboBoxUsertype.Text == "EMPLOYEE")
                    {
                        dalHelper.CreateParameter("@UserType", comboBoxUsertype.Text.ToUpper(), DbType.String);
                        where += " UserType=@UserType and ";
                    }
                    if (where != string.Empty)
                    {
                        where = " where " + where.TrimEnd(" and ".ToCharArray());
                    }
                    string sql = string.Empty;
                    if (cboRptType.Text == "ATTENDANCE")
                    {
                        sql = "select * from AttendanceView " + where + " order by StaffID";
                    }
                    else if (cboRptType.Text == "LATENESS")
                    {
                        if (cboShiftType.Text != "ALL" && cboShiftType.Text != string.Empty)
                        {
                            //var lateness = _context.stpLateAttendance(cboShiftType.Text).ToList();
                            SqlDataAdapter da = new SqlDataAdapter();
                            var sdataTable = new DataTable("AttendanceView");
                            //var attList = new List<DataReference.AttendanceView>();
                            var con = new SqlConnection(dalHelper.ConnectionString());

                            SqlCommand cmd = new SqlCommand("stpLateAttendance", con);
                            cmd.Parameters.Add(new SqlParameter("@ShiftType", cboShiftType.Text));
                            cmd.Parameters.Add(new SqlParameter("@Department", cboDepartment.Text));
                            cmd.Parameters.Add(new SqlParameter("@Unit", cboUnit.Text));
                            cmd.Parameters.Add(new SqlParameter("@Zone", cboZone.Text));
                            cmd.Parameters.Add(new SqlParameter("@Category", cboGradeCategory.Text));
                            cmd.Parameters.Add(new SqlParameter("@Grade", cboGrade.Text));
                            if (comboBoxUsertype.Text == "INTERNS")
                            {
                                if (!string.IsNullOrEmpty(comboInterntype.Text.Trim()))
                                {
                                    cmd.Parameters.Add(new SqlParameter("@UserType", comboInterntype.Text));
                                }
                                else
                                {
                                    MessageBox.Show("Please select intern type");
                                    return;
                                }
                            }
                            else if (comboBoxUsertype.Text == "EMPLOYEE")
                            {
                                cmd.Parameters.Add(new SqlParameter("@UserType", comboBoxUsertype.Text));
                            }
                            if (datePickerFrom.Checked == false)
                            {
                                cmd.Parameters.Add(new SqlParameter("@FROMDate", "1/1/1753"));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@FROMDate", datePickerFrom.Value.Date));
                            }
                            if (datePickerTo.Checked == false)
                            {
                                cmd.Parameters.Add(new SqlParameter("@TODate", "12/31/9998"));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@TODate", datePickerTo.Value.Date));
                            }
                            cmd.Parameters.Add(new SqlParameter("@StaffMainID", staffIDtxt.Text.Trim()));
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand = cmd;
                            da.Fill(sdataTable);

                            AttendanceReportForm sform = new AttendanceReportForm(sdataTable, "LATENESS");
                            sform.Show();
                        }
                        else
                        {
                            MessageBox.Show("Please select shift type");
                            return;
                        }
                    }

                    var dataTable = new DataTable("AttendanceView");
                    dataTable = dalHelper.ExecuteReader(sql);
                    //dataTable.TableName = "AttendanceView";

                    AttendanceReportForm form = new AttendanceReportForm(dataTable);
                    frm.Close();
                    form.Show();
                }


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

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


        private void AttendanceReportSelect_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                datePickerFrom.Value = DateTime.Today.Date;
                datePickerFrom.Checked = false;
                datePickerTo.Value = DateTime.Today.Date;
                datePickerTo.Checked = false;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboInType.Text.ToLower().Trim() == "all" || cboInType.Text.ToLower().Trim() == string.Empty)
                {
                    type = "All";
                }
                else if (cboInType.Text.ToLower().Trim() == "clock in")
                {
                    type = "I";
                }
                else if (cboInType.Text.ToLower().Trim() == "clock out")
                {
                    type = "O";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboInType.Items.Clear();
                cboInType.Text = string.Empty;
                type = string.Empty;
                cboInType.Items.Add("All");
                cboInType.Items.Add("Clock In");
                cboInType.Items.Add("Clock Out");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void searchGrid_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void cboShiftType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboShiftType.Items.Clear();
                cboShiftType.Items.Add("ALL");
                var getShiftType = GlobalData._context.WorkShifts.ToList();
                foreach (var shift in getShiftType)
                {
                    cboShiftType.Items.Add(shift.Name);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void comboBoxUsertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxUsertype.Text == "INTERNS")
                {
                    lbintern.Visible = true;
                    comboInterntype.Visible = true;
                }
                else
                {
                    lbintern.Visible = false;
                    comboInterntype.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void comboInterntype_DropDown(object sender, EventArgs e)
        {
            try
            {
                comboInterntype.Items.Clear();
                var intern = GlobalData._context.InternshipTypes.Where(u => u.Active == true && u.Archived == false).OrderBy(u => u.Description).ToList();
                foreach (var item in intern)
                {
                    comboInterntype.Items.Add(item.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboCheckOutType.Items.Clear();
                cboCheckOutType.Text = string.Empty;
                cboCheckOutType.Items.Add("All");
                cboCheckOutType.Items.Add("N");
                cboCheckOutType.Items.Add("A");
                cboCheckOutType.Items.Add("S");
                cboCheckOutType.Items.Add("M");

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void AttendanceReportSelect_Load_1(object sender, EventArgs e)
        {

        }
    }
}
