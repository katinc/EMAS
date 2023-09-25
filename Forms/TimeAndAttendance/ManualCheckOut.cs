using eMAS.DataReference;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRDataAccessLayerBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace eMAS.Forms.TimeAndAttendance
{
    public partial class ManualCheckOut : Form
    {

        //hrContextDataContext context = new hrContextDataContext();
        private int ctr;
        private IList<Attendance> staffAttendances;
        private IDAL dal;
        DALHelper dals;
        private IList<DDepartment> departments;
        private Company company;
        private bool found;
        private IList<Attendance> foundAttendances;
        private AttendanceDataMapper attendanceDataMapper;
        private Employee employee;

        public Permissions permissions;

        public ManualCheckOut()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.company = new Company();
            this.found = false;
            this.departments = new List<DDepartment>();
            this.foundAttendances = new List<Attendance>();
            this.attendanceDataMapper = new AttendanceDataMapper();
            dals = new DALHelper();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.DataSource = null;

                var department = GlobalData._context.DDepartments.ToList();

                if (department.Count() > 0)
                {
                    cboDepartment.DataSource = department;
                    cboDepartment.ValueMember = "ID";
                    cboDepartment.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void cboUnit_DropDown(object sender, EventArgs e)
        {
            
        }


        private void GetData()
        {
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();

                var dates = attendanceDatePicker.Value;

                var onlyDatePart = dates.Year + "/" + dates.Month + "/" + dates.Day;
                var dateStart = onlyDatePart + " 00:00:00 ";
                var dateEnd = onlyDatePart + " 23:59:59 ";

                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAttendanceView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }

                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAttendanceView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboDepartment.Text,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAttendanceView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboUnit.Text,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (tbStaffID.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAttendanceView.StaffMainID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = tbStaffID.Text,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cbNotCheckedOut.Checked)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAttendanceView.CheckOutType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = "N",
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (attendanceDatePicker.Checked)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAttendanceView.AttendanceDate",
                        CriterionOperator = CriterionOperator.GreaterThanOrEqualTo,
                        Value = dateStart,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (attendanceDatePicker.Checked)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAttendanceView.AttendanceDate",
                        CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                        Value = dateEnd,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffAttendanceView.CheckOutType",
                    CriterionOperator = CriterionOperator.NotEqualTo,
                    Value = "A",
                    CriteriaOperator = CriteriaOperator.None
                });

                staffAttendances = dal.GetByCriteria<Attendance>(query);
                PopulateView(staffAttendances);
                frm.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void PopulateView(IList<Attendance> staffAttendance) 
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();

                foreach (Attendance attendance in staffAttendances)
                {

                    var date = attendance.CheckoutTime;
                    string datePart = string.Empty;
                    string timePart = string.Empty;

                    if (date != string.Empty)
                    {
                        //selectStatement.Substring(0, selectStatement.Length - suffix.Length);     "1/23/2020 7:58:24 AM"
                        int dateLen = 9;
                        int timeLen = 10;
                        datePart = date.Substring(0, date.Length - timeLen);
                        timePart = date.Substring(dateLen, date.Length - dateLen);
                    }

                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = attendance.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = attendance.StaffMainID;
                    grid.Rows[ctr].Cells["gridDeviceStaffID"].Value = attendance.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridName"].Value = attendance.Employee.FirstName + " " + attendance.Employee.OtherName + " " + attendance.Employee.Surname;
                    grid.Rows[ctr].Cells["gridCheckInTime"].Value = attendance.CheckinTime;
                    grid.Rows[ctr].Cells["gridCheckOutTime"].Value = timePart;
                    grid.Rows[ctr].Cells["gridCheckOutDate"].Value = datePart;
                    grid.Rows[ctr].Cells["gridDate"].Value = attendance.Date;
                    grid.Rows[ctr].Cells["gridCheckInDeviceID"].Value = attendance.CheckinDeviceID;
                    grid.Rows[ctr].Cells["gridCheckOutDeviceID"].Value = attendance.CheckoutDeviceID;
                    //grid.Rows[ctr].Cells["gridUserType"].Value = attendance.UserType;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = attendance.Department;
                    grid.Rows[ctr].Cells["gridUnit"].Value = attendance.Unit;
                    grid.Rows[ctr].Cells["gridCheckOutType"].Value = attendance.CheckOutType;

                    ctr++;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboUnit_DropDown(sender, e);
        }

        private void tbStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbStaffID.Text.Trim() != string.Empty)
                {
                    
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (tbStaffID.Text.Length >= company.MinimumCharacter)
                    {
                        foundAttendances.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffAttendanceView.StaffMainID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = tbStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.None
                        });
                        staffAttendances = dal.GetByCriteria<Attendance>(query);
                        if (staffAttendances.Count > 0)
                        {
                            foreach (Attendance attendance in this.staffAttendances)
                            {
                                string name = attendance.Employee.FirstName + (attendance.Employee.OtherName == string.Empty ? string.Empty : " " + attendance.Employee.OtherName) + " " + attendance.Employee.Surname;
                                tbName.Text = name;

                                if (attendance.Employee.StaffID.Trim().ToLower().StartsWith(tbStaffID.Text.Trim().ToLower()))
                                {
                                    foundAttendances.Add(attendance);
                                }
                            }
                            PopulateView(foundAttendances);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + tbStaffID.Text + " is not Found");
                            tbStaffID.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (tbName.Text.Length >= 3)
                //{
                //    staffAttendances = GlobalData._context.StaffAttendanceViews.Where(u =>
                //    (u.Firstname.Contains(tbStaffID.Text) || u.Firstname == null)
                //    ).ToList();

                //    PopulateView(staffAttendances);
                //}
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void cbCheckedOut_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                
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
                throw ex;
            }
        }

        private void Clear()
        {
            try
            {
                cboDepartment.DataSource = null;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;

                cboUnit.DataSource = null;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;

                attendanceDatePicker.Checked = false;

                tbStaffID.Text = string.Empty;
                tbName.Text = string.Empty;

                //cbNotCheckedOut.Checked = false;

                this.grid.DataSource = null;
                this.grid.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            ctr = 0;
            bool rowUpdated = false;

            Application.DoEvents();
            eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
            frm.Show(this);
            Application.DoEvents();

            foreach (DataGridViewRow row in grid.Rows)
            {
                try 
	            {
                    if (grid.Rows[ctr].Cells["gridSelect"].Value != null)
                    {
                        //get values from gridView
                        string checkOutTime = grid.Rows[ctr].Cells["gridCheckOutTime"].Value.ToString();
                        string checkOutDate = grid.Rows[ctr].Cells["gridCheckOutDate"].Value.ToString();
                        string checkInTime = grid.Rows[ctr].Cells["gridCheckInTime"].Value.ToString();
                        string checkOutDeviceID = grid.Rows[ctr].Cells["gridCheckOutDeviceID"].Value.ToString();
                        string checkOutType = grid.Rows[ctr].Cells["gridCheckOutType"].Value.ToString();
                        string checkInDeviceID = grid.Rows[ctr].Cells["gridCheckInDeviceID"].Value.ToString();
                        string attendanceID = grid.Rows[ctr].Cells["gridID"].Value.ToString();


                        //check if payroll for month and year is closed
                        //var staffAttendance in staffAttendances
                        var staffAttendance = GlobalData._context.StaffAttendances.SingleOrDefault(u => u.ID.ToString() == attendanceID);
                        var date = Convert.ToDateTime(staffAttendance.AttendanceDate);
                        var user = GlobalData._context.StaffSalaryPaymentViews.SingleOrDefault(u => u.StaffID == staffAttendance.StaffMainID && u.Status == 2 && u.Month == date.Month && u.Year == date.Year.ToString());
                        //if user = null, then payroll is closed!

                        if (user == null)
                        {
                            if (checkOutDate == string.Empty || checkOutTime == string.Empty)
                            {
                                MessageBox.Show("CheckOut date or time cannot be empty for selected row with StaffID: " + staffAttendance.StaffMainID);
                            }
                            else if (checkOutDeviceID == string.Empty || checkInDeviceID == string.Empty)
                            {
                                MessageBox.Show("checkOutDeviceID or checkInDeviceID fields cannot be empty for selected rows with StaffID: " + staffAttendance.StaffMainID);
                            }
                            else
                            {
                                checkOutDate = Convert.ToDateTime(checkOutDate).ToShortDateString();

                                var updateAttendance = GlobalData._context.StaffAttendances.First(u => u.ID == staffAttendance.ID);
                                if (updateAttendance != null)
                                {
                                    updateAttendance.Archived = false;

                                    var joinCheckOutTime = checkOutDate + " " + checkOutTime;

                                    //check if check out time is earlier than check in time
                                    if (DateTime.Parse(joinCheckOutTime) > DateTime.Parse(staffAttendance.CheckInTime.ToString()))
                                    {
                                        updateAttendance.CheckOutTime = Convert.ToDateTime(joinCheckOutTime);
                                        updateAttendance.CheckOutDeviceID = Convert.ToInt32(grid.Rows[ctr].Cells["gridCheckOutDeviceID"].Value);
                                        updateAttendance.CheckInDeviceID = Convert.ToInt32(grid.Rows[ctr].Cells["gridCheckInDeviceID"].Value);
                                        updateAttendance.CheckOutType = 'M';

                                        GlobalData._context.SubmitChanges();
                                        rowUpdated = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("CheckOutTime cannot be earlier than Check in time for StaffID: " + staffAttendance.StaffMainID);
                                    }


                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot perform Manual Check out, Payroll already closed for the period for StaffID: " + staffAttendance.StaffMainID);
                        }
                    }
                        }   
	            catch (Exception ex)
	            {
		
		            throw ex;
	            }
                ctr++;
            }
	        {
		 
	    }
            frm.Close();

            if (rowUpdated == true)
            {
                MessageBox.Show("Checkout time edited successfully");
                btnSearch_Click(sender,e);
            }
            else
            {
                MessageBox.Show("Select at least one row");
            }
        }

        private void grid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #region BuildAttendanceFromData
        //private IList<Attendance> BuildAttendanceFromData(DataTable table)
        //{
        //    IList<Attendance> attendances = new List<Attendance>();
        //    try
        //    {
        //        foreach (DataRow row in table.Rows)
        //        {
        //            Attendance attendance = new Attendance()
        //            {
        //                ID = int.Parse(row["ID"].ToString()),
        //                Employee = new Employee()
        //                {
        //                    //ID = int.Parse(row["ID"].ToString()),
        //                    StaffID = row["StaffID"].ToString(),
        //                    Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
        //                    FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
        //                    OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
        //                },
        //                AttendanceDate = DateTime.Parse(row["AttendanceDate"].ToString()),
        //                AttendanceTime = (row["AttendanceTime"].ToString()),
        //                CheckoutTime = row["CheckOutTime"].ToString(),
        //                CheckinTime = (row["CheckInTime"].ToString()),
        //                StaffMainID = (row["StaffMainId"].ToString()),
        //                DeviceID = (row["DeviceID"].ToString()),
        //                CheckinDeviceID = (row["CheckInDeviceID"].ToString()),
        //                CheckoutDeviceID = (row["CheckoutDeviceID"].ToString()),
        //                Date = DateTime.Parse(row["Date"].ToString()),
        //                //UserID = (row["UserID"].ToString()),
        //                Department = (row["Department"].ToString()),
        //                Unit = (row["Unit"].ToString()),
        //                CheckOutType = (row["CheckOutType"].ToString()),


        //            };
        //            attendances.Add(attendance);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //        throw ex;
        //    }
        //    return attendances;
        //}


        #endregion

        private void attedanceDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void attedanceDate_CloseUp(object sender, EventArgs e)
        {
            //if (attedanceDate.Checked == true)
            //{
            //    var dates = attedanceDate.Value;

            //    var onlyDatePart = dates.Year + "/" + dates.Month + "/" + dates.Day;
            //    var dateStart = onlyDatePart + " 00:00:00 ";
            //    var dateEnd = onlyDatePart + " 23:59:59 ";


            //    try
            //    {
            //        foundAttendances.Clear();
            //        Query query = new Query();

            //        string querys = string.Empty;
            //        querys = "SELECT * FROM [dbo].[StaffAttendanceView] where StaffAttendanceView.AttendanceDate >= '" + dateStart + "' and StaffAttendanceView.AttendanceDate <= '" + dateEnd + "' order by StaffAttendanceView.AttendanceDate DESC";

            //        IList<Attendance> attendances = new List<Attendance>();
            //        DataTable table = new DataTable();

            //        dals.ExecuteNonQuery(querys);
            //        table = dals.ExecuteReader(querys);
            //        foreach (Attendance attend in BuildAttendanceFromData(table))
            //        {
            //            attendances.Add(attend);
            //        }
            //        staffAttendances = attendances;
            //        if (staffAttendances.Count > 0)
            //        {
            //            foreach (Attendance attendance in this.staffAttendances)
            //            {
            //                if (attendance != null)
            //                {
            //                    foundAttendances.Add(attendance);
            //                }
            //            }
            //            PopulateView(foundAttendances);
            //        }
            //        else
            //        {
            //            MessageBox.Show("No employees found on specified date");
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        throw ex;
            //    }

            //}
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboUnit.DataSource = null;

            try
            {
                var departmentID = decimal.Parse(cboDepartment.SelectedValue.ToString());
                var units = GlobalData._context.Units.Where(u => u.DepartmentID == departmentID);

                if (units.Count() > 0)
                {
                    cboUnit.DataSource = units;
                    cboUnit.ValueMember = "ID";
                    cboUnit.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ManualCheckOut_Load(object sender, EventArgs e)
        {
            permissions = GlobalData.CheckPermissions(2);
            btnSave.Enabled = permissions.CanAdd;

        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
                try
                {
                    ctr = grid.CurrentCell.RowIndex;

                    var type = grid.CurrentCell.GetType();

                        //get values from gridView
                    string checkOutTime = grid.Rows[ctr].Cells["gridCheckOutTime"].Value.ToString();
                    string checkOutDate = grid.Rows[ctr].Cells["gridCheckOutDate"].Value.ToString();
                    string checkInTime = grid.Rows[ctr].Cells["gridCheckInTime"].Value.ToString();
                    string checkOutType = grid.Rows[ctr].Cells["gridCheckOutType"].Value.ToString();

                    if (checkOutDate != string.Empty && checkOutType != "A")
                    {

                        DateTime date = Convert.ToDateTime(checkOutDate) ;
                        DateTime checkOut = Convert.ToDateTime(date.ToShortDateString() + " " + checkOutTime);
                        DateTime checkIn = Convert.ToDateTime(checkInTime);

                        if (checkOut <= checkIn && checkOutTime != string.Empty)
                        {
                            grid.Rows[ctr].Cells["gridCheckOutDate"].Value = string.Empty;
                            grid.Rows[ctr].Cells["gridCheckOutTime"].Value = string.Empty;
                            MessageBox.Show("CheckOut Time cannot be earlier than checkIn time.");
                        }
                        //else
                        //{
                        //    if (type.ToString() == "CalendarCell")
                        //    {
                        //        var newDate = string.Format("{0}/{1}/{2}", date.Day, date.Month, date.Year);
                        //        var newDates = date.ToString("dd/MM/yyyy");
                        //        grid.Rows[ctr].Cells["gridCheckOutDate"].Value = date.Day + "/" + date.Month + "/" + date.Year;
                        //    }
                        //}
                    }
                    else if (checkOutType == "A")
                    {
                        MessageBox.Show("You can not checkout details for Automatic CheckOut Type");
                    }
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }

        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    string checkOutTime = grid.Rows[ctr].Cells["gridCheckOutTime"].Value.ToString();
            //    string checkOutDate = grid.Rows[ctr].Cells["gridCheckOutDate"].Value.ToString();
            //    string checkInTime = grid.Rows[ctr].Cells["gridCheckInTime"].Value.ToString();
            //}
            //catch (Exception ex)
            //{
                
            //    throw ex;
            //}
            
        }
    }
}
