using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Validation;
using eMAS.Forms.ClaimsLeaveHirePurchase;
using HRDataAccessLayer;


namespace eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS
{
    public partial class MedicalClaimsNew : Form
    {
        private MedicalClaims medicalClaim;
        private MedicalClaimsItems medicalClaimsItem;
        private MedicalClaimsItems medicalClaimsItemMedicine;
        private MedicalClaimsItems medicalClaimsItemService;
        private IList<MedicalClaimsItems> medicalClaimsItems;
        private IList<MedicalClaimsItems> medicalClaimsItemsMedicines;
        private IList<MedicalClaimsItems> medicalClaimsItemsServices;
        private IList<Employee> employees;
        private IList<HealthFacilityType> healthFacilityTypes;
        private IList<Relationship> relationships;
        private Employee employee;
        private Company company;
        private IDAL dal;
        private bool editMode;
        private int claimID;
        private int staffCode;
        private int ctr;
        private string age;
        private string healthFacilityName;

        public MedicalClaimsNew()
        {
            try
            {
                this.InitializeComponent();
                this.medicalClaim = new MedicalClaims();
                this.medicalClaimsItem = new MedicalClaimsItems();
                this.medicalClaimsItemMedicine = new MedicalClaimsItems();
                this.medicalClaimsItemService = new MedicalClaimsItems();
                this.employee = new Employee();
                this.company = new Company();
                this.editMode = false;
                this.staffCode = 0;
                this.claimID = 0;
                this.ctr = 0;
                this.age = string.Empty;
                this.healthFacilityName = string.Empty;
                this.employees = new List<Employee>();
                this.medicalClaimsItems = new List<MedicalClaimsItems>();
                this.medicalClaimsItemsServices = new List<MedicalClaimsItems>();
                this.medicalClaimsItemsMedicines = new List<MedicalClaimsItems>();
                this.healthFacilityTypes = new List<HealthFacilityType>();
                this.relationships = new List<Relationship>();     
                this.dal = new DAL();
                this.dal.OpenConnection();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public MedicalClaims MedicalClaim
        {
            set 
            {
                Clear();
                label9.Text = "Edit Medical Claim";
                editMode = true;
                claimID = value.ID;
                searchGrid.Visible = false;
                groupBox2.Enabled = true;
                //Staff Details
                if (value.Employee.Photo != null)
                {
                    pictureBox.Image = value.Employee.Photo;
                }
                else
                {
                    pictureBox.Image = pictureBox.InitialImage;
                }
                staffIDtxt.Text = value.Employee.StaffID;
                staffCode = value.Employee.ID;
                nametxt.Text = value.Employee.FirstName;
                gendertxt.Text = value.Employee.Gender;
                
                txtDOB.Text = value.Employee.DOB.ToString();
                agetxt.Text = value.Employee.Age;
                txtNHIANumber.Text = value.Employee.NHISNumber;
                txtDepartment.Text = value.Employee.Department.Description;
                txtUnit.Text = value.Employee.Unit.Description;

                //Doctor's Report
                cboRelationship_DropDown(this,EventArgs.Empty);
                cboRelationship.Text = value.Relationship.Description;
                txtNameOfPatient.Text = value.PatientName;
                datePickerPatientDOB.Text = value.PatientDOB.ToString();
                txtPatientAge.Text = value.Age;
                txtOPDNumber.Text = value.OPDNumber;
                txtDiagnosis.Text = value.Diagnosis;
                txtDoctorName.Text = value.DoctorName;
                datePickerDoctorDate.Text = value.DoctorDate.ToString();
                checkBoxDoctorSign.Checked = value.DoctorSign;

                //Claims
                healthFacilityTypecmb_DropDown(this,EventArgs.Empty);
                healthFacilityTypecmb.Text = value.HealthFacilityType.Description;
                serviceFacilitytxt.Text = value.HealthFacilityName;
                payMonth.Text = value.PaymentDate.ToString();
                entryDate.Text = value.EntryDate.ToString();
                paidCheckBox.Checked = value.Paid;
                receiptNoTextBox.Text = value.ReceiptNo;
                txtSupervisorName.Text = value.SupervisorName;
                checkBoxSupervisorSign.Checked = value.SupervisorSign;

                //Services/Investigation
                Query serviceQuery = new Query();
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

                //Summary
                numericUpDownServiceCost.Value = value.ServiceCost;
                numericUpDownMedicineCost.Value = value.MedicineCost;
                numericUpDownTotalAmount.Value = value.TotalCost;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != value.User.ID)
                {
                    savebtn.Enabled = false;
                }
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
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;
                            pictureBox.Image = employee.Photo;
                            agetxt.Text = employee.Age;
                            txtDOB.Text = employee.DOB.ToString();
                            txtDepartment.Text = employee.Department.Description;
                            txtUnit.Text = employee.Unit.Description;
                            txtNHIANumber.Text = employee.NHISNumber;
                            serviceFacilitytxt.Text = healthFacilityName;
                            datePickerPatientDOB.Value = employee.DOB.Value;

                            searchGrid.Visible = false;
                            groupBox2.Enabled = true;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Medical_Claims_Load(object sender, EventArgs e)
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateMedicalClaim())
                {
                    dal.BeginTransaction();
                    UpdateMedicalClaimsEntity();
                    if (editMode)
                    {
                        medicalClaim.ID = claimID;
                        dal.Update(medicalClaim);
                    }
                    else
                    {
                        medicalClaim.User.ID = GlobalData.User.ID;
                        dal.Save(medicalClaim);
                        
                    }
                    medicalClaimsItemService.MedicalClaim.ID = medicalClaim.ID;
                    medicalClaimsItemMedicine.MedicalClaim.ID = medicalClaim.ID;
                    SaveMedicines();
                    SaveServices();
                    dal.CommitTransaction();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
            }
        }

        private bool ValidateServices()
        {
            bool result = true;
            try
            {
                foreach (DataGridViewRow row in gridServices.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridServiceInvestigation"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Investigation cannot be empty" + (row.Index + 1));
                            gridServices.Rows[row.Index + 1].Selected = true;
                        }
                        if (row.Cells["gridServiceAmount"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Service Amount cannot be empty" + (row.Index + 1));
                            gridServices.Rows[row.Index + 1].Selected = true;
                        }
                        else if (!Validator.DecimalValidator(row.Cells["gridServiceAmount"].Value.ToString().Trim()))
                        {
                            result = false;
                            MessageBox.Show("Service Amount must be a decimal" + (row.Index + 1));
                            gridServices.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void SaveServices()
        {
            try
            {
                if (ValidateServices())
                {
                    gridServices.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in gridServices.Rows)
                    {
                        //If data is entered in the grid
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["gridServiceID"].Value == null)
                            {
                                medicalClaimsItemService.Description = row.Cells["gridServiceInvestigation"].Value.ToString();
                                medicalClaimsItemService.Type = "Services";
                                medicalClaimsItemService.Amount = decimal.Parse(row.Cells["gridServiceAmount"].Value.ToString());
                                if (row.Cells["gridServiceSign"].Value == null)
                                {
                                    medicalClaimsItemService.Sign = false;
                                }
                                else
                                {
                                    medicalClaimsItemService.Sign = bool.Parse(row.Cells["gridServiceSign"].Value.ToString());
                                }
                                medicalClaimsItemService.User.ID = GlobalData.User.ID;
                                dal.Save(medicalClaimsItemService);
                            }
                            else
                            {
                                medicalClaimsItemService.ID = int.Parse(row.Cells["gridServiceID"].Value.ToString());
                                medicalClaimsItemService.Description = row.Cells["gridServiceInvestigation"].Value.ToString();
                                medicalClaimsItemService.Type = "Services";
                                medicalClaimsItemService.Amount = decimal.Parse(row.Cells["gridServiceAmount"].Value.ToString());
                                if (row.Cells["gridServiceSign"].Value == null)
                                {
                                    medicalClaimsItemService.Sign = false;
                                }
                                else
                                {
                                    medicalClaimsItemService.Sign = bool.Parse(row.Cells["gridServiceSign"].Value.ToString());
                                }
                                medicalClaimsItemService.User.ID = GlobalData.User.ID;
                                dal.Update(medicalClaimsItemService);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateMedicines()
        {
            bool result = true;
            try
            {
                foreach (DataGridViewRow row in gridMedicines.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridMedicineDrugs"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Drugs cannot be empty" + (row.Index + 1));
                            gridMedicines.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridMedicineQuantity"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Drug Quantity cannot be empty" + (row.Index + 1));
                            gridMedicines.Rows[row.Index + 1].Selected = true;
                        }
                        else if (!Validator.DecimalValidator(row.Cells["gridMedicineQuantity"].Value.ToString().Trim()))
                        {
                            result = false;
                            MessageBox.Show("Drug Quantity must be a decimal" + (row.Index + 1));
                            gridMedicines.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridMedicineAmount"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Drug Amount cannot be empty" + (row.Index + 1));
                            gridMedicines.Rows[row.Index + 1].Selected = true;
                        }
                        else if (!Validator.DecimalValidator(row.Cells["gridMedicineAmount"].Value.ToString().Trim()))
                        {
                            result = false;
                            MessageBox.Show("Drug Amount must be a decimal" + (row.Index + 1));
                            gridMedicines.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void SaveMedicines()
        {
            try
            {
                if (ValidateMedicines())
                {
                    gridMedicines.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in gridMedicines.Rows)
                    {
                        //If data is entered in the grid
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["gridMedicineID"].Value == null)
                            {
                                medicalClaimsItemMedicine.Description = row.Cells["gridMedicineDrugs"].Value.ToString();
                                medicalClaimsItemMedicine.Type = "Medicines";
                                medicalClaimsItemMedicine.Quantity = int.Parse(row.Cells["gridMedicineQuantity"].Value.ToString());
                                medicalClaimsItemMedicine.Amount = decimal.Parse(row.Cells["gridMedicineAmount"].Value.ToString());
                                if (row.Cells["gridMedicineSign"].Value == null)
                                {
                                    medicalClaimsItemMedicine.Sign = false;
                                }
                                else
                                {
                                    medicalClaimsItemMedicine.Sign = bool.Parse(row.Cells["gridMedicineSign"].Value.ToString());
                                }
                                medicalClaimsItemMedicine.User.ID = GlobalData.User.ID;
                                dal.Save(medicalClaimsItemMedicine);
                            }
                            else
                            {
                                medicalClaimsItemMedicine.ID = int.Parse(row.Cells["gridMedicineID"].Value.ToString());
                                medicalClaimsItemMedicine.Description = row.Cells["gridMedicineDrugs"].Value.ToString();
                                medicalClaimsItemMedicine.Type = "Medicines";
                                medicalClaimsItemMedicine.Quantity = int.Parse(row.Cells["gridMedicineQuantity"].Value.ToString());
                                medicalClaimsItemMedicine.Amount = decimal.Parse(row.Cells["gridMedicineAmount"].Value.ToString());
                                if (row.Cells["gridMedicineSign"].Value == null)
                                {
                                    medicalClaimsItemMedicine.Sign = false;
                                }
                                else
                                {
                                    medicalClaimsItemMedicine.Sign = bool.Parse(row.Cells["gridMedicineSign"].Value.ToString());
                                }
                                medicalClaimsItemMedicine.User.ID = GlobalData.User.ID;
                                dal.Update(medicalClaimsItemMedicine);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateMedicalClaim()
        {
            
            bool result = true;
            try
            {
                ClearErrors();
                if (staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter the StaffID");
                    staffIDtxt.Focus();
                }
                if (txtNHIANumber.Text.Trim() == string.Empty || txtNHIANumber.Text.Trim() == "0")
                {
                    result = false;
                    staffErrorProvider.SetError(txtNHIANumber, "Please Employee must have NHIS Number");
                    txtNHIANumber.Focus();
                }
                if (cboRelationship.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboRelationship, "Please Select the Relationship");
                    cboRelationship.Focus();
                }
                if (txtNameOfPatient.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtNameOfPatient, "Please Enter the Name of the Patient");
                    txtNameOfPatient.Focus();
                }
                if (datePickerPatientDOB.Checked == false || datePickerPatientDOB.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerPatientDOB, "Please select the Patient Date of Birth");
                    datePickerPatientDOB.Focus();
                }
                else if (datePickerPatientDOB.Checked && !Validator.DateRangeValidator(datePickerPatientDOB.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerPatientDOB, "Please Date of Birth cannot be greater than Today");
                    datePickerPatientDOB.Focus();
                }
                if (txtOPDNumber.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtOPDNumber, "Please Enter the OPD/Folder Number of the Patient");
                    txtOPDNumber.Focus();
                }
                if (txtDiagnosis.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtDiagnosis, "Please Enter the Diagnosis of the Patient");
                    txtDiagnosis.Focus();
                }
                if (healthFacilityTypecmb.Text.Trim() == string.Empty)
                {
                    result = false;
                    facilityErrorProvider.SetError(healthFacilityTypecmb, "Please Select Health Facility Type");
                    healthFacilityTypecmb.Focus();
                }
                if (serviceFacilitytxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    nameErrorProvider.SetError(serviceFacilitytxt, "Enter Health Facility Name");
                    serviceFacilitytxt.Focus();
                }
                if (payMonth.Value.ToString() == string.Empty)
                {
                    result = false;
                    paymentDateErrorProvider.SetError(payMonth, "Select Payment Date");
                    payMonth.Focus();
                }
                
                if (entryDate.Value.ToString() == string.Empty)
                {
                    result = false;
                    entryDateErrorProvider.SetError(entryDate, "Enter Entry Date");
                    entryDate.Focus();
                }
                if (paidCheckBox.Checked==true && receiptNoTextBox.Text.Trim().ToString() == string.Empty)
                {
                    result = false;
                    receiptNumberErrorProvider.SetError(receiptNoTextBox, "Enter Receipt Number");
                    paidCheckBox.Focus();
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                MedicalClaimsView viewForm = new MedicalClaimsView(dal, this);
                viewForm.MdiParent = this.MdiParent;
                viewForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
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

        #region ASSINGNMENTS
        private void UpdateMedicalClaimsEntity()
        {
            try
            {
                Validator.Errors.Clear();
                medicalClaim.ID = claimID;
                medicalClaim.Employee.StaffID = staffIDtxt.Text.Trim();
                medicalClaim.Employee.ID = staffCode;
                medicalClaim.PatientName = txtNameOfPatient.Text.Trim();
                medicalClaim.Relationship.ID = relationships[cboRelationship.SelectedIndex].ID;
                medicalClaim.OPDNumber = txtOPDNumber.Text.Trim();
                medicalClaim.Diagnosis = txtDiagnosis.Text.Trim();
                medicalClaim.DoctorName = txtDoctorName.Text.Trim();
                medicalClaim.DoctorSign = checkBoxDoctorSign.Checked;
                medicalClaim.SupervisorName = txtSupervisorName.Text.Trim();
                medicalClaim.SupervisorSign = checkBoxSupervisorSign.Checked;
                medicalClaim.DoctorDate = datePickerDoctorDate.Value.Date;
                if (healthFacilityTypecmb.Text.Trim() == string.Empty)
                {
                    medicalClaim.HealthFacilityType.ID = 0;
                }
                else
                {
                    medicalClaim.HealthFacilityType.ID = healthFacilityTypes[healthFacilityTypecmb.SelectedIndex].ID;
                    medicalClaim.HealthFacilityType.Description = healthFacilityTypes[healthFacilityTypecmb.SelectedIndex].Description;
                }
                
                medicalClaim.HealthFacilityName = serviceFacilitytxt.Text.Trim();
                medicalClaim.ServiceCost = numericUpDownServiceCost.Value;
                medicalClaim.MedicineCost = numericUpDownMedicineCost.Value;
                numericUpDownTotalAmount.Value = numericUpDownServiceCost.Value + numericUpDownMedicineCost.Value; 
                medicalClaim.TotalCost = numericUpDownTotalAmount.Value;
                medicalClaim.PaymentDate = payMonth.Value;
                medicalClaim.EntryDate = entryDate.Value;
                medicalClaim.Paid = paidCheckBox.Checked;
                medicalClaim.ReceiptNo = receiptNoTextBox.Text.Trim();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region CLEARERRORS
        private void ClearErrors()
        {
            try
            {
                //Errors
                staffErrorProvider.Clear();
                facilityErrorProvider.Clear();
                nameErrorProvider.Clear();
                descriptionErrorProvider.Clear();
                serviceDateErrorProvider.Clear();
                paymentDateErrorProvider.Clear();
                entryDateErrorProvider.Clear();
                costErrorProvider.Clear();
                receiptNumberErrorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            try
            {
                label9.Text = "New Medical Claim";
                claimID = 0;
                
                ClearStaff();
                ClearErrors();

                //Doctor's Report
                cboRelationship.Items.Clear();
                cboRelationship.Text = string.Empty;
                txtNameOfPatient.Clear();
                datePickerPatientDOB.ResetText();
                datePickerPatientDOB.Checked = false;
                txtPatientAge.Clear();
                txtOPDNumber.Clear();
                txtDiagnosis.Clear();
                txtDoctorName.Clear();
                datePickerDoctorDate.ResetText();
                checkBoxDoctorSign.Checked = false;

                //Claims
                healthFacilityTypecmb.Items.Clear();
                healthFacilityTypecmb.Text = string.Empty;
                serviceFacilitytxt.Clear();
                payMonth.Value = DateTime.Now;
                entryDate.Value = DateTime.Now;
                paidCheckBox.Checked = false;
                receiptNoTextBox.Clear();
                txtSupervisorName.Clear();
                checkBoxSupervisorSign.Checked = false;

                //Summary
                numericUpDownMedicineCost.ResetText();
                numericUpDownServiceCost.ResetText();
                numericUpDownTotalAmount.ResetText();  

                //Services/Investigation
                gridServices.Rows.Clear();

                //Medicines
                gridMedicines.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region CLEARSTAFF
        private void ClearStaff()
        {
            try
            {
                staffIDtxt.Clear();
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                txtNHIANumber.Clear();
                txtDepartment.Clear();
                txtUnit.Clear();
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
                editMode = false;
                groupBox2.Enabled = false;
                staffIDtxt.Select();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion


        #region Staff Operations
        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    employees=dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                            ctr++;
                        }
                    }
                    if (found)
                    {
                        if (searchGrid.RowCount == 2)
                        {
                            searchGrid.Height = searchGrid.RowCount * 24;
                        }
                        else
                        {
                            searchGrid.Height = searchGrid.RowCount * 23;
                        }
                        searchGrid.Location = new Point(178, 39);
                        searchGrid.BringToFront();
                        searchGrid.Visible = true;
                    }
                    else
                    {
                        searchGrid.Visible = false;
                    }
                }
                else
                {
                    Clear();
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
                        healthFacilityName = company.Name;
                    }

                    if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
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
                        if (employees.Count > 0)
                        {
                            foreach (Employee employee in employees)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                                    ctr++;
                                }
                            }
                            if (found)
                            {
                                if (searchGrid.RowCount == 2)
                                {
                                    searchGrid.Height = searchGrid.RowCount * 24;
                                }
                                else
                                {
                                    searchGrid.Height = searchGrid.RowCount * 23;
                                }
                                searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 21);
                                searchGrid.BringToFront();
                                searchGrid.Visible = true;
                            }
                            else
                            {
                                searchGrid.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        } 
        #endregion

        private void healthFacilityTypecmb_DropDown(object sender, EventArgs e)
        {
            try
            {
                healthFacilityTypes = dal.GetAll<HealthFacilityType>();
                healthFacilityTypecmb.Items.Clear();
                healthFacilityTypecmb.Text = string.Empty;
                foreach (HealthFacilityType healthFacilityType in healthFacilityTypes)
                {
                    healthFacilityTypecmb.Items.Add(healthFacilityType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridServices_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                gridServices.CurrentCellDirtyStateChanged += new EventHandler(gridServices_CurrentCellDirtyStateChanged);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridServices_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                decimal result = 0;
                foreach (DataGridViewRow row in gridServices.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridServiceAmount"].Value != null)
                        {
                            decimal temp = 0;
                            if (decimal.TryParse(row.Cells["gridServiceAmount"].Value.ToString().Trim(), out temp))
                            {
                                result += decimal.Parse(row.Cells["gridServiceAmount"].Value.ToString().Trim());
                            }
                            else
                            {
                                row.Cells["gridServiceAmount"].Value = 0;
                            }
                        }
                    }
                }
                numericUpDownServiceCost.Value = result;
                numericUpDownTotalAmount.Value = numericUpDownServiceCost.Value + numericUpDownMedicineCost.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    employee.StaffID = staffIDtxt.Text.Trim();
                    employee = dal.ShowImageByStaffID<Employee>(employee);
                    if (employee.ID != 0)
                    {
                        if (employee.Photo != null)
                        {
                            pictureBox.Image = employee.Photo;
                        }
                        else
                        {
                            MessageBox.Show("Image is not uploaded for the Staff");
                        }
                    }
                    else
                    {
                        MessageBox.Show("StaffID Not Found");
                    }

                }
                else
                {
                    MessageBox.Show("StaffID is Empty,Please Enter the StaffID");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridMedicines_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                decimal result = 0;
                foreach (DataGridViewRow row in gridMedicines.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridMedicineAmount"].Value != null)
                        {
                            decimal temp = 0;
                            if (decimal.TryParse(row.Cells["gridMedicineAmount"].Value.ToString().Trim(), out temp))
                            {
                                result += decimal.Parse(row.Cells["gridMedicineAmount"].Value.ToString().Trim()) * decimal.Parse(row.Cells["gridMedicineQuantity"].Value.ToString().Trim());
                            }
                            else
                            {
                                row.Cells["gridMedicineAmount"].Value = 0;
                            }
                        }
                    }
                }
                numericUpDownMedicineCost.Value = result;
                numericUpDownTotalAmount.Value = numericUpDownServiceCost.Value + numericUpDownMedicineCost.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridMedicines_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                gridMedicines.CurrentCellDirtyStateChanged += new EventHandler(gridMedicines_CurrentCellDirtyStateChanged);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboRelationship_DropDown(object sender, EventArgs e)
        {
            try
            {
                relationships = dal.GetAll<Relationship>();
                cboRelationship.Items.Clear();
                cboRelationship.Text = string.Empty;
                foreach (Relationship relationship in relationships)
                {
                    cboRelationship.Items.Add(relationship.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboRelationship_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                txtNameOfPatient.Clear();
                datePickerPatientDOB.ResetText();
                if (cboRelationship.Text.ToLower().Trim() == "self")
                {
                    txtNameOfPatient.Text = nametxt.Text.Trim();
                    txtNameOfPatient.Enabled = false;
                    datePickerPatientDOB.Value = DateTime.Parse(txtDOB.Text.Trim());
                    datePickerPatientDOB.Enabled = false;
                }
                else
                {
                    txtNameOfPatient.Enabled = true;
                    datePickerPatientDOB.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void datePickerPatientDOB_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                medicalClaim.PatientDOB = datePickerPatientDOB.Value.Date;
                txtPatientAge.Text = medicalClaim.Age;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
