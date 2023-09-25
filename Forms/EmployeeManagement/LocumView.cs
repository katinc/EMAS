using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eMAS.Forms.Employment;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;
using Microsoft.VisualBasic;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class LocumView : Form
    {
        private DALHelper dalHelper;
        private ExcuseDutyRequestDataMapper excuseDutyMapper;
        public List<ExcuseDutyRequest> lstExcuseDutyRequest;
        private IDAL dal;

        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;

        private PDFReader reader;
        private DocForm reader1;
        private Locum locum;
        public LocumView()
        {
            InitializeComponent();
            this.dalHelper = new DALHelper();
            this.dal = new DAL();
            this.excuseDutyMapper = new ExcuseDutyRequestDataMapper();
            this.lstExcuseDutyRequest = new List<ExcuseDutyRequest>();
            this.departments = new List<Department>();
            this.units = new List<Unit>();
            this.gradeCategories = new List<GradeCategory>();
            this.employeeGrades = new List<EmployeeGrade>();

        }

        public LocumView(Locum locum)
        {
            try
            {
                InitializeComponent();
                this.dalHelper = new DALHelper();
                this.dal = new DAL();
                this.excuseDutyMapper = new ExcuseDutyRequestDataMapper();
                this.lstExcuseDutyRequest = new List<ExcuseDutyRequest>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.locum = locum;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void LocumView_Load(object sender, EventArgs e)
        {

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

        private void PopulateGrid(IList<DataReference.StaffLocumView> staffLocums)
        {
            try
            {
                int ctr = 0;

                foreach (var item in staffLocums)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = item.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = item.StaffID;
                    grid.Rows[ctr].Cells["gridName"].Value = String.Concat(item.Firstname + " " + item.OtherName).Trim() + " " + item.Surname;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = item.Department;
                    grid.Rows[ctr].Cells["gridUnit"].Value = item.Unit;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = item.GradeCategory;
                    grid.Rows[ctr].Cells["gridLocumLetter"].Value = item.DocumentContent;
                    grid.Rows[ctr].Cells["gridRequestDate"].Value = item.EntryDate.ToString("dd/MM/yyyy");
                    grid.Rows[ctr].Cells["gridStartDate"].Value = item.StartDate.ToString("dd/MM/yyyy");
                    grid.Rows[ctr].Cells["gridEndDate"].Value = item.EndDate.ToString("dd/MM/yyyy");
                    grid.Rows[ctr].Cells["gridGrade"].Value = item.Grade;
                    grid.Rows[ctr].Cells["gridDocumentPath"].Value = item.Path;
                    grid.Rows[ctr].Cells["gridFileName"].Value = Path.GetFileNameWithoutExtension(item.Path);
                    ctr++;
                }
            }
            catch (Exception exii)
            {
                Logger.LogError(exii);
            }

        }

        private void GetData()
        {
            dalHelper = new DALHelper();
            dalHelper.ClearParameters();
            try
            {
                grid.Rows.Clear();

                if (datePickerRequestDate.Checked)
                {

                }

                var staffLocums = GlobalData._context.StaffLocumViews.Where(u =>
                    (u.StaffID.Contains(txtStaffID.Text) || u.StaffID == string.Empty || u.StaffID == null) &&
                    (u.Department.Contains(cboDepartment.Text) || u.Department == string.Empty || u.Department == null) &&
                    (u.Unit.Contains(cboUnit.Text) || u.Unit == string.Empty || u.Unit == null) &&
                    (u.GradeCategory.Contains(cboGradeCategory.Text) || u.GradeCategory == string.Empty || u.GradeCategory == null) &&
                    (u.Grade.Contains(cboGrade.Text) || u.Grade == string.Empty || u.Grade == null) &&
                    (u.Surname.Contains(txtSurname.Text) || u.Surname == string.Empty || u.Surname == null) &&
                    (u.Firstname.Contains(txtFirstName.Text) || u.Firstname == string.Empty || u.Firstname == null)
                    && ((datePickerRequestDate.Checked == true ? u.EntryDate == datePickerRequestDate.Value : u.EntryDate > DateTime.MinValue ))
                    && ((datePickerStartDate.Checked == true ? u.StartDate == datePickerStartDate.Value : u.StartDate > DateTime.MinValue))
                    && ((datePickerEndDate.Checked == true ? u.EndDate == datePickerEndDate.Value : u.EndDate < DateTime.MaxValue))
                    && (u.Archived == false)).ToList();

                var sql = GlobalData._context.StaffLocumViews.Where(u =>
                    (u.StaffID.Contains(txtStaffID.Text) || u.StaffID == string.Empty || u.StaffID == null) &&
                    (u.Department.Contains(cboDepartment.Text) || u.Department == string.Empty || u.Department == null) &&
                    (u.Unit.Contains(cboUnit.Text) || u.Unit == string.Empty || u.Unit == null) &&
                    (u.GradeCategory.Contains(cboGradeCategory.Text) || u.GradeCategory == string.Empty || u.GradeCategory == null) &&
                    (u.Grade.Contains(cboGrade.Text) || u.Grade == string.Empty || u.Grade == null) &&
                    (u.Surname.Contains(txtSurname.Text) || u.Surname == string.Empty || u.Surname == null) &&
                    (u.Firstname.Contains(txtFirstName.Text) || u.Firstname == string.Empty || u.Firstname == null)
                    && ((datePickerRequestDate.Checked == true ? u.EntryDate == datePickerRequestDate.Value : u.EntryDate > DateTime.MinValue))
                    && ((datePickerStartDate.Checked == true ? u.StartDate == datePickerStartDate.Value : u.StartDate > DateTime.MinValue))
                    && ((datePickerEndDate.Checked == true ? u.EndDate == datePickerEndDate.Value : u.EndDate < DateTime.MaxValue))
                    && (u.Archived == false));

                var dl = GlobalData._context.GetCommand(sql);

                foreach (var item in dl.Parameters)
                {

                }

                //&& ((datePickerRequestDate.Checked == true ? u.EntryDate ==  datePickerRequestDate.Value : DateTime.MinValue ) || u.EntryDate > DateTime.MinValue) 
                //&& (u.StartDate.Equals(datePickerStartDate.Value) || u.StartDate == null) 
                //&& (u.EndDate.Equals(datePickerEndDate.Value) || u.EndDate == null)

                grid.Rows.Clear();
                PopulateGrid(staffLocums);
                grid.ClearSelection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                // throw ex;
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            grid.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0 && MessageBox.Show(this, "Do you really want to delete record?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.OK)
            {
                excuseDutyMapper.deleteRecord(Convert.ToInt32(grid.CurrentRow.Cells["gridID"].Value));
                grid.Rows.RemoveAt(grid.CurrentRow.Index);
            }
            else
                MessageBox.Show(this, "Sorry you have to selected a row first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void cboUnit_DropDown(object sender, EventArgs e)
        {
            if (cboDepartment.Text == string.Empty)
            {
                cboUnit.Items.Clear();
                return;
            }

            try
            {
                Query query = new Query();

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

        private void btnPreviewLetter_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.SelectedRows.Count == 0)
                    MessageBox.Show("Sorry You Have Not Selected Any Record!");
                else
                {

                    System.Data.Linq.Binary test = (System.Data.Linq.Binary)grid.SelectedRows[0].Cells["gridLocumLetter"].Value;
                    byte[] bytes = (byte[])test.ToArray();
                    FileInfo fileinf = new FileInfo(grid.SelectedRows[0].Cells["gridDocumentPath"].Value.ToString().ToLower());
                    string extension = fileinf.Extension.Trim(new char[] { '.' });

                    MemoryStream ms = new MemoryStream(bytes);
                    string tempName = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Path.GetRandomFileName(), extension));
                    //System.Diagnostics.Process.Start(tempName);
                    File.WriteAllBytes(tempName, bytes);
                    if (extension.EndsWith("pdf"))
                    {
                        reader = new PDFReader(tempName);
                        reader.Show();
                    }
                    else
                    {
                        reader1 = new DocForm();
                        reader1.LoadDocument(tempName, extension);
                        reader1.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();
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
                cboUnit.Items.Add("All");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null && locum.CanEdit)
                {
                    decimal ID = Convert.ToDecimal(grid.CurrentRow.Cells["gridID"].Value.ToString());

                    locum.EditLocum(ID);
                    locum.Show();
                    locum.BringToFront();
                    this.Close();
                }
                else if (!locum.CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void removeButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    
                        if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridName"].Value.ToString() + "'s Locum?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            try
                            {
                                var locum = GlobalData._context.StaffLocums.SingleOrDefault(u=>u.ID.ToString() == grid.CurrentRow.Cells["gridID"].Value.ToString());

                                if (GlobalData.User.UserCategory.Description == "Intermediate") //&& GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString())
                            {
                                    locum.Archived = true;
                                    locum.ArchivedTime = DateTime.Today;
                                    locum.ArchivererID = GlobalData.User.ID;
                                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                    GlobalData._context.SubmitChanges();
                            }
                                else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                                {
                                    locum.Archived = true;
                                    locum.ArchivedTime = DateTime.Today;
                                    locum.ArchivererID = GlobalData.User.ID;
                                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                    GlobalData._context.SubmitChanges();
                                }
                                else
                                {
                                    MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.LogError(ex);
                            }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();
                //throw;
            }
        }
    }
}
