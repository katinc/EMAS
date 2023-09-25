using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.ErrorLogging;


namespace eMAS.Forms.StaffInformation
{
    public partial class EmployeeAppraisal : Form
    {
        private string appraisalTypeID;
        private string gradeID;
        private int rowIndex;
        private IList<Employee> employees;
        private Employee employee;
        private DataTable appraisalFormTable;
        private DataTable appraisalAnswers;
        private DataTable appraisalQuestionnaireTable;
        private DALHelper dalHelper;
        private IDAL dal;
        private int staffCode;
        private string month;
        private string year;
        private string assessor;

        public EmployeeAppraisal(Employee employee,string gradeID,string appraisalTypeID,string assessor,string month,string year)
        {
            InitializeComponent();
            this.appraisalTypeID = appraisalTypeID;
            this.gradeID = gradeID;
            this.assessor = assessor;
            this.month = month;
            this.year = year;
            this.rowIndex = 0;
            this.staffCode = 0;
            this.appraisalFormTable = new DataTable();
            this.appraisalQuestionnaireTable = new DataTable();
            this.employee = employee;
            this.dalHelper = new DALHelper();
            this.employees = new List<Employee>();
            this.dal = new DAL();
        }

        public EmployeeAppraisal()
        {
            InitializeComponent();
            this.appraisalTypeID = string.Empty;
            this.gradeID = string.Empty;
            this.assessor = string.Empty;
            this.month = string.Empty;
            this.year = string.Empty;
            this.rowIndex = 0;
            this.staffCode = 0;
            this.appraisalFormTable = new DataTable();
            this.appraisalQuestionnaireTable = new DataTable();
            this.employee = new Employee();
            this.dalHelper = new DALHelper();
            this.employees = new List<Employee>();
            this.dal = new DAL();
        }
        
        private void EmployeeAppraisal_Load(object sender, EventArgs e)
        {           
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                nametxt.Text = name;
                staffIDtxt.Text = employee.StaffID;
                staffCode = employee.ID;
                gendertxt.Text = employee.Gender;
                txtAssessor.Text = assessor;
                cboAssessmentMonth_DropDown(this,EventArgs.Empty);
                cboAssessmentMonth.Text = month;
                cboAssessmentYear_DropDown(this, EventArgs.Empty);
                cboAssessmentYear.Text = year;
                if (employee.Photo != null)
                {
                    pictureBox.Image = employee.Photo;
                }
                else
                {
                    pictureBox.Image = pictureBox.InitialImage;
                }
                agetxt.Text = employee.Age;
                appraisalFormTable = dalHelper.ExecuteReader("Select * From AppraisalForms Where GradeID =" + gradeID + " And TypeID= " + appraisalTypeID +" And Archived = 'False'");

                if (appraisalFormTable.Rows.Count > 0)
                {
                    startDatePicker.Text = appraisalFormTable.Rows[0]["StartDate"].ToString();
                    endDatePicker.Text = appraisalFormTable.Rows[0]["EndDate"].ToString();
                    appraisalQuestionnaireTable = dalHelper.ExecuteReader("Select ID,QuestionNo,Question,AnswerA,AnswerB,AnswerC,AnswerD,AnswerE,Type From AppraisalQuestionaires Where AppraisalID =" + appraisalFormTable.Rows[0]["ID"].ToString() + " order by QuestionNo ASC");
                    FormatViewForQuestion(appraisalQuestionnaireTable.Rows[0]);
                }
                else
                {
                    MessageBox.Show("A network problem occured. Please try again.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error :Please see the System Administrator.");
                this.Close();
            }
        }

