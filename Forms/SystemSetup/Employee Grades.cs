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
using HRDataAccessLayerBase;
using Microsoft.VisualBasic;

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
        DALHelper dalHelper;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;



        public Employee_Grades()
        {
            InitializeComponent();
            dal = new DAL();
            dalHelper = new DALHelper();
            employeeGradeManip = new EmployeeGradeDataMapper();
            gradeCategoryManip = new EmployeeGradeCategoryDataMapper();
            employeeGrade = new EmployeeGrade();
            employeeGradeManip.OpenConnection();
            gradeLevelsgrid.CellEnter += new DataGridViewCellEventHandler(gradeLevelsgrid_CellEnter);
            gradeLevelsgrid.RowsAdded += new DataGridViewRowsAddedEventHandler(gradeLevelsgrid_RowsAdded);
            getLevels();
            getSteps(4);
            getSteps(5);
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
           // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                savebtn.Enabled = getPermissions.CanAdd;
                viewbtn.Enabled = getPermissions.CanDelete;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
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

                        
                        //if (null != row.Cells["gridGUSSCode"].Value && null != row.Cells["gridGrade"].Value)
                        //{
                            employeeGrade = new EmployeeGrade()
                            {
                                User = new User() { ID = GlobalData.User.ID },
                                GradeCategory = new GradeCategory() { ID = gradeCategoryCode },
                                Code = row.Cells["gridGUSSCode"].Value == null ? string.Empty : row.Cells["gridGUSSCode"].Value.ToString(),
                                Grade = row.Cells["gridGrade"].Value.ToString(),
                                Level = row.Cells["gridLevel"].Value.ToString(),
                                Amount = 0,//decimal.Parse(row.Cells["gridBasicSalary"].Value.ToString()),
                                Active = (row.Cells["gridActive"].Value != null) ? bool.Parse(row.Cells["gridActive"].Value.ToString()) : false
                            };


                            employeeGrade.StartStep = (row.Cells["gridStartStep"].Value != null) ? getSetepId(row.Cells["gridStartStep"].Value.ToString(), 4) : 0;
                            employeeGrade.EndStep = (row.Cells["gridEndStep"].Value != null) ? getSetepId(row.Cells["gridEndStep"].Value.ToString(), 0) : 0;

                            if (row.Cells["ID"].Value == null)
                            {
                                employeeGradeManip.Save(employeeGrade);
                            }
                            else
                            {
                                employeeGrade.ID = Convert.ToInt32(row.Cells["ID"].Value);
                                employeeGradeManip.Update(employeeGrade);
                            }
                        //}
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
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }
        private void viewbtn_Click(object sender, EventArgs e)
        {
            Employee_GradesView employeeGradeView = new Employee_GradesView(employeeGradeManip);
            employeeGradeView.btnRemove.Enabled = CanDelete;
            employeeGradeView.Show();
        }

        #region CLEAR
        private void Clear()
        {
            gradeCategorycmb.ResetText();
            gradeCategorycmb.Text = string.Empty;
            gradeLevelsgrid.Rows.Clear();
            groupBox1.Enabled = false;
        }
        #endregion

        private void gradeCategorycmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (gradeCategorycmb.Text.Trim() == string.Empty)
            //{
            //    gradeCategorycmb.SelectedIndex = 0;
            //    groupBox1.Enabled = false;
            //    gradeLevelsgrid.Rows.Clear();
            //}
            //else
            //{
            //    gradeCategoryCode = gradeCategories[gradeCategorycmb.SelectedIndex].ID;
            //    groupBox1.Enabled = true;

            //    getCategoryGrades();
            //}
        }

        private void getCategoryGrades()
        {
            try
            {
                gradeLevelsgrid.Rows.Clear();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@CategoryID", gradeCategoryCode, DbType.Int32);
                DataTable tbl = dalHelper.ExecuteReader("Select e.*,s1.description as start_desc,s2.description as end_desc from EmployeeGrades_Setup e left outer join step s1 on  s1.id=e.startstep left outer join step s2 on s2.id=e.endstep Where e.CategoryID = @CategoryID  order by e.Description asc");
                gradeLevelsgrid.Rows.Clear();
                int ctr = 0;
                foreach (DataRow row in tbl.Rows)
                {
                    // gridLevel.Items.Add(row["Description"].ToString());
                    gradeLevelsgrid.Rows.Add(1);

                    gradeLevelsgrid.Rows[ctr].Cells["ID"].Value = row["ID"].ToString();
                    gradeLevelsgrid.Rows[ctr].Cells["gridGUSSCode"].Value = row["Code"].ToString();
                    gradeLevelsgrid.Rows[ctr].Cells["gridGrade"].Value = row["Description"].ToString();
                    gradeLevelsgrid.Rows[ctr].Cells["gridLevel"].Value = row["GradeLevel"].ToString(); // (row["GradeLevel"].ToString() == "NOT APPLICABLE") ? "" : row["GradeLevel"].ToString();
                    gradeLevelsgrid.Rows[ctr].Cells["gridStartStep"].Value = row["start_desc"].ToString();
                    gradeLevelsgrid.Rows[ctr].Cells["gridEndStep"].Value = row["end_desc"].ToString();
                    gradeLevelsgrid.Rows[ctr].Cells["gridActive"].Value = row["Active"].ToString();

                    ctr++;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradeCategorycmb_DropDown(object sender, System.EventArgs e)
        {
            gradeCategorycmb.DataSource = null ;
            try
            {
                gradeCategoryManip.OpenConnection();
                gradeCategories = gradeCategoryManip.GetAll();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            gradeCategorycmb.DataSource = gradeCategories;
            gradeCategorycmb.DisplayMember = "Description";
            gradeCategorycmb.ValueMember = "ID";

            //foreach (GradeCategory category in gradeCategories)
            //{
            //    gradeCategorycmb.Items.Add(category.Description);
            //}
            gradeCategorycmb.SelectedIndex = 0;
        }

        private void gradeLevelsgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void getLevels()
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                DataTable tbl = dalHelper.ExecuteReader("Select * from BandView Where BandView.Archived = @Archived and BandView.Active=@Active order by BandView.Description asc");
                gridLevel.Items.Clear();
                foreach (DataRow row in tbl.Rows)
                {
                    gridLevel.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        List<Step> lstStartSteps, lstEndSteps;
        private void getSteps(int which)
        {


            try
            {

                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                DataTable tbl = dalHelper.ExecuteReader("Select * from StepView Where Archived = @Archived and Active=@Active order by ID asc");
                if (which == 4)
                {
                    gridStartStep.Items.Clear();
                    lstStartSteps = new List<Step>();
                }
                else
                {
                    gridEndStep.Items.Clear();
                    lstEndSteps = new List<Step>();
                }

                foreach (DataRow row in tbl.Rows)
                {
                    var step = new Step()
                    {
                        ID = Convert.ToInt32(row["id"]),
                        Description = (row["Description"] != null) ? row["Description"].ToString() : string.Empty

                    };

                    if (which == 4)
                    {
                        gridStartStep.Items.Add(row["Description"].ToString());
                        lstStartSteps.Add(step);
                    }
                    else
                    {
                        gridEndStep.Items.Add(row["Description"].ToString());
                        lstEndSteps.Add(step);
                    }

                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private int getSetepId(string Desc, int which)
        {
            List<Step> lstStep = new List<Step>();
            lstStep = (which == 4) ? lstStartSteps : lstEndSteps;

            foreach (Step step in lstStep)
            {

                if (step.Description == Desc)
                    return step.ID;
            }
            return 0;

        }
        private void gradeLevelsgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
            try
            {
                if (gradeLevelsgrid.CurrentCell.ColumnIndex == 3)
                {
                    getLevels();
                }
                if (gradeLevelsgrid.CurrentCell.ColumnIndex == 4)
                {
                    getSteps(4);
                }
                if (gradeLevelsgrid.CurrentCell.ColumnIndex == 5)
                {
                    getSteps(5);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradeCategorycmb_SelectionChangeCommitted(object sender, EventArgs e)
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

                getCategoryGrades();
            }
        }

        private void gradeLevelsgrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Logger.LogError(e.Exception);

        }

    }
}
