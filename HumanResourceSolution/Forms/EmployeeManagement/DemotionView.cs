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
using eMAS.Forms.StaffManagement;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class DemotionView : Form
    {
        private IDAL dal;
        private DemotionForm demotionForm;
        private Employee employee;
        private EmployeeGrade employeeGrade;
        private GradeCategory gradeCategory;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Zone> zones;
        private IList<GradeCategory> gradeCategories;
        private Promotion demotion;
        private IList<Promotion> demotions;
        private IList<Promotion> foundDemotions;
        private int ctr;
        private bool found;

        public DemotionView(DemotionForm demotionForm)
        {
            try
            {
                InitializeComponent();
                this.demotionForm = demotionForm;
                this.employee = new Employee();
                this.demotion = new Promotion();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.demotions = new List<Promotion>();
                this.foundDemotions = new List<Promotion>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.zones = new List<Zone>();
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

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow != null)
                    {
                        if (bool.Parse(grid.CurrentRow.Cells["gridAction"].Value.ToString()) == false)
                        {
                            demotionForm.EditDemotion(grid.CurrentRow);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("The Staff is already demoted, Please add or cancel this Demotion");
                        }
                    }
                }

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
                        if (GlobalData.QuestionMessage("Are you sure you want to Cancel the Demotion of the Staff " + "?") == DialogResult.Yes)
                        {

                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                dal.BeginTransaction();
                                demotion.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                demotion.Archived = true;
                                dal.Delete(demotion);
                                employee = dal.GetByID<Employee>(grid.CurrentRow.Cells["gridStaffID"].Value);
                                employee.CurrentPromotionDate = null;
                                employee.PromotionType = null;
                                dal.Update(employee);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                dal.CommitTransaction();
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                dal.BeginTransaction();
                                demotion.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                demotion.Archived = true;
                                dal.Delete(demotion);
                                employee = dal.GetByID<Employee>(grid.CurrentRow.Cells["gridStaffID"].Value);
                                employee.CurrentPromotionDate = null;
                                employee.PromotionType = null;
                                dal.Update(employee);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                dal.CommitTransaction();
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
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not Cancel the Demotion successfully,Please See the system Administrator");
            }
        }

        private void DemotionView_Load(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
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
                    grid.Rows[ctr].Cells["gridNewSalary"].Value = demotion.NewSalary;
                    grid.Rows[ctr].Cells["gridNewGradeCategory"].Value = demotion.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridNewGrade"].Value = demotion.Grade.Grade;
                    grid.Rows[ctr].Cells["gridReason"].Value = demotion.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = employee.User.ID;
                    
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
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
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.PromotionType",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = "Demoted",
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

        private void Clear()
        {
            try
            {
                demotion = new Promotion();
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                datePickerDemotionDate.ResetText();
                datePickerDemotionDate.Checked = false;
                txtStaffID.Clear();
                txtSurname.Clear();
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
                demotions = dal.GetAll<Promotion>();
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
                Logger.LogError(ex);
            }
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
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
                Logger.LogError(ex);
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
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
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.Department.ID == departments[cboDepartment.SelectedIndex].ID)
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.Unit.ID == units[cboUnit.SelectedIndex].ID)
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.GradeCategory.ID == gradeCategories[cboGradeCategory.SelectedIndex].ID)
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.Grade.ID == employeeGrades[cboGrade.SelectedIndex].ID)
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategories)
                {
                    cboGradeCategory.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cboGrade.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
                departments = dal.GetAll<Department>();
                foreach (Department department in departments)
                {
                    cboDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboDepartment.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    cboUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_DropDownClosed(object sender, EventArgs e)
        {
            try
            {

                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.Department.ID == departments[cboDepartment.SelectedIndex].ID)
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.GradeCategory.ID == gradeCategories[cboGradeCategory.SelectedIndex].ID)
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboZone_DropDownClosed(object sender, EventArgs e)
        {
            try
            {

                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.Zone.ID == zones[cboZone.SelectedIndex].ID)
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.Items.Clear();
                zones = dal.GetAll<Zone>();
                foreach (Zone zone in zones)
                {
                    cboZone.Items.Add(zone.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foundDemotions.Clear();
                demotions = dal.GetAll<Promotion>();
                foreach (Promotion demotion in demotions)
                {
                    if (demotion.Employee.Zone.ID == zones[cboZone.SelectedIndex].ID)
                    {
                        foundDemotions.Add(demotion);
                    }
                }
                PopulateView(foundDemotions);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
