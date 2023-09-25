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
using HRBussinessLayer.Staff_Information_CLASS;

namespace eMAS.Forms.Employment
{
    public partial class InterviewMaintenance : Form
    {
        private Interview interviewForm;
        private IList<Vacancy> vacancies;
        private IDAL idal;
        private DALHelper dal;
        private DataTable interview;
        private bool found;

        public InterviewMaintenance()
        {
            try
            {
                InitializeComponent();
                idal = new DAL();
                dal = new DALHelper();
                interview = new DataTable();
                vacancies = new List<Vacancy>();
                this.interviewForm = new Interview();
                this.found = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public InterviewMaintenance(Interview interviewForm)
        {
            try
            {
                InitializeComponent();
                idal = new DAL();
                dal = new DALHelper();
                interview = new DataTable();
                vacancies = new List<Vacancy>();
                this.interviewForm = interviewForm;
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        void cboVacancy_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboVacancy.Items.Clear();
                vacancies = idal.GetAll<Vacancy>();
                foreach (Vacancy vacancy in vacancies)
                {
                    cboVacancy.Items.Add(vacancy.Grade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboInterviewStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboInterviewStatus.Items.Clear();
                cboInterviewStatus.Items.Add("Employed");
                cboInterviewStatus.Items.Add("Rejected");
                cboInterviewStatus.Items.Add("Review");
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
                    interviewForm.EditInterview(grid.CurrentRow);
                    interviewForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView()
        {
            try
            {
                int ctr = 0;
                grid.Rows.Clear();
                foreach (DataRow row in dal.ExecuteReader("Select Interviews.ID,Interviews.VacancyID,Interviews.ApplicantID,Interviews.TotalScore,Interviews.Status,Applicants.FirstName,Applicants.MiddleName,Applicants.Surname,EmployeeGrades_Setup.Description as Vacancy  from Interviews Inner Join Applicants on Applicants.ID = Interviews.ApplicantID Inner Join Vacancies on Vacancies.ID = Applicants.VacancyID Inner Join EmployeeGrades_Setup on EmployeeGrades_Setup.ID = Vacancies.EmployeeGradeID Where Interviews.Archived = 'False'").Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = row["ID"];
                    grid.Rows[ctr].Cells["gridVacancyID"].Value = row["VacancyID"];
                    grid.Rows[ctr].Cells["gridApplicantID"].Value = row["ApplicantID"];
                    grid.Rows[ctr].Cells["gridVacancy"].Value = row["Vacancy"];
                    grid.Rows[ctr].Cells["gridName"].Value = row["FirstName"].ToString() + (row["MiddleName"].ToString() == string.Empty ? " " : " " + row["MiddleName"].ToString() + " ") + row["Surname"].ToString();
                    grid.Rows[ctr].Cells["gridTotalScore"].Value = row["TotalScore"];
                    grid.Rows[ctr].Cells["gridStatus"].Value = row["Status"];
                    grid.Rows[ctr].Cells["gridUserID"].Value = row["UserID"];
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void InterviewMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateView();
                GlobalData.SetFormPermissions(this, idal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR: See the system administrator");
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
            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected interview?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            dal.ExecuteNonQuery("Update Interviews Set Archived ='True' Where ID = " + grid.CurrentRow.Cells["gridID"].Value.ToString());
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            dal.ExecuteNonQuery("Update Interviews Set Archived ='True' Where ID = " + grid.CurrentRow.Cells["gridID"].Value.ToString());
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
        }

        private void GetData()
        {
            try
            {
                string queryString = "Select * from InterviewView Where Archived='False' ";
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    queryString += " and UserID = '" + GlobalData.User.ID + "' ";
                }
                if (cboVacancy.Text.Trim() != string.Empty)
                {
                    queryString += " and Grade = '" + cboVacancy.Text.Trim() + "' ";
                }
                if (cboInterviewStatus.Text.Trim() != string.Empty)
                {
                    queryString += " and Status = '" + cboInterviewStatus.Text.Trim() + "' ";
                }
                if (txtName.Text.Trim() != string.Empty)
                {
                    queryString += " and UPPER(FirstName + ' ' + MiddleName + ' ' + Surname) LIKE '%" + txtName.Text.ToUpper().Trim() + "%' ";
                }
                else
                {
                    queryString += " order by DateAndTimeGenerated";
                }
                interview = dal.ExecuteReader(queryString.ToString());
                int ctr = 0;
                grid.Rows.Clear();
                foreach (DataRow row in interview.Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = row["ID"];
                    grid.Rows[ctr].Cells["gridVacancyID"].Value = row["VacancyID"];
                    grid.Rows[ctr].Cells["gridApplicantID"].Value = row["ApplicantID"];
                    grid.Rows[ctr].Cells["gridVacancy"].Value = row["Grade"];
                    grid.Rows[ctr].Cells["gridName"].Value = row["FirstName"].ToString() + (row["MiddleName"].ToString() == string.Empty ? " " : " " + row["MiddleName"].ToString() + " ") + row["Surname"].ToString();
                    grid.Rows[ctr].Cells["gridTotalScore"].Value = row["TotalScore"];
                    grid.Rows[ctr].Cells["gridStatus"].Value = row["Status"];
                    grid.Rows[ctr].Cells["gridUserID"].Value = row["UserID"];
                    ctr++;
                }
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
