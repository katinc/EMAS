using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class GeneralReversalIncrementForm : Form
    {
        private IList<Employee> employees;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> grades;
        private IList<StaffSalaryHistory> staffSalaryHistories;
        private Employee employee;
        private Increment increment;
        private DAL dal;
        private int incrementID;
        private int staffCode;
        private bool editMode;

        public GeneralReversalIncrementForm()
        {
            try
            {
                InitializeComponent();
                this.increment = new Increment();
                this.employee = new Employee();
                this.dal = new DAL();
                this.staffSalaryHistories = new List<StaffSalaryHistory>();
                this.employees = new List<Employee>();
                this.gradeCategories = new List<GradeCategory>();
                this.grades = new List<EmployeeGrade>();
                this.incrementID = 0;
                this.staffCode = 0;
                this.editMode = false;
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
                cboGradeCategory.Items.Add("All");
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
                grades = dal.GetByCriteria<EmployeeGrade>(query);
                cboGrade.Items.Add("All");
                foreach (EmployeeGrade grade in grades)
                {
                    cboGrade.Items.Add(grade.Grade);
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

        private void GeneralReversalIncrementForm_Load(object sender, EventArgs e)
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

        private void Clear()
        {
            try
            {
                incrementID = 0;
                staffErrorProvider.Clear();
                datePickerIncrementDate.ResetText();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                txtReason.Text = string.Empty;
                checkBoxPercentage.Checked = false;
                numericPercentageIncrease.Value = 0;
                editMode = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void EditGeneralReversalIncrement(DataGridViewRow row)
        {
            try
            {
                Clear();
                editMode = true;
                incrementID = int.Parse(row.Cells["gridID"].Value.ToString());
                cboGradeCategory_DropDown(this, EventArgs.Empty);
                cboGradeCategory.Text = row.Cells["gridGradeCategory"].Value.ToString();
                cboGradeCategory_SelectionChangeCommitted(this, EventArgs.Empty);
                cboGrade.Text = row.Cells["gridGrade"].Value.ToString();
                checkBoxPercentage.Checked = bool.Parse(row.Cells["gridPercentage"].Value.ToString());
                numericPercentageIncrease.Value = decimal.Parse(row.Cells["gridIncrease"].Value.ToString());
                datePickerIncrementDate.Text = row.Cells["gridIncrementDate"].Value.ToString();
                txtReason.Text = row.Cells["gridReason"].Value.ToString();
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(row.Cells["gridUserID"].Value.ToString()))
                {
                    btnSave.Enabled = false;
                }
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

                    if (editMode)
                    {
                        if (datePickerIncrementDate.Value.Date <= DateTime.Today.Date)
                        {
                            decimal basicSalary = 0;
                            Query query = new Query();
                            if (cboGradeCategory.Text != string.Empty)
                            {
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffPersonalInfoView.GradeCategory",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = cboGradeCategory.Text.Trim(),
                                    CriteriaOperator = CriteriaOperator.And
                                });
                            }
                            if (cboGrade.Text != string.Empty)
                            {
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffPersonalInfoView.Grade",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = cboGrade.Text.Trim(),
                                    CriteriaOperator = CriteriaOperator.And
                                });
                            }
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Confirmed",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = true,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.TransferredOut",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = false,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Terminated",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = false,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Payment",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = true,
                                CriteriaOperator = CriteriaOperator.And
                            });

                            employees = dal.GetByCriteria<Employee>(query);
                            foreach (Employee employee in employees)
                            {
                                basicSalary = 0;
                                UpdateIncrementsEntity();
                                employee.IncrementDate = increment.IncrementDate;
                                if (increment.IsPercentage == true)
                                {
                                    basicSalary = employee.BasicSalary-((increment.Increase / 100) * employee.BasicSalary);
                                    employee.BasicSalary = Math.Round(basicSalary, 2);
                                }
                                else
                                {
                                    basicSalary = employee.BasicSalary - increment.Increase;
                                    employee.BasicSalary = Math.Round(basicSalary, 2);
                                }
                                dal.Update(employee);
                                Query staffSalaryHistoryQuery = new Query();
                                staffSalaryHistoryQuery.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffSalaryHistoryView.StaffID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = employee.StaffID,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                staffSalaryHistories = dal.GetByCriteria<StaffSalaryHistory>(staffSalaryHistoryQuery);
                                foreach (StaffSalaryHistory staffSalaryH in staffSalaryHistories)
                                {
                                    staffSalaryH.MonthlyBasicSalary = basicSalary;
                                    staffSalaryH.Grade.ID = increment.Grade.ID;
                                    dal.Update(staffSalaryH);
                                }

                                increment.Employee.StaffID = employee.StaffID;
                                increment.Employee.ID = employee.ID;
                                dal.Update(increment);
                                increment = new Increment();
                            }
                        }
                    }
                    else
                    {
                        if (datePickerIncrementDate.Value.Date <= DateTime.Today.Date)
                        {
                            decimal basicSalary = 0;
                            Query query = new Query();
                            if (cboGradeCategory.Text != "All")
                            {
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffPersonalInfoView.GradeCategory",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = cboGradeCategory.Text.Trim(),
                                    CriteriaOperator = CriteriaOperator.And
                                });
                            }
                            if (cboGrade.Text != "All")
                            {
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffPersonalInfoView.Grade",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = cboGrade.Text.Trim(),
                                    CriteriaOperator = CriteriaOperator.And
                                });
                            }
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Confirmed",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = true,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.TransferredOut",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = false,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Terminated",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = false,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffPersonalInfoView.Payment",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = true,
                                CriteriaOperator = CriteriaOperator.And
                            });

                            employees = dal.GetByCriteria<Employee>(query);
                            foreach (Employee employee in employees)
                            {
                                basicSalary = 0;
                                UpdateIncrementsEntity();
                                employee.IncrementDate = increment.IncrementDate;
                                if (increment.IsPercentage == true)
                                {
                                    employee.OldBasicSalary = employee.BasicSalary;
                                    basicSalary = employee.BasicSalary - ((increment.Increase / 100) * employee.BasicSalary);
                                    employee.BasicSalary = Math.Round(basicSalary, 2);
                                }
                                else
                                {
                                    employee.OldBasicSalary = employee.BasicSalary;
                                    basicSalary = employee.BasicSalary - increment.Increase;
                                    employee.BasicSalary = Math.Round(basicSalary, 2);
                                }
                                dal.Update(employee);
                                Query staffSalaryHistoryQuery = new Query();
                                staffSalaryHistoryQuery.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffSalaryHistoryView.StaffID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = employee.StaffID,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                staffSalaryHistories = dal.GetByCriteria<StaffSalaryHistory>(staffSalaryHistoryQuery);
                                foreach (StaffSalaryHistory staffSalaryH in staffSalaryHistories)
                                {
                                    staffSalaryH.MonthlyBasicSalary = basicSalary;
                                    staffSalaryH.Grade.ID = increment.Grade.ID;
                                    dal.Update(staffSalaryH);
                                }
                                increment.Employee.StaffID = employee.StaffID;
                                increment.Employee.ID = employee.ID;
                                dal.Save(increment);
                                increment = new Increment();
                            }
                        }
                    }
                    dal.CommitTransaction();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Not Saved Successfully,Please See the system Administrator");
            }
        }

        private void UpdateIncrementsEntity()
        {
            try
            {
                increment.ID = incrementID;
                increment.IncrementType = "Reverse";
                increment.IncrementDate = datePickerIncrementDate.Value;
                increment.GradeCategory.ID = gradeCategories[cboGradeCategory.SelectedIndex].ID;
                Query employeeGradeQuery = new Query();
                employeeGradeQuery.Criteria.Add(new Criterion()
                {
                    Property = "CategoryID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = increment.GradeCategory.ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                grades = dal.GetByCriteria<EmployeeGrade>(employeeGradeQuery);
                foreach (EmployeeGrade grade in grades)
                {
                    increment.Grade.ID = grade.ID;
                }
                increment.IsPercentage = checkBoxPercentage.Checked;
                increment.Increase = numericPercentageIncrease.Value;
                increment.User.ID = GlobalData.User.ID;
                increment.Reason = txtReason.Text;
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
                if (datePickerIncrementDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerIncrementDate, "Please select the Increment Date");
                    datePickerIncrementDate.Focus();
                }
                if (cboGradeCategory.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboGradeCategory, "Please select the Grade Category");
                    cboGradeCategory.Focus();
                }
                else if (cboGradeCategory.Text.Trim() != string.Empty && cboGrade.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboGrade, "Please select the Grade");
                    cboGrade.Focus();
                }
                else if (numericPercentageIncrease.Value <= 0)
                {
                    result = false;
                    staffErrorProvider.SetError(numericPercentageIncrease, "Please Increase cannot be zero");
                    numericPercentageIncrease.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralReversalIncrementView form = new GeneralReversalIncrementView(this);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void checkBoxPercentage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxPercentage.Checked == true)
                {
                    lblPercent.Visible = true;
                }
                else
                {
                    lblPercent.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
