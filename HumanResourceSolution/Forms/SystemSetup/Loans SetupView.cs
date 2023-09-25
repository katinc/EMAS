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
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class LoansSetupView : Form, IRefreshView 
    {
        private IDAL dal;
        private IList<Loan> loans;
        private Loan loan;
        private bool found;

        public LoansSetupView(IDAL dal)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.loan=new Loan();
                this.loans=new List<Loan>();
                this.RefreshView();
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public LoansSetupView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.loan = new Loan();
                this.loans = new List<Loan>();
                this.RefreshView();
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {                   
                    loan.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    loan.Description = grid.CurrentRow.Cells["gridDescription"].Value.ToString();
                    loan.Inactive = bool.Parse(grid.CurrentRow.Cells["gridInActive"].Value.ToString());
                    loan.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    LoansSetupEdit loanEdit = new LoansSetupEdit(dal, loan, this);
                    loanEdit.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void RefreshView()
        {
            try
            {
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "Loan_SetupView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                loans = dal.GetByCriteria<Loan>(query);
                PopulateView(loans);
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<Loan> loans)
        {
            try
            {
                int ctr = 0;
                grid.Rows.Clear();
                foreach (Loan loan in loans)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = loan.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = loan.Description;
                    grid.Rows[ctr].Cells["gridInActive"].Value = loan.Inactive;
                    grid.Rows[ctr].Cells["gridUserID"].Value = loan.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void LoansSetupView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete the ff. loan setup:\n" + grid.CurrentRow.Cells["gridDescription"].Value.ToString(), GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {                            
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                loan.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(loan);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                loan.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(loan);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Can not delete,Please See the System Administrator");
            }
        }
    }
}
