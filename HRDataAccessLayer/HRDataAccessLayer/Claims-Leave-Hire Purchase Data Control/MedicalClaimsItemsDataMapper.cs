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
    public class MedicalClaimsItemsDataMapper
    {
        private DALHelper dal;
        private MedicalClaims medicalClaim;

        public MedicalClaimsItemsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.medicalClaim = new MedicalClaims();
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
                MedicalClaimsItems medicalClaimsItem = (MedicalClaimsItems)item;

                dal.ClearParameters();
                dal.CreateParameter("@MedicalClaimID", medicalClaimsItem.MedicalClaim.ID, DbType.Int32);
                dal.CreateParameter("@Description", medicalClaimsItem.Description, DbType.String);
                dal.CreateParameter("@Type", medicalClaimsItem.Type, DbType.String);
                dal.CreateParameter("@Quantity", medicalClaimsItem.Quantity, DbType.Int32);
                dal.CreateParameter("@Amount", medicalClaimsItem.Amount, DbType.Decimal);
                dal.CreateParameter("@Sign", medicalClaimsItem.Sign, DbType.Boolean);
                dal.CreateParameter("@CreateUserID", medicalClaimsItem.User.ID, DbType.Int32);
                dal.CreateParameter("@CreateTime", DateTime.Now, DbType.DateTime);
                dal.ExecuteNonQuery("Insert Into MedicalClaimsItems(MedicalClaimID,Description,Type,Quantity,Amount,Sign,CreateUserID,CreateTime) Values(@MedicalClaimID,@Description,@Type,@Quantity,@Amount,@Sign,@CreateUserID,@CreateTime)");
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
                MedicalClaimsItems medicalClaimsItem = (MedicalClaimsItems)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", medicalClaimsItem.ID, DbType.Int32);
                dal.CreateParameter("@MedicalClaimID", medicalClaimsItem.MedicalClaim.ID, DbType.Int32);
                dal.CreateParameter("@Description", medicalClaimsItem.Description, DbType.String);
                dal.CreateParameter("@Type", medicalClaimsItem.Type, DbType.String);
                dal.CreateParameter("@Quantity", medicalClaimsItem.Quantity, DbType.Int32);
                dal.CreateParameter("@Amount", medicalClaimsItem.Amount, DbType.Decimal);
                dal.CreateParameter("@Sign", medicalClaimsItem.Sign, DbType.Boolean);
                dal.CreateParameter("@UpdateUserID", medicalClaimsItem.User.ID, DbType.Int32);
                dal.CreateParameter("@UpdateTime", DateTime.Now, DbType.DateTime);
                dal.ExecuteNonQuery("update MedicalClaimsItems Set MedicalClaimID=@MedicalClaimID,Description=@Description,Type=@Type,Quantity=@Quantity,Amount=@Amount,Sign=@Sign,UpdateUserID=@UpdateUserID,UpdateTime=@UpdateTime Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetAll()
        public IList<MedicalClaimsItems> GetAll()
        {
            IList<MedicalClaimsItems> medicalClaimsItems = new List<MedicalClaimsItems>();
            try
            {
                string query = "Select * From MedicalClaimsItemsView where Archived = 'False'";
                DataTable table = dal.ExecuteReader(query);
                foreach (MedicalClaimsItems mc in BuildMedicalClaimsItemsFromData(table))
                {
                    medicalClaimsItems.Add(mc);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return medicalClaimsItems;
        }
        #endregion

        #region GetByCriteria
        public IList<MedicalClaimsItems> GetByCriteria(Query query1)
        {
            IList<MedicalClaimsItems> medicalClaimsItems = new List<MedicalClaimsItems>();
            try
            {
                DataTable table = new DataTable();
                string query = "SELECT * From MedicalClaimsItemsView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Archived='False'";
                table = dal.ExecuteReader(selectStatement);
                foreach (MedicalClaimsItems mc in BuildMedicalClaimsItemsFromData(table))
                {
                    medicalClaimsItems.Add(mc);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return medicalClaimsItems;
        }
        #endregion

        #region Get By ID
        public MedicalClaimsItems GetByID(object key)
        {
            MedicalClaimsItems medicalClaimsItem = new MedicalClaimsItems();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", key.ToString().Trim(), DbType.String);
                string query = "SELECT * From MedicalClaimsItemsView ";
                query += "WHERE MedicalClaimsItemsView.ID=@ID And MedicalClaimsItemsView.Archived=@Archived ";

                table = dal.ExecuteReader(query);
                foreach (MedicalClaimsItems mci in BuildMedicalClaimsItemsFromData(table))
                {
                    medicalClaimsItem = mci;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return medicalClaimsItem;
        }
        #endregion

        #region BuildMedicalClaimsItemsFromData
        private IList<MedicalClaimsItems> BuildMedicalClaimsItemsFromData(DataTable table)
        {
            IList<MedicalClaimsItems> medicalClaimsItems = new List<MedicalClaimsItems>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    MedicalClaimsItems medicalClaimsItem = new MedicalClaimsItems()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        MedicalClaim = new MedicalClaims()
                        {
                            ID = int.Parse(row["MedicalClaimID"].ToString()),
                            PatientName = row["PatientName"].ToString(),
                            Relationship = new Relationship { ID = row["RelationshipID"] == DBNull.Value ? 0 : int.Parse(row["RelationshipID"].ToString()), Description = row["Relationship"] == DBNull.Value ? string.Empty : row["Relationship"].ToString(), },
                            OPDNumber = row["OPDNumber"].ToString(),
                            PatientDOB = row["PatientDOB"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["PatientDOB"].ToString()),
                            Diagnosis = row["Diagnosis"].ToString(),
                            DoctorName = row["DoctorName"].ToString(),
                            DoctorDate = row["DoctorDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DoctorDate"].ToString()),
                            DoctorSign = bool.Parse(row["DoctorSign"].ToString()),
                            SupervisorName = row["SupervisorName"].ToString(),
                            SupervisorSign = bool.Parse(row["SupervisorSign"].ToString()),
                            ServiceCost = decimal.Parse(row["ServiceCost"].ToString()),
                            MedicineCost = decimal.Parse(row["MedicineCost"].ToString()),
                            TotalCost = decimal.Parse(row["TotalCost"].ToString()),
                            HealthFacilityType = new HealthFacilityType { ID = row["HealthFacilityTypeID"] == DBNull.Value ? 0 : int.Parse(row["HealthFacilityTypeID"].ToString()), Description = row["HealthFacilityType"] == DBNull.Value ? string.Empty : row["HealthFacilityType"].ToString(), },
                            HealthFacilityName = row["HealthFacilityName"].ToString(),
                            PaymentDate = row["PaymentDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["PaymentDate"].ToString()),
                            EntryDate = row["EntryDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EntryDate"].ToString()),
                            ReceiptNo = row["ReceiptNo"].ToString(),
                            Paid = bool.Parse(row["Paid"].ToString()),
                            PaidToStaff = bool.Parse(row["PaidToStaff"].ToString()),
                            PaymentType = row["PaymentType"].ToString(),
                            PaidToStaffDate = row["PaidToStaffDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["PaidToStaffDate"].ToString()),
                            ChequeNumber = row["ChequeNumber"].ToString(),
                            OnPayRoll = bool.Parse(row["OnPayRoll"].ToString()),
                        },
                        Description = row["Description"].ToString(),
                        Type = row["Type"].ToString(),
                        Quantity = int.Parse(row["Quantity"].ToString()),
                        Amount = decimal.Parse(row["Amount"].ToString()),
                        Sign = bool.Parse(row["Sign"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["CreateUserID"].ToString())},
                    };

                    medicalClaimsItems.Add(medicalClaimsItem);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return medicalClaimsItems;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                MedicalClaimsItems medicalClaimsItem = (MedicalClaimsItems)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", medicalClaimsItem.ID, DbType.Int32);
                dal.CreateParameter("@Archived", medicalClaimsItem.Archived, DbType.Boolean);
                dal.CreateParameter("@ArchivedUserID", medicalClaimsItem.ArchivedUserID, DbType.Int32);
                dal.CreateParameter("@ArchivedTime", medicalClaimsItem.ArchivedTime, DbType.DateTime);
                dal.ExecuteNonQuery("Update MedicalClaimsItems Set Archived = @Archived,ArchivedUserID=@ArchivedUserID,ArchivedTime=@ArchivedTime where ID=@ID");
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
