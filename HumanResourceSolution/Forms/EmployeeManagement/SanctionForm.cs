using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eMAS.All_UIs.Staff_Information_FORMS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using eMAS.Forms.Employment;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Validation;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class SanctionForm : Form
    {
        private IList<Employee> employees;
        private IList<SanctionType> sanctionTypes;
        private Employee employee;
        private Sanction sanction;
        private Company company;
        private DAL dal;
        private int sanctionID;
        private int staffCode;
        private bool editMode;
        private int ctr;

        public SanctionForm()
        {
            try
            {
                InitializeComponent();
                this.sanction = new Sanction();
                this.employee = new Employee();
                this.company = new Company();
                this.dal = new DAL();
                this.employees = new List<Employee>();
                this.sanctionTypes = new List<SanctionType>();               
                this.sanctionID = 0;
                this.staffCode = 0;
                this.ctr = 0;
                this.editMode = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboSanctionType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboSanctionType.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "SanctionTypeView.Reinstatement",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                sanctionTypes = dal.GetByCriteria<SanctionType>(query);
                foreach (SanctionType sanctionType in sanctionTypes)
                {
                    cboSanctionType.Items.Add(sanctionType.Description);
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

        private void SanctionForm_Load(object sender, EventArgs e)
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
                sanctionID = 0;
                staffErrorProvider.Clear();
                datePickerEffectiveDate.ResetText();
                cboSanctionType.Items.Clear();
                cboSanctionType.Text = string.Empty;
                reasonTextBox.Text = string.Empty;
                ClearStaff();
                searchGrid.Visible = false;
                editMode = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ClearStaff()
        {
            try
            {
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                gendertxt.Clear();
                agetxt.Clear();
                departmentTextBox.Clear();
                unitTextBox.Clear();
                gradeCategoryTextBox.Clear();
                gradeTextBox.Clear();
                specialtyTextBox.Clear();
                txtSanctionDate.Clear();
                txtSanctionType.Clear();
                pictureBox.Image = null;
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
                            if (employee.Photo != null)
                            {
                                pictureBox.Image = employee.Photo;
                            }
                            else
                            {
                                pictureBox.Image = pictureBox.InitialImage;
                            }
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            datePickerEffectiveDate.Select();
                            departmentTextBox.Text = employee.Department.Description;
                            unitTextBox.Text = employee.Unit.Description;
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                            gradeTextBox.Text = employee.Grade.Grade;
                            specialtyTextBox.Text = employee.Specialty.Description;
                            //cboSanctionType_DropDown(this,EventArgs.Empty);
                            txtSanctionType.Text = employee.SanctionType.Description;
                            txtSanctionDate.Text = employee.CurrentSanctionDate.Value.Date.ToString("dd/MM/yyyy");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

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
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
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
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 22);
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Sanctioned");
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

        public void EditSanction(DataGridViewRow row)
        {
            try
            {
                Clear();
                editMode = true;
                employee.StaffID = row.Cells["gridStaffID"].Value.ToString().Trim();
                employee = dal.LazyLoadByStaffID<Employee>(employee);
                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                nametxt.Text = name;
                staffIDtxt.Text = employee.StaffID;
                staffCode = employee.ID;
                gendertxt.Text = employee.Gender;
                if (employee.Photo != null)
                {
                    pictureBox.Image = employee.Photo;
                }
                else
                {
                    pictureBox.Image = pictureBox.InitialImage;
                }
                agetxt.Text = employee.Age;
                searchGrid.Visible = false;
                groupBox1.Enabled = true;
                datePickerEffectiveDate.Select();
                departmentTextBox.Text = employee.Department.Description;
                unitTextBox.Text = employee.Unit.Description;
                gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                gradeTextBox.Text = employee.Grade.Grade;
                specialtyTextBox.Text = employee.Specialty.Description;
                txtSanctionType.Text = employee.SanctionType.Description;
                txtSanctionDate.Text = employee.CurrentSanctionDate.ToString();
                sanctionID = int.Parse(row.Cells["gridID"].Value.ToString());
                cboSanctionType_DropDown(this,EventArgs.Empty);
                cboSanctionType.Text = row.Cells["gridSanctionType"].Value.ToString();
                datePickerEffectiveDate.Text = row.Cells["gridSanctionDate"].Value.ToString();
                reasonTextBox.Text = row.Cells["gridReason"].Value.ToString();
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(row.Cells["gridUserID"].Value.ToString()))
                {
                    savebtn.Enabled = false;
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
                    UpdateSanctionsEntity();
                    if (editMode)
                    {
                        dal.Update(sanction);
                    }
                    else
                    {
                        dal.Save(sanction);
                    }
                    dal.CommitTransaction();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not be Saved successfully,Please See the system Administrator");
            }
        }

        private void UpdateSanctionsEntity()
        {
            try
            {
                sanction.ID = sanctionID;
                sanction.Employee.StaffID = staffIDtxt.Text.Trim();
                sanction.Employee.ID = staffCode;
                sanction.SanctionType.ID=sanctionTypes[cboSanctionType.SelectedIndex].ID;
                sanction.SanctionType.Payment = sanctionTypes[cboSanctionType.SelectedIndex].Payment;
                sanction.SanctionType.Separated = sanctionTypes[cboSanctionType.SelectedIndex].Separated;
                sanction.SanctionDate = datePickerEffectiveDate.Value.Date;
                sanction.Sanctioned = true;
                sanction.User.ID = GlobalData.User.ID;
                sanction.Reason = reasonTextBox.Text;
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
                if (datePickerEffectiveDate.Checked == false || datePickerEffectiveDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerEffectiveDate, "Please select the Sanctioned Date");
                    datePickerEffectiveDate.Focus();
                }
                else if (datePickerEffectiveDate.Checked && !Validator.DateRangeValidator(datePickerEffectiveDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerEffectiveDate, "Please Sanctioned Date cannot be greater than Today");
                    datePickerEffectiveDate.Focus();
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
                SanctionView form = new SanctionView(this);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }

}
