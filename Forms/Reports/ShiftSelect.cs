using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.Reports
{
    public partial class ShiftSelect : Form
    {
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<Internship> internship;
        private IList<Internship> internshipList;
        private IList<Department> departments;
        private IList<Unit> units;
        private DALHelper dalHelper;
        private IDAL dal;
        private Company company;
        private int ctr;

        //DataReference.hrContextDataContext _context = new DataReference.hrContextDataContext();

        public ShiftSelect()
        {
            InitializeComponent();
            this.employees = new List<Employee>();
            this.employeeList = new List<Employee>();
            this.departments = new List<Department>();
            this.units = new List<Unit>();
            this.dal = new DAL();
            this.company = new Company();
            this.ctr = 0;
            this.dalHelper = new DALHelper();
            this.internship = new List<Internship>();
            this.internshipList = new List<Internship>();
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
                searchGrid.Visible = false;
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
                        
                        if(comboBoxUsertype.Text == "EMPLOYEES")
                        {
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
                        if (comboBoxUsertype.Text == "INTERNS")
                        {
                            internship = dal.LazyLoad<Internship>();
                            foreach (Internship intern in internship)
                            {
                                string name = (intern.OtherName == string.Empty ? string.Empty : " " + intern.OtherName) + " " + intern.Surname;
                                if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = intern.StaffID;
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
                        if(comboBoxUsertype.Text == "EMPLOYEES")
                        {
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
                        if(comboBoxUsertype.Text == "INTERNS")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "InternshipView.StaffID",
                                CriterionOperator = CriterionOperator.Like,
                                Value = staffIDtxt.Text.Trim() + '%',
                                CriteriaOperator = CriteriaOperator.And
                            });
                            //query.Criteria.Add(new Criterion()
                            //{
                            //    Property = "StaffPersonalInfoLazyLoadView.Terminated",
                            //    CriterionOperator = CriterionOperator.EqualTo,
                            //    Value = false,
                            //    CriteriaOperator = CriteriaOperator.And
                            //});
                            //query.Criteria.Add(new Criterion()
                            //{
                            //    Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                            //    CriterionOperator = CriterionOperator.EqualTo,
                            //    Value = false,
                            //    CriteriaOperator = CriteriaOperator.And
                            //});
                            internship = dal.LazyLoadCriteria<Internship>(query);
                            if (internship.Count > 0)
                            {
                                foreach (Internship intern in internship)
                                {
                                    string name = (intern.OtherName == string.Empty ? string.Empty : " " + intern.OtherName) + " " + intern.Surname;
                                    if (intern.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                    {
                                        found = true;
                                        searchGrid.Rows.Add(1);
                                        searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                        searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = intern.StaffID;
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
                                MessageBox.Show("Intern with StaffID " + staffIDtxt.Text + " is not Found");
                                staffIDtxt.Text = string.Empty;
                            }
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
        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                   
                    dalHelper.ClearParameters();
                    string where = string.Empty;
                    string staffname = string.Empty;
                    string sql = string.Empty;
                    if (comboBoxUsertype.Text == "INTERNS")
                    {
                        if (staffIDtxt.Text != string.Empty)
                        {
                            dalHelper.CreateParameter("@StaffID", staffIDtxt.Text, DbType.String);
                            where += " staffID=@StaffID and ";
                            var user = GlobalData._context.InternshipViews.SingleOrDefault(u => u.StaffID == staffIDtxt.Text.Trim());
                            staffname = string.Format("{0} {1}",user.Surname, user.OtherName);
                        }
                    }
                    else
                    {
                        if (staffIDtxt.Text != string.Empty)
                        {
                            dalHelper.CreateParameter("@StaffID", staffIDtxt.Text, DbType.String);
                            where += " staffID=@StaffID and ";
                            var user = GlobalData._context.StaffPersonalInfoViews.SingleOrDefault(u => u.StaffID == staffIDtxt.Text.Trim());
                            staffname = string.Format("{0} {1} {2}", user.Firstname, user.Surname, user.OtherName);
                        }
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
                   if(comboBoxUsertype.Text == "EMPLOYEE")
                   {
                       dalHelper.CreateParameter("@Usertype", comboBoxUsertype.Text, DbType.String);
                       where += " Usertype=@Usertype and ";
                   }
                   if(comboBoxUsertype.Text == "INTERNS")
                   {
                       if(comboInterntype.SelectedIndex != -1)
                       {
                           dalHelper.CreateParameter("@Usertype", comboInterntype.Text, DbType.String);
                           where += " Usertype=@Usertype and ";
                       }
                       
                   }
                    if (cboDepartment.Text.ToUpper() != "ALL" && !string.IsNullOrEmpty(cboDepartment.Text.Trim()))
                    {
                        dalHelper.CreateParameter("@Department", cboDepartment.Text, DbType.String);
                        where += " Department=@Department and ";
                    }

                    if (cboUnit.Text.ToUpper() != "ALL" && !string.IsNullOrEmpty(cboUnit.Text.Trim()))
                    {
                        dalHelper.CreateParameter("@Unit", cboUnit.Text, DbType.String);
                        where += " Unit=@Unit and ";
                    }
                    if (where != string.Empty)
                    {
                        where = " where " + where.TrimEnd(" and ".ToCharArray());
                    }

                    var dataTable = new DataTable("StaffShift_View");

                    if (comboBoxUsertype.Text == "INTERNS")
                    {
                        if(cboRptType.Text != "ABSENT")
                        {
                            sql = "select * from InternShip_Shift " + where + " order by StaffID";
                            dataTable = dalHelper.ExecuteReader(sql);
                            //dataTable.TableName = "AttendanceView";

                            staffname = "INTERNS ABSENTEE(S) SHIFT REPORT";
                            ShiftSelectform form = new ShiftSelectform(dataTable, comboBoxUsertype.Text, staffname, "");
                            form.Show();
                
                        }
                        else
                        {
                            //InternAbsentees_View
                            staffname = "INTERNS SHIFT REPORT";
                            sql = "select * from InternAbsentees_View " + where + " order by StaffID";
                            dataTable = dalHelper.ExecuteReader(sql);
                            //var absent = new List<DataReference.InternShip_Shift>();
                            //var getShift = _context.InternShip_Shifts.ToList();
                            //foreach(var staff in getShift)
                            //{
                            //    var list = _context.StaffAttendances.Where(u => u.StaffID == staff.staffId && u.Date == staff.Date);
                            //    if(list.Count() == 0)
                            //    {
                            //        absent.Add(staff);
                            //    }
                            //}
                            //dataTable = ToDataTable<DataReference.InternShip_Shift>(absent);

                            //SqlDataAdapter da = new SqlDataAdapter();
                            //var sdataTable = new DataTable("AttendanceView");
                            ////var attList = new List<DataReference.AttendanceView>();
                            //var con = new SqlConnection(dalHelper.ConnectionString());

                            //SqlCommand cmd = new SqlCommand("stpInternShiftAbsentee", con);
                            //cmd.Parameters.Add(new SqlParameter("@ShiftType", DBNull.Value));
                            //cmd.Parameters.Add(new SqlParameter("@Department", cboDepartment.Text));
                            //cmd.Parameters.Add(new SqlParameter("@Unit", cboUnit.Text));
                            //cmd.Parameters.Add(new SqlParameter("@Zone", DBNull.Value));
                            //cmd.Parameters.Add(new SqlParameter("@Category", DBNull.Value));
                            //cmd.Parameters.Add(new SqlParameter("@Grade", DBNull.Value));
                            //if (datePickerFrom.Checked == false)
                            //{
                            //    cmd.Parameters.Add(new SqlParameter("@FROMDate", "1/1/1753"));
                            //}
                            //else
                            //{
                            //    cmd.Parameters.Add(new SqlParameter("@FROMDate", datePickerFrom.Value.Date));
                            //}
                            //if (datePickerTo.Checked == false)
                            //{
                            //    cmd.Parameters.Add(new SqlParameter("@TODate", "12/31/9998"));
                            //}
                            //else
                            //{
                            //    cmd.Parameters.Add(new SqlParameter("@TODate", datePickerTo.Value.Date));
                            //}
                            //cmd.Parameters.Add(new SqlParameter("@StaffID", staffIDtxt.Text.Trim()));
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //da.SelectCommand = cmd;
                            //da.Fill(sdataTable);

                            ShiftSelectform sform = new ShiftSelectform(dataTable, comboBoxUsertype.Text, staffname, "ABSENT");

                            sform.Show();
                        }
                    }
                    else
                    {
                        if (cboRptType.Text != "ABSENT")
                        {
                            sql = "select * from StaffShift_View " + where + " order by StaffID";                           
                            dataTable = dalHelper.ExecuteReader(sql);
                            //dataTable.TableName = "AttendanceView";
                            staffname = "EMPLOYEE(S) ABSENTEE(S) SHIFT REPORT";

                            ShiftSelectform form = new ShiftSelectform(dataTable, comboBoxUsertype.Text, staffname, "");
                            form.Show();
                
                        }
                        else
                        {
                            sql = "select * from StaffAbsentees_View " + where + " order by StaffID";
                            dataTable = dalHelper.ExecuteReader(sql);
                            //dataTable.TableName = "AttendanceView";
                            staffname = "EMPLOYEE(S) SHIFT REPORT";
                            //var absent = new List<DataReference.StaffShift_View>();
                            //var getShift = _context.StaffShift_Views.ToList();
                            //foreach (var staff in getShift)
                            //{
                            //    var list = _context.StaffAttendances.Where(u => u.StaffID == staff.staffId && u.Date == staff.Date);
                            //    if (list.Count() == 0)
                            //    {
                            //        absent.Add(staff);
                            //    }
                            //}
                            //dataTable = ToDataTable<DataReference.StaffShift_View>(absent);

                            //SqlDataAdapter da = new SqlDataAdapter();
                            //var sdataTable = new DataTable("AttendanceView");
                            ////var attList = new List<DataReference.AttendanceView>();
                            //var con = new SqlConnection(dalHelper.ConnectionString());

                            //SqlCommand cmd = new SqlCommand("stpShiftAbsentee", con);
                            //cmd.Parameters.Add(new SqlParameter("@ShiftType", DBNull.Value));
                            //cmd.Parameters.Add(new SqlParameter("@Department", cboDepartment.Text));
                            //cmd.Parameters.Add(new SqlParameter("@Unit", cboUnit.Text));
                            //cmd.Parameters.Add(new SqlParameter("@Zone", DBNull.Value));
                            //cmd.Parameters.Add(new SqlParameter("@Category", DBNull.Value));
                            //cmd.Parameters.Add(new SqlParameter("@Grade", DBNull.Value));
                            //if (datePickerFrom.Checked == false)
                            //{
                            //    cmd.Parameters.Add(new SqlParameter("@FROMDate", "1/1/1753"));
                            //}
                            //else
                            //{
                            //    cmd.Parameters.Add(new SqlParameter("@FROMDate", datePickerFrom.Value.Date));
                            //}
                            //if (datePickerTo.Checked == false)
                            //{
                            //    cmd.Parameters.Add(new SqlParameter("@TODate", "12/31/9998"));
                            //}
                            //else
                            //{
                            //    cmd.Parameters.Add(new SqlParameter("@TODate", datePickerTo.Value.Date));
                            //}
                            //cmd.Parameters.Add(new SqlParameter("@StaffID", staffIDtxt.Text.Trim()));
                            //cmd.CommandType = CommandType.StoredProcedure;
                            //da.SelectCommand = cmd;
                            //da.Fill(sdataTable);

                            ShiftSelectform sform = new ShiftSelectform(dataTable, comboBoxUsertype.Text, staffname, "ABSENT");
                            sform.Show();
                        }
                    }
                 
                }


            }
            catch(Exception ex)
            {

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


        private void comboBoxUsertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(comboBoxUsertype.Text == "INTERNS")
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
            catch(Exception ex)
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
    }
}
