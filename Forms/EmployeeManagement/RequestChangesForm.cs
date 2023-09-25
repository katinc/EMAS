using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using eMAS.Forms.ClaimsLeaveHirePurchase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using eMAS.Forms.EmployeeManagement;
using HRBussinessLayer.Validation;
using HRBussinessLayer;
using eMAS.Forms.SystemSetup;
using System.IO;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class RequestChangesForm : Form
    {
        private IList<Employee> employees;
        private IList<JobTitle> jobTitles;
        private IDAL dal;
        private bool editMode;
        private Company company;
        private Employee employee;
        private int ctr;
        private int staffCode;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        private string selectedControlType;
        OpenFileDialog pictureDialog = new OpenFileDialog();
        FileStream fs;
        BinaryReader br;
        int numBytes;
        byte[] buff;

        public Permissions permissions;

        public RequestChangesForm()
        {
            try
            {
                InitializeComponent();
                this.employees = new List<Employee>();
                this.jobTitles = new List<JobTitle>();
                this.dal = new DAL();
                this.editMode = false;
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffCode = 0;
                this.selectedControlType = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    //Clear();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            if (employee.Photo != null)
                            {
                                pictureBox.Image = employee.Photo;
                            }
                            else
                            {
                                pictureBox.Image = pictureBox.InitialImage;
                            }
                            searchGrid.Visible = false;
                            groupBox2.Enabled = true;
                            departmentTextBox.Text = employee.Department.Description;
                            unitTextBox.Text = employee.Unit.Description;
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                            gradeTextBox.Text = employee.Grade.Grade;
                            if (employee.EmploymentDate == null)
                            {
                                txtEmploymentDate.Text = string.Empty;
                            }
                            else
                            {
                                txtEmploymentDate.Text = employee.EmploymentDate.Value.Date.ToString("dd/MM/yyyy");
                            }
                            employee.Photo = dal.ShowImageByStaffID<Employee>(employee).Photo;
                            if (employee.Photo != null)
                            {
                                pictureBox.Image = employee.Photo;
                            }

                            //check if user has permissions to edit
                            var permission = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u=>u.UserID == GlobalData.User.ID && u.AccessLevel2Control == "employeeToolStripMenuItem" && u.RoleName == GlobalData.User.UserRole);

                            if (permission != null && rbEdit.Checked && permission.CanEdit)
                            {
                                HideControls("combobox");
                                LoadSubDatasets();
                            }
                            else
                            {
                                HideControls("all");
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
                        errorProvider.Clear();
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
                    ClearStaff();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ClearStaff()
        {
            searchGrid.Visible = false;
            staffIDtxt.Select();
            staffIDtxt.Clear();
            staffCode = 0;
            nametxt.Clear();
            txtEmploymentDate.Text = string.Empty;
        }

        #region CLEAR
        private void Clear()
        {
            try
            {
                editMode = false;
                cboReason.Text = string.Empty;
                searchGrid.Visible = false;
                staffIDtxt.Select();
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                txtEmploymentDate.Text = string.Empty;
                gradeCategoryTextBox.Text = string.Empty;
                gradeTextBox.Text = string.Empty;
                departmentTextBox.Text = string.Empty;
                unitTextBox.Text = string.Empty;
                label8.Text = "Request Staff Detail Changes";
                groupBox2.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                pbCurrentValue.Image = pbCurrentValue.InitialImage;
                pbNewValue.Image = pbNewValue.InitialImage;
                grid.Rows.Clear();
                cboDataElement.SelectedText = string.Empty;
                cboSubDataset.SelectedText = string.Empty;
                cmbNewValue.SelectedText = string.Empty;
                txtNewValue.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void RequestChangesForm_Load(object sender, EventArgs e)
        {
            try
            {
                rbEdit.Checked = true;
                groupBox2.Visible = true;
                groupBox4.Visible = false;

                permissions = GlobalData.CheckPermissions(3);
                btnSave.Enabled = permissions.CanAdd;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void LoadSubDatasets()
        {
            try
            {
                var subDatasets = GlobalData._context.EnforceSubDatasets.Where(u => u.IsActive == true && u.DatasetID == 13 && u.IsActive == true).ToList();

                cboSubDataset.Items.Clear();

                //foreach (var item in subDatasets)
                //{
                    cboSubDataset.DataSource = subDatasets;
                    cboSubDataset.ValueMember = "ID";
                    cboSubDataset.DisplayMember = "Description";

                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void LoadDataElements()
        {
            try
            {   
                var dataElements = GlobalData._context.EnforceDataElementsViews.Where(u => u.IsActive && u.SubDatasetID.ToString() == cboSubDataset.SelectedValue.ToString() && u.IsActive == true).OrderBy(u=>u.Description).ToList();
                cboDataElement.DataSource = null;

                foreach (var item in dataElements)
                {
                    //cboDataElement.Items.Add(item.Description);
                    cboDataElement.DataSource = dataElements;
                    cboDataElement.ValueMember = "ID";
                    cboDataElement.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboSubDataset_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cboDataElement.SelectedText = string.Empty; 
            LoadDataElements();
        }

        private void HideControls(string controlType)
        {
            txtCurrentValue.Clear();
            cmbNewValue.ResetText();
            txtNewValue.Clear();
            dateNewValue.ResetText();
            pbCurrentValue.Image = pbCurrentValue.InitialImage;
            pbNewValue.Image = pbNewValue.InitialImage;


            if (controlType == "datetimepicker")
            {
                txtCurrentValue.Visible = true;
                dateNewValue.Visible = true;
                txtNewValue.Visible = false;

                pbCurrentValue.Visible = false;
                cmbNewValue.Visible = false;
                pbNewValue.Visible = false;
                btnUpload.Visible = false;
                groupBox2.Enabled = true;
            }
            else if (controlType == "textbox")
            {
                txtCurrentValue.Visible = true;
                cmbNewValue.Visible = false;
                txtNewValue.Visible = true;
                dateNewValue.Visible = false;
                pbCurrentValue.Visible = false;
                pbNewValue.Visible = false;
                btnUpload.Visible = false;
                groupBox2.Enabled = true;
            }
            else if (controlType == "picturebox")
            {
                txtCurrentValue.Visible = false;
                cmbNewValue.Visible = false;
                txtNewValue.Visible = false;
                dateNewValue.Visible = false;
                pbCurrentValue.Visible = true;
                pbNewValue.Visible = true;
                btnUpload.Visible = true;
                groupBox2.Enabled = true;
            }
            else if (controlType == "combobox")
            {
                txtCurrentValue.Visible = true;
                cmbNewValue.Visible = true;
                txtNewValue.Visible = false;
                dateNewValue.Visible = false;
                pbCurrentValue.Visible = false;
                pbNewValue.Visible = false;
                btnUpload.Visible = false;

                groupBox2.Enabled = true;
            }
            else if (controlType == "all")
            {
                txtCurrentValue.Visible = true;
                cmbNewValue.Visible = true;
                txtNewValue.Visible = false;
                dateNewValue.Visible = false;
                pbCurrentValue.Visible = false;
                pbNewValue.Visible = false;
                btnUpload.Visible = false;

                groupBox2.Enabled = false;

                MessageBox.Show("You do not have permission to make changes. \n" +
                    "Contact your Administrator if this is a mistake.");
            }
        }

        private void DisableControls(bool bol)
        {
            txtCurrentValue.Visible = !bol;
            cmbNewValue.Visible = !bol;
            txtNewValue.Visible = !bol;
            dateNewValue.Visible = !bol;
            pbCurrentValue.Visible = !bol;
            pbNewValue.Visible = !bol;
            btnUpload.Visible = !bol;
        }

        private void cboDataElement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text != string.Empty && staffIDtxt.Text != null)
                {
                    var staffinfo = GlobalData._context.StaffPersonalInfoViews.FirstOrDefault(u=> u.StaffID == staffIDtxt.Text && u.Archived == false && u.Terminated == false && u.Confirmed == true && u.TransferredOut);
                }

                foreach (DataReference.EnforceDataElementsView item in cboDataElement.Items)
                {
                    if (cboDataElement.SelectedItem == item)
                    {
                        HideControls(item.ControlType);
                        selectedControlType = item.ControlType;

                        if (item.ControlType == "combobox")
                        {

                            ComboDataMapper cdm = new ComboDataMapper();
                            var listOfSth = cdm.GetElements(item.ComboDataTable);

                            cmbNewValue.DataSource = null;
                            cmbNewValue.Text = string.Empty;

                            if (listOfSth.Count > 0)
                            {

                                //cmbNewValue.Items.Add(items.Description);
                                cmbNewValue.DataSource = listOfSth;
                                cmbNewValue.DisplayMember = "Description";
                                cmbNewValue.ValueMember = "ID";

                            }
                        }
                        LoadCurrentValue(item.ID.ToString());
                    }
                }


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void LoadCurrentValue(string ElementID)
        {
            try
            {
                var getDataElement = GlobalData._context.EnforceDataElements.SingleOrDefault(u=>u.ID.ToString() == ElementID);

                if (getDataElement.StaffDataTable == null)
                {
                    getDataElement.StaffDataTable = "StaffPersonalInfoView";
                }

                ComboDataMapper cdm = new ComboDataMapper();
                var stringOfSth = cdm.GetCurrentValue(getDataElement.StaffDataTable, getDataElement.StaffDataView, staffIDtxt.Text);

                if (getDataElement.ControlType == "picturebox")
                {
                    //System.Data.Linq.Binary test = (System.Data.Linq.Binary)stringOfSth;
                    byte[] bytes = (byte[])stringOfSth;
                    MemoryStream ms = new MemoryStream(bytes);

                    pbCurrentValue.Image = Image.FromStream(ms);
                }
                else if (getDataElement.ControlType == "datetimepicker")
                {
                    txtCurrentValue.Text = Convert.ToDateTime(stringOfSth).ToShortDateString();
                }
                else
                {
                    txtCurrentValue.Text = stringOfSth.ToString();
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmbNewValue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                pictureDialog.Multiselect = false;
                pictureDialog.RestoreDirectory = true;
                pictureDialog.Title = "Select A Picture";
                pictureDialog.AutoUpgradeEnabled = true;
                pictureDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                pictureDialog.Filter = "Image Files(*.JPE;*.JPEG;*.JFIF;*.JPG;*.EXIF;*.TIFF;*.TIF;*.PAW;*.PNG;*.GIF;*.BMP;*.PPM;*.PGM;*.PBM;*.PNM;*.CGM;*.SVG)|*.JPE;*.JPEG;*.JFIF;*.JPG;*.EXIF;*.TIFF;*.TIF;*.PAW;*.PNG;*.GIF;*.BMP;*.PPM;*.PGM;*.PBM;*.PNM;*.CGM;*.SVG|All Files(*.*)|*.*";
                pictureDialog.CheckFileExists = true;
                if (pictureDialog.ShowDialog(this) == DialogResult.OK)
                {
                    pbNewValue.Image = Image.FromFile(pictureDialog.FileName);
                    pbNewValue.ImageLocation = pictureDialog.FileName;
                    //pictureBox.Image = resizeImage(pictureBox.Image, new Size(80, 80));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboReason_DropDown(object sender, EventArgs e)
        {
            cboReason.Items.Clear();
            var reasons = GlobalData._context.StaffChangesRequestReasons.Where(u=>u.Archived == false && u.Active == true).ToList();

            foreach (var row in reasons)
            {
                cboReason.Items.Add(row.Descripion);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateAdd())
                { 
                    grid.Rows.Add(1);
                    grid.Rows[grid.RowCount - 1].Cells["gridId"].Value = 0;
                    grid.Rows[grid.RowCount - 1].Cells["gridStaffID"].Value = staffIDtxt.Text;
                    grid.Rows[grid.RowCount - 1].Cells["gridStaffName"].Value = nametxt.Text;
                    grid.Rows[grid.RowCount - 1].Cells["gridSubDataset"].Value = cboSubDataset.Text;
                    grid.Rows[grid.RowCount - 1].Cells["gridCurrentValue"].Value = selectedControlType != "picturebox" ? txtCurrentValue.Text : staffIDtxt.Text + " : Profile Image";
                    grid.Rows[grid.RowCount - 1].Cells["gridNewValue"].Value = selectedControlType == "combobox" ? cmbNewValue.Text : selectedControlType == "textbox" ? txtNewValue.Text : selectedControlType == "picturebox" ? pbNewValue.ImageLocation : selectedControlType == "datetimepicker" ? dateNewValue.Value.ToShortDateString() : "";
                    grid.Rows[grid.RowCount - 1].Cells["gridReason"].Value = cboReason.Text;
                    grid.Rows[grid.RowCount - 1].Cells["gridSubDatasetID"].Value = cboSubDataset.SelectedValue;
                    grid.Rows[grid.RowCount - 1].Cells["gridDataElementId"].Value = cboDataElement.SelectedValue;
                    grid.Rows[grid.RowCount - 1].Cells["gridDataElement"].Value = cboDataElement.Text;
                    grid.Rows[grid.RowCount - 1].Cells["gridNewValueID"].Value = selectedControlType == "combobox" ? cmbNewValue.SelectedValue : null;
                    grid.Rows[grid.RowCount - 1].Cells["gridControlType"].Value = selectedControlType;
                    grid.Rows[grid.RowCount - 1].Cells["gridOldImage"].Value = selectedControlType == "picturebox" ? GlobalData.ImageToArray(pbCurrentValue.Image) : null ;
                    grid.Rows[grid.RowCount - 1].Cells["gridNewImage"].Value = selectedControlType == "picturebox" ? GlobalData.ImageToArray(pbNewValue.Image) : null; 
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void UpdateRequestEntity()
        {
            throw new NotImplementedException();
        }

        private bool ValidateAdd()
        {
            bool result = true;
            try
            {
                if (staffIDtxt.Text.Trim() == string.Empty || nametxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(staffIDtxt, "Please set the user details");
                    staffIDtxt.Focus();
                }
                else if (cboSubDataset.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboSubDataset, "Kindly choose a SubDataset");
                    cboSubDataset.Focus();
                }
                else if (cboDataElement.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboDataElement, "Kindly choose a cboDataElement");
                    cboDataElement.Focus();
                }
                else if (cboReason.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboReason, "Please give a reason for the change request");
                    cboReason.Focus();
                }
                
                if (selectedControlType == "textbox" && txtNewValue.Text == string.Empty)
                {
                    result = false;
                    HideControls("textbox");
                    errorProvider.SetError(txtNewValue, "Please enter a new value");
                    txtNewValue.Focus();
                }
                else if (selectedControlType == "combobox" && cmbNewValue.Text == string.Empty)
                {
                    result = false;
                    HideControls("combobox");
                    errorProvider.SetError(cmbNewValue, "Please select a new value");
                    cmbNewValue.Focus();
                }
                //else if (selectedControlType == "datetimepicker" && dateNewValue.Text == string.Empty)
                //{
                //    result = false;
                //    HideControls("datetimepicker");
                //    errorProvider.SetError(dateNewValue, "Please enter a new date");
                //    dateNewValue.Focus();
                //}
                else if (selectedControlType == "picturebox" && pbNewValue.Image == pbNewValue.InitialImage)
                {
                    result = false;
                    HideControls("picturebox");
                    errorProvider.SetError(pbNewValue, "Please upload a new image");
                    pbNewValue.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private bool ValidateSave()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var grouping = Guid.NewGuid().ToString();
                if (true)
                {
                    ctr = 0;
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        var controlType = grid.Rows[ctr].Cells["gridControlType"].Value.ToString();
                        if (controlType  == "picturebox")
                        {
                            fs = new FileStream(pictureDialog.FileName, FileMode.Open, FileAccess.Read);
                            br = new BinaryReader(fs);
                            numBytes = (int)new FileInfo(pictureDialog.FileName).Length;
                            buff = br.ReadBytes(numBytes);
                        }

                        var dataElementId = Convert.ToDecimal(grid.Rows[ctr].Cells["gridDataElementId"].Value.ToString());
                        var dataElement = GlobalData._context.EnforceDataElementsViews.SingleOrDefault(u => u.ID == dataElementId);

                        var newRequest = new DataReference.StaffChangesRequest
                        {
                            StaffID = staffIDtxt.Text,
                            DatasetID = dataElement.DatasetID,
                            Form = dataElement.DatasetName,
                            ChangeID = employee.ID,
                            Control = dataElement.ControlType,
                            SubDatasetID = Convert.ToDecimal(grid.Rows[ctr].Cells["gridSubDatasetID"].Value.ToString()),
                            DataElementID = dataElementId,
                            OldValue = grid.Rows[ctr].Cells["gridCurrentValue"].Value.ToString(),
                            NewValue = grid.Rows[ctr].Cells["gridNewValue"].Value.ToString(),
                            UserId = GlobalData.User.ID,
                            Archived = false,
                            DateAndTimeGenerated = DateTime.Now,
                            Date = DateTime.Now,
                            Approved = false,
                            ApprovedBy = "",
                            Grouping = grouping.ToString(),
                            Reason = grid.Rows[ctr].Cells["gridReason"].Value.ToString(),
                            NewValueID = grid.Rows[ctr].Cells["gridNewValueID"].Value == null ? 0 : Convert.ToDecimal(grid.Rows[ctr].Cells["gridNewValueID"].Value.ToString()),
                            ControlType = controlType,
                            OldImage = (byte[])grid.Rows[ctr].Cells["gridOldImage"].Value,
                            NewImage = (byte[])grid.Rows[ctr].Cells["gridNewImage"].Value,
                        };
                        ctr++;
                        GlobalData._context.StaffChangesRequests.InsertOnSubmit(newRequest);
                    }
                    GlobalData._context.SubmitChanges();
                    AppUtils.SuccessMessageBox("Requests Submitted Successfully");
                }
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnReasonsView_Click(object sender, EventArgs e)
        {
            RequestReasons form = new RequestReasons();
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }
    }
}
