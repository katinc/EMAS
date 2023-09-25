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
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class StaffTrainingDataMapper
    {
        private DALHelper dal;
        private StaffTraining staffTraining;

        public StaffTrainingDataMapper()
        {
            this.dal = new DALHelper();
            this.staffTraining = new StaffTraining();
        }

        #region SAVE
        public void Save(StaffTraining staffTraining)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", staffTraining.Employee.StaffID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffTraining.Employee.ID.ToString(), DbType.String);
                dal.CreateParameter("@TrainingTypeID", staffTraining.TrainingType.ID, DbType.Int32);
                dal.CreateParameter("@ISTID", staffTraining.InServiceTraining.ID, DbType.Int32);
                dal.CreateParameter("@StartDate", staffTraining.StartDate, DbType.Date);
                dal.CreateParameter("@EndDate", staffTraining.EndDate, DbType.Date);
                dal.CreateParameter("@Organisers", staffTraining.Organisers.ToString(), DbType.String);
                dal.CreateParameter("@CertificateAwarded", staffTraining.CertificateAwarded.ToString(), DbType.String);
                dal.CreateParameter("@Venue", staffTraining.Venue.ToString(), DbType.String);
                dal.CreateParameter("@CostFee", staffTraining.CostFee.ToString(), DbType.String);
                dal.CreateParameter("@AccomodationFee", staffTraining.AccomodationFee.ToString(), DbType.String);
                dal.CreateParameter("@TransportationFee", staffTraining.TransportationFee.ToString(), DbType.String);
                dal.CreateParameter("@TotalCost", staffTraining.TotalCost.ToString(), DbType.String);
                dal.CreateParameter("@LocationTypeID", staffTraining.LocationType.ID, DbType.Int32);
                dal.CreateParameter("@SponsorID", staffTraining.Sponsor.ID, DbType.Int32);
                dal.CreateParameter("@UserID", staffTraining.User.ID.ToString(), DbType.String);
                dal.CreateParameter("@DateEntered", staffTraining.DateEntered, DbType.DateTime);

                dal.ExecuteNonQuery("Insert Into StaffTraining(StaffID,StaffCode,TrainingTypeID,ISTID,StartDate,EndDate,Organisers,CertificateAwarded,Venue,CostFee,AccomodationFee,TransportationFee,TotalCost,LocationTypeID,SponsorID,UserID,DateEntered) Values(@StaffID,@StaffCode,@TrainingTypeID,@ISTID,@StartDate,@EndDate,@Organisers,@CertificateAwarded,@Venue,@CostFee,@AccomodationFee,@TransportationFee,@TotalCost,@LocationTypeID,@SponsorID,@UserID,@DateEntered)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(StaffTraining staffTraining)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", staffTraining.Employee.StaffID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffTraining.Employee.ID.ToString(), DbType.String);
                dal.CreateParameter("@TrainingTypeID", staffTraining.TrainingType.ID, DbType.Int32);
                dal.CreateParameter("@ISTID", staffTraining.InServiceTraining.ID, DbType.Int32);
                dal.CreateParameter("@StartDate", staffTraining.StartDate, DbType.Date);
                dal.CreateParameter("@EndDate", staffTraining.EndDate, DbType.Date);
                dal.CreateParameter("@Organisers", staffTraining.Organisers.ToString(), DbType.String);
                dal.CreateParameter("@CertificateAwarded", staffTraining.CertificateAwarded.ToString(), DbType.String);
                dal.CreateParameter("@Venue", staffTraining.Venue.ToString(), DbType.String);
                dal.CreateParameter("@CostFee", staffTraining.CostFee.ToString(), DbType.String);
                dal.CreateParameter("@AccomodationFee", staffTraining.AccomodationFee.ToString(), DbType.String);
                dal.CreateParameter("@TransportationFee", staffTraining.TransportationFee.ToString(), DbType.String);
                dal.CreateParameter("@TotalCost", staffTraining.TotalCost.ToString(), DbType.String);
                dal.CreateParameter("@LocationTypeID", staffTraining.LocationType.ID, DbType.Int32);
                dal.CreateParameter("@SponsorID", staffTraining.Sponsor.ID, DbType.Int32);
                dal.CreateParameter("@UserID", staffTraining.User.ID.ToString(), DbType.String);
                dal.CreateParameter("@DateEntered", staffTraining.DateEntered, DbType.DateTime);
                dal.CreateParameter("@Archived", staffTraining.Archived, DbType.String);
                dal.ExecuteNonQuery("Update StaffTraining Set StaffID=@StaffID,StaffCode=@StaffCode,TrainingTypeID=@TrainingTypeID,ISTID=@ISTID,StartDate=@StartDate,EndDate=@EndDate,Organisers=@Organisers,CertificateAwarded=@CertificateAwarded,Venue=@Venue,CostFee=@CostFee,AccomodationFee=@AccomodationFee,TransportationFee=@TransportationFee,TotalCost=@TotalCost,LocationTypeID=@LocationTypeID,SponsorID=@SponsorID,UserID=@UserID,DateEntered=@DateEntered Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<StaffTraining> GetAll()
        {
            IList<StaffTraining> staffTrainings = new List<StaffTraining>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", staffTraining.Archived, DbType.String);
                string query = "SELECT StaffTraining.*,StaffPersonalInfo.*,TrainingTypes.ID as TrainingTypesID,TrainingTypes.Description as TrainingTypes,InServiceTraining.ID As InServiceTrainingID, InServiceTraining.Description as InServiceTraining,LocationTypes.ID AS LocationTypesID,LocationTypes.Description AS LocationTypes,Sponsors.ID As SponsorsID,Sponsors.Description AS Sponsors,Users.ID as UserID,Users.UserName";
                query+="FROM StaffTraining ";
                query+="inner join StaffPersonalInfo on StaffPersonalInfo.ID=StaffTraining.StaffCode ";
                query+="inner join TrainingTypes on TrainingTypes.ID=StaffTraining.TrainingTypeID ";
                query+="inner join LocationTypes on LocationTypes.ID=StaffTraining.LocationTypeID ";
                query+="inner join Sponsors on Sponsors.ID=StaffTraining.SponsorID ";
                query+="inner join Users on Users.ID=StaffTraining.UserID ";
                query+="left outer join InServiceTraining on InServiceTraining.ID=StaffTraining.ISTID ";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    staffTrainings.Add(new StaffTraining() 
                    { 
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee() { ID = int.Parse(row["ID"].ToString()), StaffID = row["StaffID"].ToString() },
                        TrainingType = new TrainingType() { ID = int.Parse(row["TrainingTypesID"].ToString()), Description = row["TrainingTypes"].ToString() },
                        InServiceTraining = new InServiceTraining() { ID = int.Parse(row["InServiceTrainingID"].ToString()), Description = row["InServiceTraining"].ToString() },
                        StartDate = DateTime.Parse(row["StartDate"].ToString()),
                        EndDate = DateTime.Parse(row["EndDate"].ToString()),
                        Organisers = row["Organisers"].ToString(),
                        CertificateAwarded = row["Organisers"].ToString(),
                        Venue = row["Organisers"].ToString(),
                        CostFee = float.Parse(row["Organisers"].ToString()),
                        AccomodationFee = float.Parse(row["Organisers"].ToString()),
                        TransportationFee = float.Parse(row["Organisers"].ToString()),
                        TotalCost = row["Organisers"].ToString(),
                        LocationType = new LocationType() { ID = int.Parse(row["LocationTypesID"].ToString()), Description = row["LocationTypes"].ToString() },
                        Sponsor = new Sponsor() { ID = int.Parse(row["SponsorsID"].ToString()), Description = row["Sponsors"].ToString() },
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        DateEntered = DateTime.Parse(row["DateEntered"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()) 
                    });
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return staffTrainings;
        }
        #endregion

        #region Get By ID

        public StaffTraining GetByID(object key)
        {
            IList<StaffTraining> staffTrainings = new List<StaffTraining>();
            dal.ClearParameters();
            dal.CreateParameter("@Archived", false, DbType.Boolean);
            dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
            DataTable table = dal.ExecuteReader("Select * from StaffTraining Where StaffID=@StaffID and Archived=@Archived");

            StaffTraining staffTraining = new StaffTraining();
            foreach (StaffTraining st in BuildStaffTrainingFromData(table))
            {
                staffTraining = st;
            }
            return staffTraining;
        }

        private IList<StaffTraining> BuildStaffTrainingFromData(DataTable table)
        {
            IList<StaffTraining> staffTrainings = new List<StaffTraining>();
            foreach (DataRow row in table.Rows)
            {
                StaffTraining staffLanguage = new StaffTraining()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Employee = new Employee() { ID = int.Parse(row["ID"].ToString()), StaffID = row["StaffID"].ToString() },
                };
                staffTrainings.Add(staffLanguage);
            }
            return staffTrainings;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", true, DbType.Boolean);
                dal.CreateParameter("@ArchivererID", staffTraining.User.ID, DbType.Int32);
                dal.CreateParameter("@ArchivedTime",DateTime.Today , DbType.DateTime);

                dal.ExecuteNonQuery("Update StaffTraining Set Archived=@Archived,ArchivererID=@ArchivererID,ArchivedTime=@ArchivedTime Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
