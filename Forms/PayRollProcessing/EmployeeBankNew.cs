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
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class Employee_Banks : Form
    {
        private StaffBank staffBank;
        private IList<StaffBank> staffBanks;
        private IList<Employee> employees;
        private IList<Bank> banks;
        private IList<BankBranch> bankBranches;
        private IList<AccountType> accountTypes;
        private IDAL dal;
        private Employee employee;
        private Company company;
        private int ctr;
        private bool editMode;
        private int staffCode;
        private int bankID;
        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        private int rowIndex;

        private DataGridViewComboBoxCell cmbCell;

        public Employee_Banks()
        {
            try
            {
                InitializeComponent();
                this.staffBank = new StaffBank();
                this.employees = new List<Employee>();
                this.staffBanks = new List<StaffBank>();
                this.banks = new List<Bank>();
                this.bankBranches = new List<BankBranch>();
                this.accountTypes = new List<AccountType>();
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.dal = new DAL();
                this.editMode = false;
                this.staffCode = 0;
                this.bankID = 0;  
                this.GetBankList();
                //this.GetBankBranchList();
                this.GetAccountTypeList();

                this.cmbCell = new DataGridViewComboBoxCell();
                this.rowIndex = 0;

            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void GetAccountTypeList()
        {
            try
            {
                gridAccountType.Items.Clear();
                accountTypes = dal.GetAll<AccountType>();
                foreach (AccountType accountType in accountTypes)
                {
                    if (accountType.Active)
                    {
                        gridAccountType.Items.Add(accountType.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void GetBankBranchList(int index)
        {
            try
            {
                gridBranch.Items.Clear();
                Query bankBranchQuery = new Query();
                bankBranchQuery.Criteria.Add(new Criterion()
                {
                    Property = "BankID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = bankID,
                    CriteriaOperator = CriteriaOperator.And
                });
                bankBranches = dal.GetByCriteria<BankBranch>(bankBranchQuery);

                cmbCell = (DataGridViewComboBoxCell)grid.Rows[index].Cells[4];
                cmbCell.Items.Clear();

                foreach (BankBranch branch in bankBranches)
                {
                    cmbCell.Items.Add(branch.Description);
                }

                //if (grid.IsCurrentRowDirty)
                //{
                //    //DataGridViewComboBoxCell cmbCell;
                //    cmbCell = (DataGridViewComboBoxCell)grid.Rows[index].Cells[4];
                //    cmbCell.Items.Clear();

                //    foreach (BankBranch branch in bankBranches)
                //    {
                //        cmbCell.Items.Add(branch.Description);
                //    }
                //}
                //else
                //{
                //    foreach (BankBranch bankBranch in bankBranches)
                //    {
                //        if (bankBranch.Active)
                //        {
                //            gridBranch.Items.Add(bankBranch.Description);

                //        }
                //    }
                //}
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        public void GetBankList()
        {
            try
            {
                gridBank.Items.Clear();
                this.banks = dal.GetAll<Bank>();
                foreach (Bank bank in banks)
                {
                    if (bank.Active)
                    {
                        gridBank.Items.Add(bank.Description);
                    }                   
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void Employee_Banks_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                groupBox2.Enabled = false;
                staffIDtxt.Select();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    findbtn.Enabled = getPermissions.CanView;
                    btnDelete.Enabled = getPermissions.CanDelete;
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
                string str = ex.Message;
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
                string str = ex.Message;
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
                    if (grid.CurrentCell.ColumnIndex == 3)
                    {
                        if (grid.CurrentRow != null)
                        {
                            foreach (Bank bank in banks)
                            {
                                if (bank.Description.Trim() == grid.Rows[rowIndex].Cells["gridBank"].Value.ToString().Trim())
                                {
                                    bankID = bank.ID;
                                    GetBankBranchList(rowIndex);
                                }
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
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
                            pictureBox.Image = employee.Photo;
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox2.Enabled = true;
                            GetBanks();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetBanks()
        {
            try
            {
                int ctr = 0;
                rowIndex = 0;
                grid.Rows.Clear();
                Query staffBankQuery = new Query();
                staffBankQuery.Criteria.Add(new Criterion()
                {
                    Property = "StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffIDtxt.Text,
                    CriteriaOperator = CriteriaOperator.And
                });
                staffBanks = dal.GetByCriteria<StaffBank>(staffBankQuery);
                foreach (StaffBank staffBank in staffBanks)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffBank.ID;
                    grid.Rows[ctr].Cells["gridBank"].Value = staffBank.Bank.Description;
                    grid.Rows[ctr].Cells["gridBranch"].Value = staffBank.BankBranch.Description;
                    grid.Rows[ctr].Cells["gridAccountType"].Value = staffBank.AccountType.Description;
                    grid.Rows[ctr].Cells["gridAccountName"].Value = staffBank.AccountName;
                    grid.Rows[ctr].Cells["gridAccountNumber"].Value = staffBank.AccountNumber;
                    grid.Rows[ctr].Cells["gridAddress"].Value = staffBank.Address;
                    grid.Rows[ctr].Cells["gridInUse"].Value = staffBank.In_Use;
                    grid.Rows[ctr].Cells["gridUserID"].Value = staffBank.User.ID;
                    ctr++;
                    rowIndex = ctr;
                }
                
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
                staffIDtxt.Clear();
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                pictureBox.Image = pictureBox.InitialImage;
                groupBox2.Enabled = false;
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
                            searchGrid.Rows[ctr].Cells["gridStaffCod"].Value = employee.ID;

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
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 22);
                        searchGrid.BringToFront();
                        searchGrid.Visible = true;
                    }
                    else
                    {
                        searchGrid.Visible = false;
                        Clear();
                    }
                }
                else
                {
                    searchGrid.Visible = false;
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
                                    searchGrid.Rows[ctr].Cells["gridStaffCod"].Value = employee.ID;
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
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            banks = dal.GetAll<Bank>();
                            foreach (Bank bank in banks)
                            {
                                if (bank.Description == row.Cells["gridBank"].Value.ToString())
                                {
                                    staffBank.Bank.ID = bank.ID;
                                    staffBank.Bank.Description = bank.Description;
                                }
                            }

                            Query query = new Query();
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "BankBranchView.BankID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = staffBank.Bank.ID,
                                CriteriaOperator = CriteriaOperator.And
                            });

                            bankBranches = dal.GetByCriteria<BankBranch>(query);
                            foreach (BankBranch bankBranch in bankBranches)
                            {
                                
                                //if (bankBranch.Description == row.Cells["gridBranch"].Value.ToString())
                                //{
                                //    staffBank.BankBranch.ID = bankBranch.ID;
                                //    staffBank.BankBranch.Description = bankBranch.Description;
                                //}

                                if (bankBranch.Description == row.Cells[4].Value.ToString())
                                {
                                    staffBank.BankBranch.ID = bankBranch.ID;
                                    staffBank.BankBranch.Description = bankBranch.Description;
                                }


                            }
                            accountTypes = dal.GetAll<AccountType>();
                            foreach (AccountType accountType in accountTypes)
                            {
                                if (accountType.Description == row.Cells["gridAccountType"].Value.ToString())
                                {
                                    staffBank.AccountType.ID = accountType.ID;
                                    staffBank.AccountType.Description = accountType.Description;
                                }
                            }
                            staffBank.AccountName = row.Cells["gridAccountName"].Value.ToString();
                            staffBank.AccountNumber = row.Cells["gridAccountNumber"].Value.ToString();
                            if (row.Cells["gridAddress"].Value != null)
                            {
                                staffBank.Address = row.Cells["gridAddress"].Value.ToString();
                            }
                            
                            staffBank.In_Use = bool.Parse(row.Cells["gridInUse"].Value.ToString());
                            staffBank.Employee.StaffID = staffIDtxt.Text.Trim();
                            staffBank.Employee.ID = staffCode;

                            if (row.Cells["gridID"].Value == null)
                            {
                                staffBank.User.ID = GlobalData.User.ID;
                                dal.Save(staffBank);
                            }
                            else
                            {
                                staffBank.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                staffBank.User.ID = int.Parse(row.Cells["gridUserID"].Value.ToString());
                                dal.Update(staffBank);
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
                int ctr = 0;
                staffErrorProvider.Clear();

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridBank"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the bank on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridBank"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the bank on row " + (row.Index + 1));
                        }
                        if (row.Cells["gridBranch"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the branch on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridBranch"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the branch on row " + (row.Index + 1));
                        }
                        if (row.Cells["gridAccountType"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the Account Type on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridAccountType"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the Account Type on row " + (row.Index + 1));
                        }
                        if (row.Cells["gridAccountName"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the account name on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridAccountName"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the account name on row " + (row.Index + 1));
                        }
                        if (row.Cells["gridAccountNumber"].Value == null)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the account number on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridAccountNumber"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            staffErrorProvider.SetError(groupBox2, "Please enter the account number on row " + (row.Index + 1));
                        }
                                              
                        if (row.Cells["gridInUse"].Value == null)
                        {
                            row.Cells["gridInUse"].Value = false;
                        }
                        else
                        {
                            if (bool.Parse(row.Cells["gridInUse"].Value.ToString()))
                            {
                                ctr++;
                            }
                        }
                    }
                }
                if (ctr > 1)
                {
                    result = false;
                    staffErrorProvider.SetError(groupBox2, "Only one bank can be in use at a time");
                }
                if (ctr == 0)
                {
                    result = false;
                    staffErrorProvider.SetError(groupBox2, "At least one bank must be selected as in use");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }

        private void findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeBanksView viewForm = new EmployeeBanksView(this);
                viewForm.removeButton.Enabled = CanDelete;
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
                            staffBank.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            staffBank.In_Use = false;
                            staffBank.Archived = true;
                            dal.Delete(staffBank);
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

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (grid.CurrentCell != null)
                //{
                //    if (grid.CurrentCell.ColumnIndex == 3)
                //    {
                //        if (grid.CurrentRow != null)
                //        {
                //            foreach (Bank bank in banks)
                //            {
                //                if (bank.Description.Trim() == grid.CurrentRow.Cells["gridBank"].Value.ToString().Trim())
                //                {
                //                    bankID = bank.ID;
                //                    GetBankBranchList(grid.CurrentRow.Index);
                //                }
                //            }

                //        }
                //    }
                //}

                //if (grid.CurrentCell.ColumnIndex == 3)
                //{
                //    MessageBox.Show("Row id" + grid.CurrentCell.RowIndex.ToString());
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
