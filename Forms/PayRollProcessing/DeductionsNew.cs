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
    public partial class DeductionsNew : Form
    {
        private IList<StaffDeduction> staffDeductions;
        private StaffDeduction staffDeduction;
        private IList<Employee> employees;
        private IList<Deduction> deductionTypes;
        private IDAL dal;
        private DALHelper dalHelper;
        private Employee employee;
        private Company company;
        private int ctr;
        private int staffCode;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public DeductionsNew()
        {
            try
            {
                InitializeComponent();
                this.staffDeduction = new StaffDeduction();
                this.staffDeductions = new List<StaffDeduction>();
                this.employees = new List<Employee>();
                this.deductionTypes = new List<Deduction>();
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffCode = 0;
                this.dal = new DAL();
                this.dalHelper = new DALHelper();
                if (this.employees.Count <= 0)
                {
                    this.employees = dal.LazyLoad<Employee>();
                }             
                this.deductionTypes = dal.GetAll<Deduction>();
                this.staffDeductions = dal.GetAll<StaffDeduction>();
                this.GetDataDeductions();
                this.GetFrequencies();              
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public DeductionsNew(string staffID)
        {
            try
            {
                InitializeComponent();
                this.staffDeduction = new StaffDeduction();
                this.staffDeductions = new List<StaffDeduction>();
                this.employees = new List<Employee>();
                this.deductionTypes = new List<Deduction>();
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffCode = 0;
                this.dal = new DAL();             
                this.deductionTypes = dal.GetAll<Deduction>();
                this.staffDeductions = dal.GetAll<StaffDeduction>();
                this.employee = dal.LazyLoadByStaffID<Employee>(staffID);
                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                nametxt.Text = name;
                staffIDtxt.Text = employee.StaffID;
                gendertxt.Text = employee.Gender;
                pictureBox.Image = employee.Photo;
                agetxt.Text = employee.Age;
                searchGrid.Visible = false;
                groupBox2.Enabled = true;
                GetDeductions();
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

        public void GetDataDeductions()
        {
            try
            {
                gridType.Items.Clear();
                this.deductionTypes = dal.GetAll<Deduction>();
                foreach (Deduction deduction in deductionTypes)
                {
                    if (deduction.Inactive)
                    {
                        gridType.Items.Add(deduction.Description);
                    }
                }
                dal.CloseConnection();
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
                    if (grid.CurrentCell.ColumnIndex == 3)
                    {
                        this.GetDataDeductions();
                    }

                    if (grid.CurrentCell.ColumnIndex == 4)
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
            catch (Exception ex)
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
                    if (grid.CurrentCell.ColumnIndex == 3)
                    {
                        // do stuff
                        decimal basicSalary = decimal.Parse(dalHelper.ExecuteScalar("select MonthlyBasicSalary From StaffSalaryHistory Where StaffID = '" + staffIDtxt.Text.Trim() + "'").ToString());
                        decimal grossSalary = 0;
                        decimal totalAllowances = 0;
                        foreach (DataRow row in dalHelper.ExecuteReader("Select Amount From StaffAllowances Where StaffID='" + staffIDtxt.Text.Trim() + "'").Rows)
                        {
                            totalAllowances += decimal.Parse(row["Amount"].ToString());
                        }
                        grossSalary = basicSalary + totalAllowances;

                        if (grid.CurrentRow != null)
                        {
                            foreach (Deduction deduction in deductionTypes)
                            {
                                if (deduction.Description == grid.CurrentRow.Cells["gridType"].Value.ToString())
                                {
                                    if (deduction.RateBased == true)
                                    {
                                        if (deduction.CalculatedOn.Description == "Basic")
                                        {
                                            grid.CurrentRow.Cells["gridAmount"].Value = decimal.Round((deduction.Rate / 100) * basicSalary, 2);
                                        }
                                        else
                                        {
                                            grid.CurrentRow.Cells["gridAmount"].Value = decimal.Round((deduction.Rate / 100) * grossSalary, 2);
                                        }
                                    }
                                    else
                                    {
                                        grid.CurrentRow.Cells["gridAmount"].Value = decimal.Round(deduction.Amount, 2);
                                    }
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
                string err = ex.Message;
            }
        }

        private void GetDeductions()
        {
            try
            {
                //Get Deductions
                grid.Rows.Clear();
                ctr = 0;
                foreach (StaffDeduction staffDeduction in staffDeductions)
                {
                    if (staffDeduction.Employee.StaffID == staffIDtxt.Text.Trim())
                    {
                        grid.Rows.Add(1);
                        grid.Rows[ctr].Cells["gridID"].Value = staffDeduction.ID;
                        grid.Rows[ctr].Cells["gridType"].Value = staffDeduction.Type.Description;
                        grid.Rows[ctr].Cells["gridFrequency"].Value = staffDeduction.Frequency;
                        grid.Rows[ctr].Cells["gridAmount"].Value = staffDeduction.Amount;
                        grid.Rows[ctr].Cells["gridEffectiveDate"].Value = staffDeduction.EffectiveDate;
                        grid.Rows[ctr].Cells["gridIsEndDate"].Value = staffDeduction.IsEndDate;
                        grid.Rows[ctr].Cells["gridEndDate"].Value = staffDeduction.EndDate;
                        grid.Rows[ctr].Cells["gridInUse"].Value = staffDeduction.InUse;
                        grid.Rows[ctr].Cells["gridStaffID"].Value = staffDeduction.Employee.StaffID;
                        grid.Rows[ctr].Cells["gridUserID"].Value = staffDeduction.User.ID;
                        ctr++;
                    }
                }
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void DeductionsNew_Load(object sender, EventArgs e)
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
                    findbtn.Enabled = getPermissions.CanView;
                    btnDelete.Enabled = getPermissions.CanDelete;
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

        private void GetDeductionsByEmployee(string StaffID)
        {
            try
            {
                //Get Deductions By Employee
                grid.Rows.Clear();
                ctr = 0;
                Query StaffDeductionQuery = new Query();
                StaffDeductionQuery.Criteria.Add(new Criterion()
                {
                    Property = "StaffDeductionView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = StaffID,
                    CriteriaOperator = CriteriaOperator.And
                });
                staffDeductions = dal.GetByCriteria<StaffDeduction>(StaffDeductionQuery);
                foreach (StaffDeduction staffDeduction in staffDeductions)
                {
                    if (staffDeduction.Employee.StaffID == staffIDtxt.Text.Trim())
                    {
                        grid.Rows.Add(1);
                        //string id = staffDeduction.ID.ToString();
                        grid.Rows[ctr].Cells["gridID"].Value = staffDeduction.ID;
                        grid.Rows[ctr].Cells["gridType"].Value = staffDeduction.Type.Description;
                        grid.Rows[ctr].Cells["gridFrequency"].Value = staffDeduction.Frequency;
                        grid.Rows[ctr].Cells["gridAmount"].Value = staffDeduction.Amount;
                        grid.Rows[ctr].Cells["gridEffectiveDate"].Value = staffDeduction.EffectiveDate;
                        grid.Rows[ctr].Cells["gridIsEndDate"].Value = staffDeduction.IsEndDate;
                        grid.Rows[ctr].Cells["gridEndDate"].Value = staffDeduction.EndDate;
                        grid.Rows[ctr].Cells["gridInUse"].Value = staffDeduction.InUse;
                        grid.Rows[ctr].Cells["gridStaffID"].Value = staffDeduction.Employee.StaffID;
                        grid.Rows[ctr].Cells["gridUserID"].Value = staffDeduction.User.ID;
                        ctr++;
                    }
                }
                dal.CloseConnection();
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
                    //Query query = new Query();
                    //query.Criteria.Add(new Criterion()
                    //{
                    //    Property = "StaffID",
                    //    CriterionOperator = CriterionOperator.EqualTo,
                    //    Value = searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim(),
                    //    CriteriaOperator = CriteriaOperator.And
                    //});
                    //query.Criteria.Add(new Criterion()
                    //{
                    //    Property = "StaffPersonalInfoView.Terminated",
                    //    CriterionOperator = CriterionOperator.EqualTo,
                    //    Value = false,
                    //    CriteriaOperator = CriteriaOperator.And
                    //});
                    //query.Criteria.Add(new Criterion()
                    //{
                    //    Property = "StaffPersonalInfoView.TransferredOut",
                    //    CriterionOperator = CriterionOperator.EqualTo,
                    //    Value = false,
                    //    CriteriaOperator = CriteriaOperator.And
                    //});
                    //employees = dal.GetByCriteria<Employee>(query);
                    if (this.employees.Count <= 0)
                    {
                        this.employees = dal.LazyLoad<Employee>();
                    }      
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
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox2.Enabled = true;

                            //Get Deductions By Employee
                            GetDeductionsByEmployee(staffIDtxt.Text);
                        }
                    }
                }
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
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
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                    company = dal.LazyLoad<Company>()[0];
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

        private void savebtn_Click(object sender, EventArgs e)
        {          
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            StaffDeduction staffDeduction = new StaffDeduction();
                            deductionTypes = dal.GetAll<Deduction>();
                            foreach (Deduction type in deductionTypes)
                            {
                                if (type.Description == row.Cells["gridType"].Value.ToString())
                                {
                                    staffDeduction.Type.ID = type.ID;
                                    staffDeduction.Type.Description = type.Description;
                                    break;
                                }
                            }

                            staffDeduction.Frequency = row.Cells["gridFrequency"].Value.ToString();
                            if (row.Cells["gridRate"].Value == null)
                            {
                                staffDeduction.Amount = decimal.Parse(row.Cells["gridAmount"].Value.ToString());
                            }
                            else
                            {
                                staffDeduction.Amount = decimal.Parse(row.Cells["gridAmount"].Value.ToString().Replace("% of "+ row.Cells["gridRate"].Value.ToString() +" Salary","").Trim());
                            }
                            staffDeduction.EffectiveDate = DateTime.Parse(row.Cells["gridEffectiveDate"].Value.ToString());
                            staffDeduction.EffectiveDate = DateTime.Parse(staffDeduction.EffectiveDate.Value.Year + "/" + staffDeduction.EffectiveDate.Value.Month + "/" + "1");

                            staffDeduction.EndDate = DateTime.Parse(row.Cells["gridEndDate"].Value.ToString());
                            staffDeduction.EndDate = DateTime.Parse(staffDeduction.EndDate.Value.Year + "/" + staffDeduction.EndDate.Value.Month + "/" + DateTime.DaysInMonth(staffDeduction.EndDate.Value.Year, staffDeduction.EndDate.Value.Month));
                            if (row.Cells["gridIsEndDate"].Value != null)
                            {
                                staffDeduction.IsEndDate = bool.Parse(row.Cells["gridIsEndDate"].Value.ToString());
                            }
                            else
                            {
                                staffDeduction.IsEndDate = false;
                            }
                            
                            staffDeduction.InUse = bool.Parse(row.Cells["gridInUse"].Value.ToString());
                            staffDeduction.Employee.StaffID = staffIDtxt.Text.Trim();
                            staffDeduction.Employee.ID = staffCode;
                            
                            if (row.Cells["gridID"].Value == null)
                            {
                                staffDeduction.User.ID = GlobalData.User.ID;
                                dal.Save(staffDeduction);
                            }
                            else
                            {
                                staffDeduction.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                staffDeduction.User.ID = int.Parse(row.Cells["gridUserID"].Value.ToString());
                                dal.Update(staffDeduction);
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
                        if (row.Cells["gridType"].Value == null || row.Cells["gridType"].Value.ToString() == string.Empty)
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
                        if (row.Cells["gridRate"].Value == null)
                        {
                            if (row.Cells["gridAmount"].Value == null || !decimal.TryParse(row.Cells["gridAmount"].Value.ToString(), out tempDecimal))
                            {
                                result = false;
                                staffErrorProvider.SetError(groupBox2, "Please enter a valid decimal as the amount for the allowance on row " + currentRow);
                            }
                        }
                        else
                        {
                            if (!decimal.TryParse(row.Cells["gridAmount"].Value.ToString().Replace("% of " + row.Cells["gridRate"].Value.ToString() + " Salary", "").Trim(), out tempDecimal))
                            {
                                result = false;
                                staffErrorProvider.SetError(groupBox2, "Please select the deduction type on row " + currentRow + " again and change only the decimal value");
                            }
                        }
                        if (row.Cells["gridIsEndDate"].Value != null && row.Cells["gridEndDate"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please select a valid End date for the allowance on row " + currentRow);
                        }
                        if (row.Cells["gridEffectiveDate"].Value == null || !DateTime.TryParse(row.Cells["gridEffectiveDate"].Value.ToString(), out tempDateTime))
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please select a valid effective date for the allowance on row " + currentRow);
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
                DeductionsView viewForm = new DeductionsView(this);
                viewForm.removeButton.Visible = CanDelete;
                viewForm.Show();
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
                            staffDeduction.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            staffDeduction.InUse = false;
                            staffDeduction.Archived = true;
                            dal.Delete(staffDeduction);
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
            GlobalData.ItemControl = this.Name;
            DeductionsBulkEntry form = new DeductionsBulkEntry();
            this.Close();
            form.Show();
        }
    }
}
