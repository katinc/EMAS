using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using Session_Framework;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class AppraisalObjectivesForm : Form
    {
        private Company company;
        private IDAL dal;
        private int ctr;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private bool editMode = false;
        private int staffCode;
        public Employee selectedEmployee;
        public IList<AppraisalPeriod> lstAppraisalPeriod;
        private AppraisalPeriodDataMapper appraisalPeriodDataMapper;

        public IList<AppraisalObjective> lstAppraisalObjectives;
        private AppraisalObjectivesDataMapper appraisalDataMapper;
        private DALHelper dalHelper;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public AppraisalObjectivesForm()
        {
            InitializeComponent();
            company = new Company();
            dal = new DAL();
            employees = new List<Employee>();
            employeeList = new List<Employee>();
            lstAppraisalPeriod = new List<AppraisalPeriod>();
            lstAppraisalObjectives = new List<AppraisalObjective>();
            appraisalDataMapper = new AppraisalObjectivesDataMapper();
            dalHelper = new DALHelper();
            appraisalPeriodDataMapper = new AppraisalPeriodDataMapper();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            grid.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AppraisalObjectivesAddEditForm objectiveAddEditForm = new AppraisalObjectivesAddEditForm(this,new AppraisalObjective());
            objectiveAddEditForm.ShowDialog(this);
        }
        void Clear()
        {
            staffIDtxt.Clear();
            nametxt.Clear();
            cmbPeriod.SelectedIndex = -1;
            grid.Rows.Clear();
        }
        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
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

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
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

                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;

                            departmentTextBox.Text = employee.Department.Description;



                            txtEmail.Text = employee.Email;

                            txtPhoneNo.Text = employee.TelNo;
                            txtCurrentGrade.Text = employee.GradeCategory.Description;



                            selectedEmployee = dal.ShowImageByStaffID<Employee>(employee);
                            pictureBox.Image = selectedEmployee.Photo;

                            if (cmbPeriod.SelectedItem != null)
                            {
                                btnAdd.Enabled = true;
                                btnEdit.Enabled = true;
                                btnDelete.Enabled = true;
                            }
                            else
                            {
                                btnAdd.Enabled = false;
                                btnEdit.Enabled = false;
                                btnDelete.Enabled = false;
                            }
                           
                            //loadGrid(selectedEmployee.ID);
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
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                  
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
        public void loadGrid(int staffId)
        {
            try
            {
                grid.Rows.Clear();
                lstAppraisalObjectives.Clear();
                lstAppraisalObjectives = appraisalDataMapper.getDataByStaffId(staffId,lstAppraisalPeriod[cmbPeriod.SelectedIndex].Id);
                
                int ctr = 0;
                foreach (AppraisalObjective dRow in lstAppraisalObjectives)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = dRow.Id;
                    grid.Rows[ctr].Cells["gridObjective"].Value = dRow.Description;
                    grid.Rows[ctr].Cells["gridRatedValue"].Value = (dRow.PeriodRating!=null)?dRow.PeriodRating.Value.ToString():string.Empty;
                    grid.Rows[ctr].Cells["gridComment"].Value = dRow.Comment;
                    grid.Rows[ctr].Cells["gridActive"].Value = dRow.Active;
                    grid.Rows[ctr].Cells["gridEnteredBy"].Value = dRow.EnteredBy.NAME;
                    grid.Rows[ctr].Cells["gridEntryDate"].Value = dRow.EntryDate.ToShortDateString();

                    ctr++;
                }
                grid.ClearSelection();
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
                MessageBox.Show("There was an error : " + xi);
            }
            
        }
        public void UpdateRow(DataGridViewRow dRow,AppraisalObjective objective)
        {
            try
            {

                dRow.Cells["gridID"].Value = objective.Id;
                dRow.Cells["gridObjective"].Value = objective.Description;
                dRow.Cells["gridRatedValue"].Value = (objective.PeriodRating!=null)?objective.PeriodRating.Value.ToString():string.Empty;
                dRow.Cells["gridComment"].Value = objective.Comment;
                dRow.Cells["gridActive"].Value = objective.Active;
                dRow.Cells["gridEnteredBy"].Value = objective.EnteredBy.NAME;
                dRow.Cells["gridEntryDate"].Value = objective.EntryDate.ToShortDateString();

                
            }
            catch (Exception xi)
            {

            }

        }
        private void AppraisalObjectivesForm_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnAdd.Enabled = getPermissions.CanAdd;
                btnEdit.Enabled = getPermissions.CanView;
                btnDelete.Enabled = getPermissions.CanDelete;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }

        private void searchGrid_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.SelectedRows.Count > 0)
                {
                    var objective = appraisalDataMapper.getDataById(Convert.ToInt32(grid.SelectedRows[0].Cells["gridID"].Value));
                    AppraisalObjectivesAddEditForm objectiveAddEdit = new AppraisalObjectivesAddEditForm(this, objective);
                    objectiveAddEdit.ShowDialog(this);
                }
                else
                    MessageBox.Show(this, "Sorry: No Record Was Selected!");
            }
            catch (Exception xi) { }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Id", Convert.ToInt32(grid.SelectedRows[0].Cells["gridID"].Value), DbType.Int32);
                dalHelper.ExecuteNonQuery("update AppraisalObjectives set Archived='true' where id=@Id");
                grid.Rows.Remove(grid.SelectedRows[0]);
            }
            else
                MessageBox.Show(this, "Sorry: No Record Was Selected!");
        }

        private void cmbPeriod_DropDown(object sender, EventArgs e)
        {
            try
            {
                lstAppraisalPeriod = appraisalPeriodDataMapper.getData(true, false);
                cmbPeriod.Items.Clear();
                foreach (AppraisalPeriod dRow in lstAppraisalPeriod)
                {
                    cmbPeriod.Items.Add(dRow.Description.Trim());
                }
            }
            catch (Exception xi) { }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbPeriod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbPeriod.SelectedItem != string.Empty)
                {
                    txtStartDate.Text = lstAppraisalPeriod[cmbPeriod.SelectedIndex].StartDate.ToShortDateString();
                    txtEndDate.Text = lstAppraisalPeriod[cmbPeriod.SelectedIndex].EndDate.ToShortDateString();

                    if(selectedEmployee!=null && selectedEmployee.ID>0)
                    {
                        btnAdd.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    else
                    {
                        btnAdd.Enabled = false;
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }

                    loadGrid(selectedEmployee.ID);
                   
                }
                else
                {
                    txtEndDate.Clear();
                    txtStartDate.Clear();
                }
                
            }
            catch (Exception xi) {

                txtEndDate.Clear();
                txtStartDate.Clear();
            }
           
        }

        private void cmbPeriod_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text != string.Empty)
                {
                    loadGrid(selectedEmployee.ID);
                }
                else
                {
                    cmbPeriod.Items.Clear();
                    cmbPeriod.Text = string.Empty;
                    txtEndDate.Clear();
                    txtStartDate.Clear();
                    MessageBox.Show("Enter a StaffID to load the details before selecting period");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);

                MessageBox.Show("Enter a StaffID to load the details before selecting period");


            }
        }

        



    }
}
