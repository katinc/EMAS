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
    public partial class Grade_CategoryView : Form, IRefreshView 
    {
        EmployeeGradeCategoryDataMapper dalHelper;
        IList<GradeCategory> gradeCategories;
        private GradeCategory gradeCategory;
        IDAL dal;

        public Grade_CategoryView()
        {
            InitializeComponent();
            dalHelper = new EmployeeGradeCategoryDataMapper();
            gradeCategories = new List<GradeCategory>();
            this.gradeCategory=new GradeCategory();
            dal = new DAL();
        }

        private void Grade_CategoryView_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            RefreshView();
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        public void RefreshView()
        {
            try
            {
                dalHelper.OpenConnection();
                int ctr = 0;
                IList<GradeCategory> gradeCategories = dalHelper.GetAll();
                grid.Rows.Clear();
                foreach (GradeCategory gradeCategory in gradeCategories)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridCode"].Value = gradeCategory.Code;
                    grid.Rows[ctr].Cells["gridID"].Value = gradeCategory.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = gradeCategory.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = gradeCategory.Active;
                    grid.Rows[ctr].Cells["gridUserID"].Value = gradeCategory.User.ID;
                    ctr++;
                }
                dalHelper.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption);
                this.Close();
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void grid_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                GradeCategoryEdit categoryEdit = new GradeCategoryEdit(
                    bool.Parse(grid.CurrentRow.Cells["gridActive"].Value.ToString()),
                    grid.CurrentRow.Cells["gridDescription"].Value.ToString(),
                    grid.CurrentRow.Cells["gridCode"].Value.ToString(),
                    grid.CurrentRow.Cells["gridID"].Value.ToString(),
                    int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()),
                this);
                categoryEdit.Show();
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
                        gradeCategory.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        dalHelper.Delete(gradeCategory);
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                    {
                        dalHelper.OpenConnection();
                        gradeCategory.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        dalHelper.Delete(gradeCategory);
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    else
                    {
                        MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }
    }
}
