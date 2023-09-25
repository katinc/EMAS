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


namespace eMAS.Forms.Employment
{
    public partial class TransfersView : Form
    {
        private IDAL dal;
        private Transfers transferNew;
        private Employee employee;
        private EmployeeGrade employeeGrade;
        private GradeCategory gradeCategory;
        private Transfer transfer;
        private Company company;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<Zone> zones;
        private IList<Transfer> transfers;
        private IList<Transfer> foundTransfers;
        private int ctr;
        private bool found;
        

        public TransfersView(Transfers transferNew)
        {
            try
            {
                InitializeComponent();
                this.transferNew = transferNew;
                this.employee = new Employee();
                this.transfer = new Transfer();
                this.company = new Company();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.transfers=new List<Transfer>();
                this.foundTransfers=new List<Transfer>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.zones = new List<Zone>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.dal = new DAL();
                this.ctr = 0;
                this.dal.OpenConnection();
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public TransfersView()
        {
            try
            {
                InitializeComponent();
                this.transferNew = new Transfers();
                this.employee = new Employee();
                this.transfer = new Transfer();
                this.company = new Company();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.transfers = new List<Transfer>();
                this.foundTransfers = new List<Transfer>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.zones = new List<Zone>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.dal = new DAL();
                this.ctr = 0;
                this.found = false;
                this.dal.OpenConnection();
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
                
                    if (grid.CurrentRow != null && transferNew.CanEdit)
                    {
                        transfer.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        transfer.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                        transfer.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                        transfer.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                        transfer.Employee.Gender = grid.CurrentRow.Cells["gridGender"].Value.ToString();
                        transfer.Employee.Age = grid.CurrentRow.Cells["gridAge"].Value.ToString();
                        transfer.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                        transfer.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                        transfer.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategory"].Value.ToString();
                        transfer.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGrade"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridSpecialty"].Value != null)
                        {
                            transfer.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();
                        }

                        if (grid.CurrentRow.Cells["gridLastTransferredDate"].Value != null)
                        {
                            transfer.Employee.CurrentTransferredDate = DateTime.Parse(grid.CurrentRow.Cells["gridLastTransferredDate"].Value.ToString());
                        }
                        else
                        {
                            transfer.Employee.CurrentTransferredDate = null;
                        }
                        if (grid.CurrentRow.Cells["gridTransferDate"].Value != null)
                        {
                            transfer.Date = DateTime.Parse(grid.CurrentRow.Cells["gridTransferDate"].Value.ToString());
                        }
                        else
                        {
                            transfer.Employee.CurrentTransferredDate = null;
                        }

                        transfer.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                        transfer.PreviousInstitution = grid.CurrentRow.Cells["gridPreviousInstitution"].Value.ToString();
                        transfer.PreviousStaffID = grid.CurrentRow.Cells["gridPreviousStaffID"].Value.ToString();
                        transfer.Employee.TransferType = grid.CurrentRow.Cells["gridTransferType"].Value.ToString();
                        transfer.Type = grid.CurrentRow.Cells["gridType"].Value.ToString();
                        if (transfer.Employee.TransferType.ToLower().Trim() == "internal transfer")
                        {
                            transfer.Zone.Description = grid.CurrentRow.Cells["gridNewZone"].Value.ToString();
                            transfer.Department.Description = grid.CurrentRow.Cells["gridNewDepartment"].Value.ToString();
                            transfer.Unit.Description = grid.CurrentRow.Cells["gridNewUnit"].Value.ToString();
                        }
                        transfer.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                        transferNew.EditTransfer(transfer);
                        this.Close();
                    }else if (!transferNew.CanEdit)
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
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are you sure you want to Cancel Transfer of the Staff " + "?") == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                dal.BeginTransaction();
                                transfer.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                transfer.Archived = true;
                                dal.Delete(transfer);
                                employee = dal.GetByID<Employee>(grid.CurrentRow.Cells["gridStaffID"].Value);
                                employee.CurrentTransferredDate = null;
                                employee.TransferedIn = false;
                                employee.TransferredOut = false;
                                employee.TransferredInternally = false;
                                dal.Update(employee);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                dal.CommitTransaction();
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                dal.BeginTransaction();
                                transfer.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                transfer.Archived = true;
                                dal.Delete(transfer);
                                employee = dal.GetByID<Employee>(grid.CurrentRow.Cells["gridStaffID"].Value);
                                employee.CurrentTransferredDate = null;
                                employee.TransferedIn = false;
                                employee.TransferredOut = false;
                                employee.TransferredInternally = false;
                                dal.Update(employee);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                dal.CommitTransaction();
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
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not Cancel the Transfer Successfully,Please See the system Administrator");
            }
        }

        private void TransfersView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                txtTotalTransferCount.Text = dal.GetAll<Transfer>().Count.ToString();
                GetData();
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

