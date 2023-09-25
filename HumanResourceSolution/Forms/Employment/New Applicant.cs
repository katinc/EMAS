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
            }
            catch(Exception ex)
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
                        dal.Update(applicant);
                        Clear();
                    }
                    else
                    {
                        dal.Save(applicant);
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
                    document.Path = row.Cells["gridDocumentsUserID"].Value.ToString();
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
                            errorProvider.SetError(groupBox19, "Please select a document group on row " + (row.Index + 1));
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
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicantMaintenance applicantView = new ApplicantMaintenance(dal, this);
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
    }
}
