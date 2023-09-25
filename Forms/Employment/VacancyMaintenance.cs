using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using eMAS.Forms.StaffInformation;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using HRDataAccessLayerBase;

namespace eMAS.Forms.StaffInformation
{
    public partial class Vacancy_Maintenance : Form
    {
        private IDAL dal;
        private NewVacancy newVacancy;
        private Vacancy vacancy;
        private IList<Vacancy> vacancies;
        private bool found;
        private string password;
        //private bool CanEdit = false;
        SqlDataAdapter Adapta;
        DALHelper dalHelper;


        public Vacancy_Maintenance()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.vacancy = new Vacancy();
                this.vacancies = new List<Vacancy>();
                this.newVacancy = new NewVacancy();
                this.found = false;
                this.dalHelper = new DALHelper();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        public Vacancy_Maintenance(IDAL dal, NewVacancy newVacancy)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.vacancy = new Vacancy();
                this.vacancies=new List<Vacancy>();
                this.newVacancy = newVacancy;
                this.found = false;
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
                if(newVacancy.permissions.CanEdit)
                {
                    if (grid.CurrentRow != null)
                    {
                        Vacancy vacancy = new Vacancy();
                        vacancy.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        vacancy.Grade.ID = int.Parse(grid.CurrentRow.Cells["gridEmployeeGradeID"].Value.ToString());
                        vacancy.Grade.Grade = grid.CurrentRow.Cells["gridEmployeeGrade"].Value.ToString();
                        vacancy.AppointmentType.ID = int.Parse(grid.CurrentRow.Cells["gridAppointmentTypeID"].Value.ToString());
                        vacancy.AppointmentType.Description = grid.CurrentRow.Cells["gridAppointmentType"].Value.ToString();
                        vacancy.Department.ID = int.Parse(grid.CurrentRow.Cells["gridDepartmentID"].Value.ToString());
                        vacancy.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                        vacancy.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                        vacancy.DeadLine = DateTime.Parse(grid.CurrentRow.Cells["gridDeadLine"].Value.ToString());
                        vacancy.ContactNos = grid.CurrentRow.Cells["gridContactNos"].Value.ToString();
                        vacancy.FaxNo = grid.CurrentRow.Cells["gridFaxNos"].Value.ToString();
                        vacancy.Email = grid.CurrentRow.Cells["gridEmailAddress"].Value.ToString();
                        vacancy.PostalAddress = grid.CurrentRow.Cells["gridPostalAddress"].Value.ToString();
                        vacancy.VacancyDueTo = grid.CurrentRow.Cells["gridVacancyDueTo"].Value.ToString();
                        vacancy.Status = (VacancyStatus)Enum.Parse(typeof(VacancyStatus), grid.CurrentRow.Cells["gridStatus"].Value.ToString());
                        vacancy.UserID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());

                        vacancy.PMB = grid.CurrentRow.Cells["gridPMB"].Value.ToString();

                        //Getting Job Descriptions
                        Adapta = new SqlDataAdapter("select * from VacancyJobDescriptions where vacancyid=@vacancyid", dalHelper.ConnectionString());
                        Adapta.SelectCommand.Parameters.AddWithValue("vacancyid", vacancy.ID);

                        var dtJobDescriptions = new DataTable();
                        Adapta.Fill(dtJobDescriptions);

                        foreach (DataRow dR in dtJobDescriptions.Rows)
                        {
                            vacancy.JobDescription.Add(dR["Description"].ToString());
                        }

                        //Getting Job Requirements
                        Adapta = new SqlDataAdapter("select * from VacanyJobRequirements where vacancyid=@vacancyid", dalHelper.ConnectionString());
                        Adapta.SelectCommand.Parameters.AddWithValue("vacancyid", vacancy.ID);

                        var dtJobRequirements = new DataTable();
                        Adapta.Fill(dtJobRequirements);

                        foreach (DataRow dR in dtJobRequirements.Rows)
                        {
                            vacancy.JobRequirements.Add(dR["Description"].ToString());
                        }

                        newVacancy.EditVacancy(vacancy);
                        //newVacancy.btnSave.Enabled = newVacancy.permissions.CanEdit;
                        newVacancy.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
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
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<Vacancy> vacancies)
        {
            try
            {
                int ctr = 0;
                grid.Rows.Clear();
                foreach (Vacancy vacancy in vacancies)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = vacancy.ID;
                    grid.Rows[ctr].Cells["gridEmployeeGradeID"].Value = vacancy.Grade.ID;
                    grid.Rows[ctr].Cells["gridEmployeeGrade"].Value = vacancy.Grade.Grade;
                    grid.Rows[ctr].Cells["gridAppointmentTypeID"].Value = vacancy.AppointmentType.ID;
                    grid.Rows[ctr].Cells["gridAppointmentType"].Value = vacancy.AppointmentType.Description;
                    grid.Rows[ctr].Cells["gridDepartmentID"].Value = vacancy.Department.ID;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = vacancy.Department.Description;
                    grid.Rows[ctr].Cells["gridDate"].Value = vacancy.Date;
                    grid.Rows[ctr].Cells["gridDeadLine"].Value = vacancy.DeadLine;
                    grid.Rows[ctr].Cells["gridContactNos"].Value = vacancy.ContactNos;
                    grid.Rows[ctr].Cells["gridFaxNos"].Value = vacancy.FaxNo;
                    grid.Rows[ctr].Cells["gridEmailAddress"].Value = vacancy.Email;
                    grid.Rows[ctr].Cells["gridPostalAddress"].Value = vacancy.PostalAddress;
                    grid.Rows[ctr].Cells["gridVacancyDueTo"].Value = vacancy.VacancyDueTo;
                    grid.Rows[ctr].Cells["gridStatus"].Value = vacancy.Status.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = vacancy.UserID;

                    grid.Rows[ctr].Cells["gridPMB"].Value = vacancy.PMB;

                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void Vacancy_Maintenance_Load(object sender, EventArgs e)
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
            GetData();
        }

        private void GetData()
        {
             Adapta = new SqlDataAdapter("select * from VacancyView where UserID=@UserID and archived='false' order by AppointmentType,Department, DeadLine", dalHelper.ConnectionString());
            Adapta.SelectCommand.Parameters.AddWithValue("UserID", GlobalData.User.ID);

            var dtVacancies=new DataTable();

            Adapta.Fill(dtVacancies);

            foreach (DataRow dRvacancy in dtVacancies.Rows)
            {
                vacancy = new Vacancy();
                
                vacancy.ID =int.Parse(dRvacancy["ID"].ToString());

                vacancy.AppointmentType.ID =int.Parse( dRvacancy["AppointmentTypeID"].ToString());
                vacancy.AppointmentType.Description = dRvacancy["AppointmentType"].ToString();


                vacancy.ContactNos = dRvacancy["ContactNos"].ToString();
                vacancy.Date =DateTime.Parse( dRvacancy["Date"].ToString());
                vacancy.DeadLine =DateTime.Parse( dRvacancy["DeadLine"].ToString());
                vacancy.Department.ID =int.Parse( dRvacancy["DepartmentID"].ToString());
                vacancy.Department.Description = dRvacancy["Department"].ToString();

                vacancy.Grade.ID =int.Parse( dRvacancy["EmployeeGradeID"].ToString());
                vacancy.Grade.Grade =dRvacancy["Grade"].ToString();

                vacancy.FaxNo = dRvacancy["FaxNos"].ToString();
                vacancy.Email = dRvacancy["EmailAddress"].ToString();
                vacancy.PostalAddress = dRvacancy["PostalAddress"].ToString();
                vacancy.VacancyDueTo = dRvacancy["VacancyDueTo"].ToString();
                vacancy.Status =(VacancyStatus)int.Parse(dRvacancy["Status"].ToString());
                vacancy.UserID=int.Parse(dRvacancy["UserID"].ToString());

                vacancy.PMB = (dRvacancy["PMB"] == null) ? string.Empty : dRvacancy["PMB"].ToString();

                vacancies.Add(vacancy);
            }

            PopulateView(vacancies);
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
                if (MessageBox.Show("Are you sure you want to delete the vacancy for position of " + grid.CurrentRow.Cells["gridEmployeeGrade"].Value.ToString() + "?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Vacancy vacancy = new Vacancy() { ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString()) };
                    //SqlCommand cmdDelete = new SqlCommand("delete from vacancies where id=@id", new SqlConnection(connectionString));
                    //cmdDelete.Parameters.AddWithValue("id", vacancy.ID);
                    try
                    {
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            dal.Delete(vacancy);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);

                           
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            dal.Delete(vacancy);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);

                        
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                    }
                }
            }
        }
    }
}
