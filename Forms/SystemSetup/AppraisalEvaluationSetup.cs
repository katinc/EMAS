using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer;
using HRDataAccessLayer;
using HRDataAccessLayerBase;

namespace eMAS.Forms.SystemSetup
{
    public partial class AppraisalEvaluationSetup : Form
    {
        private IDAL dal;
        private DALHelper dalHelper;
        private DataTable typesTable;
        private DataTable gradeCategoriesTable;
        private DataTable gradeTable;

        public AppraisalEvaluationSetup()
        {
            InitializeComponent();
            dalHelper = new DALHelper();
            dal = new DAL();
            typeComboBox.DropDown += new EventHandler(typeComboBox_DropDown);
            categoryComboBox.DropDown += new EventHandler(categoryComboBox_DropDown);
            gradeComboBox.DropDown += new EventHandler(gradeComboBox_DropDown);
        }

        void gradeComboBox_DropDown(object sender, EventArgs e)
        {
            gradeComboBox.Items.Clear();
            if (categoryComboBox.Text.Trim() != string.Empty && typeComboBox.Text.Trim() != string.Empty)
            {
                try
                {
                    dalHelper.OpenConnection();
                    gradeTable = dalHelper.ExecuteReader("Select ID,Description from EmployeeGrades_Setup Where Archived ='False' And Active='true' and CategoryID= " + gradeCategoriesTable.Rows[categoryComboBox.SelectedIndex]["ID"].ToString());
                    foreach (DataRow row in gradeTable.Rows)
                    {
                        gradeComboBox.Items.Add(row["Description"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        void categoryComboBox_DropDown(object sender, EventArgs e)
        {
            categoryComboBox.Items.Clear();
            try
            {
                dalHelper.OpenConnection();
                gradeCategoriesTable = dalHelper.ExecuteReader("Select ID,Description from GradeCategory_Setup Where Archived = 'False' And Active ='True'");
                foreach (DataRow row in gradeCategoriesTable.Rows)
                {
                    categoryComboBox.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }


        void typeComboBox_DropDown(object sender, EventArgs e)
        {
            typeComboBox.Items.Clear();
            try
            {
                dalHelper.OpenConnection();
                typesTable = dalHelper.ExecuteReader("Select ID,Description from AppraisalTypes Where Archived = 'False'");
                foreach (DataRow row in typesTable.Rows)
                {
                    typeComboBox.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {
                    if (ValidateFields())
                    {
                        dalHelper.OpenConnection();
                        dalHelper.BeginTransaction();
                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                dalHelper.ClearParameters();
                                dalHelper.CreateParameter("@AppraisalID", typesTable.Rows[typeComboBox.SelectedIndex]["ID"], DbType.Int32);
                                dalHelper.CreateParameter("@GradeID", gradeTable.Rows[gradeComboBox.SelectedIndex]["ID"], DbType.Int32);
                                dalHelper.CreateParameter("@Quality", row.Cells["gridQuality"].Value.ToString(), DbType.String);
                                if (row.Cells["gridID"].Value == null)
                                {
                                    dalHelper.ExecuteNonQuery("Insert Into AppraisalEvaluationSetup(GradeID,AppraisalTypeID,Quality) Values(@GradeID,@AppraisalID,@Quality)");
                                }
                                else
                                {
                                    dalHelper.CreateParameter("@ID", row.Cells["gridID"].Value.ToString(), DbType.String);
                                    dalHelper.ExecuteNonQuery("Update AppraisalEvaluationSetup Set GradeID=@GradeID,AppraisalTypeID=@AppraisalID,Quality=@Quality Where ID= @ID");
                                }
                            }
                        }
                        dalHelper.CommitTransaction();
                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    dal.RollBackTransaction();
                }
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            errorProvider.Clear();

            if (typeComboBox.Text.Trim() == string.Empty)
            {
                result = false;
                errorProvider.SetError(typeComboBox, "Please select a an appraisal type");
            }
            if (gradeComboBox.Text.Trim() == string.Empty)
            {
                result = false;
                errorProvider.SetError(gradeComboBox, "Please select a grade");
            }

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["gridQuality"].Value.ToString().Trim() == string.Empty)
                    {
                        result = false;
                        errorProvider.SetError(groupBox1, "Please enter the qualiy on row " + (row.Index + 1));
                    }
                }
            }
            return result;
        }


        private void Clear()
        {
            typeComboBox.Items.Clear();
            categoryComboBox.Items.Clear();
            gradeComboBox.Items.Clear();
            grid.Rows.Clear();
            
        }

        private void gradeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dalHelper.OpenConnection();
                int ctr = 0;
                grid.Rows.Clear();
                if (gradeComboBox.SelectedIndex >= 0)
                {
                    foreach (DataRow row in dalHelper.ExecuteReader("Select ID,Quality From AppraisalEvaluationSetup Where AppraisalTypeID=" + typesTable.Rows[typeComboBox.SelectedIndex]["ID"].ToString() + " And GradeID=" + gradeTable.Rows[gradeComboBox.SelectedIndex]["ID"].ToString()).Rows)
                    {
                        grid.Rows.Add(1);
                        grid.Rows[ctr].Cells["gridID"].Value = row["ID"];
                        grid.Rows[ctr].Cells["gridQuality"].Value = row["Quality"];
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {
                    
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                    {
                        dalHelper.OpenConnection();
                        dalHelper.ExecuteNonQuery("Delete From AppraisalEvaluationSetup Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                    {
                        dalHelper.OpenConnection();
                        dalHelper.ExecuteNonQuery("Delete From AppraisalEvaluationSetup Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
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

        private void AppraisalEvaluationSetup_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}
