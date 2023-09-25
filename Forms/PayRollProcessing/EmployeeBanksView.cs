using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class EmployeeBanksView : Form
    {
        private DALHelper dalHelper;
        private IDAL dal;
        private Employee_Banks newForm;
        private int ctr;

        public EmployeeBanksView()
        {
            try
            {
                InitializeComponent();
                this.newForm = new Employee_Banks();
                this.dalHelper = new DALHelper();
                this.dal = new DAL();
                this.ctr = 0;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public EmployeeBanksView(Employee_Banks newForm)
        {
            try
            {
                InitializeComponent();
                this.newForm = newForm;
                this.dalHelper = new DALHelper();
                this.dal = new DAL();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeBanksView_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete " + grid.CurrentRow.Cells["AccountName"].Value.ToString() + "'s selected banking information?", GlobalData.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            dalHelper.ExecuteNonQuery("Delete from StaffBanks Where ID =" + grid.CurrentRow.Cells["ID"].Value.ToString());
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            dalHelper.ExecuteNonQuery("Delete from StaffBanks Where ID =" + grid.CurrentRow.Cells["ID"].Value.ToString());
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                    }
                    catch (Exception ex)
                    {
                        string err = ex.Message;
                    }
                }
            }
        }

        private void cboAccountType_DropDown(object sender, EventArgs e)
        {
            cboAccountType.Items.Clear();

            try
            {
                var accountTypes = GlobalData._context.AccountTypes.ToList();

                foreach (var accountType in accountTypes)
                {
                    cboAccountType.Items.Add(accountType.Description);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void cboBank_DropDown(object sender, EventArgs e)
        {

            cboBank.Items.Clear();

            try
            {
                var banks = GlobalData._context.Banks.OrderBy(u => u.Description).ToList();

                foreach (var bank in banks)
                {
                    cboBank.Items.Add(bank.Description);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {

            //cboUnit.Items.Clear();
            //cboDepartment.Items.Clear();

            //try
            //{
            //    var departments = GlobalData._context.DDepartments.OrderBy(u => u.Description).ToList();

            //    foreach (var department in departments)
            //    {
            //        cboDepartment.Items.Add(department.Description);
            //    }
            //}
            //catch (Exception ex)
            //{
                
            //    throw ex;
            //}
            
        }

        private void cboUnit_DropDown(object sender, EventArgs e)
        {
            
        }

        private void cboDepartment_DropDownClosed(object sender, EventArgs e)
        {
            //cboUnit.Items.Clear();

            //try
            //{
            //    if (cboDepartment.Text.Trim() != string.Empty)
            //{
            //    var units = GlobalData._context.UnitViews.Where(u => u.Department == cboDepartment.Text).OrderBy(u => u.Description).ToList();

            //    foreach (var unit in units)
            //    {
            //        cboUnit.Items.Add(unit.Description);
            //    }
            //}
            //}
            //catch (Exception ex)
            //{
                
            //    throw ex;
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                getData();   
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void getData() 
        {

            try
            {
                var employeeBanks = GlobalData._context.StaffBankViews.Where(u =>
                    (u.AccountType.Contains(cboAccountType.Text) || u.AccountType == null) &&
                    (u.Bank.Contains(cboBank.Text) || u.Bank == null) &&
                    (u.StaffID.Contains(staffIDtxt.Text) || u.StaffID == null) &&
                    (u.AccountName.Contains(txtName.Text.Trim()) || u.AccountName == null)
                    ).ToList();

                PopulateView(employeeBanks);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void PopulateView(List<DataReference.StaffBankView> banks) 
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (var employeeBank in banks)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["ID"].Value = employeeBank.ID;
                    grid.Rows[ctr].Cells["StaffID"].Value = employeeBank.StaffID;
                    grid.Rows[ctr].Cells["AccountName"].Value = employeeBank.AccountName;
                    grid.Rows[ctr].Cells["AccountNumber"].Value = employeeBank.AccountNumber;
                    grid.Rows[ctr].Cells["BankName"].Value = employeeBank.Bank;
                    grid.Rows[ctr].Cells["BankBranch"].Value = employeeBank.BankBranch;
                    grid.Rows[ctr].Cells["AccountType"].Value = employeeBank.AccountType;
                    grid.Rows[ctr].Cells["BankAddress"].Value = employeeBank.Address;
                    ctr++;
                }

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cboAccountType.Items.Clear();
                cboBank.Items.Clear();
                staffIDtxt.Clear();
                txtName.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
