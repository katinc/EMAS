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
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using eMAS.Forms.Employment;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class AnnualReverseCalculateLeaveForm : Form
    {
        private IList<Employee> employees;
        private Employee employee;
        private AnnualLeaveCalculation annualLeaveCalculation;
        private IList<AnnualLeaveEntitlement> annualLeaveEntitlements;
        private DAL dal;
        private int annualLeaveCalculationsID;
        private int staffCode;
        private bool editMode;
        private Company company;
        private int ctr;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public AnnualReverseCalculateLeaveForm()
        {
            try
            {
                InitializeComponent();
                this.annualLeaveCalculation = new AnnualLeaveCalculation();
                this.annualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
                this.dal = new DAL();
                this.employees = new List<Employee>();
                this.employee = new Employee();
                this.annualLeaveCalculationsID = 0;
                this.staffCode = 0;
                this.editMode = false;
                this.company = new Company();
                this.ctr = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void yearComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                yearComboBox.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
                yearComboBox.Items.Add(DateTime.Now.Year);
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
                annualLeaveCalculationsID = 0;
                staffErrorProvider.Clear();
                yearComboBox.Items.Clear();
                yearComboBox.Text = string.Empty;
                cboLeaveEntitlement.Items.Clear();
                cboLeaveEntitlement.Text = string.Empty;
                radioButtonAll.Checked = true;
                numericUpDownNumberOfDays.Value = 0;
                searchGrid.Visible = false;
                editMode = false;
                ClearStaff();
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
                nametxt.Clear();
                gendertxt.Clear();
                staffIDtxt.Focus();
                txtLeaveEntitlement.Clear();
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
                    ClearStaff();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;
                            txtLeaveEntitlement.Text = employee.AnnualLeaveEntitlement.CategoryOfPost + " " + employee.AnnualLeaveEntitlement.Status + " (" + employee.AnnualLeaveEntitlement.NumberOfDays + ")"; ;
                            numericUpDownNumberOfDays.Enabled = false;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    ClearStaff();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    if (radioButtonAll.Checked == true)
                    {
                        employees = dal.GetAll<Employee>();
                        if (employees.Count > 0)
                        {
                            foreach (Employee employee in employees)
                            {
                                UpdateAnnualLeaveCalculationsEntity();
                                employee.AnnualLeave = employee.AnnualLeaveEntitlement.NumberOfDays;
                                employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
                                employee.AnnualLeaveYear = annualLeaveCalculation.Year;
                                dal.Update(employee);
                                annualLeaveCalculation.Employee.StaffID = employee.StaffID;
                                annualLeaveCalculation.Employee.ID = employee.ID;
                                dal.Save(annualLeaveCalculation);
                                annualLeaveCalculation = new AnnualLeaveCalculation();
                            }
                        }
                    }
                    else if (radioButtonBy.Checked == true)
                    {
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.AnnualLeaveEntitlementID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = annualLeaveEntitlements[cboLeaveEntitlement.SelectedIndex].ID,
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
                                UpdateAnnualLeaveCalculationsEntity();
                                employee.AnnualLeave = int.Parse(annualLeaveCalculation.NumberOfDays.ToString());
                                employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
                                employee.AnnualLeaveYear = annualLeaveCalculation.Year;
                                dal.Update(employee);
                                annualLeaveCalculation.Employee.StaffID = employee.StaffID;
                                annualLeaveCalculation.Employee.ID = employee.ID;
                                dal.Save(annualLeaveCalculation);
                                annualLeaveCalculation = new AnnualLeaveCalculation();
                            }
                        }
                    }
                    else
                    {                      
                        employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                        UpdateAnnualLeaveCalculationsEntity();
                        employee.AnnualLeave = int.Parse(annualLeaveCalculation.NumberOfDays.ToString());
                        employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
                        employee.AnnualLeaveYear = annualLeaveCalculation.Year;
                        dal.Update(employee);
                        annualLeaveCalculation.Employee.StaffID = employee.StaffID;
                        annualLeaveCalculation.Employee.ID = employee.ID;
                        dal.Save(annualLeaveCalculation);
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

        private void UpdateAnnualLeaveCalculationsEntity()
        {
            try
            {
                annualLeaveCalculation.ID = annualLeaveCalculationsID;
                annualLeaveCalculation.IsAll = radioButtonAll.Checked;
                annualLeaveCalculation.User.ID = GlobalData.User.ID;
                annualLeaveCalculation.NumberOfDays = numericUpDownNumberOfDays.Value;
                annualLeaveCalculation.Year = int.Parse(yearComboBox.Text);
                annualLeaveCalculation.Type = "Reverse";

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
                if (yearComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(yearComboBox, "Please select the Year Date");
                    yearComboBox.Focus();
                }
                if (radioButtonIndividual.Checked == true && staffIDtxt.Text == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter Staff");
                    staffIDtxt.Focus();
                }
                if (radioButtonBy.Checked == true && cboLeaveEntitlement.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboLeaveEntitlement, "Please Select Leave Entitlement");
                    cboLeaveEntitlement.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void AnnualReverseCalculateLeaveForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnCalculate.Visible = getPermissions.CanAdd;
                   // findbtn.Visible = getPermissions.CanView;
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

        private void radioButtonIndividual_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonIndividual.Checked == true)
                {
                    groupBoxStaff.Visible = true;
                    cboLeaveEntitlement.Visible = false;
                    numericUpDownNumberOfDays.Visible = true;
                    lblDays.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonAll.Checked == true)
                {
                    groupBoxStaff.Visible = false;
                    cboLeaveEntitlement.Visible = false;
                    numericUpDownNumberOfDays.Visible = false;
                    lblDays.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboLeaveEntitlement_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboLeaveEntitlement.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "AnnualLeaveEntitlementView.Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.And
                });
                annualLeaveEntitlements = dal.GetByCriteria<AnnualLeaveEntitlement>(query);
                foreach (AnnualLeaveEntitlement annualLeaveEntitlement in annualLeaveEntitlements)
                {
                    cboLeaveEntitlement.Items.Add(annualLeaveEntitlement.CategoryOfPost + " " + annualLeaveEntitlement.Status + " (" + annualLeaveEntitlement.NumberOfDays + ")");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboLeaveEntitlement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                numericUpDownNumberOfDays.Value = annualLeaveEntitlements[cboLeaveEntitlement.SelectedIndex].NumberOfDays;
                numericUpDownNumberOfDays.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void radioButtonBy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonBy.Checked == true)
                {
                    groupBoxStaff.Visible = false;
                    cboLeaveEntitlement.Visible = true;
                    numericUpDownNumberOfDays.Visible = true;
                    lblDays.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
