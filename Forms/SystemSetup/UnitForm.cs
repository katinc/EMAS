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
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.SystemSetup
{
    public partial class UnitForm : Form
    {
        private IDAL dal;
        private Department department;
        private Unit unit;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Unit> foundUnits;
        private int ctr;
        private bool found;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public UnitForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.department = new Department();
                this.unit = new Unit();
                this.departments = new List<Department>();
                this.foundUnits = new List<Unit>();
                this.units = new List<Unit>();
                this.ctr = 0;
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                if (cboDepartment.Text.ToString() == null || cboDepartment.Text.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Department ");
                    cboDepartment.Focus();
                }
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Description cannot be empty" + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }

        private void GetData()
        {
            try
            {
                if (cboDepartment.Text.Trim() == string.Empty)
                {
                    department.ID = 0;
                }
                else
                {
                    department.ID = departments[cboDepartment.SelectedIndex].ID;
                }
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "UnitView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.DepartmentID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = department.ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                units = dal.GetByCriteria<Unit>(query);
                PopulateView(units);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                            unit.Code = row.Cells["gridCode"].Value.ToString();
                            unit.Description = row.Cells["gridDescription"].Value.ToString();
                            unit.Department.ID = departments[cboDepartment.SelectedIndex].ID;
                            unit.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            unit.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(unit);
                            }
                            else
                            {
                                unit.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(unit);
                            }
                        }
                    }
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
                            
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                unit.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                unit.Active = false;
                                unit.Archived = true;
                                dal.Delete(unit);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                unit.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                unit.Active = false;
                                unit.Archived = true;
                                dal.Delete(unit);
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

        private void PopulateView(IList<Unit> units)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Unit unit in units)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = unit.ID.ToString();
                    grid.Rows[ctr].Cells["gridCode"].Value = unit.Code;
                    grid.Rows[ctr].Cells["gridDescription"].Value = unit.Description;
                    grid.Rows[ctr].Cells["gridDepartmentID"].Value = unit.Department.ID.ToString();
                    grid.Rows[ctr].Cells["gridActive"].Value = unit.Active.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = unit.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundUnits.Clear();
                cboDepartment.Items.Clear();
                units = dal.GetAll<Unit>();
                foreach (Unit Unit in units)
                {
                    if ((Unit.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundUnits.Add(Unit);
                    }
                }
                PopulateView(foundUnits);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foundUnits.Clear();
                txtDescription.Clear();
                units = dal.GetAll<Unit>();
                grid.Rows.Clear();
                foreach (Unit unit in units)
                {
                    if (unit.Department.ID == departments[cboDepartment.SelectedIndex].ID)
                    {
                        foundUnits.Add(unit);
                    }
                }
                PopulateView(foundUnits);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                departments = dal.GetAll<Department>();
                cboDepartment.Items.Clear();
                txtDescription.Clear();
                cboDepartment.Text = string.Empty;
                foreach (Department Department in departments)
                {
                    cboDepartment.Items.Add(Department.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboDepartment_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                foundUnits.Clear();
                units = dal.GetAll<Unit>();
                txtDescription.Clear();
                grid.Rows.Clear();
                foreach (Unit unit in units)
                {
                    if (unit.Department.ID == departments[cboDepartment.SelectedIndex].ID)
                    {
                        foundUnits.Add(unit);
                    }
                }
                PopulateView(foundUnits);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void UnitForm_Load(object sender, EventArgs e)
        {
            //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

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

    }
}
