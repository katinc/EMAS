using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRDataAccessLayer;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.ErrorLogging;
using eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class ArrearsView : Form
    {
        private IDAL dal;
        private IList<Arrears> arrears;
        private IList<Arrears> foundArrears;
        private Arrears arrear;
        private ArrearsNew arrearsNew;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private Company company;
        private int ctr;
        private bool found;

        public ArrearsView()
        {
            try
            {
                InitializeComponent();
                this.arrearsNew = new ArrearsNew();
                this.dal = new DAL();
                this.arrear = new Arrears();
                this.arrears = new List<Arrears>();
                this.foundArrears = new List<Arrears>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public ArrearsView(IDAL dal, ArrearsNew arrearsNew)
        {
            try
            {
                InitializeComponent();
                this.arrearsNew = arrearsNew;
                this.dal = dal;
                this.arrear = new Arrears();
                this.arrears = new List<Arrears>();
                this.foundArrears = new List<Arrears>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
            }
            catch(Exception ex)
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
                    Arrears arrear = new Arrears();
                    arrear.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    arrear.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    arrear.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    arrear.Employee.FirstName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                    arrear.Employee.Gender = grid.CurrentRow.Cells["gridGender"].Value.ToString();
                    arrear.Employee.Age = grid.CurrentRow.Cells["gridAge"].Value.ToString();

                    arrear.Type = grid.CurrentRow.Cells["gridType"].Value.ToString();
                    arrear.CurrentSalary = decimal.Parse(grid.CurrentRow.Cells["gridCurrentSalary"].Value.ToString());
                    arrear.PreviousSalary = decimal.Parse(grid.CurrentRow.Cells["gridPreviousSalary"].Value.ToString());
                    arrear.NumberOfTimes = int.Parse(grid.CurrentRow.Cells["gridNumberOfTimes"].Value.ToString());

                    if(grid.CurrentRow.Cells["gridEffectiveDate"].Value == null)
                    {
                        arrear.EffectiveDate = null;
                    }
                    else 
                    {
                        arrear.EffectiveDate = DateTime.Parse(grid.CurrentRow.Cells["gridEffectiveDate"].Value.ToString());
                    }
                    arrear.SSNIT =  bool.Parse(grid.CurrentRow.Cells["gridSSNIT"].Value.ToString());
                    arrear.IncomeTax =  bool.Parse(grid.CurrentRow.Cells["gridIncomeTax"].Value.ToString());
                    arrear.In_Use = bool.Parse(grid.CurrentRow.Cells["gridInUse"].Value.ToString());
                    arrear.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                    arrear.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    arrearsNew.Arrear = arrear;
                    arrearsNew.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<Arrears> arrears)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Arrears arrear in arrears)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = arrear.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = arrear.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = arrear.Employee.ID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = arrear.Employee.Surname + " " + arrear.Employee.FirstName + " " + arrear.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGender"].Value = arrear.Employee.Gender;
                    grid.Rows[ctr].Cells["gridAge"].Value = arrear.Employee.Age;
                    grid.Rows[ctr].Cells["gridType"].Value = arrear.Type;
                    grid.Rows[ctr].Cells["gridCurrentSalary"].Value = arrear.CurrentSalary;
                    grid.Rows[ctr].Cells["gridPreviousSalary"].Value = arrear.PreviousSalary;
                    grid.Rows[ctr].Cells["gridNumberOfTimes"].Value = arrear.NumberOfTimes;
                    grid.Rows[ctr].Cells["gridSSNIT"].Value = arrear.SSNIT;
                    grid.Rows[ctr].Cells["gridIncomeTax"].Value = arrear.IncomeTax;
                    grid.Rows[ctr].Cells["gridInUse"].Value = arrear.In_Use;
                    grid.Rows[ctr].Cells["gridEffectiveDate"].Value = arrear.EffectiveDate;
                    grid.Rows[ctr].Cells["gridReason"].Value = arrear.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = arrear.User.ID;

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
                        Property = "ArrearsView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ArrearsView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ArrearsView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ArrearsView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ArrearsView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ArrearsView.Firstname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ArrearsView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (effectiveDatePicker.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ArrearsView.EffectiveDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = effectiveDatePicker.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }

                arrears = dal.GetByCriteria<Arrears>(query);
                PopulateView(arrears);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ArrearsView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }

        private void closeButton_Click(object sender, EventArgs e)
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

        private void removeButton_Click(object sender, EventArgs e)
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
                                arrear.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                arrear.Archived = true;
                                dal.Delete(arrear);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                arrear.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                arrear.Archived = true;
                                dal.Delete(arrear);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                txtFirstName.Clear();
                txtSurname.Clear();
                txtStaffID.Clear();
                effectiveDatePicker.ResetText();
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
                if (txtStaffID.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (txtStaffID.Text.Length >= company.MinimumCharacter)
                    {
                        foundArrears.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "ArrearsView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        arrears = dal.GetByCriteria<Arrears>(query);
                        if (arrears.Count > 0)
                        {
                            foreach (Arrears arrear in this.arrears)
                            {
                                if (arrear.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundArrears.Add(arrear);
                                }
                            }
                            PopulateView(foundArrears);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + txtStaffID.Text + " has no Arrears");
                            grid.Rows.Clear();
                            txtStaffID.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
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
    }
}
