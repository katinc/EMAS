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
    public partial class Employee_GradesView : Form,IRefreshView
    {
        private EmployeeGradeDataMapper dalHelper;
        private IList<EmployeeGrade> grades;
        private EmployeeGrade grade;
        private IDAL dal;

        public Employee_GradesView(EmployeeGradeDataMapper dalHelper)
        {
            try
            {
                InitializeComponent();
                this.dalHelper = dalHelper;
                this.grades = new List<EmployeeGrade>();
                this.grade = new EmployeeGrade();
                this.dal = new DAL();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public Employee_GradesView()
        {
            try
            {
                InitializeComponent();
                this.dalHelper = new EmployeeGradeDataMapper();
                this.grades = new List<EmployeeGrade>();
                this.grade = new EmployeeGrade();
                this.dal = new DAL();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Employee_GradesView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                RefreshView();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void RefreshView()
        {
            int ctr = 0;
            try
            {
                grades = dalHelper.GetAll();
                grid.Rows.Clear();
                foreach (EmployeeGrade employeeGrade in grades)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridGID"].Value = employeeGrade.ID;
                    grid.Rows[ctr].Cells["gridCategoryCode"].Value = employeeGrade.GradeCategory.Code;
                    grid.Rows[ctr].Cells["gridCategoryID"].Value = employeeGrade.GradeCategory.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = employeeGrade.Grade;
                    grid.Rows[ctr].Cells["gridCategory"].Value = employeeGrade.GradeCategory.Description;
                    
                    if (grid.Rows[ctr].Cells["gridGUSSCode"].Value == null)
                    {
                        grid.Rows[ctr].Cells["gridGUSSCode"].Value = DBNull.Value;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridGUSSCode"].Value = employeeGrade.Code;
                    }
                    if (grid.Rows[ctr].Cells["gridLevel"].Value == null)
                    {
                        grid.Rows[ctr].Cells["gridLevel"].Value = DBNull.Value;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridLevel"].Value = employeeGrade.Level;
                    }

                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = employeeGrade.Amount;
                    grid.Rows[ctr].Cells["gridActive"].Value = employeeGrade.Active;
                    ctr++;
                }
                if (grid.ColumnCount > 0)
                {
                    grid.Columns["gridGID"].Visible = false;
                    grid.Columns["gridCategoryCode"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }           
        }

        private void okButton_Click(object sender, EventArgs e)
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

        void grid_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    Employee_GradesEdit gradeEdit = new Employee_GradesEdit(dalHelper, new EmployeeGradeCategoryDataMapper(), grid.CurrentRow.Cells["gridGUSSCode"].Value.ToString(), grid.CurrentRow.Cells["gridDescription"].Value.ToString(), grid.CurrentRow.Cells["gridLevel"].Value.ToString(), grid.CurrentRow.Cells["gridCategoryCode"].Value.ToString(), grid.CurrentRow.Cells["gridGID"].Value.ToString(), this, grid.CurrentRow.Cells["gridBasicSalary"].Value.ToString(), grid.CurrentRow.Cells["gridHourRate"].Value.ToString(), int.Parse(grid.CurrentRow.Cells["gridCategoryID"].Value.ToString()), bool.Parse(grid.CurrentRow.Cells["gridActive"].Value.ToString()));
                    gradeEdit.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {                
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                    {
                        dalHelper.OpenConnection();
                        grade.ID = int.Parse(grid.CurrentRow.Cells["gridGID"].Value.ToString());
                        dalHelper.Delete(grade);
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                    {
                        dalHelper.OpenConnection();
                        grade.ID = int.Parse(grid.CurrentRow.Cells["gridGID"].Value.ToString());
                        dalHelper.Delete(grade);
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
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
}
