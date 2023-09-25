using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;


namespace eMAS.Forms.EmployeeManagement
{
    public partial class SupervisorAppraisal : Form
    {
        private DALHelper dalHelper;
        private IDAL dal;
        private DataTable typesTable;
        private DataTable gradeCategoriesTable;
        private DataTable gradeTable;
        private string staffID;
        private string appraisalID;


        public SupervisorAppraisal()
        {
            try
            {
                InitializeComponent();
                staffID = string.Empty;
                dalHelper = new DALHelper();
                dal = new DAL();
                supervisorTextBox.Text = dalHelper.ExecuteScalar("Select Supervisor From DDepartments inner join StaffPersonalInfo on StaffPersonalInfo.StaffID = DDepartments.SupervisorID ").ToString();
                this.Text = GlobalData.Caption;

                typeComboBox.DropDown += new EventHandler(typeComboBox_DropDown);
                categoryComboBox.DropDown += new EventHandler(categoryComboBox_DropDown);
                gradeComboBox.DropDown += new EventHandler(gradeComboBox_DropDown);
                employeesGrid.SelectionChanged += new EventHandler(employeesGrid_SelectionChanged);
                employeesGrid.CellClick += new DataGridViewCellEventHandler(employeesGrid_CellClick);
                evaluationGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(evaluationGrid_EditingControlShowing);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void evaluationGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                evaluationGrid.CurrentCellDirtyStateChanged += new EventHandler(evaluationGrid_CurrentCellDirtyStateChanged);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void evaluationGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                decimal total = 0;
                evaluationGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                foreach (DataGridViewRow row in evaluationGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        decimal result = 0;
                        if (row.Cells["evaluationGridRating"].Value != null && decimal.TryParse(row.Cells["evaluationGridRating"].Value.ToString(), out result))
                        {
                            total += decimal.Parse(row.Cells["evaluationGridRating"].Value.ToString());
                        }
                    }
                }
                totalScoreTextBox.Text = total.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void employeesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (employeesGrid.CurrentRow != null)
                {
                    int ctr = 0;
                    totalScoreTextBox.Text = "0";
                    questionnaireGrid.Rows.Clear();
                    evaluationGrid.Rows.Clear();
                    evaluationGridQuality.Items.Clear();

                    dal.OpenConnection();

                    if (employeesGrid.CurrentRow != null && employeesGrid.CurrentRow.Cells["gridStaffID"].Value != null)
                    {
                        staffID = employeesGrid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                        ctr = 0;
                        foreach (DataRow row in dalHelper.ExecuteReader("select AppraisalAnswers.QuestionNo,AppraisalQuestionaires.Question,AppraisalAnswers.Answer from AppraisalAnswers Inner Join AppraisalQuestionaires  on AppraisalQuestionaires.QuestionNo = AppraisalAnswers.QuestionNo Where AppraisalAnswers.AppraisalID = AppraisalQuestionaires.AppraisalID  and AppraisalAnswers.StaffID ='" + staffID + "'").Rows)
                        {
                            questionnaireGrid.Rows.Add(1);
                            questionnaireGrid.Rows[ctr].Cells["gridNo"].Value = row["QuestionNo"].ToString();
                            questionnaireGrid.Rows[ctr].Cells["gridQuestion"].Value = row["Question"].ToString();
                            questionnaireGrid.Rows[ctr].Cells["gridAnswer"].Value = row["Answer"].ToString();
                            ctr++;
                        }
                    }

                    foreach (DataRow row in dalHelper.ExecuteReader("Select AppraisalEvaluationSetup.ID, AppraisalEvaluationSetup.Quality from AppraisalEvaluationSetup Where AppraisalEvaluationSetup.AppraisalTypeID = " + typesTable.Rows[typeComboBox.SelectedIndex]["ID"].ToString() + " and AppraisalEvaluationSetup.GradeID = " + gradeTable.Rows[gradeComboBox.SelectedIndex]["ID"].ToString()).Rows)
                    {
                        evaluationGridQuality.Items.Add(row["Quality"].ToString());
                    }

                    ctr = 0;
                    foreach (DataRow row in dalHelper.ExecuteReader("Select AppraisalEvaluation.ID, AppraisalEvaluation.Quality,AppraisalEvaluation.Rating from AppraisalEvaluation Where AppraisalEvaluation.StaffID = '" + staffID + "' and AppraisalEvaluation.AppraisalID = " + appraisalID).Rows)
                    {
                        evaluationGrid.Rows.Add(1);
                        evaluationGrid.Rows[ctr].Cells["evaluationGridID"].Value = row["ID"];
                        evaluationGrid.Rows[ctr].Cells["evaluationGridQuality"].Value = row["Quality"];
                        evaluationGrid.Rows[ctr].Cells["evaluationGridRating"].Value = row["Rating"];
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void employeesGrid_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        void gradeComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                gradeComboBox.Items.Clear();
                if (categoryComboBox.Text.Trim() != string.Empty && typeComboBox.Text.Trim() != string.Empty)
                {
                    gradeTable = dalHelper.ExecuteReader("Select ID,Description from EmployeeGrades_Setup Where Archived ='False' And Active='true' and CategoryID= " + gradeCategoriesTable.Rows[categoryComboBox.SelectedIndex]["ID"].ToString());
                    foreach (DataRow row in gradeTable.Rows)
                    {
                        gradeComboBox.Items.Add(row["Description"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }

        void categoryComboBox_DropDown(object sender, EventArgs e)
        {  
            try
            {
                categoryComboBox.Items.Clear();
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
            try
            {
                typeComboBox.Items.Clear();
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void SupervisorAppraisal_Load(object sender, EventArgs e)
        {
            try
            {
                totalScoreTextBox.Text = "0";
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetStaffForCurrentAppraisal()
        {
            try
            {
                evaluationGrid.Rows.Clear();
                questionnaireGrid.Rows.Clear();
                employeesGrid.Rows.Clear();
                if (typeComboBox.Text.Trim() != string.Empty && gradeComboBox.Text.Trim() != string.Empty)
                {
                    int ctr = 0;
                    employeesGrid.Rows.Clear();
                    evaluationGrid.Rows.Clear();
                    questionnaireGrid.Rows.Clear();

                    foreach (DataRow row in dalHelper.ExecuteReader("Select distinct AppraisalForms.ID,AppraisalForms.StartDate,AppraisalForms.EndDate,AppraisalAnswers.StaffID,StaffPersonalInfo.FirstName +' '+ StaffPersonalInfo.OtherName +' '+ StaffPersonalInfo.Surname as Name From AppraisalAnswers Inner Join StaffPersonalInfo on StaffPersonalInfo.StaffID = AppraisalAnswers.StaffID Inner Join AppraisalForms on AppraisalForms.ID = AppraisalAnswers.AppraisalID Where AppraisalForms.TypeID = " + typesTable.Rows[typeComboBox.SelectedIndex]["ID"].ToString() + " And AppraisalForms.GradeID = " + gradeTable.Rows[gradeComboBox.SelectedIndex]["ID"].ToString() + " And AppraisalForms.Archived='false' And StaffPersonalInfo.Archived='false'").Rows)
                    {
                        employeesGrid.Rows.Add(1);
                        appraisalID = row["ID"].ToString();
                        employeesGrid.Rows[ctr].Cells["gridStaffID"].Value = row["StaffID"].ToString();
                        employeesGrid.Rows[ctr].Cells["gridName"].Value = row["Name"].ToString();
                        startDatePicker.Text = row["StartDate"].ToString();
                        endDatePicker.Text = row["EndDate"].ToString();
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                throw ex;
            }
        }
        private void gradeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStaffForCurrentAppraisal();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dalHelper.OpenConnection();
                    dalHelper.BeginTransaction();
                    dalHelper.ExecuteNonQuery("Delete From AppraisalEvaluation Where AppraisalID=" + appraisalID + " And StaffID='" + staffID + "'");
                    foreach (DataGridViewRow row in evaluationGrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            dalHelper.ClearParameters();
                            dalHelper.CreateParameter("@Quality", row.Cells["evaluationGridQuality"].Value.ToString(), DbType.String);
                            dalHelper.CreateParameter("@Rating", row.Cells["evaluationGridRating"].Value.ToString(), DbType.String);
                            dalHelper.CreateParameter("@StaffID", staffID, DbType.String);
                            dalHelper.CreateParameter("@AppraisalID", appraisalID, DbType.Int32);
                            dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                            dalHelper.ExecuteNonQuery("Insert Into AppraisalEvaluation(Quality,Rating,StaffID,AppraisalID,UserID) Values(@Quality,@Rating,@StaffID,@AppraisalID,@UserID)");
                        }
                    }
                    dalHelper.CommitTransaction();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                decimal res = 0;
                foreach (DataGridViewRow row in evaluationGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["evaluationGridQuality"].Value == null && row.Cells["evaluationGridQuality"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            errorProvider.SetError(groupBox5, "Please select a quality to rate on row " + (row.Index + 1).ToString());
                        }

                        if (row.Cells["evaluationGridRating"].Value == null && !decimal.TryParse(row.Cells["evaluationGridRating"].Value.ToString(), out res))
                        {
                            result = false;
                            errorProvider.SetError(groupBox5, "Please select a quality to rate on row " + (row.Index + 1).ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void button7_Click(object sender, EventArgs e)
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
                typeComboBox.Items.Clear();
                gradeComboBox.Items.Clear();
                categoryComboBox.Items.Clear();
                employeesGrid.Rows.Clear();
                questionnaireGrid.Rows.Clear();
                evaluationGrid.Rows.Clear();
                totalScoreTextBox.Text = "0";
                startDatePicker.ResetText();
                endDatePicker.ResetText();
                datePicker.ResetText();
                supervisorTextBox.Clear();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetStaffForCurrentAppraisal();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
