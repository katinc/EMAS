using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRDataAccessLayerBase;

namespace eMAS.Forms.SystemSetup
{
    public partial class SalaryPaymentAccounts : Form
    {
        DALHelper dal;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        StaffSalaryHistoryDataMapper staffSalaryHistoryMapper;
        public SalaryPaymentAccounts()
        {
            InitializeComponent();
            dal = new DALHelper();
            staffSalaryHistoryMapper = new StaffSalaryHistoryDataMapper();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SalaryPaymentAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                var lstPaymentAccounts = staffSalaryHistoryMapper.GetAllSalaryPaymentAccounts();

                int ctr = 0;
                grid.Rows.Clear();
                foreach (var paymentAccount in lstPaymentAccounts)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = paymentAccount.ID;
                    grid.Rows[ctr].Cells["gridAccountName"].Value = paymentAccount.AccountName;
                    grid.Rows[ctr].Cells["gridAccountCode"].Value = paymentAccount.AccountCode;
                    grid.Rows[ctr].Cells["gridActive"].Value = paymentAccount.Active;
                    grid.Rows[ctr].Cells["gridArchived"].Value = paymentAccount.Archived;
                    ctr++;
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            grid.ClearSelection();

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnSave.Enabled = getPermissions.CanAdd;
                btnDelete.Enabled = getPermissions.CanDelete;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dal.BeginTransaction();
            try
            {
                foreach (DataGridViewRow Row in grid.Rows)
                {
                    if (!Row.IsNewRow)
                    {
                        SalaryPaymentAccount salaryPaymentAccount = new SalaryPaymentAccount();
                        salaryPaymentAccount.ID = Convert.ToInt32(Row.Cells["gridID"].Value ?? 0);
                        salaryPaymentAccount.AccountName = Convert.ToString(Row.Cells["gridAccountName"].Value ?? string.Empty);
                        salaryPaymentAccount.AccountCode = Convert.ToString(Row.Cells["gridAccountCode"].Value ?? string.Empty);
                        salaryPaymentAccount.Active = Convert.ToBoolean(Row.Cells["gridActive"].Value ?? salaryPaymentAccount.Active);
                        salaryPaymentAccount.Archived = Convert.ToBoolean(Row.Cells["gridArchived"].Value ?? salaryPaymentAccount.Archived);

                        dal.ClearParameters();
                        dal.CreateParameter("@AccountName", salaryPaymentAccount.AccountName, DbType.String);
                        dal.CreateParameter("@AccountCode", salaryPaymentAccount.AccountCode, DbType.String);
                        dal.CreateParameter("@Active", salaryPaymentAccount.Active, DbType.Boolean);
                        dal.CreateParameter("@Archived", salaryPaymentAccount.Archived, DbType.Boolean);

                        if (salaryPaymentAccount.ID > 0)
                        {
                            dal.CreateParameter("@ID", salaryPaymentAccount.ID, DbType.Int32);
                            dal.ExecuteNonQuery("update SalaryPaymentAccounts set AccountName=@AccountName,AccountCode=@AccountCode,Active=@Active,Archived=@Archived where ID=@ID");
                        }
                        else
                            dal.ExecuteNonQuery("insert into  SalaryPaymentAccounts (AccountName,AccountCode,Active,Archived)values(@AccountName,@AccountCode,@Active,@Archived)");
                    }
                }
                dal.CommitTransaction();
                MessageBox.Show(this, "Record(s) saved successfully!");
                grid.ClearSelection();
            }
            catch (Exception xi)
            {
                dal.RollBackTransaction();
                MessageBox.Show(this, "Unable to Save Record(s)!");
                Logger.LogError(xi);
            }
           
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = grid.Rows[e.RowIndex];
                if (row.Cells["gridAccountName"].Value != null && row.Cells["gridActive"].Value == null)
                    row.Cells["gridActive"].Value = true;
                else if(row.Cells["gridAccountName"].Value == null)
                    row.Cells["gridActive"].Value = false;
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@ID", Convert.ToInt32(grid.CurrentRow.Cells["gridID"].Value), DbType.Int32);

                    dal.ExecuteNonQuery("delete SalaryPaymentAccounts where ID=@ID");

                    grid.Rows.Remove(grid.CurrentRow);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            

        }
    }
}
