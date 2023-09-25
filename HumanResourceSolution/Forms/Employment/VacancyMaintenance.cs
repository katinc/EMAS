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

namespace eMAS.Forms.StaffInformation
{
    public partial class Vacancy_Maintenance : Form
    {
        private IDAL dal;
        private NewVacancy newVacancy;
        private Vacancy vacancy;
        private IList<Vacancy> vacancies;
        private bool found;

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
                    foreach (string item in vacancies[grid.CurrentRow.Index].JobDescription)
                    {
                        vacancy.JobDescription.Add(item);
                    }

                    foreach (string item in vacancies[grid.CurrentRow.Index].JobRequirements)
                    {
                        vacancy.JobRequirements.Add(item);
                    }

                    newVacancy.EditVacancy(vacancy);
                    newVacancy.Show();
                    this.Close();
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
                        Property = "VacancyView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                
                vacancies = dal.GetByCriteria<Vacancy>(query);
                PopulateView(vacancies);
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

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete the vacancy for position of " + grid.CurrentRow.Cells["gridEmployeeGrade"].Value.ToString() + "?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Vacancy vacancy = new Vacancy() { ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString()) };
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
