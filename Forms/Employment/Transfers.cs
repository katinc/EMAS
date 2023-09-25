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


namespace eMAS.Forms.Employment
{
    public partial class Transfers : Form
    {
        private IList<Employee> employees;
        private Employee employee;
        private IList<Zone> zones;
        private IList<Department> departments;
        private IList<Unit> units;
        private DAL dal;
        private Transfer transfer;
        private Company company;
        private int ctr;
        private int transferID;
        private int staffCode;
        private bool editMode;
        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        List<Control> controls;
        List<controlObject> OldValues;


        public Transfers()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.transfer = new Transfer();
                this.company = new Company();
                this.employees = new List<Employee>();
                this.employee = new Employee();
                this.zones = new List<Zone>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.transferID = 0;
                this.staffCode = 0;
                this.ctr = 0;
                this.editMode = false;

                this.controls = new List<Control>();
                this.OldValues = new List<controlObject>();


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void typeComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                typeComboBox.Items.Clear();
                typeComboBox.Items.Add("Transfer In");
                typeComboBox.Items.Add("Transfer Out");
                typeComboBox.Items.Add("Internal Transfer");
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

        private void Transfers_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Enabled = getPermissions.CanAdd;
                    btnView.Enabled = getPermissions.CanView;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }

                //GlobalData.assignControls(this);
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
                transferID = 0;
                staffErrorProvider.Clear();
                transferDatePicker.ResetText();
                previousStaffNoTextBox.Clear();
                institutionTextBox.Clear();
                reasonTextBox.Clear();
                typeComboBox.Items.Clear();
                typeComboBox.Text = string.Empty;
                cboZone.DataSource = null;
                cboZone.Text = string.Empty;
                cboDepartment.DataSource = null;
                cboDepartment.Text = string.Empty;
                cboUnit.DataSource = null;
                cboUnit.Text = string.Empty;
                ClearStaff();
                searchGrid.Visible = false;
                editMode = false;
                lblPreviousInstitution.Visible = false;
                lblNewInstitution.Visible = false;
                institutionTextBox.Visible = false;
                lblZone.Visible = false;
                lblDepartment.Visible = false;
                lblUnit.Visible = false;
                cboDepartment.Visible = false;
                cboUnit.Visible = false;
                cboZone.Visible = false;
                previousStaffNoTextBox.Text = string.Empty;
                txtTransferDate.Clear();
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
                agetxt.Clear();
                departmentTextBox.Clear();
                unitTextBox.Clear();
                gradeCategoryTextBox.Clear();
                gradeTextBox.Clear();
                specialtyTextBox.Clear();
                transferDatePicker.Value = DateTime.Today.Date;
                txtTransferType.Clear();
                pictureBox.Image = pictureBox.InitialImage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #region Staff Operations
        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    Clear();
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
                            transferDatePicker.Select();
                            departmentTextBox.Text = employee.Department.Description;
                            unitTextBox.Text = employee.Unit.Description;
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                            gradeTextBox.Text = employee.Grade.Grade;
                            specialtyTextBox.Text = employee.Specialty.Description;
                            txtTransferType.Text = employee.TransferType;
                            txtTransferDate.Text = employee.CurrentTransferredDate.Value.Date.ToString("dd/MM/yyyy");
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

