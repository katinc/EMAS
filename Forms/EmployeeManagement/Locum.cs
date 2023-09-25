using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;
using eMAS.Forms.Reports;
using System.IO;
using eMAS.Forms.Employment;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class Locum : Form
    {
        private Company company;
        private IDAL dal;
        private int ctr;
        private IList<Employee> employees;
        private bool editMode = false;
        private int staffCode;
        private Employee selectedEmployee;
        private string FilePath;
        private byte[] fileBytes;
        private string extension;
        bool skipTextChange;

        private PDFReader reader;
        private DocForm reader1;
        private DataReference.StaffLocum locum;

        private decimal ID;
        private DataReference.StaffLocumView staffLocum;

        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        List<Control> controls;
        List<controlObject> OldValues;

        public Locum()
        {
            InitializeComponent();
            this.company = new Company();
            this.dal = new DAL();
            this.employees = new List<Employee>();
            this.skipTextChange = false;
            this.ID = 0;
            this.staffLocum = new DataReference.StaffLocumView();
            this.locum = new DataReference.StaffLocum();
            this.controls = new List<Control>();
            this.OldValues = new List<controlObject>();

        }

        private void btnPreviewSheet_Click(object sender, EventArgs e)
        {
            //if (File.Exists(txtFileName.Text))
            //    System.Diagnostics.Process.Start(txtFileName.Text);
            //else if (selectedExcusedDutyRequest != null && selectedExcusedDutyRequest.ExcuseDutyFileName != string.Empty)
            //{
            //    AppUtils.downloadFile(selectedExcusedDutyRequest.ExcuseDutySheet, selectedExcusedDutyRequest.ExcuseDutyFileName);
            //}
            try
            {
                if ((txtFileName.Text != null || txtFileName.Text != string.Empty) && (FilePath != null || FilePath != string.Empty))
                {
                    if (editMode)
                    {
                        MemoryStream ms = new MemoryStream(fileBytes);
                        string tempName = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Path.GetRandomFileName(), extension));
                        File.WriteAllBytes(tempName, fileBytes);
                        System.Diagnostics.Process.Start(tempName);

                    }
                    else
                    {
                        FileInfo fi = new FileInfo(FilePath.ToLower());
                        extension = fi.Extension.Trim(new Char[] { ' ', '*', '.' });
                        System.Diagnostics.Process.Start(FilePath);
                    }
                }
                else
                {
                    MessageBox.Show("Cross check your file and try again.", "User Error");
                }
            }
            catch (Exception ex) 
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();
            }

            
        }

        private void Locum_Load(object sender, EventArgs e)
        {
            try
            {
                //GlobalData.assignControls(this);
                // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
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
                AppUtils.ErrorMessageBox();
            }
        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
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

                            txtEmail.Text = employee.Email;

                            txtPhoneNo.Text = employee.MobileNo;
                            txtCurrentGrade.Text = employee.GradeCategory.Description;


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
                AppUtils.ErrorMessageBox();
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
                    txtFileName.Text = opfDialog.SafeFileName;
                    FilePath = opfDialog.FileName;
                    btnBrowseFile.Visible = true;
                    extension = Path.GetExtension(opfDialog.FileName).Trim(new Char[] { ' ', '*', '.' });

                    try
                    {
                        FileStream fs = new FileStream(opfDialog.FileName, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        int numBytes = (int)new FileInfo(opfDialog.FileName).Length;
                        fileBytes = br.ReadBytes(numBytes);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                        MessageBox.Show("Please ensure the file is not opened in another app. \n" +
                            "And also the file is accessible and of the right filetype", "Error Adding File");
                        txtFileName.Clear();
                    }
                    
                }
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(dtpStartDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), false, false);

                if (r.Count() > 0)
                    dtpEndDate.Value = r[r.Length - 1];

                //endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()) - 1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();

            }

        }

        private void numericUpDownNumberOfDays_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(dtpStartDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), false, false);
                dtpEndDate.Value = r[r.Length - 1];
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();

            }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(int.Parse(numericUpDownNumberOfDays.Value.ToString()), dtpEndDate.Value, false, false);

                if (r.Count() > 0)
                    dtpStartDate.Value = r[r.Length - 1];

                //endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()) - 1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();

            }
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

                dtpStartDate.Value = DateTime.Now;
                dtpStartDate.Checked = false;
                dtpEndDate.Value = DateTime.Now;

                dtpRequestDate.Value = DateTime.Now;

                txtLeaveDue.Text = string.Empty;
                txtAnnualLeaveYear.Clear();
                txtLeaveArrears.Clear();

                label1.Text = "Locum";
                groupBox1.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;

                departmentTextBox.Clear();
                staffErrorProvider.Clear();

                txtEmail.Clear();
                txtPhoneNo.Clear();
                txtCurrentGrade.Clear();
                numericUpDownNumberOfDays.ResetText();
                txtFileName.Clear();
                txtReason.Clear();
                FilePath = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();

            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();

            }
        }

        private void findbtn_Click(object sender, EventArgs e)
        {
            LocumView view = new LocumView(this);
            view.MdiParent = this.MdiParent;
            view.removeButton.Enabled = CanDelete;
            view.Show();
        }

        public bool ValidateFields()
        {
            bool result = true;

            staffErrorProvider.Clear();
            if (staffIDtxt.Text.Trim() == string.Empty)
            {
                result = false;
                staffErrorProvider.SetError(staffIDtxt, "Please Enter The Staff");
            }

            if (numericUpDownNumberOfDays.Value <= 0)
            {
                result = false;
                staffErrorProvider.SetError(numericUpDownNumberOfDays, "Please enter a valid number.");
            }

            return result;

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    var dateform = dtpEndDate.Value;
                    var dateform1 = Convert.ToDateTime(dtpStartDate.Value).Date;

                    if (editMode)
                    {
                        locum.ID = ID;
                        locum.StaffID = staffIDtxt.Text;
                        locum.StartDate = Convert.ToDateTime(dtpStartDate.Value).Date;
                        locum.EndDate = Convert.ToDateTime(dtpEndDate.Value).Date;
                        locum.EntryDate = Convert.ToDateTime(dtpRequestDate.Value).Date;
                        locum.NumberOfDays = numericUpDownNumberOfDays.Value;
                        locum.Reason = txtReason.Text;
                        locum.UserID = GlobalData.User.ID;
                        locum.Archived = false;
                        locum.DateAndTimeGenerated = DateTime.Now;
                        locum.Extension = extension;
                        locum.Path = FilePath;
                        locum.DocumentContent = fileBytes;

                        GlobalData.ProcessEdit(OldValues, controls, this, Convert.ToInt32(ID.ToString()), staffIDtxt.Text);
                        //DataReference.StaffLocum oldLocum = GlobalData._context.StaffLocums.SingleOrDefault(u=>u.ID == ID);

                        //var newValues = oldLocum.DetailedCompare(locum);

                    }
                    else
                    {
                        var Locum = new DataReference.StaffLocum
                        {
                            StaffID = staffIDtxt.Text,
                            StartDate = dtpStartDate.Value,
                            EndDate = dtpEndDate.Value,
                            EntryDate = dtpRequestDate.Value,
                            NumberOfDays = numericUpDownNumberOfDays.Value,
                            Reason = txtReason.Text,
                            UserID = GlobalData.User.ID,
                            Archived = false,
                            DateAndTimeGenerated = DateTime.Now,
                            Extension = extension,
                            Path = FilePath,
                            DocumentContent = fileBytes,

                        };
                        GlobalData._context.StaffLocums.InsertOnSubmit(Locum);
                        GlobalData._context.SubmitChanges();
                        AppUtils.SuccessMessageBox("Locum Data");
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void EditLocum(decimal ID)
        {
            try
            {
                editMode = true;
                this.ID = ID;
                staffLocum = GlobalData._context.StaffLocumViews.FirstOrDefault(u=>u.ID == ID);

                if (locum != null)
                {
                    Employee employee = new Employee();
                    employee.StaffID = staffLocum.StaffID;
                    employee = dal.LazyLoadByStaffID<Employee>(employee);
                    skipTextChange = true;
                    staffIDtxt.Text = staffLocum.StaffID;
                    searchGrid.Visible = false;
                    string fullName = staffLocum.Firstname + (staffLocum.OtherName == string.Empty ? " " : " " + staffLocum.OtherName + " ") + staffLocum.Surname;
                    nametxt.Text = fullName;
                    gendertxt.Text = staffLocum.Gender;
                    agetxt.Text = employee.Age;
                    txtEmail.Text = employee.Email;
                    txtPhoneNo.Text = employee.MobileNo;
                    txtCurrentGrade.Text = staffLocum.Grade;
                    departmentTextBox.Text = staffLocum.Department;
                    txtAnnualLeaveYear.Text = employee.AnnualLeaveYear.ToString();
                    txtLeaveArrears.Text = employee.LeaveArrears.ToString();
                    txtLeaveDue.Text = employee.LeaveBalance.ToString();
                    dtpRequestDate.Value = staffLocum.EntryDate;
                    dtpStartDate.Value = staffLocum.StartDate;
                    dtpEndDate.Value = staffLocum.EndDate;
                    numericUpDownNumberOfDays.Value = staffLocum.NumberOfDays;
                    txtFileName.Text = Path.GetFileName(staffLocum.Path);
                    txtReason.Text = staffLocum.Reason;

                    FilePath = staffLocum.Path;
                    System.Data.Linq.Binary test = staffLocum.DocumentContent;
                    fileBytes = test.ToArray();
                    extension = staffLocum.Extension;
                }
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();
            }
            OldValues = GlobalData.CloneControls(controls, this);

        }

        protected void TextChangedHandler(object sender, EventArgs e)
        {
            if (skipTextChange)
            {
                return;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //void detachTB()
        //{
        //    try
        //    {
        //        staffIDtxt.TextChanged -= 
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //        AppUtils.ErrorMessageBox();
        //    }
        //}
    }
}
