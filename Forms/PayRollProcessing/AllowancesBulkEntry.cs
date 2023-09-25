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
    public partial class AllowancesBulkEntry : Form
    {
        private IList<Department> departments;
        private IDAL dal;
        public Permissions permissions;
        public AllowancesBulkEntry()
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
        IList<Allowance> allowanceTypes;
        private void cmbAllowanceType_DropDown(object sender, EventArgs e)
        {
            try
            {
                 allowanceTypes = dal.GetAll<Allowance>();
                 cmbAllowanceType.Items.Clear();
                //cmbAllowanceType.Items.Add("ALL");
                foreach (var allowanceType in allowanceTypes)
                {
                    cmbAllowanceType.Items.Add(allowanceType.Description);
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

            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            GlobalData.ItemControl = "AllowanceNew";
            var permissions = GlobalData.CheckPermissions(2);
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

                        var staffAllowance = new StaffAllowance();
                        staffAllowance.ID = Convert.ToInt32(dRow.Cells["gridID"].Value ?? 0);
                        staffAllowance.InUse = Convert.ToBoolean(dRow.Cells["gridActive"].Value ?? true);
                        staffAllowance.IsEndDate = Convert.ToBoolean(dRow.Cells["gridIsEndDate"].Value ?? false);

                       if(staffAllowance.IsEndDate==false)
                        staffAllowance.EndDate =null;
                       else
                        staffAllowance.EndDate =Convert.ToDateTime(dRow.Cells["gridEndDate"].Value);

                       if (dRow.Cells["gridStartDate"].Value != null)
                           staffAllowance.EffectiveDate = Convert.ToDateTime(dRow.Cells["gridStartDate"].Value);
                       else
                           staffAllowance.EffectiveDate = DateTime.Now;

                        staffAllowance.Archived = false;
                        staffAllowance.Employee = employees.FirstOrDefault(r => r.StaffID == dRow.Cells["gridStaffID"].Value.ToString());
                        staffAllowance.Amount = Convert.ToDecimal(dRow.Cells["gridAmount"].Value);
                        staffAllowance.Frequency = Convert.ToString(dRow.Cells["gridFrequency"].Value);

                        staffAllowance.Type = allowanceTypes[cmbAllowanceType.SelectedIndex];
                        staffAllowance.User = GlobalData.User;

                      
                        if (staffAllowance.ID > 0)
                        {
                            if (permissions.CanEdit)
                            {
                                dal.Update(staffAllowance);
                            }
                            else
                            {
                                MessageBox.Show("Sorry you do not have permission to edit this data.");
                            }
                        }
                        else if (staffAllowance.Amount > 0) { 
                            dal.Save(staffAllowance);
                        }
                     }
                   dal.CommitTransaction();
                   MessageBox.Show("Saved Successfully");
                  
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
        private IList<StaffAllowance> GetAllowancesByType(string AllowanceCategory)
        {
            IList<StaffAllowance> staffAllowances=new List<StaffAllowance>();
            try
            {
                Query StaffAllowance = new Query();
                StaffAllowance.Criteria.Add(new Criterion()
                {
                    Property = "StaffAllowanceView.Allowance",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = AllowanceCategory,
                    CriteriaOperator = CriteriaOperator.And
                });
                StaffAllowance.Criteria.Add(new Criterion()
                {
                    Property = "StaffAllowanceView.AllowanceArchived",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                staffAllowances = dal.GetByCriteria<StaffAllowance>(StaffAllowance);
                staffAllowances.OrderByDescending(r => r.ID);
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            return staffAllowances;
        }

        private List<StaffAllowance> PassStaffAllowances(IList<Employee> employees)
        {
           List<StaffAllowance> newStaffAllowances=new List<StaffAllowance>();
            if (employees != null && employees.Count > 0)
            {
               var staffAllowances=GetAllowancesByType(cmbAllowanceType.Text);
               
                    foreach (var emp in employees)
                    {
                        StaffAllowance newstaffAllowance = null;
                        if (staffAllowances != null && staffAllowances.Count>0)
                            newstaffAllowance=staffAllowances.FirstOrDefault(r => r.Employee.ID == emp.ID);

                      if (newstaffAllowance != null){
                          if (newstaffAllowance.IsEndDate == false)
                              newstaffAllowance.EndDate = null;
                          newstaffAllowance.Employee = emp;
                          newStaffAllowances.Add(newstaffAllowance);
                      }
                      else
                      {
                          newstaffAllowance = new StaffAllowance();
                          newstaffAllowance.InUse = true;
                          //newstaffAllowance.IsEndDate = true;
                          newstaffAllowance.User = GlobalData.User;
                          newstaffAllowance.Frequency = "Monthly";
                          newstaffAllowance.Employee = emp;
                      }
                      if (newstaffAllowance!=null && newStaffAllowances.Where(r => r.Employee.ID == newstaffAllowance.Employee.ID).Count() == 0)
                         newStaffAllowances.Add(newstaffAllowance);
                    }
                
            }

            return newStaffAllowances;
        }
        private void loadGrid(IList<StaffAllowance> StaffAllowances)
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
                        grid.Rows[ctr].Cells["gridAllowanceType"].Value = cmbAllowanceType.Text;
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
                if (cmbAllowanceType.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbAllowanceType, "Allowance Type is required!");
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
                    var staffAllowances = PassStaffAllowances(employees);
                    loadGrid(staffAllowances);

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
            cmbAllowanceType.Items.Clear();
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