        public void EditTransfer(Transfer transfer)
        {
            try
            {
                ClearStaff();
                editMode = true;
                nametxt.Text = transfer.StaffName;
                staffIDtxt.Text = transfer.Employee.StaffID;
                staffCode = transfer.Employee.ID;
                gendertxt.Text = transfer.Employee.Gender;
                agetxt.Text = transfer.Employee.Age;
                searchGrid.Visible = false;

                groupBox1.Enabled = true;
                transferDatePicker.Select();
                departmentTextBox.Text = transfer.Employee.Department.Description;
                unitTextBox.Text = transfer.Employee.Unit.Description;
                gradeCategoryTextBox.Text = transfer.Employee.GradeCategory.Description;
                gradeTextBox.Text = transfer.Employee.Grade.Grade;
                specialtyTextBox.Text = transfer.Employee.Specialty.Description;
                txtTransferType.Text = transfer.Employee.TransferType;
                if (transfer.Employee.CurrentTransferredDate !=null)
                {
                    txtTransferDate.Text = transfer.Employee.CurrentTransferredDate.Value.Date.ToString("dd/MM/yyyy");
                }
                
                transferID = transfer.ID;
                transferDatePicker.Text = transfer.Date.ToString();
                typeComboBox_DropDown(this, EventArgs.Empty);
                typeComboBox.Text = transfer.Type;
                typeComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                previousStaffNoTextBox.Text = transfer.PreviousStaffID.Trim();
                institutionTextBox.Text = transfer.PreviousInstitution.Trim();
                reasonTextBox.Text = transfer.Reason.Trim();
                if (typeComboBox.Text.ToLower().Trim() == "internal transfer")
                {
                    cboZone_DropDown(this, EventArgs.Empty);
                    cboZone.Text = transfer.Zone.Description.Trim();
                    cboDepartment_DropDown(this, EventArgs.Empty);
                    cboDepartment.Text = transfer.Department.Description.Trim();
                    cboDepartment_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboUnit.Text = transfer.Unit.Description;
                }
                typeComboBox.Enabled = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != transfer.User.ID)
                {
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            OldValues = GlobalData.CloneControls(controls, this);

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
                        Property = "StaffPersonalInfoLazyLoadView.Confirmed",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = true,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    employees = dal.LazyLoadCriteria<Employee>(query);
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
                    company = dal.LazyLoad<Company>()[0];
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text.Trim() + "  is already Transferred");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    UpdateTransfersEntity();
                    if (editMode)
                    {
                        if (transferDatePicker.Value.Date <= DateTime.Today.Date)
                        {
                            employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                            employee.CurrentTransferredDate = transfer.Date;
                           
                            if (typeComboBox.Text.Trim() == "Transfer In")
                            {
                                employee.TransferredOut = false;
                                employee.TransferedIn = true;
                                employee.TransferType = "Transfer In";
                            }
                            else if (typeComboBox.Text.Trim() == "Transfer Out")
                            {
                                employee.TransferredOut = true;
                                employee.TransferType = "Transfer Out";
                            }
                            else
                            {
                                employee.TransferredInternally = true;
                                employee.InZoneDate = transfer.Date;
                                employee.Zone.ID = transfer.Zone.ID;
                                employee.Department.ID = transfer.Department.ID;
                                employee.Unit.ID = transfer.Unit.ID;
                                employee.TransferType = "Internal Transfer";
                            }
                          
                            dal.Update(employee);
                            transfer.Transferred = true;
                        }
                        else
                        {                         
                            transfer.Transferred = false;
                        }
                        //dal.Update(transfer);
                        dal.CommitTransaction();
                        GlobalData.ProcessEdit(OldValues, controls, this, transferID, staffIDtxt.Text);
                        Clear();
                    }
                    else
                    {
                        if (transferDatePicker.Value.Date <= DateTime.Today.Date)
                        {
                            employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                            employee.CurrentTransferredDate = transfer.Date;
                            if (typeComboBox.Text.Trim() == "Transfer In")
                            {
                                employee.TransferredOut = false;
                                employee.TransferedIn = true;
                                employee.TransferType = "Transfer In";
                            }
                            else if (typeComboBox.Text.Trim() == "Transfer Out")
                            {
                                employee.TransferredOut = true;
                                employee.TransferType = "Transfer Out";
                            }
                            else
                            {
                                employee.TransferredInternally = true;
                                employee.InZoneDate = transfer.Date;
                                employee.Zone.ID = transfer.Zone.ID;
                                employee.Department.ID = transfer.Department.ID;
                                employee.Unit.ID = transfer.Unit.ID;
                                employee.TransferType = "Internal Transfer";
                            }                        
                            
                            dal.Update(employee);
                            transfer.Transferred = true;
                        }
                        else
                        {
                            transfer.Transferred = false;
                        }
                        dal.Save(transfer);
                        dal.CommitTransaction();
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Not saved successfully,Please See the system Administrator");
            }
        }

