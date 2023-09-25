using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class Employee_GradesEdit : Form
    {
        EmployeeGradeDataMapper employeeGradeManip;
        EmployeeGradeCategoryDataMapper gradeCategoryManip;
        IRefreshView empGradeView;
        string categoryCode;
        string categoryID;
        string gid;
        IList<GradeCategory> gradeCategories;
        IList<EmployeeGrade> grades;
        EmployeeGrade employeeGrade;
        IDAL dal;

        bool load = false;

        public Employee_GradesEdit(EmployeeGradeDataMapper empManip, EmployeeGradeCategoryDataMapper grdManip, string gussCode,string grade, string level,string categoryCode,string gid,IRefreshView empGradeView, string basicSalary,string hourRate, int categoryID, bool active)
        {
            InitializeComponent();
            employeeGrade = new EmployeeGrade();
            gradeCategories=new List<GradeCategory>();
            grades=new List<EmployeeGrade>();
            load = true;
            gradeComboBox.DropDown += new EventHandler(gradeComboBox_DropDown);
            employeeGradeManip = empManip; 
            gradeCategoryManip = grdManip;
            try
            {
                gradeCategoryManip.OpenConnection();
                employeeGradeManip.OpenConnection();

                grades = employeeGradeManip.GetAll();
                gradeCategories = gradeCategoryManip.GetAll();

                gradeCategoryManip.CloseConnection();
                employeeGradeManip.CloseConnection();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            gradeCategorycmb_DropDown(this, EventArgs.Empty);
            gradeComboBox_DropDown(this, EventArgs.Empty);

            gussCodeTextBox.Text = gussCode;
            gradeComboBox.Text = grade;
            levelTextBox.Text = level;
            this.gid = gid;
            this.empGradeView = empGradeView;
            this.categoryCode = categoryCode;
            this.categoryID = categoryID.ToString();
            string cate = GetGradeCategory(this.categoryID);
            this.gradeCategorycmb.Text = cate;
            this.basicSalaryTextBox.Text = basicSalary;
            this.activeCheckBox.Checked = active;
            load = false;
            dal = new DAL();
        }

        public Employee_GradesEdit()
        {
            InitializeComponent();
            this.empGradeView = new Employee_GradesView();
            employeeGrade = new EmployeeGrade();
            gradeCategories = new List<GradeCategory>();
            grades = new List<EmployeeGrade>();
            load = true;
            gradeComboBox.DropDown += new EventHandler(gradeComboBox_DropDown);
            employeeGradeManip = new EmployeeGradeDataMapper();
            gradeCategoryManip = new EmployeeGradeCategoryDataMapper();
            try
            {
                gradeCategoryManip.OpenConnection();
                employeeGradeManip.OpenConnection();

                grades = employeeGradeManip.GetAll();
                gradeCategories = gradeCategoryManip.GetAll();

                gradeCategoryManip.CloseConnection();
                employeeGradeManip.CloseConnection();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            gradeCategorycmb_DropDown(this, EventArgs.Empty);
            gradeComboBox_DropDown(this, EventArgs.Empty);

            gussCodeTextBox.Text = string.Empty;
            gradeComboBox.Text = string.Empty;
            levelTextBox.Text = string.Empty;
            this.gid = string.Empty;
            this.categoryCode = string.Empty;
            this.categoryID = string.Empty;
            string cate = GetGradeCategory(this.categoryID);
            this.gradeCategorycmb.Text = string.Empty;
            this.basicSalaryTextBox.Text = string.Empty;
            this.activeCheckBox.Checked = false;
            load = false;
            dal = new DAL();
        }

        void gradeComboBox_DropDown(object sender, EventArgs e)
        {
            gradeComboBox.Items.Clear();
            try
            {
                gradeCategoryManip.OpenConnection();
                gradeCategories = gradeCategoryManip.GetAll();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            foreach (EmployeeGrade grade in grades)
            {
                gradeComboBox.Items.Add(grade.Grade);
            }
        }

        private string GetGradeCategory(string categoryID)
        {
            string cat = gradeCategoryManip.GetByKey(categoryID).Description;
            return cat;
        }
        private void Employee_GradesEdit_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                gradeCategorycmb.Items.Clear();
                gradeCategorycmb.Text = string.Empty;
                gussCodeTextBox.Clear();
                gradeCategorycmb.Items.Clear();
                gradeCategorycmb.Text = string.Empty;
                activeCheckBox.Checked = false;
                levelTextBox.Clear();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    employeeGrade.Grade = gradeComboBox.Text.Trim();
                    employeeGrade.Code = gussCodeTextBox.Text.Trim();
                    employeeGrade.GradeCategory.Code = categoryCode;
                    employeeGrade.GradeCategory.ID = int.Parse(categoryID.ToString());
                    employeeGrade.Level = levelTextBox.Text;
                    employeeGrade.Amount = decimal.Parse(basicSalaryTextBox.Text);
                    employeeGrade.User.ID = GlobalData.User.ID;
                    employeeGrade.ID = int.Parse(gid);
                    employeeGrade.Active = activeCheckBox.Checked;
                    try
                    {
                        employeeGradeManip.OpenConnection();
                        employeeGradeManip.Update(employeeGrade);
                        employeeGradeManip.CloseConnection();
                        empGradeView.RefreshView();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private bool ValidateFields()
        {
            bool result = true;
            gradeCategoryErrorProvider.Clear();
            gussErrorProvider.Clear();
            gradeErrorProvider.Clear();
            levelErrorProvider.Clear();

            if (gradeCategorycmb.Text.Trim() == string.Empty)
            {
                result = false;
                gradeCategoryErrorProvider.SetError(gradeCategorycmb, "Please select a grade category");
            }
            if (gradeComboBox.Text.Trim() == string.Empty)
            {
                result = false;
                gradeErrorProvider.SetError(gradeComboBox, "Please enter a grade");
            }
            return result;
        }

        private void gradeCategorycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                if (gradeCategorycmb.Text.Trim() == string.Empty)
                {
                    gradeCategorycmb.SelectedIndex = 0;
                }
                else
                {
                    categoryCode = gradeCategories[gradeCategorycmb.SelectedIndex].Code;
                }
            }
        }
        void gradeCategorycmb_DropDown(object sender, System.EventArgs e)
        {
            
                gradeCategorycmb.Items.Clear();
                try
                {
                    gradeCategoryManip.OpenConnection();
                    gradeCategories = gradeCategoryManip.GetAll();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
                foreach (GradeCategory category in gradeCategories)
                {
                    gradeCategorycmb.Items.Add(category.Description);
                }
            
        }

        private void gussCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (gussCodeTextBox.Text.ToString() != string.Empty)
            {
                gussErrorProvider.Clear();
            }
        }

        private void levelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (levelTextBox.Text.Trim() == string.Empty)
            {
                levelTextBox.Clear();
            }
        }

        private void gradeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gradeComboBox.Text.Trim() != string.Empty)
            {
                gradeCategoryErrorProvider.Clear();
            }
        }
    }
}
