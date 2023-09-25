using HRBussinessLayer.System_Setup_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;
using HRBussinessLayer.Staff_Information_CLASS;
using System.IO;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class RequestChangeApprovalForm : Form
    {
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private Company company;
        private IDAL dal;
        private bool found;

        private string requestType;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public Permissions permissions;
        public RequestChangeApprovalForm()
        {
            InitializeComponent();
            this.departments = new List<Department>();
            this.units = new List<Unit>();
            this.gradeCategories = new List<GradeCategory>();
            this.employeeGrades = new List<EmployeeGrade>();
            this.dal = new DAL();
            this.found = false;
            this.requestType = string.Empty;
        }

        private void RequestChangeApprovalForm_Load(object sender, EventArgs e)
        {
            

            permissions = GlobalData.CheckPermissions(3);
            btnSave.Enabled = permissions.CanAdd;

            if (!permissions.CanView)
            {
                MessageBox.Show("Sorry you do not have permission to edit this data.");
                return;
            }
            GetAll();
        }

        private void GetAll()
        {
            try
            {
                grid.Rows.Clear();
                var requests = GlobalData._context.StaffChangesRequestViews.Where(u => u.Approved == false).GroupBy(u => u.Grouping).ToList();
                //var transactionalRequests = GlobalData._context.StaffChangesRequestsTransactionsViews.Where(u => u.Approved == false).GroupBy(u => u.Grouping).ToList();

                int ctr = 0;
                foreach (var req in requests)
                {
                    var fullName = GlobalData.GetFullName(req.ToList()[0].Surname, req.ToList()[0].Firstname, req.ToList()[0].OtherName);

                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridStaffID"].Value = req.ToList()[0].StaffID;
                    grid.Rows[ctr].Cells["gridUser"].Value = req.ToList()[0].Name;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = fullName.Trim() == string.Empty || fullName == null ? req.ToList()[0].DatasetDescription : fullName;
                    grid.Rows[ctr].Cells["gridGroupID"].Value = req.ToList()[0].Grouping;
                    grid.Rows[ctr].Cells["gridDate"].Value = req.ToList()[0].Date;
                    //grid.Rows[ctr].Cells["gridRequestType"].Value = "Staff Info"; //to signify staff changes
                    ctr++;
                }

                //foreach (var req in transactionalRequests)
                //{
                //    grid.Rows.Add(1);
                //    grid.Rows[ctr].Cells["gridStaffID"].Value = req.ToList()[0].StaffID;
                //    grid.Rows[ctr].Cells["gridUser"].Value = req.ToList()[0].Name;
                //    grid.Rows[ctr].Cells["gridStaffName"].Value = GlobalData.GetFullName(req.ToList()[0].Surname, req.ToList()[0].Firstname, req.ToList()[0].OtherName);
                //    grid.Rows[ctr].Cells["gridGroupID"].Value = req.ToList()[0].Grouping;
                //    grid.Rows[ctr].Cells["gridDate"].Value = req.ToList()[0].Date;
                //    grid.Rows[ctr].Cells["gridRequestType"].Value = "Transactional"; //to signify transactional changes
                //    ctr++;
                //}

                grid.Sort(grid.Columns["gridDate"],
                System.ComponentModel.ListSortDirection.Descending);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        //private void cboDepartment_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cboDepartment.Items.Clear();
        //        if (departments.Count <= 0)
        //        {
        //            departments = dal.GetAll<Department>();
        //        }

        //        foreach (Department department in departments)
        //        {
        //            cboDepartment.Items.Add(department.Description);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}

        //private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Query query = new Query();
        //        cboUnit.Items.Clear();
        //        cboUnit.Text = string.Empty;
        //        query.Criteria.Add(new Criterion()
        //        {
        //            Property = "UnitView.Department",
        //            CriterionOperator = CriterionOperator.EqualTo,
        //            Value = cboDepartment.SelectedItem,
        //            CriteriaOperator = CriteriaOperator.And
        //        });
        //        units = dal.GetByCriteria<Unit>(query);
        //        foreach (Unit unit in units)
        //        {
        //            cboUnit.Items.Add(unit.Description);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}

        //private void cboGradeCategory_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cboGradeCategory.Items.Clear();
        //        if (gradeCategories.Count <= 0)
        //        {
        //            gradeCategories = dal.GetAll<GradeCategory>();
        //        }

        //        foreach (GradeCategory category in gradeCategories)
        //        {
        //            cboGradeCategory.Items.Add(category.Description);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}

        private void cboGrade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        //private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Query query = new Query();
        //        cboGrade.Items.Clear();
        //        cboGrade.Text = string.Empty;
        //        query.Criteria.Add(new Criterion()
        //        {
        //            Property = "EmployeeGradeView.GradeCategory",
        //            CriterionOperator = CriterionOperator.EqualTo,
        //            Value = cboGradeCategory.SelectedItem,
        //            CriteriaOperator = CriteriaOperator.And
        //        });
        //        employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
        //        foreach (EmployeeGrade employeeGrade in employeeGrades)
        //        {
        //            cboGrade.Items.Add(employeeGrade.Grade);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        GetData();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}

        //private void GetData()
        //{
        //    try
        //    {
        //        grid.Rows.Clear();
        //        var requests = GlobalData._context.StaffChangesRequestViews.Where(u => u.Approved == false
        //            && (u.Department.Contains(cboDepartment.Text) || u.Department == null)
        //            && (u.Unit.Contains(unitTextBox.Text) || u.Unit == null)
        //            && (u.GradeCategory.Contains(cboGradeCategory.Text) || u.GradeCategory == null)
        //            && (u.Grade.Contains(cboGrade.Text) || u.Grade == null)
        //            //&& datePickerDate.Checked ? u.Date == datePickerDate.Value : u.Date > DateTime.MinValue
        //        ).GroupBy(u => u.Grouping).ToList();

        //        int ctr = 0;
        //        foreach (var req in requests)
        //        {
        //            grid.Rows.Add(1);
        //            grid.Rows[ctr].Cells["gridStaffID"].Value = req.ToList()[0].StaffID;
        //            grid.Rows[ctr].Cells["gridUser"].Value = req.ToList()[0].Name;
        //            grid.Rows[ctr].Cells["gridStaffName"].Value = GlobalData.GetFullName(req.ToList()[0].Surname, req.ToList()[0].Firstname, req.ToList()[0].OtherName);
        //            grid.Rows[ctr].Cells["gridGroupID"].Value = req.ToList()[0].Grouping;
        //            ctr++;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //        throw ex;
        //    }
        //}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void LoadApprovalPage(string staffID, string groupID)
        {
            try
            {
                Employee employee = new Employee();
                employee = dal.GetByID<Employee>(staffID);
                if (employee == null)
                {
                    AppUtils.ErrorMessageBox();
                }
                else
                {
                    staffIDtxt.Text = staffID;
                    nametxt.Text = GlobalData.GetFullName(employee);
                    departmentTextBox.Text = employee.Department.Description;
                    unitTextBox.Text = employee.Unit.Description;
                    gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                    gradeTextBox.Text = employee.Grade.Grade;
                    txtEmploymentDate.Text = employee.EmploymentDate.ToString();

                    employee.Photo = dal.ShowImageByStaffID<Employee>(employee).Photo;
                    if (employee.Photo != null)
                    {
                        pictureBox.Image = employee.Photo;
                    }
                        var getRequests = GlobalData._context.StaffChangesRequestViews.Where(u => u.Grouping == groupID && u.Approved == false).ToList();
                        var permissions = GlobalData._context.UserAccessLevelsViews.Where(u => u.CanApproveChanges && u.UserID == GlobalData.User.ID && u.RoleName == GlobalData.Role).ToList();

                        int ctr = 0;
                        foreach (var req in getRequests)
                        {
                            foreach (var item in permissions)
                            {
                                if (req.MenuItem == item.AccessLevel2Control || req.MenuItem == item.AccessLevel3Control)
                                {
                                    gridApproval.Rows.Add(1);
                                    gridApproval.Rows[ctr].Cells["gridApprovalID"].Value = req.ID;
                                    gridApproval.Rows[ctr].Cells["gridApprovalStaffID"].Value = req.StaffID;
                                    gridApproval.Rows[ctr].Cells["gridApprovalName"].Value = GlobalData.GetFullName(req.Surname, req.Firstname, req.OtherName);
                                    gridApproval.Rows[ctr].Cells["gridApprovalSubDataset"].Value = req.Form;
                                    gridApproval.Rows[ctr].Cells["gridApprovalDataElement"].Value = req.DataElement == null ? req.Control : req.DataElement;
                                    gridApproval.Rows[ctr].Cells["gridApprovalCurrentValue"].Value = req.OldValue;
                                    gridApproval.Rows[ctr].Cells["gridApprovalNewValue"].Value = req.NewValue;
                                    gridApproval.Rows[ctr].Cells["gridApprovalReason"].Value = req.Reason;
                                    gridApproval.Rows[ctr].Cells["gridApprovalControlType"].Value = req.ControlType;
                                    gridApproval.Rows[ctr].Cells["gridApprovalDate"].Value = req.Date.ToShortDateString();
                                    gridApproval.Rows[ctr].Cells["gridApprovalOldImage"].Value = req.OldImage;
                                    gridApproval.Rows[ctr].Cells["gridApprovalNewImage"].Value = req.NewImage;
                                    gridApproval.Rows[ctr].Cells["gridApprovalRequestType"].Value = requestType;
                                    ctr++;
                                }
                            }
                        }
                }
                gridApprovalDecision.Items.Add("APPROVE");
                gridApprovalDecision.Items.Add("REJECT");

                tabControl1.SelectedTab = tabPage2;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridApproval_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var controlType = gridApproval.SelectedRows[0].Cells["gridApprovalControlType"].Value;
                if (gridApproval.SelectedRows[0].Cells["gridApprovalControlType"].Value != null)
                {
                    HideControls(controlType.ToString());
                }

                txtSubDataset.Text = gridApproval.SelectedRows[0].Cells["gridApprovalSubDataset"].Value.ToString();
                txtDataElement.Text = gridApproval.SelectedRows[0].Cells["gridApprovalDataElement"].Value == null ? "" : gridApproval.SelectedRows[0].Cells["gridApprovalDataElement"].Value.ToString();

                if (controlType != null && controlType.ToString() == "picturebox")
                {
                    pbOldValue.Image = GlobalData.ArrayToImage(gridApproval.SelectedRows[0].Cells["gridApprovalOldImage"].Value);
                    pbNewValue.Image = GlobalData.ArrayToImage(gridApproval.SelectedRows[0].Cells["gridApprovalNewImage"].Value);
                }
                else
                {
                    txtOldValue.Text = gridApproval.SelectedRows[0].Cells["gridApprovalCurrentValue"].Value.ToString();
                    txtNewValue.Text = gridApproval.SelectedRows[0].Cells["gridApprovalNewValue"].Value.ToString();
                }

                txtReason.Text = gridApproval.SelectedRows[0].Cells["gridApprovalReason"].Value == null ? "" : gridApproval.SelectedRows[0].Cells["gridApprovalReason"].Value.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw;
            }
        }

        private void HideControls(string controlType)
        {
            if (controlType == "picturebox")
            {
                pbOldValue.Visible = true;
                pbNewValue.Visible = true;

                txtNewValue.Visible = false;
                txtOldValue.Visible = false;
            }
            else
            {
                pbOldValue.Visible = false;
                pbNewValue.Visible = false;

                txtNewValue.Visible = true;
                txtOldValue.Visible = true;
            }
            
        }

        private void ClearApprovalPage()
        {
            pictureBox.Image = pictureBox.InitialImage;
            staffIDtxt.Text = string.Empty;
            nametxt.Text = string.Empty;
            departmentTextBox.Text = string.Empty;
            unitTextBox.Text = string.Empty;
            gradeCategoryTextBox.Text = string.Empty;
            gradeTextBox.Text = string.Empty;
            txtEmploymentDate.Text = string.Empty;

            txtSubDataset.Text = string.Empty;
            txtDataElement.Text = string.Empty;
            txtOldValue.Text = string.Empty;
            txtNewValue.Text = string.Empty;

            pbOldValue.Image = pbOldValue.InitialImage;
            pbNewValue.Image = pbNewValue.InitialImage;

            txtReason.Text = string.Empty;

            gridApproval.Rows.Clear();
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {

        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridApproval.Rows.Clear();
                var groupID = grid.CurrentRow.Cells["gridGroupID"].Value.ToString();
                var staffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                //string reqType = grid.CurrentRow.Cells["gridRequestType"].Value.ToString();
                //requestType = grid.CurrentRow.Cells["gridRequestType"].Value.ToString();
                LoadApprovalPage(staffID, groupID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Clear()
        {
            staffIDtxt.Text = string.Empty;
            nametxt.Text = string.Empty;
            departmentTextBox.Text = string.Empty;
            unitTextBox.Text = string.Empty;
            gradeCategoryTextBox.Text = string.Empty;
            gradeTextBox.Text = string.Empty;
            txtEmploymentDate.Text = string.Empty;
            gridApproval.Rows.Clear();
            txtSubDataset.Text = string.Empty;
            txtDataElement.Text = string.Empty;
            txtOldValue.Text = string.Empty;
            txtNewValue.Text = string.Empty;
            pbOldValue.Image = pbOldValue.InitialImage;
            pbNewValue.Image = pbNewValue.InitialImage;
            pictureBox.Image = pictureBox.InitialImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GlobalData.QuestionMessage("Do you want to save this changes??") == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in gridApproval.Rows)
                    {
                        if (row.Cells["gridApprovalDecision"].Value != null)
                        {
                                var getRequest = GlobalData._context.StaffChangesRequests.SingleOrDefault
                                (u => u.ID.ToString() == row.Cells["gridApprovalID"].Value.ToString() && u.Archived == false);

                                getRequest.Approved = true;
                                getRequest.ApprovedBy = GlobalData.User.Name;

                                var approval = new DataReference.StaffChangesApproval
                                {
                                    ChangeRequestID = getRequest.ID,
                                    StaffID = getRequest.StaffID,
                                    Decision = row.Cells["gridApprovalDecision"].Value.ToString(),
                                    SubDatasetID = getRequest.SubDatasetID,
                                    DataElementID = getRequest.DataElementID,
                                    OldValue = getRequest.OldValue,
                                    NewValue = getRequest.NewValue,
                                    Reason = "",
                                    UserId = GlobalData.User.ID,
                                    Archived = false,
                                    Decided = true,
                                    DecisionDate = DateTime.Today,
                                    DecidedBy = GlobalData.User.ID.ToString(),
                                    DateAndTimeGenerated = DateTime.Now,
                                };
                                GlobalData._context.StaffChangesApprovals.InsertOnSubmit(approval);

                                if (row.Cells["gridApprovalDecision"].Value.ToString() == "APPROVE")
                                {
                                if (getRequest.ChangeID != 0 && getRequest.ChangeID != null)
                                    CommitTransChanges(getRequest);
                                else
                                    CommitChanges(getRequest);
                                }
                        }
                    }
                    GlobalData._context.SubmitChanges();
                    Clear();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void CommitChanges(DataReference.StaffChangesRequest req)
        {
            try
            {
                var getDataElement = GlobalData._context.EnforceDataElements.SingleOrDefault(u => u.ID == req.DataElementID);

                ComboDataMapper cdm = new ComboDataMapper();

                if (getDataElement == null)
                {
                    return;
                }

                if (getDataElement.ControlType == "datetimepicker")
                {
                    cdm.UpdateDate(getDataElement.StaffDataColumn, getDataElement.StaffDataTable, req.StaffID, Convert.ToDateTime(req.NewValue));
                }else if (getDataElement.ControlType == "picturebox")
                {
                    cdm.UpdateImage(getDataElement.StaffDataColumn, req.StaffID, req.NewImage.ToArray());
                }
                else if(getDataElement.ControlType == "combobox")
                {
                    cdm.UpdateComboText(getDataElement.StaffDataColumn, null, req.StaffID, req.NewValueID.ToString());
                }
                else
                {
                    cdm.UpdateText(getDataElement.StaffDataColumn, getDataElement.StaffDataTable,  req.StaffID, req.NewValue);
                }

            }   
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void CommitTransChanges(DataReference.StaffChangesRequest req)
        {
            try
            {
                var getDataElement = GlobalData._context.EnforceDataElementsViews.SingleOrDefault(u => u.Name == req.Control && u.DatasetID == req.DatasetID);

                ComboDataMapper cdm = new ComboDataMapper();

                if (getDataElement == null)
                 {
                    return;
                }

                if (getDataElement.ControlType == "datetimepicker")
                {
                    cdm.UpdateDateTrans(getDataElement.StaffDataColumn, getDataElement.StaffDataTable, Convert.ToDecimal(req.ChangeID), Convert.ToDateTime(req.NewValue));
                }
                else
                {
                    cdm.UpdateText(getDataElement.StaffDataColumn, getDataElement.StaffDataTable, Convert.ToDecimal(req.ChangeID), req.NewValue);
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            GetAll();
        }
    }
}
