using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;

namespace eMAS.Forms
{
    public partial class LeavesBulkEntry : Form
    {
        IDAL dal;
        IList<Department> departments;
        Company company;
        private DALHelper dalHelper;
        private LeaveBalanceDataMapper leaveBalanceDataMapper;

        DataReference.hrContextDataContext _context = new DataReference.hrContextDataContext();
        public LeavesBulkEntry()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.departments = new List<Department>();
            this.company = new Company();
            this.leaveBalanceDataMapper = new LeaveBalanceDataMapper();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (employeeList.Count == 0)
                    MessageBox.Show("No Records To Upload!");
                else
                {
                    int addIndex = 0;
                    dal.BeginTransaction();
                    foreach (var emp in employeeList)
                    {
                        //var checkemp = _context.StaffLeaves.Where(u => u.StaffID == emp.StaffID && u.Status == "Requested");
                        //if(checkemp.Count() > 0)
                        //{
                        //    MessageBox.Show(string.Format("{0} {1} {2}, has a pending leave request", emp.FirstName, emp.Surname, emp.OtherName));
                           
                        //}
                        //else
                        //{
                           
                        //}
                        Assign(emp, addIndex);
                        addIndex++;
                    }
                }
                dal.CommitTransaction();
                MessageBox.Show("Records Saved Successfully!");
                this.Close();
            }
            catch (Exception xi) {
                dal.RollBackTransaction();
                MessageBox.Show("Unable To Save Records!");
                Logger.LogError(xi);
            }
            
        }

        private void Assign(Employee emp, int addIndex)
        {
            Leave leave = new Leave();
            try
            {
                //leave.ID = leaveID;
                leave.Employee.StaffID = emp.StaffID;
                leave.Employee.ID = emp.ID;
                leave.StaffName =grid.Rows[addIndex].Cells["gridStaffName"].Value.ToString();
                leave.Status = "Requested";
                leave.LeaveType = "Annual Leave";
                leave.StartDate = grid.Rows[addIndex].Cells["gridStartDate"].Value != null ? Convert.ToDateTime(grid.Rows[addIndex].Cells["gridStartDate"].Value) : leave.StartDate;
                leave.EndDate = grid.Rows[addIndex].Cells["gridEndDate"].Value != null ? Convert.ToDateTime(grid.Rows[addIndex].Cells["gridEndDate"].Value) : leave.EndDate;
                leave.LeaveDate = grid.Rows[addIndex].Cells["gridLeaveDate"].Value != null ? Convert.ToDateTime(grid.Rows[addIndex].Cells["gridLeaveDate"].Value) : leave.LeaveDate;
                leave.NumberOfDays = grid.Rows[addIndex].Cells["gridNumberOfDays"].Value!=null?Convert.ToInt32(grid.Rows[addIndex].Cells["gridNumberOfDays"].Value):0;
                leave.User.ID = GlobalData.User.ID;

                leave.Resumed = grid.Rows[addIndex].Cells["gridResumed"].Value != null ? bool.Parse(grid.Rows[addIndex].Cells["gridResumed"].Value.ToString()) : true;
                leave.ResumedDate = grid.Rows[addIndex].Cells["gridResumptionDate"].Value != null ? Convert.ToDateTime(grid.Rows[addIndex].Cells["gridResumptionDate"].Value) : leave.ResumedDate;
               // leave.Reason = txtReason.Text.Trim();
               // leave.Institution = txtInstitution.Text.Trim();
               // leave.Programme = txtProgramme.Text.Trim();
                //leave.Duration = txtDuration.Text.Trim();
                leave.Approved = grid.Rows[addIndex].Cells["gridApproved"].Value != null? bool.Parse(grid.Rows[addIndex].Cells["gridApproved"].Value.ToString()):true;
                leave.ApprovedDate = grid.Rows[addIndex].Cells["gridApprovalDate"].Value != null ? Convert.ToDateTime(grid.Rows[addIndex].Cells["gridApprovalDate"].Value) : leave.ApprovedDate;
                leave.ApprovedUser = GlobalData.User.Name;
                leave.ApprovedUserStaffID = GlobalData.User.StaffID;


                leave.Recommended = grid.Rows[addIndex].Cells["gridRecommended"].Value != null ? bool.Parse(grid.Rows[addIndex].Cells["gridRecommended"].Value.ToString()) : true;
                leave.RecommendedDate = grid.Rows[addIndex].Cells["gridRecommendationDate"].Value != null ? Convert.ToDateTime(grid.Rows[addIndex].Cells["gridRecommendationDate"].Value) : leave.RecommendedDate;
                leave.RecommendedUser = GlobalData.User.Name;
                leave.RecommendedUserStaffID = GlobalData.User.StaffID;

                leave.Rejected = grid.Rows[addIndex].Cells["gridRejected"].Value != null ? bool.Parse(grid.Rows[addIndex].Cells["gridRejected"].Value.ToString()) : false;
                leave.RejectedDate = leave.Rejected == true ? Convert.ToDateTime(grid.Rows[addIndex].Cells["gridRejectedDate"].Value) : leave.RejectedDate;

                leave.Recalled = grid.Rows[addIndex].Cells["gridRecalled"].Value != null ? bool.Parse(grid.Rows[addIndex].Cells["gridRecalled"].Value.ToString()) : false;
                leave.RecalledReason = Convert.ToString(grid.Rows[addIndex].Cells["gridRecalledReason"].Value);
                leave.RecalledDate = grid.Rows[addIndex].Cells["gridRecalledDate"].Value != null ? Convert.ToDateTime(grid.Rows[addIndex].Cells["gridRecalledDate"].Value) : leave.RecalledDate;

                leave.LeaveYear =Convert.ToInt32(yearComboBox.Text);


                emp.LeaveTaken = (int)leaveBalanceDataMapper.getLeaveTaken(leave.LeaveYear, DateTime.Now.Month, emp.ID) + int.Parse(leave.NumberOfDays.ToString());
                emp.LeaveBalance = (int)(leaveBalanceDataMapper.getYearAnnualLeave(leave.LeaveYear, emp.ID) + leaveBalanceDataMapper.getMyLeaveArrears(leave.LeaveYear, leave.StartDate.Year, emp.ID) - leaveBalanceDataMapper.getLeaveTaken(leave.LeaveYear, leave.StartDate.Month, emp.ID)) - int.Parse(leave.NumberOfDays.ToString());

                emp.LeaveTaken = emp.LeaveTaken + int.Parse(leave.NumberOfDays.ToString());
                emp.LeaveBalance = emp.LeaveBalance - int.Parse(leave.NumberOfDays.ToString());

                if (leave.NumberOfDays>0)
                {
                    dal.Update(emp);

                    LeaveDataMapper leaveDataMapper = new LeaveDataMapper();
                  int id=  leaveDataMapper.SaveLeave(leave);

                    if (id > 0)
                    {
                        leave.ID = id;
                        dal.Update(leave);
                    }
                   
                }
               
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                //throw ex;
            }
        }
        private void yearComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                yearComboBox.Items.Clear();
                foreach (var year in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(year);
                }
            }
            catch (Exception xi) { }
           
        }

        private void cmbDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbDepartment.Items.Clear();
                cmbDepartment.Items.Add("ALL DEPARTMENTS");
                if (departments.Count <= 0)
                {
                    departments = dal.GetAll<Department>();
                }
                foreach (Department department in departments)
                {
                    cmbDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private bool Validation(bool useFind)
        {
            var error = string.Empty;
            errorProvider1.Clear();
            bool validate = true;
          
         if (yearComboBox.Text == string.Empty)
            {
                error = "Select Valid Year!";
                errorProvider1.SetError(yearComboBox, error);
                validate = false;
            }

            else if (useFind == true && cmbDepartment.Text == string.Empty)
            {
                error = "Select Department!";
                errorProvider1.SetError(cmbDepartment, error);
                validate = false;
            }
            else if (useFind == true && cboMechanised.Text == string.Empty)
            {
                error = "Select Mechanised Status!";
                errorProvider1.SetError(cboMechanised, error);
                validate = false;
            }
            if (error != string.Empty)
                MessageBox.Show("Error:" + error);

            //if(useFind)

            return validate;
        }
        EmployeeDataMapper employeeDataMapper;
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        IList<Employee> employeeList;
        private void btnFind_Click(object sender, EventArgs e)
        {
            employeeDataMapper = new EmployeeDataMapper();
            employeeList = new List<Employee>();
            try
            {
                grid.Rows.Clear();
                if (Validation(true))
                {
                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();

                    //dalHelper.CreateParameter("@name", nameTextBox.Text.Trim(), DbType.String);

                    string where = string.Empty;

                    

                    if (cmbDepartment.Text.ToUpper() != "ALL DEPARTMENTS")
                    {
                      dalHelper.CreateParameter("@Department", cmbDepartment.Text, DbType.String);
                      where = " Department=@Department and ";
                    }

                    if (cboMechanised.Text.ToUpper() != "ALL")
                    {
                        dalHelper.CreateParameter("@Mechanised", cboMechanised.Text.ToUpper() == "YES" ? true : false, DbType.Boolean);
                        where += "Mechanised=@Mechanised and ";
                    }

                    //if (yearComboBox.Text.ToUpper() != "ALL")
                    //{
                    //    dalHelper.CreateParameter("@Year", Convert.ToInt32(yearComboBox.Text), DbType.Int32);
                    //    where += "year(employmentDate)<=@Year and ";
                    //}

                    dalHelper.CreateParameter("@Archived", false, DbType.Int32);
                    where += " Archived=@Archived and ";

                    dalHelper.CreateParameter("@Terminated", false, DbType.Int32);
                    where += " Terminated=@Terminated and ";

                    dalHelper.CreateParameter("@TransferredOut", false, DbType.Int32);
                    where += " TransferredOut=@TransferredOut ";

                    where = where.TrimEnd(" and ".ToCharArray());
                    string sql = "select *,REPLACE(MobileNo,'-','') as MobileNumber from StaffPersonalInfoLazyLoadView where " + where + "  order by staffID";
                    var dt = dalHelper.ExecuteReader(sql);

                     employeeList = employeeDataMapper.BuildLazyLoadEmployeeData(dt);

                    if (employeeList.Count == 0)
                    {
                        MessageBox.Show("No. Employees  found");
                        //staffIDTextBox.Text = string.Empty;
                    }
                    else
                        PopulateGrid(employeeList);
                }

            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void PopulateGrid(IList<Employee> empList)
        {
            try
            {
                grid.Rows.Clear();
                int ctr = 0;
                foreach (var emp in empList)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = emp.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = emp.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = (emp.FirstName + " " + emp.OtherName).Trim() + " " + emp.Surname;
                    ctr++;
                }
            }
            catch (Exception xi) { }
            
        }
    }
}
