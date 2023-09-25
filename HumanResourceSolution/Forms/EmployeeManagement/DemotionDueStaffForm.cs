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

namespace eMAS.Forms.EmployeeManagement
{
    public partial class DemotionDueStaffForm : Form
    {
        private IDAL dal;
        private IList<Employee> employees;
        private Employee employee;
        private Promotion demotion;
        private IList<Promotion> demotions;
        private IList<Promotion> foundDemotions;
        private int ctr;
        private bool found;

        public DemotionDueStaffForm()
        {
            try
            {
                InitializeComponent();
                this.demotion = new Promotion();
                this.demotions = new List<Promotion>();
                this.foundDemotions = new List<Promotion>();
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

        private void DemotionDueStaffForm_Load(object sender, EventArgs e)
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
                        if (GlobalData.QuestionMessage("Are you sure you want to Cancel Demotion of the Staff " + "?") == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                demotion.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                demotion.Archived = true;
                                dal.Delete(demotion);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                demotion.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                demotion.Archived = true;
                                dal.Delete(demotion);
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

        private void PopulateView(IList<Promotion> demotions)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Promotion demotion in demotions)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = demotion.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = demotion.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = demotion.Employee.Title.Description + " " + demotion.Employee.Surname + " " + demotion.Employee.FirstName + " " + demotion.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = demotion.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = demotion.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridZone"].Value = demotion.Employee.Zone.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = demotion.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = demotion.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridDemotionType"].Value = demotion.PromotionType;
                    //grid.Rows[ctr].Cells["gridAction"].Value = demotion.Action;
                    grid.Rows[ctr].Cells["gridDemotionDate"].Value = demotion.PromotionDate;
                    grid.Rows[ctr].Cells["gridNewGrade"].Value = demotion.Grade.Grade;
                    grid.Rows[ctr].Cells["gridNewGradeCategory"].Value = demotion.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridNewSalary"].Value = demotion.NewSalary;
                    grid.Rows[ctr].Cells["gridReason"].Value = demotion.Reason;
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
                        Property = "PromotionView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (datePickerDemotionDate.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.PromotionDate",
                        CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                        Value = datePickerDemotionDate.Value.Date.ToString("yyyy-MM-dd"),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.PromotionType",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = "Demoted",
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.Action",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                demotions = dal.GetByCriteria<Promotion>(query);
                PopulateView(demotions);
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
                demotion = new Promotion();
                grid.Rows.Clear();
                txtStaffID.Clear();
                txtSurname.Clear();
                datePickerDemotionDate.ResetText();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void datePickerDemotionDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                dal.OpenConnection();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.PromotionDate",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = datePickerDemotionDate.Value.Date.ToString("yyyy-MM-dd"),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.PromotionType",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = "Demoted",
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.Action",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                demotions = dal.GetByCriteria<Promotion>(query);
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.PromotionDate.Value.Date == datePickerDemotionDate.Value.Date)
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                dal.OpenConnection();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.PromotionDate",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = datePickerDemotionDate.Value.Date.ToString("yyyy-MM-dd"),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.PromotionType",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = "Demoted",
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.Action",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                demotions = dal.GetByCriteria<Promotion>(query);
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
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
                foundDemotions.Clear();
                dal.OpenConnection();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.PromotionDate",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = datePickerDemotionDate.Value.Date.ToString("yyyy-MM-dd"),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.PromotionType",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = "Demoted",
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.Action",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                demotions = dal.GetByCriteria<Promotion>(query);
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.Surname.Trim().ToLower().StartsWith(txtSurname.Text.Trim().ToLower()))
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private bool ValidateFields()
        {
            bool result = false;
            try
            {
                errorProvider.Clear();
                int ctr = 0;
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
                if (result == false)
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

        private void btnDemote_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.OpenConnection();
                    dal.BeginTransaction();
                    int ctr = 0;
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (grid.Rows[ctr].Cells["gridID"].Value != null && grid.Rows[ctr].Cells["gridSelect"].Value != null)
                        {
                            if (DateTime.Parse(grid.Rows[ctr].Cells["gridDemotionDate"].Value.ToString()).Date <= DateTime.Today.Date)
                            {
                                employee = dal.GetByID<Employee>(grid.Rows[ctr].Cells["gridStaffID"].Value);
                                employee.CurrentPromotionDate = DateTime.Parse(grid.Rows[ctr].Cells["gridDemotionDate"].Value.ToString()).Date;
                                //employee.PromotionType = "Demoted";
                                dal.Update(employee);

                                demotion.ID = int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString());
                                Query query = new Query();
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "PromotionView.ID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = demotion.ID,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                demotions = dal.GetByCriteria<Promotion>(query);
                                foreach (Promotion demo in demotions)
                                {
                                    //demo.Action = true;
                                    //demo.PromotionType = "Demoted";
                                    dal.Update(demo);
                                }
                            }
                            else if (GlobalData.QuestionMessage("The Promotion Date is greater than Today, Are you sure you want to continue " + "?") == DialogResult.Yes)
                            {
                                employee = dal.GetByID<Employee>(grid.Rows[ctr].Cells["gridStaffID"].Value);
                                employee.CurrentPromotionDate = DateTime.Parse(grid.Rows[ctr].Cells["gridDemotionDate"].Value.ToString()).Date;
                                //employee.PromotionType = "Demoted";
                                dal.Update(employee);

                                demotion.ID = int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString());
                                Query query = new Query();
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "PromotionView.ID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = demotion.ID,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                demotions = dal.GetByCriteria<Promotion>(query);
                                foreach (Promotion demo in demotions)
                                {
                                    //demo.Action = true;
                                    //demo.PromotionType = "Demoted";
                                    dal.Update(demo);
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
    }
}
