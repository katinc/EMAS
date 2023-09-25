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
using eMAS.Forms.StaffManagement;
using eMAS.Forms.EmployeeManagement;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.StaffManagement
{
    public partial class DemotionCorectForm : Form
    {
        private IList<Employee> employees;
        private IList<Promotion> demotions;
        private Employee employee;
        private Promotion demotion;
        private DAL dal;
        private int demotionID;
        private int staffCode;
        private bool editMode;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public DemotionCorectForm()
        {
            try
            {
                InitializeComponent();
                this.demotion = new Promotion();
                this.employee = new Employee();
                this.dal = new DAL();
                this.employees = new List<Employee>();
                this.demotions = new List<Promotion>();
                this.demotionID = 0;
                this.staffCode = 0;
                this.editMode = false;
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

        private void DemotionCorrectForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);


                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Visible = getPermissions.CanAdd;
                    //findbtn.Visible = getPermissions.CanView;
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
                demotionID = 0;
                staffErrorProvider.Clear();
                datePickerEffectiveDate.ResetText();
                txtReason.Text = string.Empty;
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
                nametxt.Clear();
                gendertxt.Clear();
                agetxt.Clear();
                departmentTextBox.Clear();
                unitTextBox.Clear();
                gradeCategoryTextBox.Clear();
                gradeTextBox.Clear();
                specialtyTextBox.Clear();
                txtDemotionDate.Clear();
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
                    Clear();
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoView.PromotionType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = "Demoted",
                        CriteriaOperator = CriteriaOperator.And
                    });
                    employees = dal.GetByCriteria<Employee>(query);
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            demotionID = int.Parse(searchGrid.CurrentRow.Cells["gridID"].Value.ToString());
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
                            txtDemotionDate.Text = employee.CurrentPromotionDate.Value.Date.ToString("dd/MM/yyyy");
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
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.PromotionType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = "Promoted",
                        CriteriaOperator = CriteriaOperator.And
                    });
                    demotions = dal.GetByCriteria<Promotion>(query);
                    foreach (Promotion promotion in demotions)
                    {
                        string name = promotion.Employee.FirstName + (promotion.Employee.OtherName == string.Empty ? string.Empty : " " + promotion.Employee.OtherName) + " " + promotion.Employee.Surname;
                        if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = promotion.Employee.ID;
                            searchGrid.Rows[ctr].Cells["gridNewGrade"].Value = promotion.Grade.Grade;
                            searchGrid.Rows[ctr].Cells["gridNewGradeCategory"].Value = promotion.GradeCategory.Description;
                            searchGrid.Rows[ctr].Cells["gridNewSalary"].Value = promotion.NewSalary;
                            searchGrid.Rows[ctr].Cells["gridPromotionDate"].Value = promotion.PromotionDate;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = promotion.Employee.StaffID;
                            searchGrid.Rows[ctr].Cells["gridID"].Value = promotion.ID;
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
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.PromotionType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = "Promoted",
                        CriteriaOperator = CriteriaOperator.And
                    });
                    demotions = dal.GetByCriteria<Promotion>(query);
                    foreach (Promotion demotion in demotions)
                    {
                        string name = demotion.Employee.FirstName + (demotion.Employee.OtherName == string.Empty ? string.Empty : " " + demotion.Employee.OtherName) + " " + demotion.Employee.Surname;
                        if (demotion.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = demotion.Employee.StaffID;
                            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = demotion.Employee.ID;
                            searchGrid.Rows[ctr].Cells["gridNewGrade"].Value = demotion.Grade.Grade;
                            searchGrid.Rows[ctr].Cells["gridNewGradeCategory"].Value = demotion.GradeCategory.Description;
                            searchGrid.Rows[ctr].Cells["gridNewSalary"].Value = demotion.NewSalary;
                            searchGrid.Rows[ctr].Cells["gridDemotionDate"].Value = demotion.PromotionDate;
                            searchGrid.Rows[ctr].Cells["gridID"].Value = demotion.ID;
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
                        searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 22);
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

        public void EditDemotion(DataGridViewRow row)
        {
            try
            {
                Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoView.PromotedType",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = "Demoted",
                    CriteriaOperator = CriteriaOperator.And
                });
                employees = dal.GetByCriteria<Employee>(query);
                foreach (Employee employee in employees)
                {
                    if (employee.StaffID.Trim() == row.Cells["gridStaffID"].Value.ToString().Trim())
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
                        txtDemotionDate.Text = employee.CurrentPromotionDate.ToString();
                        break;
                    }
                }
                editMode = true;
                demotionID = int.Parse(row.Cells["gridID"].Value.ToString());
                datePickerEffectiveDate.Text = row.Cells["gridDemotionDate"].Value.ToString();
                txtReason.Text = row.Cells["gridReason"].Value.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.OpenConnection();
                    dal.BeginTransaction();
                    UpdateDemotionsEntity();
                    if (demotionID != 0)
                    {
                        if (datePickerEffectiveDate.Value.Date <= DateTime.Today.Date)
                        {
                            employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                            employee.CurrentPromotionDate = datePickerEffectiveDate.Value;
                            employee.GradeDate = datePickerEffectiveDate.Value;
                            //employee.PromotionType = demotion.PromotionType.ID;
                            dal.Update(employee);
                        }
                        else
                        {
                            //employee.PromotionType = string.Empty;
                        }
                        dal.Update(demotion);
                        dal.CommitTransaction();
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                string err = ex.Message;
                string err2 = ex.Source;
                MessageBox.Show("Error:Not saved successfully,See the system Administrator");
            }
        }

        private void UpdateDemotionsEntity()
        {
            try
            {
                demotion.ID = demotionID;
                demotion.Employee.StaffID = staffIDtxt.Text;
                demotion.Employee.ID = staffCode;
                //demotion.PromotionType = "Demoted";
                demotion.PromotionDate = datePickerEffectiveDate.Value;
                demotion.User.ID = GlobalData.User.ID;
                demotion.Reason = txtReason.Text;
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
                if (datePickerEffectiveDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerEffectiveDate, "Please select the Effective Date");
                    datePickerEffectiveDate.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }
    }
}
