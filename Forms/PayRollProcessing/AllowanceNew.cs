using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using HRBussinessLayer.Validation;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class AllowanceNew : Form
    {
        private IList<StaffAllowance> staffAllowances;
        private StaffAllowance staffAllowance;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private Allowance allowanceType;
        private IList<Allowance> allowanceTypes;
        private Employee employee;
        private Company company;
        private int ctr;
        private IDAL dal;
        private string gradeLevel;
        private int staffCode;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        
        public AllowanceNew()
        {
            try
            {
                InitializeComponent();

                this.staffAllowances = new List<StaffAllowance>();
                this.staffAllowance = new StaffAllowance();
                this.allowanceTypes = new List<Allowance>();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.allowanceType = new Allowance();
                this.company = new Company();
                this.employee = new Employee();
                this.dal = new DAL();
                this.ctr = 0;
                this.staffCode = 0;
                this.allowanceTypes = dal.GetAll<Allowance>();
                this.staffAllowances = dal.GetAll<StaffAllowance>();
                this.GetDataAllowances();
                this.GetFrequencies();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public AllowanceNew(string staffID)
        {
            try
            {
                InitializeComponent();
                this.staffAllowances = new List<StaffAllowance>();
                this.staffAllowance = new StaffAllowance();
                this.allowanceTypes = new List<Allowance>();
                this.allowanceType = new Allowance();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.dal = new DAL();
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffCode = 0;              
                this.allowanceTypes = dal.GetAll<Allowance>();
                this.staffAllowances = dal.GetAll<StaffAllowance>();
                this.GetDataAllowances();
                this.GetFrequencies();
                if (this.employees.Count <= 0)
                {
                    this.employees = dal.LazyLoad<Employee>();
                }
                foreach (Employee employee in employees)
                {
                    if (employee.StaffID.Trim() == staffID.Trim())
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        nametxt.Text = name;
                        staffIDtxt.Text = employee.StaffID;
                        staffCode = employee.ID;
                        gendertxt.Text = employee.Gender;
                        pictureBox.Image = employee.Photo;
                        agetxt.Text = employee.Age;
                        searchGrid.Visible = false;
                        groupBox2.Enabled = true;
                        GetAllowances();
                    }
                }
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void GetFrequencies()
        {
            try
            {
                gridFrequency.Items.Clear();
                //gridFrequency.Items.Add("Yearly");
                gridFrequency.Items.Add("Monthly");
                //gridFrequency.Items.Add("Weekly");
                //gridFrequency.Items.Add("Daily");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void GetDataAllowances()
        {
            try
            {
                gridType.Items.Clear();
                this.allowanceTypes = dal.GetAll<Allowance>();
                foreach (Allowance allowance in allowanceTypes)
                {
                    if (allowance.InUse)
                    {
                        gridType.Items.Add(allowance.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentCell != null)
                {
                    if (grid.CurrentCell.ColumnIndex == 2)
                    {
                        this.GetDataAllowances();
                    }
                    else if (grid.CurrentCell.ColumnIndex == 3)
                    {
                        GetFrequencies();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        void staffIDtxt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!searchGrid.Focused)
                {
                    searchGrid.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void nametxt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!searchGrid.Focused)
                {
                    searchGrid.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                grid.CurrentCellDirtyStateChanged += new EventHandler(grid_CurrentCellDirtyStateChanged);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentCell != null)
                {
                    if (grid.CurrentCell.ColumnIndex == 2)
                    {
                        if (grid.CurrentRow != null)
                        {
                            foreach (Allowance allowance in allowanceTypes)
                            {
                                if (allowance.Description == grid.CurrentRow.Cells["gridType"].Value.ToString())
                                {
                                    grid.CurrentRow.Cells["gridAmount"].Value = decimal.Round(allowance.Amount, 2);
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.grid.IsCurrentCellDirty)
                {
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetAllowances()
        {
            try
            {
                //Get Allowances
                grid.Rows.Clear();
                int ctr = 0;
                foreach (StaffAllowance staffAllowance in staffAllowances)
                {
                    if (staffAllowance.Employee.StaffID == staffIDtxt.Text.Trim())
                    {
                        grid.Rows.Add(1);
                        grid.Rows[ctr].Cells["gridID"].Value = staffAllowance.ID;
                        grid.Rows[ctr].Cells["gridType"].Value = staffAllowance.Type.Description;
                        grid.Rows[ctr].Cells["gridFrequency"].Value = staffAllowance.Frequency;
                        grid.Rows[ctr].Cells["gridAmount"].Value = staffAllowance.Amount;
                        grid.Rows[ctr].Cells["gridEffectiveDate"].Value = staffAllowance.EffectiveDate;
                        grid.Rows[ctr].Cells["gridIsEndDate"].Value = staffAllowance.IsEndDate;
                        grid.Rows[ctr].Cells["gridEndDate"].Value = staffAllowance.EndDate;
                        grid.Rows[ctr].Cells["gridInUse"].Value = staffAllowance.InUse;
                        grid.Rows[ctr].Cells["gridStaffID"].Value = staffAllowance.Employee.StaffID;
                        grid.Rows[ctr].Cells["gridUserID"].Value = staffAllowance.User.ID;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;
                            if (employee.Photo != null)
                            {
                                pictureBox.Image = employee.Photo;
                            }
                            else
                            {
                                pictureBox.Image = pictureBox.InitialImage;
                            }
                            gradeLevel = employee.Grade.Level;
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox2.Enabled = true;
                            GetAllowanceByEmployee(staffIDtxt.Text.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void AllowanceNew_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                groupBox2.Enabled = false;
                staffIDtxt.Select();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    btnUseBulkEntry.Enabled = getPermissions.CanAdd;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
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


        private void Clear()
        {
            try
            {
                grid.Rows.Clear();
                ClearStaffInfo();
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
                staffErrorProvider.Clear();
                staffIDtxt.Clear();
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                pictureBox.Image = pictureBox.InitialImage;
                groupBox2.Enabled = false;
                searchGrid.Visible = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                    Clear();
                }
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
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
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

        private void buildAllowanceFromData(IList<StaffAllowance> staffAllowances, bool skipDuty, bool skipRisk)
        {
            try
            {
                foreach (StaffAllowance staffAllowance in staffAllowances)
                {
                    if (staffAllowance.Employee.StaffID == staffIDtxt.Text.Trim())
                    {
                        if (staffAllowance.Type.Description.ToUpper() == "DUTY ALLOWANCE" || staffAllowance.Type.Description.ToUpper() == "RISK ALLOWANCE")
                        {
                            if (skipDuty)
                            {
                                continue;
                            }
                            else if (skipRisk)
                            {
                                continue;
                            }
                        }
                        grid.Rows.Add(1);
                        grid.Rows[ctr].Cells["gridID"].Value = staffAllowance.ID;
                        grid.Rows[ctr].Cells["gridType"].Value = staffAllowance.Type.Description;
                        grid.Rows[ctr].Cells["gridFrequency"].Value = staffAllowance.Frequency;
                        grid.Rows[ctr].Cells["gridAmount"].Value = staffAllowance.Amount;
                        grid.Rows[ctr].Cells["gridEffectiveDate"].Value = staffAllowance.EffectiveDate;
                        grid.Rows[ctr].Cells["gridIsEndDate"].Value = staffAllowance.IsEndDate;
                        grid.Rows[ctr].Cells["gridEndDate"].Value = staffAllowance.EndDate;
                        grid.Rows[ctr].Cells["gridInUse"].Value = staffAllowance.InUse;
                        grid.Rows[ctr].Cells["gridStaffID"].Value = staffAllowance.Employee.StaffID;
                        grid.Rows[ctr].Cells["gridUserID"].Value = staffAllowance.User.ID;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void GetAllowanceByEmployee(string StaffID)
        {
            try
            {
                grid.Rows.Clear();
                ctr = 0;
                Query StaffAllowance = new Query();
                StaffAllowance.Criteria.Add(new Criterion()
                {
                    Property = "StaffAllowanceView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = StaffID,
                    CriteriaOperator = CriteriaOperator.And
                });
                staffAllowances = dal.GetByCriteria<StaffAllowance>(StaffAllowance);

                StaffAllowance CurrentDutyAllowance = null;

                buildAllowanceFromData(staffAllowances, true, true);

                //foreach (StaffAllowance staffAllowance in staffAllowances)
                //{
                //    if (staffAllowance.Employee.StaffID == staffIDtxt.Text.Trim())
                //    {
                //        if (staffAllowance.Type.Description.ToUpper() == "DUTY ALLOWANCE" || staffAllowance.Type.Description.ToUpper() == "RISK ALLOWANCE")
                //        {
                //            continue;
                //        }
                //        grid.Rows.Add(1);
                //        grid.Rows[ctr].Cells["gridID"].Value = staffAllowance.ID;
                //        grid.Rows[ctr].Cells["gridType"].Value = staffAllowance.Type.Description;
                //        grid.Rows[ctr].Cells["gridFrequency"].Value = staffAllowance.Frequency;
                //        grid.Rows[ctr].Cells["gridAmount"].Value =staffAllowance.Amount;
                //        grid.Rows[ctr].Cells["gridEffectiveDate"].Value = staffAllowance.EffectiveDate;
                //        grid.Rows[ctr].Cells["gridIsEndDate"].Value = staffAllowance.IsEndDate;
                //        grid.Rows[ctr].Cells["gridEndDate"].Value = staffAllowance.EndDate;
                //        grid.Rows[ctr].Cells["gridInUse"].Value = staffAllowance.InUse;
                //        grid.Rows[ctr].Cells["gridStaffID"].Value = staffAllowance.Employee.StaffID;
                //        grid.Rows[ctr].Cells["gridUserID"].Value = staffAllowance.User.ID;
                //        ctr++;
                //    }
                //}

                

                if (staffAllowances != null && staffAllowances.Count > 0 && grid.Rows.Count > 0)
                {
                    IList<StaffAllowance> allowance = new List<StaffAllowance>();
                    CurrentDutyAllowance = staffAllowances.Where(r => r.Type.Description.ToUpper() == "DUTY ALLOWANCE").OrderByDescending(r => r.ID).FirstOrDefault();
                    allowance.Add(CurrentDutyAllowance);
                    CurrentDutyAllowance = staffAllowances.Where(r => r.Type.Description.ToUpper() == "RISK ALLOWANCE").OrderByDescending(r => r.ID).FirstOrDefault();
                    allowance.Add(CurrentDutyAllowance);
                    buildAllowanceFromData(allowance, false, false);
                    
                    //grid.Rows.Add(1);
                    //grid.Rows[ctr].Cells["gridID"].Value = CurrentDutyAllowance.ID;
                    //grid.Rows[ctr].Cells["gridType"].Value = CurrentDutyAllowance.Type.Description;
                    //grid.Rows[ctr].Cells["gridFrequency"].Value = CurrentDutyAllowance.Frequency;
                    //grid.Rows[ctr].Cells["gridAmount"].Value = CurrentDutyAllowance.Amount;
                    //grid.Rows[ctr].Cells["gridEffectiveDate"].Value = CurrentDutyAllowance.EffectiveDate;
                    //grid.Rows[ctr].Cells["gridIsEndDate"].Value = CurrentDutyAllowance.IsEndDate;
                    //grid.Rows[ctr].Cells["gridEndDate"].Value = CurrentDutyAllowance.EndDate;
                    //grid.Rows[ctr].Cells["gridInUse"].Value = CurrentDutyAllowance.InUse;
                    //grid.Rows[ctr].Cells["gridStaffID"].Value = CurrentDutyAllowance.Employee.StaffID;
                    //grid.Rows[ctr].Cells["gridUserID"].Value = CurrentDutyAllowance.User.ID;

                }

                //if (staffAllowances != null && staffAllowances.Count > 0 && grid.Rows.Count > 0)
                //{
                //    CurrentDutyAllowance = staffAllowances.Where(r => r.Type.Description.ToUpper() == "RISK ALLOWANCE").OrderByDescending(r => r.ID).FirstOrDefault();
                //    grid.Rows.Add(1);

                //    grid.Rows[ctr].Cells["gridID"].Value = CurrentDutyAllowance.ID;
                //    grid.Rows[ctr].Cells["gridType"].Value = CurrentDutyAllowance.Type.Description;
                //    grid.Rows[ctr].Cells["gridFrequency"].Value = CurrentDutyAllowance.Frequency;
                //    grid.Rows[ctr].Cells["gridAmount"].Value = CurrentDutyAllowance.Amount;
                //    grid.Rows[ctr].Cells["gridEffectiveDate"].Value = CurrentDutyAllowance.EffectiveDate;
                //    grid.Rows[ctr].Cells["gridIsEndDate"].Value = CurrentDutyAllowance.IsEndDate;
                //    grid.Rows[ctr].Cells["gridEndDate"].Value = CurrentDutyAllowance.EndDate;
                //    grid.Rows[ctr].Cells["gridInUse"].Value = CurrentDutyAllowance.InUse;
                //    grid.Rows[ctr].Cells["gridStaffID"].Value = CurrentDutyAllowance.Employee.StaffID;
                //    grid.Rows[ctr].Cells["gridUserID"].Value = CurrentDutyAllowance.User.ID;

                //}

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {           
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            StaffAllowance staffAllowance = new StaffAllowance();
                            allowanceTypes = dal.GetAll<Allowance>();
                            foreach (Allowance type in allowanceTypes)
                            {
                                if (type.Description == row.Cells["gridType"].Value.ToString())
                                {
                                    staffAllowance.Type.ID = type.ID;
                                    staffAllowance.Type.Description = type.Description;
                                }
                            }
                            staffAllowance.Frequency = row.Cells["gridFrequency"].Value.ToString();
                            staffAllowance.Amount = decimal.Parse(row.Cells["gridAmount"].Value.ToString());
                            staffAllowance.EffectiveDate = DateTime.Parse(row.Cells["gridEffectiveDate"].Value.ToString());
                            staffAllowance.EffectiveDate = DateTime.Parse(staffAllowance.EffectiveDate.Value.Year + "/" + staffAllowance.EffectiveDate.Value.Month + "/" + "1");
                            staffAllowance.EndDate = DateTime.Parse(row.Cells["gridEndDate"].Value.ToString());
                            staffAllowance.EndDate = DateTime.Parse(staffAllowance.EndDate.Value.Year + "/" + staffAllowance.EndDate.Value.Month + "/" + DateTime.DaysInMonth(staffAllowance.EndDate.Value.Year, staffAllowance.EndDate.Value.Month));
                            if (row.Cells["gridIsEndDate"].Value != null)
                            {
                                staffAllowance.IsEndDate = bool.Parse(row.Cells["gridIsEndDate"].Value.ToString());
                            }
                            else
                            {
                                staffAllowance.IsEndDate = false;
                            }
                            
                            staffAllowance.InUse = bool.Parse(row.Cells["gridInUse"].Value.ToString());
                            staffAllowance.Employee.StaffID = staffIDtxt.Text.Trim();
                            staffAllowance.Employee.ID = staffCode;

                            if (row.Cells["gridID"].Value == null)
                            {
                                staffAllowance.User.ID = GlobalData.User.ID;
                                dal.Save(staffAllowance);
                            }
                            else
                            {
                                staffAllowance.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                staffAllowance.User.ID = int.Parse(row.Cells["gridUserID"].Value.ToString());
                                dal.Update(staffAllowance);
                            }                         
                        }
                    }
                    dal.CommitTransaction();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                decimal tempDecimal = 0;
                DateTime tempDateTime;
                List<string> types = new List<string>();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        int currentRow = row.Index + 1;
                        if (row.Cells["gridType"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please select the allowance type on row " + currentRow);
                        }
                        else if (row.Cells["gridType"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please select the allowance type on row " + currentRow);
                        }
                        else
                        {
                            if (types.Contains(row.Cells["gridType"].Value.ToString()) && (row.Cells["gridInUse"].Value == null || bool.Parse(row.Cells["gridInUse"].Value.ToString()) != false))
                            {
                                result = false;
                                staffErrorProvider.SetError(groupBox2, row.Cells["gridType"].Value.ToString() + " allowance on row " + currentRow + " cannot be saved because it has already been given");
                            }
                        }
                        types.Add(row.Cells["gridType"].Value.ToString());
                        if (row.Cells["gridFrequency"].Value == null || row.Cells["gridFrequency"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please select the frequency of the allowance on row " + currentRow);
                        }
                        if (row.Cells["gridAmount"].Value == null || !decimal.TryParse(row.Cells["gridAmount"].Value.ToString(), out tempDecimal))
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter a valid decimal as the amount for the allowance on row " + currentRow);
                        }
                        if (row.Cells["gridIsEndDate"].Value != null && row.Cells["gridEndDate"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please select a valid End date for the allowance on row " + currentRow);
                        }
                        if (row.Cells["gridEffectiveDate"].Value == null || !DateTime.TryParse(row.Cells["gridEffectiveDate"].Value.ToString(), out tempDateTime))
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please select a valid Effective date for the allowance on row " + currentRow);
                        }
                        else if (row.Cells["gridEffectiveDate"].Value != null && row.Cells["gridEndDate"].Value != null && !Validator.DateRangeValidator(DateTime.Parse(row.Cells["gridEffectiveDate"].Value.ToString()), DateTime.Parse(row.Cells["gridEndDate"].Value.ToString()), DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please Effective Date cannot be greater than End Date on row " + currentRow);
                        }
                        
                        
                        if (row.Cells["gridInUse"].Value == null)
                        {
                            row.Cells["gridInUse"].Value = false;
                        }

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



        private void findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                AllowancesView viewForm = new AllowancesView(this);
                viewForm.MdiParent = this;
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                        {
                            staffAllowance.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            staffAllowance.InUse = false;
                            staffAllowance.Archived = true;
                            dal.Delete(staffAllowance);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    employee.StaffID = staffIDtxt.Text.Trim();
                    employee = dal.ShowImageByStaffID<Employee>(employee);
                    if (employee.ID != 0)
                    {
                        if (employee.Photo != null)
                        {
                            pictureBox.Image = employee.Photo;
                        }
                        else
                        {
                            MessageBox.Show("Image is not uploaded for the Staff");
                        }
                    }
                    else
                    {
                        MessageBox.Show("StaffID Not Found");
                    }

                }
                else
                {
                    MessageBox.Show("StaffID is Empty,Please Enter the StaffID");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnUseBulkEntry_Click(object sender, EventArgs e)
        {
            AllowancesBulkEntry form = new AllowancesBulkEntry();
            this.Close();
            form.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
