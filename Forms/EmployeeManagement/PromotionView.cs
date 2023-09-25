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
    public partial class PromotionView : Form
    {
        private IDAL dal;
        private NewPromotion promotionForm;
        private Employee employee;
        private EmployeeGrade employeeGrade;
        private GradeCategory gradeCategory;
        private Company company;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<Zone> zones;
        private IList<PromotionType> promotionTypes;
        private Promotion promotion;
        private IList<Promotion> promotions;
        private IList<Promotion> foundPromotions;
        private int ctr;
        private bool approved;
        private bool found;

        public PromotionView(NewPromotion promotionForm)
        {
            try
            {
                InitializeComponent();
                this.promotionForm = promotionForm;
                this.employee = new Employee();
                this.promotion = new Promotion();
                this.company = new Company();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.promotions = new List<Promotion>();
                this.foundPromotions = new List<Promotion>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.zones = new List<Zone>();
                this.promotionTypes=new List<PromotionType>();
                this.dal = new DAL();
                this.ctr = 0;
                this.found = false;
                this.approved = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public PromotionView()
        {
            try
            {
                InitializeComponent();
                this.promotionForm = new NewPromotion();
                this.employee = new Employee();
                this.promotion = new Promotion();
                this.company = new Company();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.promotions = new List<Promotion>();
                this.foundPromotions = new List<Promotion>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.zones = new List<Zone>();
                this.promotionTypes = new List<PromotionType>();
                this.dal = new DAL();
                this.ctr = 0;
                this.found = false;
                this.approved = false;
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
                if (grid.CurrentRow != null && promotionForm.CanEdit)
                {
                    if (grid.CurrentRow != null)
                    {
                        if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == false)
                        {
                            promotionForm.EditPromotion(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("The Staff is already Approved");
                        }
                    }
                }
                else if (!promotionForm.CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
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
                    if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == false)
                    {
                        if (grid.CurrentRow.Cells["gridID"].Value != null)
                        {
                            if (GlobalData.QuestionMessage("Are you sure you want to Cancel the Promotion of the Staff " + "?") == DialogResult.Yes)
                            {
                                dal.BeginTransaction();
                                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                                {
                                    promotion.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                    promotion.Archived = true;
                                    //dal.Delete(promotion);
                                    GlobalData.ProcessDelete(this.Name, promotion.ID);
                                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                }
                                else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                                {
                                    promotion.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                    promotion.Archived = true;
                                    //dal.Delete(promotion);
                                    GlobalData.ProcessDelete(this.Name, promotion.ID);
                                    grid.Rows.RemoveAt(grid.CurrentRow.Index);

                                }
                                else
                                {
                                    MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                                }
                                dal.CommitTransaction();

                            } 
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Employee is Aleady Approved For Promotion and so cannot be Deleted");
                    }
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not Cancel the Promotion successfully,Please See the system Administrator");
            }
        }

        private void PromotionView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                cboApproved_DropDown(sender, e);
                cboApproved.Text = "No";
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

        private void PopulateView(IList<Promotion> promotions)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (Promotion promotion in promotions)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = promotion.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = promotion.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = promotion.Employee.Title.Description + " " + promotion.Employee.Surname + " " + promotion.Employee.FirstName + " " + promotion.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = promotion.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = promotion.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridZone"].Value = promotion.Employee.Zone.Description;                  
                    grid.Rows[ctr].Cells["gridDepartment"].Value = promotion.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = promotion.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridPromotionType"].Value = promotion.PromotionType.Description;
                    grid.Rows[ctr].Cells["gridApproved"].Value = promotion.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = promotion.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = promotion.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = promotion.ApprovedTime;
                    grid.Rows[ctr].Cells["gridPromotionDate"].Value = promotion.PromotionDate;
                    grid.Rows[ctr].Cells["gridNotionalDate"].Value = promotion.NotionalDate;
                    grid.Rows[ctr].Cells["gridSubstantiveDate"].Value = promotion.SubstantiveDate;
                    grid.Rows[ctr].Cells["gridNewSalary"].Value = promotion.NewSalary;
                    grid.Rows[ctr].Cells["gridNewGradeCategory"].Value = promotion.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridNewGrade"].Value = promotion.Grade.Grade;
                    grid.Rows[ctr].Cells["gridReason"].Value = promotion.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = promotion.User.ID;
                    grid.Rows[ctr].Cells["gridBand"].Value = promotion.Band.Description;
                    grid.Rows[ctr].Cells["gridStep"].Value = promotion.Step.Description;
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
                if (datePickerPromotionDate.Checked == true && datePickerPromotionDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.PromotionDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerPromotionDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtStaffID.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.StaffID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtStaffID.Text,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboPromotionType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.PromotionType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboPromotionType.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if(cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGradeCategory.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGrade.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboApproved.Text.Trim() != string.Empty && cboApproved.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.Approved",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = approved,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.Archived",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.None
                });
                promotions = dal.GetByCriteria<Promotion>(query);
                PopulateView(promotions);
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
                promotion = new Promotion();
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                datePickerPromotionDate.ResetText();
                datePickerPromotionDate.Checked = false;
                cboApproved.Items.Clear();
                cboApproved.Text = string.Empty;
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
                if (txtStaffID.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (txtStaffID.Text.Length >= company.MinimumCharacter)
                    {
                        foundPromotions.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "PromotionView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        promotions = dal.GetByCriteria<Promotion>(query);
                        if (promotions.Count > 0)
                        {
                            foreach (Promotion promotion in promotions)
                            {
                                if (promotion.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundPromotions.Add(promotion);
                                }
                            }
                            PopulateView(foundPromotions);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + txtStaffID.Text + " is not in the Promotion List");
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

        private void cboApproved_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboApproved.Items.Clear();
                cboApproved.Items.Add("All");
                cboApproved.Items.Add("Yes");
                cboApproved.Items.Add("No");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboApproved_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if(cboApproved.Text.ToLower().Trim() == "yes")
                {
                    approved=true;
                }
                else if(cboApproved.Text.ToLower().Trim() == "no")
                {
                    approved=false;
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

        private void cboNewGradeCategory_DropDown(object sender, EventArgs e)
        {
            //try
            //{
            //    cboNewGradeCategory.Items.Clear();
            //    gradeCategories = dal.GetAll<GradeCategory>();
            //    foreach (GradeCategory category in gradeCategories)
            //    {
            //        cboNewGradeCategory.Items.Add(category.Description);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex);
            //}
        }

        private void cboNewGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //Query query = new Query();
                //cboNewGrade.Items.Clear();
                //cboNewGrade.Text = string.Empty;
                //query.Criteria.Add(new Criterion()
                //{
                //    Property = "EmployeeGradeView.GradeCategory",
                //    CriterionOperator = CriterionOperator.EqualTo,
                //    Value = cboNewGradeCategory.SelectedItem,
                //    CriteriaOperator = CriteriaOperator.And
                //});
                //employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                //foreach (EmployeeGrade employeeGrade in employeeGrades)
                //{
                //    cboNewGrade.Items.Add(employeeGrade.Grade);
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboPromotionType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboPromotionType.Items.Clear();
                promotionTypes = dal.GetAll<PromotionType>();
                foreach (PromotionType promotionType in promotionTypes)
                {
                    if (promotionType.Description != "DEMOTION")
                    {
                        cboPromotionType.Items.Add(promotionType.Description);
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
