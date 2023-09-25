using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Validation;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class Loans_Payments : Form
    {
        private IDAL dal;
        private StaffLoan staffLoan;
        private Company company;
        private StaffLoanPayment staffLoanPayment;
        private IList<StaffLoan> staffLoans;
        private IList<StaffLoan> staffLoanList;
        private IList<StaffLoanPayment> staffLoanPayments;
        private int loanIndex;
        private decimal amountOwing;
        private int staffLoanPaymentID;
        private int loanID;
        private int ctr;
        private bool searchGridClick;
        private bool editMode;
        private int staffCode;
        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public Loans_Payments()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffLoan = new StaffLoan();
                this.company = new Company();
                this.staffLoanPayment = new StaffLoanPayment();
                this.staffCode = 0;
                this.ctr = 0;
                this.staffLoanPaymentID = 0;
                this.loanID = 0;
                this.editMode = false;
                this.staffLoans = new List<StaffLoan>();
                this.staffLoanList = new List<StaffLoan>();
                this.staffLoanPayments=new List<StaffLoanPayment>();
                this.dal.OpenConnection();
                this.searchGridClick = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public Loans_Payments(string staffID)
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffLoan = new StaffLoan();
                this.staffLoanPayment = new StaffLoanPayment();
                this.staffCode = 0;
                this.ctr = 0;
                this.loanID = 0;
                this.editMode = false;
                this.staffLoanPaymentID = 0;
                this.staffLoans = new List<StaffLoan>();
                this.staffLoanList = new List<StaffLoan>();
                this.staffLoanPayments = new List<StaffLoanPayment>();
                this.dal.OpenConnection();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public StaffLoanPayment StaffLoanPayment
        {
            set
            {
                staffLoanPaymentID = value.ID;
                txtStaffNo.Text = value.StaffLoan.Employee.StaffID;
                staffCode = value.StaffLoan.Employee.ID;
                txtStaffName.Text = value.StaffLoan.StaffName;
                paymentDate.Value = value.PaymentDate.Value;
                amountToBePaidtxt.Text = value.StaffLoan.AmountToBePaid.ToString();
                paySNASchkbox.Checked = value.NotAffectSalary;
                editMode = true;
                label13.Text = "Edit Loan Payments";
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != value.User.ID)
                {
                    savebtn.Enabled = false;
                }
            }
        }

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                searchGridClick = true;
                loanID=int.Parse(searchGrid.CurrentRow.Cells["searchGridID"].Value.ToString());
                decimal totalPayment = 0;
                decimal previousAmount = 0;
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffLoanPaymentView.StaffLoanID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = loanID,
                    CriteriaOperator = CriteriaOperator.And
                });
                staffLoanPayments = dal.GetByCriteria<StaffLoanPayment>(query);
                if(staffLoanPayments.Count > 0)
                {
                    foreach (StaffLoanPayment payment in staffLoanPayments)
                    {
                        totalPayment = totalPayment + payment.Amount;
                    }
                    previousAmount = staffLoanPayments[0].Amount;
                }
                
                Query staffLoanQuery = new Query();
                staffLoanQuery.Criteria.Add(new Criterion()
                {
                    Property = "StaffLoanView.ID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = loanID,
                    CriteriaOperator = CriteriaOperator.And
                });
                staffLoanList = dal.GetByCriteria<StaffLoan>(staffLoanQuery);
                if (staffLoanList.Count > 0)
                {
                    foreach (StaffLoan staffLoan in staffLoanList)
                    {
                        totalAmounttxt.Text = staffLoan.MonthlyInstallment.ToString();
                        txtStaffName.Text = searchGrid.CurrentRow.Cells["searchGridName"].Value.ToString();
                        txtStaffNo.Text = searchGrid.CurrentRow.Cells["searchGridStaffNo"].Value.ToString();
                        staffCode = int.Parse(searchGrid.CurrentRow.Cells["searchGridStaffCode"].Value.ToString());
                        amountOwing = decimal.Parse(totalAmounttxt.Text) - totalPayment;
                        amountOwingtxt.Text = amountOwing.ToString();
                        monthlyInstallmenttxt.Text = staffLoan.MonthlyInstallment.ToString();
                        totalPaymenttxt.Text = totalPayment.ToString();
                        previousPaymenttxt.Text = previousAmount.ToString();
                        if (amountOwing < staffLoan.MonthlyInstallment)
                        {
                            amountToBePaidtxt.Text = amountOwing.ToString();
                        }
                        else
                        {
                            amountToBePaidtxt.Text = monthlyInstallmenttxt.Text;
                        }
                        if (staffLoan.LoanAmount - totalPayment > 0)
                        {
                            amountToBePaidtxt.ReadOnly = false;
                            paymentDate.Enabled = true;
                            savebtn.Enabled = true;
                        }
                        else
                        {
                            amountToBePaidtxt.ReadOnly = true;
                            paymentDate.Enabled = false;
                            savebtn.Enabled = false;
                        }
                    }
                }                    
                DisableBoxes(false);                
                searchGrid.Hide();
                amountToBePaidtxt.Select();
                searchGridClick = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Loans_Payments_Load(object sender, EventArgs e)
        {
            try
            {
                //GlobalData.assignControls(this);
                this.Text = GlobalData.Caption;
                DisableBoxes(true);
                grid.Hide();
                txtStaffNo.Select();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    findbtn.Enabled = getPermissions.CanView;
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

        private void closebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.Visible == true)
                {
                    grid.Visible = false;
                    findbtn.Text = "View";
                    clearbtn.Visible = true;
                    savebtn.Visible = true;
                }
                else
                {
                    dal.CloseConnection();
                    this.Close();
                }
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
                txtStaffName.Clear();
                txtStaffNo.Clear();
                amountToBePaidtxt.Clear();
                paymentDate.ResetText();
                paySNASchkbox.Checked = false;
                amountOwingtxt.Clear();
                totalAmounttxt.Clear();
                previousPaymenttxt.Clear();
                totalPaymenttxt.Clear();
                monthlyInstallmenttxt.Clear();
                amountOwing = 0;
                searchGrid.Rows.Clear();
                searchGrid.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        private void DisableBoxes(bool state)
        {
            try
            {
                amountToBePaidtxt.ReadOnly = state;
                paymentDate.Enabled = !state;
                paySNASchkbox.Enabled = !state;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CanView)
                {
                    if (findbtn.Text.Trim() == "View")
                    {
                        GetPayments();
                    }
                    else
                    {
                        if (grid.CurrentRow != null)
                        {
                            staffLoans[loanIndex].Payments[grid.CurrentRow.Index].Archived = true;
                            try
                            {
                                dal.Delete(staffLoans[loanIndex]);
                                if (staffLoans.Count <= 0)
                                {
                                    staffLoans = dal.GetAll<StaffLoan>();
                                }
                                GetPayments();
                            }
                            catch (Exception ex)
                            {
                                Logger.LogError(ex);
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

        private void GetPayments()
        {
            try
            {
                if (txtStaffName.Text != string.Empty)
                {
                    int ctr = 0;
                    grid.Rows.Clear();
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLoanPaymentView.StaffLoanID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = loanID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    staffLoanPayments = dal.GetByCriteria<StaffLoanPayment>(query);
                    foreach (StaffLoanPayment payment in staffLoanPayments)
                    {
                        grid.Rows.Add(1);
                        grid.Rows[ctr].Cells["gridID"].Value = payment.ID;
                        grid.Rows[ctr].Cells["gridAmount"].Value = payment.Amount;
                        grid.Rows[ctr].Cells["gridDate"].Value = payment.PaymentDate;
                        grid.Rows[ctr].Cells["gridStaffCode"].Value = payment.StaffLoan.Employee.ID;
                        grid.Rows[ctr].Cells["gridStaffID"].Value = payment.StaffLoan.Employee.StaffID;
                        grid.Rows[ctr].Cells["gridStaffName"].Value = payment.StaffLoan.StaffName;
                        grid.Rows[ctr].Cells["gridDateTo"].Value = payment.StaffLoan.DateTo;
                        grid.Rows[ctr].Cells["gridDateFrom"].Value = payment.StaffLoan.DateFrom;
                        grid.Rows[ctr].Cells["gridLoanAmount"].Value = payment.StaffLoan.LoanAmount;
                        grid.Rows[ctr].Cells["gridAmountToBePaid"].Value = payment.StaffLoan.AmountToBePaid;
                        grid.Rows[ctr].Cells["gridMonthlyInstallment"].Value = payment.StaffLoan.MonthlyInstallment;
                        grid.Rows[ctr].Cells["gridNotAffectSalary"].Value = payment.NotAffectSalary;
                        ctr++;
                    }
                    grid.BringToFront();
                    grid.Show();
                    clearbtn.Visible = false;
                    savebtn.Visible = false;
                    findbtn.Text = "Archive";
                }
                else
                    staffErrorProvider.SetError(txtStaffName, "Please enter a staff's name to view his payments");
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

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffName.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    ctr = 0;
                    bool found = false;
                    if(staffLoans.Count <= 0)
                    {
                        staffLoans = dal.GetAll<StaffLoan>();
                    }
                    
                    foreach (StaffLoan staffLoan in staffLoans)
                    {
                        if (staffLoan.StaffName.Trim().ToLower().StartsWith(txtStaffName.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["searchGridName"].Value = staffLoan.StaffName;
                            searchGrid.Rows[ctr].Cells["searchGridStaffNo"].Value = staffLoan.Employee.StaffID;
                            searchGrid.Rows[ctr].Cells["searchGridStaffCode"].Value = staffLoan.Employee.ID;
                            staffCode = staffLoan.Employee.ID;
                            searchGrid.Rows[ctr].Cells["searchGridDescription"].Value = staffLoan.LoanDescription;
                            searchGrid.Rows[ctr].Cells["searchGridAmount"].Value = staffLoan.MonthlyInstallment;
                            searchGrid.Rows[ctr].Cells["searchGridID"].Value = staffLoan.ID;
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
                        searchGrid.Location = new Point(120, 70);
                        searchGrid.BringToFront();
                        searchGrid.Visible = true;
                    }
                }
                else
                {
                    Clear();
                    searchGrid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtStaffNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffNo.Text.Trim() != string.Empty)
                {
                    company = dal.LazyLoad<Company>()[0];
                    if (txtStaffNo.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLoanView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffNo.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        
                        staffLoans = dal.GetByCriteria<StaffLoan>(query);
                        if (staffLoans.Count > 0)
                        {
                            foreach (StaffLoan staffLoan in staffLoans)
                            {
                                if (staffLoan.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffNo.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["searchGridName"].Value = staffLoan.StaffName;
                                    searchGrid.Rows[ctr].Cells["searchGridStaffNo"].Value = staffLoan.Employee.StaffID;
                                    searchGrid.Rows[ctr].Cells["searchGridStaffCode"].Value = staffLoan.Employee.ID;
                                    staffCode=staffLoan.Employee.ID;
                                    searchGrid.Rows[ctr].Cells["searchGridDescription"].Value = staffLoan.LoanDescription;
                                    searchGrid.Rows[ctr].Cells["searchGridAmount"].Value = staffLoan.LoanAmount;
                                    searchGrid.Rows[ctr].Cells["searchGridID"].Value = staffLoan.ID;
                                    ctr++;
                                }
                            }

                            if (found)
                            {
                                if (searchGrid.RowCount == 2)
                                {
                                    searchGrid.Height = searchGrid.RowCount * 25;
                                }
                                else
                                {
                                    searchGrid.Height = searchGrid.RowCount * 24;
                                }
                                searchGrid.Location = new Point(120, 92);
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
                            MessageBox.Show("Employee with StaffID " + txtStaffNo.Text + " is not Found");
                            txtStaffNo.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    Clear();
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void amountToBePaidtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!searchGridClick)
                {
                    if (amountToBePaidtxt.Text.Trim() != string.Empty)
                    {
                        if (Validator.DecimalValidator(amountToBePaidtxt.Text))
                        {
                            AmountErrorProvider.Clear();
                            if (amountToBePaidtxt.Text.Trim() != string.Empty)
                            {
                                amountOwingtxt.Text = (amountOwing - decimal.Parse(amountToBePaidtxt.Text)).ToString();
                            }
                        }
                        else
                        {
                            if (amountToBePaidtxt.Text.Trim() != string.Empty)
                                AmountErrorProvider.SetError(amountToBePaidtxt, "Please enter a valid decimal as the amount to be paid");
                        }
                    }
                    else
                    {
                        amountOwingtxt.Text = amountOwing.ToString();
                    }
                }
            }
            catch(Exception ex)
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
                    //Check if date for payment is valid
                    dal.BeginTransaction();                  
                    UpdateStaffLoanPaymentEntity();
                    if (editMode)
                    {
                        staffLoanPayment.ID = staffLoanPaymentID;
                        dal.Update(staffLoanPayment);
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLoanView.ID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = staffLoanPayment.StaffLoan.ID,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffLoans = dal.GetByCriteria<StaffLoan>(query);
                        if (staffLoans.Count > 0)
                        {
                            foreach (StaffLoan staffLoan in staffLoans)
                            {
                                staffLoan.ID = staffLoanPayment.StaffLoan.ID;
                                staffLoan.NotAffectSalary = staffLoanPayment.NotAffectSalary;
                                dal.Update(staffLoan);
                            }
                        }
                        Clear();
                    }
                    else
                    {
                        staffLoanPayment.User.ID = GlobalData.User.ID;
                        dal.Save(staffLoanPayment);
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLoanView.ID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = staffLoanPayment.StaffLoan.ID,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffLoans=dal.GetByCriteria<StaffLoan>(query);
                        if(staffLoans.Count > 0)
                        {
                            foreach(StaffLoan staffLoan in staffLoans)
                            {
                                staffLoan.ID = staffLoanPayment.StaffLoan.ID;
                                staffLoan.NotAffectSalary = staffLoanPayment.NotAffectSalary;
                                dal.Update(staffLoan);
                            }
                        }
                        Clear();
                    }
                    dal.CommitTransaction();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateStaffLoanPaymentEntity()
        {
            try
            {
                staffLoanPayment.StaffLoan.ID = loanID;
                staffLoanPayment.PaymentDate = DateTime.Parse(paymentDate.Text);
                staffLoanPayment.Amount = decimal.Parse(amountToBePaidtxt.Text);
                staffLoanPayment.NotAffectSalary = paySNASchkbox.Checked;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                dateErrorProvider.Clear();
                AmountErrorProvider.Clear();
                Query staffLoanQuery = new Query();
                staffLoanQuery.Criteria.Add(new Criterion()
                {
                    Property = "StaffLoanView.ID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = loanID,
                    CriteriaOperator = CriteriaOperator.And
                });
                staffLoanList = dal.GetByCriteria<StaffLoan>(staffLoanQuery);
                if (staffLoanList.Count > 0)
                {
                    foreach (StaffLoan staffLoan in staffLoanList)
                    {
                        
                        if (DateTime.Parse(paymentDate.Text).Date > staffLoan.DateTo.Value.Date)
                        {
                            if (GlobalData.QuestionMessage("The payment date is greater than the loan end date \nWould you like to continue it?") == DialogResult.No)
                            {
                                result = false;
                                MessageBox.Show("The payment date cannot be greater than the end date of the loan");
                                paymentDate.Focus();
                            }
                        }
                    }
                }
                if (!Validator.DecimalValidator(amountToBePaidtxt.Text))
                {
                    result = false;
                    AmountErrorProvider.SetError(amountToBePaidtxt, "Please enter a valid decimal as the amount to be paid");
                }
                if (DateTime.Parse(paymentDate.Text).Date > DateTime.Today.Date)
                {
                    result = false;
                    dateErrorProvider.SetError(paymentDate, "The payment date cannot be greater than today");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null && CanEdit)
                {
                    StaffLoanPayment staffLoanPayment = new StaffLoanPayment();
                    staffLoanPayment.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    staffLoanPayment.StaffLoan.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    staffLoanPayment.StaffLoan.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    staffLoanPayment.StaffLoan.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                    staffLoanPayment.Amount = decimal.Parse(grid.CurrentRow.Cells["gridAmount"].Value.ToString());
                    staffLoanPayment.StaffLoan.LoanAmount = decimal.Parse(grid.CurrentRow.Cells["gridLoanAmount"].Value.ToString());
                    staffLoanPayment.StaffLoan.AmountToBePaid = decimal.Parse(grid.CurrentRow.Cells["gridAmountToBePaid"].Value.ToString());
                    staffLoanPayment.StaffLoan.MonthlyInstallment = decimal.Parse(grid.CurrentRow.Cells["gridMonthlyInstallment"].Value.ToString());
                    staffLoanPayment.PaymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                    staffLoanPayment.NotAffectSalary = bool.Parse(grid.CurrentRow.Cells["gridNotAffectSalary"].Value.ToString());
                    staffLoanPayment.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    this.StaffLoanPayment = staffLoanPayment;
                    this.Show();
                    this.Close();
                }
                else if (!CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (MessageBox.Show("Are you sure you want to delete " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s selected loan information?", GlobalData.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                dal.BeginTransaction();
                                staffLoanPayment.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(staffLoanPayment);
                                dal.CommitTransaction();
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                dal.BeginTransaction();
                                staffLoanPayment.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(staffLoanPayment);
                                dal.CommitTransaction();
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
            }
        }

        private void archivebbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                        {
                            staffLoanPayment.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            staffLoanPayment.Archived = true;
                            dal.Delete(staffLoanPayment);
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

    }
}
