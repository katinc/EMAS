using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using eMAS.Forms.Employment;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class TerminationView : Form
    {
        private IDAL dal;
        private TerminationNew terminationNew;
        private IList<Termination> terminations;
        private IList<Termination> foundTerminations;
        private Termination termination;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<SeparationType> separationTypes;
        private Company company;
        private int ctr;
        private bool found;
        private PDFReader reader;

        public TerminationView(IDAL dal,TerminationNew terminationNew)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.termination = new Termination();
                this.terminationNew = terminationNew;
                this.terminations = new List<Termination>();
                this.foundTerminations = new List<Termination>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.separationTypes = new List<SeparationType>();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
                this.terminationDatePicker.Value = DateTime.Today.Date;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public TerminationView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.termination = new Termination();
                this.terminationNew = new TerminationNew();
                this.terminations = new List<Termination>();
                this.foundTerminations = new List<Termination>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.separationTypes = new List<SeparationType>();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
                this.terminationDatePicker.Value = DateTime.Today.Date;
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
                if (grid.CurrentRow != null && terminationNew.CanEdit)
                {
                    if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == false)
                    {
                        Termination termination = new Termination();
                        termination.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        termination.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                        termination.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                        termination.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                        termination.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                        termination.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategory"].Value.ToString();
                        termination.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGrade"].Value.ToString();
                        termination.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridEmploymentDate"].Value != null)
                        {
                            termination.Employee.EmploymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDate"].Value.ToString());
                        }
                        
                        termination.Employee.SeparationType.Description = grid.CurrentRow.Cells["gridCurrentSeparationType"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridCurrentSeparationDate"].Value != null)
                        {
                            termination.Employee.TerminationDate = DateTime.Parse(grid.CurrentRow.Cells["gridCurrentSeparationDate"].Value.ToString());
                        }
                        

                        termination.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                        termination.EmployeeNoticed = bool.Parse(grid.CurrentRow.Cells["gridEmployeeNotified"].Value.ToString());
                        termination.EmployerNoticed = bool.Parse(grid.CurrentRow.Cells["gridEmployerNotified"].Value.ToString());
                        termination.TerminationDate = DateTime.Parse(grid.CurrentRow.Cells["gridTerminationDate"].Value.ToString());
                        termination.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                        termination.TerminationDate = DateTime.Parse(grid.CurrentRow.Cells["gridTerminationDate"].Value.ToString());
                        termination.Type = grid.CurrentRow.Cells["gridType"].Value.ToString();
                        termination.SeparationType.Description = grid.CurrentRow.Cells["gridSeparationType"].Value.ToString();
                        termination.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                        terminationNew.EditTermination(termination);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("The Staff is already Separated");
                    }
                }
                else if (!terminationNew.CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == false)
                {
                    if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s termination?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                termination.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                termination.Archived = false;
                                //dal.Delete(termination);
                                GlobalData.ProcessDelete(this.Name, termination.ID);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                termination.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                termination.Archived = false;
                                //dal.Delete(termination);
                                GlobalData.ProcessDelete(this.Name, termination.ID);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                        }
                    }
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void TerminationView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch(Exception ex)
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
                grid.Rows.Clear();
                cboType.Items.Clear();
                cboType.Text = string.Empty;
                cboSeparationType.Items.Clear();
                cboSeparationType.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                terminationDatePicker.Value = DateTime.Today.Date;
                staffIDtxt.Clear();
                txtSurname.Clear();
                txtFirstName.Clear();
                errorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateView(IList<Termination> terminations)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (Termination termination in terminations)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = termination.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = termination.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = termination.Employee.ID;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = termination.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = termination.Employee.EmploymentDate;
                    grid.Rows[ctr].Cells["gridCurrentSeparationType"].Value = termination.Employee.SeparationType.Description;
                    grid.Rows[ctr].Cells["gridCurrentSeparationDate"].Value = termination.Employee.TerminationDate;

                    grid.Rows[ctr].Cells["gridStaffName"].Value = termination.StaffName;
                    grid.Rows[ctr].Cells["gridTerminationDate"].Value = termination.TerminationDate;
                    grid.Rows[ctr].Cells["gridType"].Value = termination.Type;
                    grid.Rows[ctr].Cells["gridSeparationType"].Value = termination.SeparationType.Description;
                    grid.Rows[ctr].Cells["gridReason"].Value = termination.Reason;
                    grid.Rows[ctr].Cells["gridEmployeeNotified"].Value = termination.EmployeeNoticed;
                    grid.Rows[ctr].Cells["gridEmployerNotified"].Value = termination.EmployerNoticed;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = termination.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = termination.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = termination.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = termination.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridApproved"].Value = termination.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = termination.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = termination.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = termination.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = termination.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = termination.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = termination.User.ID;

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
                        Property = "TerminationView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Type",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboType.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboSeparationType.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.SeparationType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = separationTypes[cboSeparationType.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (terminationDatePicker.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.TerminationDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = terminationDatePicker.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "TerminationView.Archived",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.None
                });

                terminations = dal.GetByCriteria<Termination>(query);
                PopulateView(terminations);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void cboSeparationType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboSeparationType.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "SeparationTypesView.Reinstatement",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                separationTypes = dal.GetByCriteria<SeparationType>(query);
                foreach (SeparationType separationType in separationTypes)
                {
                    cboSeparationType.Items.Add(separationType.Description);
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
                if (departments.Count <= 0)
                {
                    departments = dal.GetAll<Department>();
                }

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

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                if (gradeCategories.Count <= 0)
                {
                    gradeCategories = dal.GetAll<GradeCategory>();
                }

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

        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                    {
                        foundTerminations.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "TerminationView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        terminations = dal.GetByCriteria<Termination>(query);
                        if (terminations.Count > 0)
                        {
                            foreach (Termination termination in this.terminations)
                            {
                                if (termination.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    foundTerminations.Add(termination);
                                }
                            }
                            PopulateView(foundTerminations);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboType.Items.Clear();
                cboType.Items.Add("Employee Instigated");
                cboType.Items.Add("Employer Instigated");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var staffid = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();

            //    var doc = GlobalData._context.SeparationDocuments.First(u => u.StaffID == staffid);

            //    if (doc == null)
            //    {
            //        MessageBox.Show("No separation letter available for the seleted separation");
            //    }
            //    else
            //    {

            //        if (doc != null)
            //        {
            //            if (reader != null && !reader.IsDisposed)
            //            {
            //                reader.Close();
            //                reader = null;
            //            }

            //            reader = new PDFReader(doc.Path);
            //            reader.Show();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("No separation letter available for the seleted separation");
            //    Logger.LogError(ex);
            //    //throw ex;
            //}
        }
    }
}
