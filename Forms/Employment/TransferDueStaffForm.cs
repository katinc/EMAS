using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using eMAS.All_UIs.Applicants;
using eMAS.All_UIs.Staff_Information_FORMS;
using eMAS.Forms.Employment;

namespace eMAS.Forms.Employment
{
    public partial class TransferDueStaffForm : Form
    {
        private IDAL dal;
        private IList<Employee> employees;
        private Employee employee;
        private Transfer transfer;
        private IList<Transfer> transfers;
        private IList<Transfer> foundTransfers;
        private int ctr;
        private bool found;

        public TransferDueStaffForm()
        {
            try
            {
                InitializeComponent();
                this.transfer = new Transfer();
                this.transfers = new List<Transfer>();
                this.foundTransfers = new List<Transfer>();
                this.employees = new List<Employee>();
                this.employee = new Employee();
                this.dal = new DAL();
                this.ctr = 0;
                this.found = false;
                this.dal.OpenConnection();
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are you sure you want to delete the Staff " + "?") == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                transfer.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                transfer.Archived = true;
                                dal.Delete(transfer);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                transfer.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                transfer.Archived = true;
                                dal.Delete(transfer);
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
            }
        }

        private void TransferDueStaffForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<Transfer> transfers)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Transfer transfer in transfers)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = transfer.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = transfer.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = transfer.Employee.Title.Description + " " + transfer.Employee.Surname + " " + transfer.Employee.FirstName + " " + transfer.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = transfer.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = transfer.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridZone"].Value = transfer.Employee.Zone.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = transfer.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = transfer.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = transfer.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridType"].Value = transfer.Type;
                    if (transfer.Type.Trim() == "Internal Transfer")
                    {
                        grid.Rows[ctr].Cells["gridNewUnit"].Value = transfer.Unit.Description;
                        grid.Rows[ctr].Cells["gridNewDepartment"].Value = transfer.Department.Description;
                        grid.Rows[ctr].Cells["gridNewZone"].Value = transfer.Zone.Description;
                        grid.Rows[ctr].Cells["gridPreviousInstitution"].Value = "NA";
                        grid.Rows[ctr].Cells["gridPreviousStaffID"].Value = transfer.PreviousStaffID;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridPreviousInstitution"].Value = transfer.PreviousInstitution;
                        grid.Rows[ctr].Cells["gridPreviousStaffID"].Value = transfer.PreviousStaffID;
                        grid.Rows[ctr].Cells["gridNewUnit"].Value = "NA";
                        grid.Rows[ctr].Cells["gridNewDepartment"].Value = "NA";
                        grid.Rows[ctr].Cells["gridNewZone"].Value = "NA";
                    }
                    grid.Rows[ctr].Cells["gridTransferDate"].Value = transfer.Date;
                    grid.Rows[ctr].Cells["gridReason"].Value = transfer.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = employee.User.ID;
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(grid.Rows[ctr].Cells["gridUserID"].Value.ToString()))
                    {
                        grid.Rows[ctr].Cells["gridSelect"].ReadOnly = true;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridSelect"].ReadOnly = false;
                    }
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetData()
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
                        Property = "TransferView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (datePickerTransferDate.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TransferView.Date",
                        CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                        Value = datePickerTransferDate.Value.Date.ToString("yyyy-MM-dd"),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "TransferView.Transferred",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                transfers = dal.GetByCriteria<Transfer>(query);
                PopulateView(transfers);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();              
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
                transfer = new Transfer();
                grid.Rows.Clear();
                txtStaffID.Clear();
                txtSurname.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundTransfers.Clear();
                dal.OpenConnection();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "TransferView.Date",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = datePickerTransferDate.Value.Date.ToString("yyyy-MM-dd"),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "TransferView.Transferred",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                transfers = dal.GetByCriteria<Transfer>(query);
                foreach (Transfer transfer in transfers)
                {
                    if (transfer.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                    {
                        foundTransfers.Add(transfer);
                    }
                }
                PopulateView(foundTransfers);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundTransfers.Clear();
                dal.OpenConnection();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "TransferView.Date",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = datePickerTransferDate.Value.Date.ToString("yyyy-MM-dd"),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "TransferView.Transferred",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                transfers = dal.GetByCriteria<Transfer>(query);
                foreach (Transfer transfer in transfers)
                {
                    if (transfer.Employee.Surname.Trim().ToLower().StartsWith(txtSurname.Text.Trim().ToLower()))
                    {
                        foundTransfers.Add(transfer);
                    }
                }
                PopulateView(foundTransfers);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = false;
            try
            {
                errorProvider.Clear();
                int ctr=0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (grid.Rows[ctr].Cells["gridSelect"].Value == null)
                    {
                        grid.Rows[ctr].Cells["gridSelect"].Value = false;
                    }
                    if (bool.Parse(grid.Rows[ctr].Cells["gridSelect"].Value.ToString()) == true)
                    {
                        result = true;
                        break;
                    }
                    ctr++;
                }
                if(result == false)
                {
                    MessageBox.Show("Select at least one row");
                    result = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    int ctr = 0;
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (grid.Rows[ctr].Cells["gridID"].Value != null && grid.Rows[ctr].Cells["gridSelect"].Value !=null)
                        {
                            if (DateTime.Parse(grid.Rows[ctr].Cells["gridTransferDate"].Value.ToString()).Date <= DateTime.Today.Date)
                            {
                                employee = dal.GetByID<Employee>(grid.Rows[ctr].Cells["gridStaffID"].Value);
                                employee.CurrentTransferredDate = DateTime.Parse(grid.Rows[ctr].Cells["gridTransferDate"].Value.ToString()).Date;
                                if (grid.Rows[ctr].Cells["gridType"].Value.ToString().Trim() == "Transfer In")
                                {
                                    employee.TransferedIn = true;
                                }
                                else if (grid.Rows[ctr].Cells["gridType"].Value.ToString().Trim() == "Transfer Out")
                                {
                                    employee.TransferredOut = true;
                                }
                                else
                                {
                                    employee.TransferredInternally = true;
                                }
                                
                                dal.Update(employee);

                                transfer.ID = int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString());
                                Query query = new Query();
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "TransferView.ID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = transfer.ID,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                transfers = dal.GetByCriteria<Transfer>(query);
                                foreach(Transfer transf in transfers)
                                {
                                    transf.Transferred = true;
                                    dal.Update(transf);
                                }                             
                            }
                            else if (GlobalData.QuestionMessage("The Transfer Date is greater than Today, Are you sure you want to continue " + "?") == DialogResult.Yes)
                            {
                                employee = dal.GetByID<Employee>(grid.Rows[ctr].Cells["gridStaffID"].Value);
                                employee.CurrentTransferredDate = DateTime.Parse(grid.Rows[ctr].Cells["gridTransferDate"].Value.ToString()).Date;
                                if (grid.Rows[ctr].Cells["gridType"].Value.ToString().Trim() == "Transfer In")
                                {
                                    employee.TransferedIn = true;
                                }
                                else if (grid.Rows[ctr].Cells["gridType"].Value.ToString().Trim() == "Transfer Out")
                                {
                                    employee.TransferredOut = true;
                                }
                                else
                                {
                                    employee.TransferredInternally = true;
                                }

                                dal.Update(employee);

                                transfer.ID = int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString());
                                Query query = new Query();
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "TransferView.ID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = transfer.ID,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                transfers = dal.GetByCriteria<Transfer>(query);
                                foreach (Transfer transf in transfers)
                                {
                                    transf.Transferred = true;
                                    dal.Update(transf);
                                }     
                            }
                        }
                        ctr++;
                    }
                    Clear();
                    GetData();                   
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            int ctr = 0;
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[ctr].Cells["gridSelect"].Value = true;
                ctr++;
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            int ctr = 0;
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[ctr].Cells["gridSelect"].Value = false;
                ctr++;
            }
        }

        private void datePickerTransferDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                foundTransfers.Clear();
                dal.OpenConnection();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "TransferView.Date",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = datePickerTransferDate.Value.Date.ToString("yyyy-MM-dd"),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "TransferView.Transferred",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                transfers = dal.GetByCriteria<Transfer>(query);
                foreach (Transfer transfer in transfers)
                {
                    if (transfer.Date.Value.Date == datePickerTransferDate.Value.Date)
                    {
                        foundTransfers.Add(transfer);
                    }
                }
                PopulateView(foundTransfers);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
    }
}
