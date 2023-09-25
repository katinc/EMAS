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
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using eMAS.All_UIs.Applicants;
using eMAS.All_UIs.Staff_Information_FORMS;
using eMAS.Forms.Employment;

namespace eMAS.Forms.StaffInformation
{
    public partial class ApplicantMaintenance : Form
    {
        private IDAL dal;
        private DALHelper dalHelper;
        private NewApplicant newApplicant;
        private IList<Applicant> applicants;
        private IList<Vacancy> vacancies;
        private Vacancy vacancy;
        private bool found;

        public ApplicantMaintenance()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dalHelper = new DALHelper();
                this.newApplicant = new NewApplicant();
                this.applicants = new List<Applicant>();
                this.vacancies = new List<Vacancy>();
                this.vacancy = new Vacancy();
                this.found = false;
                grid.SelectionChanged += new EventHandler(grid_SelectionChanged);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public ApplicantMaintenance(IDAL dal,NewApplicant newApplicant)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.dalHelper = new DALHelper();
                this.newApplicant = newApplicant;
                this.applicants = new List<Applicant>();
                this.vacancies = new List<Vacancy>();
                this.vacancy = new Vacancy();
                this.found = false;
                grid.SelectionChanged += new EventHandler(grid_SelectionChanged);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    int ctr = 0;
                    gridDocuments.Rows.Clear();
                    foreach (StaffDocument document in applicants[grid.CurrentRow.Index].Documents)
                    {
                        gridDocuments.Rows.Add(1);
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDateCreated"].Value = document.DateCreated;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDescription"].Value = document.Description;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentContent"].Value = document.DocumentContent;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentGroup"].Value = document.DocumentGroup;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsPath"].Value = document.Path;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsUserID"].Value = document.User.ID;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void Clear()
        {
            try
            {
                grid.Rows.Clear();
                gridDocuments.Rows.Clear();
                cboVacancy.Items.Clear();
                txtEmail.Clear();
                txtSurname.Clear();
                txtFirstName.Clear();
                txtMiddleName.Clear();
                txtContactNo.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ApplicantMaintenance_Load(object sender, EventArgs e)
        {         
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    Applicant applicant = new Applicant();
                    applicant.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    applicant.FirstName = grid.CurrentRow.Cells["gridFirstName"].Value.ToString();
                    applicant.MiddleName = grid.CurrentRow.Cells["gridMiddleName"].Value.ToString();
                    applicant.Surname = grid.CurrentRow.Cells["gridSurname"].Value.ToString();
                    applicant.Vacancy.ID = int.Parse(grid.CurrentRow.Cells["gridVacancyID"].Value.ToString());
                    applicant.Vacancy.Grade.Grade = grid.CurrentRow.Cells["gridVacancy"].Value.ToString();
                    applicant.ApplicationDate = DateTime.Parse(grid.CurrentRow.Cells["gridApplicationDate"].Value.ToString());
                    applicant.EmailAddress = grid.CurrentRow.Cells["gridEmailAddress"].Value.ToString();
                    applicant.ContactNo = grid.CurrentRow.Cells["gridContactNo"].Value.ToString();
                    applicant.ContactAddress = grid.CurrentRow.Cells["gridContactAddress"].Value.ToString();
                    applicant.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    applicant.Documents = applicants[grid.CurrentRow.Index].Documents;
                    newApplicant.EditApplicant(applicant);
                    newApplicant.Show();
                    this.Close();
                }
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete the applicant " + grid.CurrentRow.Cells["gridFirstName"].Value.ToString() + " " + grid.CurrentRow.Cells["gridSurname"].Value.ToString() + "?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            Applicant applicant = new Applicant() { ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString()) };
                            dal.Delete(applicant);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            Applicant applicant = new Applicant() { ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString()) };
                            dal.Delete(applicant);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridShortList"].Value != null && bool.Parse(row.Cells["gridShortList"].Value.ToString()))
                        {
                            try
                            {
                                dalHelper.ExecuteNonQuery("Update Applicants Set Status = 'ShortListed' where ID = " + row.Cells["gridID"].Value.ToString());
                            }
                            catch (Exception ex)
                            {
                                string err = ex.Message;
                            }
                        }
                    }
                }
                ApplicantMaintenance_Load(this, EventArgs.Empty);
            }
            catch(Exception ex)
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

        private void PopulateView(IList<Applicant> applicants)
        {
            try
            {
                int ctr = 0;
                grid.Rows.Clear();
                foreach (Applicant applicant in applicants)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = applicant.ID;
                    grid.Rows[ctr].Cells["gridFirstName"].Value = applicant.FirstName;
                    grid.Rows[ctr].Cells["gridMiddleName"].Value = applicant.MiddleName;
                    grid.Rows[ctr].Cells["gridSurname"].Value = applicant.Surname;
                    grid.Rows[ctr].Cells["gridVacancyID"].Value = applicant.Vacancy.ID;
                    grid.Rows[ctr].Cells["gridVacancy"].Value = applicant.Vacancy.Grade.Grade;
                    grid.Rows[ctr].Cells["gridContactNo"].Value = applicant.ContactNo;
                    grid.Rows[ctr].Cells["gridContactAddress"].Value = applicant.ContactAddress;
                    grid.Rows[ctr].Cells["gridApplicationDate"].Value = applicant.ApplicationDate;
                    grid.Rows[ctr].Cells["gridEmailAddress"].Value = applicant.EmailAddress;
                    grid.Rows[ctr].Cells["gridUserID"].Value = applicant.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetData()
        {
            try
            {
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ApplicantView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboVacancy.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ApplicantView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = vacancies[cboVacancy.SelectedIndex].Grade.Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtEmail.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ApplicantView.EmailAddress",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtEmail.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtContactNo.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ApplicantView.ContactNo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtContactNo.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ApplicantView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ApplicantView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtMiddleName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ApplicantView.MiddleName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtMiddleName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                
                applicants = dal.GetByCriteria<Applicant>(query);
                PopulateView(applicants);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
