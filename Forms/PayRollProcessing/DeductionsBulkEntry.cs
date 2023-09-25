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
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using Microsoft.VisualBasic;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class DeductionsBulkEntry : Form
    {
        private IList<Department> departments;
        private IDAL dal;
        public Permissions permissions;
        public DeductionsBulkEntry()
        {
            InitializeComponent();
            dal = new DAL();
            departments = new List<Department>();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbDepartment.Items.Clear();
                departments = dal.GetAll<Department>();
                cmbDepartment.Items.Add("ALL DEPARTMENTS");
                foreach (Department department in departments)
                {
                    cmbDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cmbGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cmbUnit_DropDown(object sender, EventArgs e)
        {
            if (cmbDepartment.Text == string.Empty || cmbDepartment.Text=="ALL DEPARTMENTS")
            {
                cmbUnit.Items.Clear();
                return;
            }

            try
            {
                Query query = new Query();

                cmbUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cmbDepartment.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                var units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    cmbUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        IList<Deduction> deductionTypes;
        private void cmbAllowanceType_DropDown(object sender, EventArgs e)
        {
            try
            {
                deductionTypes = dal.GetAll<Deduction>();
                 cmbDeductionType.Items.Clear();
                //cmbAllowanceType.Items.Add("ALL");
                 foreach (var deductionType in deductionTypes)
                {
                    cmbDeductionType.Items.Add(deductionType.Description);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void AllowancesBulkEntry_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in grid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            permissions = GlobalData.CheckPermissions(2);
            savebtn.Enabled = permissions.CanAdd;
            btnDelete.Enabled = permissions.CanDelete;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(grid.Rows.Count==0) 
                errorProvider1.SetError(btnFind, "No Records To Save!");
            else{
               
                try
                {
                    dal.BeginTransaction();
                foreach (DataGridViewRow dRow in grid.Rows)
                {
                    if (dRow.IsNewRow)
                        continue;

                        var staffDeduction = new StaffDeduction();
                        staffDeduction.ID = Convert.ToInt32(dRow.Cells["gridID"].Value ?? 0);
                        staffDeduction.InUse = Convert.ToBoolean(dRow.Cells["gridActive"].Value ?? true);
                        staffDeduction.IsEndDate = Convert.ToBoolean(dRow.Cells["gridIsEndDate"].Value ?? false);

                        if (staffDeduction.IsEndDate == false)
                            staffDeduction.EndDate = null;
                       else
                            staffDeduction.EndDate = Convert.ToDateTime(dRow.Cells["gridEndDate"].Value);

                       if (dRow.Cells["gridStartDate"].Value != null)
                           staffDeduction.EffectiveDate = Convert.ToDateTime(dRow.Cells["gridStartDate"].Value);
                       else
                           staffDeduction.EffectiveDate = DateTime.Now;

                       staffDeduction.Archived = false;
                       staffDeduction.Employee = employees.FirstOrDefault(r => r.StaffID == dRow.Cells["gridStaffID"].Value.ToString());
                       staffDeduction.Amount = Convert.ToDecimal(dRow.Cells["gridAmount"].Value);
                       staffDeduction.Frequency = Convert.ToString(dRow.Cells["gridFrequency"].Value);

                       staffDeduction.Type = deductionTypes[cmbDeductionType.SelectedIndex];
                       staffDeduction.User = GlobalData.User;


                       if (staffDeduction.ID > 0)
                        {
                            if (permissions.CanEdit)
                            {
                                dal.Update(staffDeduction);
                            }
                            else
                            {
                                MessageBox.Show("Sorry you do not have permission to edit this data.");
                            }
                            
                        }
                       else if (staffDeduction.Amount > 0)
                           dal.Save(staffDeduction);
                     }
                   dal.CommitTransaction();
                  
                 }
                catch (Exception xii)
                {
                    dal.RollBackTransaction();
                    Logger.LogError(xii);
                }

                btnFind_Click(sender, e);
            }
        }
        //IList<StaffAllowance> staffAllowances;
        private IList<StaffDeduction> GetDeductionsByType(string DeductionCategory)
        {
            IList<StaffDeduction> staffDeductions = new List<StaffDeduction>();
            try
            {
                Query StaffDeduction = new Query();
                StaffDeduction.Criteria.Add(new Criterion()
                {
                    Property = "StaffDeductionView.Deduction",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = DeductionCategory,
                    CriteriaOperator = CriteriaOperator.And
                });
                StaffDeduction.Criteria.Add(new Criterion()
                {
                    Property = "StaffDeductionView.Archived",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });

                staffDeductions = dal.GetByCriteria<StaffDeduction>(StaffDeduction);
                staffDeductions.OrderByDescending(r => r.ID);
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            return staffDeductions;
        }

        private List<StaffDeduction> PassStaffDeductions(IList<Employee> employees)
        {
            List<StaffDeduction> newStaffDeductions = new List<StaffDeduction>();
            if (employees != null && employees.Count > 0)
            {
               var staffDeductions=GetDeductionsByType(cmbDeductionType.Text);
             
                    foreach (var emp in employees)
                    {
                        StaffDeduction newstaffDeduction = null;
                        if (staffDeductions!=null && staffDeductions.Count>0)
                            newstaffDeduction=staffDeductions.FirstOrDefault(r => r.Employee.ID == emp.ID);

                        if (newstaffDeduction != null)
                        {
                            if (newstaffDeduction.IsEndDate == false)
                                newstaffDeduction.EndDate = null;
                            newstaffDeduction.Employee = emp;
                            newStaffDeductions.Add(newstaffDeduction);
                      }
                      else
                      {
                          newstaffDeduction = new StaffDeduction();
                          newstaffDeduction.InUse = true;
                          //newstaffAllowance.IsEndDate = true;
                          newstaffDeduction.User = GlobalData.User;
                          newstaffDeduction.Frequency = "Monthly";
                          newstaffDeduction.Employee = emp;
                      }
                        if (newstaffDeduction != null && staffDeductions.Where(r => r.Employee.ID == newstaffDeduction.Employee.ID).Count() == 0)
                            newStaffDeductions.Add(newstaffDeduction);
                    }
                
            }

            return newStaffDeductions;
        }
        private void loadGrid(IList<StaffDeduction> StaffAllowances)
        {
           
            try
            {
                grid.Rows.Clear();
                int ctr = 0;
                foreach (var staffAllowance in StaffAllowances)
                {
                    if (staffAllowance.Employee != null)
                    {
                        grid.Rows.Add(1);
                        
                        grid.Rows[ctr].Cells["gridID"].Value = staffAllowance.ID;
                        grid.Rows[ctr].Cells["gridStaffID"].Value = staffAllowance.Employee.StaffID;
                        grid.Rows[ctr].Cells["gridName"].Value = GlobalData.GetFullName(staffAllowance.Employee);
                        grid.Rows[ctr].Cells["gridAllowanceType"].Value = cmbDeductionType.Text;
                        grid.Rows[ctr].Cells["gridFrequency"].Value = staffAllowance.Frequency;
                        grid.Rows[ctr].Cells["gridAmount"].Value = staffAllowance.Amount;
                        grid.Rows[ctr].Cells["gridStartDate"].Value = staffAllowance.EffectiveDate;
                        grid.Rows[ctr].Cells["gridIsEndDate"].Value = staffAllowance.IsEndDate;
                        grid.Rows[ctr].Cells["gridEndDate"].Value = staffAllowance.EndDate;
                        grid.Rows[ctr].Cells["gridActive"].Value = staffAllowance.InUse;
                        grid.Rows[ctr].Cells["gridUserID"].Value = staffAllowance.User.ID;

                        ctr++;
                    }
                   
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }
        IList<Employee> employees;
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (cmbDeductionType.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbDeductionType, "Allowance Type is required!");
                }
                else
                {
                    Query query = new Query();
                    if (cmbDepartment.Text.Trim() != string.Empty && cmbDepartment.Text.ToUpper().Trim() != "ALL DEPARTMENTS")
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Department",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = cmbDepartment.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }
                    if (cmbUnit.Text.Trim() != string.Empty && cmbUnit.Text.ToUpper().Trim() != "ALL")
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Unit",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = cmbUnit.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }
                    if (cmbGradeCategory.Text.Trim() != string.Empty && cmbGradeCategory.Text.ToUpper().Trim() != "ALL")
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.GradeCategory",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = cmbGradeCategory.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }
                    if (cmbGrade.Text.Trim() != string.Empty && cmbGrade.Text.ToUpper().Trim() != "ALL")
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Grade",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = cmbGrade.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }
                    if (cmbMechanised.Text.Trim() != string.Empty && cmbMechanised.Text.ToUpper().Trim() != "ALL")
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Mechanised",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = cmbMechanised.Text.ToUpper() == "YES" ? true : false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }
                    if (txtStaffID.Text.Trim() != string.Empty)
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = txtStaffID.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }

                    if (txtName.Text.Trim() != string.Empty)
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.firstname+' '+StaffPersonalInfoLazyLoadView.othername+' '+StaffPersonalInfoLazyLoadView.surname",
                            CriterionOperator = CriterionOperator.Like,
                            Value = "%" + txtName.Text.Trim() + "%",
                            CriteriaOperator = CriteriaOperator.And
                        });

                    }

                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Terminated",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = false,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = false,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Confirmed",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = true,
                        CriteriaOperator = CriteriaOperator.And
                    });

                    employees = dal.LazyLoadCriteria<Employee>(query);
                    var staffDeductions = PassStaffDeductions(employees);
                    loadGrid(staffDeductions);

                }
            }
            catch (Exception xii)
            {
                Logger.LogError(xii);
            }
           
        }

        private void cmbGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbGradeCategory.Items.Clear();
              
                  var   gradeCategories = dal.GetAll<GradeCategory>();
               

                foreach (GradeCategory category in gradeCategories)
                {
                    cmbGradeCategory.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.Text == string.Empty)
                cmbUnit.Items.Clear();
        }

        private void cmbGradeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGradeCategory.Text == string.Empty)
                cmbGrade.Items.Clear();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            cmbDepartment.Items.Clear();
            cmbUnit.Items.Clear();
            cmbGradeCategory.Items.Clear();
            cmbGradeCategory.Items.Clear();
            cmbGrade.Items.Clear();
            cmbDeductionType.Items.Clear();
            cmbMechanised.Items.Clear();
            txtStaffID.Clear();
            txtName.Clear();

            grid.Rows.Clear();
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (!Information.IsNumeric(grid.Rows[e.RowIndex].Cells["gridAmount"].Value))
                //{
                //    grid.Rows[e.RowIndex].Cells["gridAmount"].Value = 0;
                //}
                //else if (!Information.IsDate(grid.Rows[e.RowIndex].Cells["gridStartDate"].Value) && Convert.ToDecimal( grid.Rows[e.RowIndex].Cells["gridAmount"].Value)>0)
                //{
                //    grid.Rows[e.RowIndex].Cells["gridStartDate"].Value = DateTime.Now;
                //}
                //else if (!(Information.IsNumeric(grid.Rows[e.RowIndex].Cells["gridID"].Value) && Convert.ToInt32(grid.Rows[e.RowIndex].Cells["gridID"].Value)>0))
                //    grid.Rows[e.RowIndex].Cells["gridStartDate"].Value =null;
                //if (Convert.ToBoolean(grid.Rows[e.RowIndex].Cells["gridIsEndDate"].Value) == true && grid.Rows[e.RowIndex].Cells["gridEndDate"].Value == null)
                //    grid.Rows[e.RowIndex].Cells["gridEndDate"].Value = DateTime.Now;
                //else if (Convert.ToBoolean(grid.Rows[e.RowIndex].Cells["gridIsEndDate"].Value) == false)
                //    grid.Rows[e.RowIndex].Cells["gridEndDate"].Value = null;
            }
            catch (Exception xi)
            {
                //Logger.LogError(xi);
            }
        
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try{
                if (grid.SelectedRows.Count > 0 && MessageBox.Show(this,"Do you really want to delete record?","Confirmation!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    var staffAllowance = new StaffAllowance();
                    staffAllowance.ID = Convert.ToInt32(grid.SelectedRows[0].Cells["gridID"].Value ?? 0);
                    dal.Delete(staffAllowance);
                    grid.Rows.Remove(grid.SelectedRows[0]);
                }
                else{
                    errorProvider1.SetError(btnDelete, "No Record was selected!");
                }
            }
            catch(Exception xi){
                Logger.LogError(xi);
            }
            
        }

        private void cmbGrade_DropDown(object sender, EventArgs e)
        {
            if (cmbGradeCategory.Text == string.Empty || cmbGradeCategory.Text == "ALL")
                return;
            try
            {
                Query query = new Query();
                cmbGrade.Items.Clear();
                cmbGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cmbGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                var employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cmbGrade.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
