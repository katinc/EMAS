using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control
{
    public class MedicalClaimsDataMapper
    {
        private DALHelper dal;
        private Employee employee;

        public MedicalClaimsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.employee = new Employee();
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
                MedicalClaims medicalClaims = (MedicalClaims)item;

                dal.ClearParameters();
                dal.CreateParameter("@StaffID", medicalClaims.Employee.StaffID,DbType.String);
                dal.CreateParameter("@StaffCode", medicalClaims.Employee.ID, DbType.String);
                dal.CreateParameter("@PatientName", medicalClaims.PatientName, DbType.String);
                if (medicalClaims.PatientDOB == null)
                {
                    dal.CreateParameter("@PatientDOB", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@PatientDOB", medicalClaims.PatientDOB, DbType.Date);
                }
                dal.CreateParameter("@RelationshipID", medicalClaims.Relationship.ID, DbType.Int32);
                dal.CreateParameter("@OPDNumber", medicalClaims.OPDNumber, DbType.String);
                dal.CreateParameter("@Diagnosis", medicalClaims.Diagnosis, DbType.String);
                dal.CreateParameter("@DoctorName", medicalClaims.DoctorName, DbType.String);
                if (medicalClaims.DoctorDate == null)
                {
                    dal.CreateParameter("@DoctorDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@DoctorDate", medicalClaims.DoctorDate, DbType.Date);
                }
                dal.CreateParameter("@DoctorSign", medicalClaims.DoctorSign, DbType.Boolean);

                dal.CreateParameter("@SupervisorName", medicalClaims.SupervisorName, DbType.String);
                dal.CreateParameter("@SupervisorSign", medicalClaims.SupervisorSign, DbType.Boolean);
                dal.CreateParameter("@ServiceCost", medicalClaims.ServiceCost, DbType.Decimal);
                dal.CreateParameter("@MedicineCost", medicalClaims.MedicineCost, DbType.Decimal);
                dal.CreateParameter("@TotalCost", medicalClaims.TotalCost, DbType.Decimal);
                dal.CreateParameter("@HealthFacilityType", medicalClaims.HealthFacilityType.ID, DbType.Int32);
                dal.CreateParameter("@HealthFacilityName", medicalClaims.HealthFacilityName, DbType.String);
                if (medicalClaims.EntryDate == null)
                {
                    dal.CreateParameter("@EntryDate", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@EntryDate", medicalClaims.EntryDate, DbType.DateTime);
                }
                if (medicalClaims.PaymentDate == null)
                {
                    dal.CreateParameter("@PaymentDate", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@PaymentDate", medicalClaims.PaymentDate, DbType.DateTime);
                }
                
                dal.CreateParameter("@Paid", medicalClaims.Paid, DbType.Boolean);
                dal.CreateParameter("@PaidToStaff", medicalClaims.PaidToStaff, DbType.Boolean);
                dal.CreateParameter("@PaymentType", medicalClaims.PaymentType, DbType.String);
                dal.CreateParameter("@ChequeNumber", medicalClaims.ChequeNumber, DbType.String);
                if (medicalClaims.PaidToStaffDate == null)
                {
                    dal.CreateParameter("@PaidToStaffDate", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@PaidToStaffDate", medicalClaims.PaidToStaffDate, DbType.DateTime);
                }
                dal.CreateParameter("@OnPayRoll", medicalClaims.OnPayRoll, DbType.Boolean);
                dal.CreateParameter("@ReceiptNo", medicalClaims.ReceiptNo, DbType.String);
                dal.CreateParameter("@UserID", medicalClaims.User.ID, DbType.Int32);
                dal.CreateParameter("@Reason", medicalClaims.Reason, DbType.String);

                dal.ExecuteNonQuery("Insert Into MedicalClaims(StaffID,StaffCode,PatientName,PatientDOB,RelationshipID,OPDNumber,Diagnosis,DoctorName,DoctorDate,DoctorSign,SupervisorName,SupervisorSign,ServiceCost,MedicineCost,TotalCost,HealthFacilityType,HealthFacilityName,PaymentDate,EntryDate,Paid,PaidToStaff,PaidToStaffDate,PaymentType,ChequeNumber,OnPayRoll,ReceiptNo,UserID,Reason) Values(@StaffID,@StaffCode,@PatientName,@PatientDOB,@RelationshipID,@OPDNumber,@Diagnosis,@DoctorName,@DoctorDate,@DoctorSign,@SupervisorName,@SupervisorSign,@ServiceCost,@MedicineCost,@TotalCost,@HealthFacilityType,@HealthFacilityName,@PaymentDate,@EntryDate,@Paid,@PaidToStaff,@PaidToStaffDate,@PaymentType,@ChequeNumber,@OnPayRoll,@ReceiptNo,@UserID,@Reason)");
                medicalClaims.ID = int.Parse(dal.ExecuteScalar("Select Max(ID) from MedicalClaims").ToString());
            }
            catch (Exception ex)
            {
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
                MedicalClaims medicalClaims = (MedicalClaims)item;
                dal.ClearParameters();
                dal.CreateParameter("@ClaimID", medicalClaims.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", medicalClaims.Employee.StaffID, DbType.String);                
                dal.CreateParameter("@StaffCode", medicalClaims.Employee.ID, DbType.String);

                dal.CreateParameter("@PatientName", medicalClaims.PatientName, DbType.String);
                if (medicalClaims.PatientDOB == null)
                {
                    dal.CreateParameter("@PatientDOB", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@PatientDOB", medicalClaims.PatientDOB, DbType.Date);
                }
                
                dal.CreateParameter("@RelationshipID", medicalClaims.Relationship.ID, DbType.Int32);
                dal.CreateParameter("@OPDNumber", medicalClaims.OPDNumber, DbType.String);
                dal.CreateParameter("@Diagnosis", medicalClaims.Diagnosis, DbType.String);
                dal.CreateParameter("@DoctorName", medicalClaims.DoctorName, DbType.String);
                if (medicalClaims.DoctorDate == null)
                {
                    dal.CreateParameter("@DoctorDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@DoctorDate", medicalClaims.DoctorDate, DbType.Date);
                }
                
                dal.CreateParameter("@DoctorSign", medicalClaims.DoctorSign, DbType.Boolean);

                dal.CreateParameter("@SupervisorName", medicalClaims.SupervisorName, DbType.String);
                dal.CreateParameter("@SupervisorSign", medicalClaims.SupervisorSign, DbType.Boolean);
                dal.CreateParameter("@ServiceCost", medicalClaims.ServiceCost, DbType.Decimal);
                dal.CreateParameter("@MedicineCost", medicalClaims.MedicineCost, DbType.Decimal);
                dal.CreateParameter("@TotalCost", medicalClaims.TotalCost, DbType.Decimal);
                dal.CreateParameter("@HealthFacilityTypeID", medicalClaims.HealthFacilityType.ID, DbType.Int32);
                dal.CreateParameter("@HealthFacilityName", medicalClaims.HealthFacilityName, DbType.String);
                if (medicalClaims.EntryDate == null)
                {
                    dal.CreateParameter("@EntryDate", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@EntryDate", medicalClaims.EntryDate, DbType.DateTime);
                }
                if (medicalClaims.PaymentDate == null)
                {
                    dal.CreateParameter("@PaymentDate", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@PaymentDate", medicalClaims.PaymentDate, DbType.DateTime);
                }

                dal.CreateParameter("@Paid", medicalClaims.Paid, DbType.Boolean);
                dal.CreateParameter("@PaidToStaff", medicalClaims.PaidToStaff, DbType.Boolean);
                dal.CreateParameter("@PaymentType", medicalClaims.PaymentType, DbType.String);
                dal.CreateParameter("@ChequeNumber", medicalClaims.ChequeNumber, DbType.String);
                if (medicalClaims.PaidToStaffDate == null)
                {
                    dal.CreateParameter("@PaidToStaffDate", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@PaidToStaffDate", medicalClaims.PaidToStaffDate, DbType.DateTime);
                }
                dal.CreateParameter("@OnPayRoll", medicalClaims.OnPayRoll, DbType.Boolean);
                dal.CreateParameter("@ReceiptNo", medicalClaims.ReceiptNo, DbType.String);
                dal.CreateParameter("@UserID", medicalClaims.User.ID, DbType.Int32);

                dal.CreateParameter("@Approved", medicalClaims.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedAmount", medicalClaims.ApprovedAmount, DbType.Decimal);
                dal.CreateParameter("@ApprovedUser", medicalClaims.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", medicalClaims.ApprovedUserStaffID, DbType.String);
                if (medicalClaims.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", medicalClaims.ApprovedDate, DbType.Date);
                }
                if (medicalClaims.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", medicalClaims.ApprovedTime, DbType.DateTime);
                }
                

                dal.CreateParameter("@Rejected", medicalClaims.Rejected, DbType.Boolean);
                dal.CreateParameter("@RejectedUser", medicalClaims.RejectedUser, DbType.String);
                dal.CreateParameter("@RejectedUserStaffID", medicalClaims.RejectedUserStaffID, DbType.String);
                if (medicalClaims.RejectedDate == null)
                {
                    dal.CreateParameter("@RejectedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@RejectedDate", medicalClaims.RejectedDate, DbType.Date);
                }
                if (medicalClaims.RejectedTime == null)
                {
                    dal.CreateParameter("@RejectedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@RejectedTime", medicalClaims.RejectedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", medicalClaims.Reason, DbType.String);

                dal.ExecuteNonQuery("update MedicalClaims Set StaffID=@StaffID,StaffCode=@StaffCode,Approved=@Approved,ApprovedAmount=@ApprovedAmount,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedDate=@ApprovedDate,ApprovedTime=@ApprovedTime,Rejected=@Rejected,RejectedUser=@RejectedUser,RejectedUserStaffID=@RejectedUserStaffID,RejectedDate=@RejectedDate,RejectedTime=@RejectedTime,PatientName=@PatientName,PatientDOB=@PatientDOB,RelationshipID=@RelationshipID,OPDNumber=@OPDNumber,Diagnosis=@Diagnosis,DoctorName=@DoctorName,DoctorDate=@DoctorDate,DoctorSign=@DoctorSign,SupervisorName=@SupervisorName,SupervisorSign=@SupervisorSign,ServiceCost=@ServiceCost,MedicineCost=@MedicineCost,TotalCost=@TotalCost,HealthFacilityType=@HealthFacilityTypeID,HealthFacilityName=@HealthFacilityName,PaymentDate=@PaymentDate,EntryDate=@EntryDate,Paid=@Paid,PaidToStaff=@PaidToStaff,PaidToStaffDate=@PaidToStaffDate,PaymentType=@PaymentType,ChequeNumber=@ChequeNumber,OnPayRoll=@OnPayRoll,ReceiptNo=@ReceiptNo,Reason=@Reason Where ID=@ClaimID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetAll()
        public IList<MedicalClaims> GetAll()
        {
            IList<MedicalClaims> medicalClaims = new List<MedicalClaims>();
            try
            {
                string query = "Select * From MedicalClaimView where Archived = 'False'";
                DataTable table = dal.ExecuteReader(query);
                foreach (MedicalClaims mc in BuildMedicalClaimFromData(table))
                {
                    medicalClaims.Add(mc);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return medicalClaims;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                MedicalClaims claim = (MedicalClaims) item;
                dal.ExecuteNonQuery("Update MedicalClaims Set Archived = 'True' where ID=" + claim.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<MedicalClaims> GetByCriteria(Query query1)
        {
            IList<MedicalClaims> medicalClaims = new List<MedicalClaims>();
            try
            {
                DataTable table = new DataTable();
                string query = "SELECT * From MedicalClaimView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Archived='False' ORDER BY EntryDate DESC";
                table = dal.ExecuteReader(selectStatement);
                foreach (MedicalClaims mc in BuildMedicalClaimFromData(table))
                {
                    medicalClaims.Add(mc);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return medicalClaims;
        }
        #endregion

        #region Get By ID
        public MedicalClaims GetByID(object key)
        {
            MedicalClaims medicalClaim = new MedicalClaims();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", key.ToString().Trim(), DbType.String);
                string query = "SELECT * From MedicalClaimView ";
                query += "WHERE MedicalClaimView.ID=@ID And MedicalClaimView.Archived=@Archived  ORDER BY EntryDate DESC";

                table = dal.ExecuteReader(query);
                foreach (MedicalClaims mci in BuildMedicalClaimFromData(table))
                {
                    medicalClaim = mci;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return medicalClaim;
        }
        #endregion

        #region LazyLoadByStaffID
        public MedicalClaims LazyLoadByStaffID(object item)
        {
            MedicalClaims medicalClaim = new MedicalClaims();
            try
            {
                MedicalClaims medicalC = (MedicalClaims)item;
                dal.ClearParameters();
                dal.CreateParameter("@Archived", medicalC.Archived, DbType.Boolean);
                dal.CreateParameter("@StaffID", medicalC.Employee.StaffID, DbType.String);
                string query = "SELECT * From MedicalClaimView Where Archived=@Archived and StaffID=@StaffID ORDER BY EntryDate DESC";
                DataTable table = dal.ExecuteReader(query);
                foreach (MedicalClaims mc in BuildMedicalClaimFromData(table))
                {
                    medicalClaim = mc;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return medicalClaim;
        }
        #endregion

        #region BuildMedicalClaimFromData
        private IList<MedicalClaims> BuildMedicalClaimFromData(DataTable table)
        {
            IList<MedicalClaims> medicalClaims = new List<MedicalClaims>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    MedicalClaims medicalClaim = new MedicalClaims()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                            Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
                            FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
                            OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
                            Gender = row["Gender"] == DBNull.Value ? string.Empty : row["Gender"].ToString(),
                            DOB = row["DOB"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString()),
                            NHISNumber = row["NHISNumber"] == DBNull.Value ? string.Empty : row["NHISNumber"].ToString(),
                            Zone = new Zone() { ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()), Description = row["Zone"] == DBNull.Value ? string.Empty : row["Zone"].ToString() },
                            Department = new Department() { ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()), Description = row["Department"] == DBNull.Value ? string.Empty : row["Department"].ToString() },
                            Unit = new Unit() { ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()), Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString() },
                            GradeCategory = new GradeCategory() { ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()), Description = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString() },
                            Grade = new EmployeeGrade() { ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()), Grade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString() },
                        },
                        PatientName = row["PatientName"].ToString(),
                        Relationship = new Relationship { ID = row["RelationshipID"] == DBNull.Value ? 0 : int.Parse(row["RelationshipID"].ToString()), Description = row["Relationship"] == DBNull.Value ? string.Empty : row["Relationship"].ToString(), },
                        OPDNumber = row["OPDNumber"].ToString(),
                        PatientDOB = row["PatientDOB"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["PatientDOB"].ToString()),
                        Diagnosis = row["Diagnosis"].ToString(),
                        DoctorName = row["DoctorName"].ToString(),
                        DoctorSign = bool.Parse(row["DoctorSign"].ToString()),
                        DoctorDate = row["DoctorDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DoctorDate"].ToString()),
                        SupervisorName = row["SupervisorName"].ToString(),
                        SupervisorSign = bool.Parse(row["SupervisorSign"].ToString()),
                        ServiceCost = decimal.Parse(row["ServiceCost"].ToString()),
                        MedicineCost = decimal.Parse(row["MedicineCost"].ToString()),
                        TotalCost = decimal.Parse(row["TotalCost"].ToString()),
                        HealthFacilityType = new HealthFacilityType { ID = row["HealthFacilityTypeID"] == DBNull.Value ? 0 : int.Parse(row["HealthFacilityTypeID"].ToString()), Description = row["HealthFacilityType"] == DBNull.Value ? string.Empty : row["HealthFacilityType"].ToString(), },
                        HealthFacilityName = row["HealthFacilityName"].ToString(),
                        EntryDate = row["EntryDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EntryDate"].ToString()),
                        PaymentDate = row["PaymentDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["PaymentDate"].ToString()),
                        ReceiptNo = row["ReceiptNo"].ToString(),
                        Paid = bool.Parse(row["Paid"].ToString()),
                        PaidToStaff = bool.Parse(row["PaidToStaff"].ToString()),
                        PaymentType = row["PaymentType"].ToString(),
                        PaidToStaffDate = row["PaidToStaffDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["PaidToStaffDate"].ToString()),
                        ChequeNumber = row["ChequeNumber"].ToString(),
                        OnPayRoll = bool.Parse(row["OnPayRoll"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        
                        Approved = bool.Parse(row["Approved"].ToString()),
                        ApprovedUser = row["ApprovedUser"].ToString(),
                        ApprovedAmount = decimal.Parse(row["ApprovedAmount"].ToString()),
                        ApprovedUserStaffID = row["ApprovedUserStaffID"].ToString(),
                        ApprovedDate = row["ApprovedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedDate"].ToString()),
                        ApprovedTime = row["ApprovedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedTime"].ToString()),
                        
                        Rejected = bool.Parse(row["Rejected"].ToString()),
                        RejectedUser = row["RejectedUser"].ToString(),
                        RejectedUserStaffID = row["RejectedUserStaffID"].ToString(),
                        RejectedDate = row["RejectedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["RejectedDate"].ToString()),
                        RejectedTime = row["RejectedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["RejectedTime"].ToString()),
                        Reason = row["Reason"].ToString(),
                    };

                    medicalClaims.Add(medicalClaim);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return medicalClaims;
        }
        #endregion
    }
}
