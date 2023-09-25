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

namespace eMAS.Forms.Employment
{
    public partial class EmployeeGradeSalaries : Form
    {
        int gradeCategoryCode;
        int gradeCode;
        IList<GradeCategory> gradeCategories;
        DataTable grades;
        IDAL dal;
        DALHelper dalHelper;
        EmployeeGradeDataMapper employeeGradeManip;
        EmployeeGradeCategoryDataMapper gradeCategoryManip;
        GradeSalaries gsalary;
        GradeSalariesMapper gmapper;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public EmployeeGradeSalaries()
        {
            InitializeComponent();
            dal = new DAL();
            dalHelper = new DALHelper();
            employeeGradeManip = new EmployeeGradeDataMapper();
            gradeCategoryManip = new EmployeeGradeCategoryDataMapper();
            gmapper = new GradeSalariesMapper();
            employeeGradeManip.OpenConnection();

        }

        private void EmployeeGradeSalaries_Load(object sender, EventArgs e)
        {
            try
            {
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    //  deleteButton.Visible = getPermissions.CanDelete;
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
                //throw ex;
            }
        }

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
                getCategoryGrades();


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

        private void getCategoryGrades()
        {
            try
            {
                gradeLevelsgrid.Rows.Clear();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@CategoryID", gradeCategoryCode, DbType.Int32);
                grades = dalHelper.ExecuteReader("Select e.*,s1.description as start_desc,s1.numeric_part as start_numeric_part,s2.numeric_part as end_numeric_part,s2.description as end_desc from EmployeeGrades_Setup e left outer join ViewSortedStepsAlphaNumeric s1 on  s1.id=e.startstep left outer join ViewSortedStepsAlphaNumeric s2 on s2.id=e.endstep Where e.CategoryID = @CategoryID  order by e.Description asc");


                gradeComboBox.Items.Clear();
                foreach (DataRow row in grades.Rows)
                {
                    gradeComboBox.Items.Add(row["Description"]);
                }
                if (gradeComboBox.Items.Count > 0)
                {
                    gradeComboBox.SelectedIndex = 0;
                    getGridData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void getGridData()
        {
            //gradeCategoryCode 
            gradeLevelsgrid.Rows.Clear();
            gradeCode = int.Parse(grades.Rows[gradeComboBox.SelectedIndex]["ID"].ToString());
            if (null != grades.Rows[gradeComboBox.SelectedIndex]["StartStep"] && !string.IsNullOrEmpty(grades.Rows[gradeComboBox.SelectedIndex]["StartStep"].ToString()))
            {
                int start_step =Information.IsNumeric(grades.Rows[gradeComboBox.SelectedIndex]["start_numeric_part"])?Convert.ToInt32(grades.Rows[gradeComboBox.SelectedIndex]["start_numeric_part"]):0;
                int end_step =Information.IsNumeric(grades.Rows[gradeComboBox.SelectedIndex]["end_numeric_part"])?Convert.ToInt32(grades.Rows[gradeComboBox.SelectedIndex]["end_numeric_part"]):0;


                dalHelper = new DALHelper();
                dalHelper.Parameters.Clear();

                dalHelper.CreateParameter("@start_step", start_step, DbType.Int32);
                dalHelper.CreateParameter("@end_step", end_step, DbType.Int32);
                var dtGradeSteps = dalHelper.ExecuteReader("select * from ViewSortedStepsAlphaNumeric where numeric_part between @start_step and @end_step");

                if (dtGradeSteps != null)
                {
                    int ctr = 0;
                    foreach (DataRow step in dtGradeSteps.Rows)
                    {
                        // gridLevel.Items.Add(row["Description"].ToString());
                        gradeLevelsgrid.Rows.Add(1);

                        gradeLevelsgrid.Rows[ctr].Cells["Step"].Value = step["Description"];
                        gradeLevelsgrid.Rows[ctr].Cells["StepID"].Value = step["id"];

                        DataRow r = getStepSalary(gradeCategoryCode, gradeCode, Convert.ToInt32(step["id"]));
                        if (r != null)
                        {
                            gradeLevelsgrid.Rows[ctr].Cells["ID"].Value = 1;
                            gradeLevelsgrid.Rows[ctr].Cells["BasicSalary"].Value = double.Parse(r["BasicSalary"].ToString());
                            gradeLevelsgrid.Rows[ctr].Cells["HourlyRate"].Value = double.Parse(r["HourlyRate"].ToString());
                        }

                        ctr++;
                    }
                }
            }

        }


        private DataRow getStepSalary(int catid, int gradeid, int step)
        {
            dalHelper.ClearParameters();
            dalHelper.CreateParameter("@CategoryID", catid, DbType.Int32);
            dalHelper.CreateParameter("@GradeID", gradeid, DbType.Int32);
            dalHelper.CreateParameter("@Step", step, DbType.Int32);

            DataTable tbl = dalHelper.ExecuteReader("Select * from GradeSalaries Where CategoryID = @CategoryID and GradeID = @GradeID and Step=@Step");
            if (tbl.Rows.Count > 0)
            {
                return tbl.Rows[0];
            }

            return null;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            gradeCategoryManip.CloseConnection();
            this.Close();
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
                        if (null != row.Cells["BasicSalary"].Value)
                        {

                            gsalary = new GradeSalaries()
                            {
                                UserID = GlobalData.User.ID,
                                CategoryID = gradeCategoryCode,
                                GradeID = gradeCode,
                                Step = Convert.ToInt32(row.Cells["StepID"].Value),
                                
                                BasicSalary = Convert.ToDouble(row.Cells["BasicSalary"].Value)
                            };

                            if (null != row.Cells["HourlyRate"].Value)
                            {
                                gsalary.HourlyRate = Convert.ToDouble(row.Cells["HourlyRate"].Value);
                            }

                            if (row.Cells["ID"].Value == null)
                            {
                                gmapper.Save(gsalary);
                            }
                            else
                            {
                                gmapper.Update(gsalary);
                            }
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

        private void Clear()
        {
            gradeLevelsgrid.Rows.Clear();
            //gradeComboBox.SelectedIndex = -1; 
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

                foreach (DataGridViewRow row in gradeLevelsgrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (!(row.Cells["BasicSalary"].Value == null))
                        {
                            //gridErrorProvider.SetError(groupBox1, "Please enter an employee grade for the selected grade category");
                            //result = false;

                            double t;
                            if (!double.TryParse(row.Cells["BasicSalary"].Value.ToString(), out t))
                            {
                                gridErrorProvider.SetError(groupBox1, "Invalid Basic Salary");
                                result = false;
                            }

                            if (row.Cells["HourlyRate"].Value != null && !double.TryParse(row.Cells["HourlyRate"].Value.ToString(), out t))
                            {
                                gridErrorProvider.SetError(groupBox1, "Invalid Basic Hourly Rate");
                                result = false;
                            }
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

        private void gradeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            getGridData();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
