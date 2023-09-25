using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class TaxableIncomeView : Form, IRefreshView
    {
        TaxableIncomeDataMapper taxableIncomeDal;
        IDAL dal;
        private bool found;

        public TaxableIncomeView(TaxableIncomeDataMapper taxableIncomeDal)
        {
            InitializeComponent();
            this.taxableIncomeDal = taxableIncomeDal;
            this.dal = new DAL();
            this.found = false;
            RefreshView();
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        public TaxableIncomeView()
        {
            InitializeComponent();
            this.taxableIncomeDal = new TaxableIncomeDataMapper();
            this.dal = new DAL();
            this.found = false;
            RefreshView();
            grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                TaxableIncome taxableIncome = new TaxableIncome();
                taxableIncome.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                taxableIncome.AnnualTaxableIncome = decimal.Parse(grid.CurrentRow.Cells["gridAnnualTax"].Value.ToString());
                taxableIncome.Description = grid.CurrentRow.Cells["gridDescription"].Value.ToString();
                taxableIncome.TaxRate = decimal.Parse(grid.CurrentRow.Cells["gridTaxRate"].Value.ToString());
                taxableIncome.Year  = int.Parse(grid.CurrentRow.Cells["gridYear"].Value.ToString());
                taxableIncome.Active = bool.Parse(grid.CurrentRow.Cells["gridActive"].Value.ToString());
                taxableIncome.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                Taxable_IncomeEdit taxableEdit = new Taxable_IncomeEdit(taxableIncome,taxableIncomeDal,this);
                taxableEdit.Show();
            }
        }

        public void RefreshView()
        {
            
            try
            {
                IList<TaxableIncome> taxableIncomes = new List<TaxableIncome>();
                Query query=new Query();
                /*if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {*/
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TaxableIncome_Setup.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                /*}*/
                taxableIncomes = dal.GetByCriteria<TaxableIncome>(query);
                PopulateView(taxableIncomes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }

        private void PopulateView(IList<TaxableIncome> taxableIncomes)
        {
            try
            {
                grid.Rows.Clear();
                int ctr = 0;
                foreach (TaxableIncome income in taxableIncomes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = income.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = income.Description;
                    grid.Rows[ctr].Cells["gridAnnualTax"].Value = income.AnnualTaxableIncome;
                    grid.Rows[ctr].Cells["gridTaxRate"].Value = income.TaxRate;
                    grid.Rows[ctr].Cells["gridYear"].Value = income.Year;
                    grid.Rows[ctr].Cells["gridActive"].Value = income.Active;
                    grid.Rows[ctr].Cells["gridUserID"].Value = income.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete the income tax for the year " + grid.CurrentRow.Cells["gridYear"].Value.ToString(), GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            taxableIncomeDal.Delete(grid.CurrentRow.Cells["gridID"].Value);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            taxableIncomeDal.Delete(grid.CurrentRow.Cells["gridID"].Value);
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

        private void TaxableIncomeView_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}