        private void FormatViewForQuestion(DataRow row)
        {
            try
            {
                questionLabel.Text = string.Empty;
                questionLabel.Text = row["QuestionNo"].ToString() + ". " + row["Question"].ToString();
                appraisalAnswers = dalHelper.ExecuteReader("Select ID,AppraisalID,StaffID,QuestionNo,Answer From AppraisalAnswers Where QuestionNo =" + row["QuestionNo"].ToString() + " And AppraisalID =" + appraisalFormTable.Rows[0]["ID"].ToString() + " And StaffID ='" + employee.StaffID + "' And AssessmentMonth='" + month + "' And AssessmentYear='" + year + "'");

                if (row["Type"].ToString() == "Objective")
                {
                    objectivesPanel.Visible = true;
                    answerTextBox.Visible = false;

                    if (row["AnswerA"].ToString().Trim() != string.Empty)
                    {
                        aRadioButton.Visible = true;
                        aRadioButton.Text = row["AnswerA"].ToString();
                    }
                    else
                    {
                        aRadioButton.Visible = false;
                        aRadioButton.Text = string.Empty;
                    }

                    if (row["AnswerB"].ToString().Trim() != string.Empty)
                    {
                        bRadioButton.Text = row["AnswerB"].ToString();
                        bRadioButton.Visible = true;
                    }
                    else
                    {
                        bRadioButton.Visible = false;
                        bRadioButton.Text = string.Empty;
                    }

                    if (row["AnswerC"].ToString().Trim() != string.Empty)
                    {
                        cRadioButton.Text = row["AnswerC"].ToString();
                        cRadioButton.Visible = true;
                    }
                    else
                    {
                        cRadioButton.Visible = false;
                        cRadioButton.Text = string.Empty;
                    }

                    if (row["AnswerD"].ToString().Trim() != string.Empty)
                    {
                        dRadioButton.Text = row["AnswerD"].ToString();
                        dRadioButton.Visible = true;
                    }
                    else
                    {
                        dRadioButton.Visible = false;
                        dRadioButton.Text = string.Empty;
                    }

                    if (row["AnswerE"].ToString().Trim() != string.Empty)
                    {
                        eRadioButton.Visible = true;
                        eRadioButton.Text = row["AnswerE"].ToString();
                    }
                    else
                    {
                        eRadioButton.Visible = false;
                        eRadioButton.Text = string.Empty;
                    }
                    titleLabel.Text = "Please select One Answer";

                    foreach (DataRow item in appraisalAnswers.Rows)
                    {
                        if (item["QuestionNo"].ToString() == row["QuestionNo"].ToString())
                        {
                            if (item["Answer"].ToString() == aRadioButton.Text)
                            {
                                aRadioButton.Checked = true;
                            }
                            else if (item["Answer"].ToString() == bRadioButton.Text)
                            {
                                bRadioButton.Checked = true;
                            }
                            else if (item["Answer"].ToString() == cRadioButton.Text)
                            {
                                cRadioButton.Checked = true;
                            }
                            else if (item["Answer"].ToString() == dRadioButton.Text)
                            {
                                dRadioButton.Checked = true;
                            }
                            else if (item["Answer"].ToString() == eRadioButton.Text)
                            {
                                eRadioButton.Checked = true;
                            }
                        }
                    }

                }
                else
                {
                    objectivesPanel.Visible = false;
                    answerTextBox.Clear();
                    answerTextBox.Visible = true;
                    foreach (DataRow item in appraisalAnswers.Rows)
                    {
                        if (item["QuestionNo"].ToString() == row["QuestionNo"].ToString())
                        {
                            answerTextBox.Text = item["Answer"].ToString();
                        }
                    }
                    titleLabel.Text = "Please type your answer in the space provided below";
                }
                if (!aRadioButton.Checked && !bRadioButton.Checked && !cRadioButton.Checked && !dRadioButton.Checked && !eRadioButton.Checked)
                {
                    aRadioButton.Checked = true;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    string ans = string.Empty;
                    dal.BeginTransaction();
                    if (!answerTextBox.Visible)
                    {
                        if (aRadioButton.Checked)
                        {
                            ans = aRadioButton.Text;
                        }
                        if (bRadioButton.Checked)
                        {
                            ans = bRadioButton.Text;
                        }
                        if (cRadioButton.Checked)
                        {
                            ans = cRadioButton.Text;
                        }
                        if (dRadioButton.Checked)
                        {
                            ans = dRadioButton.Text;
                        }
                        if (eRadioButton.Checked)
                        {
                            ans = eRadioButton.Text;
                        }
                    }
                    else
                    {
                        ans = answerTextBox.Text;
                    }

                    object result = dalHelper.ExecuteScalar("Select ID From AppraisalAnswers Where QuestionNo=" + appraisalQuestionnaireTable.Rows[rowIndex]["QuestionNo"].ToString().ToString() + " And AppraisalID =" + appraisalFormTable.Rows[0]["ID"].ToString() + " And  StaffID='" + employee.StaffID + "' And AssessmentMonth='" + cboAssessmentMonth.Text + "' And AssessmentYear= '" + cboAssessmentYear.Text + "' ");
                    if (result == null)
                    {
                        dalHelper.ExecuteNonQuery("Insert Into AppraisalAnswers(AppraisalID,QuestionNo,StaffID,StaffCode,Answer,Assessor,AssessmentMonth,AssessmentYear,UserID) Values(" + appraisalFormTable.Rows[0]["ID"].ToString() + "," + appraisalQuestionnaireTable.Rows[rowIndex]["QuestionNo"].ToString() + ",'" + employee.StaffID + "','" + staffCode + "','" + ans + "','" + txtAssessor.Text.Trim() + "','" + cboAssessmentMonth.Text.Trim() + "','" + cboAssessmentYear.Text.Trim() + "','" + GlobalData.User.ID + "' )");
                    }
                    else
                    {
                        int tempID = int.Parse(result.ToString());
                        dalHelper.ExecuteNonQuery("Update AppraisalAnswers Set AppraisalID=" + appraisalFormTable.Rows[0]["ID"].ToString() + ",QuestionNo=" + appraisalQuestionnaireTable.Rows[rowIndex]["QuestionNo"].ToString() + ",StaffID='" + employee.StaffID + "',Answer='" + ans + "' Where ID=" + tempID);
                    }

                    if (rowIndex < appraisalQuestionnaireTable.Rows.Count - 1)
                    {
                        rowIndex++;
                        FormatViewForQuestion(appraisalQuestionnaireTable.Rows[rowIndex]);
                    }
                    else
                    {
                        EmployeeAppraisalFinishPage form = new EmployeeAppraisalFinishPage();
                        form.Owner = this;
                        this.Hide();
                        form.Show();
                    }
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowIndex > 0)
                {
                    rowIndex--;
                    FormatViewForQuestion(appraisalQuestionnaireTable.Rows[rowIndex]);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        //private void txtAssessor_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
                //if (txtAssessor.Text.Trim() != string.Empty)
                //{
                //    staffErrorProvider.Clear();
                //    searchGrid.Rows.Clear();
                //    searchGrid.BringToFront();
                //    int ctr = 0;
                //    bool found = false;
                //    if (employees.Count <= 0)
                //    {
                //        employees = DAL.LazyLoad<Employee>();
                //    }
                //    foreach (Employee employee in employees)
                //    {
                //        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                //        if (name.Trim().ToLower().StartsWith(txtAssessor.Text.Trim().ToLower()))
                //        {
                //            found = true;
                //            searchGrid.Rows.Add(1);
                //            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                //            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                //            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                //            ctr++;

                //        }
                //    }
                //    if (found)
                //    {
                //        if (searchGrid.RowCount == 2)
                //        {
                //            searchGrid.Height = searchGrid.RowCount * 24;
                //        }
                //        else
                //        {
                //            searchGrid.Height = searchGrid.RowCount * 23;
                //        }
                //        searchGrid.Location = new Point(txtAssessor.Location.X, txtAssessor.Location.Y + 22);
                //        searchGrid.BringToFront();
                //        searchGrid.Visible = true;
                //    }
                //    else
                //    {
                //        searchGrid.Visible = false;
                //    }
                //}
                //else
                //{
                //    Clear();
                //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    Clear();
                    if(employees.Count <= 0)
                    {
                        employees = dal.LazyLoad<Employee>();
                    }
                    
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            txtAssessor.Text = name;
                            staffCode = employee.ID;
                            searchGrid.Visible = false;
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

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                if (txtAssessor.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtAssessor, "Please Enter the Name of the Assessor");
                    txtAssessor.Focus();
                }
                else if (cboAssessmentMonth.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboAssessmentMonth, "Please select the Month");
                    cboAssessmentMonth.Focus();
                }
                else if (cboAssessmentYear.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboAssessmentYear, "Please select the Year");
                    cboAssessmentYear.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void Clear()
        {
            try
            {
                staffErrorProvider.Clear();
                txtAssessor.Clear();
                searchGrid.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void cboAssessmentMonth_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAssessmentMonth.Items.Clear();
                foreach (string item in GlobalData.GetMonthsToDate())
                {
                    cboAssessmentMonth.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void cboAssessmentYear_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAssessmentYear.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    cboAssessmentYear.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
            }
        }
    }
}
