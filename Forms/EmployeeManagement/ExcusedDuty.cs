using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;
using eMAS.Forms.Reports;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ExcusedDuty : Form
    {
        private ExcuseDutyRequestTypeDataMapper excuseDutyRequestTypeMapper;
        private  List<ExcuseDutyRequestType> requestTypes;
        private Company company;
        private IDAL dal;
        private int ctr;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private bool editMode=false;
        private int staffCode;
        private Employee selectedEmployee;
        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        private DALHelper dalHelper;
        public ExcuseDutyRequest selectedExcusedDutyRequest;
        List<Control> controls;
        List<controlObject> OldValues;

        public ExcusedDuty()
        {
            InitializeComponent();
            this.excuseDutyRequestTypeMapper = new ExcuseDutyRequestTypeDataMapper();
            this.company = new Company();
            this.dal = new DAL();
            this.employees = new List<Employee>();
            this.employeeList = new List<Employee>();
            this.dalHelper = new DALHelper();
            this.selectedExcusedDutyRequest = new ExcuseDutyRequest();
            controls = new List<Control>();
            OldValues = new List<controlObject>();

        }

        public void cmbRequestType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbRequestType.DataSource = null;
                requestTypes = excuseDutyRequestTypeMapper.getAll(GlobalData.User.ID);

                cmbRequestType.DataSource = requestTypes;
                cmbRequestType.DisplayMember = "description";
                cmbRequestType.ValueMember = "ID";
            }
            catch (Exception exii) { }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Clear()
        {
            try
            {
                editMode = false;
                staffIDtxt.Clear();
                nametxt.Clear();
                gendertxt.Clear();
                agetxt.Clear();
              
                dtpStartDate.Value=DateTime.Now;
                dtpStartDate.Checked = false;
                dtpEndDate.Value=DateTime.Now;

                dtpRequestDate.Value = DateTime.Now;
              
             
                txtLeaveDue.Text = string.Empty;
                txtAnnualLeaveYear.Clear();
                txtLeaveArrears.Clear();
               
                //label1.Text = "New Leave";
                groupBox1.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
              
                departmentTextBox.Clear();
                staffErrorProvider.Clear();

                txtEmail.Clear();
                txtPhoneNo.Clear();
                txtCurrentGrade.Clear();
                numericUpDownNumberOfDays.ResetText();
                cmbRequestType.DataSource = null;
                cmbRequestType.ResetText();
                txtFileName.Clear();
                txtSpecifyOther.Clear();
                //editMode = false;
                //selectedExcusedDutyRequest = new ExcuseDutyRequest();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                            
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            
                            departmentTextBox.Text = employee.Department.Description;
                           

                            txtLeaveDue.Text = employee.AnnualLeave.ToString();
                            //txtAnnualEndDate.Text = employee.CurrentLeaveEndDate.ToString();
                           
                            txtAnnualLeaveYear.Text = employee.AnnualLeaveYear.ToString();

                            txtEmail.Text=  employee.Email;

                            txtPhoneNo.Text=  employee.MobileNo;
                           txtCurrentGrade.Text= employee.GradeCategory.Description;

                         
                                txtLeaveArrears.Text = employee.LeaveArrears.ToString();

                                selectedEmployee = dal.ShowImageByStaffID<Employee>(employee);
                                pictureBox.Image = selectedEmployee.Photo;
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

        private void numericUpDownNumberOfDays_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(dtpStartDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()),false, false);
                dtpEndDate.Value =r[r.Length - 1];
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
               
                 DateTime []   r = AppUtils.getNonePublicHolidaysOWeekends(dtpStartDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), false, false);

                if (r.Count() > 0)
                    dtpEndDate.Value = r[r.Length - 1];

                //endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()) - 1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (btnBrowseFile.Text == "-")
                txtFileName.Clear();
            else
            {
                opfDialog.Filter = "Medical Excuse Duty Sheet|*.doc;*.docx;*.xls;*.xlsx;*.png;*.jpg;*.jpeg;*.bmp;*.pdf";
                if (opfDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = opfDialog.FileName;
                    btnBrowseFile.Visible = true;
                }
            }
        }

        private void cmbRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRequestType.Text.ToLower() == "other")
            {
                lblspecifyother.Visible = true;
                txtSpecifyOther.Visible = true;
            }
            
            else
            {
                if (cmbRequestType.Text.ToLower() == "medical")
                {
                    btnBrowseFile.Enabled = true;
                }
                else
                    btnBrowseFile.Enabled = false;

                lblspecifyother.Visible = false;
                txtSpecifyOther.Visible = false;
            }
        }

        private void ExcusedDuty_Load(object sender, EventArgs e)
        {
            lblspecifyother.Visible = false;
            txtSpecifyOther.Visible = false;
            dtpRequestDate.Value=dtpStartDate.Value = DateTime.Now.Date;
            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                savebtn.Enabled = getPermissions.CanAdd;
                findbtn.Enabled = getPermissions.CanView;
                btnPreviewSheet.Enabled = getPermissions.CanView;
                btnPreview.Enabled = getPermissions.CanView;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }

            //GlobalData.assignControls(this);

        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text != string.Empty){
                btnBrowseFile.Text = "-";
                btnPreviewSheet.Visible = true;
            }
                
            else{
                btnBrowseFile.Text = "+";
                btnPreviewSheet.Visible = false;
            }
           
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string leaveArrears = "Have taken none";
            try {

                if (txtLeaveArrears.Text != string.Empty)
                {
                    if (Convert.ToInt32(txtLeaveArrears.Text) > 0 && Convert.ToInt32(txtLeaveArrears.Text) < Convert.ToInt32(txtLeaveDue.Text))
                        leaveArrears = "Have taken part";
                    else if (Convert.ToInt32(txtLeaveArrears.Text) == 0)
                        leaveArrears = "Have taken all";
                }

              
                if (staffIDtxt.Text == string.Empty)
                    staffErrorProvider.SetError(staffIDtxt, "Staff ID is required!");
                else if (txtCurrentGrade.Text == string.Empty)
                    staffErrorProvider.SetError(txtCurrentGrade, "Current grade is required!");
                else if (departmentTextBox.Text == string.Empty)
                    staffErrorProvider.SetError(departmentTextBox, "Department is required!");
                else if (cmbRequestType.Text == string.Empty)
                    staffErrorProvider.SetError(cmbRequestType, "Request type is required!");
                else if (dtpRequestDate.Value.Date > dtpStartDate.Value.Date)
                    staffErrorProvider.SetError(dtpRequestDate, "Request date cannot be greater than start date!");
                else if(dtpStartDate.Value.Date>dtpEndDate.Value.Date)
                    staffErrorProvider.SetError(dtpStartDate, "Start date cannot be greater than end date!");

                    ///else if (txtEndDate.Text == string.Empty)
                //    staffErrorProvider.SetError(txtEndDate, "End Date is required!");
                else if (hasActiveRequest(selectedEmployee.ID,selectedExcusedDutyRequest.id) == true) 
                    staffErrorProvider.SetError(savebtn,"Selected employee already has an active request");
                else if(editMode==false)
                {
                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();

                    dalHelper.CreateParameter("@StaffId", selectedEmployee.ID, DbType.Int32);
                    dalHelper.CreateParameter("@GradeCategoryId", selectedEmployee.GradeCategory.ID, DbType.Int32);
                    dalHelper.CreateParameter("@DepartmentId", selectedEmployee.Department.ID, DbType.Int32);
                    dalHelper.CreateParameter("@LeaveStatus", leaveArrears, DbType.String);
                    dalHelper.CreateParameter("@RequestTypeId", requestTypes[cmbRequestType.SelectedIndex].id, DbType.Int32);
                    dalHelper.CreateParameter("@SpecifyOther", txtSpecifyOther.Text, DbType.String);
                    dalHelper.CreateParameter("@StartDate", dtpStartDate.Value, DbType.DateTime);
                    dalHelper.CreateParameter("@EndDate", dtpEndDate.Value, DbType.DateTime);
                    dalHelper.CreateParameter("@RequestDate", dtpRequestDate.Value.Date, DbType.DateTime);
                    dalHelper.CreateParameter("@Returned", false, DbType.Boolean);
                    dalHelper.CreateParameter("@LeaveYear",Convert.ToInt32(txtAnnualLeaveYear.Text), DbType.Int32);
                    dalHelper.CreateParameter("@NumOfDays",numericUpDownNumberOfDays.Value, DbType.Int32);
                    dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                    dalHelper.CreateParameter("@Recommended", false, DbType.Boolean);
                    dalHelper.CreateParameter("@HRRecommended", false, DbType.Boolean);
                    dalHelper.CreateParameter("@Approved", false, DbType.Boolean);


                    var sql = "insert into ExcusedDutyRequest (StaffId,GradeCategoryId,DepartmentId,LeaveStatus,RequestTypeId,SpecifyOther,StartDate,EndDate,RequestDate,ExcuseDutySheet,ExcuseDutyFileName,Returned,LeaveYear,NumOfDays,Active, Recommended, HRRecommended, Approved) values (@StaffId,@GradeCategoryId,@DepartmentId,@LeaveStatus,@RequestTypeId,@SpecifyOther,@StartDate,@EndDate,@RequestDate,@ExcuseDutySheet,@ExcuseDutyFileName,@Returned,@LeaveYear,@NumOfDays,@Active, @Recommended, @HRRecommended, @Approved)";
                    if (txtFileName.Text.Trim() != "")
                    {
                        dalHelper.CreateParameter("@ExcuseDutySheet", AppUtils.FileGetBytes(txtFileName.Text), DbType.Binary);

                        String [] fileNameSplit=txtFileName.Text.Split(new char[] {'\\'});
                        dalHelper.CreateParameter("@ExcuseDutyFileName", fileNameSplit[fileNameSplit.Length-1], DbType.String);
                    }
                    else
                    {
                        //dalHelper.CreateParameter("@ExcuseDutySheet", null, DbType.Binary);
                        //dalHelper.CreateParameter("@ExcuseDutyFileName",null, DbType.String);
                        sql = "insert into ExcusedDutyRequest (StaffId,GradeCategoryId,DepartmentId,LeaveStatus,RequestTypeId,SpecifyOther,StartDate,EndDate,RequestDate,Returned,LeaveYear,NumOfDays,Active, Recommended, HRRecommended, Approved) values (@StaffId,@GradeCategoryId,@DepartmentId,@LeaveStatus,@RequestTypeId,@SpecifyOther,@StartDate,@EndDate,@RequestDate,@Returned,@LeaveYear,@NumOfDays,@Active, @Recommended, @HRRecommended, @Approved)";
                    }
                    dalHelper.ExecuteNonQuery(sql);
                    MessageBox.Show("Record saved successfully!", "Information!");
                    Clear();
                }
                else if (editMode == true && selectedExcusedDutyRequest != null)
                {
                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@StaffId", selectedExcusedDutyRequest.Employee.ID, DbType.Int32);
                    dalHelper.CreateParameter("@GradeCategoryId", selectedExcusedDutyRequest.Employee.GradeCategory.ID, DbType.Int32);
                    dalHelper.CreateParameter("@DepartmentId", selectedExcusedDutyRequest.Employee.Department.ID, DbType.Int32);
                    dalHelper.CreateParameter("@LeaveStatus", leaveArrears, DbType.String);
                    dalHelper.CreateParameter("@RequestTypeId", new ExcuseDutyRequestType().getRequestId(requestTypes, cmbRequestType.Text), DbType.String);
                    dalHelper.CreateParameter("@SpecifyOther", txtSpecifyOther.Text, DbType.String);
                    dalHelper.CreateParameter("@StartDate", dtpStartDate.Value, DbType.DateTime);
                    dalHelper.CreateParameter("@EndDate",dtpEndDate.Value, DbType.DateTime);
                    dalHelper.CreateParameter("@RequestDate", dtpRequestDate.Value.Date, DbType.DateTime);
                    dalHelper.CreateParameter("@Returned", false, DbType.Boolean);
                    dalHelper.CreateParameter("@LeaveYear", Convert.ToInt32(txtAnnualLeaveYear.Text), DbType.Int32);
                    dalHelper.CreateParameter("@NumOfDays", numericUpDownNumberOfDays.Value, DbType.Int32);
                    dalHelper.CreateParameter("@Active",true, DbType.Boolean);
                    
                    dalHelper.CreateParameter("@id", selectedExcusedDutyRequest.id, DbType.Int32);

                    String  fileName = string.Empty;
                  
                    if (txtFileName.Text.Trim() != "" && File.Exists(txtFileName.Text))
                    {
                             var sheetBytes = AppUtils.FileGetBytes(txtFileName.Text);
                                selectedExcusedDutyRequest.ExcuseDutySheet = sheetBytes;
                                String[] fileNameSplit = txtFileName.Text.Split(new char[] { '\\' });
                                selectedExcusedDutyRequest.ExcuseDutyFileName = fileNameSplit[fileNameSplit.Length - 1];
                     }

                    //dalHelper.CreateParameter("@ExcuseDutySheet", selectedExcusedDutyRequest.ExcuseDutySheet, DbType.Binary);
                    //dalHelper.CreateParameter("@ExcuseDutyFileName", selectedExcusedDutyRequest.ExcuseDutyFileName, DbType.String);


                    //dalHelper.ExecuteNonQuery("update ExcusedDutyRequest set StaffId=@StaffId,GradeCategoryId=@GradeCategoryId,DepartmentId=@DepartmentId,LeaveStatus=@LeaveStatus,RequestTypeId=@RequestTypeId,SpecifyOther=@SpecifyOther,StartDate=@StartDate,EndDate=@EndDate,RequestDate=@RequestDate,ExcuseDutySheet=@ExcuseDutySheet,ExcuseDutyFileName=@ExcuseDutyFileName,Returned=@Returned,LeaveYear=@LeaveYear,NumOfDays=@NumOfDays,Active=@Active where id=@id");
                    GlobalData.ProcessEdit(OldValues, controls, this, selectedExcusedDutyRequest.id, staffIDtxt.Text);
                    MessageBox.Show("Record saved successfully!", "Information!");
                }
            }
            catch (Exception exi)
            {
                Logger.LogError(exi);
                MessageBox.Show(exi.Message+"\n Could not save record!", "Error!");
            }
        }

        //Check Already ExcusedDuty

        public bool hasActiveRequest(int staffId,int excusedDutyId)
        {
            dalHelper = new DALHelper();
            dalHelper.ClearParameters();
            dalHelper.CreateParameter("@StaffId", staffId, DbType.Int32);
            dalHelper.CreateParameter("@Returned", false, DbType.Boolean);

            var sql = "select count(*) as ActiveRequests from ExcusedDutyRequest where StaffId=@StaffId and Returned=@Returned";

            if (excusedDutyId > 0)
                sql += " and id<>" + excusedDutyId;

            var ActiveRequests=dalHelper.ExecuteScalar(sql);

            if (ActiveRequests != null && Convert.ToInt32(ActiveRequests) > 0)
                return true;
            else
                return false;
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
        ExcusedDutyView execusedDutyView;
        
        private void findbtn_Click(object sender, EventArgs e)
        {
            execusedDutyView = new ExcusedDutyView();
            //execusedDutyView.MdiParent = this;
            execusedDutyView.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(ExecusedDutyViewGrid_CellDoubleClick);
            execusedDutyView.removeButton.Enabled = CanDelete;
            execusedDutyView.btnOpenMedicalSheet.Enabled = CanView;
            execusedDutyView.Show(this);
        }


        private void ExecusedDutyViewGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CanEdit)
            {
                editMode = false;
                try
                {
                    if (execusedDutyView.grid.SelectedRows.Count > 0)
                    {

                        //selectedExcusedDutyRequest = new ExcuseDutyRequest();
                        selectedExcusedDutyRequest = execusedDutyView.lstExcuseDutyRequest[execusedDutyView.grid.SelectedRows[0].Index];
                        staffIDtxt.Text = selectedExcusedDutyRequest.Employee.StaffID.Trim();


                        searchGrid.Rows[0].Selected = true;
                        searchGrid_CellClick(sender, e);

                        editMode = true;
                        cmbRequestType_DropDown(sender, e);
                        cmbRequestType.Text = selectedExcusedDutyRequest.requestType.description;
                        txtFileName.Text = selectedExcusedDutyRequest.ExcuseDutyFileName;
                        txtSpecifyOther.Text = selectedExcusedDutyRequest.SpecifyOther;
                        dtpRequestDate.Value = selectedExcusedDutyRequest.RequestDate;
                        dtpStartDate.Value = selectedExcusedDutyRequest.StartDate;

                        dtpEndDate.Value = selectedExcusedDutyRequest.EndDate;
                        numericUpDownNumberOfDays.Value = selectedExcusedDutyRequest.NumOfDays;

                    }
                    else
                        selectedExcusedDutyRequest = null;
                }
                catch (Exception exii)
                {
                    Logger.LogError(exii);
                }
                OldValues = GlobalData.CloneControls(controls, this);
            }
            else
            {
                MessageBox.Show("Sorry you do not have permission to edit this data.");
                return;
            }

        }

        private void btnPreviewSheet_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFileName.Text))
                System.Diagnostics.Process.Start(txtFileName.Text);
            else if(selectedExcusedDutyRequest!=null && selectedExcusedDutyRequest.ExcuseDutyFileName!=string.Empty)
            {
                AppUtils.downloadFile(selectedExcusedDutyRequest.ExcuseDutySheet, selectedExcusedDutyRequest.ExcuseDutyFileName);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (staffIDtxt.Text == string.Empty)
                selectedExcusedDutyRequest = new ExcuseDutyRequest();
            PreviewExcusedDutyForm form = new PreviewExcusedDutyForm(selectedExcusedDutyRequest);
            form.Show(this);
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(int.Parse(numericUpDownNumberOfDays.Value.ToString()),dtpEndDate.Value, false, false);

                if (r.Count() > 0)
                    dtpStartDate.Value = r[r.Length - 1];

                //endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()) - 1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
      
    }
}
