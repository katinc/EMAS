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

namespace eMAS.Forms.ClaimsLeaveHirePurchase
{
    public partial class MedicalClaimsView : Form
    {
        private IDAL dal;
        private IList<MedicalClaims> medicalClaims;
        private IList<MedicalClaims> foundMedicalClaims;
        private MedicalClaims medicalClaim;
        private MedicalClaimsNew medicalClaimsNew;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private Company company;
        private int ctr;
        private bool found;

        public MedicalClaimsView(IDAL dal,MedicalClaimsNew medicalClaimsNew)
        {
            try
            {
                InitializeComponent();
                this.medicalClaimsNew = medicalClaimsNew;
                this.dal = dal;
                this.medicalClaim = new MedicalClaims();
                this.medicalClaims = new List<MedicalClaims>();
                this.foundMedicalClaims = new List<MedicalClaims>();
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

        public MedicalClaimsView()
        {
            try
            {
                InitializeComponent();
                this.medicalClaimsNew = new MedicalClaimsNew();
                this.dal = new DAL();
                this.medicalClaim = new MedicalClaims();
                this.medicalClaims = new List<MedicalClaims>();
                this.foundMedicalClaims = new List<MedicalClaims>();
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

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (grid.CurrentRow != null && medicalClaimsNew.CanEdit)
                {
                    MedicalClaims medicalClaim = new MedicalClaims();
                    medicalClaim.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    medicalClaim.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    medicalClaim.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    medicalClaim.Employee.FirstName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                    medicalClaim.Employee.Gender = grid.CurrentRow.Cells["gridGender"].Value.ToString();
                    if (grid.CurrentRow.Cells["gridDOB"].Value == null)
                    {
                        medicalClaim.Employee.DOB = null;
                    }
                    else
                    {
                        medicalClaim.Employee.DOB = DateTime.Parse(grid.CurrentRow.Cells["gridDOB"].Value.ToString());
                    }
                    
                    medicalClaim.Employee.Age = grid.CurrentRow.Cells["gridAge"].Value.ToString();
                    medicalClaim.Employee.NHISNumber = grid.CurrentRow.Cells["gridNHIANumber"].Value.ToString();
                    medicalClaim.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                    medicalClaim.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();

                    medicalClaim.Relationship.Description = grid.CurrentRow.Cells["gridRelationship"].Value.ToString();
                    medicalClaim.PatientName = grid.CurrentRow.Cells["gridPatientName"].Value.ToString();
                    if(grid.CurrentRow.Cells["gridPatientDOB"].Value == null)
                    {
                        medicalClaim.PatientDOB = null;
                    }
                    else 
                    {
                        medicalClaim.PatientDOB = DateTime.Parse(grid.CurrentRow.Cells["gridPatientDOB"].Value.ToString());
                    }
                    medicalClaim.OPDNumber = grid.CurrentRow.Cells["gridOPDNumber"].Value.ToString();
                    medicalClaim.Diagnosis = grid.CurrentRow.Cells["gridDiagnosis"].Value.ToString();
                    medicalClaim.DoctorName = grid.CurrentRow.Cells["gridDoctorName"].Value.ToString();
                    if (grid.CurrentRow.Cells["gridDoctorDate"].Value == null)
                    {
                        medicalClaim.DoctorDate = null;
                    }
                    else
                    {
                        medicalClaim.DoctorDate = DateTime.Parse(grid.CurrentRow.Cells["gridDoctorDate"].Value.ToString());
                    }
                    medicalClaim.DoctorSign = bool.Parse(grid.CurrentRow.Cells["gridDoctorSign"].Value.ToString());

                    medicalClaim.ServiceCost = decimal.Parse(grid.CurrentRow.Cells["gridServiceCost"].Value.ToString());
                    medicalClaim.MedicineCost = decimal.Parse(grid.CurrentRow.Cells["gridMedicineCost"].Value.ToString());
                    medicalClaim.TotalCost = decimal.Parse(grid.CurrentRow.Cells["gridTotalCost"].Value.ToString());
                    medicalClaim.HealthFacilityName = grid.CurrentRow.Cells["gridHealthFacilityName"].Value.ToString();
                    medicalClaim.HealthFacilityType.Description = grid.CurrentRow.Cells["gridHealthFacilityType"].Value.ToString();
                    medicalClaim.SupervisorName = grid.CurrentRow.Cells["gridSupervisorName"].Value.ToString();
                    medicalClaim.SupervisorSign = bool.Parse(grid.CurrentRow.Cells["gridSupervisorSign"].Value.ToString());
                    if (grid.CurrentRow.Cells["gridEntryDate"].Value == null)
                    {
                        medicalClaim.EntryDate = null;
                    }
                    else
                    {
                        medicalClaim.EntryDate = DateTime.Parse(grid.CurrentRow.Cells["gridEntryDate"].Value.ToString());
                    }
                    if (grid.CurrentRow.Cells["gridPaymentDate"].Value == null)
                    {
                        medicalClaim.PaymentDate = null;
                    }
                    else
                    {
                        medicalClaim.PaymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridPaymentDate"].Value.ToString());
                    }
                    medicalClaim.ReceiptNo = grid.CurrentRow.Cells["gridReceiptNo"].Value.ToString();
                    medicalClaim.OnPayRoll = bool.Parse(grid.CurrentRow.Cells["gridActive"].Value.ToString());
                    medicalClaim.Paid = bool.Parse(grid.CurrentRow.Cells["gridPaid"].Value.ToString());
                    medicalClaimsNew.MedicalClaim = medicalClaim;
                    medicalClaimsNew.Show();
                    this.Close();
                }
                else if(!medicalClaimsNew.CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<MedicalClaims> medicalClaims)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (MedicalClaims claim in medicalClaims)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = claim.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = claim.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = claim.Employee.ID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = claim.Employee.Surname + " " + claim.Employee.FirstName + " " + claim.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGender"].Value = claim.Employee.Gender;
                    grid.Rows[ctr].Cells["gridDOB"].Value = claim.Employee.DOB;
                    grid.Rows[ctr].Cells["gridAge"].Value = claim.Employee.Age;
                    grid.Rows[ctr].Cells["gridNHIANumber"].Value = claim.Employee.NHISNumber;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = claim.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = claim.Employee.Unit.Description;

                    grid.Rows[ctr].Cells["gridRelationship"].Value = claim.Relationship.Description;
                    grid.Rows[ctr].Cells["gridPatientName"].Value = claim.PatientName;
                    grid.Rows[ctr].Cells["gridPatientDOB"].Value = claim.PatientDOB;
                    grid.Rows[ctr].Cells["gridOPDNumber"].Value = claim.OPDNumber;
                    grid.Rows[ctr].Cells["gridDiagnosis"].Value = claim.Diagnosis;
                    grid.Rows[ctr].Cells["gridDoctorName"].Value = claim.DoctorName;
                    grid.Rows[ctr].Cells["gridDoctorDate"].Value = claim.DoctorDate;
                    grid.Rows[ctr].Cells["gridDoctorSign"].Value = claim.DoctorSign;

                    grid.Rows[ctr].Cells["gridSupervisorName"].Value = claim.SupervisorName;
                    grid.Rows[ctr].Cells["gridSupervisorSign"].Value = claim.SupervisorSign;
                    grid.Rows[ctr].Cells["gridHealthFacilityType"].Value = claim.HealthFacilityType.Description;
                    grid.Rows[ctr].Cells["gridHealthFacilityName"].Value = claim.HealthFacilityName;
                    grid.Rows[ctr].Cells["gridServiceCost"].Value = claim.ServiceCost;
                    grid.Rows[ctr].Cells["gridMedicineCost"].Value = claim.MedicineCost;
                    grid.Rows[ctr].Cells["gridTotalCost"].Value = claim.TotalCost;
                    grid.Rows[ctr].Cells["gridPaymentDate"].Value = claim.PaymentDate;
                    grid.Rows[ctr].Cells["gridEntryDate"].Value = claim.EntryDate;
                    grid.Rows[ctr].Cells["gridReceiptNo"].Value = claim.ReceiptNo;
                    grid.Rows[ctr].Cells["gridPaid"].Value = claim.Paid;
                    grid.Rows[ctr].Cells["gridApproved"].Value = claim.Approved;
                    grid.Rows[ctr].Cells["gridRejected"].Value = claim.Rejected;
                    grid.Rows[ctr].Cells["gridActive"].Value = claim.OnPayRoll;
                    grid.Rows[ctr].Cells["gridUserID"].Value = claim.User.ID;
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
                        Property = "MedicalClaimView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Firstname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (paymentDatePicker.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.PaymentDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = paymentDatePicker.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Archived",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = false,
                        CriteriaOperator = CriteriaOperator.None
                    });
                medicalClaims = dal.GetByCriteria<MedicalClaims>(query);
                PopulateView(medicalClaims);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void MedicalClaimsView_Load(object sender, EventArgs e)
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
                                medicalClaim.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                medicalClaim.Archived = true;
                                //dal.Delete(medicalClaim);
                                GlobalData.ProcessDelete(this.Name, medicalClaim.ID);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);

                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                medicalClaim.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                medicalClaim.Archived = true;
                                //dal.Delete(medicalClaim);
                                GlobalData.ProcessDelete(this.Name, medicalClaim.ID);
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

        public void Clear()
        {
            try
            {
                cboDepartment.Items.Clear() ;
                cboUnit.Items.Clear();
                cboGradeCategory.Items.Clear();
                cboGrade.Items.Clear();
                txtFirstName.Clear();
                txtStaffID.Clear();
                txtSurname.Clear();
                paymentDatePicker.Checked = false;
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
                        foundMedicalClaims.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "MedicalClaimView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        medicalClaims = dal.GetByCriteria<MedicalClaims>(query);
                        if (medicalClaims.Count > 0)
                        {
                            foreach (MedicalClaims claim in this.medicalClaims)
                            {
                                if (claim.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundMedicalClaims.Add(claim);
                                }
                            }
                            PopulateView(foundMedicalClaims);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + txtStaffID.Text + " has not Submitted any Claim");
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

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
