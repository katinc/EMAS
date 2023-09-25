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
using HRBussinessLayer.Validation;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class MedicalClaimsDueForApprovalForm : Form
    {
        private IDAL dal;
        private IList<MedicalClaims> medicalClaims;
        private IList<MedicalClaims> foundMedicalClaims;
        private IList<MedicalClaimsItems> medicalClaimsItems;
        private IList<MedicalClaimsItems> medicalClaimsItemsMedicines;
        private IList<MedicalClaimsItems> medicalClaimsItemsServices;
        private MedicalClaims medicalClaim;
        private MedicalClaimsNew medicalClaimsNew;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private Company company;
        private int ctr;
        private bool approved;
        private bool rejected;
        private int claimID;
        private bool found;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public MedicalClaimsDueForApprovalForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.medicalClaim = new MedicalClaims();
                this.medicalClaims = new List<MedicalClaims>();
                this.foundMedicalClaims = new List<MedicalClaims>();
                this.medicalClaimsItems = new List<MedicalClaimsItems>();
                this.medicalClaimsItemsServices = new List<MedicalClaimsItems>();
                this.medicalClaimsItemsMedicines = new List<MedicalClaimsItems>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
                this.approved = false;
                this.rejected = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grid.Rows[e.RowIndex];
                    claimID = int.Parse(row.Cells["gridID"].Value.ToString());
                    numericUpDownTotalAmount.Text = row.Cells["gridTotalCost"].Value.ToString();

                    //Services/Investigation
                    Query serviceQuery = new Query();
                    if (GlobalData.User.UserCategory.Description == "Basic")
                    {
                        found = true;
                    }
                    if (found == true)
                    {
                        serviceQuery.Criteria.Add(new Criterion()
                        {
                            Property = "MedicalClaimsItemsView.UserID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = GlobalData.User.ID,
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }
                    serviceQuery.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimsItemsView.MedicalClaimID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = claimID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    serviceQuery.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimsItemsView.Type",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = "Services",
                        CriteriaOperator = CriteriaOperator.And
                    });
                    medicalClaimsItemsServices = dal.GetByCriteria<MedicalClaimsItems>(serviceQuery);
                    PopulateServicesView(medicalClaimsItemsServices);

                    //Services/Investigation and Medicines
                    Query medicineQuery = new Query();
                    if (GlobalData.User.UserCategory.Description == "Basic")
                    {
                        found = true;
                    }
                    if (found == true)
                    {
                        medicineQuery.Criteria.Add(new Criterion()
                        {
                            Property = "MedicalClaimsItemsView.UserID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = GlobalData.User.ID,
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }
                    medicineQuery.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimsItemsView.MedicalClaimID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = claimID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    medicineQuery.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimsItemsView.Type",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = "Medicines",
                        CriteriaOperator = CriteriaOperator.And
                    });
                    medicalClaimsItemsMedicines = dal.GetByCriteria<MedicalClaimsItems>(medicineQuery);
                    PopulateMedicinesView(medicalClaimsItemsMedicines);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateServicesView(IList<MedicalClaimsItems> medicalClaimsItemsServices)
        {
            try
            {
                this.ctr = 0;
                gridServices.Rows.Clear();
                foreach (MedicalClaimsItems claimItems in medicalClaimsItemsServices)
                {
                    gridServices.Rows.Add(1);
                    gridServices.Rows[ctr].Cells["gridServiceID"].Value = claimItems.ID;
                    gridServices.Rows[ctr].Cells["gridServiceInvestigation"].Value = claimItems.Description;
                    gridServices.Rows[ctr].Cells["gridServiceAmount"].Value = claimItems.Amount;
                    gridServices.Rows[ctr].Cells["gridServiceSign"].Value = claimItems.Sign;
                    gridServices.Rows[ctr].Cells["gridServiceUserID"].Value = claimItems.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateMedicinesView(IList<MedicalClaimsItems> medicalClaimsItemsMedicines)
        {
            try
            {
                this.ctr = 0;
                gridMedicines.Rows.Clear();
                foreach (MedicalClaimsItems claimItems in medicalClaimsItemsMedicines)
                {
                    gridMedicines.Rows.Add(1);
                    gridMedicines.Rows[ctr].Cells["gridMedicineID"].Value = claimItems.ID;
                    gridMedicines.Rows[ctr].Cells["gridMedicineDrugs"].Value = claimItems.Description;
                    gridMedicines.Rows[ctr].Cells["gridMedicineQuantity"].Value = claimItems.Quantity;
                    gridMedicines.Rows[ctr].Cells["gridMedicineAmount"].Value = claimItems.Amount;
                    gridMedicines.Rows[ctr].Cells["gridMedicineSign"].Value = claimItems.Sign;
                    gridMedicines.Rows[ctr].Cells["gridMedicineUserID"].Value = claimItems.User.ID;

                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void MedicalClaimsDueForApprovalForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnApprove.Enabled = getPermissions.CanAdd;
                    btnReject.Enabled = getPermissions.CanAdd;
                    btnSearch.Enabled = getPermissions.CanView;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
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
                        if (GlobalData.QuestionMessage("Are you sure you want to Cancel Medical Claims of the Staff " + "?") == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                medicalClaim.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                medicalClaim.Archived = true;
                                dal.Delete(medicalClaim);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                medicalClaim.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                medicalClaim.Archived = true;
                                dal.Delete(medicalClaim);
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
                    grid.Rows[ctr].Cells["gridApproved"].Value = claim.Approved;
                    grid.Rows[ctr].Cells["gridApprovedAmount"].Value = claim.ApprovedAmount;
                    grid.Rows[ctr].Cells["gridRejected"].Value = claim.Rejected;
                    grid.Rows[ctr].Cells["gridPaid"].Value = claim.Paid;
                    grid.Rows[ctr].Cells["gridActive"].Value = claim.OnPayRoll;
                    grid.Rows[ctr].Cells["gridUserID"].Value = claim.User.ID;
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
                        Property = "MedicalClaimView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
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
                if (cboApproved.Text.Trim() != string.Empty && cboApproved.Text.Trim() != "All")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Approved",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = approved,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboRejected.Text.Trim() != string.Empty  && cboRejected.Text.Trim() != "All")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "MedicalClaimView.Rejected",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = rejected,
                        CriteriaOperator = CriteriaOperator.None
                    });
                }

              
                medicalClaims = dal.GetByCriteria<MedicalClaims>(query);
                PopulateView(medicalClaims);
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
                medicalClaim = new MedicalClaims();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                paymentDatePicker.ResetText();
                paymentDatePicker.Checked = false;
                datePickerEntryDate.ResetText();
                datePickerDateVetted.ResetText();
                datePickerDateVetted.Checked = false;
                datePickerEntryDate.Checked = false;
                cboApproved.Items.Clear();
                cboApproved.Text = string.Empty;
                cboApproved_DropDown(this, EventArgs.Empty);
                cboApproved.Text = "No";
                approved = false;
                cboRejected.Items.Clear();
                cboRejected.Text = string.Empty;
                cboRejected_DropDown(this, EventArgs.Empty);
                cboRejected.Text = "No";
                rejected = false;
                numericUpDownApprovedAmount.Value = 0;
                numericUpDownTotalAmount.Value = 0;
                txtStaffID.Clear();
                txtFirstName.Clear();
                txtSurname.Clear();
                gridServices.Rows.Clear();
                gridMedicines.Rows.Clear();
                //grid.Rows.Clear();
                errorProvider.Clear();
                btnClearSelection.PerformClick();
                txtReason.Clear();
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

        private bool ValidateFieldsApproval()
        {
            bool resultGrid = false;
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
                        resultGrid = true;
                        result = true;
                        break;
                    }
                    ctr++;
                }
                if (resultGrid == false)
                {
                    MessageBox.Show("Select at least one row");
                    resultGrid = false;
                    result = false;
                }
                if (datePickerDateVetted.Checked == false)
                {
                    result = false;
                    errorProvider.SetError(datePickerDateVetted, "Please select the Date Vetted");
                    datePickerDateVetted.Focus();
                }
                else if (datePickerDateVetted.Checked && !Validator.DateRangeValidator(datePickerDateVetted.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    errorProvider.SetError(datePickerDateVetted, "Please Date Vetted cannot be greater than Today");
                    datePickerDateVetted.Focus();
                }
                else if (numericUpDownApprovedAmount.Value < 0)
                {
                    result = false;
                    errorProvider.SetError(numericUpDownApprovedAmount, "Please Approved Amount cannot be Zero");
                    numericUpDownApprovedAmount.Focus();
                }
                else if (numericUpDownApprovedAmount.Value > numericUpDownTotalAmount.Value)
                {
                    result = false;
                    errorProvider.SetError(numericUpDownApprovedAmount, "Please Approved Amount cannot be greater than requested Ampunt");
                    numericUpDownApprovedAmount.Focus();
                }
                else if (radioButtonPaid.Checked && cboPaymentType.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboPaymentType, "Please Payment Type Cannot be Empty");
                    cboPaymentType.Focus();
                }
                else if (radioButtonPaid.Checked && cboPaymentType.Text.ToLower().Trim() == "cheque" && txtChequeNumber.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtChequeNumber, "Please ChequeNumber Cannot be Empty");
                    txtChequeNumber.Focus();
                }
                else if (radioButtonPaid.Checked && payMonth.Checked == false)
                {
                    result = false;
                    errorProvider.SetError(cboPaymentType, "Please Payment Date Cannot be Empty");
                    cboPaymentType.Focus();
                }
                else if (radioButtonPaid.Checked && payMonth.Checked && !Validator.DateRangeValidator(payMonth.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    errorProvider.SetError(payMonth, "Please Payment Date cannot be greater than Today");
                    payMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFieldsApproval())
                {
                    dal.BeginTransaction();
                    ctr = 0;
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (grid.Rows[ctr].Cells["gridID"].Value != null && grid.Rows[ctr].Cells["gridSelect"].Value != null)
                        {
                            medicalClaim = dal.GetByID<MedicalClaims>(int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString()));
                            if (medicalClaim.ID != 0 && medicalClaim.Rejected == false && medicalClaim.Approved == false)
                            {
                                //Approve Medical Claims
                                medicalClaim.ApprovedAmount = numericUpDownApprovedAmount.Value;
                                medicalClaim.OnPayRoll = radioButtonPayRoll.Checked;
                                medicalClaim.PaidToStaff = radioButtonPaid.Checked;
                                medicalClaim.PaidToStaffDate = payMonth.Value;
                                medicalClaim.PaymentType = cboPaymentType.Text.Trim();
                                medicalClaim.ChequeNumber = txtChequeNumber.Text.Trim();
                                medicalClaim.Approved = true;
                                medicalClaim.ApprovedDate = DateTime.Parse(datePickerDateVetted.Value.Year + "/" + datePickerDateVetted.Value.Month + "/" + "1");
                                medicalClaim.ApprovedTime = datePickerDateVetted.Value;
                                medicalClaim.ApprovedUser = GlobalData.User.Name;
                                medicalClaim.ApprovedUserStaffID = GlobalData.User.StaffID;
                                medicalClaim.Reason = txtReason.Text.Trim();
                                dal.Update(medicalClaim);
                            }
                        }
                        ctr++;
                    }
                    dal.CommitTransaction();
                    Clear();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Could Not Save Successfully");
            }
        }

        private bool ValidateFieldsReject()
        {
            bool resultGrid = false;
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
                        resultGrid = true;
                        result = true;
                        break;
                    }
                    ctr++;
                }
                if (resultGrid == false)
                {
                    MessageBox.Show("Select at least one row");
                    resultGrid = false;
                    result = false;
                }
                if (datePickerDateVetted.Checked == false || datePickerDateVetted.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(datePickerDateVetted, "Please select the Date Vetted");
                    datePickerDateVetted.Focus();
                }
                else if (datePickerDateVetted.Checked && !Validator.DateRangeValidator(datePickerDateVetted.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    errorProvider.SetError(datePickerDateVetted, "Please Date Vetted cannot be greater than Today");
                    datePickerDateVetted.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFieldsReject())
                {
                    dal.BeginTransaction();
                    ctr = 0;
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (grid.Rows[ctr].Cells["gridID"].Value != null && grid.Rows[ctr].Cells["gridSelect"].Value != null)
                        {
                            medicalClaim = dal.GetByID<MedicalClaims>(int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString()));
                            if (medicalClaim.ID != 0 && medicalClaim.Approved == false && medicalClaim.Rejected == false)
                            {
                                //Update Medical Claims
                                medicalClaim.Rejected = true;
                                medicalClaim.RejectedDate = datePickerDateVetted.Value.Date;
                                medicalClaim.RejectedTime = datePickerDateVetted.Value;
                                medicalClaim.RejectedUser = GlobalData.User.Name;
                                medicalClaim.RejectedUserStaffID = GlobalData.User.StaffID;
                                medicalClaim.Reason = txtReason.Text.Trim();
                                dal.Update(medicalClaim);
                            }
                        }
                        ctr++;
                    }
                    dal.CommitTransaction();
                    Clear();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Could Not Save Successfully");
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid.Rows[ctr].Cells["gridSelect"].Value = true;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            try
            {
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid.Rows[ctr].Cells["gridSelect"].Value = false;
                    ctr++;
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
                if (cboApproved.Text.ToLower().Trim() == "yes")
                {
                    approved = true;
                }
                else if (cboApproved.Text.ToLower().Trim() == "no")
                {
                    approved = false;
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

        private void cboRejected_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboRejected.Items.Clear();
                cboRejected.Items.Add("All");
                cboRejected.Items.Add("Yes");
                cboRejected.Items.Add("No");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboRejected_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboRejected.Text.ToLower().Trim() == "yes")
                {
                    rejected = true;
                }
                else if (cboRejected.Text.ToLower().Trim() == "no")
                {
                    rejected = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void radioButtonPaid_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonPaid.Checked && radioButtonPayRoll.Checked == false)
                {
                    cboPaymentType.Visible = true;
                    payMonth.Visible = true;
                    lblPaymentType.Visible = true;
                    lblPayMonth.Visible = true;
                }
                else
                {
                    cboPaymentType.Visible = false;
                    payMonth.Visible = false;
                    lblPaymentType.Visible = false;
                    lblPayMonth.Visible = false;
                    txtChequeNumber.Visible = false;
                    lblChequeNumber.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboPaymentType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboPaymentType.Text.ToLower().Trim() == "cheque")
                {
                    txtChequeNumber.Visible = true;
                    lblChequeNumber.Visible = true;
                }
                else
                {
                    txtChequeNumber.Visible = false;
                    lblChequeNumber.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboPaymentType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboPaymentType.Items.Clear();
                cboPaymentType.Items.Add("Cash");
                cboPaymentType.Items.Add("Cheque");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
