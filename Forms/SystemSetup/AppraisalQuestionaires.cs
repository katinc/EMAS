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


namespace eMAS.Forms.SystemSetup
{
    public partial class AppraisalQuestionaires : Form
    {
        private DALHelper dalHelper = new DALHelper();
        private DataTable appraisalTypesTable;
        private DataTable gradesTable;
        private DataTable gradeCategoryTable;
        private DataTable subjectiveQuestionsTable;
        private DataTable objectiveQuestionsTable;
        private IDAL dal;

        public AppraisalQuestionaires()
        {
            try
            {
                InitializeComponent();
                dalHelper = new DALHelper();
                dal = new DAL();
                appraisalTypesTable = new DataTable();
                gradesTable = new DataTable();
                gradeCategoryTable = new DataTable();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gradeCategoryComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                gradeCategoryComboBox.Items.Clear();
                gradeCategoryTable = dalHelper.ExecuteReader("Select ID,Description From GradeCategory_Setup Where Active = 'True' and Archived='False'");
                foreach (DataRow row in gradeCategoryTable.Rows)
                {
                    gradeCategoryComboBox.Items.Add(row["Description"].ToString());
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void subjectiveGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in subjectiveGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["subGridNo"].Value == null)
                        {
                            row.Cells["subGridNo"].Value = GenerateQuestionNo();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridNo"].Value == null)
                        {
                            row.Cells["gridNo"].Value = GenerateQuestionNo();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private int GenerateQuestionNo()
        {
            int gridNo = 0;
            int subGridNo = 0;
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridNo"].Value != null)
                        {
                            gridNo = int.Parse(row.Cells["gridNo"].Value.ToString());
                        }
                    }
                }
                foreach (DataGridViewRow row in subjectiveGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["subGridNo"].Value != null)
                        {
                            subGridNo = int.Parse(row.Cells["subGridNo"].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            if (gridNo > subGridNo)
            {
                return gridNo +1;
            }
            else
            {
                return subGridNo +1;
            }

        }

        void gradeComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (gradeCategoryComboBox.Text.Trim() != string.Empty)
                {
                    gradeComboBox.Items.Clear();
                    gradesTable = dalHelper.ExecuteReader("Select ID,Description From EmployeeGrades_Setup Where CategoryID=" + gradeCategoryTable.Rows[gradeCategoryComboBox.SelectedIndex]["ID"].ToString() + " And Active='True' And Archived='False'");
                    foreach (DataRow row in gradesTable.Rows)
                    {
                        gradeComboBox.Items.Add(row["Description"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void appraisalTypesComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                appraisalTypesComboBox.Items.Clear();
                appraisalTypesTable = dalHelper.ExecuteReader("Select ID,Description From AppraisalTypes Where Archived='False'");
                foreach (DataRow row in appraisalTypesTable.Rows)
                {
                    appraisalTypesComboBox.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void AppraisalQuestionaires_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditQuestionaire(DataGridViewRow row)
        {
            try
            {
                appraisalTypesComboBox_DropDown(this, EventArgs.Empty);
                gradeCategoryComboBox_DropDown(this, EventArgs.Empty);
                
                subjectiveGrid.Rows.Clear();
                grid.Rows.Clear();

                appraisalTypesComboBox.Text = row.Cells["AppraisalType"].Value.ToString();
                string gradeID = row.Cells["GradeID"].Value.ToString();
                string categoryID = row.Cells["GradeCategoryID"].Value.ToString();
                string appraisalID = row.Cells["ID"].Value.ToString();

                foreach (DataRow row1 in gradeCategoryTable.Rows)
                {
                    if (row1["ID"].ToString() == categoryID)
                    {
                        gradeCategoryComboBox.Text = row1["Description"].ToString();
                    }
                }
                gradeComboBox_DropDown(this, EventArgs.Empty);
                gradeComboBox.Text = row.Cells["Grade"].Value.ToString();
                startDatePicker.Text = row.Cells["StartDate"].Value.ToString();
                endDatePicker.Text = row.Cells["EndDate"].Value.ToString();

                objectiveQuestionsTable = dalHelper.ExecuteReader("Select * from AppraisalQuestionaires inner join AppraisalForms ON AppraisalForms.ID = AppraisalQuestionaires.AppraisalID Where AppraisalQuestionaires.AppraisalID=" + appraisalID + " and AppraisalQuestionaires.Type='Objective' and AppraisalForms.Archived='False'");
                int ctr = 0;
                grid.Rows.Clear();
                foreach (DataRow row1 in objectiveQuestionsTable.Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridNo"].Value = row1["QuestionNo"].ToString();
                    grid.Rows[ctr].Cells["gridQuestion"].Value = row1["Question"].ToString();
                    grid.Rows[ctr].Cells["gridAnswerA"].Value = row1["AnswerA"].ToString();
                    grid.Rows[ctr].Cells["gridAnswerB"].Value = row1["AnswerB"].ToString();
                    grid.Rows[ctr].Cells["gridAnswerC"].Value = row1["AnswerC"].ToString();
                    grid.Rows[ctr].Cells["gridAnswerD"].Value = row1["AnswerD"].ToString();
                    grid.Rows[ctr].Cells["gridAnswerE"].Value = row1["AnswerE"].ToString();
                    ctr++;
                }

                subjectiveQuestionsTable = dalHelper.ExecuteReader("Select * from AppraisalQuestionaires inner join AppraisalForms ON AppraisalForms.ID = AppraisalQuestionaires.AppraisalID Where AppraisalQuestionaires.AppraisalID=" + appraisalID + " and AppraisalQuestionaires.Type='Subjective' and AppraisalForms.Archived='False'");
                ctr = 0;
                subjectiveGrid.Rows.Clear();
                foreach (DataRow row1 in subjectiveQuestionsTable.Rows)
                {
                    subjectiveGrid.Rows.Add(1);
                    subjectiveGrid.Rows[ctr].Cells["subGridNo"].Value = row1["QuestionNo"].ToString();
                    subjectiveGrid.Rows[ctr].Cells["subGridQuestion"].Value = row1["Question"].ToString();
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    dalHelper.BeginTransaction();
                    //int ctr = dal.ExecuteReader("Select AppraisalForms.ID,AppraisalForms.TypeID,AppraisalTypes.Description as AppraisalType,AppraisalForms.GradeID,EmployeeGrades_Setup.Description as Grade, AppraisalForms.StartDate,AppraisalForms.EndDate From AppraisalForms inner join AppraisalTypes on AppraisalTypes.ID = AppraisalForms.TypeID inner join EmployeeGrades_Setup on EmployeeGrades_Setup.ID = AppraisalForms.GradeID Where AppraisalTypes.Archived ='False' And AppraisalForms.Archived = 'False' And TypeID =" + appraisalTypesTable.Rows[appraisalTypesComboBox.SelectedIndex]["ID"] + " And GradeID=  " + gradesTable.Rows[gradeComboBox.SelectedIndex]["ID"] + "  And EndDate < '" + startDatePicker.Text + "' Or StartDate > '"+ endDatePicker.Text  +"' ").Rows.Count ;
                    int ctr = dalHelper.ExecuteReader("Select AppraisalForms.ID,AppraisalForms.TypeID,AppraisalTypes.Description as AppraisalType,AppraisalForms.GradeID,EmployeeGrades_Setup.Description as Grade, AppraisalForms.StartDate,AppraisalForms.EndDate From AppraisalForms inner join AppraisalTypes on AppraisalTypes.ID = AppraisalForms.TypeID inner join EmployeeGrades_Setup on EmployeeGrades_Setup.ID = AppraisalForms.GradeID Where AppraisalTypes.Archived ='False' And AppraisalForms.Archived = 'False' And TypeID =" + appraisalTypesTable.Rows[appraisalTypesComboBox.SelectedIndex]["ID"] + " And GradeID=  " + gradesTable.Rows[gradeComboBox.SelectedIndex]["ID"] + "  And (('" + startDatePicker.Text + "' >= StartDate and '" + endDatePicker.Text + "' <= EndDate) or ('" + startDatePicker.Text + "' >= StartDate and '" + endDatePicker.Text + "' <= EndDate)) ").Rows.Count;
                    if (ctr == 0)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@TypeID", appraisalTypesTable.Rows[appraisalTypesComboBox.SelectedIndex]["ID"], DbType.Int32);
                        dalHelper.CreateParameter("@GradeID", gradesTable.Rows[gradeComboBox.SelectedIndex]["ID"], DbType.Int32);
                        dalHelper.CreateParameter("@StartDate", startDatePicker.Text, DbType.DateTime);
                        dalHelper.CreateParameter("@EndDate", endDatePicker.Text, DbType.DateTime);
                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                        dalHelper.ExecuteNonQuery("Insert Into AppraisalForms(TypeID,GradeID,StartDate,EndDate,UserID) Values(@TypeID,@GradeID,@StartDate,@EndDate,@UserID)");

                        string appraisalID = dalHelper.ExecuteScalar("Select Max(ID) From AppraisalForms").ToString();
                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            dalHelper.ClearParameters();
                            if (!row.IsNewRow)
                            {
                                dalHelper.CreateParameter("@AppraisalID", appraisalID, DbType.String);
                                dalHelper.CreateParameter("@QuestionNo", row.Cells["gridNo"].Value, DbType.Int32);
                                dalHelper.CreateParameter("@Question", row.Cells["gridQuestion"].Value, DbType.String);
                                dalHelper.CreateParameter("@AnswerA", row.Cells["gridAnswerA"].Value, DbType.String);
                                dalHelper.CreateParameter("@AnswerB", row.Cells["gridAnswerB"].Value, DbType.String);
                                dalHelper.CreateParameter("@AnswerC", row.Cells["gridAnswerC"].Value, DbType.String);
                                dalHelper.CreateParameter("@AnswerD", row.Cells["gridAnswerD"].Value, DbType.String);
                                dalHelper.CreateParameter("@AnswerE", row.Cells["gridAnswerE"].Value, DbType.String);
                                dalHelper.CreateParameter("@Type", "Objective", DbType.String);
                                dalHelper.ExecuteNonQuery("Insert Into AppraisalQuestionaires(AppraisalID,QuestionNo,Question,AnswerA,AnswerB,AnswerC,AnswerD,AnswerE,Type) Values(@AppraisalID,@QuestionNo,@Question,@AnswerA,@AnswerB,@AnswerC,@AnswerD,@AnswerE,@Type)");
                            }
                        }

                        foreach (DataGridViewRow row in subjectiveGrid.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                dalHelper.ClearParameters();
                                dalHelper.CreateParameter("@AppraisalID", appraisalID, DbType.String);
                                dalHelper.CreateParameter("@Question", row.Cells["subGridQuestion"].Value, DbType.String);
                                dalHelper.CreateParameter("@QuestionNo", row.Cells["subGridNo"].Value, DbType.Int32);
                                dalHelper.CreateParameter("@Type", "Subjective", DbType.String);
                                dalHelper.ExecuteNonQuery("Insert Into AppraisalQuestionaires(AppraisalID,QuestionNo,Question,Type) Values(@AppraisalID,@QuestionNo,@Question,@Type)");
                            }
                        }

                        dalHelper.CommitTransaction();
                        Clear();
                    }
                    else
                    {
                        GlobalData.ShowMessage("The appraisal you are trying to setup already exists for a similar period.");
                    }
                    
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    dalHelper.RollBackTransaction();
                }
            }

        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                ErrorProvider.Clear();

                if (appraisalTypesComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    ErrorProvider.SetError(appraisalTypesComboBox, "Please select the type of appraisal");
                }
                if (gradeComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    ErrorProvider.SetError(gradeComboBox, "Please select a grade");
                }

                if (DateTime.Parse(startDatePicker.Text) > DateTime.Parse(endDatePicker.Text))
                {
                    result = false;
                    ErrorProvider.SetError(startDatePicker, "The start date for the appraisal cannot be greater than the end date");
                }

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridAnswerA"] == null)
                        {
                            result = false;
                            ErrorProvider.SetError(groupBox3, "At least two answers must be provided in the answer a and answer b columns on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridAnswerA"].Value == null)
                        {
                            result = false;
                            ErrorProvider.SetError(groupBox3, "At least two answers must be provided in the answer a and answer b columns on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridAnswerA"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            ErrorProvider.SetError(groupBox3, "At least two answers must be provided in the answer a and answer b columns on row " + (row.Index + 1));
                        }
                        if (row.Cells["gridAnswerB"] == null)
                        {
                            result = false;
                            ErrorProvider.SetError(groupBox3, "At least two answers must be provided in the answer a and answer b columns on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridAnswerB"].Value == null)
                        {
                            result = false;
                            ErrorProvider.SetError(groupBox3, "At least two answers must be provided in the answer a and answer b columns on row " + (row.Index + 1));
                        }
                        else if (row.Cells["gridAnswerB"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            ErrorProvider.SetError(groupBox3, "At least two answers must be provided in the answer a and answer b columns on row " + (row.Index + 1));
                        }
                        if (row.Cells["gridAnswerC"].Value == null)
                        {
                            row.Cells["gridAnswerC"].Value = string.Empty;
                        }
                        if (row.Cells["gridAnswerD"].Value == null)
                        {
                            row.Cells["gridAnswerD"].Value = string.Empty;
                        }
                        if (row.Cells["gridAnswerE"].Value == null)
                        {
                            row.Cells["gridAnswerE"].Value = string.Empty;
                        }
                    }
                }

                foreach (DataGridViewRow row in subjectiveGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["subGridQuestion"] == null)
                        {
                            result = false;
                            ErrorProvider.SetError(groupBox1, "Please enter a question on row " + (row.Index));
                        }
                        else if (row.Cells["subGridQuestion"].Value == null)
                        {
                            result = false;
                            ErrorProvider.SetError(groupBox1, "Please enter a question on row " + (row.Index));
                        }
                        else if (row.Cells["subGridQuestion"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            ErrorProvider.SetError(groupBox1, "Please enter a question on row " + (row.Index));
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
                grid.Rows.Clear();
                subjectiveGrid.Rows.Clear();
                appraisalTypesComboBox.Items.Clear();
                appraisalTypesComboBox.Text = string.Empty;
                gradeCategoryComboBox.Items.Clear();
                gradeCategoryComboBox.Text = string.Empty;
                gradeComboBox.Items.Clear();
                gradeComboBox.Text = string.Empty;
                startDatePicker.ResetText();
                endDatePicker.ResetText();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                AppraisalQuestionaireView form = new AppraisalQuestionaireView(this);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
