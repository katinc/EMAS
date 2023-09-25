using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRBussinessLayer.Staff_Information_CLASS;
using eMAS.All_UIs.Applicants;
using eMAS.All_UIs.Staff_Information_FORMS;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.Employment
{
    public partial class Interview : Form
    {
        private string interviewID;
        private DataTable namesTable;
        private DataTable documentsTable;
        private DataTable requirementsTable;
        private DataTable descriptionsTable;
        private DataTable assessmentTable;
        private DataTable commentsTable;
        private IList<Vacancy> vacancies;
        private IList<Applicant> applicants;
        private DAL dal;
        private DALHelper dalHelper;
        private bool editMode;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        List<Control> controls;
        List<controlObject> OldValues;


        public Interview()
        {
            try
            {
                InitializeComponent();
                interviewID = string.Empty;
                namesTable = new DataTable();
                documentsTable = new DataTable();
                requirementsTable = new DataTable();
                descriptionsTable = new DataTable();
                vacancies = new List<Vacancy>();
                dal = new DAL();
                dalHelper = new DALHelper();
                editMode = false;

                this.controls = new List<Control>();
                this.OldValues = new List<controlObject>();

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void statusComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                statusComboBox.Items.Clear();
                statusComboBox.Items.Add("Employed");
                statusComboBox.Items.Add("Rejected");
                statusComboBox.Items.Add("Review");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void nameComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                if (vacanyComboBox.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(vacanyComboBox, "Please select a vacancy");
                    nameComboBox.Text = string.Empty;
                    vacanyComboBox.Select();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void requirementsGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                requirementsGrid.CurrentCellDirtyStateChanged += new EventHandler(requirementsGrid_CurrentCellDirtyStateChanged);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void requirementsGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                decimal result = 0;
                foreach (DataGridViewRow row in requirementsGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["requirementsGridRating"].Value != null)
                        {
                            decimal temp = 0;
                            if (decimal.TryParse(row.Cells["requirementsGridRating"].Value.ToString().Trim(), out temp))
                            {
                                result += decimal.Parse(row.Cells["requirementsGridRating"].Value.ToString().Trim());
                            }
                            else
                            {
                                row.Cells["requirementsGridRating"].Value = 0;
                            }
                        }
                    }
                }
                totalScoreTextBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void vacanyComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                vacanyComboBox.Items.Clear();
                vacancies = dal.GetAll<Vacancy>();
                foreach (Vacancy vacancy in vacancies)
                {
                    vacanyComboBox.Items.Add(vacancy.Grade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Interview_Load(object sender, EventArgs e)
        {
            try
            {
                namesTable = dalHelper.ExecuteReader("Select ID,VacancyID,FirstName,OtherName,Surname From ApplicantView Where ApplicantView.Status='ShortListed' ");
                nameComboBox.Items.Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Visible = getPermissions.CanAdd;
                    btnView.Visible = getPermissions.CanView;
                    btnPreview.Visible = getPermissions.CanView;
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
            }
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gridDocuments.Rows.Clear();
                if (vacanyComboBox.Text.Trim() != string.Empty)
                {
                    dalHelper.OpenConnection();

                    documentsTable = dalHelper.ExecuteReader("Select * from ApplicantDocumentView Where ApplicantDocumentView.ApplicantID = " + namesTable.Rows[nameComboBox.SelectedIndex]["ID"].ToString());
                    commentsTable = dalHelper.ExecuteReader("Select * from InterviewCommentView Where InterviewCommentView.ApplicantID = " + namesTable.Rows[nameComboBox.SelectedIndex]["ID"].ToString());
                    int ctr = 0;
                    gridDocuments.Rows.Clear();
                    foreach (DataRow row in documentsTable.Rows)
                    {
                        gridDocuments.Rows.Add(1);
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDateCreated"].Value = row["DateCreated"];
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDescription"].Value = row["Description"];
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentContent"].Value = row["DocumentContent"];
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentGroup"].Value = row["DocumentGroup"];
                        gridDocuments.Rows[ctr].Cells["gridDocumentsPath"].Value = row["Path"];
                        ctr++;
                    }
                }
                else
                {
                    MessageBox.Show("Please select the Vacancy");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void vacanyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                dalHelper.OpenConnection();
                requirementsTable = dalHelper.ExecuteReader("Select * from VacanyJobRequirements Where VacancyID =" + vacancies[vacanyComboBox.SelectedIndex].ID);
                descriptionsTable = dalHelper.ExecuteReader("Select * from VacancyJobDescriptions Where VacancyID =" + vacancies[vacanyComboBox.SelectedIndex].ID);
                namesTable = dalHelper.ExecuteReader("Select * from ApplicantView Where ApplicantView.Status='ShortListed'  and ApplicantView.VacancyID = " + vacancies[vacanyComboBox.SelectedIndex].ID);

                nameComboBox.Items.Clear();
                nameComboBox.Text = string.Empty;
                gridDocuments.Rows.Clear();
                commentsGrid.Rows.Clear();

                foreach (DataRow applicant in namesTable.Rows)
                {
                    if (int.Parse(applicant["VacancyID"].ToString()) == vacancies[vacanyComboBox.SelectedIndex].ID)
                    {
                        nameComboBox.Items.Add(applicant["FirstName"].ToString() + (applicant["MiddleName"].ToString() == string.Empty ? " " : " " + applicant["MiddleName"].ToString() + " ") + applicant["Surname"].ToString());
                    }
                }

                int ctr = 0;
                requirementsGrid.Rows.Clear();
                foreach (DataRow row in requirementsTable.Rows)
                {
                    requirementsGrid.Rows.Add(1);
                    requirementsGrid.Rows[ctr].Cells["requirementsGridRequirement"].Value = row["Description"].ToString();
                    ctr++;
                }

                ctr = 0;
                descriptionsGrid.Rows.Clear();
                foreach (DataRow row in descriptionsTable.Rows)
                {
                    descriptionsGrid.Rows.Add(1);
                    descriptionsGrid.Rows[ctr].Cells["descriptionsGridDescription"].Value = row["Description"].ToString();
                    ctr++;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnJobDescription_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnJobDescription.Text == "Job Requirements")
                {
                    requirementsGrid.Visible = true;
                    descriptionsGrid.Visible = false;
                    btnJobDescription.Text = "Job Descriptions";
                }
                else
                {
                    requirementsGrid.Visible = false;
                    descriptionsGrid.Visible = true;
                    btnJobDescription.Text = "Job Requirements";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFiels()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();

                if (vacanyComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(vacanyComboBox, "Please select a vacancy");
                }

                if (nameComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(nameComboBox, "Please enter or select an applicant");
                }

                if (statusComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(statusComboBox, "Please select the status of the applicant");
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
                errorProvider.Clear();
                nameComboBox.Text = string.Empty;
                vacanyComboBox.Items.Clear();
                vacanyComboBox.Text = string.Empty;
                requirementsGrid.Rows.Clear();
                descriptionsGrid.Rows.Clear();
                commentsGrid.Rows.Clear();
                totalScoreTextBox.Text = "0";
                statusComboBox.Items.Clear();
                gridDocuments.Rows.Clear();
                statusComboBox.Text = string.Empty;
                editMode = false;
                label13.Text = "New Interview";
                interviewID = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFiels())
                {
                    string applicantID = string.Empty;
                    dalHelper.BeginTransaction();

                    dalHelper.ClearParameters();
                    namesTable = dalHelper.ExecuteReader("Select ID,VacancyID,FirstName,MiddleName,Surname From ApplicantView ");
                    dalHelper.ClearParameters();
                    string name = string.Empty;
                    dalHelper.CreateParameter("@VacancyID", vacancies[vacanyComboBox.SelectedIndex].ID, DbType.Int32);
                    foreach (DataRow row in namesTable.Rows)
                    {
                        name = row["FirstName"].ToString().Trim() + (row["MiddleName"].ToString().Trim() == string.Empty ? " " : " " + row["MiddleName"].ToString().Trim() + " ") + row["Surname"].ToString().Trim();
                        if (nameComboBox.Text.Trim() == name)
                        {
                            applicantID = row["ID"].ToString();
                            dalHelper.CreateParameter("@ApplicantID", row["ID"].ToString(), DbType.Int32);
                            break;
                        }
                    }

                    dalHelper.CreateParameter("@TotalScore", totalScoreTextBox.Text, DbType.Decimal);
                    dalHelper.CreateParameter("@Status", statusComboBox.Text, DbType.String);
                    dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                    if (editMode)
                    {
                        dalHelper.CreateParameter("@ID", this.interviewID, DbType.String);
                        //dalHelper.ExecuteNonQuery("Update Interviews Set VacancyID=@VacancyID ,ApplicantID=@ApplicantID,TotalScore=@TotalScore,Status=@Status,UserID=@UserID Where ID=@ID");
                        GlobalData.ProcessEdit(OldValues, controls, this, Convert.ToInt32(this.interviewID), interviewID.ToString());
                    }
                    else
                    {
                        dalHelper.ExecuteNonQuery("Insert Into Interviews(VacancyID,ApplicantID,TotalScore,Status,UserID) Values(@VacancyID,@ApplicantID,@TotalScore,@Status,@UserID)");
                        interviewID = dalHelper.ExecuteScalar("Select Max(ID) from Interviews").ToString();
                    }

                    dalHelper.ExecuteNonQuery("Delete From InterviewAssessment Where InterviewID = " + interviewID);
                    foreach (DataGridViewRow row in requirementsGrid.Rows)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@InterviewID", interviewID, DbType.Int32);
                        dalHelper.CreateParameter("@Requirement", row.Cells["requirementsGridRequirement"].Value.ToString(), DbType.String);
                        if (row.Cells["requirementsGridRating"].Value == null)
                        {
                            dalHelper.CreateParameter("@Rating", 0, DbType.Decimal);
                        }
                        else if (row.Cells["requirementsGridRating"].Value.ToString() == string.Empty)
                        {
                            dalHelper.CreateParameter("@Rating", 0, DbType.Decimal);
                        }
                        else
                        {
                            dalHelper.CreateParameter("@Rating", row.Cells["requirementsGridRating"].Value, DbType.Decimal);
                            
                        }
                        dalHelper.ExecuteNonQuery("Insert Into InterviewAssessment(InterviewID,Requirement,Rating) Values(@InterviewID,@Requirement,@Rating)");
                    }

                    dalHelper.ExecuteNonQuery("Delete From InterviewComments Where InterviewID = " + interviewID);
                    foreach (DataGridViewRow row in commentsGrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            dalHelper.ClearParameters();
                            dalHelper.CreateParameter("@InterviewID", interviewID, DbType.Int32);
                            dalHelper.CreateParameter("@comment", row.Cells["gridComments"].Value.ToString(), DbType.String);
                            dalHelper.ExecuteNonQuery("Insert Into InterviewComments (InterviewID,Comment) Values(@InterviewID,@Comment)");
                        }
                    }

                    dalHelper.ClearParameters();
                    dalHelper.ExecuteNonQuery("Update Applicants Set Status = '" + statusComboBox.Text + "' Where ID = " + applicantID);
                    namesTable = dalHelper.ExecuteReader("Select ID,VacancyID,FirstName,MiddleName,Surname From Applicants Where Status='ShortListed' ");
                    dalHelper.CommitTransaction();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                dalHelper.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Not save successfully");
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

        public void EditInterview(DataGridViewRow item)
        {
            try
            {
                Clear();
                editMode = true;
                vacancies = dal.GetAll<Vacancy>();
                interviewID = item.Cells["gridID"].Value.ToString();
                namesTable = dalHelper.ExecuteReader("Select ID,VacancyID,FirstName,MiddleName,Surname From ApplicantView Where Status='ShortListed' ");
                assessmentTable = dalHelper.ExecuteReader("Select * from InterviewAssessmentView Where InterviewID =" + item.Cells["gridID"].Value.ToString());
                descriptionsTable = dalHelper.ExecuteReader("Select * from VacancyJobDescriptions Where VacancyID =" + item.Cells["gridVacancyID"].Value.ToString());
                commentsTable = dalHelper.ExecuteReader("Select * from InterviewCommentView Where InterviewID = " + item.Cells["gridID"].Value.ToString());

                vacanyComboBox.Items.Clear();
                foreach (Vacancy vacancy in vacancies)
                {
                    vacanyComboBox.Items.Add(vacancy.Grade.Grade);
                }
                vacanyComboBox.SelectedIndex = vacanyComboBox.Items.IndexOf(item.Cells["gridVacancy"].Value.ToString());

                nameComboBox.Items.Clear();
                foreach (DataRow applicant in namesTable.Rows)
                {
                    nameComboBox.Items.Add(applicant["FirstName"].ToString() + (applicant["MiddleName"].ToString() == string.Empty ? " " : " " + applicant["MiddleName"].ToString() + " ") + applicant["Surname"].ToString());
                }
                nameComboBox.Text = item.Cells["gridName"].Value.ToString();


                int ctr = 0;
                requirementsGrid.Rows.Clear();
                foreach (DataRow row in assessmentTable.Rows)
                {
                    requirementsGrid.Rows.Add(1);
                    requirementsGrid.Rows[ctr].Cells["requirementsGridRequirement"].Value = row["Requirement"].ToString();
                    requirementsGrid.Rows[ctr].Cells["requirementsGridRating"].Value = row["Rating"].ToString();
                    ctr++;
                }

                ctr = 0;
                descriptionsGrid.Rows.Clear();
                foreach (DataRow row in descriptionsTable.Rows)
                {
                    descriptionsGrid.Rows.Add(1);
                    descriptionsGrid.Rows[ctr].Cells["descriptionsGridDescription"].Value = row["Description"].ToString();
                    ctr++;
                }

                ctr = 0;
                commentsGrid.Rows.Clear();
                foreach (DataRow row in commentsTable.Rows)
                {
                    commentsGrid.Rows.Add(1);
                    commentsGrid.Rows[ctr].Cells["gridComments"].Value = row["Comment"];
                    ctr++;
                }
                totalScoreTextBox.Text = item.Cells["gridTotalScore"].Value.ToString();
                statusComboBox_DropDown(this, EventArgs.Empty);
                statusComboBox.Text = item.Cells["gridStatus"].Value.ToString();
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(item.Cells["gridUserID"].Value.ToString()))
                {
                    btnSave.Enabled = false;
                }
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
                InterviewMaintenance form = new InterviewMaintenance(this);
                form.MdiParent = this.MdiParent;
                form.btnRemove.Visible = CanDelete;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDocuments.CurrentRow != null)
                {
                    PDFReader reader = new PDFReader(gridDocuments.CurrentRow.Cells["gridDocumentsPath"].Value.ToString());
                    reader.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
