using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using System.Data;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class VacancyDataMapper
    {
        private DALHelper dal;
        private Vacancy vacancy;

        public VacancyDataMapper()
        {
            this.dal = new DALHelper();
            this.vacancy = new Vacancy();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Vacancy vacancy = (Vacancy)item;
                dal.ClearParameters();
                dal.OpenConnection();
                dal.CreateParameter("@EmployeeGradeID", vacancy.Grade.ID, DbType.Int32);
                dal.CreateParameter("@AppointmentTypeID", vacancy.AppointmentType.ID, DbType.Int32);
                dal.CreateParameter("@DepartmentID", vacancy.Department.ID, DbType.Int32);
                dal.CreateParameter("@Date", vacancy.Date, DbType.DateTime);
                dal.CreateParameter("@DeadLine", vacancy.Date, DbType.DateTime);
                dal.CreateParameter("@ContactNos", vacancy.ContactNos, DbType.String);
                dal.CreateParameter("@FaxNos", vacancy.ContactNos, DbType.String);
                dal.CreateParameter("@EmailAddress", vacancy.Email, DbType.String);
                dal.CreateParameter("@PostalAddress", vacancy.PostalAddress, DbType.String);
                dal.CreateParameter("@VacancyDueTo", vacancy.VacancyDueTo, DbType.String);
                dal.CreateParameter("@Status", vacancy.Status, DbType.Int32);
                dal.CreateParameter("@UserID", vacancy.UserID, DbType.Int32);

                dal.CreateParameter("@PMB", vacancy.PMB, DbType.String);
                
                dal.BeginTransaction();
                dal.ExecuteNonQuery("Insert Into Vacancies(EmployeeGradeID,AppointmentTypeID,DepartmentID,Date,DeadLine,ContactNos,FaxNos,EmailAddress,PostalAddress,VacancyDueTo,Status,UserID,PMB) Values(@EmployeeGradeID,@AppointmentTypeID,@DepartmentID,@Date,@DeadLine,@ContactNos,@FaxNos,@EmailAddress,@PostalAddress,@VacancyDueTo,@Status,@UserID,@PMB)");
                vacancy.ID  = int.Parse(dal.ExecuteScalar("Select Max(ID) From Vacancies").ToString());

                foreach (string description in vacancy.JobDescription)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@VacancyID", vacancy.ID , DbType.Int32);
                    dal.CreateParameter("@Description", description, DbType.String);
                    dal.ExecuteNonQuery("Insert Into VacancyJobDescriptions(VacancyID,Description) Values(@VacancyID,@Description)");
                }

                foreach (string requirement in vacancy.JobRequirements)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@VacancyID", vacancy.ID, DbType.Int32);
                    dal.CreateParameter("@Description", requirement, DbType.String);
                    dal.ExecuteNonQuery("Insert Into VacanyJobRequirements(VacancyID,Description) Values(@VacancyID,@Description)");
                }
                dal.CommitTransaction();
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region UPDATE
        public void Update(object item)
        {
            try
            {
                Vacancy vacancy = (Vacancy)item;
                dal.ClearParameters();
                dal.OpenConnection();
                dal.CreateParameter("@ID", vacancy.ID, DbType.Int32);
                dal.CreateParameter("@EmployeeGradeID", vacancy.Grade.ID, DbType.Int32);
                dal.CreateParameter("@AppointmentTypeID", vacancy.AppointmentType.ID, DbType.Int32);
                dal.CreateParameter("@DepartmentID", vacancy.Department.ID, DbType.Int32);
                dal.CreateParameter("@Date", vacancy.Date, DbType.DateTime);
                dal.CreateParameter("@DeadLine", vacancy.Date, DbType.DateTime);
                dal.CreateParameter("@ContactNos", vacancy.ContactNos, DbType.String);
                dal.CreateParameter("@FaxNos", vacancy.ContactNos, DbType.String);
                dal.CreateParameter("@EmailAddress", vacancy.Email, DbType.String);
                dal.CreateParameter("@PostalAddress", vacancy.PostalAddress, DbType.String);
                dal.CreateParameter("@VacancyDueTo", vacancy.VacancyDueTo, DbType.String);
                dal.CreateParameter("@Status", vacancy.Status, DbType.Int32);
                dal.CreateParameter("@UserID", vacancy.UserID, DbType.Int32);

                dal.CreateParameter("@PMB", vacancy.PMB, DbType.String);

                dal.BeginTransaction();
                dal.ExecuteNonQuery("Update Vacancies Set EmployeeGradeID=@EmployeeGradeID,AppointmentTypeID=@AppointmentTypeID,DepartmentID=@DepartmentID,Date=@Date,DeadLine=@DeadLine,ContactNos=@ContactNos,FaxNos=@FaxNos,EmailAddress=@EmailAddress,PostalAddress=@PostalAddress,VacancyDueTo=@VacancyDueTo,Status=@Status,UserID = @UserID,PMB=@PMB where ID = @ID");

                dal.ExecuteNonQuery("Delete From VacancyJobDescriptions Where VacancyID = "+ vacancy.ID);
                dal.ExecuteNonQuery("Delete From VacanyJobRequirements Where VacancyID = " + vacancy.ID);

                foreach (string description in vacancy.JobDescription)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@VacancyID", vacancy.ID, DbType.Int32);
                    dal.CreateParameter("@Description", description, DbType.String);
                    dal.ExecuteNonQuery("Insert Into VacancyJobDescriptions(VacancyID,Description) Values(@VacancyID,@Description)");
                }

                foreach (string requirement in vacancy.JobRequirements)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@VacancyID", vacancy.ID, DbType.Int32);
                    dal.CreateParameter("@Description", requirement, DbType.String);
                    dal.ExecuteNonQuery("Insert Into VacanyJobRequirements(VacancyID,Description) Values(@VacancyID,@Description)");
                }
                dal.CommitTransaction();
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<Vacancy> GetAll()
        {
            IList<Vacancy> vacancies = new List<Vacancy>();
            try
            {
                string query = "Select * from VacancyView Where VacancyView.Archived ='False' And VacancyView.Status <> 6";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    Vacancy vacancy = new Vacancy()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Grade  = new EmployeeGrade() { ID = int.Parse(row["EmployeeGradeID"].ToString()), Grade = row["Grade"].ToString() },
                        AppointmentType = new AppointmentType() { ID = row["AppointmentTypeID"] == DBNull.Value ? 0 : int.Parse(row["AppointmentTypeID"].ToString()), Description = row["AppointmentType"] == DBNull.Value ? string.Empty : row["AppointmentType"].ToString() },
                        Department = new Department() { ID = int.Parse(row["DepartmentID"].ToString()), Description = row["Department"].ToString() },
                        Date = DateTime.Parse(row["Date"].ToString()),
                        DeadLine = DateTime.Parse(row["DeadLine"].ToString()),
                        ContactNos = row["ContactNos"].ToString(),
                        FaxNo = row["FaxNos"].ToString(),
                        Email = row["EmailAddress"].ToString(),
                        PostalAddress = row["PostalAddress"].ToString(),
                        VacancyDueTo = row["VacancyDueTo"].ToString(),
                        Status =(VacancyStatus) Enum.Parse(typeof(VacancyStatus), row["Status"].ToString()),
                        UserID = int.Parse(row["UserID"].ToString()),

                        PMB=row["PMB"].ToString()
                    };

                   foreach (DataRow item in dal.ExecuteReader("Select Description From VacancyJobDescriptions Where VacancyID=" + row["ID"].ToString()).Rows)
                   {
                       vacancy.JobDescription.Add(item["Description"].ToString());
                   }

                   foreach (DataRow item in dal.ExecuteReader("Select Description From VacanyJobRequirements Where VacancyID=" + row["ID"].ToString()).Rows)
                   {
                       vacancy.JobRequirements.Add(item["Description"].ToString());
                   }
                   vacancies.Add(vacancy);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return vacancies;
        }
        #endregion

        #region GETBYID
        //public IList<Vacancy> GetByID(object key)
        //{
        //    IList<Vacancy> vacancies = new List<Vacancy>();
        //    try
        //    {
        //        DataTable table = dal.ExecuteReader("select Vacancies.ID,Vacancies.EmployeeGradeID,EmployeeGrades_Setup.Grade,Vacancies.Type,Vacancies.JobDescription,Vacancies.DepartmentID,epartments.Description,Vacancies.Date,Vacancies.VacancyDueTo,Vacancies.Qualifications,Vacancies.ApplyOnline,Vacancies.Email,Vacancies.DeadLine From Vacancies Inner Join EmployeeGrades_Setup on EmployeeGrades_Setup.GID = Vacancies.EmployeeGradeID Inner Join Departments On Departments.ID = Vacancies.DepartmentID where Vacancies.ID =" + key.ToString() + " And Vacancies.Archived ='False'");
        //        foreach (DataRow row in table.Rows)
        //        {
        //            vacancies.Add(new Vacancy()
        //            {
        //                ID = int.Parse(row["ID"].ToString()),
        //                JobTitle = new EmployeeGrade() { GID = int.Parse(row["EmployeeGradeID"].ToString()), Grade = row["Grade"].ToString() },
        //                Type = row["Type"].ToString(),
        //                JobDescription = row["JobDescription"].ToString(),
        //                Department = new Department() { ID = int.Parse(row["DepartmentID"].ToString()), Description = row["Description"].ToString() },
        //                Date = DateTime.Parse(row["Date"].ToString()),
        //                VacancyDueTo = row["VacancyDueTo"].ToString(),
        //                Qualifications = row["Qualifications"].ToString(),
        //                ApplyOnline = bool.Parse(row["ApplyOnline"].ToString()),
        //                Email = row["Email"].ToString(),
        //                DeadLine = DateTime.Parse(row["DeadLine"].ToString())
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return vacancies;
        //}
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                Vacancy vacancy = (Vacancy)item;
                dal.ExecuteNonQuery("Update Vacancies Set Archived = 'True' Where ID=" + vacancy.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion
    }
}