        private void UpdateTransfersEntity()
        {
            try
            {
                transfer.ID = transferID;
                transfer.Employee.StaffID = staffIDtxt.Text.Trim();
                transfer.Employee.ID = staffCode;
                transfer.Date = transferDatePicker.Value;
                transfer.Type = typeComboBox.Text.Trim();
                if (transfer.Type == "Internal Transfer")
                {
                    transfer.Zone.ID = zones[cboZone.SelectedIndex].ID;
                    transfer.Department.ID = departments[cboDepartment.SelectedIndex].ID;
                    transfer.Unit.ID = units[cboUnit.SelectedIndex].ID;
                }
                else
                {
                    transfer.PreviousInstitution = institutionTextBox.Text.Trim();
                    transfer.PreviousStaffID = previousStaffNoTextBox.Text.Trim();
                }
                            
                transfer.Reason = reasonTextBox.Text.Trim();
                transfer.User.ID = GlobalData.User.ID;
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
                if (staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter the StaffID");
                    staffIDtxt.Focus();
                }
                else if (nametxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(nametxt, "Please Enter the Name of the Staff");
                    nametxt.Focus();
                }
                else if (transferDatePicker.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(transferDatePicker, "Please select the Transfer Date");
                    transferDatePicker.Focus();
                }
                else if (transferDatePicker.Checked && !Validator.DateRangeValidator(transferDatePicker.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(transferDatePicker, "Please Transfer Date cannot be greater than Today");
                    transferDatePicker.Focus();
                }
                else if (typeComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(typeComboBox, "Please select the Type");
                    typeComboBox.Focus();
                }
                else if ((typeComboBox.Text.Trim() == "Transfer Out" || typeComboBox.Text.Trim() == "Transfer In") && institutionTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(institutionTextBox, "Please enter Institution");
                    institutionTextBox.Focus();
                }
                else if (typeComboBox.Text.Trim() == "Internal Transfer" && cboZone.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboZone, "Please enter Zone");
                    cboZone.Focus();
                }
                else if (typeComboBox.Text.Trim() == "Internal Transfer" && cboDepartment.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboDepartment, "Please enter Department");
                    cboDepartment.Focus();
                }
                else if (typeComboBox.Text.Trim() == "Internal Transfer" && cboUnit.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboUnit, "Please enter Unit");
                    cboUnit.Focus();
                }
                else if ((typeComboBox.Text.Trim() == "Transfer Out" || typeComboBox.Text.Trim() == "Transfer In") && previousStaffNoTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(previousStaffNoTextBox, "Please enter Previous StaffID");
                    previousStaffNoTextBox.Focus();
                }
                else if (editMode == false && typeComboBox.Text.Trim() == txtTransferType.Text.Trim() && txtTransferType.Text.ToLower().Trim() != "internal transfer")
                {
                    result = false;
                    staffErrorProvider.SetError(typeComboBox, "Please The Staff is Already  " + txtTransferType.Text.Trim());
                    typeComboBox.Focus();
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
                TransfersView form = new TransfersView(this);
                form.MdiParent = this.MdiParent;
                form.btnRemove.Enabled = CanDelete;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.DataSource = null;
                zones = dal.GetAll<Zone>();

                cboZone.DataSource = zones;
                cboZone.DisplayMember = "Description";
                cboZone.ValueMember = "ID";

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
                cboDepartment.DataSource = null;
                departments = dal.GetAll<Department>();

                cboDepartment.DataSource = departments;
                cboDepartment.DisplayMember = "Description";
                cboDepartment.ValueMember = "ID";
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
                cboUnit.DataSource = null;
                cboUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboDepartment.Text,
                    CriteriaOperator = CriteriaOperator.And
                });
                units = dal.GetByCriteria<Unit>(query);

                cboUnit.DataSource = units;
                cboUnit.DisplayMember = "Description";
                cboUnit.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void typeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if(typeComboBox.Text.Trim()=="Transfer Out")
                {
                    lblNewInstitution.Visible=true;
                    lblPreviousInstitution.Visible = false;
                    institutionTextBox.Visible = true;
                    lblZone.Visible = false;
                    lblDepartment.Visible = false;
                    lblUnit.Visible = false;
                    cboDepartment.Visible = false;
                    cboUnit.Visible = false;
                    cboZone.Visible = false;
                    previousStaffNoTextBox.Text = staffIDtxt.Text.Trim();
                }
                else if(typeComboBox.Text.Trim()=="Transfer In")
                {
                    lblPreviousInstitution.Visible=true;
                    lblNewInstitution.Visible = false;
                    institutionTextBox.Visible = true;
                    lblZone.Visible = false;
                    lblDepartment.Visible = false;
                    lblUnit.Visible = false;
                    cboDepartment.Visible = false;
                    cboUnit.Visible = false;
                    cboZone.Visible = false;
                    previousStaffNoTextBox.Text = string.Empty;
                }
                else if (typeComboBox.Text.Trim() == "Internal Transfer")
                {
                    lblZone.Visible = true;
                    lblDepartment.Visible = true;
                    lblUnit.Visible = true;
                    cboDepartment.Visible = true;
                    cboUnit.Visible = true;
                    cboZone.Visible = true;
                    lblPreviousInstitution.Visible = false;
                    lblNewInstitution.Visible = false;
                    lblNewInstitution.Visible = false;
                    institutionTextBox.Visible = false;
                    previousStaffNoTextBox.Text = staffIDtxt.Text.Trim();
                }
                else
                {
                    lblPreviousInstitution.Visible=false;
                    lblNewInstitution.Visible = false;
                    lblNewInstitution.Visible=false;
                    lblZone.Visible = false;
                    lblDepartment.Visible = false;
                    lblUnit.Visible = false;
                    cboDepartment.Visible = false;
                    cboUnit.Visible = false;
                    cboZone.Visible = false;
                    previousStaffNoTextBox.Text = string.Empty;
                }
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
    }
}
