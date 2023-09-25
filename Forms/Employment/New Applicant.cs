using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using eMAS.Forms.StaffInformation;
using eMAS.All_UIs.Staff_Information_FORMS;
using Microsoft.Office.Interop.Word;
using System.IO;
using eMAS.Forms.Employment;


namespace eMAS.All_UIs.Applicants
{
    public partial class NewApplicant : Form
    {
        private IDAL dal;
        private DALHelper dalHelper;
        private bool EditMode;
        private Applicant applicant;
        private IList<Vacancy> vacancies;
        private DataTable documentGroupsTable;
        private PDFReader reader;
        public Permissions permissions;

        List<Control> controls;
        List<controlObject> OldValues;

        public NewApplicant()
        {
            try
            {
                InitializeComponent();
                dal = new DAL();
                dalHelper = new DALHelper();
                EditMode = false;
                applicant = new Applicant();
                vacancies = new List<Vacancy>();
                documentGroupsTable = new DataTable();
                dal.OpenConnection();
                vacancies = dal.GetAll<Vacancy>();
                vacancyComboBox.DropDown += new EventHandler(vacancyComboBox_DropDown);
                gridDocuments.CellClick += new DataGridViewCellEventHandler(gridDocuments_CellClick);
                this.controls = new List<Control>();
                this.OldValues = new List<controlObject>();

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gridDocuments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GetDocumentGroups();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetDocumentGroups()
        {
            try
            {
                if (gridDocuments.CurrentRow != null)
                {
                    if (gridDocuments.CurrentCell.ColumnIndex == gridDocumentsDocumentGroup.Index)
                    {
                        dalHelper.OpenConnection();
                        documentGroupsTable = dalHelper.ExecuteReader("select ID,Description From DocumentGroups Where Archived ='False' order by Description ASC");
                        gridDocumentsDocumentGroup.Items.Clear();
                        foreach (DataRow row in documentGroupsTable.Rows)
                        {
                            gridDocumentsDocumentGroup.Items.Add(row["Description"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void GetVacancies()
        {
            try
            {
                vacancyComboBox.Items.Clear();
                foreach (Vacancy vacancy in vacancies)
                {
                    vacancyComboBox.Items.Add(vacancy.Grade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void vacancyComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                GetVacancies();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditApplicant(Applicant applicant)
        {
            try
            {
                EditMode = true;
                label13.Text = "Edit Applicant";
                this.applicant = applicant;

                txtSurname.Text = applicant.Surname;
                txtMiddleName.Text = applicant.MiddleName;
                txtFirstName.Text = applicant.FirstName;
                GetVacancies();
                vacancyComboBox.Text = applicant.Vacancy.Grade.Grade;
                contactAddressTextBox.Text = applicant.ContactAddress;
                contactNoTextBox.Text = applicant.ContactNo;
                dateTimePicker1.Text = applicant.ApplicationDate.ToString();
                emailAddressTextBox.Text = applicant.EmailAddress;

                //Get Document Groups
                dalHelper.OpenConnection();
                documentGroupsTable = dalHelper.ExecuteReader("select ID,Description From DocumentGroups Where Archived ='False' order by Description ASC");
                gridDocumentsDocumentGroup.Items.Clear();
                foreach (DataRow row in documentGroupsTable.Rows)
                {
                    gridDocumentsDocumentGroup.Items.Add(row["Description"].ToString());
                }

                int ctr = 0;
                gridDocuments.Rows.Clear();
                foreach (StaffDocument document in applicant.Documents)
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
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != applicant.User.ID)
                {
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            OldValues = GlobalData.CloneControls(controls, this);

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    UpdateApplicantEntity();
                    if (EditMode)
                    {
                        //dal.Update(applicant);
                        GlobalData.ProcessEdit(OldValues, controls, this, applicant.ID, applicant.ID.ToString());
                        Clear();
                    }
                    else
                    {
                        dal.Save(applicant);
                        var lastIndex = GlobalData._context.Applicants.Max(u => u.ID).ToString();

                        foreach (DataGridViewRow item in gridEducationHistory.Rows)
                        {
                            if (!item.IsNewRow)
                            {
                                var educationHistory = new DataReference.StaffEducationHistory
                                {
                                    StaffID = lastIndex,
                                    StaffCode = 0,
                                    NameOfInstitution = item.Cells["qualificationsNameOfInstitution"].Value.ToString(),
                                    CertificateObtained = item.Cells["qualificationsCertificateObtained"].Value.ToString(),
                                    StartMonth = item.Cells["qualificationsFromMonth"].Value.ToString(),
                                    StartYear = item.Cells["qualificationsFromYear"].Value.ToString(),
                                    EndMonth = item.Cells["qualificationsToMonth"].Value.ToString(),
                                    EndYear = item.Cells["qualificationsToYear"].Value.ToString(),
                                    DateAndTimeGenerated = DateTime.Now,
                                    UserID = GlobalData.User.ID,
                                };
                                GlobalData._context.StaffEducationHistories.InsertOnSubmit(educationHistory);
                            }
                            
                        }

                        foreach (DataGridViewRow item in gridEmploymentHistory.Rows)
	                    {
                            if (!item.IsNewRow)
                            {
                                var employmentHistory = new DataReference.StaffEmploymentHistory
                                {
                                    StaffID = lastIndex,
                                    StaffCode = Convert.ToDecimal(lastIndex),
                                    NameOfOrganisation = item.Cells["experienceNameOfOrganisation"].Value.ToString(),
                                    StartYear = item.Cells["experienceFromYear"].Value.ToString(),
                                    EndYear = item.Cells["experienceToYear"].Value.ToString(),
                                    StartMonth = item.Cells["experienceFromMonth"].Value.ToString(),
                                    EndMonth = item.Cells["experienceToMonth"].Value.ToString(),
                                    DateAndTimeGenerated = DateTime.Now,
                                    UserID = Convert.ToDecimal(GlobalData.User.ID),
                                    JobTitle = item.Cells["experienceJobTitle"].Value.ToString(),
                                    ReasonForLeaving = string.Empty,
                                    AnnualSalary = 0
                                };

                                GlobalData._context.StaffEmploymentHistories.InsertOnSubmit(employmentHistory);
                            }
	                    }

                        foreach (DataGridViewRow item in gridReferees.Rows)
                        {
                            if (!item.IsNewRow)
                            {
                                var referees = new DataReference.StaffReferee
                                {
                                    StaffID = lastIndex,
                                    StaffCode = 0,
                                    Name = item.Cells["txtName"].Value.ToString(),
                                    Address = item.Cells["refereesCompany"].Value.ToString(),
                                    Occupation = item.Cells["txtOccupation"].Value.ToString(),
                                    TelNo = item.Cells["txtNumber"].Value.ToString(),
                                    Email = "applicant@referee.com",
                                    DateAndTimeGenerated = DateTime.Now,
                                    UserID = GlobalData.User.ID,
                                };
                                GlobalData._context.StaffReferees.InsertOnSubmit(referees);
                            }
                            
                        }

                        foreach (DataGridViewRow item in gridSkill.Rows)
                        {
                            if (!item.IsNewRow)
                            {
                                var skills = new DataReference.ApplicantSkill
                                {
                                    ApplicantID = lastIndex,
                                    Skill = item.Cells["gridSkills"].Value.ToString()
                                };
                                GlobalData._context.ApplicantSkills.InsertOnSubmit(skills);
                            }

                        }

                        GlobalData._context.SubmitChanges();

                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void UpdateApplicantEntity()
        {
            try
            {
                gridDocuments.CommitEdit(DataGridViewDataErrorContexts.Commit);

                applicant.Surname = txtSurname.Text;
                applicant.MiddleName = txtMiddleName.Text;
                applicant.FirstName = txtFirstName.Text;
                applicant.Vacancy = vacancies[vacancyComboBox.SelectedIndex];
                applicant.ContactNo = contactNoTextBox.Text;
                applicant.EmailAddress = emailAddressTextBox.Text;
                applicant.ApplicationDate = DateTime.Parse(dateTimePicker1.Text);
                applicant.ContactAddress = contactAddressTextBox.Text;
                applicant.User.ID = GlobalData.User.ID;

                foreach (DataGridViewRow row in gridDocuments.Rows)
                {
                    StaffDocument document = new StaffDocument();
                    document.DateCreated = DateTime.Parse(row.Cells["gridDocumentsDateCreated"].Value.ToString());
                    document.Description = row.Cells["gridDocumentsDescription"].Value.ToString();
                    document.DocumentContent = (byte[])row.Cells["gridDocumentsDocumentContent"].Value;
                    document.DocumentGroup = row.Cells["gridDocumentsDocumentGroup"].Value.ToString();
                    document.Path = row.Cells["gridDocumentsPath"].Value.ToString();
                    //document.Path = row.Cells["gridDocumentsUserID"].Value.ToString();
                    applicant.Documents.Add(document);
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                if (txtSurname.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtSurname, "Please enter employee's surname");
                }
                if (txtFirstName.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtFirstName, "Please enter employee's first name");
                }

                if (vacancyComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(vacancyComboBox, "Please select the vacancy");
                }

                foreach (DataGridViewRow row in gridDocuments.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridDocumentsDocumentGroup"].Value == null)
                        {
                            result = false;
                            errorProvider.SetError(tabOtherDetails, "Please select a document group on row " + (row.Index + 1));
                        }
                    }
                }

                foreach (DataGridViewRow row in gridEducationHistory.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["qualificationsNameOfInstitution"].Value == null
                            || row.Cells["qualificationsCertificateObtained"].Value == null
                            || row.Cells["qualificationsFromMonth"].Value == null
                            || row.Cells["qualificationsFromYear"].Value == null
                            || row.Cells["qualificationsToMonth"].Value == null
                            || row.Cells["qualificationsToYear"].Value == null)
                        {
                            result = false;
                            errorProvider.SetError(tabOtherDetails, "Please fill out all the details for the Education History on all rows");
                            break;
                        }
                    }
                }

                foreach (DataGridViewRow row in gridEmploymentHistory.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["experienceNameOfOrganisation"].Value == null
                            || row.Cells["experienceJobTitle"].Value == null
                            || row.Cells["experienceFromMonth"].Value == null
                            || row.Cells["experienceFromYear"].Value == null
                            || row.Cells["experienceToMonth"].Value == null
                            || row.Cells["experienceToYear"].Value == null)
                        {
                            result = false;
                            errorProvider.SetError(tabOtherDetails, "Please fill out all the details for the Employment History on all rows");
                            break;
                        }
                    }
                }

                foreach (DataGridViewRow row in gridReferees.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["txtName"].Value == null || row.Cells["txtOccupation"].Value == null || row.Cells["refereesCompany"].Value == null || row.Cells["txtNumber"].Value == null)
                        {
                            result = false;
                            errorProvider.SetError(tabOtherDetails, "Please fill out all the details for the referee on all rows");
                            break;
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

        private void Clear()
        {
            try
            {
                applicant = new Applicant();
                txtSurname.Clear();
                txtFirstName.Clear();
                txtMiddleName.Clear();
                vacancyComboBox.Items.Clear();
                vacancyComboBox.Text = string.Empty;
                contactNoTextBox.Clear();
                emailAddressTextBox.Clear();
                contactAddressTextBox.Clear();
                dateTimePicker1.ResetText();
                gridDocuments.Rows.Clear();
                EditMode = false;
                label13.Text = "New Applicant";
                gridEducationHistory.Rows.Clear();
                gridEmploymentHistory.Rows.Clear();
                gridReferees.Rows.Clear();
                gridSkill.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void New_Applicant_Load(object sender, EventArgs e)
        {
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicantMaintenance applicantView = new ApplicantMaintenance(dal, this);
                applicantView.MdiParent = this.MdiParent;
                applicantView.btnRemove.Enabled = permissions.CanDelete;
                applicantView.btnSave.Enabled = permissions.CanEdit;
                applicantView.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog documentDialog = new OpenFileDialog();
                documentDialog.Multiselect = false;
                documentDialog.RestoreDirectory = true;
                documentDialog.Title = "Select Document";
                documentDialog.AutoUpgradeEnabled = true;
                documentDialog.Filter = "Word 2007/2010 Document (PDF Files (*.PDF)|*.PDF";
                documentDialog.CheckFileExists = true;


                if (documentDialog.ShowDialog(this) == DialogResult.OK)
                {
                    gridDocuments.Rows.Add(1);
                    FileStream fs = new FileStream(documentDialog.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    int numBytes = (int)new FileInfo(documentDialog.FileName).Length;
                    byte[] buff = br.ReadBytes(numBytes);
                    gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDateCreated"].Value = GlobalData.ServerDate;
                    gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDescription"].Value = "New Document";
                    gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsPath"].Value = documentDialog.FileName;
                    gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDocumentContent"].Value = buff;
                }
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
                if (gridDocuments.CurrentRow != null && gridDocuments.CurrentRow.Cells["gridDocumentsPath"].Value != null)
                {
                    if (reader != null && !reader.IsDisposed)
                    {
                        reader.Close();
                        reader = null;
                    }

                    reader = new PDFReader(gridDocuments.CurrentRow.Cells["gridDocumentsPath"].Value.ToString());
                    reader.Show();
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnCV_Click(object sender, EventArgs e)
        {
            
        }

        private void gridEmploymentHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridEmploymentHistory.CurrentCell.ColumnIndex == 5)
                {
                    experienceFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        experienceFromYear.Items.Add(year);
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {

        }

        private void NewApplicant_Load(object sender, EventArgs e)
        {
            try
            {
                permissions = GlobalData.CheckPermissions(2);
                btnSave.Enabled = permissions.CanAdd;
                btnView.Enabled = permissions.CanView;

                experienceFromYear.Items.Clear();
                experienceToYear.Items.Clear();
                qualificationsFromYear.Items.Clear();
                qualificationsToYear.Items.Clear();
                foreach (string year in GlobalData.GetYears())
                {
                    experienceFromYear.Items.Add(year);
                    experienceToYear.Items.Add(year);
                    qualificationsFromYear.Items.Add(year);
                    qualificationsToYear.Items.Add(year);
                }


                this.Text = GlobalData.Caption;
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
