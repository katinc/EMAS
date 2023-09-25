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
    public partial class Employee_Grades : Form
    {
        EmployeeGrade employeeGrade;
        EmployeeGradeDataMapper employeeGradeManip;
        EmployeeGradeCategoryDataMapper gradeCategoryManip;
        IList<GradeCategory> gradeCategories;
        int gradeCategoryCode;
        IDAL dal;

        public Employee_Grades()
        {
            InitializeComponent();
            dal = new DAL();
            employeeGradeManip = new EmployeeGradeDataMapper();
            gradeCategoryManip = new EmployeeGradeCategoryDataMapper();
            employeeGrade = new EmployeeGrade();
            employeeGradeManip.OpenConnection();
            gradeLevelsgrid.CellEnter += new DataGridViewCellEventHandler(gradeLevelsgrid_CellEnter);
            gradeLevelsgrid.RowsAdded += new DataGridViewRowsAddedEventHandler(gradeLevelsgrid_RowsAdded);
        }

        void gradeLevelsgrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in gradeLevelsgrid.Rows)
            {
                if (row.IsNewRow)
                {
                    row.Cells["gridActive"].Value = true;
                }
            }
        }

        void gradeLevelsgrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridErrorProvider.Clear();
        }

        private void Employee_Grades_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            groupBox1.Enabled = false;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            employeeGradeManip.CloseConnection();
            this.Close();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    employeeGradeManip.OpenConnection();
                    foreach (DataGridViewRow row in gradeLevelsgrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            employeeGrade = new EmployeeGrade() 
                            { 
                                User = new User(){ID=GlobalData.User.ID},
                                GradeCategory = new GradeCategory(){ID=gradeCategoryCode}, 
                                Code = row.Cells["gridGUSSCode"].Value.ToString(), 
                                Grade = row.Cells["gridGrade"].Value.ToString(), 
                                Level = row.Cells["gridLevel"].Value.ToString(), 
                                Amount = decimal.Parse(row.Cells["gridBasicSalary"].Value.ToString()),
                                Active = bool.Parse(row.Cells["gridActive"].Value.ToString()) 
                            };
                            employeeGradeManip.Save(employeeGrade);
                        }
                    }
                    this.Clear();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                gradeCategoryErrorProvider.Clear();
                gridErrorProvider.Clear();

                if (gradeCategorycmb.Text.Trim() == string.Empty)
                {
                    result = false;
                    gradeCategoryErrorProvider.SetError(gradeCategorycmb, "Please select a grade category");
                }
                try
                {
                    gradeLevelsgrid.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    result = false;
                    gridErrorProvider.SetError(groupBox1, "Please make sure you have entered valid data for all fields");
                }
                if (gradeLevelsgrid.RowCount == 1)
                {
                    result = false;
                    gridErrorProvider.SetError(groupBox1, "Please enter an employee grade for the selected grade category");
                }
                foreach (DataGridViewRow row in gradeLevelsgrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridGUSSCode"].Value == null)
                        {
                            row.Cells["gridGUSSCode"].Value = string.Empty;
                        }
                        if (row.Cells["gridLevel"].Value == null)
                        {
                            row.Cells["gridLevel"].Value = string.Empty;
                        }
                        if (row.Cells["gridBasicSalary"].Value == null || row.Cells["gridBasicSalary"].Value.ToString() == string.Empty)
                        {
                            row.Cells["gridBasicSalary"].Value = 0;
                        }
                        if (row.Cells["gridActive"].Value == null)
                        {
                            row.Cells["gridActive"].Value = false;
                        }
                        if (row.Cells["gridGrade"].Value == null)
                        {
                            result = false;
                            gridErrorProvider.SetError(groupBox1, "Please enter the employee grade on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridGrade"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            gridErrorProvider.SetError(groupBox1, "Please enter the employee grade on row " + (row.Index + 1));
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }
        private void viewbtn_Click(object sender, EventArgs e)
        {
            Employee_GradesView employeeGradeView = new Employee_GradesView(employeeGradeManip);
            employeeGradeView.Show();
        }

        #region CLEAR
        private void Clear()
        {
            gradeCategorycmb.Items.Clear();
            gradeCategorycmb.Text = string.Empty;
            gradeLevelsgrid.Rows.Clear();
            groupBox1.Enabled = false;
        }
        #endregion
       
        private void gradeCategorycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (gradeCategorycmb.Text.Trim() == string.Empty)
            {
                gradeCategorycmb.SelectedIndex = 0;
                groupBox1.Enabled = false;
                gradeLevelsgrid.Rows.Clear();
            }
            else
            {
                gradeCategoryCode = gradeCategories[gradeCategorycmb.SelectedIndex].ID;
                groupBox1.Enabled = true;
            }
        }

        private void gradeCategorycmb_DropDown(object sender, System.EventArgs e)
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
            gradeCategorycmb.SelectedIndex = 0;
        }

        private void gradeLevelsgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
