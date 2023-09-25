using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using System.ComponentModel;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;


namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class InternshipDataMapper
    {
        private DALHelper dal;
        private Internship internship;

        public InternshipDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.internship = new Internship();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Internship internship = (Internship)item;
                dal.ClearParameters();
                dal.CreateParameter("@InternshipTypeID", internship.InternshipType.ID, DbType.String);
                dal.CreateParameter("@Photo", Global.ImageToArray(internship.Photo), DbType.Binary);
                dal.CreateParameter("@IDNumber", internship.IDNumber, DbType.String);
                dal.CreateParameter("@StaffID", internship.StaffID, DbType.String);
                dal.CreateParameter("@Institution", internship.Institution, DbType.String);
                dal.CreateParameter("@MaritalStatusID", internship.MaritalStatus, DbType.Int32);
                dal.CreateParameter("@AreaOfStudy", internship.AreaOfStudy, DbType.String);
                dal.CreateParameter("@MobileNo", internship.MobileNo, DbType.String);
                dal.CreateParameter("@Address", internship.Address, DbType.String);
                dal.CreateParameter("@SupervisorCode", internship.SupervisorCode, DbType.Int32);
                dal.CreateParameter("@SupervisorName", internship.SupervisorName, DbType.String);
                dal.CreateParameter("@SupervisorStaffID", internship.SupervisorStaffID, DbType.String);
                dal.CreateParameter("@Overseer", internship.Overseer, DbType.String);
                dal.CreateParameter("@YearStudied", internship.YearStudied, DbType.Decimal);
                dal.CreateParameter("@GenderID", internship.Gender, DbType.Int32);
                dal.CreateParameter("@OtherName", internship.OtherName, DbType.String);
                dal.CreateParameter("@Surname", internship.Surname, DbType.String);
                dal.CreateParameter("@UserID", internship.User.ID, DbType.Int32);
                dal.CreateParameter("@ReportingDate", internship.ReportingDate, DbType.DateTime);
                dal.CreateParameter("@StartDate", internship.StartDate, DbType.DateTime);
                dal.CreateParameter("@EndDate", internship.EndDate, DbType.DateTime);
                dal.CreateParameter("@DOB", internship.DOB, DbType.DateTime);
                dal.CreateParameter("@DepartmentID", internship.Department.ID, DbType.Int32);
                dal.CreateParameter("@UnitID", internship.Unit.ID, DbType.Int32);
                dal.CreateParameter("@ZoneID", internship.Zone.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Internships(InternshipTypeID,Photo,IDNumber,StaffID,Institution,MaritalStatusID,AreaOfStudy,MobileNo,Address,GenderID,OtherName,Surname,UserID,ReportingDate,StartDate,EndDate,DOB,DepartmentID,UnitID,ZoneID,SupervisorCode,SupervisorStaffID,SupervisorName,Overseer,YearStudied) Values(@InternshipTypeID,@Photo,@IDNumber,@StaffID,@Institution,@MaritalStatusID,@AreaOfStudy,@MobileNo,@Address,@GenderID,@OtherName,@Surname,@UserID,@ReportingDate,@StartDate,@EndDate,@DOB,@DepartmentID,@UnitID,@ZoneID,@SupervisorCode,@SupervisorStaffID,@SupervisorName,@Overseer,@YearStudied)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                Internship internship = (Internship)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", internship.ID, DbType.Int32);
                dal.CreateParameter("@InternshipTypeID", internship.InternshipType.ID, DbType.Int32);
                dal.CreateParameter("@Photo", Global.ImageToArray(internship.Photo), DbType.Binary);
                dal.CreateParameter("@IDNumber", internship.IDNumber, DbType.String);
                dal.CreateParameter("@StaffID", internship.StaffID, DbType.String);
                dal.CreateParameter("@Institution", internship.Institution, DbType.String);
                dal.CreateParameter("@MaritalStatusID", internship.MaritalStatus, DbType.Int32);
                dal.CreateParameter("@AreaOfStudy", internship.AreaOfStudy, DbType.String);
                dal.CreateParameter("@MobileNo", internship.MobileNo, DbType.String);
                dal.CreateParameter("@Address", internship.Address, DbType.String);
                dal.CreateParameter("@SupervisorCode", internship.SupervisorCode, DbType.Int32);
                dal.CreateParameter("@SupervisorName", internship.SupervisorName, DbType.String);
                dal.CreateParameter("@SupervisorStaffID", internship.SupervisorStaffID, DbType.String);
                dal.CreateParameter("@Overseer", internship.Overseer, DbType.String);
                dal.CreateParameter("@YearStudied", internship.YearStudied, DbType.Decimal);
                dal.CreateParameter("@GenderID", internship.Gender, DbType.Int32);
                dal.CreateParameter("@OtherName", internship.OtherName, DbType.String);
                dal.CreateParameter("@Surname", internship.Surname, DbType.String);
                dal.CreateParameter("@UserID", internship.User.ID, DbType.Int32);
                dal.CreateParameter("@ReportingDate", internship.ReportingDate, DbType.DateTime);
                dal.CreateParameter("@StartDate", internship.StartDate, DbType.DateTime);
                dal.CreateParameter("@EndDate", internship.EndDate, DbType.DateTime);
                dal.CreateParameter("@DOB", internship.DOB, DbType.DateTime);
                dal.CreateParameter("@DepartmentID", internship.Department.ID, DbType.Int32);
                dal.CreateParameter("@UnitID", internship.Unit.ID, DbType.Int32);
                dal.CreateParameter("@ZoneID", internship.Zone.ID, DbType.Int32);
                dal.CreateParameter("@Archived", internship.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Internships Set MobileNo=@MobileNo,Address=@Address,Photo=@Photo,ZoneID=@ZoneID,InternshipTypeID=@InternshipTypeID,IDNumber=@IDNumber,StaffID=@StaffID,Institution=@Institution,MaritalStatusID=@MaritalStatusID,AreaOfStudy=@AreaOfStudy,GenderID=@GenderID,OtherName=@OtherName,Surname=@Surname,UserID=@UserID,ReportingDate=@ReportingDate,StartDate=@StartDate,EndDate=@EndDate,DOB=@DOB,DepartmentID=@DepartmentID,UnitID=@UnitID,SupervisorCode=@SupervisorCode,SupervisorStaffID=@SupervisorStaffID,SupervisorName=@SupervisorName,Overseer=@Overseer,YearStudied=@YearStudied Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Internship> GetAll()
        {
            IList<Internship> internships = new List<Internship>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", internship.Archived, DbType.String);
                string query = "select InternshipView.*,InternshipView.SupervisorFirstName +' '+ InternshipView.SupervisorOtherName +' '+ InternshipView.SupervisorSurname as SupervisorName from InternshipView ";
                query += "WHERE InternshipView.Archived=@Archived order BY InternshipView.Surname ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Internship internsh in BuildInternshipFromData(table))
                {
                    internships.Add(internsh);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return internships;
        }
        #endregion

        #region GetByCriteria
        public IList<Internship> GetByCriteria(Query query1)
        {
            IList<Internship> internships = new List<Internship>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", internship.Archived, DbType.Boolean);
                string query = "select InternshipView.*,InternshipView.SupervisorFirstName +' '+ InternshipView.SupervisorOtherName +' '+ InternshipView.SupervisorSurname as SupervisorName from InternshipView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  InternshipView.Archived=@Archived order BY InternshipView.Surname ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Internship intern in BuildInternshipFromData(table))
                {
                    internships.Add(intern);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return internships;
        }
        #endregion

        #region LazyLoad
        public IList<Internship> LazyLoad()
        {
            IList<Internship> internships = new List<Internship>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.String);

                string query = "SELECT InternshipView.*,InternshipView.SupervisorFirstName +' '+ InternshipView.SupervisorOtherName +' '+ InternshipView.SupervisorSurname as SupervisorName From InternshipView Where Archived=@Archived";
                DataTable table = dal.ExecuteReader(query);

                foreach (Internship intern in BuildInternshipFromData(table))
                {
                    internships.Add(intern);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return internships;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Internship internship = (Internship)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", internship.ID, DbType.Int32);
                dal.CreateParameter("@Archived", internship.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update Internships Set Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region BuildInternshipFromData
        private IList<Internship> BuildInternshipFromData(DataTable table)
        {
            IList<Internship> internships = new List<Internship>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Internship internship = new Internship()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Photo = row["Photo"] == DBNull.Value ? null : Global.ArrayToImage((byte[])row["Photo"]),
                        AreaOfStudy = row["AreaOfStudy"].ToString(),
                        Department = new Department() { ID = int.Parse(row["DepartmentID"].ToString()), Description = row["Department"].ToString() },
                        Unit = new Unit() { ID = int.Parse(row["UnitID"].ToString()), Description = row["Unit"].ToString() },
                        Zone = new Zone() { ID = int.Parse(row["ZoneID"].ToString()), Description = row["Zone"].ToString() },
                        StaffID = row["StaffID"] == DBNull.Value ? string.Empty : row["StaffID"].ToString(),
                        Surname = row["Surname"].ToString(),
                        OtherName = row["OtherName"].ToString(),
                        MobileNo = row["MobileNo"] == DBNull.Value ? string.Empty : row["MobileNo"].ToString(),
                        Address = row["Address"] == DBNull.Value ? string.Empty : row["Address"].ToString(),
                        SupervisorCode = row["SupervisorCode"] == DBNull.Value ? 0 : int.Parse(row["SupervisorCode"].ToString()),
                        SupervisorStaffID = row["SupervisorStaffID"] == DBNull.Value ? string.Empty : row["SupervisorStaffID"].ToString(),
                        SupervisorName = row["SupervisorName"] == DBNull.Value ? string.Empty : row["SupervisorName"].ToString(),
                        Overseer = row["Overseer"] == DBNull.Value ? string.Empty : row["Overseer"].ToString(),
                        YearStudied = row["YearStudied"] == DBNull.Value ? 0 : decimal.Parse(row["YearStudied"].ToString()),
                        DOB = row["DOB"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString()),
                        MaritalStatus = (MaritalStatusGroups)Enum.Parse(typeof(MaritalStatusGroups), row["MaritalStatus"].ToString()),
                        Gender = (GenderGroups)Enum.Parse(typeof(GenderGroups), row["Gender"].ToString()),
                        IDNumber = row["IDNumber"].ToString(),
                        Institution = row["Institution"].ToString(),
                        InternshipType = new InternshipType() { ID = int.Parse(row["InternshipTypeID"].ToString()), Description = row["InternshipType"].ToString() },
                        ReportingDate = row["ReportingDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ReportingDate"].ToString()),
                        StartDate = row["StartDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["StartDate"].ToString()),
                        EndDate = row["EndDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EndDate"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    internships.Add(internship);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return internships;
        }
        #endregion

        #region ShowImageByStaffID
        public Internship ShowImageByStaffID(object item)
        {
            Internship internship = new Internship();
            try
            {
                Internship intern = (Internship)item;
                dal.ClearParameters();
                dal.CreateParameter("@Archived", intern.Archived, DbType.Boolean);
                dal.CreateParameter("@IDNumber", intern.IDNumber, DbType.String);
                string query = "SELECT Internships.ID,Internships.IDNumber,Internships.Photo From Internships Where IDNumber=@IDNumber AND Archived=@Archived";
                DataTable table = dal.ExecuteReader(query);
                foreach (Internship inter in ShowImageData(table))
                {
                    internship = inter;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return internship;
        }
        #endregion

        #region ShowImageData
        private IList<Internship> ShowImageData(DataTable table)
        {
            IList<Internship> internships = new List<Internship>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Internship internship = new Internship()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        IDNumber = row["IDNumber"].ToString(),
                        Photo = row["Photo"] is DBNull ? null : Global.ArrayToImage((byte[])row["Photo"]),
                    };
                    internships.Add(internship);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return internships;
        }
        #endregion

        #region Open Connection
        public void OpenConnection()
        {
            try
            {
                dal.OpenConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Close Connection
        public void CloseConnection()
        {
            try
            {
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