        private void PopulateView(IList<Transfer> transfers)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Transfer transfer in transfers)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = transfer.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = transfer.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = transfer.Employee.ID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = transfer.Employee.Title.Description + " " + transfer.Employee.Surname + " " + transfer.Employee.FirstName + " " + transfer.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGender"].Value = transfer.Employee.Gender;
                    grid.Rows[ctr].Cells["gridAge"].Value = transfer.Employee.Age;
                    grid.Rows[ctr].Cells["gridGrade"].Value = transfer.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = transfer.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = transfer.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = transfer.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = transfer.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridZone"].Value = transfer.Employee.Zone.Description;
                    grid.Rows[ctr].Cells["gridTransferType"].Value = transfer.Employee.TransferType;
                    grid.Rows[ctr].Cells["gridType"].Value = transfer.Type;
                    if(transfer.Type.Trim() == "Internal Transfer")
                    {
                        grid.Rows[ctr].Cells["gridNewUnit"].Value = transfer.Unit.Description;
                        grid.Rows[ctr].Cells["gridNewDepartment"].Value = transfer.Department.Description;
                        grid.Rows[ctr].Cells["gridNewZone"].Value = transfer.Zone.Description;
                        grid.Rows[ctr].Cells["gridPreviousInstitution"].Value = "NA";
                        grid.Rows[ctr].Cells["gridPreviousStaffID"].Value = transfer.PreviousStaffID;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridPreviousInstitution"].Value = transfer.PreviousInstitution;
                        grid.Rows[ctr].Cells["gridPreviousStaffID"].Value = transfer.PreviousStaffID;
                        grid.Rows[ctr].Cells["gridNewUnit"].Value = "NA";
                        grid.Rows[ctr].Cells["gridNewDepartment"].Value = "NA";
                        grid.Rows[ctr].Cells["gridNewZone"].Value = "NA";
                    }
                    grid.Rows[ctr].Cells["gridTransferred"].Value = transfer.Transferred;
                    grid.Rows[ctr].Cells["gridTransferDate"].Value = transfer.Date;
                    grid.Rows[ctr].Cells["gridLastTransferredDate"].Value = transfer.Employee.CurrentTransferredDate; 
                    grid.Rows[ctr].Cells["gridReason"].Value = transfer.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = transfer.User.ID;
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
                        Property = "TransferView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (typeComboBox.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TransferView.Type",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = typeComboBox.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TransferView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TransferView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TransferView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TransferView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TransferView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }

                query.Criteria.Add(new Criterion()
                {
                    Property = "TransferView.Archived",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.None
                });
                transfers = dal.GetByCriteria<Transfer>(query);
                txtTotalTransferCount.Text = transfers.Count.ToString();
                PopulateView(transfers);
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
                transfer = new Transfer();
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                typeComboBox.Items.Clear();
                typeComboBox.Text = string.Empty;
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
                        foundTransfers.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "TransferView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        transfers = dal.GetByCriteria<Transfer>(query);
                        if (transfers.Count > 0)
                        {
                            foreach (Transfer transfer in transfers)
                            {
                                if (transfer.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundTransfers.Add(transfer);
                                }
                            }
                            PopulateView(foundTransfers);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + txtStaffID.Text + " is not Found in the Transfer List");
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

        
        void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.Items.Clear();
                zones = dal.GetAll<Zone>();
                foreach (Zone zone in zones)
                {
                    cboZone.Items.Add(zone.Description);
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

        private void typeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (typeComboBox.Text == "Transfer Out")
                {
                    txtStaffID.Enabled = true;
                    lblZone.Visible = false;
                    lblDepartment.Visible = false;
                    lblUnit.Visible = false;
                    cboDepartment.Visible = false;
                    cboUnit.Visible = false;
                    cboZone.Visible = false;
                }
                else if (typeComboBox.Text == "Transfer In")
                {
                    txtStaffID.Enabled = true;
                    lblZone.Visible = false;
                    lblDepartment.Visible = false;
                    lblUnit.Visible = false;
                    cboDepartment.Visible = false;
                    cboUnit.Visible = false;
                    cboZone.Visible = false;
                }
                else if (typeComboBox.Text == "Internal Transfer")
                {
                    txtStaffID.Enabled = true;
                    lblZone.Visible = true;
                    lblDepartment.Visible = true;
                    lblUnit.Visible = true;
                    cboDepartment.Visible = true;
                    cboUnit.Visible = true;
                    cboZone.Visible = true;
                }
                else
                {
                    txtStaffID.Enabled = false;
                    lblZone.Visible = false;
                    lblDepartment.Visible = false;
                    lblUnit.Visible = false;
                    cboDepartment.Visible = false;
                    cboUnit.Visible = false;
                    cboZone.Visible = false;
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
    }
}
